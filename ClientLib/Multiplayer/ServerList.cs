using Minecraft.Implementations.Storage;
using NBT;
using NBT.Tags;

namespace ClientLib.Multiplayer;

/// <summary>
/// <c>ServerList</c>: the saved servers, and up to 16 hidden ones that direct connect remembered, kept in an
/// uncompressed <c>servers.dat</c> in the directory given.
/// </summary>
public sealed class ServerList(string directory) {
    private const int MaxHiddenServers = 16;

    private static readonly SemaphoreSlim Io = new(1, 1);

    private readonly List<ServerData> _servers = [];
    private readonly List<ServerData> _hidden = [];

    public int Count => _servers.Count;

    public ServerData this[int index] => _servers[index];

    private string File(string name) => Path.Combine(directory, name);

    public void Load() {
        try {
            _servers.Clear();
            _hidden.Clear();
            string path = File("servers.dat");
            if (!System.IO.File.Exists(path)) {
                return;
            }
            CompoundTag root = NbtRoot.Parse(System.IO.File.ReadAllBytes(path));
            if (root["servers"] is not ListTag list) {
                return;
            }
            foreach (INbtTag entry in list.Tags) {
                if (entry is not CompoundTag tag) {
                    continue;
                }
                ServerData server = ServerData.Read(tag);
                if (ServerData.NumericValue(tag["hidden"]) is { } hidden && (sbyte)hidden != 0) {
                    _hidden.Add(server);
                }
                else {
                    _servers.Add(server);
                }
            }
        }
        catch (Exception e) when (e is IOException or InvalidDataException or UnauthorizedAccessException) {
            Console.Error.WriteLine($"Couldn't load server list: {e.Message}");
        }
    }

    /// <summary><c>save</c>: written beside the file, then swapped in with the old one kept as <c>servers.dat_old</c>.</summary>
    public void Save() {
        try {
            List<INbtTag> tags = [];
            foreach (ServerData server in _servers) {
                tags.Add(server.Write().WithChild("hidden", new ByteTag(0)));
            }
            foreach (ServerData server in _hidden) {
                tags.Add(server.Write().WithChild("hidden", new ByteTag(1)));
            }
            byte[] data = NbtRoot.Serialise(new CompoundTag(("servers", new ListTag(tags))));
            Directory.CreateDirectory(directory);
            string temporary = File($"servers{Random.Shared.NextInt64()}.dat");
            System.IO.File.WriteAllBytes(temporary, data);
            SafeReplace(File("servers.dat"), temporary, File("servers.dat_old"));
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
            Console.Error.WriteLine($"Couldn't save server list: {e.Message}");
        }
    }

    /// <summary><c>Util.safeReplaceFile</c>: the current file becomes the backup, then the new one takes its place.</summary>
    private static void SafeReplace(string target, string replacement, string backup) {
        if (System.IO.File.Exists(target)) {
            System.IO.File.Move(target, backup, true);
        }
        System.IO.File.Move(replacement, target, true);
    }

    /// <summary><c>get(String)</c>: the shown or hidden server with the address.</summary>
    public ServerData? Get(string ip) => _servers.Find(s => s.Ip == ip) ?? _hidden.Find(s => s.Ip == ip);

    public ServerData? Unhide(string ip) {
        int index = _hidden.FindIndex(s => s.Ip == ip);
        if (index < 0) {
            return null;
        }
        ServerData server = _hidden[index];
        _hidden.RemoveAt(index);
        _servers.Add(server);
        return server;
    }

    public void Remove(ServerData server) {
        if (!_servers.Remove(server)) {
            _hidden.Remove(server);
        }
    }

    public void Add(ServerData server, bool hidden) {
        if (hidden) {
            _hidden.Insert(0, server);
            while (_hidden.Count > MaxHiddenServers) {
                _hidden.RemoveAt(_hidden.Count - 1);
            }
        }
        else {
            _servers.Add(server);
        }
    }

    public void Swap(int a, int b) {
        (_servers[a], _servers[b]) = (_servers[b], _servers[a]);
        Save();
    }

    public void Replace(int index, ServerData server) => _servers[index] = server;

    private static bool Set(ServerData server, List<ServerData> list) {
        int index = list.FindIndex(s => s.Name == server.Name && s.Ip == server.Ip);
        if (index < 0) {
            return false;
        }
        list[index] = server;
        return true;
    }

    /// <summary>
    /// <c>saveSingleServer</c>: the file read afresh with this one entry, matched by name and address,
    /// replaced, on a worker one save at a time.
    /// </summary>
    public static Task SaveSingleServer(string directory, ServerData server) => Task.Run(async () => {
        await Io.WaitAsync();
        try {
            ServerList list = new(directory);
            list.Load();
            if (!Set(server, list._servers)) {
                Set(server, list._hidden);
            }
            list.Save();
        }
        finally {
            Io.Release();
        }
    });
}
