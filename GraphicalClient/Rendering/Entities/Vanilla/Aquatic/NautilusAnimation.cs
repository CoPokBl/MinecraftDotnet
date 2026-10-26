using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class NautilusAnimation {
    public static readonly AnimationDefinition Swimming = AnimationDefinition.Builder.WithLength(1.0F).Looping()
        .AddAnimation("body", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.2F), Linear),
            new Keyframe(0.75F, ScaleVec(1.0, 1.0, 0.9F), Linear),
            new Keyframe(0.875F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("upper_mouth", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("upper_mouth", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.4F), Linear),
            new Keyframe(0.75F, ScaleVec(1.0, 1.0, 0.9F), Linear),
            new Keyframe(0.875F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("inner_mouth", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(0.8F, 0.8F, 1.0), Linear),
            new Keyframe(0.75F, ScaleVec(1.0, 1.0, 0.9F), Linear),
            new Keyframe(0.875F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("lower_mouth", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.875F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("lower_mouth", new AnimationChannel(Scale,
            new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(0.5F, ScaleVec(1.0, 1.0, 1.4F), Linear),
            new Keyframe(0.75F, ScaleVec(1.0, 1.0, 0.9F), Linear),
            new Keyframe(0.875F, ScaleVec(1.0, 1.0, 1.0), Linear),
            new Keyframe(1.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .Build();
}
