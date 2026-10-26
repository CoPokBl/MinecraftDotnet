using ClientLib.World;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Schemas.Vec;
using EnvironmentAttribute = Minecraft.Data.Generated.EnvironmentAttribute;

namespace GraphicalClient.Audio;

/// <summary>The three audio attributes the client reads, from the level's <c>EnvironmentAttributeSystem</c> at a point.</summary>
public static class AudioEnvironment {
    public static BackgroundMusic BackgroundMusic(ClientLevel level, double x, double y, double z) =>
        level.Environment.Attributes.GetValue(EnvironmentAttribute.AudioBackgroundMusic, new Vec3<double>(x, y, z));

    public static AmbientSounds AmbientSounds(ClientLevel level, double x, double y, double z) =>
        level.Environment.Attributes.GetValue(EnvironmentAttribute.AudioAmbientSounds, new Vec3<double>(x, y, z));

    public static float MusicVolume(ClientLevel level, double x, double y, double z) =>
        level.Environment.Attributes.GetValue(EnvironmentAttribute.AudioMusicVolume, new Vec3<double>(x, y, z));
}
