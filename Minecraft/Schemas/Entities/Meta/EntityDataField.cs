namespace Minecraft.Schemas.Entities.Meta;

/// <summary>
/// One entity data slot: the index it travels at and the type its serializer decodes to. The vanilla
/// set is generated as <c>Minecraft.Data.Generated.EntityDataFields</c>.
/// </summary>
public readonly record struct EntityDataField<T>(int Index);
