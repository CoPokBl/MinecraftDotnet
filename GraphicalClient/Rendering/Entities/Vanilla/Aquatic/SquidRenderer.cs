using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SquidRenderState : LivingEntityRenderState {
    public float TentacleAngle, XBodyRot, ZBodyRot;
}

/// <summary><c>SquidRenderer</c>, with the client half of <c>Squid.aiStep</c> that poses it.</summary>
public class SquidRenderer : AgeableMobRenderer<SquidRenderState, SquidModel> {
    private const byte TentacleResetEvent = 19;

    private static readonly Random Random = new();

    public SquidRenderer(EntityRendererContext context)
        : base(new SquidModel(SquidModel.CreateBodyLayer().BakeRoot()), new SquidModel(BabySquidModel.CreateBodyLayer().BakeRoot()), 0.7F) { }

    /// <summary>The fields <c>Squid</c> keeps for its animation.</summary>
    private sealed class Squid {
        public float XBodyRot, XBodyRotO, ZBodyRot, ZBodyRotO, TentacleMovement, OldTentacleMovement, TentacleAngle, OldTentacleAngle, RotateSpeed;

        // The Squid constructor's roll. Only the server rerolls it, so the client keeps this one.
        public readonly float TentacleSpeed = 1.0F / (Random.NextSingle() + 1.0F) * 0.2F;

        /// <summary><c>LivingEntity.yBodyRot</c> as this class turns it, which vanilla never wraps.</summary>
        public float YBodyRot;
        public bool YBodyRotSet;
    }

