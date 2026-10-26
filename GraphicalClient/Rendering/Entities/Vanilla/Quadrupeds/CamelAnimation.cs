using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class CamelAnimation {
    public static readonly AnimationDefinition CamelWalk = AnimationDefinition.Builder.WithLength(1.5F).Looping()
        .AddAnimation("root", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 2.5F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, -2.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 2.5F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(2.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.4583F, PosVec(0.0F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.2083F, PosVec(0.0F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-20.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.375F, DegreeVec(-22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-20.4F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -0.21F, 0.0F), CatmullRom),
            new Keyframe(0.75F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0833F, PosVec(0.0F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(1.375F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, -0.21F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.625F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, PosVec(0.0F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(0.625F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(15.94102F, -8.42106F, 20.94102F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(15.94102F, 8.42106F, -20.94102F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(15.94102F, -8.42106F, 20.94102F), CatmullRom)))
        .Build();

    public static readonly AnimationDefinition CamelSit = AnimationDefinition.Builder.WithLength(2.0F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.8F, DegreeVec(24.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, PosVec(0.0F, 0.0F, 1.0F), Linear),
            new Keyframe(1.8F, PosVec(0.0F, -6.0F, 1.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -19.9F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -2.0F, 11.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, -2.0F, 11.0F), Linear),
            new Keyframe(1.7F, PosVec(0.0F, -8.4F, 11.4F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -20.6F, 12.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -2.0F, 11.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, -2.0F, 11.0F), Linear),
            new Keyframe(1.7F, PosVec(0.0F, -8.4F, 11.4F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -20.6F, 12.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(-15.0F, -3.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(-65.0F, -9.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, -15.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 1.0F), Linear),
            new Keyframe(1.7F, PosVec(1.0F, -0.62F, 0.25F), Linear),
            new Keyframe(1.9F, PosVec(0.5F, -11.25F, 2.5F), Linear),
            new Keyframe(2.0F, PosVec(1.0F, -20.5F, 5.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(-15.0F, 3.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(-65.0F, 9.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, 15.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, PosVec(0.0F, 0.0F, 1.0F), Linear),
            new Keyframe(1.7F, PosVec(-1.0F, -0.62F, 0.25F), Linear),
            new Keyframe(1.9F, PosVec(-0.5F, -11.25F, 2.5F), Linear),
            new Keyframe(2.0F, PosVec(-1.0F, -20.5F, 5.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, DegreeVec(-27.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-21.25F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(80.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(50.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelSitPose = AnimationDefinition.Builder.WithLength(1.0F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -19.9F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -19.9F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -20.6F, 12.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -20.6F, 12.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -20.6F, 12.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -20.6F, 12.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -15.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-90.0F, -15.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(1.0F, -20.5F, 5.0F), Linear),
            new Keyframe(1.0F, PosVec(1.0F, -20.5F, 5.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 15.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-90.0F, 15.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-1.0F, -20.5F, 5.0F), Linear),
            new Keyframe(1.0F, PosVec(-1.0F, -20.5F, 5.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(50.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(50.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelStandup = AnimationDefinition.Builder.WithLength(2.6F)
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, DegreeVec(-17.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.8F, DegreeVec(-17.83F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.3F, DegreeVec(-5.83F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -19.9F, 0.0F), Linear),
            new Keyframe(0.7F, PosVec(0.0F, -19.9F, -3.0F), Linear),
            new Keyframe(1.4F, PosVec(0.0F, -12.76F, -4.0F), CatmullRom),
            new Keyframe(1.8F, PosVec(0.0F, -10.1F, -4.0F), CatmullRom),
            new Keyframe(2.3F, PosVec(0.0F, -2.9F, -2.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-49.06F, 10.0F, 0.0F), Linear),
            new Keyframe(1.8F, DegreeVec(-22.5F, 10.0F, 0.0F), Linear),
            new Keyframe(2.3F, DegreeVec(-25.0F, 10.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -20.6F, 12.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, -20.6F, 8.0F), Linear),
            new Keyframe(1.1F, PosVec(0.0F, -7.14F, 4.42F), Linear),
            new Keyframe(1.8F, PosVec(0.0F, -1.27F, -1.33F), Linear),
            new Keyframe(2.3F, PosVec(0.0F, -1.27F, -0.33F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-49.06F, -10.0F, 0.0F), Linear),
            new Keyframe(1.8F, DegreeVec(-22.5F, -10.0F, 0.0F), Linear),
            new Keyframe(2.3F, DegreeVec(-25.0F, -10.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -20.6F, 12.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, -20.6F, 8.0F), Linear),
            new Keyframe(1.1F, PosVec(0.0F, -7.14F, 4.42F), Linear),
            new Keyframe(1.8F, PosVec(0.0F, -1.27F, -1.33F), Linear),
            new Keyframe(2.3F, PosVec(0.0F, -1.27F, -0.33F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -15.0F, 0.0F), Linear),
            new Keyframe(0.3F, DegreeVec(-90.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6F, DegreeVec(-90.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-60.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.2F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(1.0F, -20.5F, 5.0F), Linear),
            new Keyframe(0.3F, PosVec(-2.0F, -20.5F, 3.0F), Linear),
            new Keyframe(0.6F, PosVec(-2.0F, -20.5F, 3.0F), Linear),
            new Keyframe(1.1F, PosVec(-2.0F, -10.5F, 2.0F), Linear),
            new Keyframe(1.5F, PosVec(-2.0F, -0.4F, -3.9F), Linear),
            new Keyframe(1.9F, PosVec(-2.0F, -4.3F, -9.8F), Linear),
            new Keyframe(2.2F, PosVec(-1.0F, -2.5F, -5.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 15.0F, 0.0F), Linear),
            new Keyframe(0.3F, DegreeVec(-90.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6F, DegreeVec(-90.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-60.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(35.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.2F, DegreeVec(30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-1.0F, -20.5F, 5.0F), Linear),
            new Keyframe(0.3F, PosVec(2.0F, -20.5F, 3.0F), Linear),
            new Keyframe(0.6F, PosVec(2.0F, -20.5F, 3.0F), Linear),
            new Keyframe(1.1F, PosVec(2.0F, -10.5F, 2.0F), Linear),
            new Keyframe(1.5F, PosVec(2.0F, -0.4F, -3.9F), Linear),
            new Keyframe(1.9F, PosVec(2.0F, -4.3F, -9.8F), Linear),
            new Keyframe(2.2F, PosVec(1.0F, -2.5F, -5.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.8F, DegreeVec(55.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(65.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.4F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(50.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4F, DegreeVec(55.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(55.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(17.5F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(5.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelDash = AnimationDefinition.Builder.WithLength(0.5F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(5.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(112.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(112.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(44.97272F, 1.76749F, -1.76833F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(44.97272F, 1.76749F, -1.76833F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(44.97272F, 1.76749F, -1.76833F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(44.97272F, -1.76749F, 1.76833F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(44.97272F, -1.76749F, 1.76833F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -67.5F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, -67.5F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 67.5F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 67.5F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelIdle = AnimationDefinition.Builder.WithLength(4.0F)
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(4.98107F, 0.43523F, -4.98107F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(4.9872F, -0.29424F, 3.36745F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(2.625F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(2.75F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(2.875F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(2.625F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(2.75F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(2.875F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom)))
        .Build();
}
