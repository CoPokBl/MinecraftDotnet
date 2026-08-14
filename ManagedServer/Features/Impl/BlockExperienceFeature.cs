using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Experience orbs from a broken block, vanilla's <c>Block.spawnAfterBreak</c> and
/// <c>tryDropExperience</c>.
/// <p/>
/// Separate from <see cref="BlockDropsFeature"/> because it is a separate vanilla method on a separate
/// gate: items come from the loot table and experience never does, so a minigame can have one without
/// the other.
/// </summary>
public class BlockExperienceFeature : ScopedFeature {
    /// <summary>
    /// The five classes that pass a literal to <c>tryDropExperience</c> or <c>popExperience</c> inside
    /// their <c>spawnAfterBreak</c>, so there is no field for the dumper to read the way there is on
    /// <c>DropExperienceBlock</c>. Resolved through <see cref="BlockClasses"/> nearest first, as the
    /// placement rules are, so a new subclass upstream inherits the right answer.
    /// <p/>
    /// <c>SpawnerBlock</c> is deliberately absent: its amount is a random count stored on the block
    /// entity, and there are no spawner block entities here for it to come from.
    /// </summary>
    private static readonly (BlockClass Class, int Min, int Max)[] LiteralExperience = [
        (BlockClass.RedStoneOreBlock, 1, 5),
        (BlockClass.SculkSensorBlock, 5, 5),
        (BlockClass.SculkShriekerBlock, 5, 5),
        (BlockClass.SculkCatalystBlock, 5, 5),
        (BlockClass.CreakingHeartBlock, 20, 24)
    ];

    public override void Register() {
        AddEventHandler<PlayerBreakBlockEvent>(e => {
            Player player = e.Player;
            IBlock block = e.Block;

            if (player.GameMode == GameMode.Creative) {
                return;
            }

            ItemStack tool = player.HeldItem;
            if (!BlockUtils.CanHarvest(tool, block, player.Server.Registry)) {
                return;
            }

            if (ExperienceRange(block) is not { } range) {
                return;
            }

            // EnchantmentHelper.processBlockExperience, which silk touch's block_experience effect
            // multiplies by zero. Read off the level rather than out of the enchantment's effects: only
            // two effect kinds are parsed at registry load, and block_experience is not one of them, so
            // the enchantment is present here and does nothing.
            if (tool.GetEnchantmentLevel(Enchantment.SilkTouch) > 0) {
                return;
            }

            World world = e.World;
            Vec3<int> position = e.Position;

            // Same deferral as BlockDropsFeature: the break is not settled until every listener has run.
            Scope.Server.Scheduler.ScheduleNextTick(() => {
                if (e.Cancelled) {
                    return;
                }

                Award(world, position, Mth.NextInt(world.Random, range.Min, range.Max));
            });
        });
    }

    /// <summary>How much experience a block is worth, or null for the great majority worth none.</summary>
    private static (int Min, int Max)? ExperienceRange(IBlock block) {
        if (block.Experience is { } dumped) {
            return dumped;
        }

        BlockClass[] chain = BlockClasses.Of(block.Identifier);
        foreach (BlockClass blockClass in chain) {
            foreach ((BlockClass candidate, int min, int max) in LiteralExperience) {
                if (candidate == blockClass) {
                    return (min, max);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// <c>ExperienceOrb.award</c>: an amount is split into orbs of the largest denomination that fits,
    /// repeatedly, so twenty three becomes seventeen, three, three. That split is visible to the player
    /// as how many orbs appear, which is why it is transcribed rather than rounded to one orb.
    /// </summary>
    public static void Award(World world, Vec3<int> position, int amount) {
        Vec3<double> centre = new(position.X + 0.5, position.Y + 0.5, position.Z + 0.5);

        while (amount > 0) {
            int value = ExperienceValue(amount);
            amount -= value;
            Spawn(world, centre, value);
        }
    }

    /// <summary><c>ExperienceOrb.getExperienceValue</c>, vanilla's denominations.</summary>
    public static int ExperienceValue(int maxValue) {
        return maxValue switch {
            >= 2477 => 2477,
            >= 1237 => 1237,
            >= 617 => 617,
            >= 307 => 307,
            >= 149 => 149,
            >= 73 => 73,
            >= 37 => 37,
            >= 17 => 17,
            >= 7 => 7,
            >= 3 => 3,
            _ => 1
        };
    }

    /// <summary><c>ExperienceOrb</c>'s constructor: a random yaw and a small scatter.</summary>
    private static Entity Spawn(World world, Vec3<double> position, int value) {
        RandomSource random = world.Random;

        Entity orb = new(EntityType.ExperienceOrb) {
            Position = position,
            Yaw = Angle.FromDegrees(random.NextFloat() * 360.0f),
            Velocity = new Vec3<double>(
                (random.NextDouble() * 0.2 - 0.1) * 2.0,
                random.NextDouble() * 0.2 * 2.0,
                (random.NextDouble() * 0.2 - 0.1) * 2.0)
        };

        world.Spawn(orb);
        orb.Meta = new ExperienceOrbMeta(value);
        return orb;
    }
}
