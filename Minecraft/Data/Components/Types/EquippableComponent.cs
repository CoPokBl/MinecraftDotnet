using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

// TODO: Make this actually work without kicking the client
public record EquippableComponent() : IDataComponent<EquippableComponent.Data> {
    public override Identifier Identifier => "minecraft:equippable";

    /// <summary>
    /// <b>The slot names are not the member names in snake case.</b> Vanilla writes <c>mainhand</c>
    /// and <c>offhand</c> with no separator while the rest are plain words, so the pair is spelled
    /// out rather than derived.
    /// </summary>
    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .String("slot", SlotNames[val.Slot])
            .Sound("equip_sound", val.EquipSound)
            .Id("asset_id", val.Model)
            .Id("camera_overlay", val.CameraOverlay)
            .IdSet("allowed_entities", val.AllowedEntities, registry.EntityTypes)
            .Bool("dispensable", val.Dispensable, true)
            .Bool("swappable", val.Swappable, true)
            .Bool("damage_on_hurt", val.DamageOnHurt, true)
            .Bool("equip_on_interact", val.EquipOnInteract, false)
            .Bool("can_be_sheared", val.CanBeSheared, false)
            .Sound("shearing_sound", val.ShearSound)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:equippable");
            string slot = node.String("slot");

            if (!SlotsByName.TryGetValue(slot, out Slot named)) {
                throw new UnportedComponentException("minecraft:equippable",
                    $"\"{slot}\" is not an equipment slot.");
            }

            Data data = new(
                named,
                node.Sound("equip_sound", registry)!,
                node.IdOrNull("asset_id"),
                node.IdOrNull("camera_overlay"),
                node.IdSetOrNull("allowed_entities", registry.EntityTypes),
                node.Bool("dispensable", true),
                node.Bool("swappable", true),
                node.Bool("damage_on_hurt", true),
                node.Bool("equip_on_interact", false),
                node.Bool("can_be_sheared", false),
                node.Sound("shearing_sound", registry)!);

            node.AssertRead();
            return data;
        });

    private static readonly Dictionary<Slot, string> SlotNames = new() {
        [Slot.MainHand] = "mainhand",
        [Slot.OffHand] = "offhand",
        [Slot.Feet] = "feet",
        [Slot.Legs] = "legs",
        [Slot.Chest] = "chest",
        [Slot.Head] = "head",
        [Slot.Body] = "body",
        [Slot.Saddle] = "saddle"
    };

    private static readonly Dictionary<string, Slot> SlotsByName =
        SlotNames.ToDictionary(pair => pair.Value, pair => pair.Key);
    
    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt((int)val.Slot)
            .WriteIdOr(val.EquipSound, registry.SoundTypes.GetProtocolId, (sound, w) => w.Write(sound, registry))
            .WritePrefixedOptional(val.Model, (id, w) => w.Write(id, registry))
            .WritePrefixedOptional(val.CameraOverlay, (id, w) => w.Write(id, registry))
            .WritePrefixedOptional(val.AllowedEntities, (set, w) => w.Write(set, registry))
            .WriteBoolean(val.Dispensable)
            .WriteBoolean(val.Swappable)
            .WriteBoolean(val.DamageOnHurt)
            .WriteBoolean(val.EquipOnInteract)
            .WriteBoolean(val.CanBeSheared)
            .WriteIdOr(val.ShearSound, registry.SoundTypes.GetProtocolId, (sound, w) => w.Write(sound, registry));
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

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
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
