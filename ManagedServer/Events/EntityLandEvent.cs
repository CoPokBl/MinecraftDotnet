using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

/// <summary>
/// Called when an entity lands after a fall, which is vanilla's <c>Block.fallOn</c> and where fall
/// damage comes from. The entity's <see cref="Entity.FallDistance"/> is cleared straight afterwards.
/// </summary>
[BuiltinEvent]
public class EntityLandEvent : IEntityEvent {
    /// <summary>
    /// The entity that landed.
    /// </summary>
    public required Entity Entity { get; init; }

    /// <summary>
    /// How far the entity fell, in blocks. Always greater than zero: a landing that ends no fall is
    /// not reported.
    /// </summary>
    public required double FallDistance { get; init; }

    /// <summary>
    /// The block the landing is judged against, vanilla's <c>Entity.getOnPosLegacy</c>. It is not
    /// always the block under the entity's centre, since an entity standing on the edge of one lands
    /// on that block rather than on whatever its middle happens to be over.
    /// </summary>
    public required Vec3<int> LandedOn { get; init; }

    public required World World { get; init; }
}
