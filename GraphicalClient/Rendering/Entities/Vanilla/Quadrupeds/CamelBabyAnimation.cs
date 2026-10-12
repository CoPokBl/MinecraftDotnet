using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class CamelBabyAnimation {
    public static readonly AnimationDefinition CamelBabyWalk = AnimationDefinition.Builder.WithLength(1.5F).Looping()
        .AddAnimation("root", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 2.5F), Linear),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, -2.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 2.5F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(2.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, 0.0F, 0.1F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(-22.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.075F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, PosVec(0.075F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.2083F, PosVec(0.075F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, PosVec(0.075F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.75F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(22.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(-0.1F, 4.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, PosVec(-0.1F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, PosVec(-0.1F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(22.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(-9.49F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5833F, DegreeVec(-17.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.2083F, DegreeVec(7.38F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(22.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.25F, PosVec(-0.1F, 5.0F, 0.0F), CatmullRom),
            new Keyframe(0.5833F, PosVec(-0.1F, 0.0F, -0.1F), CatmullRom),
            new Keyframe(1.5F, PosVec(-0.1F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-15.83F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(-7.38F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.25F, DegreeVec(-21.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(-15.83F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6667F, PosVec(0.1F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, PosVec(0.1F, 4.0F, 0.17F), CatmullRom),
            new Keyframe(1.2083F, PosVec(0.1F, 0.0F, -0.11F), CatmullRom),
            new Keyframe(1.5F, PosVec(0.1F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(0.75F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.125F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(15.94F, -8.42F, 20.94F), Linear),
            new Keyframe(0.75F, DegreeVec(15.94F, 8.42F, -20.94F), CatmullRom),
            new Keyframe(1.5F, DegreeVec(15.94F, -8.42F, 20.94F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -0.6F, 0.0F), Linear),
            new Keyframe(0.4583F, PosVec(0.0F, -0.6F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelBabyStandup = AnimationDefinition.Builder.WithLength(2.6F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(-12.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-12.6F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -13.25F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, -13.25F, 0.0F), Linear),
            new Keyframe(0.3F, PosVec(0.0F, -11.52F, -0.85F), Linear),
            new Keyframe(0.9F, PosVec(0.0F, -9.4335F, -1.6246F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, -9.15F, -1.58F), Linear),
            new Keyframe(1.2F, PosVec(0.0F, -8.5F, -1.3F), Linear),
            new Keyframe(1.9F, PosVec(0.0F, -1.7F, 0.0F), CatmullRom),
            new Keyframe(2.3F, PosVec(0.0F, -0.1F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(0.2F, DegreeVec(-75.21F, 9.37F, 2.45F), Linear),
            new Keyframe(0.3F, DegreeVec(-70.21F, 9.37F, 2.45F), Linear),
            new Keyframe(0.8F, DegreeVec(-40.55F, 8.68F, 1.23F), Linear),
            new Keyframe(1.0F, DegreeVec(-40.55F, 8.68F, 1.23F), Linear),
            new Keyframe(1.2F, DegreeVec(-20.45F, 7.61F, 0.74F), Linear),
            new Keyframe(1.5F, DegreeVec(-20.45F, 7.61F, 0.74F), Linear),
            new Keyframe(1.6F, DegreeVec(-20.45F, 7.61F, 0.74F), Linear),
            new Keyframe(1.9F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.1F, -11.0F, 6.0F), Linear),
            new Keyframe(0.2F, PosVec(0.1F, -8.0F, 6.0F), Linear),
            new Keyframe(0.3F, PosVec(-0.12F, -7.18F, 5.0F), Linear),
            new Keyframe(0.8F, PosVec(-0.9942F, -2.3474F, 2.2929F), Linear),
            new Keyframe(1.0F, PosVec(-0.9942F, -2.3474F, 2.2929F), Linear),
            new Keyframe(1.2F, PosVec(-0.72F, -0.6F, 1.71F), Linear),
            new Keyframe(1.5F, PosVec(-0.72F, -0.6F, 1.71F), Linear),
            new Keyframe(1.6F, PosVec(-0.72F, -0.6F, 1.71F), Linear),
            new Keyframe(1.7F, PosVec(-0.21F, -0.55F, 1.05F), Linear),
            new Keyframe(1.8F, PosVec(-0.21F, 0.73F, 0.52F), Linear),
            new Keyframe(1.9F, PosVec(0.05F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, PosVec(0.05F, 0.0F, 0.0F), Linear),
            new Keyframe(2.2F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(0.2F, DegreeVec(-74.2F, -9.3F, -2.45F), Linear),
            new Keyframe(0.3F, DegreeVec(-69.2F, -9.32F, -2.4F), Linear),
            new Keyframe(0.8F, DegreeVec(-46.75F, -10.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-46.75F, -10.0F, 0.0F), Linear),
            new Keyframe(1.2F, DegreeVec(-24.31F, -9.2F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-24.31F, -9.2F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(-24.31F, -9.2F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(-12.15F, -4.6F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-12.15F, -4.6F, 0.0F), Linear),
            new Keyframe(2.2F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -11.0F, 6.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, -7.89F, 4.96F), Linear),
            new Keyframe(0.3F, PosVec(0.0F, -6.89F, 4.96F), Linear),
            new Keyframe(0.8F, PosVec(0.65F, -2.98F, 3.56F), Linear),
            new Keyframe(1.0F, PosVec(0.65F, -2.98F, 3.56F), Linear),
            new Keyframe(1.2F, PosVec(0.5F, -0.69F, 2.47F), Linear),
            new Keyframe(1.5F, PosVec(0.5F, -0.69F, 2.47F), Linear),
            new Keyframe(1.7F, PosVec(0.5F, -0.69F, 2.47F), Linear),
            new Keyframe(1.9F, PosVec(0.4F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, PosVec(0.2F, 1.0F, 0.0F), Linear),
            new Keyframe(2.2F, PosVec(-0.025F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, PosVec(-0.02F, 0.0F, 0.0F), Linear),
            new Keyframe(2.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, -12.0F, -0.5F), Linear),
            new Keyframe(0.2F, DegreeVec(-90.0F, -12.0F, -0.5F), Linear),
            new Keyframe(0.5F, DegreeVec(-89.79F, -17.4F, -0.8F), Linear),
            new Keyframe(0.8F, DegreeVec(-89.38F, -11.59F, -0.99F), Linear),
            new Keyframe(0.9F, DegreeVec(-89.09F, -7.49F, -0.98F), Linear),
            new Keyframe(1.0F, DegreeVec(-88.5F, -4.3F, -1.0F), Linear),
            new Keyframe(1.2F, DegreeVec(-79.5F, -4.3F, -1.0F), Linear),
            new Keyframe(1.3F, DegreeVec(-66.11F, -4.19F, -1.05F), Linear),
            new Keyframe(1.5F, DegreeVec(-47.51F, -4.19F, -1.05F), Linear),
            new Keyframe(1.7F, DegreeVec(-35.11F, -4.19F, -1.05F), Linear),
            new Keyframe(1.8F, DegreeVec(-20.63F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(1.5F, -10.949F, 1.9507F), Linear),
            new Keyframe(0.2F, PosVec(1.5F, -10.949F, 1.9507F), Linear),
            new Keyframe(0.5F, PosVec(1.0F, -11.0F, 1.75F), Linear),
            new Keyframe(0.8F, PosVec(0.16F, -11.11F, 0.49F), Linear),
            new Keyframe(0.9F, PosVec(-0.81F, -10.95F, -0.02F), Linear),
            new Keyframe(1.0F, PosVec(-0.77F, -10.8F, -0.94F), Linear),
            new Keyframe(1.2F, PosVec(-0.77F, -8.7F, -0.94F), Linear),
            new Keyframe(1.3F, PosVec(-1.6F, -6.43F, -1.59F), Linear),
            new Keyframe(1.5F, PosVec(-1.36F, -3.37F, -1.65F), Linear),
            new Keyframe(1.7F, PosVec(-1.2F, -1.33F, -1.69F), Linear),
            new Keyframe(1.8F, PosVec(-0.6F, 2.0F, -0.3F), Linear),
            new Keyframe(1.9F, PosVec(-0.2F, 1.9F, -1.0F), Linear),
            new Keyframe(2.1F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 12.0F, 0.5F), Linear),
            new Keyframe(0.2F, DegreeVec(-90.0F, 12.0F, 0.5F), Linear),
            new Keyframe(0.5F, DegreeVec(-90.0F, 17.5F, 1.0F), Linear),
            new Keyframe(0.8F, DegreeVec(-90.0F, 8.5F, 0.73F), Linear),
            new Keyframe(0.9F, DegreeVec(-90.0F, 3.0F, 0.37F), Linear),
            new Keyframe(1.0F, DegreeVec(-75.38F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(-56.38F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(-30.15F, 0.0F, 0.0F), Linear),
            new Keyframe(1.6F, DegreeVec(3.6F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.9F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-1.3F, -11.0F, 1.95F), Linear),
            new Keyframe(0.2F, PosVec(-1.3F, -11.0F, 1.95F), Linear),
            new Keyframe(0.5F, PosVec(-0.7F, -10.9F, 1.8F), Linear),
            new Keyframe(0.8F, PosVec(-0.06F, -11.2F, 0.21F), Linear),
            new Keyframe(0.9F, PosVec(0.39F, -11.2F, -0.23F), Linear),
            new Keyframe(1.0F, PosVec(0.24F, -8.0F, -1.27F), Linear),
            new Keyframe(1.3F, PosVec(0.34F, -4.53F, -0.8F), Linear),
            new Keyframe(1.4F, PosVec(0.3F, -1.88F, -0.42F), Linear),
            new Keyframe(1.5F, PosVec(0.25F, 0.18F, 0.3F), Linear),
            new Keyframe(1.6F, PosVec(0.25F, 1.48F, -1.75F), Linear),
            new Keyframe(1.7F, PosVec(0.1F, 0.0F, -0.4F), Linear),
            new Keyframe(1.9F, PosVec(0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(2.1F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-4.75F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, DegreeVec(5.65F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(40.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.5F, DegreeVec(46.68F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.6F, DegreeVec(37.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.8368F, 1.9553F), Linear),
            new Keyframe(1.8F, PosVec(0.0F, -0.95F, 1.5F), Linear),
            new Keyframe(2.3F, PosVec(0.0F, -0.95F, 1.42F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, -0.95F, 1.42F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(46.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, DegreeVec(46.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3F, DegreeVec(39.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(40.75F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, DegreeVec(47.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.8F, DegreeVec(49.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(52.75F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(50.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(42.75F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(1.75F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(7.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.8F, DegreeVec(6.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, DegreeVec(5.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.3F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.8F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.3F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(1.4F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(1.6F, DegreeVec(0.0F, 0.0F, 5.0F), Linear),
            new Keyframe(1.9F, DegreeVec(0.0F, 0.0F, -23.75F), Linear),
            new Keyframe(2.2F, DegreeVec(0.0F, 0.0F, -23.75F), Linear),
            new Keyframe(2.3F, DegreeVec(0.0F, 0.0F, 12.5F), Linear),
            new Keyframe(2.4F, DegreeVec(0.0F, 0.0F, 67.5F), Linear),
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, 45.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, 45.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Position,
            new Keyframe(2.3F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.4F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -22.5F), Linear),
            new Keyframe(1.0F, DegreeVec(0.0F, 0.0F, -22.5F), Linear),
            new Keyframe(1.4F, DegreeVec(0.0F, 0.0F, -22.5F), Linear),
            new Keyframe(1.6F, DegreeVec(0.0F, 0.0F, -7.5F), Linear),
            new Keyframe(1.9F, DegreeVec(0.0F, 0.0F, 22.5F), Linear),
            new Keyframe(2.2F, DegreeVec(0.0F, 0.0F, 22.5F), Linear),
            new Keyframe(2.3F, DegreeVec(0.0F, 0.0F, -22.5F), Linear),
            new Keyframe(2.4F, DegreeVec(0.0F, 0.0F, -55.0F), Linear),
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, -45.0F), Linear),
            new Keyframe(2.6F, DegreeVec(0.0F, 0.0F, -45.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Position,
            new Keyframe(2.3F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.4F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.5F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.6F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelBabyDash = AnimationDefinition.Builder.WithLength(0.5F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(5.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -2.8F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(112.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(112.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(67.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.0F), Linear),
            new Keyframe(0.5F, PosVec(0.0F, 0.0F, 1.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(44.9727F, 1.7675F, -1.7683F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(44.9727F, 1.7675F, -1.7683F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(44.9727F, 1.7675F, -1.7683F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.05F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(44.9727F, -1.7675F, 1.7683F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(44.9727F, -1.7675F, 1.7683F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(-90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.05F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.05F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.125F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.25F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.375F, DegreeVec(90.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.5F, DegreeVec(-45.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.05F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -67.5F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, -67.5F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 67.5F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 67.5F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelBabyIdle = AnimationDefinition.Builder.WithLength(4.0F).Looping()
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(4.9811F, 0.4352F, -4.9811F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(4.9872F, -0.2942F, 3.3674F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(5.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.0F, DegreeVec(-2.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(2.625F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(2.75F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(2.875F, DegreeVec(0.0F, 0.0F, 22.5F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(0.0F, 0.0F, -45.0F), CatmullRom)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(2.5F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(2.625F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(2.75F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(2.875F, DegreeVec(0.0F, 0.0F, -22.5F), CatmullRom),
            new Keyframe(3.0F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom),
            new Keyframe(4.0F, DegreeVec(0.0F, 0.0F, 45.0F), CatmullRom)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -0.1F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelBabySit = AnimationDefinition.Builder.WithLength(2.0F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4F, DegreeVec(9.26F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6F, DegreeVec(18.15F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(30.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.2F, DegreeVec(21.14F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(15.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.6F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, -0.1F, 0.0F), Linear),
            new Keyframe(0.2F, PosVec(0.0F, -1.5F, 0.0F), Linear),
            new Keyframe(0.4F, PosVec(0.0F, -2.21F, 0.04F), Linear),
            new Keyframe(0.6F, PosVec(0.0F, -2.21F, 0.04F), Linear),
            new Keyframe(1.1F, PosVec(0.0F, -5.23F, 0.33F), Linear),
            new Keyframe(1.2F, PosVec(0.0F, -6.06F, 0.17F), Linear),
            new Keyframe(1.3F, PosVec(0.0F, -11.7F, 0.0F), Linear),
            new Keyframe(1.4F, PosVec(0.0F, -13.35F, 0.0F), Linear),
            new Keyframe(1.6F, PosVec(0.0F, -13.25F, 0.0F), Linear),
            new Keyframe(1.7F, PosVec(0.0F, -13.25F, 0.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -13.25F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, DegreeVec(-23.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-44.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(-73.25F, 6.5F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.125F, -0.1F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.125F, -0.1F, 0.4F), Linear),
            new Keyframe(0.6F, PosVec(0.12F, -0.15F, 2.5F), Linear),
            new Keyframe(0.7F, PosVec(0.12F, -0.6F, 4.6F), Linear),
            new Keyframe(0.9F, PosVec(0.12F, -0.87F, 5.97F), Linear),
            new Keyframe(1.0F, PosVec(0.125F, -1.0F, 6.9F), Linear),
            new Keyframe(1.1F, PosVec(0.325F, -2.6F, 7.6F), Linear),
            new Keyframe(1.3F, PosVec(-0.28F, -7.45F, 8.06F), Linear),
            new Keyframe(1.4F, PosVec(0.1F, -11.0F, 6.0F), Linear),
            new Keyframe(1.7F, PosVec(0.1F, -11.0F, 6.0F), Linear),
            new Keyframe(2.0F, PosVec(0.1F, -11.0F, 6.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(-2.5F, 0.0F, 0.0F), Linear),
            new Keyframe(0.7F, DegreeVec(-23.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.0F, DegreeVec(-30.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-45.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(-73.5F, -6.5F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(1.7F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.125F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(-0.125F, 0.0F, 0.0F), Linear),
            new Keyframe(0.6F, PosVec(-0.13F, -0.18F, 2.35F), Linear),
            new Keyframe(0.7F, PosVec(-0.13F, -0.57F, 4.7F), Linear),
            new Keyframe(0.9F, PosVec(-0.13F, -0.86F, 6.07F), Linear),
            new Keyframe(1.0F, PosVec(-0.125F, -1.0F, 6.8F), Linear),
            new Keyframe(1.1F, PosVec(-0.22F, -2.7F, 7.8F), Linear),
            new Keyframe(1.3F, PosVec(0.19F, -7.5F, 8.01F), Linear),
            new Keyframe(1.4F, PosVec(0.0F, -11.0F, 6.0F), Linear),
            new Keyframe(1.7F, PosVec(0.0F, -10.9F, 6.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, -11.0F, 6.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-31.47F, -0.45F, 1.29F), Linear),
            new Keyframe(1.2F, DegreeVec(-49.78F, -10.29F, -1.15F), Linear),
            new Keyframe(1.3F, DegreeVec(-79.21F, -13.72F, -1.53F), Linear),
            new Keyframe(1.4F, DegreeVec(-90.0F, -11.88F, -0.54F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, -11.88F, -0.54F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(-0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, PosVec(-0.1F, 0.0F, 1.0F), Linear),
            new Keyframe(1.1F, PosVec(0.56F, -3.49F, 2.18F), Linear),
            new Keyframe(1.3F, PosVec(1.22F, -8.72F, 3.0F), Linear),
            new Keyframe(1.4F, PosVec(1.4F, -10.95F, 1.95F), Linear),
            new Keyframe(2.0F, PosVec(1.4F, -10.95F, 1.95F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(-10.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-31.13F, 0.56F, -1.3F), Linear),
            new Keyframe(1.2F, DegreeVec(-49.8F, 10.3F, 1.15F), Linear),
            new Keyframe(1.3F, DegreeVec(-79.21F, 13.72F, 1.53F), Linear),
            new Keyframe(1.4F, DegreeVec(-90.0F, 11.89F, 0.54F), Linear),
            new Keyframe(2.0F, DegreeVec(-90.0F, 11.89F, 0.54F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.5F, PosVec(0.1F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, PosVec(0.1F, 0.0F, 1.0F), Linear),
            new Keyframe(1.1F, PosVec(0.2F, -0.75F, 1.5F), Linear),
            new Keyframe(1.2F, PosVec(-0.51F, -3.49F, 2.18F), Linear),
            new Keyframe(1.3F, PosVec(-1.22F, -8.72F, 3.1F), Linear),
            new Keyframe(1.4F, PosVec(-1.33F, -11.0F, 1.95F), Linear),
            new Keyframe(2.0F, PosVec(-1.33F, -11.0F, 1.95F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4F, DegreeVec(-20.42F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(-31.25F, 0.0F, 0.0F), Linear),
            new Keyframe(1.1F, DegreeVec(-26.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2F, DegreeVec(-19.25F, 0.0F, 0.0F), Linear),
            new Keyframe(1.3F, DegreeVec(-14.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(-4.75F, 0.0F, 0.0F), Linear),
            new Keyframe(1.6F, DegreeVec(-4.75F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(-4.75F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.1F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.4F, PosVec(0.0F, 0.38F, 0.44F), Linear),
            new Keyframe(0.9F, PosVec(0.0F, 0.35F, 0.88F), Linear),
            new Keyframe(1.1F, PosVec(0.0F, -0.3F, 1.21F), Linear),
            new Keyframe(1.3F, PosVec(0.0F, -0.3F, 1.22F), Linear),
            new Keyframe(1.6F, PosVec(0.0F, 0.0F, 1.22F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(0.9F, DegreeVec(5.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.2F, DegreeVec(25.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(52.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.6F, DegreeVec(62.5F, 0.0F, 0.0F), Linear),
            new Keyframe(1.8F, DegreeVec(52.5F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, DegreeVec(52.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Position,
            new Keyframe(1.4F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(1.8F, PosVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -45.0F), Linear),
            new Keyframe(1.2F, DegreeVec(0.0F, 0.0F, -45.0F), Linear),
            new Keyframe(1.3F, DegreeVec(0.0F, 0.0F, -62.5F), Linear),
            new Keyframe(1.4F, DegreeVec(0.0F, 0.0F, -45.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, 20.0F), Linear),
            new Keyframe(1.6F, DegreeVec(0.0F, 0.0F, -22.5F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, -22.5F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Position, new Keyframe(1.2F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 45.0F), Linear),
            new Keyframe(1.2F, DegreeVec(0.0F, 0.0F, 45.0F), Linear),
            new Keyframe(1.3F, DegreeVec(0.0F, 0.0F, 60.0F), Linear),
            new Keyframe(1.4F, DegreeVec(0.0F, 0.0F, 45.0F), Linear),
            new Keyframe(1.5F, DegreeVec(0.0F, 0.0F, -20.0F), Linear),
            new Keyframe(1.6F, DegreeVec(0.0F, 0.0F, 15.0F), Linear),
            new Keyframe(2.0F, DegreeVec(0.0F, 0.0F, 15.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Position, new Keyframe(1.2F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .Build();

    public static readonly AnimationDefinition CamelBabySitPose = AnimationDefinition.Builder.WithLength(0.0F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(2.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -13.25F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-90.0F, 10.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.1F, -11.0F, 6.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-90.0F, -10.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, -11.0F, 6.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-90.0F, -11.88F, -0.54F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(1.4F, -10.95F, 1.95F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-90.0F, 11.89F, 0.54F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-1.33F, -11.0F, 1.95F), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-4.75F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 1.22F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(52.5F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, -22.5F), Linear)))
        .AddAnimation("left_ear", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 15.0F), Linear)))
        .AddAnimation("right_ear", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("root", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("root", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .Build();
}
