using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SnowGolemRenderState : LivingEntityRenderState {
    public IBlock? HeadBlock;
}

public sealed class SnowGolemRenderer : MobRenderer<SnowGolemRenderState, SnowGolemModel> {
    public SnowGolemRenderer(EntityRendererContext context) : base(new SnowGolemModel(SnowGolemModel.CreateBodyLayer().BakeRoot()), 0.5F) {
        AddLayer(new SnowGolemHeadLayer(this, context.Blocks));
    }

    public override string GetTextureLocation(SnowGolemRenderState state) => "minecraft:textures/entity/snow_golem/snow_golem.png";

    public override void ExtractRenderState(ClientEntity entity, SnowGolemRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // SnowGolem.hasPumpkin: bit 4 of DATA_PUMPKIN_ID, which starts set, so a golem the server sends
        // nothing for still wears one.
        state.HeadBlock = (entity.Get(EntityDataFields.SnowGolem.Pumpkin, (sbyte)16) & 16) != 0 ? Block.CarvedPumpkin : null;
    }
}