    private static Squid DataOf(ClientEntity entity) => (Squid)(entity.RendererData ??= new Squid());

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == TentacleResetEvent) {
            DataOf(entity).TentacleMovement = 0.0F;
        }
    }

    /// <summary><c>Squid.aiStep</c> on the client.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Squid squid = DataOf(entity);
        if (!squid.YBodyRotSet) {
            squid.YBodyRot = entity.YBodyRotO;
            squid.YBodyRotSet = true;
        }
        squid.XBodyRotO = squid.XBodyRot;
        squid.ZBodyRotO = squid.ZBodyRot;
        squid.OldTentacleMovement = squid.TentacleMovement;
        squid.OldTentacleAngle = squid.TentacleAngle;
        squid.TentacleMovement = squid.TentacleMovement + squid.TentacleSpeed;
        if (squid.TentacleMovement > Math.PI * 2) {
            squid.TentacleMovement = (float)(Math.PI * 2);
        }

        if (EntityWater.IsInWater(level, entity)) {
            if (squid.TentacleMovement < (float)Math.PI) {
                float tentacleScale = squid.TentacleMovement / (float)Math.PI;
                squid.TentacleAngle = Mth.Sin(tentacleScale * tentacleScale * (float)Math.PI) * (float)Math.PI * 0.25F;
                if (tentacleScale > 0.75) {
                    squid.RotateSpeed = 1.0F;
                }
                else {
                    squid.RotateSpeed *= 0.8F;
                }
            }
            else {
                squid.TentacleAngle = 0.0F;
                squid.RotateSpeed *= 0.99F;
            }

            Vec3d movement = AiStepMovement(entity.DeltaMovement);
            double horizontalMovement = Math.Sqrt(movement.HorizontalDistanceSqr());
            float yBodyRot = squid.YBodyRot;
            yBodyRot = yBodyRot + (-(float)Math.Atan2(movement.X, movement.Z) * (180.0F / (float)Math.PI) - yBodyRot) * 0.1F;
            TurnBody(entity, squid, yBodyRot);
            squid.ZBodyRot = squid.ZBodyRot + (float)Math.PI * squid.RotateSpeed * 1.5F;
            squid.XBodyRot = squid.XBodyRot + (-(float)Math.Atan2(horizontalMovement, movement.Y) * (180.0F / (float)Math.PI) - squid.XBodyRot) * 0.1F;
        }
        else {
            squid.TentacleAngle = Mth.Abs(Mth.Sin(squid.TentacleMovement)) * (float)Math.PI * 0.25F;
            squid.XBodyRot = squid.XBodyRot + (-90.0F - squid.XBodyRot) * 0.02F;
            squid.YBodyRot = entity.YBodyRot;
        }
    }

    /// <summary>
    /// The delta movement <c>Squid.aiStep</c> reads after <c>LivingEntity.aiStep</c> has zeroed components
    /// under 0.003. The 0.98 decay aiStep applies while not interpolating is left out: the client entity
    /// does not expose whether it is, so the vector is the last one the server sent.
    /// </summary>
    private static Vec3d AiStepMovement(Vec3d movement) => new(
        Math.Abs(movement.X) < 0.003 ? 0.0 : movement.X,
        Math.Abs(movement.Y) < 0.003 ? 0.0 : movement.Y,
        Math.Abs(movement.Z) < 0.003 ? 0.0 : movement.Z);

    /// <summary>
    /// <c>LivingEntity.tick</c>'s body turn after <c>aiStep</c>, from the yaw the squid has just set.
    /// <see cref="ClientEntity.Tick"/> turns the body before this runs and in the other order, so the
    /// turn is redone here and its result replaces that one. <c>setYRot</c> is not written back: the
    /// client entity's yaw is the server's interpolation target, and the server's squid sets the same.
    /// </summary>
    private static void TurnBody(ClientEntity entity, Squid squid, float yBodyRot) {
        float yRot = yBodyRot;
        double xd = entity.Position.X - entity.OldPosition.X;
        double zd = entity.Position.Z - entity.OldPosition.Z;
        float sideDist = (float)(xd * xd + zd * zd);
        float yBodyRotT = yBodyRot;
        if (sideDist > 0.0025000002F) {
            float walkDirection = (float)Math.Atan2(zd, xd) * (180.0F / (float)Math.PI) - 90.0F;
            float diffBetweenDirectionAndFacing = Mth.Abs(Mth.WrapDegrees(yRot) - walkDirection);
            yBodyRotT = 95.0F < diffBetweenDirectionAndFacing && diffBetweenDirectionAndFacing < 265.0F ? walkDirection - 180.0F : walkDirection;
        }
        if (entity.AttackAnim > 0.0F) {
            yBodyRotT = yRot;
        }
        // tickHeadTurn.
        yBodyRot += Mth.WrapDegrees(yBodyRotT - yBodyRot) * 0.3F;
        float headDiff = Mth.WrapDegrees(yRot - yBodyRot);
        if (Math.Abs(headDiff) > 50.0F) {
            yBodyRot += headDiff - Math.Sign(headDiff) * 50.0F;
        }
        squid.YBodyRot = yBodyRot;
        entity.YBodyRot = yBodyRot;
        while (entity.YBodyRot - entity.YBodyRotO < -180.0F) {
            entity.YBodyRotO -= 360.0F;
        }
        while (entity.YBodyRot - entity.YBodyRotO >= 180.0F) {
            entity.YBodyRotO += 360.0F;
        }
    }

    public override string GetTextureLocation(SquidRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/squid/squid_baby.png" : "minecraft:textures/entity/squid/squid.png";

    public override void ExtractRenderState(ClientEntity entity, SquidRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        if (entity.RendererData is Squid squid) {
            state.TentacleAngle = Mth.Lerp(partialTick, squid.OldTentacleAngle, squid.TentacleAngle);
            state.XBodyRot = Mth.Lerp(partialTick, squid.XBodyRotO, squid.XBodyRot);
            state.ZBodyRot = Mth.Lerp(partialTick, squid.ZBodyRotO, squid.ZBodyRot);
        }
    }

    protected override void SetupRotations(SquidRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        pose.Translate(0.0F, state.IsBaby ? 0.25F : 0.5F, 0.0F);
        pose.RotateYDegrees(180.0F - bodyRot);
        pose.RotateXDegrees(state.XBodyRot);
        pose.RotateYDegrees(state.ZBodyRot);
        pose.Translate(0.0F, state.IsBaby ? -0.6F : -1.2F, 0.0F);
    }
}
