namespace ClientLib.Particles;

/// <summary>
/// One particle, a plain struct in <see cref="ParticleEngine"/>'s array: no object per particle and no
/// virtual call per tick, as <see cref="Motion"/> picks the tick by a switch. The fields are vanilla's
/// <c>Particle</c> and <c>SingleQuadParticle</c>, plus a few spare ones each motion uses for its own.
/// </summary>
public struct ParticleState {
    public double X, Y, Z;
    public double Xo, Yo, Zo;
    public double Xd, Yd, Zd;

    /// <summary>A second position: where a portal or enchanting glyph started, or where a trail is heading.</summary>
    public double Ax, Ay, Az;

    public int Age, Lifetime;
    public float Gravity, Friction;

    /// <summary><c>bbWidth</c> and <c>bbHeight</c>, which only collision reads.</summary>
    public float Width, Height;

    /// <summary><c>quadSize</c>: half the quad's side in blocks, before its <see cref="SizeCurve"/>.</summary>
    public float Size;
    public float R, G, B, A;
    public float Roll, RollO;

    /// <summary>Spare numbers a motion keeps: a spin speed, a colour to fade to, a target's angles.</summary>
    public float F0, F1, F2, F3;

    /// <summary>Spare whole numbers a motion keeps: a delay, an entity id, the particle a drip becomes.</summary>
    public int I0, I1;

    /// <summary>Which of a motion's variants this is, such as a drip's stage.</summary>
    internal byte Variant;

    /// <summary>The particle type's protocol id, whose sprite set the quad draws from.</summary>
    public int Type;

    /// <summary>The block state or interned item a <see cref="ParticleTexture"/> other than a sprite reads.</summary>
    public int TextureArg;

    public int SpriteNum, SpriteDen;

    /// <summary>The block and sky light where the particle was at its last tick, 0 to 15.</summary>
    public byte BlockLight, SkyLight;

    /// <summary>Which quarter of the texture a breaking block or item shows, 0 to 3 in each direction.</summary>
    public float Uo, Vo;

    internal ParticleMotion Motion;
    internal ParticleFlags Flags;
    public ParticleTexture Texture;
    public ParticleSpriteMode SpriteMode;
    public ParticleFacing Facing;
    public ParticleSizeCurve SizeCurve;
    public ParticleAlphaCurve AlphaCurve;
    public ParticleLightMode LightMode;

    /// <summary>Drawn with alpha blending, <c>SingleQuadParticle.Layer.translucent</c>; otherwise cut out at an alpha of 0.1.</summary>
    public bool Translucent;

    /// <summary>Whether the quad is drawn this tick: not an emitter, a shriek still waiting, or a twinkling spark between flashes.</summary>
    public readonly bool Visible => (Flags & (ParticleFlags.NoRender | ParticleFlags.Hidden | ParticleFlags.ElderGuardian)) == 0;

    /// <summary>An <c>ElderGuardianParticle</c>, which the renderer draws as the elder guardian's model.</summary>
    public readonly bool IsElderGuardian => (Flags & ParticleFlags.ElderGuardian) != 0;

    public readonly bool OnGround => (Flags & ParticleFlags.OnGround) != 0;

    public readonly bool Removed => (Flags & ParticleFlags.Removed) != 0;

    public bool HasPhysics {
        readonly get => (Flags & ParticleFlags.HasPhysics) != 0;
        set => Set(ParticleFlags.HasPhysics, value);
    }

    internal void Set(ParticleFlags flag, bool on) => Flags = on ? Flags | flag : Flags & ~flag;

    internal readonly bool Has(ParticleFlags flag) => (Flags & flag) != 0;

    /// <summary><c>setPos</c>, which moves <c>xo</c> as well only when the constructor does.</summary>
    public void SetPosition(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary><c>Particle.setPower</c>.</summary>
    public void SetPower(float power) {
        Xd *= power;
        Yd = (Yd - 0.1F) * power + 0.1F;
        Zd *= power;
    }

    /// <summary><c>SingleQuadParticle.scale</c>: the quad and the box both.</summary>
    public void Scale(float scale) {
        Size *= scale;
        Width = 0.2F * scale;
        Height = 0.2F * scale;
    }

    public void SetColour(float r, float g, float b) {
        R = r;
        G = g;
        B = b;
    }

    public void SetColour(int rgb) => SetColour((rgb >> 16 & 0xFF) / 255.0F, (rgb >> 8 & 0xFF) / 255.0F, (rgb & 0xFF) / 255.0F);

    public void SetSpeed(double xd, double yd, double zd) {
        Xd = xd;
        Yd = yd;
        Zd = zd;
    }

    public void Remove() => Flags |= ParticleFlags.Removed;

    /// <summary><c>SimpleAnimatedParticle.setFadeColor</c>: the colour it turns toward over its second half.</summary>
    public void SetFadeColour(int rgb) {
        (F1, F2, F3) = ((rgb >> 16 & 0xFF) / 255.0F, (rgb >> 8 & 0xFF) / 255.0F, (rgb & 0xFF) / 255.0F);
        Flags |= ParticleFlags.Fade;
    }

    /// <summary>A firework spark's <c>setTrail</c>: half aged sparks left behind it.</summary>
    public bool Trail {
        readonly get => Has(ParticleFlags.Trail);
        set => Set(ParticleFlags.Trail, value);
    }

    /// <summary>A firework spark's <c>setTwinkle</c>: flickering late in its life.</summary>
    public bool Twinkle {
        readonly get => Has(ParticleFlags.Twinkle);
        set => Set(ParticleFlags.Twinkle, value);
    }
}

[Flags]
internal enum ParticleFlags : ushort {
    HasPhysics = 1,
    OnGround = 2,
    StoppedByCollision = 4,
    SpeedUpWhenBlocked = 8,
    Removed = 16,
    Hidden = 32,
    NoRender = 64,
    ElderGuardian = 128,

    /// <summary><c>SimpleAnimatedParticle.hasFade</c>, the colour to fade to being F1 to F3.</summary>
    Fade = 256,

    /// <summary>A firework spark's <c>trail</c> and <c>twinkle</c>.</summary>
    Trail = 512,
    Twinkle = 1024,

    /// <summary>Counted against <c>ParticleLimit.SPORE_BLOSSOM</c>.</summary>
    SporeLimited = 2048,

    /// <summary><c>DragonBreathParticle.hasHitGround</c>, <c>GeyserPlumeParticle.done</c>.</summary>
    Done = 4096
}

/// <summary>Which tick a particle runs: one per vanilla class whose <c>tick</c> differs from <c>Particle.tick</c>.</summary>
internal enum ParticleMotion : byte {
    /// <summary><c>Particle.tick</c>, which most particles keep.</summary>
    Standard,
    Crit,
    DustColorTransition,
    SimpleAnimated,
    SquidInk,
    FireworkSpark,
    Firefly,
    PlayerCloud,
    DustPlume,
    NoxiousGas,
    Lava,
    Snowflake,
    BubbleColumnUp,
    GeyserPlume,
    SulfurBubble,
    Bubble,
    BubblePop,
    CampfireSmoke,
    SuspendedTown,
    WaterCurrentDown,
    DragonBreath,
    Drip,
    FallingDust,
    FallingLeaves,
    FlyStraightTowards,
    FlyTowardsPosition,
    AgeOnly,
    Portal,
    ReversePortal,
    Shriek,
    WaterDrop,
    Wake,
    Trail,
    Vibration,
    TrackingEmitter,
    ExplosionSeed,
    GustSeed,
    GeyserEruption,
    NoxiousGasCloud
}
