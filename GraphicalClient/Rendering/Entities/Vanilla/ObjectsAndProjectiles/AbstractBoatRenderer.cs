using System.Numerics;
using ClientLib.Entities;
using ClientLib.Physics;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BoatRenderState</c>.</summary>
public class BoatRenderState : EntityRenderState {
    public float YRot;
    public int HurtDir;
    public float HurtTime;
    public float DamageTime;
    public float BubbleAngle;
    public bool IsUnderWater;
    public float RowingTimeLeft;
    public float RowingTimeRight;
}

/// <summary><c>AbstractBoatRenderer</c>, with the model and texture its subclasses' <c>model()</c> and <c>renderType()</c> give.</summary>
public abstract class AbstractBoatRenderer : EntityRenderer<BoatRenderState> {
    private readonly string _texture;
    private readonly EntityModel<BoatRenderState> _model;

    /// <param name="modelId">The model layer's path, <c>boat/oak</c> or <c>chest_boat/oak</c>, which the texture is named after.</param>
    protected AbstractBoatRenderer(string modelId, EntityModel<BoatRenderState> model) {
        _texture = $"minecraft:textures/entity/{modelId}.png";
        _model = model;
        ShadowRadius = 0.8F;
    }

    /// <summary>What <c>AbstractBoat</c> keeps on the client: its own counts of the hurt shake, the paddles and the bubble column tilt.</summary>
    private sealed class ClientBoat {
        public readonly LocalEntityData<int> HurtTime = new(EntityDataFields.VehicleEntity.IdHurt, 0);
        public readonly LocalEntityData<float> Damage = new(EntityDataFields.VehicleEntity.IdDamage, 0.0F);
        public readonly float[] PaddlePositions = new float[2];
        public float BubbleMultiplier, BubbleAngle, BubbleAngleO;
        public bool UnderWater;
    }

    private static ClientBoat Boat(ClientEntity entity) => (ClientBoat)(entity.RendererData ??= new ClientBoat());

    public override void Tick(ClientEntity entity) => TickBoat(entity, null);

    public override void Tick(ClientEntity entity, ClientLevel level) => TickBoat(entity, level);

    /// <summary><c>AbstractBoat.tick</c>'s client side bookkeeping.</summary>
    private static void TickBoat(ClientEntity entity, ClientLevel? level) {
        ClientBoat boat = Boat(entity);
        boat.UnderWater = level != null && IsUnderwater(entity, level);
        if (boat.HurtTime.Sync(entity) > 0) {
            boat.HurtTime.Value--;
        }
        if (boat.Damage.Sync(entity) > 0.0F) {
            boat.Damage.Value -= 1.0F;
        }
        // tickBubbleColumn, the client half.
        if (entity.Get(EntityDataFields.AbstractBoat.IdBubbleTime) > 0) {
            boat.BubbleMultiplier += 0.05F;
        }
        else {
            boat.BubbleMultiplier -= 0.1F;
        }
        boat.BubbleMultiplier = Mth.Clamp(boat.BubbleMultiplier, 0.0F, 1.0F);
        boat.BubbleAngleO = boat.BubbleAngle;
        boat.BubbleAngle = 10.0F * (float)Math.Sin(0.5 * entity.TickCount) * boat.BubbleMultiplier;
        for (int i = 0; i <= 1; i++) {
            if (GetPaddleState(entity, i)) {
                boat.PaddlePositions[i] = boat.PaddlePositions[i] + (float)(Math.PI / 8);
            }
            else {
                boat.PaddlePositions[i] = 0.0F;
            }
        }
    }

    /// <summary><c>getPaddleState</c>.</summary>
    private static bool GetPaddleState(ClientEntity entity, int side) =>
        entity.Get(side == 0 ? EntityDataFields.AbstractBoat.IdPaddleLeft : EntityDataFields.AbstractBoat.IdPaddleRight) && entity.ControllingPassenger != null;

    /// <summary>
    /// <c>isUnderwater</c>, reduced to whether it returns a status at all: water whose surface is above
    /// the top of the box. The two statuses it tells apart are both <c>isUnderWater</c> to the renderer.
    /// </summary>
    private static bool IsUnderwater(ClientEntity entity, ClientLevel level) {
        double halfWidth = entity.Width / 2.0;
        double minX = entity.Position.X - halfWidth, maxX = entity.Position.X + halfWidth;
        double minZ = entity.Position.Z - halfWidth, maxZ = entity.Position.Z + halfWidth;
        double boxMaxY = entity.Position.Y + entity.Height;
        double maxY = boxMaxY + 0.001;
        int x0 = (int)Math.Floor(minX), x1 = (int)Math.Ceiling(maxX);
        int y0 = (int)Math.Floor(boxMaxY), y1 = (int)Math.Ceiling(maxY);
        int z0 = (int)Math.Floor(minZ), z1 = (int)Math.Ceiling(maxZ);
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                for (int z = z0; z < z1; z++) {
                    MovementBlocks.Entry fluid = MovementBlocks.Get(level.Registry, level.GetState(x, y, z));
                    if (fluid.Fluid == FluidKind.Water && maxY < y + FluidInteraction.FluidHeight(level, x, y, z, fluid)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /// <summary><c>getRowingTime</c>.</summary>
    private static float GetRowingTime(ClientEntity entity, ClientBoat boat, int side, float a) =>
        GetPaddleState(entity, side) ? Mth.ClampedLerp(a, boat.PaddlePositions[side] - (float)(Math.PI / 8), boat.PaddlePositions[side]) : 0.0F;

    public override void ExtractRenderState(ClientEntity entity, BoatRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ClientBoat boat = Boat(entity);
        state.YRot = GetYRot(entity, partialTick);
        state.HurtTime = boat.HurtTime.Value - partialTick;
        state.HurtDir = entity.Get(EntityDataFields.VehicleEntity.IdHurtdir, 1);
        state.DamageTime = Math.Max(boat.Damage.Value - partialTick, 0.0F);
        state.BubbleAngle = Mth.Lerp(partialTick, boat.BubbleAngleO, boat.BubbleAngle);
        state.IsUnderWater = boat.UnderWater;
        state.RowingTimeLeft = GetRowingTime(entity, boat, 0, partialTick);
        state.RowingTimeRight = GetRowingTime(entity, boat, 1, partialTick);
    }

    public override void Submit(BoatRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Translate(0.0F, 0.375F, 0.0F);
        pose.RotateYDegrees(180.0F - state.YRot);
        float hurt = state.HurtTime;
        if (hurt > 0.0F) {
            pose.RotateXDegrees(Mth.Sin(hurt) * hurt * state.DamageTime / 10.0F * state.HurtDir);
        }
        // Mth.equal: within 1.0E-5.
        if (!state.IsUnderWater && Math.Abs(state.BubbleAngle) >= 1.0E-5F) {
            float half = state.BubbleAngle * (float)(Math.PI / 180.0) * 0.5F;
            float s = MathF.Sin(half);
            pose.Rotate(CameraOrientation.JomlRotation(s, 0.0F, s, MathF.Cos(half)));
        }
        pose.Scale(-1.0F, -1.0F, 1.0F);
        pose.RotateYDegrees(90.0F);
        _model.SetupAnim(state);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(_texture), state));
        SubmitTypeAdditions(state, pose, context);
        pose.Pop();
    }

    protected virtual void SubmitTypeAdditions(BoatRenderState state, PoseStack pose, EntityRenderContext context) { }
}
