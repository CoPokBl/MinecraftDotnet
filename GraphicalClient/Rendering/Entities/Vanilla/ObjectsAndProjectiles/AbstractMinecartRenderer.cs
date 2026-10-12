using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>MinecartRenderState</c>, without the new behaviour's fields, which only the experimental minecart movement fills.</summary>
public class MinecartRenderState : EntityRenderState {
    public float XRot;
    public float YRot;
    public long OffsetSeed;
    public int HurtDir;
    public float HurtTime;
    public float DamageTime;
    public int DisplayOffset;
    public IBlock? DisplayBlock;
    public Vec3d? PosOnRail;
    public Vec3d? FrontPos;
    public Vec3d? BackPos;
}

/// <summary><c>MinecartRenderer</c>. Every minecart model layer is <c>MinecartModel.createBodyLayer</c>, so one bake serves them all.</summary>
public sealed class MinecartRenderer(EntityRendererContext context) : AbstractMinecartRenderer<MinecartRenderState>(context);

/// <summary>
/// <c>AbstractMinecartRenderer</c>, for <c>OldMinecartBehavior</c> only: the new behaviour belongs to the
/// experimental minecart movement, which a client of a server without the experiment never sees.
/// </summary>
public abstract class AbstractMinecartRenderer<S> : EntityRenderer<S> where S : MinecartRenderState, new() {
    private const string MinecartLocation = "minecraft:textures/entity/minecart/minecart.png";

    protected readonly MinecartModel Model;
    private readonly BlockModelRenderer _blocks;

    protected AbstractMinecartRenderer(EntityRendererContext context) {
        ShadowRadius = 0.7F;
        Model = new MinecartModel(MinecartModel.CreateBodyLayer().BakeRoot());
        _blocks = context.Blocks;
    }

    /// <summary>The hurt shake <c>AbstractMinecart.tick</c> counts down on the client's own copy of the synced values.</summary>
    protected class ClientMinecart {
        public readonly LocalEntityData<int> HurtTime = new(EntityDataFields.VehicleEntity.IdHurt, 0);
        public readonly LocalEntityData<float> Damage = new(EntityDataFields.VehicleEntity.IdDamage, 0.0F);
    }

    protected virtual ClientMinecart CreateClientState() => new();

    protected ClientMinecart Cart(ClientEntity entity) => (ClientMinecart)(entity.RendererData ??= CreateClientState());

    public override void Tick(ClientEntity entity) {
        ClientMinecart cart = Cart(entity);
        if (cart.HurtTime.Sync(entity) > 0) {
            cart.HurtTime.Value--;
        }
        if (cart.Damage.Sync(entity) > 0.0F) {
            cart.Damage.Value -= 1.0F;
        }
    }

    public override (System.Numerics.Vector3 Min, System.Numerics.Vector3 Max)? BoundingBoxForCulling(ClientEntity entity) {
        float half = (float)entity.Width / 2;
        float bottom = 0, top = (float)entity.Height;
        if (!GetDisplayBlockState(entity).Air) {
            // expandTowards: the box grows by the contents' offset, down for a negative one.
            float offset = GetDisplayOffset(entity) * 0.75F / 16.0F;
            if (offset < 0) {
                bottom += offset;
            }
            else {
                top += offset;
            }
        }
        return (new System.Numerics.Vector3(-half, bottom, -half), new System.Numerics.Vector3(half, top, half));
    }

    /// <summary><c>AbstractMinecart.getDisplayBlockState</c>.</summary>
    private static IBlock GetDisplayBlockState(ClientEntity entity) {
        Optional<IBlock>? custom = entity.Get(EntityDataFields.AbstractMinecart.IdCustomDisplayBlock);
        return custom is { Present: true, Value: { } block } ? block : GetDefaultDisplayBlockState(entity);
    }

    /// <summary>Each minecart class's <c>getDefaultDisplayBlockState</c>.</summary>
    private static IBlock GetDefaultDisplayBlockState(ClientEntity entity) =>
        entity.Type.Equals(EntityType.ChestMinecart) ? Block.Chest
        : entity.Type.Equals(EntityType.FurnaceMinecart) ? Block.Furnace.WithLit(entity.Get(EntityDataFields.MinecartFurnace.IdFuel))
        : entity.Type.Equals(EntityType.CommandBlockMinecart) ? Block.CommandBlock
        : entity.Type.Equals(EntityType.HopperMinecart) ? Block.Hopper
        : entity.Type.Equals(EntityType.SpawnerMinecart) ? Block.Spawner
        : entity.Type.Equals(EntityType.TntMinecart) ? Block.Tnt
        : Block.Air;

    /// <summary><c>getDisplayOffset</c>, defaulting to each class's <c>getDefaultDisplayOffset</c>.</summary>
    private static int GetDisplayOffset(ClientEntity entity) {
        int fallback = entity.Type.Equals(EntityType.ChestMinecart) ? 8 : entity.Type.Equals(EntityType.HopperMinecart) ? 1 : 6;
        return entity.Get(EntityDataFields.AbstractMinecart.IdDisplayOffset, fallback);
    }

