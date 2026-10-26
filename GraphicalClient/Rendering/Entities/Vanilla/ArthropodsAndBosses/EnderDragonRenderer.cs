using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EnderDragonRenderState : EntityRenderState {
    public float FlapTime, DeathTime;
    public bool HasRedOverlay, IsLandingOrTakingOff, IsSitting;
    public double DistanceToEgg;
    public float PartialTicks;
    public ClientLib.Maths.Vec3d? BeamOffset;
    public readonly DragonFlightHistory FlightHistory = new();

    public DragonFlightHistory.Sample GetHistoricalPos(int delay) => FlightHistory.Get(delay, PartialTicks);

    public float GetHeadPartYOffset(int part, DragonFlightHistory.Sample bodyPos, DragonFlightHistory.Sample partPos) {
        double result;
        if (IsLandingOrTakingOff) {
            result = part / Math.Max(DistanceToEgg / 4.0, 1.0);
        }
        else if (IsSitting) {
            result = part;
        }
        else if (part == 6) {
            result = 0.0;
        }
        else {
            result = partPos.Y - bodyPos.Y;
        }
        return (float)result;
    }
}

/// <summary>
/// <c>EnderDragonRenderer</c>. The dissolve the dying dragon is drawn with is left out: it masks the
/// texture against <c>dragon_exploding.png</c> at the same coordinates as it fades, a second texture no
/// entity geometry carries, so a dying dragon draws whole.
/// </summary>
public sealed class EnderDragonRenderer : EntityRenderer<EnderDragonRenderState> {
    private const string DragonTextureLocation = "minecraft:textures/entity/enderdragon/dragon.png";
    private const string DragonEyesLocation = "minecraft:textures/entity/enderdragon/dragon_eyes.png";
    private const string CrystalBeamLocation = "minecraft:textures/entity/end_crystal/end_crystal_beam.png";
    private static readonly float HalfSqrt3 = (float)(Math.Sqrt(3.0) / 2.0);

    // EnderDragonPhase ids, in the order the phases are created.
    private const int Landing = 3, Takeoff = 4, SittingFlaming = 5, SittingScanning = 6, SittingAttacking = 7, Hovering = 10, PhaseCount = 11;

    private readonly EnderDragonModel _model;

    public EnderDragonRenderer(EntityRendererContext context) {
        ShadowRadius = 0.5F;
        _model = new EnderDragonModel(EnderDragonModel.CreateBodyLayer().BakeRoot());
    }

    /// <summary>What <c>EnderDragon</c> keeps on the client: its wing beat, death count, flight history and nearest crystal.</summary>
    private sealed class DragonData {
        public float FlapTime, OFlapTime;
        public int DragonDeathTime;
        public readonly DragonFlightHistory FlightHistory = new();
        public ClientEntity? NearestCrystal;

        /// <summary><c>Entity.random</c>, which <c>checkCrystals</c> draws from on the client too.</summary>
        public readonly Random Random = new();
    }

    // The crystals are found among the other entities, which a tick has no way to look up, so the client is taken from the last frame.
    private ClientLib.MinecraftClient? _client;

    /// <summary><c>EnderDragonPhase.getById</c>, as the client's phase manager is set from <c>DATA_PHASE</c>.</summary>
    private static int Phase(ClientEntity entity) {
        int id = entity.Get(EntityDataFields.EnderDragon.Phase, Hovering);
        return id < 0 || id >= PhaseCount ? 0 : id;
    }

    /// <summary><c>DragonPhaseInstance.isSitting</c>: the three sitting phases and hovering.</summary>
    private static bool IsSitting(int phase) => phase is SittingFlaming or SittingScanning or SittingAttacking or Hovering;

