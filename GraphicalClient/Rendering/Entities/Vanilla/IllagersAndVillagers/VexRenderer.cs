using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class VexRenderState : ArmedEntityRenderState {
    public bool IsCharging;
}

/// <summary><c>VexRenderer</c>: always at full block light.</summary>
public sealed class VexRenderer : MobRenderer<VexRenderState, VexModel> {
    private readonly ItemRenderer _items;

    public VexRenderer(EntityRendererContext context) : base(new VexModel(VexModel.CreateBodyLayer().BakeRoot()), 0.3F) {
        _items = context.Items;
        AddLayer(new ItemInHandLayer<VexRenderState, VexModel>(this, context.Items));
    }

    public override string GetTextureLocation(VexRenderState state) =>
        state.IsCharging ? "minecraft:textures/entity/illager/vex_charging.png" : "minecraft:textures/entity/illager/vex.png";

    public override void ExtractRenderState(ClientEntity entity, VexRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
        ArmedEntityRenderState.ExtractArmedEntityRenderState(entity, state, _items, partialTick);
        // Vex.isCharging: FLAG_IS_CHARGING of DATA_FLAGS_ID.
        state.IsCharging = (entity.Get(EntityDataFields.Vex.Flags) & 1) != 0;
    }
}
