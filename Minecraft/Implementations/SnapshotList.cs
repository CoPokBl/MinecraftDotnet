using System.Collections;

namespace Minecraft.Implementations;

/// <summary>
/// A small copy on write collection for sets that are read constantly and written rarely: the
/// players on a server, the open connections, and anything else the tick loop walks every tick while
/// the network threads add to and remove from it.
/// <p/>
/// Readers take the current array and iterate it with no lock and no allocation, and are unaffected
/// by a write that lands mid-iteration. Writers replace the array wholesale under a lock. That is
/// the right trade here because joins and disconnects are rare next to the number of times a tick
/// walks the list, and because the alternative on offer, a bare <see cref="List{T}"/> touched from
/// several threads, fails by corrupting itself rather than by throwing.
/// </summary>
public sealed class SnapshotList<T> : IReadOnlyList<T> where T : class {
    private readonly object _lock = new();
    private T[] _items = [];

    /// <summary>
    /// The current contents. Stable for as long as the caller holds it, so it is the right thing to
    /// capture once and iterate, and it must not be written to.
    /// </summary>
    public T[] Snapshot => Volatile.Read(ref _items);

    public int Count => Snapshot.Length;

    public T this[int index] => Snapshot[index];

    /// <summary>Adds the item unless it is already present. True if the collection changed.</summary>
    public bool Add(T item) {
        lock (_lock) {
            T[] current = _items;
            if (Array.IndexOf(current, item) >= 0) {
                return false;
            }

            T[] updated = new T[current.Length + 1];
            Array.Copy(current, updated, current.Length);
            updated[current.Length] = item;
            Volatile.Write(ref _items, updated);
            return true;
        }
    }

    /// <summary>Removes the item if present. True if the collection changed.</summary>
    public bool Remove(T item) {
        lock (_lock) {
            T[] current = _items;
            int index = Array.IndexOf(current, item);
            if (index < 0) {
                return false;
            }

            T[] updated = new T[current.Length - 1];
            Array.Copy(current, updated, index);
            Array.Copy(current, index + 1, updated, index, current.Length - index - 1);
            Volatile.Write(ref _items, updated);
            return true;
        }
    }

    public bool Contains(T item) => Array.IndexOf(Snapshot, item) >= 0;

    public void Clear() {
        lock (_lock) {
            Volatile.Write(ref _items, Array.Empty<T>());
        }
    }

    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Snapshot).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
