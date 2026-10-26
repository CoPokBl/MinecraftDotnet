using System.Globalization;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace ClientLib.Packs;

/// <summary><c>HttpUtil.DownloadProgressListener</c>, called from the download thread.</summary>
public interface IDownloadProgressListener {
    void RequestStart();

    void DownloadStart(long? sizeBytes);

    void DownloadedBytes(long bytesSoFar);

    void RequestFinished(bool success);
}

/// <summary>
/// <c>DownloadQueue</c>: downloads one batch at a time on a background thread into a cache folder, a
/// folder per pack id and a file per SHA-1, and logs each download to <c>log.json</c> there.
/// </summary>
public sealed class PackDownloadQueue : IDisposable {
    private const int MaxKeptPacks = 20;

    private readonly string _cacheDir;
    private readonly HttpClient _http;
    private readonly object _tasksLock = new();
    private Task _tasks = Task.CompletedTask;

    public PackDownloadQueue(string cacheDir) {
        _cacheDir = cacheDir;
        Directory.CreateDirectory(cacheDir);
        DownloadCacheCleaner.VacuumCacheDir(cacheDir, MaxKeptPacks);
        // HttpURLConnection.openConnection(Proxy.NO_PROXY), following redirects.
        _http = new HttpClient(new SocketsHttpHandler { UseProxy = false, AllowAutoRedirect = true }) { Timeout = Timeout.InfiniteTimeSpan };
    }

    /// <summary><c>downloadBatch</c>: runs after any batch already queued.</summary>
    public Task<PackBatchResult> DownloadBatch(int maxSize, IReadOnlyList<(string Name, string Value)> headers, IDownloadProgressListener listener,
        Dictionary<Guid, PackDownloadRequest> requests) {
        lock (_tasksLock) {
            Task<PackBatchResult> batch = _tasks.ContinueWith(_ => RunDownload(maxSize, headers, listener, requests), TaskScheduler.Default);
            _tasks = batch;
            return batch;
        }
    }

    private PackBatchResult RunDownload(int maxSize, IReadOnlyList<(string Name, string Value)> headers, IDownloadProgressListener listener,
        Dictionary<Guid, PackDownloadRequest> requests) {
        PackBatchResult result = new();
        foreach ((Guid id, PackDownloadRequest request) in requests) {
            string targetDir = Path.Combine(_cacheDir, id.ToString());
            string? downloadedFile = null;
            try {
                downloadedFile = DownloadFile(targetDir, request.Url, headers, request.Hash, maxSize, listener);
                result.Downloaded[id] = downloadedFile;
            }
            catch (Exception e) {
                Console.Error.WriteLine($"Failed to download {request.Url}: {e.GetBaseException().Message}");
                result.Failed.Add(id);
            }
            try {
                WriteLog(id, request, downloadedFile);
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
                Console.Error.WriteLine($"Failed to log download of {request.Url}: {e.Message}");
            }
        }
        return result;
    }

    /// <summary><c>JsonEventLog.write</c> of a <c>DownloadQueue.LogEntry</c>: one JSON object a line.</summary>
    private void WriteLog(Guid id, PackDownloadRequest request, string? downloadedFile) {
        JObject entry = new() {
            ["id"] = id.ToString(),
            ["url"] = request.Url.ToString(),
            ["time"] = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", CultureInfo.InvariantCulture)
        };
        if (request.Hash != null) {
            entry["hash"] = request.Hash;
        }
        if (downloadedFile == null) {
            entry["error"] = "download_failed";
        }
        else {
            try {
                entry["file"] = new JObject {
                    ["name"] = Path.GetRelativePath(_cacheDir, downloadedFile),
                    ["size"] = new FileInfo(downloadedFile).Length
                };
            }
            catch (IOException) {
                entry["error"] = "no_access";
            }
        }
        File.AppendAllText(Path.Combine(_cacheDir, "log.json"), entry.ToString(Newtonsoft.Json.Formatting.None) + "\n");
    }

