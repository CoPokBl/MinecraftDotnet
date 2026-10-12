using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class GoatRenderState : LivingEntityRenderState {
    public bool HasLeftHorn = true;
    public bool HasRightHorn = true;
    public float RammingXHeadRot;
}

public sealed class GoatRenderer() : AgeableMobRenderer<GoatRenderState, GoatModel>(
    new GoatModel(GoatModel.CreateBodyLayer().BakeRoot()), new BabyGoatModel(BabyGoatModel.CreateBodyLayer().BakeRoot()), 0.7F) {
    /// <summary><c>Goat.isLoweringHead</c>, which entity events 58 and 59 set, and <c>lowerHeadTick</c>.</summary>
    private sealed class Ram {
        public bool IsLoweringHead;
        public int LowerHeadTick;
    }

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId is 58 or 59) {
            ((Ram)(entity.RendererData ??= new Ram())).IsLoweringHead = eventId == 58;
        }
    }

    /// <summary><c>Goat.aiStep</c>'s head count.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.RendererData is not Ram ram) {
            return;
        }
        if (ram.IsLoweringHead) {
            ram.LowerHeadTick++;
        }
        else {
            ram.LowerHeadTick -= 2;
        }
        ram.LowerHeadTick = Math.Clamp(ram.LowerHeadTick, 0, 20);
    }

    public override string GetTextureLocation(GoatRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/goat/goat_baby.png" : "minecraft:textures/entity/goat/goat.png";

    public override void ExtractRenderState(ClientEntity entity, GoatRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.HasLeftHorn = entity.Get(EntityDataFields.Goat.HasLeftHorn, true);
        state.HasRightHorn = entity.Get(EntityDataFields.Goat.HasRightHorn, true);
        // Goat.getRammingXHeadRot.
        int lowerHeadTick = entity.RendererData is Ram ram ? ram.LowerHeadTick : 0;
        float maxRammingXHeadRot = entity.IsBaby ? 52.5F : 30.0F;
        state.RammingXHeadRot = lowerHeadTick / 20.0F * maxRammingXHeadRot * (MathF.PI / 180.0F);
    }
}
