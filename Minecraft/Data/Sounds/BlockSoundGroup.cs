namespace Minecraft.Data.Sounds;

/// <summary>
/// Vanilla's block <c>SoundType</c>: the volume and pitch every one of a block's sounds is scaled by, and
/// what it plays for each thing that happens to it. The vanilla set is generated as
/// <c>Minecraft.Data.Generated.BlockSoundGroups</c>.
/// </summary>
public sealed record BlockSoundGroup(float Volume, float Pitch, ISoundType Break, ISoundType Step, ISoundType Place, ISoundType Hit, ISoundType Fall);
