using System.Diagnostics;
using System.Text;

namespace ClientLib.Parsing.Packrat;

/// <summary>Vanilla's <c>Scope</c>: a stack of frames, each a run of atom and value pairs.</summary>
public sealed class Scope {
    private const int NotFound = -1;
    private static readonly object FrameStartMarker = new FrameMarker();
    private const int EntryStride = 2;

    private object?[] _stack = new object?[128];
    private int _topEntryKeyIndex;
    private int _topMarkerKeyIndex;

    public Scope() {
        _stack[0] = FrameStartMarker;
        _stack[1] = null;
    }

    private sealed class FrameMarker {
        public override string ToString() => "frame";
    }

    private int ValueIndex(object atom) {
        for (int i = _topEntryKeyIndex; i > _topMarkerKeyIndex; i -= EntryStride) {
            if (ReferenceEquals(_stack[i], atom)) {
                return i + 1;
            }
        }
        return NotFound;
    }

    private int ValueIndexForAny(object[] atoms) {
        for (int i = _topEntryKeyIndex; i > _topMarkerKeyIndex; i -= EntryStride) {
            object? key = _stack[i];
            foreach (object atom in atoms) {
                if (ReferenceEquals(atom, key)) {
                    return i + 1;
                }
            }
        }
        return NotFound;
    }

    private void EnsureCapacity(int additionalEntryCount) {
        int currentSize = _stack.Length;
        int currentLastValueIndex = _topEntryKeyIndex + 1;
        int newLastValueIndex = currentLastValueIndex + additionalEntryCount * EntryStride;
        if (newLastValueIndex >= currentSize) {
            int newSize = Util.GrowByHalf(currentSize, newLastValueIndex + 1);
            Array.Resize(ref _stack, newSize);
        }
        Debug.Assert(ValidateStructure());
    }

    private void SetupNewFrame() {
        _topEntryKeyIndex += EntryStride;
        _stack[_topEntryKeyIndex] = FrameStartMarker;
        _stack[_topEntryKeyIndex + 1] = _topMarkerKeyIndex;
        _topMarkerKeyIndex = _topEntryKeyIndex;
    }

    public void PushFrame() {
        EnsureCapacity(1);
        SetupNewFrame();
    }

    private int GetPreviousMarkerIndex(int markerKeyIndex) => (int)_stack[markerKeyIndex + 1]!;

    public void PopFrame() {
        Debug.Assert(_topMarkerKeyIndex != 0);
        _topEntryKeyIndex = _topMarkerKeyIndex - EntryStride;
        _topMarkerKeyIndex = GetPreviousMarkerIndex(_topMarkerKeyIndex);
    }

    public void SplitFrame() {
        int currentFrameMarkerIndex = _topMarkerKeyIndex;
        int nonMarkerEntriesInFrame = (_topEntryKeyIndex - _topMarkerKeyIndex) / EntryStride;
        EnsureCapacity(nonMarkerEntriesInFrame + 1);
        SetupNewFrame();
        int sourceCursor = currentFrameMarkerIndex + EntryStride;
        int targetCursor = _topEntryKeyIndex;
        for (int i = 0; i < nonMarkerEntriesInFrame; i++) {
            targetCursor += EntryStride;
            object? key = _stack[sourceCursor];
            Debug.Assert(key != null);
            _stack[targetCursor] = key;
            _stack[targetCursor + 1] = null;
            sourceCursor += EntryStride;
        }
        _topEntryKeyIndex = targetCursor;
    }

    public void ClearFrameValues() {
        for (int i = _topEntryKeyIndex; i > _topMarkerKeyIndex; i -= EntryStride) {
            _stack[i + 1] = null;
        }
    }

    public void MergeFrame() {
        int previousMarkerIndex = GetPreviousMarkerIndex(_topMarkerKeyIndex);
        int previousFrameCursor = previousMarkerIndex;
        int currentFrameCursor = _topMarkerKeyIndex;
        while (currentFrameCursor < _topEntryKeyIndex) {
            previousFrameCursor += EntryStride;
            currentFrameCursor += EntryStride;
            object? newKey = _stack[currentFrameCursor];
            object? newValue = _stack[currentFrameCursor + 1];
            object? oldKey = _stack[previousFrameCursor];
            if (!ReferenceEquals(oldKey, newKey)) {
                _stack[previousFrameCursor] = newKey;
                _stack[previousFrameCursor + 1] = newValue;
            }
            else if (newValue != null) {
                _stack[previousFrameCursor + 1] = newValue;
            }
        }
        _topEntryKeyIndex = previousFrameCursor;
        _topMarkerKeyIndex = previousMarkerIndex;
    }

    public void Put<T>(Atom<T> name, T? value) {
        int valueIndex = ValueIndex(name);
        if (valueIndex != NotFound) {
            _stack[valueIndex] = value;
        }
        else {
            EnsureCapacity(1);
            _topEntryKeyIndex += EntryStride;
            _stack[_topEntryKeyIndex] = name;
            _stack[_topEntryKeyIndex + 1] = value;
        }
    }

    public T? Get<T>(Atom<T> name) {
        int valueIndex = ValueIndex(name);
        return valueIndex != NotFound ? (T?)_stack[valueIndex] : default;
    }

    public T GetOrThrow<T>(Atom<T> name) {
        int valueIndex = ValueIndex(name);
        if (valueIndex == NotFound) {
            throw new ArgumentException("No value for atom " + name);
        }
        return (T)_stack[valueIndex]!;
    }

    public T GetOrDefault<T>(Atom<T> name, T fallback) {
        int valueIndex = ValueIndex(name);
        return valueIndex != NotFound ? (T)_stack[valueIndex]! : fallback;
    }

    public T? GetAny<T>(params Atom<T>[] names) {
        int valueIndex = ValueIndexForAny(names);
        return valueIndex != NotFound ? (T?)_stack[valueIndex] : default;
    }

    public T GetAnyOrThrow<T>(params Atom<T>[] names) {
        int valueIndex = ValueIndexForAny(names);
        if (valueIndex == NotFound) {
            throw new ArgumentException("No value for atoms " + string.Join(", ", names.Select(n => n.ToString())));
        }
        return (T)_stack[valueIndex]!;
    }

    public override string ToString() {
        StringBuilder result = new();
        bool afterFrame = true;
        for (int i = 0; i <= _topEntryKeyIndex; i += EntryStride) {
            object? key = _stack[i];
            object? value = _stack[i + 1];
            if (ReferenceEquals(key, FrameStartMarker)) {
                result.Append('|');
                afterFrame = true;
            }
            else {
                if (!afterFrame) {
                    result.Append(',');
                }
                afterFrame = false;
                result.Append(key).Append(':').Append(value);
            }
        }
        return result.ToString();
    }

    public bool HasOnlySingleFrame() {
        for (int i = _topEntryKeyIndex; i > 0; i--) {
            if (ReferenceEquals(_stack[i], FrameStartMarker)) {
                return false;
            }
        }
        if (!ReferenceEquals(_stack[0], FrameStartMarker)) {
            throw new InvalidOperationException("Corrupted stack");
        }
        return true;
    }

    private bool ValidateStructure() {
        if (_topMarkerKeyIndex < 0 || _topEntryKeyIndex < _topMarkerKeyIndex) {
            return false;
        }
        for (int marker = _topMarkerKeyIndex; marker != 0; marker = GetPreviousMarkerIndex(marker)) {
            if (!ReferenceEquals(_stack[marker], FrameStartMarker)) {
                return false;
            }
        }
        return true;
    }
}
