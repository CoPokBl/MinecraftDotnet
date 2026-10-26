using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class EvokerRenderState : IllagerRenderState {
    public bool IsCastingSpell;
}

/// <summary><c>EvokerRenderer</c>: the held item shows only while casting.</summary>
public sealed class EvokerRenderer : IllagerRenderer<EvokerRenderState> {
    public EvokerRenderer(EntityRendererContext context) : base(context) {
        AddLayer(new ConditionalItemInHandLayer(this, context.Items, state => state.IsCastingSpell));
    }

    public override string GetTextureLocation(EvokerRenderState state) => "minecraft:textures/entity/illager/evoker.png";

    /// <summary><c>SpellcasterIllager.getArmPose</c>.</summary>
    protected override IllagerArmPose GetArmPose(ClientEntity entity) {
        if (IsCastingSpell(entity)) {
            return IllagerArmPose.Spellcasting;
        }
        return IsCelebrating(entity) ? IllagerArmPose.Celebrating : IllagerArmPose.Crossed;
    }

    public override void ExtractRenderState(ClientEntity entity, EvokerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsCastingSpell = IsCastingSpell(entity);
    }
}
