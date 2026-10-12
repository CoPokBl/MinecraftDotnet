using static GraphicalClient.Rendering.Entities.AnimationChannel.Interpolations;
using static GraphicalClient.Rendering.Entities.AnimationChannel.Targets;
using static GraphicalClient.Rendering.Entities.KeyframeAnimations;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public static class BabyAxolotlAnimation {
    public static readonly AnimationDefinition BabyAxolotlIdleFloor = AnimationDefinition.Builder.WithLength(2.88F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.8F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(160.0F, -10.0F, -37.5F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.2F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation, new Keyframe(1.72F, DegreeVec(360.0F, 0.0F, -45.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(160.0F, 10.0F, 37.5F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.2F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 37.5F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 10.0F, 0.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(0.0F, -14.0F, 0.0F), Linear),
            new Keyframe(0.96F, DegreeVec(0.0F, -21.0F, 0.0F), Linear),
            new Keyframe(1.4F, DegreeVec(0.0F, -25.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, -16.75F, 0.0F), CatmullRom),
            new Keyframe(2.84F, DegreeVec(0.0F, 10.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.04F, DegreeVec(0.0F, 0.0F, -6.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(-6.45F, -1.45F, -6.5F), Linear),
            new Keyframe(1.48F, DegreeVec(-6.45F, -1.45F, -6.5F), Linear),
            new Keyframe(2.84F, DegreeVec(0.0F, 0.0F, -6.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 38.0F, 0.0F), CatmullRom),
            new Keyframe(1.28F, DegreeVec(0.0F, 45.5F, 0.0F), CatmullRom),
            new Keyframe(1.64F, DegreeVec(0.0F, 45.5F, 0.0F), CatmullRom),
            new Keyframe(2.8F, DegreeVec(0.0F, 38.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.04F, DegreeVec(0.0F, -50.0F, 0.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(0.0F, -59.0F, 0.0F), CatmullRom),
            new Keyframe(1.6F, DegreeVec(0.0F, -59.0F, 0.0F), CatmullRom),
            new Keyframe(2.84F, DegreeVec(0.0F, -50.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(33.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.28F, DegreeVec(47.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.64F, DegreeVec(47.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.8F, DegreeVec(33.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition IdleFloorUnderwater = AnimationDefinition.Builder.WithLength(5.12F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.12F, DegreeVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.5F, 0.0F), CatmullRom),
            new Keyframe(5.12F, PosVec(0.0F, 1.5F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation, new Keyframe(5.04F, DegreeVec(190.0F, -15.0F, -30.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.3F, 0.0F, 0.5F), CatmullRom),
            new Keyframe(5.12F, PosVec(0.3F, 0.0F, 0.5F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(360.0F, 0.0F, -30.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.18F, 0.0F, 0.0F), Linear),
            new Keyframe(5.12F, PosVec(0.18F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation, new Keyframe(5.04F, DegreeVec(190.0F, 18.0F, 30.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.1F, 0.0F, 0.5F), CatmullRom),
            new Keyframe(5.12F, PosVec(-0.1F, 0.0F, 0.5F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation, new Keyframe(5.04F, DegreeVec(180.0F, 0.0F, 30.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.2F, 0.0F, 0.0F), Linear),
            new Keyframe(5.12F, PosVec(-0.2F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.04F, DegreeVec(0.0F, -12.0F, 0.0F), CatmullRom),
            new Keyframe(2.56F, DegreeVec(0.0F, 12.0F, 0.0F), CatmullRom),
            new Keyframe(5.12F, DegreeVec(0.0F, -12.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 10.0F, 0.0F), CatmullRom),
            new Keyframe(3.12F, DegreeVec(0.0F, -16.0F, 0.0F), CatmullRom),
            new Keyframe(5.12F, DegreeVec(0.0F, 10.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -16.0F, 0.0F), CatmullRom),
            new Keyframe(2.08F, DegreeVec(0.0F, 12.0F, 0.0F), CatmullRom),
            new Keyframe(5.12F, DegreeVec(0.0F, -16.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.56F, DegreeVec(-16.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.12F, DegreeVec(10.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition IdleUnderwater = AnimationDefinition.Builder.WithLength(5.2F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-8.9F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(-2.6F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(-8.9F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.6F, PosVec(0.0F, -0.5F, 0.0F), CatmullRom),
            new Keyframe(5.2F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-5.0F, -20.0F, -55.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(1.0F, -20.0F, -65.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(-5.0F, -20.0F, -55.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.15F, -0.3391F, 0.0876F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(60.0F, -60.0F, 15.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(75.0F, -60.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(60.0F, -60.0F, 15.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position, new Keyframe(5.2F, PosVec(0.0F, -0.4F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 20.0F, 50.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(0.0F, 20.0F, 60.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(0.0F, 20.0F, 50.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(2.68F, PosVec(-0.15F, -0.4F, 0.3F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-135.0F, -50.0F, -330.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(-160.0F, -60.0F, -295.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(-135.0F, -50.0F, -330.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position, new Keyframe(5.2F, PosVec(0.0F, -0.5F, 0.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 15.0F, 0.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(0.0F, -32.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(0.0F, 15.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(11.7F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(2.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(11.7F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -25.6F, 0.0F), CatmullRom),
            new Keyframe(3.12F, DegreeVec(0.0F, 16.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(0.0F, -25.6F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 23.0F, 0.0F), CatmullRom),
            new Keyframe(2.08F, DegreeVec(0.0F, -26.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(0.0F, 23.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-19.2F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.6F, DegreeVec(12.3F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(5.2F, DegreeVec(-19.2F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition BabyAxolotlSwim = AnimationDefinition.Builder.WithLength(1.0F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(8.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.24F, DegreeVec(12.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.68F, DegreeVec(-7.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(8.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.52F, PosVec(0.0F, -1.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(0.0F, -0.05F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(310.0F, 70.0F, 400.0F), CatmullRom),
            new Keyframe(0.24F, DegreeVec(330.0F, 70.0F, 420.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(290.0F, 65.0F, 384.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(290.0F, 70.0F, 380.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(310.0F, 70.0F, 400.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(105.0F, -95.0F, 180.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(105.0F, -85.0F, 180.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(105.0F, -80.0F, 180.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(105.0F, -95.0F, 180.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(105.0F, -95.0F, 180.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-50.0F, -70.0F, -40.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(-60.0F, -68.0F, -30.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(-55.0F, -70.0F, -30.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(-50.0F, -70.0F, -40.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(70.0F, -80.0F, 15.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(130.0F, -80.0F, -45.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(120.0F, -70.0F, -35.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(80.0F, -70.0F, 5.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(70.0F, -80.0F, 15.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 15.0F, 0.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(0.0F, -15.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(0.0F, 13.36F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-7.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(-13.9F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(14.23F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.0F, DegreeVec(-7.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -72.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(0.0F, -79.9F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(0.0F, -38.1F, 0.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(0.0F, -72.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 72.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(0.0F, 86.5F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(0.0F, 26.7F, 0.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(0.0F, 72.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-57.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(-68.7F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(-24.2F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, DegreeVec(-57.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition BabyAxolotlDash = AnimationDefinition.Builder.WithLength(1.04F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(8.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.24F, DegreeVec(15.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.68F, DegreeVec(-12.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(8.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.52F, PosVec(0.0F, -1.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(0.0F, -0.05F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(310.0F, 70.0F, 400.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(290.0F, 65.0F, 384.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(290.0F, 70.0F, 380.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(311.0F, 70.0F, 400.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(100.0F, -85.0F, -170.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(105.0F, -70.0F, -175.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(105.0F, -80.0F, -180.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(105.0F, -90.0F, -180.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(100.0F, -85.0F, -170.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-50.0F, -70.0F, -40.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(-56.0F, -68.0F, -30.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(-65.0F, -70.0F, -30.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(-50.0F, -70.0F, -40.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(70.0F, -80.0F, 15.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(130.0F, -80.0F, -45.0F), CatmullRom),
            new Keyframe(0.52F, DegreeVec(120.0F, -70.0F, -35.0F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(65.0F, -65.0F, 25.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(69.0F, -80.0F, 15.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-15.0F, 10.0F, 0.0F), CatmullRom),
            new Keyframe(0.24F, DegreeVec(-5.0F, 5.75F, 0.0F), CatmullRom),
            new Keyframe(0.36F, DegreeVec(8.5F, -2.0242F, 0.3582F), CatmullRom),
            new Keyframe(0.48F, DegreeVec(22.5F, -10.0F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(8.74F, -8.7F, -0.02F), CatmullRom),
            new Keyframe(0.76F, DegreeVec(-5.0F, -3.25F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(-15.0F, 10.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-7.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.28F, DegreeVec(-22.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(18.73F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(-7.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -72.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(0.0F, -79.9F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(0.0F, -38.1F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(0.0F, -72.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 72.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(0.0F, 86.5F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(0.0F, 26.7F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(0.0F, 72.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-57.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.2F, DegreeVec(-68.7F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.44F, DegreeVec(-64.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(-40.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.84F, DegreeVec(-40.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(-57.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition AxolotlWalkFloor = AnimationDefinition.Builder.WithLength(2.72F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear),
            new Keyframe(2.72F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(2.5F, 10.0F, -30.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(2.5F, -22.5F, -30.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(2.5F, 10.0F, -30.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(1.92F, PosVec(0.5F, 0.0F, 0.8F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(260.0F, -10.0F, 230.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(90.0F, -20.0F, 50.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(260.0F, -10.0F, 230.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.72F, PosVec(0.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-2.5F, 32.5F, 30.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(-2.5F, -12.0F, 30.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(-2.5F, 32.5F, 30.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.5F, 0.0F, 0.7F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-2.5F, -30.0F, 30.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(2.5F, 12.0F, 30.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(-2.5F, -30.0F, 30.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.72F, PosVec(-0.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -10.0F, 0.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(0.0F, 10.0F, 0.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(0.0F, -10.0F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -7.5F, 0.0F), CatmullRom),
            new Keyframe(1.32F, DegreeVec(0.0F, 6.7F, 0.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(0.0F, -7.5F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 38.1F, 0.0F), CatmullRom),
            new Keyframe(1.08F, DegreeVec(0.0F, 45.6F, 0.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(0.0F, 45.6F, 0.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(0.0F, 38.1F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -50.0F, 0.0F), CatmullRom),
            new Keyframe(1.08F, DegreeVec(0.0F, -59.0F, 0.0F), CatmullRom),
            new Keyframe(1.36F, DegreeVec(0.0F, -59.0F, 0.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(0.0F, -50.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(33.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.08F, DegreeVec(47.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(47.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.72F, DegreeVec(33.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition WalkFloorUnderwater = AnimationDefinition.Builder.WithLength(2.04F).Looping()
        .AddAnimation("body", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -5.0F, 6.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(0.0F, 5.0F, -4.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, -5.0F, 6.0F), CatmullRom)))
        .AddAnimation("body", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 1.5F, 0.0F), CatmullRom),
            new Keyframe(2.04F, PosVec(0.0F, 1.5F, 0.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -15.0F, -30.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(0.0F, 9.0F, -30.0F), CatmullRom),
            new Keyframe(1.12F, DegreeVec(0.0F, 13.0F, -24.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(0.0F, 9.0F, -30.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, -15.0F, -30.0F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(0.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(95.0F, -20.0F, 70.0F), CatmullRom),
            new Keyframe(0.68F, DegreeVec(255.0F, -20.0F, 230.0F), CatmullRom),
            new Keyframe(1.12F, DegreeVec(280.0F, -25.0F, 255.0F), CatmullRom),
            new Keyframe(1.52F, DegreeVec(255.0F, -20.0F, 230.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(95.0F, -20.0F, 70.0F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(0.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(0.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, PosVec(0.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-5.0F, -20.0F, 30.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(0.0F, 10.0F, 25.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(0.0F, 10.0F, 25.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(-5.0F, -20.0F, 30.0F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(0.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, PosVec(-0.5F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(5.0F, 15.0F, 25.0F), CatmullRom),
            new Keyframe(0.72F, DegreeVec(-10.0F, -20.0F, 35.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(-10.0F, -20.0F, 35.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(5.0F, 15.0F, 25.0F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position,
            new Keyframe(0.0F, PosVec(-0.7F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(0.96F, PosVec(-0.4F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, PosVec(-0.7F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("tail", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 16.5F, 0.0F), CatmullRom),
            new Keyframe(0.56F, DegreeVec(0.0F, 1.12F, 0.0F), CatmullRom),
            new Keyframe(1.44F, DegreeVec(0.0F, 17.5F, 0.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, 16.5F, 0.0F), CatmullRom)))
        .AddAnimation("head", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 4.0F, -5.8F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(0.0F, -4.0F, 5.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, 4.0F, -5.8F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, -60.0F, 0.0F), CatmullRom),
            new Keyframe(1.24F, DegreeVec(0.0F, -45.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, -60.0F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(0.0F, 38.0F, 0.0F), CatmullRom),
            new Keyframe(0.64F, DegreeVec(0.0F, 53.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(0.0F, 38.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation,
            new Keyframe(0.0F, DegreeVec(-34.0F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(1.04F, DegreeVec(-41.5F, 0.0F, 0.0F), CatmullRom),
            new Keyframe(2.04F, DegreeVec(-34.0F, 0.0F, 0.0F), CatmullRom)))
        .Build();
    public static readonly AnimationDefinition BabyAxolotlPlayDead = AnimationDefinition.Builder.WithLength(0.04F)
        .AddAnimation("body", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 30.0F), CatmullRom)))
        .AddAnimation("body", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("body", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(202.35F, -30.33F, -40.82F), CatmullRom)))
        .AddAnimation("right_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.2F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_front_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(418.0F, -50.0F, 35.8F), CatmullRom)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_hind_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(177.0F, 22.76F, 15.9F), CatmullRom)))
        .AddAnimation("left_front_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(-0.2F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_front_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(16.4287F, -37.6467F, 16.9822F), CatmullRom)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_hind_leg", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("tail", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, -18.67F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("tail", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("head", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(-4.21F, -0.95F, -6.33F), Linear)))
        .AddAnimation("head", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("head", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("left_gills", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 43.21F, 0.0F), CatmullRom)))
        .AddAnimation("left_gills", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("left_gills", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("right_gills", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, -55.87F, 0.0F), CatmullRom)))
        .AddAnimation("right_gills", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("right_gills", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("top_gills", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(43.0F, 0.0F, 0.0F), CatmullRom)))
        .AddAnimation("top_gills", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("top_gills", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .AddAnimation("root", new AnimationChannel(Rotation, new Keyframe(0.0F, DegreeVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("root", new AnimationChannel(Position, new Keyframe(0.0F, PosVec(0.0F, 0.0F, 0.0F), Linear)))
        .AddAnimation("root", new AnimationChannel(Scale, new Keyframe(0.0F, ScaleVec(1.0, 1.0, 1.0), Linear)))
        .Build();
}
