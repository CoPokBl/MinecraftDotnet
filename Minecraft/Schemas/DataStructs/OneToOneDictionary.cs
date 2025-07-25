namespace Minecraft.Schemas.DataStructs;

public class OneToOneDictionary<T1, T2> where T2 : notnull where T1 : notnull {
    private readonly Dictionary<T1, T2> _forward = new();
    private readonly Dictionary<T2, T1> _backward = new();
    
    public int Count => _forward.Count;
    
    public void Add(T1 key, T2 value) {
        if (_forward.ContainsKey(key) || _backward.ContainsKey(value)) {
            throw new ArgumentException("Key or value already exists in the dictionary.");
        }
        _forward[key] = value;
        _backward[value] = key;
    }
    
    public void Add(T2 key, T1 value) {
        if (_backward.ContainsKey(key) || _forward.ContainsKey(value)) {
            throw new ArgumentException("Key or value already exists in the dictionary.");
        }
        _backward[key] = value;
        _forward[value] = key;
    }

    public void Add(KeyValuePair<T1, T2> item) {
        Add(item.Key, item.Value);
    }

    public void Add(KeyValuePair<T2, T1> item) {
        Add(item.Key, item.Value);
    }

    public bool TryGetValue(T1 key, out T2? value) {
        return _forward.TryGetValue(key, out value);
    }
    
    public bool TryGetValue(T2 value, out T1? key) {
        return _backward.TryGetValue(value, out key);
    }
    
    public T2 this[T1 key] {
        get => _forward[key];
        set {
            if (_forward.ContainsKey(key) || _backward.ContainsKey(value)) {
                throw new ArgumentException("Key or value already exists in the dictionary.");
            }
            _forward[key] = value;
            _backward[value] = key;
        }
    }
    
    public T1 this[T2 key] {
        get => _backward[key];
        set {
            if (_backward.ContainsKey(key) || _forward.ContainsKey(value)) {
                throw new ArgumentException("Key or value already exists in the dictionary.");
            }
            _backward[key] = value;
            _forward[value] = key;
        }
    }
    
    public bool ContainsKey(T1 key) {
        return _forward.ContainsKey(key);
    }
    
    public bool ContainsKey(T2 value) {
        return _backward.ContainsKey(value);
    }
    
    public bool Remove(T1 key) {
        if (_forward.Remove(key, out T2? value)) {
            _backward.Remove(value);
            return true;
        }
        return false;
    }
    
    public bool Remove(T2 value) {
        if (_backward.Remove(value, out T1? key)) {
            _forward.Remove(key);
            return true;
        }
        return false;
    }
    
    public void Clear() {
        _forward.Clear();
        _backward.Clear();
    }
    
    public ICollection<T1> Keys => _forward.Keys;
    public ICollection<T2> Values => _forward.Values;
}
