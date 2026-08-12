using Minecraft.Data.Generated;
using Minecraft.Data.PaintingVariant;
using Minecraft.Data.Blocks;
using Minecraft.Data.Particles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Conformance;

/// <summary>
/// One <c>set_entity_data</c> packet per metadata field type.
/// </summary>
/// <remarks>
/// Reflection can't fabricate these: the value's type has to match the type id written beside
/// it, or the sample proves nothing. They're worth the hand maintenance because vanilla writes
/// each value with a serializer looked up by id, so this catches both a mis-numbered
/// <see cref="MetaFieldType"/> (its ids are positions in a vanilla registry that shifts when
/// entries are added) and a value we encode differently to the game.
/// </remarks>
public static class MetaSamples {
    public static IEnumerable<(string Name, string Serialiser, ClientBoundSetEntityMetadataPacket Packet)> Build() {
        foreach ((MetaFieldType type, object value) in Values()) {
            EntityMetaContainer meta = new();
            meta.Fields.Add(0, new MetaField(type, value));

            yield return (
                $"ClientBoundSetEntityMetadataPacket[{type}]",
                VanillaSerialisers[type],
                new ClientBoundSetEntityMetadataPacket {
                    EntityId = 1,
                    Meta = meta
                });
        }
    }

    /// <summary>
    /// What each of our types is meant to be, named as the field in vanilla's
    /// <c>EntityDataSerializers</c>. The harness resolves the name to a serializer and checks
    /// the id we wrote resolves to that same one.
    /// </summary>
    /// <remarks>
    /// Without this, a type id that shifts onto a serializer of the same wire shape decodes
    /// perfectly and the packet looks fine — which is how the ids drifted in the first place.
    /// Values that share a shape (every variant is a var int) are indistinguishable by bytes
    /// alone, so intent has to be stated somewhere, and here is the cheapest place.
    /// </remarks>
    private static readonly Dictionary<MetaFieldType, string> VanillaSerialisers = new() {
        { MetaFieldType.Byte, "BYTE" },
        { MetaFieldType.VarInt, "INT" },
        { MetaFieldType.VarLong, "LONG" },
        { MetaFieldType.Float, "FLOAT" },
        { MetaFieldType.String, "STRING" },
        { MetaFieldType.TextComponent, "COMPONENT" },
        { MetaFieldType.OptionalTextComponent, "OPTIONAL_COMPONENT" },
        { MetaFieldType.Slot, "ITEM_STACK" },
        { MetaFieldType.Boolean, "BOOLEAN" },
        { MetaFieldType.Rotations, "ROTATIONS" },
        { MetaFieldType.Position, "BLOCK_POS" },
        { MetaFieldType.OptionalPosition, "OPTIONAL_BLOCK_POS" },
        { MetaFieldType.Direction, "DIRECTION" },
        { MetaFieldType.OptionalLivingEntityReference, "OPTIONAL_LIVING_ENTITY_REFERENCE" },
        { MetaFieldType.BlockState, "BLOCK_STATE" },
        { MetaFieldType.OptionalBlockState, "OPTIONAL_BLOCK_STATE" },
        { MetaFieldType.Particle, "PARTICLE" },
        { MetaFieldType.Particles, "PARTICLES" },
        { MetaFieldType.VillagerData, "VILLAGER_DATA" },
        { MetaFieldType.OptionalVarInt, "OPTIONAL_UNSIGNED_INT" },
        { MetaFieldType.Pose, "POSE" },
        { MetaFieldType.CatVariant, "CAT_VARIANT" },
        { MetaFieldType.CatSoundVariant, "CAT_SOUND_VARIANT" },
        { MetaFieldType.CowVariant, "COW_VARIANT" },
        { MetaFieldType.CowSoundVariant, "COW_SOUND_VARIANT" },
        { MetaFieldType.WolfVariant, "WOLF_VARIANT" },
        { MetaFieldType.WolfSoundVariant, "WOLF_SOUND_VARIANT" },
        { MetaFieldType.FrogVariant, "FROG_VARIANT" },
        { MetaFieldType.PigVariant, "PIG_VARIANT" },
        { MetaFieldType.PigSoundVariant, "PIG_SOUND_VARIANT" },
        { MetaFieldType.ChickenVariant, "CHICKEN_VARIANT" },
        { MetaFieldType.ChickenSoundVariant, "CHICKEN_SOUND_VARIANT" },
        { MetaFieldType.ZombieNautilusVariant, "ZOMBIE_NAUTILUS_VARIANT" },
        { MetaFieldType.OptionalGlobalPosition, "OPTIONAL_GLOBAL_POS" },
        { MetaFieldType.PaintingVariant, "PAINTING_VARIANT" },
        { MetaFieldType.SnifferState, "SNIFFER_STATE" },
        { MetaFieldType.ArmadilloState, "ARMADILLO_STATE" },
        { MetaFieldType.CopperGolemState, "COPPER_GOLEM_STATE" },
        { MetaFieldType.WeatheringCopperState, "WEATHERING_COPPER_STATE" },
        { MetaFieldType.Vector3, "VECTOR3" },
        { MetaFieldType.Quaternion, "QUATERNION" },
        { MetaFieldType.ResolvableProfile, "RESOLVABLE_PROFILE" },
        { MetaFieldType.HumanoidArm, "HUMANOID_ARM" }
    };

