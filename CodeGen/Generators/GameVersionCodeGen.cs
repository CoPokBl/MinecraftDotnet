using System.IO.Compression;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Reads the version stamps out of the server jar's own <c>version.json</c>, so a saved chunk says the
/// version it was written by rather than the one somebody last remembered to type in. A stale stamp is
/// silent: vanilla runs every data fixer between it and the current version over a chunk that needs
/// none of them.
/// </summary>
public static class GameVersionCodeGen {
    private const string FileTemplate =
"""
namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>What the server jar this build was generated from says about itself.</summary>
public static class GameVersion {
    /// <summary>
    /// <c>world_version</c>, which vanilla writes as <c>DataVersion</c> on every chunk, level and
    /// structure file and reads to decide which data fixers a file needs.
    /// </summary>
    public const int DataVersion = {dataVersion};
}

""";

    public static void GenerateGameVersionCode(JObject _) {
        using ZipArchive jar = ZipFile.OpenRead(CodeGenUtils.ServerJarPath);
        ZipArchiveEntry entry = jar.GetEntry("version.json")
            ?? throw new InvalidOperationException("The server jar has no version.json.");

        using StreamReader reader = new(entry.Open());
        JObject version = JObject.Parse(reader.ReadToEnd());
        int dataVersion = version["world_version"]?.Value<int>()
            ?? throw new InvalidOperationException("version.json has no world_version.");

        File.WriteAllText("GameVersion.cs", FileTemplate.Replace("{dataVersion}", dataVersion.ToString()));
    }
}
