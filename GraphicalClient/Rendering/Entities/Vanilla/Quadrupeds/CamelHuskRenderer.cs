using ClientLib.Entities;
using ClientLib.World;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CamelHuskRenderer : MobRenderer<CamelRenderState, CamelModel> {
    public CamelHuskRenderer(EntityRendererContext context) : base(new AdultCamelModel(AdultCamelModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        AddLayer(CamelRenderer.CreateCamelSaddleLayer(context, this, EquipmentClientInfo.LayerType.CamelHuskSaddle));
    }

    public override string GetTextureLocation(CamelRenderState state) => "minecraft:textures/entity/camel/camel_husk.png";

    public override void Tick(ClientEntity entity, ClientLevel level) => CamelClientState.Tick(entity, level);

    public override void ExtractRenderState(ClientEntity entity, CamelRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        CamelRenderer.ExtractAdditionalState(entity, state, partialTick);
    }
}
