using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;

namespace ManagedServer.Entities.Types;

/// <summary>
/// A dropped stack, vanilla's <c>ItemEntity</c>.
/// <p/>
/// The physics half of <c>ItemEntity.tick</c> already runs in <c>EntityPhysics.TickGeneric</c>, which
/// is taken from that method. What is here is the bookkeeping around it: the fields, and the counters
/// <c>ItemEntityFeature</c> reads. <b>Nothing on this class ticks by itself</b>, on the same rule as
/// <c>FallDistance</c> and <c>Effects</c>: the state is core so a stack is always describable, and
/// what it means is a feature.
/// </summary>
public class ItemEntity : Entity {
    /// <summary><c>ItemEntity.LIFETIME</c>: five minutes.</summary>
    public const int Lifetime = 6000;

    /// <summary><c>ItemEntity.INFINITE_PICKUP_DELAY</c>, which also makes a stack unmergeable.</summary>
    public const int InfinitePickupDelay = 32767;

    /// <summary><c>ItemEntity.INFINITE_LIFETIME</c>, which stops <see cref="Age"/> counting.</summary>
    public const int InfiniteLifetime = -32768;

    /// <summary><c>Entity.setDefaultPickUpDelay</c>, half a second.</summary>
    public const int DefaultPickupDelay = 10;

    public ItemEntity(ItemStack? item = null) : base(EntityType.Item, new ItemMeta(item)) { }

    /// <summary>The stack, which lives in the metadata because that is what the client is sent.</summary>
    public ItemStack? Item {
        get => (Meta as ItemMeta)?.Item;
        set => Meta = (ItemMeta)Meta with { Item = value };
    }

    /// <summary>
    /// Ticks since the drop. Counted by <c>ItemEntityFeature</c> and compared against
    /// <see cref="Lifetime"/>; <see cref="InfiniteLifetime"/> never counts.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Ticks before the stack may be picked up, counted down by <c>ItemEntityFeature</c>.
    /// <p/>
    /// A counter rather than a timestamp because vanilla's is one, and because merging takes the
    /// larger of two delays: comparing wall clock instants makes that mean the wrong thing when the
    /// server falls behind.
    /// </summary>
    public int PickupDelay { get; set; }

    /// <summary>
    /// Who threw it, vanilla's <c>thrower</c>. Only used to keep a player from instantly picking their
    /// own throw back up; a block drop has none.
    /// </summary>
    public Entity? Thrower { get; set; }

    /// <summary>
    /// <c>ItemEntity.isMergable</c>. A full stack is not mergeable, which is what stops sixty four
    /// cobblestone swallowing another sixty four into one entity.
    /// </summary>
    public bool Mergeable => World != null
                             && Item is { } item
                             && !item.IsAir()
                             && PickupDelay != InfinitePickupDelay
                             && Age != InfiniteLifetime
                             && Age < Lifetime
                             && item.Count < item.GetMaxStackSize();
}
