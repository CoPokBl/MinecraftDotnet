using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class BatAnimation {
    public static readonly AnimationDefinition BatResting = AnimationDefinition.Builder.WithLength(0.5F).Looping()
        .AddAnimation("head", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(180.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.5F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(180.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.5F, 0.0F), Linear)))
        .AddAnimation("feet", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_wing", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("right_wing", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.0F), Linear)))
        .AddAnimation("right_wing_tip", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, -120.0F, 0.0F), Linear)))
        .AddAnimation("left_wing", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 10.0F, 0.0F), Linear)))
        .AddAnimation("left_wing", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.0F), Linear)))
        .AddAnimation("left_wing_tip", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 120.0F, 0.0F), Linear)))
        .Build();
    public static readonly AnimationDefinition BatFlying = AnimationDefinition.Builder.WithLength(0.5F).Looping()
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(20.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, 2.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(40.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(52.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(40.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, PosVec(0.0F, 2.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(0.0F, 1.0F, 0.0F), Linear),
            new Keyframe(0.375F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, -1.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("feet", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(-21.25F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(-12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(10.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_wing", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 85.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(0.0F, -55.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, 50.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(0.0F, 70.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 85.0F, 0.0F), Linear)))
        .AddAnimation("right_wing_tip", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 10.5F, 0.0F), Linear),
            new Keyframe(0.0417F, DegreeVec(0.0F, 65.5F, 0.0F), Linear),
            new Keyframe(0.2083F, DegreeVec(0.0F, -135.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 10.5F, 0.0F), Linear)))
        .AddAnimation("left_wing", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -85.0F, 0.0F), Linear),
            new Keyframe(0.125F, DegreeVec(0.0F, 55.0F, 0.0F), Linear),
            new Keyframe(0.25F, DegreeVec(0.0F, -50.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(0.0F, -70.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, -85.0F, 0.0F), Linear)))
        .AddAnimation("left_wing_tip", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -10.5F, 0.0F), Linear),
            new Keyframe(0.0417F, DegreeVec(0.0F, -65.5F, 0.0F), Linear),
            new Keyframe(0.2083F, DegreeVec(0.0F, 135.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, -10.5F, 0.0F), Linear)))
        .Build();
}