    /// <summary>
    /// <c>EnderDragon.tickDeath</c>'s count and <c>aiStep</c>'s client half. The dragon records its flight
    /// before it interpolates toward the server, which is the position and heading the entity started
    /// this tick with. <c>inWall</c> is only ever set by the server, so the client never slows for it.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        DragonData data = (DragonData)(entity.RendererData ??= new DragonData());
        bool deadOrDying = entity.CurrentHealth <= 0;
        if (deadOrDying) {
            data.DragonDeathTime++;
        }
        data.OFlapTime = data.FlapTime;
        if (deadOrDying) {
            return;
        }
        CheckCrystals(entity, data);
        double hx = entity.DeltaMovement.X, hz = entity.DeltaMovement.Z;
        float flapSpeed = 0.2F / ((float)Math.Sqrt(hx * hx + hz * hz) * 10.0F + 1.0F);
        flapSpeed *= (float)Math.Pow(2.0, entity.DeltaMovement.Y);
        if (IsSitting(Phase(entity))) {
            data.FlapTime += 0.1F;
        }
        else {
            data.FlapTime += flapSpeed;
        }
        bool noAi = (entity.Get(EntityDataFields.Mob.MobFlags) & 1) != 0;
        if (noAi) {
            data.FlapTime = 0.5F;
        }
        else {
            data.FlightHistory.Record(entity.OldPosition.Y, Mth.WrapDegrees(entity.YRotO));
        }
    }

    /// <summary>
    /// <c>EnderDragon.checkCrystals</c>, which the client runs too: a removed crystal is let go, and one tick
    /// in ten the nearest crystal within 32 blocks of the dragon's box is taken. The heal is the server's.
    /// </summary>
    private void CheckCrystals(ClientEntity entity, DragonData data) {
        if (data.NearestCrystal is { IsRemoved: true }) {
            data.NearestCrystal = null;
        }
        if (data.Random.Next(10) != 0 || _client == null) {
            return;
        }
        Minecraft.Physics.Box box = entity.BoundingBox;
        ClientEntity? nearest = null;
        double distance = double.MaxValue;
        foreach (ClientEntity crystal in _client.Entities.Values) {
            if (!crystal.Is(EntityClass.EndCrystal)) {
                continue;
            }
            Minecraft.Physics.Box crystalBox = crystal.BoundingBox;
            if (crystalBox.MaxX <= box.MinX - 32.0 || crystalBox.MinX >= box.MaxX + 32.0 || crystalBox.MaxY <= box.MinY - 32.0
                || crystalBox.MinY >= box.MaxY + 32.0 || crystalBox.MaxZ <= box.MinZ - 32.0 || crystalBox.MinZ >= box.MaxZ + 32.0) {
                continue;
            }
            double dx = crystal.Position.X - entity.Position.X, dy = crystal.Position.Y - entity.Position.Y, dz = crystal.Position.Z - entity.Position.Z;
            double dist = dx * dx + dy * dy + dz * dz;
            if (dist < distance) {
                distance = dist;
                nearest = crystal;
            }
        }
        data.NearestCrystal = nearest;
    }

    public override bool AffectedByCulling(ClientEntity entity) => false;

    public override void ExtractRenderState(ClientEntity entity, EnderDragonRenderState state, float partialTick, EntityRenderContext context) {
        _client = context.Client;
        base.ExtractRenderState(entity, state, partialTick, context);
        DragonData data = (DragonData)(entity.RendererData ??= new DragonData());
        if (data.NearestCrystal is { } nearestCrystal) {
            ClientLib.Maths.Vec3d crystalPosition = ClientLib.Entities.Leashes.Position(nearestCrystal, partialTick)
                + new ClientLib.Maths.Vec3d(0.0, EndCrystalRenderer.GetY(EndCrystalRenderer.Time(nearestCrystal, partialTick)), 0.0);
            state.BeamOffset = crystalPosition - ClientLib.Entities.Leashes.Position(entity, partialTick);
        }
        else {
            state.BeamOffset = null;
        }
        state.FlapTime = Mth.Lerp(partialTick, data.OFlapTime, data.FlapTime);
        state.DeathTime = data.DragonDeathTime > 0 ? data.DragonDeathTime + partialTick : 0.0F;
        state.HasRedOverlay = entity.HurtTime > 0;
        int phase = Phase(entity);
        state.IsLandingOrTakingOff = phase is Landing or Takeoff;
        state.IsSitting = IsSitting(phase);
        // The client's dragon never learns its fight origin, so the egg is looked for over the origin.
        int eggY = context.Level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.MotionBlockingNoLeaves, 0, 0);
        double dx = 0.5 - entity.Position.X, dy = eggY + 0.5 - entity.Position.Y, dz = 0.5 - entity.Position.Z;
        state.DistanceToEgg = dx * dx + dy * dy + dz * dz;
        state.PartialTicks = entity.CurrentHealth <= 0 ? 0.0F : partialTick;
        state.FlightHistory.CopyFrom(data.FlightHistory);
    }

    public override void Submit(EnderDragonRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        float yr = state.GetHistoricalPos(7).YRot;
        float rot2 = (float)(state.GetHistoricalPos(5).Y - state.GetHistoricalPos(10).Y);
        pose.RotateYDegrees(-yr);
        pose.RotateXDegrees(rot2 * 10.0F);
        pose.Translate(0.0F, 0.0F, 1.0F);
        pose.Scale(-1.0F, -1.0F, 1.0F);
        pose.Translate(0.0F, -1.501F, 0.0F);
        _model.SetupAnim(state);
        EntityTexture texture = context.Textures.Get(DragonTextureLocation) ?? context.Textures.Missing;
        // While dying vanilla draws the dissolve with no overlay; see the class comment.
        float red = state.DeathTime > 0.0F ? 0 : state.HasRedOverlay ? 1 : 0;
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, red));
        if (context.Textures.Get(DragonEyesLocation) is { } eyes) {
            // Full sky and block light is the stand-in for the eyes render type's additive, unlit blending.
            _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(eyes, 0xFFFFFFFF, 15, 15, 0) { NoOutline = true, Emissive = true, Unshaded = true });
        }
        if (state.DeathTime > 0.0F && context.AdditiveBatch is { } additive) {
            float deathTime = state.DeathTime / 200.0F;
            pose.Push();
            pose.Translate(0.0F, -1.0F, -2.0F);
            SubmitRays(pose, deathTime, additive);
            pose.Pop();
        }
        pose.Pop();
        if (state.BeamOffset is { } beamOffset) {
            SubmitCrystalBeams((float)beamOffset.X, (float)beamOffset.Y, (float)beamOffset.Z, state.AgeInTicks, pose, context, state.SkyLight, state.BlockLight);
        }
    }

    /// <summary>
    /// <c>submitRays</c>: fans of three triangles, white at the centre fading out with the overdrive and
    /// magenta and clear at the tips, each turned further from the last.
    /// </summary>
    private static void SubmitRays(PoseStack pose, float deathTime, EntityBatch batch) {
        float overDrive = Math.Min(deathTime > 0.8F ? (deathTime - 0.8F) / 0.2F : 0.0F, 1.0F);
        uint innerColor = (uint)Mth.Floor((1.0F - overDrive) * 255.0F) << 24 | 0xFFFFFF;
        const uint outerColor = 16711935;
        ModelDrawState draw = new(batch.Textures.White, 0xFFFFFFFF, 15, 15, 0) { NoOutline = true };
        Assets.ResourcePacks.JavaRandom random = new(432L);
        int rayCount = Mth.Floor((deathTime + deathTime * deathTime) / 2.0F * 60.0F);
        pose.Push();
        for (int i = 0; i < rayCount; i++) {
            float x0 = random.NextFloat() * (float)(Math.PI * 2), y0 = random.NextFloat() * (float)(Math.PI * 2), z0 = random.NextFloat() * (float)(Math.PI * 2);
            float x1 = random.NextFloat() * (float)(Math.PI * 2), y1 = random.NextFloat() * (float)(Math.PI * 2);
            float z1 = random.NextFloat() * (float)(Math.PI * 2) + deathTime * (float)(Math.PI / 2);
            // rotationXYZ(x0, y0, z0).rotateXYZ(x1, y1, z1), applied to the pose without a push: each ray turns from the last.
            pose.RotateXYZ(x0, y0, z0);
            pose.RotateXYZ(x1, y1, z1);
            float length = random.NextFloat() * 20.0F + 5.0F + overDrive * 10.0F;
            float width = random.NextFloat() * 2.0F + 1.0F + overDrive * 2.0F;
            System.Numerics.Matrix4x4 m = pose.Matrix;
            System.Numerics.Vector3 origin = System.Numerics.Vector3.Transform(System.Numerics.Vector3.Zero, m);
            System.Numerics.Vector3 outerLeft = System.Numerics.Vector3.Transform(new System.Numerics.Vector3(-HalfSqrt3 * width, length, -0.5F * width), m);
            System.Numerics.Vector3 outerRight = System.Numerics.Vector3.Transform(new System.Numerics.Vector3(HalfSqrt3 * width, length, -0.5F * width), m);
            System.Numerics.Vector3 outerBottom = System.Numerics.Vector3.Transform(new System.Numerics.Vector3(0.0F, length, width), m);
            batch.Triangle(origin, outerLeft, outerRight, innerColor, outerColor, outerColor, draw);
            batch.Triangle(origin, outerRight, outerBottom, innerColor, outerColor, outerColor, draw);
            batch.Triangle(origin, outerBottom, outerLeft, innerColor, outerColor, outerColor, draw);
        }
        pose.Pop();
    }

    /// <summary><c>submitCrystalBeams</c>: an eight sided tube from the pose to the delta, narrowing at the start, its texture scrolling along it.</summary>
    public static void SubmitCrystalBeams(float deltaX, float deltaY, float deltaZ, float timeInTicks, PoseStack pose, EntityRenderContext context,
        float skyLight, float blockLight) {
        if (context.Textures.Get(CrystalBeamLocation) is not { } texture) {
            return;
        }
        float horizontalLength = Mth.Sqrt(deltaX * deltaX + deltaZ * deltaZ);
        float length = Mth.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        pose.Push();
        pose.Translate(0.0F, 2.0F, 0.0F);
        pose.RotateY((float)-Math.Atan2(deltaZ, deltaX) - (float)(Math.PI / 2));
        pose.RotateX((float)-Math.Atan2(horizontalLength, deltaY) - (float)(Math.PI / 2));
        float v0 = 0.0F - timeInTicks * 0.01F;
        float v1 = length / 32.0F - timeInTicks * 0.01F;
        ModelDrawState draw = new(texture, 0xFFFFFFFF, skyLight, blockLight, 0) { NoOutline = true };
        System.Numerics.Matrix4x4 m = pose.Matrix;
        System.Numerics.Vector3 normal = pose.TransformNormal(-System.Numerics.Vector3.UnitY);
        System.Numerics.Vector3 V(float x, float y, float z) => System.Numerics.Vector3.Transform(new System.Numerics.Vector3(x, y, z), m);
        float lastSin = 0.0F;
        float lastCos = 0.75F;
        float lastU = 0.0F;
        for (int i = 1; i <= 8; i++) {
            float sin = Mth.Sin(i * (float)(Math.PI * 2) / 8.0F) * 0.75F;
            float cos = Mth.Cos(i * (float)(Math.PI * 2) / 8.0F) * 0.75F;
            float u = i / 8.0F;
            context.Batch.RepeatingQuad([V(lastSin * 0.2F, lastCos * 0.2F, 0.0F), V(lastSin, lastCos, length), V(sin, cos, length), V(sin * 0.2F, cos * 0.2F, 0.0F)],
                [new(lastU, v0), new(lastU, v1), new(u, v1), new(u, v0)], [0xFF000000, 0xFFFFFFFF, 0xFFFFFFFF, 0xFF000000], normal, draw);
            lastSin = sin;
            lastCos = cos;
            lastU = u;
        }
        pose.Pop();
    }
}
