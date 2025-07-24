using System.Collections;

namespace Minecraft.Schemas;

/// <summary>
/// A list that allows for copy-on-write semantics.
/// <p/>
/// When an item is added, removed, or modified, a new array is created to hold the items.
/// This means that the list can be safely shared across multiple threads without needing locks,
/// and you can safely iterate over the list while modifications are being made.
/// </summary>
/// <typeparam name="T">The type encapsulated by the list.</typeparam>
public class CopyOnWriteList<T> : IList<T> {
    private T[] _items = [];
    
    public int Count => _items.Length;
    public bool IsReadOnly => false;

    public IEnumerator<T> GetEnumerator() {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Add(T item) {
        T[] newItems = new T[_items.Length + 1];
        Array.Copy(_items, newItems, _items.Length);
        newItems[^1] = item;
        _items = newItems;
    }

    public void Clear() {
        _items = [];
    }

    public bool Contains(T item) {
        return _items.Any(existingItem => EqualityComparer<T>.Default.Equals(existingItem, item));
    }

    public void CopyTo(T[] array, int arrayIndex) {
        if (array == null) {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0) {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Array index cannot be negative.");
        }
        if (array.Length - arrayIndex < _items.Length) {
            throw new ArgumentException("The destination array is not large enough to hold the items.");
        }
        
        Array.Copy(_items, 0, array, arrayIndex, _items.Length);
    }

    public bool Remove(T item) {
        int index = IndexOf(item);
        if (index < 0) {
            return false; // Item not found
        }
        
        RemoveAt(index);
        return true; // Item removed successfully
    }

    public int IndexOf(T item) {
        for (int i = 0; i < _items.Length; i++) {
            if (EqualityComparer<T>.Default.Equals(_items[i], item)) {
                return i;
            }
        }
        return -1;
    }

    public void Insert(int index, T item) {
        T[] newItems = new T[_items.Length + 1];
        Array.Copy(_items, newItems, index);
        newItems[index] = item;
        Array.Copy(_items, index, newItems, index + 1, _items.Length - index);
    }

    public void RemoveAt(int index) {
        T[] newItems = new T[_items.Length - 1];
        Array.Copy(_items, newItems, index);
        Array.Copy(_items, index + 1, newItems, index, _items.Length - index - 1);
        _items = newItems;
    }
    
    /// <summary>
    /// Removes all items that match the specified predicate.
    /// </summary>
    /// <param name="match">The predicate, which should return true to remove the element.</param>
    /// <exception cref="ArgumentNullException">If match is null.</exception>
    public void RemoveAll(Predicate<T> match) {
        if (match == null) {
            throw new ArgumentNullException(nameof(match));
        }
        
        T[] newItems = _items.Where(item => !match(item)).ToArray();
        _items = newItems;
    }

    public T this[int index] {
        get => _items[index];
        set {
            T[] newItems = new T[_items.Length];
            Array.Copy(_items, newItems, _items.Length);
            newItems[index] = value;
            _items = newItems;
        }
    }
}
