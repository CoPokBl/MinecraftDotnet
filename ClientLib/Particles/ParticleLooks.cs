namespace ClientLib.Particles;

/// <summary>Which texture a particle's quad samples.</summary>
public enum ParticleTexture : byte {
    /// <summary>A frame of the particle type's own sprite set.</summary>
    Sprite,

    /// <summary>A quarter of the sprite set's first frame, as a breaking item's particle cuts it.</summary>
    SpriteQuarter,

    /// <summary>A quarter of a block state's particle sprite: <c>TerrainParticle</c>.</summary>
    BlockQuarter,

    /// <summary>A block state's whole particle sprite: <c>BlockMarker</c>.</summary>
    Block,

    /// <summary>A quarter of an item's particle sprite: <c>BreakingItemParticle</c>.</summary>
    ItemQuarter
}

/// <summary>How a quad is turned: <c>SingleQuadParticle.FacingCameraMode</c>, or the turns a few particles make their own.</summary>
public enum ParticleFacing : byte {
    /// <summary><c>LOOKAT_XYZ</c>, then turned by the particle's roll.</summary>
    Camera,

    /// <summary><c>LOOKAT_Y</c>: upright, turning only about the vertical.</summary>
    CameraY,

    /// <summary><c>ShriekParticle</c>: two quads tilted 60 degrees off the horizontal, one each way.</summary>
    Shriek,

    /// <summary>
    /// <c>VibrationSignalParticle</c>: two quads along the way to the target, whose yaw and pitch are the
    /// particle's <see cref="ParticleState.F0"/> to <see cref="ParticleState.F3"/> (now, then last tick).
    /// </summary>
    Vibration
}

/// <summary>Which sprite of its set a particle shows.</summary>
public enum ParticleSpriteMode : byte {
    /// <summary><c>SpriteSet.get(RandomSource)</c> or <c>first()</c>: the frame is <see cref="ParticleState.SpriteNum"/> modulo the set's size.</summary>
    Index,

    /// <summary><c>SpriteSet.get(index, max)</c> of <see cref="ParticleState.SpriteNum"/> over <see cref="ParticleState.SpriteDen"/>.</summary>
    Fraction,

    /// <summary><c>setSpriteFromAge</c>: the age over the lifetime.</summary>
    ByAge
}

/// <summary>A <c>getQuadSize</c> override, worked out per frame from the age with the partial tick.</summary>
public enum ParticleSizeCurve : byte {
    Constant,

    /// <summary>Full size within the first 32nd of the life: smoke, dust, crits, hearts.</summary>
    GrowIn,

    /// <summary><c>FlameParticle</c>: half a size lost by the end, on the square of the age.</summary>
    Flame,

    /// <summary><c>LavaParticle</c>: shrinking to nothing on the square of the age.</summary>
    Lava,

    /// <summary><c>PortalParticle</c>: growing in quickly, on one minus the square of what is left.</summary>
    Portal,

    /// <summary><c>ReversePortalParticle</c>: shrinking toward a third left at the end.</summary>
    ReversePortal,

    /// <summary><c>ShriekParticle</c>: growing to three quarters over the life.</summary>
    Shriek,

    /// <summary><c>FireworkParticles.OverlayParticle</c>: a sine pulse up to 7.1 blocks.</summary>
    Flash
}

/// <summary>An alpha worked out per frame from the age, in place of the particle's own.</summary>
public enum ParticleAlphaCurve : byte {
    Constant,

    /// <summary><c>FireworkParticles.OverlayParticle</c>: 0.6 falling an eighth a tick.</summary>
    Flash,

    /// <summary><c>ShriekParticle</c>: fading out over the life.</summary>
    Shriek,

    /// <summary>The vault connection's <c>LifetimeAlpha(0, 0.6, 0.25, 1)</c>.</summary>
    VaultConnection
}

/// <summary>A <c>getLightCoords</c> override.</summary>
public enum ParticleLightMode : byte {
    /// <summary>The light where the particle is.</summary>
    Level,

    /// <summary><c>FULL_BRIGHT</c>: drawn at its own colour, unlit.</summary>
    FullBright,

    /// <summary><c>withBlock(15)</c>: the sky light where it is with full block light.</summary>
    BlockMax,

    /// <summary><c>addSmoothBlockEmission</c> by the age: block light rising to full over the life.</summary>
    EmissionByAge,

    /// <summary><c>addSmoothBlockEmission</c> by the fourth power of the age: portal and enchanting glyphs.</summary>
    EmissionByAgeFourth,

    /// <summary><c>FireflyParticle</c>: block light fading in and out with no sky light.</summary>
    Firefly
}

/// <summary>
/// What the client needs from whoever draws it to work out a particle's colour: block tints depend on the
/// biome colours and colour maps a resource pack supplies. Without one, nothing is tinted.
/// </summary>
public interface IParticleColours {
    /// <summary><c>BlockTintSource.colorAsTerrainParticle</c>: RGB for a block's particles at a position, or -1 for none.</summary>
    int TerrainTint(uint state, int x, int y, int z);

    /// <summary>
    /// <c>FallingDustParticle.Provider</c>'s colour: a falling block's dust colour, else its tint, else its map colour.
    /// </summary>
    int DustColour(uint state, int x, int y, int z);
}
