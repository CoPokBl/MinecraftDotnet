using ManagedServer.Ai.Goals.Impl;
using ManagedServer.Ai.Goals.Target;
using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Ai.Vanilla;

/// <summary>
/// Which goals each vanilla entity type gets, the table vanilla keeps as a <c>registerGoals</c>
/// override on every mob class. <c>VanillaMobAiFeature</c> applies it when a mob spawns.
/// <p/>
/// A game implementation mutates its own copy rather than this one: take
/// <see cref="MobAiRegistry.Vanilla"/>, <see cref="Copy"/> it, change the entries it cares about and
/// hand it to the feature. Overriding one mob does not mean forking the table.
/// <p/>
/// <b>This table is incomplete and knows it.</b> Vanilla has around sixty goal driven mobs and eighty
/// two goal classes; the goal library is built in a later phase, and until then only the mobs whose
/// behaviour can be written out of the goals that exist are listed. Every entry below states what it
/// leaves out, so a mob that behaves nearly right is distinguishable from one that behaves right.
/// A type with no entry gets no goals at all and stands still, which is the honest result rather than
/// a guess.
/// </summary>
public class MobAiRegistry {
    private readonly Dictionary<Identifier, Action<Mob>> _definitions = [];

    public MobAiRegistry() { }

    private MobAiRegistry(Dictionary<Identifier, Action<Mob>> definitions) {
        _definitions = new Dictionary<Identifier, Action<Mob>>(definitions);
    }

    public MobAiRegistry Copy() {
        return new MobAiRegistry(_definitions);
    }

    /// <summary>Replaces whatever was registered for the type, so a game can override one mob.</summary>
    public MobAiRegistry Set(Identifier entityType, Action<Mob> registerGoals) {
        _definitions[entityType] = registerGoals;
        return this;
    }

    public MobAiRegistry Remove(Identifier entityType) {
        _definitions.Remove(entityType);
        return this;
    }

    public Action<Mob>? Get(Identifier entityType) {
        return _definitions.GetValueOrDefault(entityType);
    }

    /// <summary>Puts the goals for a type onto a mob, doing nothing for a type with no entry.</summary>
    public bool Apply(Mob mob) {
        if (!_definitions.TryGetValue(mob.Type.Identifier, out Action<Mob>? register)) {
            return false;
        }

        register(mob);
        return true;
    }

    /// <summary>
    /// Vanilla's behaviour, as far as the goal library goes. A fresh instance every call, so a game
    /// mutating what it gets cannot affect anybody else.
    /// </summary>
    public static MobAiRegistry Vanilla {
        get {
            MobAiRegistry registry = new();

            foreach (Identifier type in ZombieLike) {
                registry.Set(type, Zombie);
            }

            foreach (Identifier type in FarmAnimals) {
                registry.Set(type, FarmAnimal);
            }

            return registry;
        }
    }

    /// <summary>
    /// The types whose vanilla <c>registerGoals</c> is <c>Zombie</c>'s. A husk and a drowned add their
    /// own goals on top (a drowned swims and uses a trident); those are not here.
    /// </summary>
    private static readonly Identifier[] ZombieLike = [
        EntityType.Zombie.Identifier,
        EntityType.Husk.Identifier,
        EntityType.ZombieVillager.Identifier
    ];

    /// <summary>
    /// <c>Zombie.registerGoals</c> plus <c>addBehaviourGoals</c>, minus what does not exist yet.
    /// <p/>
    /// Left out, with vanilla's priority: <c>ZombieAttackTurtleEggGoal</c> (4) and
    /// <c>MoveThroughVillageGoal</c> (6), both of which need the pathfinder; <c>SpearUseGoal</c> (2),
    /// which needs item use; and the three target goals for villagers, iron golems and turtles, which
    /// need entity families rather than the type predicates available now. The stroll is vanilla's
    /// <c>WaterAvoidingRandomStrollGoal</c> without the water avoidance, since that needs
    /// <c>LandRandomPos</c> and so the node evaluator.
    /// <p/>
    /// What is left is what a zombie mostly does: chase a player, hit them, fight back, and wander.
    /// </summary>
    private static void Zombie(Mob mob) {
        mob.Goals.AddGoal(3, new ZombieAttackGoal(mob, 1.0, false));
        mob.Goals.AddGoal(7, new RandomStrollGoal(mob, 1.0));
        mob.Goals.AddGoal(8, new LookAtPlayerGoal(mob, 8.0f));
        mob.Goals.AddGoal(8, new RandomLookAroundGoal(mob));

        mob.TargetGoals.AddGoal(1, new HurtByTargetGoal(mob).SetAlertOthers());
        mob.TargetGoals.AddGoal(2, new NearestAttackableTargetGoal(mob));
    }

    /// <summary>
    /// The animals whose vanilla goal list is <c>AbstractCow</c>'s shape: float, panic, breed, be
    /// tempted, follow a parent, stroll, look.
    /// </summary>
    private static readonly Identifier[] FarmAnimals = [
        EntityType.Cow.Identifier,
        EntityType.Pig.Identifier,
        EntityType.Sheep.Identifier,
        EntityType.Chicken.Identifier
    ];

    /// <summary>
    /// The tail of <c>AbstractCow.registerGoals</c>, which is the part of every farm animal's list
    /// that exists yet.
    /// <p/>
    /// Left out, with vanilla's priority: <c>FloatGoal</c> (0), <c>PanicGoal</c> (1),
    /// <c>BreedGoal</c> (2), <c>TemptGoal</c> (3) and <c>FollowParentGoal</c> (4). Panic is the one
    /// that shows: an animal you hit stands there instead of bolting. The priorities of what is here
    /// are vanilla's, so adding the missing goals later needs no renumbering.
    /// </summary>
    private static void FarmAnimal(Mob mob) {
        mob.Goals.AddGoal(5, new RandomStrollGoal(mob, 1.0));
        mob.Goals.AddGoal(6, new LookAtPlayerGoal(mob, 6.0f));
        mob.Goals.AddGoal(7, new RandomLookAroundGoal(mob));
    }
}
