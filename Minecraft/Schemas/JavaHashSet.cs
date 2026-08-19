using System.Collections;

namespace Minecraft.Schemas;

/// <summary>
/// A set that iterates in <c>java.util.HashSet</c>'s order.
/// </summary>
/// <remarks>
/// <b>Vanilla's iteration order over a hash set is load bearing wherever the set decides an order
/// rather than a membership.</b> A tree collects its logs and leaves into <c>Sets.newHashSet()</c>,
/// hands them to the decorators as a list sorted by y alone, and every decorator then draws a fixed
/// number of values per entry. So the draws land on different blocks depending on where the set put
/// them, the count is identical either way, and the difference is invisible until something reads
/// back what was written: a vine one column further out moves the live <c>WORLD_SURFACE</c> heightmap,
/// which is what <c>surface_water_depth_filter</c> compares against, so the next candidate position is
/// dropped instead of grown and every feature after it is somewhere else.
/// <p/>
/// The order is not arbitrary and not a hash seed: it is buckets in index order, each bucket in
/// insertion order, over a table that doubles at three quarters full and splits each bucket in two
/// while preserving order. On top of that, <b>a bucket that reaches nine entries becomes a red-black
/// tree</b>, and treeifying reorders the bucket: the tree's root is moved to the front of the chain
/// the iterator walks, and every later insertion into that bucket can rebalance and move a new root
/// there. A vegetation patch reaches nine within a hundred chunks, so this is ordinary rather than
/// pathological. All of it is reproducible, which is what this does.
/// <p/>
/// The hash is supplied rather than taken from <see cref="object.GetHashCode"/>, because what matters
/// is the <b>Java</b> hash of the value: <c>BlockPos</c>'s is <c>(y + z * 31) * 31 + x</c>, and a
/// C# record's is whatever the runtime chose today.
/// <p/>
/// <b>Two values with the same hash inside a treeified bucket are the one thing here that is not
/// reproducible, and it is vanilla that is not reproducible rather than this.</b> Upstream orders them
/// with <c>tieBreakOrder</c>, which falls to <c>System.identityHashCode</c> whenever the key's own
/// class does not directly declare <c>Comparable</c> for itself. <c>BlockPos</c> is exactly that case:
/// it extends <c>Vec3i</c>, which declares <c>Comparable&lt;Vec3i&gt;</c>, but
/// <c>comparableClassFor</c> reads the key class's <b>own</b> generic interfaces and <c>BlockPos</c>
/// declares none. An identity hash is a per run value, so vanilla itself puts those two in an order
/// that is not a function of the seed. Insertion order is used here instead, which is deterministic
/// and agrees with vanilla whenever vanilla agrees with itself.
/// </remarks>
public sealed class JavaHashSet<T>(Func<T, int> hash) : IEnumerable<T> where T : notnull {
    private const double LoadFactor = 0.75;
    private const int InitialCapacity = 16;

    /// <summary>
    /// <c>TREEIFY_THRESHOLD</c>. The count is of nodes <b>traversed</b> before the new one is linked
    /// on, so the bucket holds nine when it turns into a tree.
    /// </summary>
    private const int TreeifyThreshold = 8;

    /// <summary><c>UNTREEIFY_THRESHOLD</c>: what a half of a split bucket falls back to a chain at.</summary>
    private const int UntreeifyThreshold = 6;

    /// <summary>
    /// <c>MIN_TREEIFY_CAPACITY</c>. Below this the table is widened instead, on the reasoning that a
    /// bucket that long in a narrow table is crowding rather than collision.
    /// </summary>
    private const int MinTreeifyCapacity = 64;

    private sealed class Node(int hash, T value, long sequence) {
        public readonly int Hash = hash;
        public readonly T Value = value;

        /// <summary>Where the value was added, which is what breaks a tie between equal hashes.</summary>
        public readonly long Sequence = sequence;

        /// <summary>The chain the iterator walks. Maintained for a treeified bucket too.</summary>
        public Node? Next;
        public Node? Prev;

        public Node? Parent;
        public Node? Left;
        public Node? Right;
        public bool Red;

        /// <summary><c>e instanceof TreeNode</c>, which upstream is the node's own class.</summary>
        public bool Tree;
    }

    private Node?[] _table = [];
    private int _threshold;
    private long _sequence;

    public int Count { get; private set; }