    public override void Submit(S state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        long seed = state.OffsetSeed;
        float offsetX = (((seed >> 16 & 7L) + 0.5F) / 8.0F - 0.5F) * 0.004F;
        float offsetY = (((seed >> 20 & 7L) + 0.5F) / 8.0F - 0.5F) * 0.004F;
        float offsetZ = (((seed >> 24 & 7L) + 0.5F) / 8.0F - 0.5F) * 0.004F;
        pose.Translate(offsetX, offsetY, offsetZ);
        OldRender(state, pose);
        float hurt = state.HurtTime;
        if (hurt > 0.0F) {
            pose.RotateXDegrees(Mth.Sin(hurt) * hurt * state.DamageTime / 10.0F * state.HurtDir);
        }
        if (state.DisplayBlock is { Air: false } displayBlock) {
            pose.Push();
            pose.Scale(0.75F, 0.75F, 0.75F);
            pose.Translate(-0.5F, (state.DisplayOffset - 8) / 16.0F, 0.5F);
            pose.RotateYDegrees(90.0F);
            SubmitMinecartContents(state, displayBlock, pose, context);
            pose.Pop();
        }
        pose.Scale(-1.0F, -1.0F, 1.0F);
        Model.SetupAnim(state);
        Model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(MinecartLocation), state));
        pose.Pop();
    }

    private static void OldRender(S state, PoseStack pose) {
        double entityX = state.X;
        double entityY = state.Y;
        double entityZ = state.Z;
        float xRot = state.XRot;
        float rotation = state.YRot;
        if (state.PosOnRail is { } posOnRail && state.FrontPos is { } frontPos && state.BackPos is { } backPos) {
            pose.Translate((float)(posOnRail.X - entityX), (float)((frontPos.Y + backPos.Y) / 2.0 - entityY), (float)(posOnRail.Z - entityZ));
            Vec3d direction = backPos.Add(-frontPos.X, -frontPos.Y, -frontPos.Z);
            if (direction.Length() != 0.0) {
                direction = direction.Normalize();
                rotation = (float)(Math.Atan2(direction.Z, direction.X) * 180.0 / Math.PI);
                xRot = (float)(Math.Atan(direction.Y) * 73.0);
            }
        }
        pose.Translate(0.0F, 0.375F, 0.0F);
        pose.RotateYDegrees(180.0F - rotation);
        pose.RotateZDegrees(-xRot);
    }

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        OldExtractState(entity, state, partialTick, context.Level);
        ClientMinecart cart = Cart(entity);
        long seed = entity.Id * 493286711L;
        state.OffsetSeed = seed * seed * 4392167121L + seed * 98761L;
        state.HurtTime = cart.HurtTime.Value - partialTick;
        state.HurtDir = entity.Get(EntityDataFields.VehicleEntity.IdHurtdir, 1);
        state.DamageTime = Math.Max(cart.Damage.Value - partialTick, 0.0F);
        state.DisplayOffset = GetDisplayOffset(entity);
        state.DisplayBlock = GetDisplayBlockState(entity);
    }

    private static void OldExtractState(ClientEntity entity, S state, float partialTick, ClientLevel level) {
        state.XRot = GetXRot(entity, partialTick);
        state.YRot = GetYRot(entity, partialTick);
        double entityX = state.X;
        double entityY = state.Y;
        double entityZ = state.Z;
        state.PosOnRail = GetPos(level, entityX, entityY, entityZ);
        if (state.PosOnRail is { } onRail) {
            state.FrontPos = GetPosOffs(level, entityX, entityY, entityZ, 0.3F) ?? onRail;
            state.BackPos = GetPosOffs(level, entityX, entityY, entityZ, -0.3F) ?? onRail;
        }
        else {
            state.FrontPos = state.BackPos = null;
        }
    }

    protected virtual void SubmitMinecartContents(S state, IBlock block, PoseStack pose, EntityRenderContext context) =>
        _blocks.Render(block, pose, context.Batch, state.SkyLight, state.BlockLight);

    /// <summary>
    /// <c>BaseRailBlock.isRail</c> with the state's <c>RailShape</c>. The six value shape the powered,
    /// detector and activator rails carry lists the same first six shapes in the same order.
    /// </summary>
    private static RailShape? RailShapeOf(IBlock block) => block switch {
        IRailShaped shaped => shaped.Shape,
        IRailDirected directed => (RailShape)(int)directed.Shape,
        _ => null
    };

    /// <summary><c>AbstractMinecart.EXITS</c>, each shape's two ends as block steps.</summary>
    private static ((int X, int Y, int Z) First, (int X, int Y, int Z) Second) Exits(RailShape shape) => shape switch {
        RailShape.NorthSouth => ((0, 0, -1), (0, 0, 1)),
        RailShape.EastWest => ((-1, 0, 0), (1, 0, 0)),
        RailShape.AscendingEast => ((-1, -1, 0), (1, 0, 0)),
        RailShape.AscendingWest => ((-1, 0, 0), (1, -1, 0)),
        RailShape.AscendingNorth => ((0, 0, -1), (0, -1, 1)),
        RailShape.AscendingSouth => ((0, -1, -1), (0, 0, 1)),
        RailShape.SouthEast => ((0, 0, 1), (1, 0, 0)),
        RailShape.SouthWest => ((0, 0, 1), (-1, 0, 0)),
        RailShape.NorthWest => ((0, 0, -1), (-1, 0, 0)),
        _ => ((0, 0, -1), (1, 0, 0))
    };

    private static bool IsSlope(RailShape shape) =>
        shape is RailShape.AscendingEast or RailShape.AscendingWest or RailShape.AscendingNorth or RailShape.AscendingSouth;

    /// <summary><c>OldMinecartBehavior.getPosOffs</c>.</summary>
    private static Vec3d? GetPosOffs(ClientLevel level, double x, double y, double z, double offs) {
        int xt = (int)Math.Floor(x);
        int yt = (int)Math.Floor(y);
        int zt = (int)Math.Floor(z);
        if (RailShapeOf(level.GetBlock(xt, yt - 1, zt)) != null) {
            yt--;
        }
        if (RailShapeOf(level.GetBlock(xt, yt, zt)) is not { } shape) {
            return null;
        }
        y = yt;
        if (IsSlope(shape)) {
            y = yt + 1;
        }
        ((int X, int Y, int Z) exit0, (int X, int Y, int Z) exit1) = Exits(shape);
        double xD = exit1.X - exit0.X;
        double zD = exit1.Z - exit0.Z;
        double dd = Math.Sqrt(xD * xD + zD * zD);
        xD /= dd;
        zD /= dd;
        x += xD * offs;
        z += zD * offs;
        if (exit0.Y != 0 && (int)Math.Floor(x) - xt == exit0.X && (int)Math.Floor(z) - zt == exit0.Z) {
            y += exit0.Y;
        }
        else if (exit1.Y != 0 && (int)Math.Floor(x) - xt == exit1.X && (int)Math.Floor(z) - zt == exit1.Z) {
            y += exit1.Y;
        }
        return GetPos(level, x, y, z);
    }

    /// <summary><c>OldMinecartBehavior.getPos</c>.</summary>
    private static Vec3d? GetPos(ClientLevel level, double x, double y, double z) {
        int xt = (int)Math.Floor(x);
        int yt = (int)Math.Floor(y);
        int zt = (int)Math.Floor(z);
        if (RailShapeOf(level.GetBlock(xt, yt - 1, zt)) != null) {
            yt--;
        }
        if (RailShapeOf(level.GetBlock(xt, yt, zt)) is not { } shape) {
            return null;
        }
        ((int X, int Y, int Z) exit0, (int X, int Y, int Z) exit1) = Exits(shape);
        double x0 = xt + 0.5 + exit0.X * 0.5;
        double y0 = yt + 0.0625 + exit0.Y * 0.5;
        double z0 = zt + 0.5 + exit0.Z * 0.5;
        double x1 = xt + 0.5 + exit1.X * 0.5;
        double y1 = yt + 0.0625 + exit1.Y * 0.5;
        double z1 = zt + 0.5 + exit1.Z * 0.5;
        double xD = x1 - x0;
        double yD = (y1 - y0) * 2.0;
        double zD = z1 - z0;
        double progress;
        if (xD == 0.0) {
            progress = z - zt;
        }
        else if (zD == 0.0) {
            progress = x - xt;
        }
        else {
            double xx = x - x0;
            double zz = z - z0;
            progress = (xx * xD + zz * zD) * 2.0;
        }
        x = x0 + xD * progress;
        y = y0 + yD * progress;
        z = z0 + zD * progress;
        if (yD < 0.0) {
            y++;
        }
        else if (yD > 0.0) {
            y += 0.5;
        }
        return new Vec3d(x, y, z);
    }
}

