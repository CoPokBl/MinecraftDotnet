namespace ManagedServer.Pathfinding;

/// <summary>
/// The open set, vanilla's <c>BinaryHeap</c>. A min heap on <see cref="Node.F"/> that can lower a
/// node's cost in place, which is what A* needs when it finds a cheaper way to a node it has
/// already seen.
/// <p/>
/// Each node carries its own <see cref="Node.HeapIndex"/>, so finding it again to reorder it is
/// free rather than a scan. That is also why a node cannot be in two heaps at once, and why
/// <see cref="Insert"/> throws on one that already is: silently accepting it would corrupt the
/// index and lose nodes.
/// </summary>
public class BinaryHeap {
    private Node[] _heap = new Node[128];

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public Node Insert(Node node) {
        if (node.HeapIndex >= 0) {
            throw new InvalidOperationException("Node is already in the open set.");
        }

        if (Count == _heap.Length) {
            Node[] grown = new Node[Count << 1];
            Array.Copy(_heap, grown, Count);
            _heap = grown;
        }

        _heap[Count] = node;
        node.HeapIndex = Count;
        UpHeap(Count++);
        return node;
    }

    public void Clear() {
        // Vanilla only resets the size and leaves the array populated, which keeps stale nodes
        // alive until they are overwritten. Cleared here as well, since holding a whole search's
        // nodes past the end of it is a leak rather than a saving.
        Array.Clear(_heap, 0, Count);
        Count = 0;
    }

    public Node Peek() {
        return _heap[0];
    }

    public Node Pop() {
        Node popped = _heap[0];
        _heap[0] = _heap[--Count];
        _heap[Count] = null!;

        if (Count > 0) {
            DownHeap(0);
        }

        popped.HeapIndex = -1;
        return popped;
    }

    public void Remove(Node node) {
        int index = node.HeapIndex;
        _heap[index] = _heap[--Count];
        _heap[Count] = null!;

        if (Count > index) {
            if (_heap[index].F < node.F) {
                UpHeap(index);
            }
            else {
                DownHeap(index);
            }
        }

        node.HeapIndex = -1;
    }

    public void ChangeCost(Node node, float newCost) {
        float oldCost = node.F;
        node.F = newCost;

        if (newCost < oldCost) {
            UpHeap(node.HeapIndex);
        }
        else {
            DownHeap(node.HeapIndex);
        }
    }

    /// <summary>Everything in the heap, in heap order. For debugging and tests only.</summary>
    public Node[] ToArray() {
        return _heap[..Count];
    }

    private void UpHeap(int index) {
        Node node = _heap[index];
        float cost = node.F;

        while (index > 0) {
            int parentIndex = (index - 1) >> 1;
            Node parent = _heap[parentIndex];

            if (!(cost < parent.F)) {
                break;
            }

            _heap[index] = parent;
            parent.HeapIndex = index;
            index = parentIndex;
        }

        _heap[index] = node;
        node.HeapIndex = index;
    }

    private void DownHeap(int index) {
        Node node = _heap[index];
        float cost = node.F;

        while (true) {
            int leftIndex = 1 + (index << 1);
            int rightIndex = leftIndex + 1;

            if (leftIndex >= Count) {
                break;
            }

            Node left = _heap[leftIndex];
            float leftCost = left.F;

            Node? right;
            float rightCost;
            if (rightIndex >= Count) {
                right = null;
                rightCost = float.PositiveInfinity;
            }
            else {
                right = _heap[rightIndex];
                rightCost = right.F;
            }

            if (leftCost < rightCost) {
                if (!(leftCost < cost)) {
                    break;
                }

                _heap[index] = left;
                left.HeapIndex = index;
                index = leftIndex;
            }
            else {
                if (!(rightCost < cost)) {
                    break;
                }

                _heap[index] = right!;
                right!.HeapIndex = index;
                index = rightIndex;
            }
        }

        _heap[index] = node;
        node.HeapIndex = index;
    }
}