    /// <summary>Whether the value was not already there, <c>HashSet.add</c>'s answer.</summary>
    public bool Add(T value) {
        if (_table.Length == 0) {
            Resize();
        }

        int spread = Spread(hash(value));
        int index = spread & (_table.Length - 1);
        Node? head = _table[index];

        if (head == null) {
            _table[index] = NewNode(spread, value);
        } else if (head.Hash == spread && EqualityComparer<T>.Default.Equals(head.Value, value)) {
            // Upstream tests the head before it asks whether the bucket is a tree, so a hit on the
            // first node never walks either structure.
            return false;
        } else if (head.Tree) {
            if (PutTreeValue(head, index, spread, value)) {
                return false;
            }
        } else {
            Node node = head;

            for (int traversed = 0; ; traversed++) {
                if (node.Next is not { } next) {
                    node.Next = NewNode(spread, value);

                    if (traversed >= TreeifyThreshold - 1) {
                        TreeifyBucket(index);
                    }

                    break;
                }

                if (next.Hash == spread && EqualityComparer<T>.Default.Equals(next.Value, value)) {
                    return false;
                }

                node = next;
            }
        }

        // Upstream grows after the insert, not before it, so a set filled to exactly the threshold
        // keeps the narrower table and the order that goes with it.
        if (++Count > _threshold) {
            Resize();
        }

        return true;
    }

    public bool Contains(T value) {
        if (_table.Length == 0) {
            return false;
        }

        int spread = Spread(hash(value));
        Node? head = _table[spread & (_table.Length - 1)];

        if (head is { Tree: true }) {
            return Find(head, spread, value) != null;
        }

        for (Node? node = head; node != null; node = node.Next) {
            if (node.Hash == spread && EqualityComparer<T>.Default.Equals(node.Value, value)) {
                return true;
            }
        }

        return false;
    }

    public void Clear() {
        _table = [];
        _threshold = 0;
        Count = 0;
        _sequence = 0;
    }

    private Node NewNode(int spread, T value) => new(spread, value, _sequence++);

    /// <summary><c>HashMap.hash</c>: the top bits folded down, so a table narrower than the hash uses them.</summary>
    private static int Spread(int value) => value ^ (int)((uint)value >> 16);

    /// <summary>
    /// <c>HashMap.resize</c>. A chained bucket splits into the entries whose extra bit is clear and the
    /// ones where it is set, <b>each keeping its order</b>; a treeified one goes through
    /// <see cref="SplitTree"/>.
    /// </summary>
    private void Resize() {
        Node?[] old = _table;
        int oldCapacity = old.Length;
        int capacity = oldCapacity == 0 ? InitialCapacity : oldCapacity << 1;

        _threshold = (int)(capacity * LoadFactor);
        Node?[] table = new Node?[capacity];
        _table = table;

        for (int bucket = 0; bucket < oldCapacity; bucket++) {
            if (old[bucket] is not { } head) {
                continue;
            }

            old[bucket] = null;

            if (head.Next == null) {
                table[head.Hash & (capacity - 1)] = head;
                continue;
            }

            if (head.Tree) {
                SplitTree(head, bucket, oldCapacity);
                continue;
            }

            Node? node = head;
            Node? lowHead = null, lowTail = null, highHead = null, highTail = null;

            while (node != null) {
                Node? next = node.Next;
                node.Next = null;

                if ((node.Hash & oldCapacity) == 0) {
                    if (lowTail == null) {
                        lowHead = node;
                    } else {
                        lowTail.Next = node;
                    }

                    lowTail = node;
                } else {
                    if (highTail == null) {
                        highHead = node;
                    } else {
                        highTail.Next = node;
                    }

                    highTail = node;
                }

                node = next;
            }

            table[bucket] = lowHead;
            table[bucket + oldCapacity] = highHead;
        }
    }

    /// <summary>
    /// <c>treeifyBin</c>. A bucket this long in a table narrower than
    /// <see cref="MinTreeifyCapacity"/> is widened instead of turned into a tree, and that widening
    /// happens <b>before</b> the size check that may widen it again.
    /// </summary>
    private void TreeifyBucket(int index) {
        if (_table.Length < MinTreeifyCapacity) {
            Resize();
            return;
        }

        if (_table[index] is not { } head) {
            return;
        }

        // Upstream builds fresh TreeNodes over the chain and links their prev pointers as it goes.
        // The root is unlinked from the chain by its prev, so leaving those unset loses the node in
        // front of it.
        Node? previous = null;

        for (Node? node = head; node != null; node = node.Next) {
            node.Tree = true;
            node.Left = node.Right = node.Parent = null;
            node.Prev = previous;
            previous = node;
        }

        Treeify(head, index);
    }

    /// <summary>
    /// <c>TreeNode.treeify</c>: the bucket's chain, in its current order, inserted one at a time into
    /// a red-black tree, whose root is then moved to the front of that chain.
    /// </summary>
    /// <remarks>
    /// The chain itself is not rebuilt, so what the iterator sees changes only by the root moving.
    /// </remarks>
    private void Treeify(Node head, int index) {
        Node? root = null;

        for (Node? x = head; x != null; x = x.Next) {
            x.Left = x.Right = null;

            if (root == null) {
                x.Parent = null;
                x.Red = false;
                root = x;
                continue;
            }

            Node p = root;

            while (true) {
                int direction = p.Hash > x.Hash ? -1 : p.Hash < x.Hash ? 1 : TieBreak(x, p);
                Node parent = p;
                Node? child = direction <= 0 ? p.Left : p.Right;

                if (child == null) {
                    x.Parent = parent;

                    if (direction <= 0) {
                        parent.Left = x;
                    } else {
                        parent.Right = x;
                    }

                    root = BalanceInsertion(root, x);
                    break;
                }

                p = child;
            }
        }

        if (root != null) {
            MoveRootToFront(index, root);
        }
    }

