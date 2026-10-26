using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>PlayerItemInHandLayer</c>.</summary>
public sealed class PlayerItemInHandLayer<S, M> : ItemInHandLayer<S, M>
    where S : AvatarRenderState, new()
    where M : EntityModel<S>, IArmedModel<S>, IHeadedModel {
    private readonly ItemRenderer _items;

    public PlayerItemInHandLayer(LivingEntityRenderer<S, M> renderer, ItemRenderer items) : base(renderer, items) {
        _items = items;
    }

    protected override void SubmitArmWithItem(S state, ItemStackModel? item, ItemStack stack, HumanoidArm arm, PoseStack pose, EntityRenderContext context) {
        if (item == null) {
            return;
        }
        Hand currentHand = arm == state.MainArm ? Hand.MainHand : Hand.OffHand;
        if (state.IsUsingItem && state.UseItemHand == currentHand && state.AttackTime < 1.0E-5F && state.HeldOnHead != null) {
            RenderItemHeldToEye(state, arm, pose, context);
        }
        else {
            base.SubmitArmWithItem(state, item, stack, arm, pose, context);
        }
    }

    private void RenderItemHeldToEye(S state, HumanoidArm arm, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        M model = Parent.CurrentModel;
        model.RootPart.TranslateAndRotate(pose);
        ModelPart head = model.Head;
        float previousXRot = head.XRot;
        head.XRot = Mth.Clamp(head.XRot, (float)(-Math.PI / 6), (float)(Math.PI / 2));
        head.TranslateAndRotate(pose);
        head.XRot = previousXRot;
        CustomHeadLayer.TranslateToHead(pose, CustomHeadLayer.Transforms.Default);
        bool isLeftHand = arm == HumanoidArm.Left;
        pose.Translate((isLeftHand ? -2.5F : 2.5F) / 16.0F, -0.0625F, 0.0F);
        _items.Submit(state.HeldOnHead!, ItemDisplayContext.Head, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
