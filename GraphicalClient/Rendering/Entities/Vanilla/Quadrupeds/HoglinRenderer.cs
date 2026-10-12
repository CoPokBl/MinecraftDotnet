using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using NBT;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class HoglinRenderer() : AbstractHoglinRenderer("minecraft:textures/entity/hoglin/hoglin.png", "minecraft:textures/entity/hoglin/hoglin_baby.png") {
    public override void ExtractRenderState(ClientEntity entity, HoglinRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsConverting = IsConverting(entity, context.Level);
    }

    protected override bool IsShaking(HoglinRenderState state) => base.IsShaking(state) || state.IsConverting;

    /// <summary><c>Hoglin.isConverting</c>.</summary>
    private static bool IsConverting(ClientEntity entity, ClientLevel level) {
        // Mob.isNoAi: bit 0 of DATA_MOB_FLAGS_ID.
        bool noAi = (entity.Get(EntityDataFields.Mob.MobFlags) & 1) != 0;
        return !entity.Get(EntityDataFields.Hoglin.ImmuneToZombification) && !noAi && PiglinsZombify(entity, level);
    }

    /// <summary>
    /// <c>EnvironmentAttributes.PIGLINS_ZOMBIFY</c> where the entity stands: the biome's value over the
    /// dimension's over the default. A biome entry that modifies the dimension's value rather than
    /// replacing it is not applied; no vanilla biome has one for this attribute.
    /// </summary>
    private static bool PiglinsZombify(ClientEntity entity, ClientLevel level) {
        bool value = level.DimensionType.Attributes?[EnvironmentAttribute.GameplayPiglinsZombify.Identifier.ToString()] is not { } dimension || dimension.GetBoolean();
        int x = (int)Math.Floor(entity.Position.X), y = (int)Math.Floor(entity.Position.Y), z = (int)Math.Floor(entity.Position.Z);
        int biomeId = level.GetBiome(x, y, z);
        if (biomeId < level.Registry.Biomes.Count
            && level.Registry.Biomes[biomeId].Attributes[EnvironmentAttribute.GameplayPiglinsZombify] is EnvironmentAttributeEntry.Constant { Value: EnvironmentAttributeValue.Boolean fromBiome }) {
            value = fromBiome.Value;
        }
        return value;
    }
}
