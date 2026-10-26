using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// The client's own copy of a synced value it also writes, as a vehicle's hurt time or a primed TNT's
/// fuse counted down by the client's <c>tick()</c>: each value the server sends replaces the copy, even
/// one equal to the last, since every packet stores a fresh field.
/// </summary>
public sealed class LocalEntityData<T> {
    private readonly EntityDataField<T> _field;
    private MetaField? _seen;

    public T Value;

    /// <summary>Whether the last <see cref="Sync"/> took a value from a new packet, as <c>onSyncedDataUpdated</c> would hear it.</summary>
    public bool Arrived { get; private set; }

    public LocalEntityData(EntityDataField<T> field, T fallback) {
        _field = field;
        Value = fallback;
    }

    /// <summary>Takes the server's value if a new one has arrived since the last call.</summary>
    public T Sync(ClientEntity entity) {
        Arrived = false;
        if (entity.Metadata.TryGetValue(_field.Index, out MetaField? field) && !ReferenceEquals(field, _seen)) {
            _seen = field;
            if (field is MetaField<T> typed) {
                Value = typed.Value;
                Arrived = true;
            }
        }
        return Value;
    }
}
