using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class FoxBabyAnimation {
    public static readonly AnimationDefinition FoxBabyWalk = AnimationDefinition.Builder.WithLength(0.5F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -1.025F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-35.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-35.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.05F, 0.6F, -0.02F), Linear),
            new Keyframe(0.25F, PosVec(0.05F, 0.6F, -0.02F), Linear),
            new Keyframe(0.5F, PosVec(0.05F, 0.6F, -0.02F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.15F, 1.0), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(35.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(35.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.05F, 0.6F, -0.02F), Linear),
            new Keyframe(0.25F, PosVec(-0.05F, 0.6F, -0.02F), Linear),
            new Keyframe(0.5F, PosVec(-0.05F, 0.6F, -0.02F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.15F, 1.0), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(35.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(35.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.05F, 0.6F, -0.4F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.15F, 1.0), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-35.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-35.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.05F, 0.6F, -0.4F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.15F, 1.0), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -0.05F, 0.0F), CatmullRom)))
        .Build();
}
