using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EnderDragonRenderState : EntityRenderState {
    public float FlapTime, DeathTime;
    public bool HasRedOverlay, IsLandingOrTakingOff, IsSitting;
    public double DistanceToEgg;
    public float PartialTicks;
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
/// <c>EnderDragonRenderer</c>. Three things it draws are left out: the death rays, which are per vertex
/// coloured additive triangles with no texture; the beam to the nearest end crystal, a scrolling
/// texture; and the dissolve the dying dragon is drawn with, which masks its texture against
/// <c>dragon_exploding.png</c> as it fades, so a dying dragon draws whole instead.
/// </summary>
public sealed class EnderDragonRenderer : EntityRenderer<EnderDragonRenderState> {
    private const string DragonTextureLocation = "minecraft:textures/entity/enderdragon/dragon.png";
    private const string DragonEyesLocation = "minecraft:textures/entity/enderdragon/dragon_eyes.png";

    // EnderDragonPhase ids, in the order the phases are created.
    private const int Landing = 3, Takeoff = 4, SittingFlaming = 5, SittingScanning = 6, SittingAttacking = 7, Hovering = 10, PhaseCount = 11;

    private readonly EnderDragonModel _model;

    public EnderDragonRenderer(EntityRendererContext context) {
        ShadowRadius = 0.5F;
        _model = new EnderDragonModel(EnderDragonModel.CreateBodyLayer().BakeRoot());
    }

    /// <summary>What <c>EnderDragon</c> keeps on the client: its wing beat, death count and flight history.</summary>
    private sealed class DragonData {
        public float FlapTime, OFlapTime;
        public int DragonDeathTime;
        public readonly DragonFlightHistory FlightHistory = new();
    }

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

    public override bool AffectedByCulling(ClientEntity entity) => false;

    public override void ExtractRenderState(ClientEntity entity, EnderDragonRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        DragonData data = (DragonData)(entity.RendererData ??= new DragonData());
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
            _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(eyes, 0xFFFFFFFF, 15, 15, 0) { NoOutline = true });
        }
        pose.Pop();
    }
}
