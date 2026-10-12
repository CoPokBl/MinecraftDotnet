using System.Text;
using ClientLib.Profiles;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ClientLib.Testing.Profiles;

/// <summary>
/// The textures property of a game profile as authlib unpacks it, the legacy skin conversion of
/// <c>SkinTextureDownloader</c>, and <c>ResolvableProfile.STREAM_CODEC</c>.
/// </summary>
public class ProfileTexturesTest {
    private static ProfileProperty Packed(string json) => new() { Name = "textures", Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(json)) };

    [Test]
    public void TestUnpacksSkinModelAndCape() {
        ProfileTextures textures = ProfileTextures.Unpack(Packed("""
            {"timestamp":1,"profileId":"853c80ef3c3749fdaa49938b674adae6","profileName":"jeb_","textures":{
              "SKIN":{"url":"http://textures.minecraft.net/texture/abc123","metadata":{"model":"slim"}},
              "CAPE":{"url":"http://textures.minecraft.net/texture/def456"}}}
            """), SignatureState.Signed);
        Assert.Multiple(() => {
            Assert.That(textures.Skin!.Hash, Is.EqualTo("abc123"));
            Assert.That(textures.Skin.GetMetadata("model"), Is.EqualTo("slim"));
            Assert.That(textures.Cape!.Url, Is.EqualTo("http://textures.minecraft.net/texture/def456"));
            Assert.That(textures.Cape.GetMetadata("model"), Is.Null);
            Assert.That(textures.Elytra, Is.Null);
            Assert.That(textures.SignatureState, Is.EqualTo(SignatureState.Signed));
        });
    }

    [Test]
    public void TestOneForeignUrlDropsEveryTexture() {
        ProfileTextures textures = ProfileTextures.Unpack(Packed("""
            {"textures":{"SKIN":{"url":"http://textures.minecraft.net/texture/abc"},"CAPE":{"url":"http://example.com/cape.png"}}}
            """), SignatureState.Unsigned);
        Assert.That(textures, Is.EqualTo(ProfileTextures.Empty));
    }

    [Test]
    public void TestTextureDomainIsExactAndLowerCase() {
        Assert.Multiple(() => {
            Assert.That(ProfileTextures.IsAllowedTextureDomain("https://textures.minecraft.net/texture/a"), Is.True);
            Assert.That(ProfileTextures.IsAllowedTextureDomain("http://Textures.minecraft.net/texture/a"), Is.False);
            Assert.That(ProfileTextures.IsAllowedTextureDomain("http://evil.textures.minecraft.net/texture/a"), Is.False);
            Assert.That(ProfileTextures.IsAllowedTextureDomain("ftp://textures.minecraft.net/texture/a"), Is.False);
            Assert.That(ProfileTextures.IsAllowedTextureDomain("not a url"), Is.False);
        });
    }

    [Test]
    public void TestUndecodablePayloadIsEmpty() {
        Assert.That(ProfileTextures.Unpack(new ProfileProperty { Name = "textures", Value = "!!" }, SignatureState.Unsigned), Is.EqualTo(ProfileTextures.Empty));
    }

    private static byte[] Pixel(byte[] image, int width, int x, int y) => image.AsSpan((y * width + x) * 4, 4).ToArray();

    [Test]
    public void TestLegacySkinGainsMirroredLeftLimbs() {
        byte[] legacy = new byte[64 * 32 * 4];
        // The right leg's front, at (4, 20), with a marker at its left edge.
        legacy[(20 * 64 + 4) * 4] = 200;
        legacy[(20 * 64 + 4) * 4 + 3] = 255;
        byte[] skin = SkinTextureProcessing.ProcessLegacySkin(64, 32, legacy)!;
        Assert.Multiple(() => {
            Assert.That(skin, Has.Length.EqualTo(64 * 64 * 4));
            // copyRect(4, 20, 16, 32, 4, 12, true, false): the left leg's front at (20, 52), mirrored.
            Assert.That(Pixel(skin, 64, 23, 52), Is.EqualTo(new byte[] { 200, 0, 0, 255 }));
            Assert.That(Pixel(skin, 64, 20, 52)[0], Is.EqualTo(0));
        });
    }

    [Test]
    public void TestBaseLayersAreMadeOpaqueAndOverlaysKeepAlpha() {
        byte[] skin = SkinTextureProcessing.ProcessLegacySkin(64, 64, new byte[64 * 64 * 4])!;
        Assert.Multiple(() => {
            Assert.That(Pixel(skin, 64, 0, 0)[3], Is.EqualTo(255), "head");
            Assert.That(Pixel(skin, 64, 40, 20)[3], Is.EqualTo(255), "body row");
            Assert.That(Pixel(skin, 64, 20, 50)[3], Is.EqualTo(255), "left leg");
            Assert.That(Pixel(skin, 64, 40, 0)[3], Is.EqualTo(0), "hat");
            Assert.That(Pixel(skin, 64, 4, 50)[3], Is.EqualTo(0), "left trouser");
        });
    }

    [Test]
    public void TestOpaqueLegacyHatIsCleared() {
        byte[] legacy = Enumerable.Repeat((byte)255, 64 * 32 * 4).ToArray();
        byte[] skin = SkinTextureProcessing.ProcessLegacySkin(64, 32, legacy)!;
        Assert.Multiple(() => {
            Assert.That(Pixel(skin, 64, 40, 4)[3], Is.EqualTo(0));
            Assert.That(Pixel(skin, 64, 40, 4)[0], Is.EqualTo(255));
        });
    }

    [Test]
    public void TestOtherSizesAreDiscarded() {
        Assert.That(SkinTextureProcessing.ProcessLegacySkin(128, 128, new byte[128 * 128 * 4]), Is.Null);
    }

    [Test]
    public void TestSha1WithRsaSignature() {
        using System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create(2048);
        System.Security.Cryptography.RSAParameters key = rsa.ExportParameters(true);
        byte[] hash = System.Security.Cryptography.SHA1.HashData("value"u8);
        // EMSA-PKCS1-v1_5 for SHA-1, then the private key's power.
        byte[] encoded = new byte[key.Modulus!.Length];
        encoded[1] = 1;
        encoded.AsSpan(2, encoded.Length - 3 - 35).Fill(0xFF);
        byte[] digestInfo = Convert.FromHexString("3021300906052B0E03021A05000414");
        digestInfo.CopyTo(encoded, encoded.Length - 35);
        hash.CopyTo(encoded, encoded.Length - 20);
        System.Numerics.BigInteger n = new(key.Modulus, true, true);
        byte[] signature = System.Numerics.BigInteger.ModPow(new System.Numerics.BigInteger(encoded, true, true), new System.Numerics.BigInteger(key.D, true, true), n)
            .ToByteArray(true, true);
        Assert.Multiple(() => {
            Assert.That(MojangServices.VerifySha1WithRsa(key, hash, signature), Is.True);
            Assert.That(MojangServices.VerifySha1WithRsa(key, System.Security.Cryptography.SHA1.HashData("other"u8), signature), Is.False);
        });
    }

    [Test]
    public void TestResolvedProfileStreamCodec() {
        Guid id = Guid.Parse("853c80ef-3c37-49fd-aa49-938b674adae6");
        // either(GAME_PROFILE, Partial): true, then the id, the name and the properties; then the patch's four optionals.
        byte[] bytes = new DataWriter()
            .WriteBoolean(true).WriteUuid(id).WriteString("jeb_")
            .WriteVarInt(1).WriteString("textures").WriteString("e30=").WriteBoolean(true).WriteString("sig")
            .WriteBoolean(false).WriteBoolean(true).WriteString("minecraft:entity/player/wide/steve").WriteBoolean(false).WriteBoolean(true).WriteBoolean(true)
            .ToArray();
        ProfileComponent.Data profile = ProfileComponent.Read(new DataReader(bytes), VanillaRegistry.Data);
        Assert.Multiple(() => {
            Assert.That(profile.Name, Is.EqualTo("jeb_"));
            Assert.That(profile.UniqueId, Is.EqualTo(id));
            Assert.That(profile.Properties.Single().Signature, Is.EqualTo("sig"));
            Assert.That(profile.Patch, Is.EqualTo(new ProfileComponent.SkinPatch(null, Identifier.Parse("minecraft:entity/player/wide/steve"), null, true)));
            Assert.That(new ProfileComponent().WriteData(profile, new DataWriter(), VanillaRegistry.Data).ToArray(), Is.EqualTo(bytes));
        });
    }

    [Test]
    public void TestNameOnlyProfileIsPartial() {
        ProfileComponent.Data profile = new("jeb_", null, []);
        byte[] bytes = new ProfileComponent().WriteData(profile, new DataWriter(), VanillaRegistry.Data).ToArray();
        Assert.Multiple(() => {
            Assert.That(bytes[0], Is.EqualTo(0), "partial");
            Assert.That(ProfileComponent.Read(new DataReader(bytes), VanillaRegistry.Data), Is.EqualTo(profile));
        });
    }
}
