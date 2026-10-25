using System.Text;
using ClientLib;
using ClientLib.Packs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// <c>LanguageManager</c>: the languages the packs offer and the selected one, whose translations each reload
/// puts over English. A key no pack has falls back to this client's own wording.
/// </summary>
public sealed class LanguageManager(string selected) {
    public const string DefaultCode = "en_us";

    private static readonly LanguageInfo DefaultLanguage = new("US", "English", false);

    public string Selected { get; set; } = selected;

    /// <summary>By code, in code order as <c>getLanguages</c> sorts them.</summary>
    public SortedDictionary<string, LanguageInfo> Languages { get; private set; } = new(StringComparer.Ordinal) { [DefaultCode] = DefaultLanguage };

    /// <summary>What <see cref="Prepare"/> read, for <see cref="Apply"/> to put in use.</summary>
    public sealed record Prepared(SortedDictionary<string, LanguageInfo> Languages, Dictionary<string, string> Translations, bool DefaultRightToLeft);

    /// <summary><c>onResourceManagerReload</c>.</summary>
    public void Reload(PackFiles? files) => Apply(Prepare(files, Selected));

    /// <summary><c>onResourceManagerReload</c>'s reading, which touches nothing in use and so may run on any thread.</summary>
    public static Prepared Prepare(PackFiles? files, string selected) {
        SortedDictionary<string, LanguageInfo> languages = ExtractLanguages(files);
        List<string> languageStack = [DefaultCode];
        bool defaultRightToLeft = DefaultLanguage.Bidirectional;
        if (selected != DefaultCode && languages.TryGetValue(selected, out LanguageInfo? current)) {
            languageStack.Add(selected);
            defaultRightToLeft = current.Bidirectional;
        }
        return new Prepared(languages, files != null ? LoadFrom(files, languageStack) : new Dictionary<string, string>(), defaultRightToLeft);
    }

    public void Apply(Prepared prepared) {
        Languages = prepared.Languages;
        Translations.Load(prepared.Translations, prepared.DefaultRightToLeft);
    }

    /// <summary><c>extractLanguages</c>: each pack's <c>language</c> section, the lowest pack's entry winning a clash.</summary>
    private static SortedDictionary<string, LanguageInfo> ExtractLanguages(PackFiles? files) {
        SortedDictionary<string, LanguageInfo> result = new(StringComparer.Ordinal);
        foreach (PackFiles.IPack pack in files?.Packs ?? []) {
            foreach ((string code, LanguageInfo info) in PackMetadata.Languages(pack.Read("pack.mcmeta")) ?? new Dictionary<string, LanguageInfo>()) {
                result.TryAdd(code, info);
            }
        }
        // The game's languages come from the asset index; without it only English is known, as vanilla's default map has.
        result.TryAdd(DefaultCode, DefaultLanguage);
        return result;
    }

    /// <summary>
    /// <c>ClientLanguage.loadFrom</c>: each language's file from every namespace and every pack, lowest first, then
    /// the game's <c>deprecated.json</c> dropping and renaming keys.
    /// </summary>
    private static Dictionary<string, string> LoadFrom(PackFiles files, List<string> languageStack) {
        Dictionary<string, string> translations = new();
        List<string> namespaces = files.Paths("assets/").Select(path => path.Split('/')[1]).Distinct().Order(StringComparer.Ordinal).ToList();
        foreach (string code in languageStack) {
            foreach (string ns in namespaces) {
                foreach (byte[] file in files.ReadEach($"assets/{ns}/lang/{code}.json")) {
                    try {
                        foreach ((string key, JToken? value) in JObject.Parse(Encoding.UTF8.GetString(file))) {
                            if (value?.Type == JTokenType.String) {
                                translations[key] = value.Value<string>()!;
                            }
                        }
                    }
                    catch (JsonException e) {
                        Console.Error.WriteLine($"Failed to load translations for {code}: {e.Message}");
                    }
                }
            }
        }
        ApplyDeprecated(files, translations);
        return translations;
    }

    /// <summary>
    /// <c>DeprecatedTranslationsInfo.applyToMap</c>. Vanilla reads the file from its own jar whatever the packs
    /// are; here it is the lowest pack's, which is the jar when the game's own pack is loaded.
    /// </summary>
    private static void ApplyDeprecated(PackFiles files, Dictionary<string, string> translations) {
        if (files.ReadEach("assets/minecraft/lang/deprecated.json").FirstOrDefault() is not { } data) {
            return;
        }
        JObject deprecated;
        try {
            deprecated = JObject.Parse(Encoding.UTF8.GetString(data));
        }
        catch (JsonException) {
            return;
        }
        foreach (JToken key in deprecated["removed"] as JArray ?? []) {
            translations.Remove(key.ToString());
        }
        foreach ((string fromKey, JToken? toKey) in deprecated["renamed"] as JObject ?? []) {
            if (translations.Remove(fromKey, out string? value)) {
                translations[toKey!.ToString()] = value;
            }
            else {
                translations.Remove(toKey!.ToString());
            }
        }
    }
}
