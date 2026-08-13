using ManagedServer;
using ManagedServer.Ai.Goals.Impl;
using ManagedServer.Ai.Goals.Target;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using ManagedServer.Viewables;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace TestServer.Servers.MobAi;

/// <summary>
/// Mob AI demo. Spawns mobs that decide things for themselves and lets you watch what they decide.
/// <p/>
/// Say a mob's name to spawn one where you are standing: <c>zombie</c>, <c>cow</c>, <c>pig</c>,
/// <c>sheep</c>, <c>chicken</c>. Say <c>clear</c> to remove them all, <c>custom</c> for one built
/// without the vanilla registry, and <c>freeze</c> to toggle every mob's AI off and on.
/// <p/>
/// What to look for: a zombie chases and hits, an animal wanders and watches you, and both now plan.
/// Walk to the far side of the wall and a mob heading for you will make for the gap rather than press
/// into the bricks. Stand past the lava and it will go round the pool, which nothing about the blocks
/// forces since lava is not solid; it is the malus. The staircase shows the step rules: the one block
/// step is a jump the search will take, the two and three block ones are not, so a mob climbs the
/// first and finds another way rather than getting stuck against the second.
/// <p/>
/// It will still walk off a drop it can survive, which is vanilla: a mob spends up to three blocks of
/// fall, and more when it has a target and health to spare.
/// </summary>
public static class MobAiTest {
    private static readonly Vec3<double> SpawnPos = new(0.5, MobAiMapProvider.FloorY, 0.5);

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New(
            ManagedMinecraftServer.BasicsBundle,
            ManagedMinecraftServer.MobsBundle);

        // Not in any bundle, and without it a zombie's hits are worth nothing to armour. Included so
        // the demo shows the whole damage path rather than half of it.
        server.AddFeature(new ArmourFeature());
        server.AddFeature(new FallDamageFeature());

        World world = server.CreateWorld(new MobAiMapProvider());

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            // Survival, because a creative player is not a valid target and no zombie would look at
            // them. That is vanilla's rule, ported in LivingEntity.CanBeSeenAsEnemy.
            e.GameMode = GameMode.Survival;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(SpawnPos);
            Tell(e.Player, "&aMob AI demo.");
            Tell(e.Player, "&7Say &fzombie&7, &fcow&7, &fpig&7, &fsheep&7 or &fchicken&7 to spawn one.");
            Tell(e.Player, "&7Say &fcustom&7 for a hand built mob, &ffreeze&7 to toggle AI, &fclear&7 to remove them.");
            Tell(e.Player, "&7The wall is east, the stairs west and the lava north. Stand behind one and watch them route.");
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            e.Cancelled = true;
            HandleCommand(world, e.Player, e.RawMessage.Trim().ToLowerInvariant());
        });

        server.Start();
        await server.ListenTcp(25565);
    }

    /// <summary>
    /// Sends a message written with legacy <c>&amp;</c> colour codes. <c>SendMessage</c> takes a
    /// <see cref="TextComponent"/> and a bare string converts to one as <b>raw text</b>, so passing
    /// the codes straight in prints them rather than colouring anything.
    /// </summary>
    private static void Tell(Player player, string message) {
        player.SendMessage(TextComponent.FromLegacyString(message));
    }

    private static void HandleCommand(World world, Player player, string message) {
        switch (message) {
            case "zombie":
                Spawn(world, player, EntityType.Zombie);
                break;

            case "cow":
                Spawn(world, player, EntityType.Cow);
                break;

            case "pig":
                Spawn(world, player, EntityType.Pig);
                break;

            case "sheep":
                Spawn(world, player, EntityType.Sheep);
                break;

            case "chicken":
                Spawn(world, player, EntityType.Chicken);
                break;

            case "custom":
                SpawnCustom(world, player);
                break;

            case "freeze":
                Freeze(world, player);
                break;

            case "clear":
                Clear(world, player);
                break;

            default:
                Tell(player, "&cUnknown. Try zombie, cow, pig, sheep, chicken, custom, freeze, clear.");
                break;
        }
    }

    private static void Spawn(World world, Player player, IEntityType type) {
        Mob mob = new(type) {
            Position = player.Position
        };

        // SetWorld is what builds the navigation and fires the spawn event VanillaMobAiFeature listens
        // for, so the goals arrive here rather than in the constructor.
        mob.SetWorld(world);

        Tell(player, $"&aSpawned a &f{type.Identifier.Key}&a with &f{mob.Goals.AvailableGoals.Count}&a goals "
                     + $"and &f{mob.TargetGoals.AvailableGoals.Count}&a target goals.");
    }

    /// <summary>
    /// A mob whose goals are put on by hand before it spawns, which is the second of the three ways a
    /// game gets behaviour. Because its selectors are not empty when the spawn event fires,
    /// <c>VanillaMobAiFeature</c> leaves it alone: this is an override, not an addition.
    /// </summary>
    private static void SpawnCustom(World world, Player player) {
        Mob mob = new(EntityType.Skeleton) {
            Position = player.Position
        };

        // Faster and more short sighted than a vanilla skeleton, to make the difference obvious.
        mob.SetAttributeBaseValue(Attribute.MovementSpeed, 0.35);
        mob.SetAttributeBaseValue(Attribute.FollowRange, 12.0);
        mob.SetAttributeBaseValue(Attribute.AttackDamage, 1.0);

        mob.Goals.AddGoal(1, new MeleeAttackGoal(mob, 1.2, false));
        mob.Goals.AddGoal(5, new RandomStrollGoal(mob, 0.8));
        mob.Goals.AddGoal(6, new LookAtPlayerGoal(mob, 12.0f));
        mob.Goals.AddGoal(7, new RandomLookAroundGoal(mob));
        mob.TargetGoals.AddGoal(1, new HurtByTargetGoal(mob));
        mob.TargetGoals.AddGoal(2, new NearestAttackableTargetGoal(mob));

        mob.SetWorld(world);
        Tell(player, "&aSpawned a hand built skeleton; the vanilla registry left it alone.");
    }

    private static void Freeze(World world, Player player) {
        int count = 0;
        bool? frozen = null;

        foreach (Entity entity in world.Entities.GetEntities()) {
            if (entity is not Mob mob) {
                continue;
            }

            // Read the first one and match the rest to it, so the toggle stays in step rather than
            // flipping each mob independently.
            frozen ??= !mob.NoAi;
            mob.NoAi = frozen.Value;
            count++;
        }

        Tell(player, frozen == true
            ? $"&eFroze &f{count}&e mobs."
            : $"&eUnfroze &f{count}&e mobs.");
    }

    private static void Clear(World world, Player player) {
        int count = 0;

        foreach (Entity entity in world.Entities.GetEntities()) {
            if (entity is not Mob) {
                continue;
            }

            entity.Despawn();
            count++;
        }

        Tell(player, $"&eRemoved &f{count}&e mobs.");
    }
}
