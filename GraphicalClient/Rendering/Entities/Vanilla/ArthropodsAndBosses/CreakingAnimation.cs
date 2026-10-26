using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class CreakingAnimation {
    public static readonly AnimationDefinition CreakingWalk = AnimationDefinition.Builder.WithLength(1.125F).Looping()
        .AddAnimation("upper_body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(26.8802F, -23.399F, -9.0616F), Linear),
            new Keyframe(0.125F, DegreeVec(-2.2093F, 5.9119F, 0.0675F), Linear),
            new Keyframe(0.5417F, DegreeVec(23.0778F, 14.2906F, 4.6066F), Linear),
            new Keyframe(0.7083F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(7.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(26.8802F, -23.399F, -9.0616F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0417F, DegreeVec(-17.5F, -62.5F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4167F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, DegreeVec(0.0F, 15.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0417F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0833F, DegreeVec(-37.1532F, 81.1131F, -28.3621F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(-32.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(12.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(-15.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5417F, DegreeVec(-25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(-9.0923F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7917F, DegreeVec(-15.137F, -66.7758F, 13.9603F), Linear),
            new Keyframe(0.8333F, DegreeVec(-9.0923F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(-15.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(49.8924F, -3.8282F, 3.2187F), Linear),
            new Keyframe(0.5F, DegreeVec(17.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(-56.5613F, -12.2403F, -8.7374F), Linear),
            new Keyframe(0.9167F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.1846F, 0.5979F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, -0.0665F, -2.2177F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 1.3563F, -4.3474F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.1047F, -1.6556F), Linear),
            new Keyframe(0.9167F, PosVec(0.0F, 0.0F, -1.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.0F, 2.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(25.5305F, 11.3125F, 5.3525F), Linear),
            new Keyframe(0.125F, DegreeVec(-49.5628F, 7.3556F, 6.7933F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0417F, DegreeVec(55.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(25.5305F, 11.3125F, 5.3525F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.9674F, -3.6578F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, -0.2979F, -0.9411F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, -0.3F, -0.94F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, -0.3F, 1.06F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 0.9674F, -3.6578F), Linear)))
        .Build();
    public static readonly AnimationDefinition CreakingAttack = AnimationDefinition.Builder.WithLength(0.7083F).Looping()
        .AddAnimation("upper_body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(0.0F, 45.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-115.0F, 67.5F, -90.0F), Linear),
            new Keyframe(0.375F, DegreeVec(67.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5417F, DegreeVec(0.0F, 45.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("upper_body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, PosVec(0.0F, -2.7716F, -1.1481F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5417F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("upper_body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.7083F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, -45.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(-11.25F, -45.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(-117.3939F, 76.6331F, -130.1483F), Linear),
            new Keyframe(0.4167F, DegreeVec(-45.0F, -45.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(60.0F, -45.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(60.0F, -45.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, -45.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4167F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.3827F, 0.5133F, -0.7682F), Linear),
            new Keyframe(0.5833F, PosVec(0.3827F, 0.5133F, -0.7682F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Scale,
            new Keyframe(0.1667F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.4167F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.3F, 1.0), Linear),
            new Keyframe(0.625F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(7.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, DegreeVec(55.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 45.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 45.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.7071F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.7071F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(10.3453F, 14.7669F, 2.664F), Linear),
            new Keyframe(0.4583F, DegreeVec(57.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition CreakingInvulnerable = AnimationDefinition.Builder.WithLength(0.2917F)
        .AddAnimation("upper_body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("upper_body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(17.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(20.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition CreakingDeath = AnimationDefinition.Builder.WithLength(2.25F)
        .AddAnimation("upper_body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(-40.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(7.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(16.25F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6667F, DegreeVec(29.0814F, 62.5516F, 26.5771F), Linear),
            new Keyframe(0.75F, DegreeVec(12.2115F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(10.25F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0417F, DegreeVec(-47.64F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(21.96F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(2.25F, DegreeVec(17.3266F, 7.9022F, -0.1381F), Linear)))
        .AddAnimation("upper_body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, PosVec(0.0F, 0.557F, 1.2659F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, -2.0889F, -0.3493F), Linear),
            new Keyframe(0.2917F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("upper_body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.0833F, ScaleVec(1.0, 1.1F, 1.0), Linear),
            new Keyframe(0.1667F, ScaleVec(1.0, 0.9F, 1.0), Linear),
            new Keyframe(0.2917F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5417F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(-12.1479F, -34.3927F, 6.9326F), Linear),
            new Keyframe(1.6667F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.8333F, DegreeVec(-4.4444F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(-26.7402F, -78.831F, 26.3025F), Linear),
            new Keyframe(0.9583F, DegreeVec(-5.5556F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5417F, DegreeVec(5.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(-67.4168F, -12.9552F, -8.0231F), Linear),
            new Keyframe(0.6667F, DegreeVec(8.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(10.773F, -29.5608F, -5.3627F), Linear),
            new Keyframe(1.25F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7917F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.8333F, DegreeVec(12.9625F, 39.2735F, 8.2901F), Linear),
            new Keyframe(1.9167F, DegreeVec(10.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
}
