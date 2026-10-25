using System.Text;
using ClientLib.Packs;

namespace ClientLib.Testing.Packs;

/// <summary><c>Pack.readPackMetadata</c> and <c>PackFormat.IntermediaryFormat.validate</c> against client format 88.0.</summary>
public class PackMetadataTest {
    private static PackMetadata? Read(string json) => PackMetadata.Read(Encoding.UTF8.GetBytes(json));

    private static PackCompatibility? Compatibility(string pack) => Read("{\"pack\":{\"description\":\"d\"," + pack + "}}")?.Compatibility;

    [Test]
    public void TestMinAndMaxFormatAboveTheOldRange() {
        // min 88 reads as 88.0 and max 88 as 88.*, which 88.0 is inside.
        Assert.That(Compatibility("\"min_format\":88,\"max_format\":88"), Is.EqualTo(PackCompatibility.Compatible));
        Assert.That(Compatibility("\"min_format\":[88,1],\"max_format\":90"), Is.EqualTo(PackCompatibility.TooNew));
        Assert.That(Compatibility("\"min_format\":70,\"max_format\":[87,5]"), Is.EqualTo(PackCompatibility.TooOld));
    }

    [Test]
    public void TestOldPackFormatsAreTooOld() {
        Assert.That(Compatibility("\"pack_format\":34"), Is.EqualTo(PackCompatibility.TooOld));
        Assert.That(Compatibility("\"pack_format\":34,\"supported_formats\":[34,64]"), Is.EqualTo(PackCompatibility.TooOld));
        Assert.That(Compatibility("\"pack_format\":34,\"supported_formats\":{\"min_inclusive\":34,\"max_inclusive\":64}"), Is.EqualTo(PackCompatibility.TooOld));
    }

    [Test]
    public void TestRangeSpanningTheOldFieldsNeedsThemToAgree() {
        Assert.That(Compatibility("\"pack_format\":60,\"supported_formats\":[60,64],\"min_format\":60,\"max_format\":88"),
            Is.EqualTo(PackCompatibility.Compatible));
        // Without supported_formats a range starting at or below 64 fails validation, and only the description is kept.
        Assert.That(Compatibility("\"pack_format\":60,\"min_format\":60,\"max_format\":88"), Is.EqualTo(PackCompatibility.Unknown));
        Assert.That(Compatibility("\"pack_format\":60,\"supported_formats\":[61,64],\"min_format\":60,\"max_format\":88"),
            Is.EqualTo(PackCompatibility.Unknown));
    }

    [Test]
    public void TestBrokenFormatsFallBackToUnknown() {
        Assert.That(Compatibility("\"pack_format\":88"), Is.EqualTo(PackCompatibility.Unknown), "a lone pack_format above 64 must have min and max");
        Assert.That(Compatibility("\"min_format\":88"), Is.EqualTo(PackCompatibility.Unknown));
        Assert.That(Compatibility("\"min_format\":-1,\"max_format\":88"), Is.EqualTo(PackCompatibility.Unknown));
        Assert.That(Compatibility("\"min_format\":90,\"max_format\":88"), Is.EqualTo(PackCompatibility.Unknown));
        Assert.That(Compatibility("\"pack_format\":10"), Is.EqualTo(PackCompatibility.TooOld), "a single format below 15 is still a range of one");
        Assert.That(Compatibility("\"pack_format\":10,\"supported_formats\":[10,12]"), Is.EqualTo(PackCompatibility.Unknown),
            "a multi-version pack may not start below 15");
    }

    [Test]
    public void TestMissingPackSectionOrDescriptionIsNoPack() {
        Assert.That(Read("{}"), Is.Null);
        Assert.That(Read("{\"pack\":{\"min_format\":88,\"max_format\":88}}"), Is.Null);
        Assert.That(Read("not json"), Is.Null);
        Assert.That(PackMetadata.Read(null), Is.Null);
    }

    [Test]
    public void TestDescriptionIsAComponent() {
        PackMetadata? meta = Read("{\"pack\":{\"description\":{\"text\":\"Hi\",\"color\":\"red\"},\"min_format\":88,\"max_format\":88}}");
        Assert.That(meta, Is.Not.Null);
        Assert.That(TextFlattener.Plain(meta!.Description), Is.EqualTo("Hi"));
    }