    /// <summary>
    /// Every type <see cref="EntityMetaContainer"/> can write. A type missing from here is
    /// reported by the runner, so this staying in step with the enum is checked rather than
    /// assumed.
    /// </summary>
    private static IEnumerable<(MetaFieldType, object)> Values() {
        yield return (MetaFieldType.Byte, (sbyte)0);
        yield return (MetaFieldType.VarInt, 0);
        yield return (MetaFieldType.VarLong, 0L);
        yield return (MetaFieldType.Float, 0f);
        yield return (MetaFieldType.String, "test");
        yield return (MetaFieldType.TextComponent, TextComponent.Empty());
        yield return (MetaFieldType.OptionalTextComponent, Optional<TextComponent>.Empty);
        yield return (MetaFieldType.Slot, ItemStack.Air);
        yield return (MetaFieldType.Boolean, false);
        yield return (MetaFieldType.Rotations, new Vec3<float>(0, 0, 0));
        yield return (MetaFieldType.Position, new Vec3<int>(0, 0, 0));
        yield return (MetaFieldType.OptionalPosition, Optional<Vec3<int>>.Empty);
        yield return (MetaFieldType.Direction, Cardinal.North);
        yield return (MetaFieldType.OptionalLivingEntityReference, Optional<Guid>.Empty);
        yield return (MetaFieldType.BlockState, Block.Stone);
        yield return (MetaFieldType.OptionalBlockState, Optional<IBlock>.Empty);
        yield return (MetaFieldType.Particle, Particle.Flame);
        yield return (MetaFieldType.Particles, new IParticle[] { Particle.Flame });
        yield return (MetaFieldType.VillagerData, (0, 0, 1));
        yield return (MetaFieldType.OptionalVarInt, Optional<int>.Empty);
        yield return (MetaFieldType.Pose, EntityPose.Standing);
        yield return (MetaFieldType.CatVariant, 0);
        yield return (MetaFieldType.CatSoundVariant, 0);
        yield return (MetaFieldType.CowVariant, 0);
        yield return (MetaFieldType.CowSoundVariant, 0);
        yield return (MetaFieldType.WolfVariant, 0);
        yield return (MetaFieldType.WolfSoundVariant, 0);
        yield return (MetaFieldType.FrogVariant, 0);
        yield return (MetaFieldType.PigVariant, 0);
        yield return (MetaFieldType.PigSoundVariant, 0);
        yield return (MetaFieldType.ChickenVariant, 0);
        yield return (MetaFieldType.ChickenSoundVariant, 0);
        yield return (MetaFieldType.ZombieNautilusVariant, 0);
        yield return (MetaFieldType.OptionalGlobalPosition, Optional<(Identifier, Vec3<int>)>.Empty);
        yield return (MetaFieldType.PaintingVariant, Or<int, IPaintingVariant>.FromValue1(0));
        yield return (MetaFieldType.SnifferState, SnifferState.Idling);
        yield return (MetaFieldType.ArmadilloState, ArmadilloState.Idle);
        yield return (MetaFieldType.CopperGolemState, CopperGolemState.Idle);
        yield return (MetaFieldType.WeatheringCopperState, WeatheringCopperState.Unaffected);
        yield return (MetaFieldType.Vector3, new Vec3<float>(0, 0, 0));
        yield return (MetaFieldType.Quaternion, new Quaternion(0, 0, 0, 1));
        yield return (MetaFieldType.HumanoidArm, HumanoidArm.Right);
    }

    /// <summary>Types with no sample above, so the runner can say so out loud.</summary>
    public static IEnumerable<MetaFieldType> Uncovered() {
        HashSet<MetaFieldType> covered = Values().Select(pair => pair.Item1).ToHashSet();
        return Enum.GetValues<MetaFieldType>().Where(type => !covered.Contains(type));
    }
}
