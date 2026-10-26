using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class TurtleRenderState : LivingEntityRenderState {
    public bool IsOnLand;
    public bool IsLayingEgg;
    public bool HasEgg;
}

public sealed class TurtleRenderer() : AgeableMobRenderer<TurtleRenderState, TurtleModel>(
    new AdultTurtleModel(AdultTurtleModel.CreateBodyLayer().BakeRoot()), new BabyTurtleModel(BabyTurtleModel.CreateBodyLayer().BakeRoot()), 0.7F) {
    protected override float GetShadowRadius(TurtleRenderState state) {
        float radius = base.GetShadowRadius(state);
        return state.IsBaby ? radius * 0.83F : radius;
    }

    public override string GetTextureLocation(TurtleRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/turtle/turtle_baby.png" : "minecraft:textures/entity/turtle/turtle.png";

    public override void ExtractRenderState(ClientEntity entity, TurtleRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsOnLand = !EntityWater.IsInWater(context.Level, entity) && entity.OnGround;
        state.IsLayingEgg = entity.Get(EntityDataFields.Turtle.LayingEgg);
        state.HasEgg = !entity.IsBaby && entity.Get(EntityDataFields.Turtle.HasEgg);
    }
}