    [Test]
    public void TestLanguages() {
        IReadOnlyDictionary<string, LanguageInfo>? languages = PackMetadata.Languages(Encoding.UTF8.GetBytes(
            "{\"language\":{\"ar_sa\":{\"name\":\"Arabic\",\"region\":\"Saudi Arabia\",\"bidirectional\":true},\"de_de\":{\"name\":\"Deutsch\",\"region\":\"Deutschland\"}}}"));
        Assert.That(languages, Is.Not.Null);
        Assert.That(languages!["ar_sa"], Is.EqualTo(new LanguageInfo("Saudi Arabia", "Arabic", true)));
        Assert.That(languages["de_de"].Display, Is.EqualTo("Deutsch (Deutschland)"));
        Assert.That(PackMetadata.Languages(Encoding.UTF8.GetBytes("{\"language\":{\"xx\":{\"name\":\"\",\"region\":\"R\"}}}")), Is.Null,
            "one bad entry loses the pack's whole section");
    }

    private static IReadOnlyList<string>? Overlays(string entries) =>
        Read("{\"pack\":{\"description\":\"d\",\"min_format\":88,\"max_format\":88},\"overlays\":{\"entries\":" + entries + "}}")?.Overlays;

    [Test]
    public void TestOverlaysApplyByRangeInListedOrder() {
        // a covers 80.0 to 88.*, b starts at 89, c is exactly 88.0 to 88.0.
        Assert.That(Overlays("[{\"directory\":\"a\",\"min_format\":80,\"max_format\":88},{\"directory\":\"b\",\"min_format\":89,\"max_format\":90}," +
                             "{\"directory\":\"c\",\"min_format\":[88,0],\"max_format\":[88,0]}]"), Is.EqualTo(new[] { "a", "c" }));
        Assert.That(Overlays("[{\"directory\":\"later\",\"min_format\":[88,1],\"max_format\":90}]"), Is.Empty, "88.1 is after this version's 88.0");
    }

    [Test]
    public void TestOldFormatsAreNeededOnceAnyEntryReachesBackTo64() {
        // x reaches 34, so every entry must carry formats; y does, and agrees with its min and max.
        Assert.That(Overlays("[{\"directory\":\"x\",\"formats\":[34,64]},{\"directory\":\"y\",\"min_format\":60,\"max_format\":90,\"formats\":[60,64]}]"),
            Is.EqualTo(new[] { "y" }));
        Assert.That(Overlays("[{\"directory\":\"x\",\"formats\":[34,64]},{\"directory\":\"y\",\"min_format\":70,\"max_format\":90}]"), Is.Null,
            "a broken overlays section leaves the whole pack out");
        Assert.That(Overlays("[{\"directory\":\"y\",\"min_format\":70,\"max_format\":90,\"formats\":[70,90]}]"), Is.Null,
            "formats is refused once every entry starts above 64");
    }

    [Test]
    public void TestBrokenOverlayEntries() {
        Assert.That(Overlays("[{\"directory\":\"z\"},{\"directory\":\"a\",\"min_format\":88,\"max_format\":88}]"), Is.EqualTo(new[] { "a" }),
            "an entry naming no formats is skipped");
        Assert.That(Overlays("[{\"directory\":\"a/b\",\"min_format\":88,\"max_format\":88}]"), Is.Null, "a directory outside [-_a-zA-Z0-9.]");
        Assert.That(Overlays("[{\"directory\":\"a\",\"min_format\":88}]"), Is.Null, "min without max");
        Assert.That(Read("{\"pack\":{\"description\":\"d\",\"min_format\":88,\"max_format\":88},\"overlays\":{}}"), Is.Null, "entries is required");
        Assert.That(Read("{\"pack\":{\"description\":\"d\",\"min_format\":88,\"max_format\":88}}")!.Overlays, Is.Empty);
    }

    [Test]
    public void TestOverlaysFollowTheGameVersion() {
        byte[] mcmeta = Encoding.UTF8.GetBytes("{\"pack\":{\"description\":\"d\",\"min_format\":80,\"max_format\":99}," +
                                               "\"overlays\":{\"entries\":[{\"directory\":\"new\",\"min_format\":[90,2],\"max_format\":99}]}}");
        Assert.That(PackMetadata.Read(mcmeta, new PackFormat(88, 0))!.Overlays, Is.Empty);
        Assert.That(PackMetadata.Read(mcmeta, new PackFormat(90, 2))!.Overlays, Is.EqualTo(new[] { "new" }));
    }
}
