using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class OcelotRenderer() : AgeableMobRenderer<FelineRenderState, AbstractFelineModel<FelineRenderState>>(
        new AdultOcelotModel(AdultFelineModel<FelineRenderState>.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
        new BabyOcelotModel(BabyFelineModel<FelineRenderState>.CreateBabyLayer().BakeRoot()), 0.4F) {
    public override string GetTextureLocation(FelineRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/cat/ocelot_baby.png" : "minecraft:textures/entity/cat/ocelot.png";

    public override void ExtractRenderState(ClientEntity entity, FelineRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsCrouching = IsCrouching(entity);
        state.IsSprinting = IsSprinting(entity);
    }

    /// <summary><c>Entity.isCrouching</c>: the crouching pose, not the shift key flag.</summary>
    internal static bool IsCrouching(ClientEntity entity) => entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing) == EntityPose.Sneaking;

    /// <summary><c>Entity.isSprinting</c>: shared flag 3.</summary>
    internal static bool IsSprinting(ClientEntity entity) => (entity.SharedFlags & 1 << 3) != 0;
}
