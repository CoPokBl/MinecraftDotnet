namespace GraphicalClient.Assets;

/// <summary><c>MapColor</c>: the colour each id shows on a map.</summary>
public static class MapColors {
    /// <summary>The base colours by id, RGB; id 0 is <c>NONE</c>, which a map leaves clear.</summary>
    public static readonly uint[] Base = [
        0x000000, 0x7FB238, 0xF7E9A3, 0xC7C7C7, 0xFF0000, 0xA0A0FF, 0xA7A7A7, 0x007C00,
        0xFFFFFF, 0xA4A8B8, 0x976D4D, 0x707070, 0x4040FF, 0x8F7748, 0xFFFCF5, 0xD87F33,
        0xB24CD8, 0x6699D8, 0xE5E533, 0x7FCC19, 0xF27FA5, 0x4C4C4C, 0x999999, 0x4C7F99,
        0x7F3FB2, 0x334CB2, 0x664C33, 0x667F33, 0x993333, 0x191919, 0xFAEE4D, 0x5CDBD5,
        0x4A80FF, 0x00D93A, 0x815631, 0x700200, 0xD1B1A1, 0x9F5224, 0x95576C, 0x706C8A,
        0xBA8524, 0x677535, 0xA04D4E, 0x392923, 0x876B62, 0x575C5C, 0x7A4958, 0x4C3E5C,
        0x4C3223, 0x4C522A, 0x8E3C2E, 0x251610, 0xBD3031, 0x943F61, 0x5C191D, 0x167E86,
        0x3A8E8C, 0x562C3E, 0x14B485, 0x646464, 0xD8AF93, 0x7FA796
    ];

    /// <summary><c>Brightness</c>'s modifiers, by the low two bits of a packed id.</summary>
    private static readonly int[] Brightness = [180, 220, 255, 135];

    /// <summary><c>getColorFromPackedId</c>, ARGB: clear for <c>NONE</c> and for an id past the table.</summary>
    public static uint FromPackedId(byte packedId) {
        int id = packedId >> 2;
        if (id <= 0 || id >= Base.Length) {
            return 0;
        }
        uint colour = Base[id];
        int modifier = Brightness[packedId & 3];
        uint Scale(int shift) => (uint)((colour >> shift & 0xFF) * modifier / 255);
        return 0xFF000000 | Scale(16) << 16 | Scale(8) << 8 | Scale(0);
    }
}
