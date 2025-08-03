using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Data.Components.Types;

// TODO: Make this actually work without kicking the client
public record EquippableComponent(int ProtocolId) : IDataComponent<EquippableComponent.Data> {
    public override Identifier Identifier => "minecraft:equippable";
    
    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt((int)val.Slot)
            .WriteIdOr(val.EquipSound, (sound, w) => w.Write(sound, registry))
            .WritePrefixedOptional(val.Model, (id, w) => w.Write(id, registry))
            .WritePrefixedOptional(val.CameraOverlay, (id, w) => w.Write(id, registry))
            .WritePrefixedOptional(val.AllowedEntities, (set, w) => w.Write(set, registry))
            .WriteBoolean(val.Dispensable)
            .WriteBoolean(val.Swappable)
            .WriteBoolean(val.DamageOnHurt)
            .WriteBoolean(val.EquipOnInteract)
            .WriteBoolean(val.CanBeSheared)
            .WriteIdOr(val.ShearSound, (sound, w) => w.Write(sound, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        Slot slot = (Slot)reader.ReadVarInt();
        Or<ISoundType, SoundEvent> equipSound = reader.ReadIdOr(
            id => registry.SoundTypes[id],
            r => r.Read<SoundEvent>(registry)
        );
        Identifier? model = reader.ReadPrefixedOptional(r => r.Read<Identifier>(registry));
        Identifier? cameraOverlay = reader.ReadPrefixedOptional(r => r.Read<Identifier>(registry));
        IdSet? allowedEntities = reader.ReadPrefixedOptional(r => r.Read<IdSet>(registry));
        bool dispensable = reader.ReadBoolean();
        bool swappable = reader.ReadBoolean();
        bool damageOnHurt = reader.ReadBoolean();
        bool equipOnInteract = reader.ReadBoolean();
        bool canBeSheared = reader.ReadBoolean();
        Or<ISoundType, SoundEvent> shearSound = reader.ReadIdOr(
            id => registry.SoundTypes[id],
            r => r.Read<SoundEvent>(registry)
        );

        return new Data(slot, equipSound, model, cameraOverlay, allowedEntities, dispensable, swappable, damageOnHurt, 
            equipOnInteract, canBeSheared, shearSound);
    }

    public record Data(Slot Slot, Or<ISoundType, SoundEvent> EquipSound, Identifier? Model, Identifier? CameraOverlay, 
        IdSet? AllowedEntities, bool Dispensable, bool Swappable, bool DamageOnHurt, bool EquipOnInteract, 
        bool CanBeSheared, Or<ISoundType, SoundEvent> ShearSound);
    
    public enum Slot {
        MainHand = 0,
        Feet = 1,
        Legs = 2,
        Chest = 3,
        Head = 4,
        OffHand = 5,
        Body = 6,
        Saddle = 7 // TODO: Check if this is correct? It's not in the protocol but it is in a default component
    }
}
