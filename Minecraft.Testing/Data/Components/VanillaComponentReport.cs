using System.Text.Json;
using Minecraft.Schemas;

namespace Minecraft.Testing.Data.Components;

/// <summary>One item's default value for one component, as vanilla's own codec wrote it.</summary>
public readonly record struct ReportedComponent(string Item, Identifier Component, JsonElement Value);

/// <summary>
/// Vanilla's encoding of every item's default components, which is what the codec round trip is
/// checked against.
/// </summary>
/// <remarks>
/// <b>Not committed, and not fetched either.</b> These come out of the vanilla data generator, so
/// they are Mojang's files and cannot live here; they are read from the generator's output directory
/// when it is present and the tests that want them are skipped when it is not. Running the
/// generator for the version under test is what turns those tests on.
/// <p/>
/// Covers 59 of the components. What it cannot cover is the tag widths, since JSON does not carry
/// them, and any component no item has a default for.
/// </remarks>
public static class VanillaComponentReport {
    private const string Version = "26.3";

    private static readonly Lazy<ReportedComponent[]?> Cache = new(Load);

    /// <summary>Every reported value, or null when the generator has not been run.</summary>
    public static ReportedComponent[]? Entries => Cache.Value;

    /// <summary>The reported values, skipping the test when they are not on disk.</summary>
    public static ReportedComponent[] Require() {
        return Entries ?? throw new IgnoreException(
            $"No component report for {Version}. Run CodeGen for it first: "
            + $"cd CodeGen/bin/Debug/net10.0 && ./CodeGen {Version}");
    }

    private static ReportedComponent[]? Load() {
        string? directory = Locate();

        if (directory is null) {
            return null;
        }

        List<ReportedComponent> entries = [];

        foreach (string file in Directory.EnumerateFiles(directory, "*.json").Order(StringComparer.Ordinal)) {
            using JsonDocument document = JsonDocument.Parse(File.ReadAllText(file));
            string item = Path.GetFileNameWithoutExtension(file);

            foreach (JsonProperty component in document.RootElement.GetProperty("components").EnumerateObject()) {
                // Cloned because the values outlive the document they were parsed from.
                entries.Add(new ReportedComponent(item, component.Name, component.Value.Clone()));
            }
        }

        return entries.ToArray();
    }

    private static string? Locate() {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);

        while (directory is not null) {
            string candidate = Path.Combine(directory.FullName, "CodeGen", "bin", "Debug", "net10.0",
                $"vanilladata{Version}", "reports", "minecraft", "components", "item");

            if (Directory.Exists(candidate)) {
                return candidate;
            }

            directory = directory.Parent;
        }

        return null;
    }
}