    /// <summary>
    /// <c>TreeNode.putTreeVal</c>. Reports whether the value was already there; when it was not, the
    /// new node is linked into the chain <b>directly after the node it hangs off</b> rather than at
    /// the end, which is the other half of how a treeified bucket's order stops being insertion order.
    /// </summary>
    private bool PutTreeValue(Node head, int index, int spread, T value) {
        Node root = head;

        while (root.Parent is { } parent) {
            root = parent;
        }

        Node p = root;
        bool searched = false;

        while (true) {
            int direction;

            if (p.Hash > spread) {
                direction = -1;
            } else if (p.Hash < spread) {
                direction = 1;
            } else if (EqualityComparer<T>.Default.Equals(p.Value, value)) {
                return true;
            } else {
                // Equal hashes and different values, so the tree cannot say which side the value is
                // on and the whole subtree under this node has to be searched once before the tie is
                // broken and a side picked.
                if (!searched) {
                    searched = true;

                    if ((p.Left != null && Find(p.Left, spread, value) != null)
                        || (p.Right != null && Find(p.Right, spread, value) != null)) {

                        return true;
                    }
                }

                // The value being added is newer than everything already in the tree, so the tie
                // break on insertion order always sends it right. See the note on the type for why
                // insertion order stands in for vanilla's identity hash here.
                direction = 1;
            }

            Node parent = p;
            Node? child = direction <= 0 ? p.Left : p.Right;

            if (child == null) {
                Node? after = parent.Next;
                Node inserted = NewNode(spread, value);
                inserted.Tree = true;

                if (direction <= 0) {
                    parent.Left = inserted;
                } else {
                    parent.Right = inserted;
                }

                parent.Next = inserted;
                inserted.Parent = inserted.Prev = parent;

                if (after != null) {
                    after.Prev = inserted;
                    inserted.Next = after;
                }

                MoveRootToFront(index, BalanceInsertion(root, inserted));
                return false;
            }

            p = child;
        }
    }

    /// <summary>
    /// <c>TreeNode.split</c>: the two halves of a resized bucket, each keeping the chain order it had.
    /// </summary>
    /// <remarks>
    /// A half of six or fewer falls back to a plain chain. A half that keeps its tree is only
    /// re-treeified when the <b>other</b> half is non-empty: a bucket that moved across whole is
    /// already a tree, and rebuilding it would move its root again.
    /// </remarks>
    private void SplitTree(Node head, int index, int bit) {
        Node? lowHead = null, lowTail = null, highHead = null, highTail = null;
        int low = 0, high = 0;

        for (Node? node = head; node != null;) {
            Node? next = node.Next;
            node.Next = null;

            if ((node.Hash & bit) == 0) {
                node.Prev = lowTail;

                if (lowTail == null) {
                    lowHead = node;
                } else {
                    lowTail.Next = node;
                }

                lowTail = node;
                low++;
            } else {
                node.Prev = highTail;

                if (highTail == null) {
                    highHead = node;
                } else {
                    highTail.Next = node;
                }

                highTail = node;
                high++;
            }

            node = next;
        }

        if (lowHead != null) {
            if (low <= UntreeifyThreshold) {
                _table[index] = Untreeify(lowHead);
            } else {
                _table[index] = lowHead;

                if (highHead != null) {
                    Treeify(lowHead, index);
                }
            }
        }

        if (highHead != null) {
            if (high <= UntreeifyThreshold) {
                _table[index + bit] = Untreeify(highHead);
            } else {
                _table[index + bit] = highHead;

                if (lowHead != null) {
                    Treeify(highHead, index + bit);
                }
            }
        }
    }

    /// <summary><c>TreeNode.untreeify</c>: the chain, in the order it already has.</summary>
    private static Node Untreeify(Node head) {
        for (Node? node = head; node != null; node = node.Next) {
            node.Tree = false;
            node.Left = node.Right = node.Parent = node.Prev = null;
            node.Red = false;
        }

        return head;
    }

