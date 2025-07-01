namespace Minecraft.Schemas;

public class OneToOneDictionary<T1, T2> where T2 : notnull where T1 : notnull {
    private Dictionary<T1, T2> _forward = new();
    private Dictionary<T2, T1> _backward = new();
    
    public int Count => _forward.Count;
    
    public void Add(T1 key, T2 value) {
        if (_forward.ContainsKey(key) || _backward.ContainsKey(value)) {
            throw new ArgumentException("Key or value already exists in the dictionary.");
        }
        _forward[key] = value;
        _backward[value] = key;
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
    
    public void Remove(T1 key) {
        if (_forward.Remove(key, out T2? value)) {
            _backward.Remove(value);
        }
    }
    
    public void Remove(T2 value) {
        if (_backward.Remove(value, out T1? key)) {
            _forward.Remove(key);
        }
    }
    
    public void Clear() {
        _forward.Clear();
        _backward.Clear();
    }
    
    public IEnumerable<T1> Keys => _forward.Keys;
    public IEnumerable<T2> Values => _forward.Values;
}
