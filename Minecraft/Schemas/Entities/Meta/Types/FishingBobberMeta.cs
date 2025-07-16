namespace Minecraft.Schemas.Entities.Meta.Types;

public record FishingBobberMeta(Optional<int>? HookedEntityId = null, bool? IsCatchable = null) : EntityMeta {

    public override EntityMeta LoadFields(EntityMetaContainer container) {
        Optional<int>? hookedEntityId = container.GetValue<Optional<int>>(8);
        return (FishingBobberMeta)base.LoadFields(container) with {
            HookedEntityId = hookedEntityId == null ? null : hookedEntityId.Present ? hookedEntityId.Value - 1 : Optional<int>.Empty,
            IsCatchable = container.GetValue<bool>(9)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.VarInt, HookedEntityId == null ? null : (int?)(HookedEntityId.Present
                ? HookedEntityId.Value + 1
                : 0))
            .WithField(9, MetaFieldType.Boolean, IsCatchable);
    }
}