    /// <summary>
    /// <c>HttpUtil.downloadFile</c>. With a hash, a cached file that matches it is used without a request
    /// and one that does not is deleted first; the download must then match. Without one, the file is kept
    /// under the hash it turned out to have.
    /// </summary>
    private string DownloadFile(string targetDir, Uri url, IReadOnlyList<(string Name, string Value)> headers, string? requestedHash, int maxSize,
        IDownloadProgressListener listener) {
        listener.RequestStart();
        string? targetFile = null;
        if (requestedHash != null) {
            targetFile = Path.Combine(targetDir, requestedHash);
            try {
                if (CheckExistingFile(targetFile, requestedHash)) {
                    listener.RequestFinished(true);
                    UpdateModificationTime(targetFile);
                    return targetFile;
                }
            }
            catch (IOException e) {
                Console.Error.WriteLine($"Failed to check cached file {targetFile}: {e.Message}");
            }
            try {
                if (File.Exists(targetFile)) {
                    File.Delete(targetFile);
                }
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
                listener.RequestFinished(false);
                throw new IOException($"Failed to remove existing file {targetFile}", e);
            }
        }

        try {
            using HttpRequestMessage message = new(HttpMethod.Get, url);
            foreach ((string name, string value) in headers) {
                message.Headers.TryAddWithoutValidation(name, value);
            }
            using HttpResponseMessage response = _http.Send(message, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            using Stream input = response.Content.ReadAsStream();
            long? size = response.Content.Headers.ContentLength;
            Directory.CreateDirectory(targetDir);
            listener.DownloadStart(size);
            if (size > maxSize) {
                throw new IOException($"Filesize is bigger than maximum allowed (file is {size}, limit is {maxSize})");
            }

            if (targetFile == null) {
                string tmpPath = Path.Combine(targetDir, "download" + Random.Shared.NextInt64() + ".tmp");
                try {
                    string actualHash = DownloadAndHash(maxSize, listener, input, tmpPath);
                    string actualPath = Path.Combine(targetDir, actualHash);
                    if (!CheckExistingFile(actualPath, actualHash)) {
                        File.Move(tmpPath, actualPath, overwrite: true);
                    }
                    else {
                        UpdateModificationTime(actualPath);
                    }
                    listener.RequestFinished(true);
                    return actualPath;
                }
                finally {
                    File.Delete(tmpPath);
                }
            }

            string downloadedHash = DownloadAndHash(maxSize, listener, input, targetFile);
            if (downloadedHash != requestedHash) {
                throw new IOException($"Hash of downloaded file ({downloadedHash}) did not match requested ({requestedHash})");
            }
            listener.RequestFinished(true);
            return targetFile;
        }
        catch (Exception e) {
            listener.RequestFinished(false);
            throw new InvalidOperationException($"Failed to download file {url}", e);
        }
    }

    private static void UpdateModificationTime(string file) {
        try {
            File.SetLastWriteTimeUtc(file, DateTime.UtcNow);
        }
        catch (IOException e) {
            Console.Error.WriteLine($"Failed to update modification time of {file}: {e.Message}");
        }
    }

    private static string HashFile(string file) {
        using FileStream stream = File.OpenRead(file);
        return Convert.ToHexStringLower(SHA1.HashData(stream));
    }

    private static bool CheckExistingFile(string file, string expectedHash) {
        if (!File.Exists(file)) {
            return false;
        }
        string actualHash = HashFile(file);
        if (actualHash == expectedHash) {
            return true;
        }
        Console.Error.WriteLine($"Mismatched hash of file {file}, expected {expectedHash} but found {actualHash}");
        return false;
    }

    /// <summary><c>downloadAndHash</c>: the size limit is checked as the bytes arrive, whatever the server said the length was.</summary>
    private static string DownloadAndHash(int maxSize, IDownloadProgressListener listener, Stream input, string downloadFile) {
        using FileStream output = new(downloadFile, FileMode.OpenOrCreate, FileAccess.Write);
        using IncrementalHash hasher = IncrementalHash.CreateHash(HashAlgorithmName.SHA1);
        byte[] buffer = new byte[8196];
        long readSoFar = 0;
        int read;
        while ((read = input.Read(buffer)) > 0) {
            readSoFar += read;
            listener.DownloadedBytes(readSoFar);
            if (readSoFar > maxSize) {
                throw new IOException($"Filesize was bigger than maximum allowed (got >= {readSoFar}, limit was {maxSize})");
            }
            output.Write(buffer, 0, read);
            hasher.AppendData(buffer, 0, read);
        }
        return Convert.ToHexStringLower(hasher.GetHashAndReset());
    }

    public void Dispose() => _http.Dispose();
}

/// <summary><c>DownloadCacheCleaner</c>.</summary>
public static class DownloadCacheCleaner {
    /// <summary>
    /// <c>vacuumCacheDir</c>: past <paramref name="maxFiles"/> files in the folders under the cache, deletes
    /// the oldest copies first from the folders holding the most, then any folder left empty.
    /// </summary>
    public static void VacuumCacheDir(string cacheDir, int maxFiles) {
        try {
            List<(string Path, DateTime Time)> filesAndDates = ListFilesWithModificationTimes(cacheDir);
            int toRemove = filesAndDates.Count - maxFiles;
            if (toRemove <= 0) {
                return;
            }
            // NEWEST_FIRST, then the stable sort by priority after a reverse: oldest first within a priority.
            List<(string Path, DateTime Time)> newestFirst = filesAndDates.OrderByDescending(f => f.Time).ToList();
            List<(string Path, int RemovalPriority)> filesWithDirOrder = PrioritizeFilesInDirs(newestFirst);
            filesWithDirOrder.Reverse();
            filesWithDirOrder = filesWithDirOrder.OrderByDescending(f => f.RemovalPriority).ToList();
            HashSet<string> emptyDirectoryCandidates = [];
            for (int i = 0; i < toRemove; i++) {
                (string pathToRemove, int priority) = filesWithDirOrder[i];
                try {
                    File.Delete(pathToRemove);
                    if (priority == 0) {
                        emptyDirectoryCandidates.Add(Path.GetDirectoryName(pathToRemove)!);
                    }
                }
                catch (IOException e) {
                    Console.Error.WriteLine($"Failed to delete cache file {pathToRemove}: {e.Message}");
                }
            }
            emptyDirectoryCandidates.Remove(Path.GetFullPath(cacheDir).TrimEnd(Path.DirectorySeparatorChar));
            foreach (string dir in emptyDirectoryCandidates) {
                try {
                    if (!Directory.EnumerateFileSystemEntries(dir).Any()) {
                        Directory.Delete(dir);
                    }
                }
                catch (IOException e) {
                    Console.Error.WriteLine($"Failed to delete empty(?) cache directory {dir}: {e.Message}");
                }
            }
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
            Console.Error.WriteLine($"Failed to vacuum cache dir {cacheDir}: {e.Message}");
        }
    }

    /// <summary>Every file below the cache's own folder, the log beside them being left alone.</summary>
    private static List<(string Path, DateTime Time)> ListFilesWithModificationTimes(string cacheDir) {
        if (!Directory.Exists(cacheDir)) {
            return [];
        }
        string root = Path.GetFullPath(cacheDir).TrimEnd(Path.DirectorySeparatorChar);
        return Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories)
            .Where(file => Path.GetDirectoryName(file) != root)
            .Select(file => (file, File.GetLastWriteTimeUtc(file)))
            .ToList();
    }

    /// <summary><c>prioritizeFilesInDirs</c>: each file's count of newer files in its folder.</summary>
    private static List<(string Path, int RemovalPriority)> PrioritizeFilesInDirs(List<(string Path, DateTime Time)> filesAndDates) {
        List<(string, int)> result = [];
        Dictionary<string, int> parentCounts = new();
        foreach ((string path, _) in filesAndDates) {
            string parent = Path.GetDirectoryName(path)!;
            int removalPriority = parentCounts.GetValueOrDefault(parent);
            parentCounts[parent] = removalPriority + 1;
            result.Add((path, removalPriority));
        }
        return result;
    }
}
