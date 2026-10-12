using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class BreezeAnimation {
    public static readonly AnimationDefinition Idle = AnimationDefinition.Builder.WithLength(2.0F).Looping()
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.5F, 0.0F, -0.5F), Linear),
            new Keyframe(0.75F, PosVec(-0.5F, 0.0F, -0.5F), Linear),
            new Keyframe(1.25F, PosVec(-0.5F, 0.0F, 0.5F), Linear),
            new Keyframe(1.75F, PosVec(0.5F, 0.0F, 0.5F), Linear),
            new Keyframe(2.0F, PosVec(0.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.5F, 0.0F, -0.5F), Linear),
            new Keyframe(0.5F, PosVec(-0.5F, 0.0F, -0.5F), Linear),
            new Keyframe(1.0F, PosVec(-0.5F, 0.0F, 0.5F), Linear),
            new Keyframe(1.5F, PosVec(0.5F, 0.0F, 0.5F), Linear),
            new Keyframe(2.0F, PosVec(0.5F, 0.0F, -0.5F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, PosVec(0.0F, 1.0F, 0.0F), CatmullRom),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("rods", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 1080.0F, 0.0F), Linear)))
        .AddAnimation("rods", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition Shoot = AnimationDefinition.Builder.WithLength(1.125F)
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(-12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(-12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, -2.0F, 0.0F), Linear),
            new Keyframe(0.7917F, PosVec(0.0F, -1.0F, 2.0F), Linear),
            new Keyframe(0.9583F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_bottom", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.0F, 5.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, 6.0F), Linear),
            new Keyframe(0.9167F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(0.8333F, PosVec(0.0F, 0.0F, 4.0F), Linear),
            new Keyframe(0.9583F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(-2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 3.0F, 5.0F), Linear),
            new Keyframe(0.8333F, PosVec(0.0F, 3.0F, 6.0F), Linear),
            new Keyframe(0.9583F, PosVec(0.0F, 3.0F, -1.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("rods", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 360.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition Jump = AnimationDefinition.Builder.WithLength(0.5F)
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -10.0F, 0.0F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, 11.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2083F, DegreeVec(-19.25F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.125F, ScaleVec(1.0, 1.3F, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("wind_bottom", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 90.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 360.0F, 0.0F), Linear)))
        .AddAnimation("wind_bottom", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.125F, ScaleVec(1.0, 1.1F, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 180.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -6.0F, 0.0F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, 2.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 90.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -5.0F, 0.0F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, 2.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("rods", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 360.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition Inhale = AnimationDefinition.Builder.WithLength(2.0F)
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, -10.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(22.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.625F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("wind_bottom", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 90.0F, 0.0F), Linear)))
        .AddAnimation("wind_bottom", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.625F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, -6.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, -6.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, -5.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, -5.0F, 0.0F), Linear)))
        .AddAnimation("rods", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 360.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition Slide = AnimationDefinition.Builder.WithLength(0.2F)
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, 0.0F, -6.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, 0.0F, -3.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, 0.0F, -2.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition SlideBack = AnimationDefinition.Builder.WithLength(0.1F)
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, -6.0F), Linear),
            new Keyframe(0.1F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_mid", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, -3.0F), Linear),
            new Keyframe(0.1F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("wind_top", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(0.1F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
}
