namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// What a note block above a block plays. Doubles as the note block's own instrument property,
/// which takes the same values.
/// </summary>
public enum NoteBlockInstrument {
    Harp,
    Basedrum,
    Snare,
    Hat,
    Bass,
    Flute,
    Bell,
    Guitar,
    Chime,
    Xylophone,
    IronXylophone,
    CowBell,
    Didgeridoo,
    Bit,
    Banjo,
    Pling,
    Trumpet,
    TrumpetExposed,
    TrumpetOxidized,
    TrumpetWeathered,
    Zombie,
    Skeleton,
    Creeper,
    Dragon,
    WitherSkeleton,
    Piglin,
    CustomHead
}

public static class NoteBlockInstrumentExtensions {
    /// <summary>
    /// <c>NoteBlockInstrument.worksAboveNoteBlock()</c>: whether a note block sitting on this one
    /// takes its instrument from it. True for everything that is not a <c>BASE_BLOCK</c> instrument,
    /// which is the six mob heads and the custom head, so the test is a range rather than a list.
    /// </summary>
    public static bool WorksAboveNoteBlock(this NoteBlockInstrument instrument) {
        return instrument >= NoteBlockInstrument.Zombie;
    }

    public static NoteBlockInstrument FromString(string value) {
        return value switch {
            "harp" => NoteBlockInstrument.Harp,
            "basedrum" => NoteBlockInstrument.Basedrum,
            "snare" => NoteBlockInstrument.Snare,
            "hat" => NoteBlockInstrument.Hat,
            "bass" => NoteBlockInstrument.Bass,
            "flute" => NoteBlockInstrument.Flute,
            "bell" => NoteBlockInstrument.Bell,
            "guitar" => NoteBlockInstrument.Guitar,
            "chime" => NoteBlockInstrument.Chime,
            "xylophone" => NoteBlockInstrument.Xylophone,
            "iron_xylophone" => NoteBlockInstrument.IronXylophone,
            "cow_bell" => NoteBlockInstrument.CowBell,
            "didgeridoo" => NoteBlockInstrument.Didgeridoo,
            "bit" => NoteBlockInstrument.Bit,
            "banjo" => NoteBlockInstrument.Banjo,
            "pling" => NoteBlockInstrument.Pling,
            "trumpet" => NoteBlockInstrument.Trumpet,
            "trumpet_exposed" => NoteBlockInstrument.TrumpetExposed,
            "trumpet_oxidized" => NoteBlockInstrument.TrumpetOxidized,
            "trumpet_weathered" => NoteBlockInstrument.TrumpetWeathered,
            "zombie" => NoteBlockInstrument.Zombie,
            "skeleton" => NoteBlockInstrument.Skeleton,
            "creeper" => NoteBlockInstrument.Creeper,
            "dragon" => NoteBlockInstrument.Dragon,
            "wither_skeleton" => NoteBlockInstrument.WitherSkeleton,
            "piglin" => NoteBlockInstrument.Piglin,
            "custom_head" => NoteBlockInstrument.CustomHead,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for NoteBlockInstrument.")
        };
    }

    public static string ToName(this NoteBlockInstrument instrument) {
        return instrument switch {
            NoteBlockInstrument.Harp => "harp",
            NoteBlockInstrument.Basedrum => "basedrum",
            NoteBlockInstrument.Snare => "snare",
            NoteBlockInstrument.Hat => "hat",
            NoteBlockInstrument.Bass => "bass",
            NoteBlockInstrument.Flute => "flute",
            NoteBlockInstrument.Bell => "bell",
            NoteBlockInstrument.Guitar => "guitar",
            NoteBlockInstrument.Chime => "chime",
            NoteBlockInstrument.Xylophone => "xylophone",
            NoteBlockInstrument.IronXylophone => "iron_xylophone",
            NoteBlockInstrument.CowBell => "cow_bell",
            NoteBlockInstrument.Didgeridoo => "didgeridoo",
            NoteBlockInstrument.Bit => "bit",
            NoteBlockInstrument.Banjo => "banjo",
            NoteBlockInstrument.Pling => "pling",
            NoteBlockInstrument.Trumpet => "trumpet",
            NoteBlockInstrument.TrumpetExposed => "trumpet_exposed",
            NoteBlockInstrument.TrumpetOxidized => "trumpet_oxidized",
            NoteBlockInstrument.TrumpetWeathered => "trumpet_weathered",
            NoteBlockInstrument.Zombie => "zombie",
            NoteBlockInstrument.Skeleton => "skeleton",
            NoteBlockInstrument.Creeper => "creeper",
            NoteBlockInstrument.Dragon => "dragon",
            NoteBlockInstrument.WitherSkeleton => "wither_skeleton",
            NoteBlockInstrument.Piglin => "piglin",
            NoteBlockInstrument.CustomHead => "custom_head",
            _ => throw new ArgumentOutOfRangeException(nameof(instrument), instrument, "Unknown NoteBlockInstrument value.")
        };
    }
}