/// <summary><c>MinecartModel</c>.</summary>
public sealed class MinecartModel : EntityModel<MinecartRenderState> {
    public MinecartModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild(
            "bottom",
            CubeListBuilder.Create().TexOffs(0, 10).AddBox(-10.0F, -8.0F, -1.0F, 20.0F, 16.0F, 2.0F),
            PartPose.OffsetAndRotation(0.0F, 4.0F, 0.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild(
            "front",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -9.0F, -1.0F, 16.0F, 8.0F, 2.0F),
            PartPose.OffsetAndRotation(-9.0F, 4.0F, 0.0F, 0.0F, (float)(Math.PI * 3.0 / 2.0), 0.0F));
        root.AddOrReplaceChild(
            "back",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -9.0F, -1.0F, 16.0F, 8.0F, 2.0F),
            PartPose.OffsetAndRotation(9.0F, 4.0F, 0.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        root.AddOrReplaceChild(
            "left",
            CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -9.0F, -1.0F, 16.0F, 8.0F, 2.0F),
            PartPose.OffsetAndRotation(0.0F, 4.0F, -7.0F, 0.0F, (float)Math.PI, 0.0F));
        root.AddOrReplaceChild("right", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -9.0F, -1.0F, 16.0F, 8.0F, 2.0F), PartPose.Offset(0.0F, 4.0F, 7.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }
}
