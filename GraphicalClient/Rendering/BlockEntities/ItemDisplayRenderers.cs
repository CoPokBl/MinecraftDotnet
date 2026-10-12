using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class ItemDisplayRenderState : BlockEntityRenderState {
    public Direction Facing = Direction.North;
    public ItemStackModel?[] Items = [];
    public bool AlignToBottom;
}

/// <summary><c>CampfireRenderer</c>: the food on the four corners of the fire.</summary>
public sealed class CampfireRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ItemDisplayBlockEntity, ItemDisplayRenderState> {
    public override void ExtractRenderState(ItemDisplayBlockEntity blockEntity, ItemDisplayRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Facing = blockEntity.State is IHorizontalFacing facing ? facing.Facing : Direction.North;
        state.Items = blockEntity.Items.Select(stack => stack.IsAir() ? null : context.Items.Resolve(stack, ItemDisplayContext.Fixed)).ToArray();
    }

    public override void Submit(ItemDisplayRenderState state, PoseStack pose, EntityRenderContext render) {
        for (int slot = 0; slot < state.Items.Length; slot++) {
            if (state.Items[slot] is not { } item) {
                continue;
            }
            pose.Push();
            pose.Translate(0.5F, 0.44921875F, 0.5F);
            Direction direction = DirectionUtil.From2DDataValue((slot + DirectionUtil.Get2DDataValue(state.Facing)) % 4);
            pose.RotateYDegrees(-DirectionUtil.ToYRot(direction));
            pose.RotateXDegrees(90.0F);
            pose.Translate(-0.3125F, -0.3125F, 0.0F);
            pose.Scale(0.375F, 0.375F, 0.375F);
            context.Items.Submit(item, ItemDisplayContext.Fixed, pose, render.Batch, state.SkyLight, state.BlockLight);
            pose.Pop();
        }
    }
}

/// <summary><c>ShelfRenderer</c>: three items standing on the shelf.</summary>
public sealed class ShelfRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ItemDisplayBlockEntity, ItemDisplayRenderState> {
    public override void ExtractRenderState(ItemDisplayBlockEntity blockEntity, ItemDisplayRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.AlignToBottom = blockEntity.AlignItemsToBottom;
        state.Facing = blockEntity.State is IHorizontalFacing facing ? facing.Facing : Direction.North;
        state.Items = blockEntity.Items.Select(stack => stack.IsAir() ? null : context.Items.Resolve(stack, ItemDisplayContext.OnShelf)).ToArray();
    }

    public override void Submit(ItemDisplayRenderState state, PoseStack pose, EntityRenderContext render) {
        float yRot = -DirectionUtil.ToYRot(state.Facing);
        for (int slot = 0; slot < state.Items.Length; slot++) {
            if (state.Items[slot] is { } item) {
                SubmitItem(state, item, pose, render, slot, yRot);
            }
        }
    }

    private void SubmitItem(ItemDisplayRenderState state, ItemStackModel item, PoseStack pose, EntityRenderContext render, int slot, float yRot) {
        float itemSlotPosition = (slot - 1) * 0.3125F;
        pose.Push();
        pose.Translate(0.5F, 0.5F, 0.5F);
        pose.RotateYDegrees(yRot);
        pose.Translate(itemSlotPosition, state.AlignToBottom ? -0.25F : 0.0F, -0.25F);
        pose.Scale(0.25F, 0.25F, 0.25F);
        (System.Numerics.Vector3 min, System.Numerics.Vector3 max) = item.ModelBoundingBox;
        double offsetY = -min.Y;
        if (!state.AlignToBottom) {
            offsetY += -(max.Y - min.Y) / 2.0;
        }
        pose.Translate(0.0F, (float)offsetY, 0.0F);
        context.Items.Submit(item, ItemDisplayContext.OnShelf, pose, render.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}

public sealed class BrushableBlockRenderState : BlockEntityRenderState {
    public ItemStackModel? Item;
    public int DustProgress;
    public Cardinal? HitDirection;
}

/// <summary><c>BrushableBlockRenderer</c>: the find coming out of suspicious sand or gravel as it is brushed.</summary>
public sealed class BrushableBlockRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<BrushableBlockEntity, BrushableBlockRenderState> {
    public override void ExtractRenderState(BrushableBlockEntity blockEntity, BrushableBlockRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.HitDirection = blockEntity.HitDirection;
        state.DustProgress = blockEntity.Dusted;
        if (blockEntity.HitDirection is { } hit) {
            (int dx, int dy, int dz) = DirectionUtil.Step(hit);
            (state.SkyLight, state.BlockLight) = LightAt(render.Level, blockEntity.X + dx, blockEntity.Y + dy, blockEntity.Z + dz, blockEntity.State);
        }
        state.Item = blockEntity.Item.IsAir() ? null : context.Items.Resolve(blockEntity.Item, ItemDisplayContext.Fixed);
    }

    public override void Submit(BrushableBlockRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.DustProgress <= 0 || state.HitDirection is not { } hit || state.Item is not { } item) {
            return;
        }
        pose.Push();
        pose.Translate(0.0F, 0.5F, 0.0F);
        (float x, float y, float z) = Translations(hit, state.DustProgress);
        pose.Translate(x, y, z);
        pose.RotateYDegrees(75.0F);
        bool eastWest = hit is Cardinal.East or Cardinal.West;
        pose.RotateYDegrees((eastWest ? 90 : 0) + 11);
        pose.Scale(0.5F, 0.5F, 0.5F);
        context.Items.Submit(item, ItemDisplayContext.Fixed, pose, render.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    private static (float X, float Y, float Z) Translations(Cardinal direction, int completionState) {
        float x = 0.5F, y = 0.0F, z = 0.5F;
        float completionOffset = completionState / 10.0F * 0.75F;
        switch (direction) {
            case Cardinal.East:
                x = 0.73F + completionOffset;
                break;
            case Cardinal.West:
                x = 0.25F - completionOffset;
                break;
            case Cardinal.Up:
                y = 0.25F + completionOffset;
                break;
            case Cardinal.Down:
                y = -0.23F - completionOffset;
                break;
            case Cardinal.North:
                z = 0.25F - completionOffset;
                break;
            case Cardinal.South:
                z = 0.73F + completionOffset;
                break;
        }
        return (x, y, z);
    }
}

public sealed class VaultRenderState : BlockEntityRenderState {
    public ItemEntityRenderState? DisplayItem;
    public float Spin;
}

/// <summary><c>VaultRenderer</c>: the reward turning inside an active vault.</summary>
public sealed class VaultRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<VaultBlockEntity, VaultRenderState> {
    public override void ExtractRenderState(VaultBlockEntity blockEntity, VaultRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        ItemStack displayItem = blockEntity.DisplayItem;
        if (!displayItem.IsAir()) {
            state.DisplayItem = new ItemEntityRenderState();
            ItemEntityRenderer.ExtractItemGroupRenderState(state.DisplayItem, displayItem, context.Items, render);
            state.Spin = Mth.RotLerp(partialTick, blockEntity.PreviousSpin, blockEntity.CurrentSpin);
        }
    }

    public override void Submit(VaultRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.DisplayItem?.Item is not { } item) {
            return;
        }
        pose.Push();
        pose.Translate(0.5F, 0.4F, 0.5F);
        pose.RotateYDegrees(state.Spin);
        (System.Numerics.Vector3 min, System.Numerics.Vector3 max) = item.ModelBoundingBox;
        ItemEntityRenderer.SubmitMultipleFromCount(context.Items, pose, render.Batch, item, state.DisplayItem.Count, state.DisplayItem.Seed, max.Z - min.Z,
            state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
