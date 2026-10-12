using GraphicalClient.Assets.Skins;
using GraphicalClient.Rendering.BlockEntities;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>CustomHeadLayer</c>'s statics: its <c>Transforms</c> and <c>translateToHead</c>.</summary>
public static class CustomHeadLayer {
    public sealed record Transforms(float YOffset, float SkullYOffset, float HorizontalScale) {
        public static readonly Transforms Default = new(0.0F, 0.0F, 1.0F);
    }

    public static void TranslateToHead(PoseStack pose, Transforms transforms) {
        pose.Translate(0.0F, -0.25F + transforms.YOffset, 0.0F);
        pose.RotateYDegrees(180.0F);
        pose.Scale(0.625F, -0.625F, -0.625F);
    }

    /// <summary>
    /// <c>LivingEntityRenderer.extractRenderState</c>'s head item: what the layer draws for a stack worn on
    /// the head, null for a skull or for armour, which other layers draw.
    /// </summary>
    public static ItemStackModel? HeadItem(ItemStack headItem, ItemRenderer items, ClientLib.Entities.ClientEntity owner) {
        if (headItem.IsAir() || IsSkull(headItem) || HumanoidArmorLayer.ShouldRender(headItem, EquipmentSlot.Helmet)) {
            return null;
        }
        return items.Resolve(headItem, ItemDisplayContext.Head, owner);
    }

    /// <summary>A block item whose block is an <c>AbstractSkullBlock</c>, which <c>wornHeadType</c> is set for.</summary>
    public static bool IsSkull(ItemStack stack) => stack.Type.CorrespondingBlock is { } block && BlockClasses.Is(block, BlockClass.AbstractSkullBlock);
}

/// <summary><c>CustomHeadLayer</c>: a worn skull or mob head as its block's model, anything else as its item.</summary>
public sealed class CustomHeadLayer<S, M> : RenderLayer<S, M>
    where S : LivingEntityRenderState, new()
    where M : EntityModel<S>, IHeadedModel {
    private readonly CustomHeadLayer.Transforms _transforms;
    private readonly ItemRenderer _items;
    private readonly Dictionary<SkullKind, SkullModelBase> _skullModels = new();

    public CustomHeadLayer(LivingEntityRenderer<S, M> renderer, ItemRenderer items) : this(renderer, items, CustomHeadLayer.Transforms.Default) { }

    public CustomHeadLayer(LivingEntityRenderer<S, M> renderer, ItemRenderer items, CustomHeadLayer.Transforms transforms) : base(renderer) {
        _transforms = transforms;
        _items = items;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        ItemStack headStack = HumanoidEntityData.ItemBySlot(state.Entity, EquipmentSlot.Helmet, context);
        // LivingEntityRenderer.extractRenderState's wornHeadType: the skull block's type when the stack is one.
        SkullKind? wornHeadType = CustomHeadLayer.IsSkull(headStack)
            ? SkullBlockRenderer.KindOf(context.Client.Registry.Blocks.Get(headStack.Type.CorrespondingBlock!.Value))?.Kind
            : null;
        ItemStackModel? headItem = CustomHeadLayer.HeadItem(headStack, _items, state.Entity);
        if (headItem == null && wornHeadType == null) {
            return;
        }
        pose.Push();
        pose.Scale(_transforms.HorizontalScale, 1.0F, _transforms.HorizontalScale);
        M parentModel = Parent.CurrentModel;
        parentModel.RootPart.TranslateAndRotate(pose);
        ((IHeadedModel)parentModel).TranslateToHead(pose);
        if (wornHeadType is { } type) {
            pose.Translate(0.0F, _transforms.SkullYOffset, 0.0F);
            pose.Scale(1.1875F, 1.1875F, 1.1875F);
            if (!_skullModels.TryGetValue(type, out SkullModelBase? skullModel)) {
                skullModel = SkullBlockRenderer.CreateModel(type);
                _skullModels[type] = skullModel;
            }
            // resolveSkullRenderType: a player head's skin draws translucent, any other skull cut out.
            ProfileComponent.Data? profile = type == SkullKind.Player ? headStack.GetOrNull(DataComponent.Profile) : null;
            string texture = profile != null ? SkinManager.GetOrDefault(profile).Body : SkullBlockRenderer.SkinByType(type).Texture.ToString();
            SkullBlockRenderer.SubmitSkull(WornHeadAnimationPos(state, context.PartialTick), pose, profile != null ? context.TranslucentBatch : context.Batch,
                state.SkyLight, state.BlockLight, skullModel, context.Texture(texture));
        }
        else {
            CustomHeadLayer.TranslateToHead(pose, _transforms);
            _items.Submit(headItem!, ItemDisplayContext.Head, pose, context.Batch, state.SkyLight, state.BlockLight);
        }
        pose.Pop();
    }

    /// <summary><c>wornHeadAnimationPos</c>: a rider's is its living mount's walk, so a dragon head chews in step.</summary>
    private static float WornHeadAnimationPos(S state, float partialTick) =>
        state.Entity.Vehicle is { IsLiving: true } vehicle ? vehicle.WalkAnimationPosition(partialTick) : state.WalkAnimationPos;
}
