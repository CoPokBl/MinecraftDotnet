namespace ClientLib.World;

/// <summary>
/// The block states of one 16x16x16 section, indexed <c>y &lt;&lt; 8 | z &lt;&lt; 4 | x</c>, which is
/// the order the wire and the protocol library's flat arrays use.
/// <p/>
/// Held as one of three forms, cheapest first: a single state, a byte index into a palette of up to
/// 256 states, or the states themselves. Every block state id in the game fits a ushort.
/// </summary>
public sealed class ClientSection {
    public const int Volume = 4096;

    private ushort _uniform;
    private byte[]? _indices;
    private ushort[]? _palette;
    private int _paletteSize;
    private ushort[]? _direct;

    /// <summary>Positions holding something other than air. Lets the renderer skip a section outright.</summary>
    public int NonAirCount { get; private set; }

    public ClientSection(ushort uniform, bool uniformIsAir) {
        _uniform = uniform;
        NonAirCount = uniformIsAir ? 0 : Volume;
    }

    public ClientSection(ReadOnlySpan<uint> states, Func<uint, bool> isAir) {
        uint first = states[0];
        bool uniform = true;
        for (int i = 1; i < Volume; i++) {
            if (states[i] != first) {
                uniform = false;
                break;
            }
        }

        if (uniform) {
            _uniform = (ushort)first;
            NonAirCount = isAir(first) ? 0 : Volume;
            return;
        }

        _indices = new byte[Volume];
        _palette = new ushort[16];
        uint lastState = uint.MaxValue;
        int lastIndex = 0;
        for (int i = 0; i < Volume; i++) {
            uint state = states[i];
            if (state != lastState) {
                lastState = state;
                lastIndex = IndexOf((ushort)state);
                if (lastIndex < 0) {
                    ToDirect();
                    FillDirect(states, i);
                    break;
                }
            }
            _indices[i] = (byte)lastIndex;
        }

        // Counted separately so the direct fallback above does not need to keep a tally.
        for (int i = 0; i < Volume; i++) {
            if (!isAir(states[i])) {
                NonAirCount++;
            }
        }
    }

    public bool IsUniform => _indices == null && _direct == null;

    /// <summary>
    /// Set while a snapshot holds this section's block array: the next change copies the array first,
    /// so a snapshot costs nothing unless the section changes while it is read.
    /// </summary>
    private bool _shared;

    /// <summary>The section in the form the light engine reads, safe to hand to another thread.</summary>
    public Minecraft.Lighting.LightSection CopyForLight() {
        if (_direct != null) {
            _shared = true;
            return new Minecraft.Lighting.LightSection(0, null, 0, null, _direct);
        }
        if (_indices != null) {
            _shared = true;
            return new Minecraft.Lighting.LightSection(0, _palette![.._paletteSize], _paletteSize, _indices, null);
        }
        return new Minecraft.Lighting.LightSection(_uniform, null, 0, null, null);
    }

    public ushort Get(int index) {
        if (_direct != null) {
            return _direct[index];
        }
        if (_indices != null) {
            return _palette![_indices[index]];
        }
        return _uniform;
    }

    public ushort Get(int x, int y, int z) => Get(y << 8 | z << 4 | x);

    /// <returns>The state that was there.</returns>
    public ushort Set(int index, ushort state, bool wasAir, bool isAir) {
        ushort old = Get(index);
        if (old == state) {
            return old;
        }

        if (!wasAir) {
            NonAirCount--;
        }
        if (!isAir) {
            NonAirCount++;
        }

        if (_shared) {
            _shared = false;
            _direct = (ushort[]?)_direct?.Clone();
            _indices = (byte[]?)_indices?.Clone();
        }

        if (_direct != null) {
            _direct[index] = state;
            return old;
        }

        if (_indices == null) {
            _indices = new byte[Volume];
            _palette = new ushort[16];
            _palette[0] = _uniform;
            _paletteSize = 1;
        }

        int paletteIndex = IndexOf(state);
        if (paletteIndex < 0) {
            ToDirect();
            _direct![index] = state;
            return old;
        }
        _indices[index] = (byte)paletteIndex;
        return old;
    }

    private int IndexOf(ushort state) {
        ushort[] palette = _palette!;
        for (int i = 0; i < _paletteSize; i++) {
            if (palette[i] == state) {
                return i;
            }
        }
        if (_paletteSize == 256) {
            return -1;
        }
        if (_paletteSize == palette.Length) {
            Array.Resize(ref _palette, palette.Length * 2);
        }
        _palette![_paletteSize] = state;
        return _paletteSize++;
    }

    private void ToDirect() {
        ushort[] direct = new ushort[Volume];
        if (_indices != null) {
            for (int i = 0; i < Volume; i++) {
                direct[i] = _palette![_indices[i]];
            }
        }
        else {
            Array.Fill(direct, _uniform);
        }
        _direct = direct;
        _indices = null;
        _palette = null;
        _paletteSize = 0;
    }

    private void FillDirect(ReadOnlySpan<uint> states, int from) {
        for (int i = from; i < Volume; i++) {
            _direct![i] = (ushort)states[i];
        }
    }
}
