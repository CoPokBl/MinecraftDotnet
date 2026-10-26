using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class SnifferAnimation {
    public static readonly AnimationDefinition SnifferSniffsniff = AnimationDefinition.Builder.WithLength(8.0F).Looping()
        .AddAnimation("nose", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5417F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5833F, ScaleVec(1.0, 0.5, 1.0), CatmullRom),
            new Keyframe(0.6667F, ScaleVec(1.0, 2.5, 1.0), CatmullRom),
            new Keyframe(0.7917F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.9167F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.0F, ScaleVec(1.0, 3.0, 1.0), CatmullRom),
            new Keyframe(1.125F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(2.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .Build();

    public static readonly AnimationDefinition SnifferLongsniff = AnimationDefinition.Builder.WithLength(1.0F)
        .AddAnimation("nose", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.0833F, ScaleVec(1.0, 0.7F, 1.0), CatmullRom),
            new Keyframe(0.125F, ScaleVec(1.0, 3.0, 1.0), CatmullRom),
            new Keyframe(0.25F, ScaleVec(1.0, 3.0, 1.0), CatmullRom),
            new Keyframe(0.7083F, ScaleVec(1.0, 4.0, 1.0), CatmullRom),
            new Keyframe(0.8333F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.0F, ScaleVec(1.0, 1.0, 1.0), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(-20.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition SnifferWalk = AnimationDefinition.Builder.WithLength(2.0F).Looping()
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 3.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-7.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-7.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 2.67F, -0.67F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3333F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(1.9167F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 2.67F, -0.67F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, -0.5F), Linear),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 2.22F, 0.78F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.5833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, -0.5F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, -1.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(1.75F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(0.9167F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 2.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 2.22F, 0.78F), Linear),
            new Keyframe(0.3333F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, -0.5F), Linear),
            new Keyframe(1.5833F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 2.22F, 0.78F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(1.0F, 0.0F, -2.5F), Linear),
            new Keyframe(0.5F, DegreeVec(-1.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(1.0F, 0.0F, 2.5F), Linear),
            new Keyframe(1.5F, DegreeVec(-1.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(1.0F, 0.0F, -2.5F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2083F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2083F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.375F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(7.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.1667F, DegreeVec(9.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.875F, DegreeVec(-1.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.25F, DegreeVec(7.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.75F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(7.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -2.5F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, -7.5F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, -2.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, -7.5F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, -2.5F), CatmullRom)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 2.5F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 7.5F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 2.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 7.5F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 2.5F), CatmullRom)))
        .Build();

    public static readonly AnimationDefinition SnifferSniffSearch = AnimationDefinition.Builder.WithLength(2.0F).Looping()
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 3.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-7.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-7.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 2.67F, -0.67F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3333F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(1.9167F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 2.67F, -0.67F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, -0.5F), Linear),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 2.22F, 0.78F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.5833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.75F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, -0.5F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, -1.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(1.75F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1667F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.0F, 3.0F), Linear),
            new Keyframe(0.9167F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(1.1667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 2.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5833F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(25.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 2.22F, 0.78F), Linear),
            new Keyframe(0.3333F, PosVec(0.0F, 4.0F, -1.0F), Linear),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, -2.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, -0.5F), Linear),
            new Keyframe(1.5833F, PosVec(0.0F, 0.0F, 2.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 2.22F, 0.78F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(1.25F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(33.61503F, 11.46526F, 9.803F), Linear),
            new Keyframe(0.875F, DegreeVec(34.71128F, 17.67415F, 14.15251F), Linear),
            new Keyframe(1.125F, DegreeVec(37.21128F, -17.67415F, -14.15251F), Linear),
            new Keyframe(1.875F, DegreeVec(38.30529F, -21.62827F, -17.40292F), Linear),
            new Keyframe(2.0F, DegreeVec(35.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -2.0F, 0.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -2.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, -15.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, -15.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, -15.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(1.75F, DegreeVec(0.0F, 0.0F, -15.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, -2.5F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(1.75F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 2.5F), Linear)))
        .AddAnimation("nose", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.0833F, ScaleVec(1.0, 1.5, 1.0), CatmullRom),
            new Keyframe(0.2083F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.375F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.4583F, ScaleVec(1.0, 2.5, 1.0), CatmullRom),
            new Keyframe(0.625F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.8333F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(0.9167F, ScaleVec(1.0, 2.5, 1.0), CatmullRom),
            new Keyframe(1.0833F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.2917F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.3333F, ScaleVec(1.0, 2.5, 1.0), CatmullRom),
            new Keyframe(1.5F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.625F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(1.6667F, ScaleVec(1.0, 3.5, 1.0), CatmullRom),
            new Keyframe(1.8333F, ScaleVec(1.0, 1.0, 1.0), CatmullRom),
            new Keyframe(2.0F, ScaleVec(1.0, 1.0, 1.0), CatmullRom)))
        .Build();

    public static readonly AnimationDefinition SnifferDig = AnimationDefinition.Builder.WithLength(8.0F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(1.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.5F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(3.5F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(4.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(4.5F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(5.6667F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(5.8333F, DegreeVec(-2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(6.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, -7.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.5F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.5417F, ScaleVec(1.04F, 0.98F, 1.02F), Linear),
            new Keyframe(1.5833F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.1667F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.4167F, DegreeVec(-10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5833F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.875F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.0833F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.5F, DegreeVec(47.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.6667F, DegreeVec(38.44F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.875F, DegreeVec(10.95951F, 13.57454F, -14.93501F), CatmullRom),
            new Keyframe(3.2083F, DegreeVec(47.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(3.5833F, DegreeVec(55.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(3.7917F, DegreeVec(4.2932F, -16.187F, 10.90042F), CatmullRom),
            new Keyframe(4.125F, DegreeVec(47.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(4.4167F, DegreeVec(54.71135F, 7.98009F, -5.56662F), CatmullRom),
            new Keyframe(4.5F, DegreeVec(55.72895F, -6.77684F, 4.46197F), CatmullRom),
            new Keyframe(4.5833F, DegreeVec(54.71135F, 7.98009F, -5.56662F), CatmullRom),
            new Keyframe(4.6667F, DegreeVec(55.72895F, -6.77684F, 4.46197F), CatmullRom),
            new Keyframe(4.75F, DegreeVec(54.71135F, 7.98009F, -5.56662F), CatmullRom),
            new Keyframe(4.8333F, DegreeVec(55.72895F, -6.77684F, 4.46197F), CatmullRom),
            new Keyframe(5.0F, DegreeVec(65.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.75F, DegreeVec(65.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.9167F, DegreeVec(-32.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(6.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.375F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(1.5833F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(1.875F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(2.0833F, PosVec(0.0F, 3.0F, 0.0F), Linear),
            new Keyframe(2.2917F, PosVec(0.0F, 6.0F, 0.0F), Linear),
            new Keyframe(2.6667F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(3.2083F, PosVec(0.0F, 4.0F, 0.0F), Linear),
            new Keyframe(3.5833F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(4.125F, PosVec(0.0F, 4.0F, 0.0F), Linear),
            new Keyframe(5.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(5.75F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(6.0F, PosVec(0.0F, 1.5F, 0.0F), Linear),
            new Keyframe(6.25F, PosVec(0.0F, 1.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, -2.5F), Linear),
            new Keyframe(1.4167F, DegreeVec(0.0F, 0.0F, -50.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(0.0F, 0.0F, -30.0F), Linear),
            new Keyframe(5.9167F, DegreeVec(0.0F, 0.0F, -30.0F), Linear),
            new Keyframe(6.0833F, DegreeVec(0.0F, 0.0F, -65.0F), Linear),
            new Keyframe(6.3333F, DegreeVec(0.0F, 0.0F, -30.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(1.4167F, DegreeVec(0.0F, 0.0F, 50.0F), Linear),
            new Keyframe(1.5833F, DegreeVec(0.0F, 0.0F, 30.0F), Linear),
            new Keyframe(5.9167F, DegreeVec(0.0F, 0.0F, 30.0F), Linear),
            new Keyframe(6.0833F, DegreeVec(0.0F, 0.0F, 65.0F), Linear),
            new Keyframe(6.3333F, DegreeVec(0.0F, 0.0F, 30.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.375F, DegreeVec(0.0F, 0.0F, 90.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2083F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2917F, PosVec(-2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.375F, PosVec(-4.0F, -5.5F, 0.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4167F, DegreeVec(0.0F, 0.0F, 90.0F), Linear)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(-2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.4167F, PosVec(-4.0F, -5.5F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 90.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4167F, PosVec(-2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(-4.0F, -5.5F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.375F, DegreeVec(0.0F, 0.0F, -90.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2083F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2917F, PosVec(2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.375F, PosVec(4.0F, -5.5F, 0.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4167F, DegreeVec(0.0F, 0.0F, -90.0F), Linear)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.4167F, PosVec(4.0F, -5.5F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, -90.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3333F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4167F, PosVec(2.0F, -0.75F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(4.0F, -5.5F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition SnifferStandUp = AnimationDefinition.Builder.WithLength(3.0F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.25F, PosVec(0.0F, -7.0F, 0.0F), Linear),
            new Keyframe(0.75F, PosVec(0.0F, -7.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7083F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3333F, DegreeVec(-5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7083F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.375F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(1.375F, PosVec(0.0F, 1.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -30.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(0.0F, 0.0F, -30.0F), Linear),
            new Keyframe(1.2083F, DegreeVec(0.0F, 0.0F, -5.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 30.0F), Linear),
            new Keyframe(0.9167F, DegreeVec(0.0F, 0.0F, 30.0F), Linear),
            new Keyframe(1.2083F, DegreeVec(0.0F, 0.0F, 5.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 90.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.2083F, PosVec(6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0833F, DegreeVec(0.0F, 0.0F, 90.0F), CatmullRom),
            new Keyframe(0.5833F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0833F, PosVec(-4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.3333F, PosVec(6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 90.0F), CatmullRom),
            new Keyframe(0.6667F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.1667F, PosVec(-4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.4167F, PosVec(6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -90.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.2083F, PosVec(-6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0833F, DegreeVec(0.0F, 0.0F, -90.0F), CatmullRom),
            new Keyframe(0.5833F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_mid_leg", new AnimationChannel(Position,
            new Keyframe(0.0833F, PosVec(4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.3333F, PosVec(-6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.5833F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, -90.0F), CatmullRom),
            new Keyframe(0.6667F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.1667F, PosVec(4.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.4167F, PosVec(-6.0F, -5.5F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();

    public static readonly AnimationDefinition SnifferHappy = AnimationDefinition.Builder.WithLength(2.0F).Looping()
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-32.00206F, 19.3546F, -11.70092F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(-32.00206F, -19.3546F, 11.70092F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, -67.5F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, -67.5F), CatmullRom),
            new Keyframe(1.2917F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 67.5F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 67.5F), CatmullRom),
            new Keyframe(1.2917F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
}
