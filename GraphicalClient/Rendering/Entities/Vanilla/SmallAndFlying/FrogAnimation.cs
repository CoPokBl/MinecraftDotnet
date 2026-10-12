using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class FrogAnimation {
    public static readonly AnimationDefinition FrogCroak = AnimationDefinition.Builder.WithLength(3.0F)
        .AddAnimation("croaking_body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4167F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(2.9583F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(3.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("croaking_body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(0.0, 0.0, 0.0), Linear),
            new Keyframe(0.375F, ScaleVec(0.0, 0.0, 0.0), Linear),
            new Keyframe(0.4167F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.4583F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5417F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(0.625F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(0.7083F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(2.25F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(2.3333F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(2.4167F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(2.5F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(2.5833F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(2.6667F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(2.875F, ScaleVec(1.3F, 2.1F, 1.6F), Linear),
            new Keyframe(2.9583F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(3.0F, ScaleVec(0.0, 0.0, 0.0), Linear)))
        .Build();
    public static readonly AnimationDefinition FrogWalk = AnimationDefinition.Builder.WithLength(1.25F).Looping()
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -5.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(7.5F, -2.67F, -7.5F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7917F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.125F, DegreeVec(-45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, -5.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.1F, -2.0F), Linear),
            new Keyframe(0.2917F, PosVec(-0.5F, -0.25F, -0.13F), Linear),
            new Keyframe(0.625F, PosVec(-0.5F, 0.1F, 2.0F), Linear),
            new Keyframe(0.9583F, PosVec(0.5F, 1.0F, -0.11F), Linear),
            new Keyframe(1.25F, PosVec(0.0F, 0.1F, -2.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, DegreeVec(-45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, 5.0F, 0.0F), Linear),
            new Keyframe(0.9583F, DegreeVec(7.5F, 2.33F, 7.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.5F, 0.1F, 2.0F), Linear),
            new Keyframe(0.2917F, PosVec(-0.5F, 1.0F, 0.12F), Linear),
            new Keyframe(0.625F, PosVec(0.0F, 0.1F, -2.0F), Linear),
            new Keyframe(0.9583F, PosVec(0.5F, -0.25F, -0.13F), Linear),
            new Keyframe(1.25F, PosVec(0.5F, 0.1F, 2.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.625F, DegreeVec(-45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7917F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.1F, 1.2F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.1F, 2.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, 2.0F, 1.06F), Linear),
            new Keyframe(0.7917F, PosVec(0.0F, 0.1F, -1.0F), Linear),
            new Keyframe(1.25F, PosVec(0.0F, 0.1F, 1.2F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-33.75F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0417F, DegreeVec(-45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1667F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7917F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9583F, DegreeVec(45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.25F, DegreeVec(-33.75F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.14F, 0.11F), Linear),
            new Keyframe(0.1667F, PosVec(0.0F, 0.1F, -1.0F), Linear),
            new Keyframe(0.7917F, PosVec(0.0F, 0.1F, 2.0F), Linear),
            new Keyframe(1.125F, PosVec(0.0F, 2.0F, 0.95F), Linear),
            new Keyframe(1.25F, PosVec(0.0F, 1.14F, 0.11F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 5.0F, 0.0F), Linear),
            new Keyframe(0.2917F, DegreeVec(-7.5F, 0.33F, 7.5F), Linear),
            new Keyframe(0.625F, DegreeVec(0.0F, -5.0F, 0.0F), Linear),
            new Keyframe(0.9583F, DegreeVec(-7.5F, 0.33F, -7.5F), Linear),
            new Keyframe(1.25F, DegreeVec(0.0F, 5.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition FrogJump = AnimationDefinition.Builder.WithLength(0.5F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-22.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-56.14F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-56.14F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 1.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-56.14F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-56.14F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 1.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(45.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(45.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(45.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition FrogTongue = AnimationDefinition.Builder.WithLength(0.5F)
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(-60.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4167F, DegreeVec(-60.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Scale,
            new Keyframe(0.0F, DegreeVec(1.0F, 1.0F, 1.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(0.998F, 1.0F, 1.0F), Linear),
            new Keyframe(0.4167F, DegreeVec(0.998F, 1.0F, 1.0F), Linear),
            new Keyframe(0.5F, DegreeVec(1.0F, 1.0F, 1.0F), Linear)))
        .AddAnimation("tongue", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.0833F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4167F, DegreeVec(-18.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tongue", new AnimationChannel(Scale,
            new Keyframe(0.0833F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.1667F, ScaleVec(0.5, 1.0, 5.0), Linear),
            new Keyframe(0.4167F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .Build();
    public static readonly AnimationDefinition FrogSwim = AnimationDefinition.Builder.WithLength(1.04167F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.3333F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, DegreeVec(-10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0417F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, 22.5F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(45.0F, 22.5F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, DegreeVec(-22.5F, -22.5F, -22.5F), CatmullRom),
            new Keyframe(0.875F, DegreeVec(-45.0F, -22.5F, 0.0F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(22.5F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(1.0417F, DegreeVec(90.0F, 22.5F, 0.0F), CatmullRom)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -0.64F, 2.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(0.0F, -0.64F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.875F, PosVec(0.0F, -0.27F, -1.14F), CatmullRom),
            new Keyframe(0.9583F, PosVec(0.0F, -1.45F, 0.43F), CatmullRom),
            new Keyframe(1.0417F, PosVec(0.0F, -0.64F, 2.0F), CatmullRom)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, -22.5F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(45.0F, -22.5F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, DegreeVec(-22.5F, 22.5F, 22.5F), CatmullRom),
            new Keyframe(0.875F, DegreeVec(-45.0F, 22.5F, 0.0F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(22.5F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(1.0417F, DegreeVec(90.0F, -22.5F, 0.0F), CatmullRom)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -0.64F, 2.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(0.0F, -0.64F, 0.0F), CatmullRom),
            new Keyframe(0.6667F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.875F, PosVec(0.0F, -0.27F, -1.14F), CatmullRom),
            new Keyframe(0.9583F, PosVec(0.0F, -1.45F, 0.43F), CatmullRom),
            new Keyframe(1.0417F, PosVec(0.0F, -0.64F, 2.0F), CatmullRom)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(67.5F, -45.0F, 0.0F), CatmullRom),
            new Keyframe(0.7917F, DegreeVec(90.0F, 45.0F, 0.0F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0417F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-2.5F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(0.25F, PosVec(-2.0F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(1.0F, -2.0F, -1.0F), CatmullRom),
            new Keyframe(0.7917F, PosVec(0.58F, 0.0F, -2.83F), CatmullRom),
            new Keyframe(0.9583F, PosVec(-2.5F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(1.0417F, PosVec(-2.5F, 0.0F, 1.0F), CatmullRom)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, DegreeVec(67.5F, 45.0F, 0.0F), CatmullRom),
            new Keyframe(0.7917F, DegreeVec(90.0F, -45.0F, 0.0F), CatmullRom),
            new Keyframe(0.9583F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0417F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(2.5F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(0.25F, PosVec(2.0F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(-1.0F, -2.0F, -1.0F), CatmullRom),
            new Keyframe(0.7917F, PosVec(-0.58F, 0.0F, -2.83F), CatmullRom),
            new Keyframe(0.9583F, PosVec(2.5F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(1.0417F, PosVec(2.5F, 0.0F, 1.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition FrogIdleWater = AnimationDefinition.Builder.WithLength(3.0F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.625F, DegreeVec(-10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(2.2083F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom)))
        .AddAnimation("left_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-1.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.2083F, PosVec(-1.0F, -0.5F, 0.0F), CatmullRom),
            new Keyframe(3.0F, PosVec(-1.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_arm", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(2.2083F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom)))
        .AddAnimation("right_arm", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(1.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.2083F, PosVec(1.0F, -0.5F, 0.0F), CatmullRom),
            new Keyframe(3.0F, PosVec(1.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, -22.5F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(22.5F, -22.5F, -45.0F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(22.5F, -22.5F, 0.0F), CatmullRom)))
        .AddAnimation("left_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(1.0F, PosVec(0.0F, -1.0F, 1.0F), CatmullRom),
            new Keyframe(3.0F, PosVec(0.0F, 0.0F, 1.0F), CatmullRom)))
        .AddAnimation("right_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 22.5F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(22.5F, 22.5F, 45.0F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(22.5F, 22.5F, 0.0F), CatmullRom)))
        .AddAnimation("right_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.0F), CatmullRom),
            new Keyframe(1.0F, PosVec(0.0F, -1.0F, 1.0F), CatmullRom),
            new Keyframe(3.0F, PosVec(0.0F, 0.0F, 1.0F), CatmullRom)))
        .Build();
}