    /// <summary>
    /// <c>TreeNode.moveRootToFront</c>: the tree's root becomes the first node the iterator sees.
    /// </summary>
    private void MoveRootToFront(int index, Node root) {
        if (_table[index] == root) {
            return;
        }

        Node? first = _table[index];
        _table[index] = root;

        Node? before = root.Prev;
        Node? after = root.Next;

        if (after != null) {
            after.Prev = before;
        }

        if (before != null) {
            before.Next = after;
        }

        if (first != null) {
            first.Prev = root;
        }

        root.Next = first;
        root.Prev = null;
    }

    /// <summary>
    /// <c>TreeNode.find</c>. Where the hashes tie and the values differ the tree cannot choose a side,
    /// so both are walked.
    /// </summary>
    private static Node? Find(Node from, int spread, T value) {
        Node? p = from;

        while (p != null) {
            Node? left = p.Left;
            Node? right = p.Right;

            if (p.Hash > spread) {
                p = left;
            } else if (p.Hash < spread) {
                p = right;
            } else if (EqualityComparer<T>.Default.Equals(p.Value, value)) {
                return p;
            } else if (left == null) {
                p = right;
            } else if (right == null) {
                p = left;
            } else if (Find(right, spread, value) is { } found) {
                return found;
            } else {
                p = left;
            }
        }

        return null;
    }

    /// <summary>
    /// Which side of <paramref name="existing"/> a value with the same hash goes on.
    /// </summary>
    /// <remarks>
    /// <c>tieBreakOrder</c>, with insertion order where vanilla has an identity hash. See the note on
    /// the type: the value upstream compares is a per run one, so this is the one place a vanilla
    /// world is not a function of its seed.
    /// </remarks>
    private static int TieBreak(Node inserting, Node existing) {
        return inserting.Sequence <= existing.Sequence ? -1 : 1;
    }

    /// <summary><c>TreeNode.rotateLeft</c>.</summary>
    private static Node RotateLeft(Node root, Node p) {
        if (p.Right is not { } right) {
            return root;
        }

        Node? rightLeft = p.Right = right.Left;

        if (rightLeft != null) {
            rightLeft.Parent = p;
        }

        Node? parent = right.Parent = p.Parent;

        if (parent == null) {
            root = right;
            right.Red = false;
        } else if (parent.Left == p) {
            parent.Left = right;
        } else {
            parent.Right = right;
        }

        right.Left = p;
        p.Parent = right;
        return root;
    }

    /// <summary><c>TreeNode.rotateRight</c>.</summary>
    private static Node RotateRight(Node root, Node p) {
        if (p.Left is not { } left) {
            return root;
        }

        Node? leftRight = p.Left = left.Right;

        if (leftRight != null) {
            leftRight.Parent = p;
        }

        Node? parent = left.Parent = p.Parent;

        if (parent == null) {
            root = left;
            left.Red = false;
        } else if (parent.Right == p) {
            parent.Right = left;
        } else {
            parent.Left = left;
        }

        left.Right = p;
        p.Parent = left;
        return root;
    }

    /// <summary><c>TreeNode.balanceInsertion</c>.</summary>
    /// <remarks>
    /// A rotation can leave the node's parent null, which is why both are re-read and tested rather
    /// than carried across it.
    /// </remarks>
    private static Node BalanceInsertion(Node root, Node inserted) {
        Node x = inserted;
        x.Red = true;

        while (true) {
            if (x.Parent is not { } parent) {
                x.Red = false;
                return x;
            }

            if (!parent.Red || parent.Parent is not { } grandparent) {
                return root;
            }

            Node? parentOrNull = parent;
            Node? grandparentOrNull = grandparent;

            if (parent == grandparent.Left) {
                if (grandparent.Right is { Red: true } uncle) {
                    uncle.Red = false;
                    parent.Red = false;
                    grandparent.Red = true;
                    x = grandparent;
                    continue;
                }

                if (x == parent.Right) {
                    x = parent;
                    root = RotateLeft(root, x);
                    parentOrNull = x.Parent;
                    grandparentOrNull = parentOrNull?.Parent;
                }

                if (parentOrNull != null) {
                    parentOrNull.Red = false;

                    if (grandparentOrNull != null) {
                        grandparentOrNull.Red = true;
                        root = RotateRight(root, grandparentOrNull);
                    }
                }
            } else {
                if (grandparent.Left is { Red: true } uncle) {
                    uncle.Red = false;
                    parent.Red = false;
                    grandparent.Red = true;
                    x = grandparent;
                    continue;
                }

                if (x == parent.Left) {
                    x = parent;
                    root = RotateRight(root, x);
                    parentOrNull = x.Parent;
                    grandparentOrNull = parentOrNull?.Parent;
                }

                if (parentOrNull != null) {
                    parentOrNull.Red = false;

                    if (grandparentOrNull != null) {
                        grandparentOrNull.Red = true;
                        root = RotateLeft(root, grandparentOrNull);
                    }
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator() {
        foreach (Node? head in _table) {
            for (Node? node = head; node != null; node = node.Next) {
                yield return node.Value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
