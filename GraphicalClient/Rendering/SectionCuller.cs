using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Culls sections and writes their draw commands on the GPU, so a frame costs the CPU a dispatch
/// rather than a pass over every section in range.
/// <p/>
/// Every section with geometry has a slot in a table on the GPU holding its position and its quad
/// count per bucket. The visibility walk hands over its result as a list of slots in walk order,
/// which is nearest first, and only when it changes. Each frame the list is culled and compacted with
/// a prefix sum rather than atomics, so solid geometry still goes front to back and translucent back
/// to front. The shadow camera's commands come from every slot, in any order, since a shadow map
/// does not blend.
/// </summary>
public sealed unsafe class SectionCuller : IDisposable {
    /// <summary>Solid, cutout and translucent for the main camera, then solid and cutout for the shadow camera.</summary>
    public const int Sets = 5;
    private const int Facings = SectionMesh.Facings;
    private const int CommandSize = 20;
    private const int CountsLength = 12;
    private const int MainVisibleCount = 7;
    private const int MainQuadsCount = 5;
    private const int LayerQuadsCount = 8;
    private const int ShadowQuadsCount = 6;

    [StructLayout(LayoutKind.Sequential)]
    private struct GpuSection {
        public int X, Y, Z;
        /// <summary>First vertex in the arena, or -1 for an empty slot.</summary>
        public int BaseVertex;
        public fixed uint Quads[24];
    }

    private const string Common = """

        struct Section { ivec4 position; uint quads[24]; };
        struct Command { uint count; uint instanceCount; uint firstIndex; int baseVertex; uint baseInstance; };

        layout(std430, binding = 0) readonly buffer Sections { Section sections[]; };
        layout(std430, binding = 1) readonly buffer List { uint list[]; };
        layout(std430, binding = 2) writeonly buffer Commands { Command commands[]; };
        layout(std430, binding = 3) buffer Counts { uint counts[12]; };
        layout(std430, binding = 4) writeonly buffer Origins { vec4 origins[]; };

        uniform ivec3 cameraSection;
        uniform vec3 cameraOffset;
        uniform vec4 planes[6];
        uniform float maxDistance;
        uniform uint regionCapacity;
        uniform uint maxQuads;
        // Without indirect count support every command up to this many is written, culled ones empty.
        uniform uint padTo;

        // Integer section offsets first, so precision does not depend on how far out the world is.
        vec3 relativeOf(uint slot) {
            return vec3((sections[slot].position.xyz - cameraSection) * 16) - cameraOffset;
        }

        bool inside(vec3 lo) {
            vec2 centre = lo.xz + 8.0;
            if (dot(centre, centre) > maxDistance * maxDistance) {
                return false;
            }
            for (int i = 0; i < 6; i++) {
                vec3 corner = mix(lo, lo + 16.0, greaterThanEqual(planes[i].xyz, vec3(0.0)));
                if (dot(planes[i].xyz, corner) + planes[i].w < 0.0) {
                    return false;
                }
            }
            return true;
        }
        """;

    /// <summary>
    /// The main camera's culling, in four dispatches over the walk's list. COUNT tests each section and
    /// writes how many commands it needs per layer; SCAN turns those into offsets within blocks of 1024
    /// and BLOCKS into each block's start, a prefix sum in two levels; EMIT writes the commands. Solid
    /// and cutout keep list order; translucent is written in reverse by taking each offset from the far end.
    /// </summary>
    private const string MainSource = Common + """

        // Per list entry: commands per layer, then the facing mask in w's low bits and 256 if visible.
        // SCAN replaces xyz with the exclusive solid and cutout offsets and the inclusive translucent one,
        // all within the entry's block of 1024; BLOCKS gives each block's starting offsets.
        layout(std430, binding = 5) buffer Work { uvec4 work[]; };
        layout(std430, binding = 6) buffer Blocks { uvec4 blocks[]; };

        uniform uint listCount;

        // A face can only be seen from its outward side, so a section's faces in one direction are all
        // hidden while the camera is wholly behind the section on that axis. Bit 6 is the unaligned bucket.
        uint facings(vec3 r) {
            uint mask = 64u;
            if (r.y + 16.0 > 0.0) mask |= 1u;
            if (r.y < 0.0) mask |= 2u;
            if (r.z + 16.0 > 0.0) mask |= 4u;
            if (r.z < 0.0) mask |= 8u;
            if (r.x + 16.0 > 0.0) mask |= 16u;
            if (r.x < 0.0) mask |= 32u;
            return mask;
        }

        #if defined(COUNT)
        layout(local_size_x = 256) in;

        void main() {
            uint i = gl_GlobalInvocationID.x;
            if (i >= listCount) {
                return;
            }
            uint slot = list[i];
            uvec4 n = uvec4(0u);
            vec3 r = relativeOf(slot);
            if (sections[slot].position.w >= 0 && inside(r)) {
                uint mask = facings(r);
                origins[slot] = vec4(r, 0.0);
                for (uint f = 0u; f < 7u; f++) {
                    if ((mask & (1u << f)) != 0u) {
                        n.x += sections[slot].quads[f] != 0u ? 1u : 0u;
                        n.y += sections[slot].quads[7u + f] != 0u ? 1u : 0u;
                        n.z += sections[slot].quads[14u + f] != 0u ? 1u : 0u;
                    }
                }
                n.w = mask | 256u;
                atomicAdd(counts[7], 1u);
            }
            work[i] = n;
        }

        #elif defined(SCAN) || defined(BLOCKS)
        layout(local_size_x = 1024) in;

        shared uvec3 sums[1024];

        // barrier() orders execution; memoryBarrierShared makes the array's writes visible across it.
        void sync() {
            memoryBarrierShared();
            barrier();
        }

        // Inclusive prefix sum of n across the workgroup, Hillis and Steele's.
        uvec3 inclusiveSum(uvec3 n) {
            uint local = gl_LocalInvocationID.x;
            sums[local] = n;
            sync();
            for (uint offset = 1u; offset < 1024u; offset <<= 1u) {
                uvec3 add = local >= offset ? sums[local - offset] : uvec3(0u);
                sync();
                sums[local] += add;
                sync();
            }
            return sums[local];
        }

        #if defined(SCAN)
        // One workgroup per block of 1024 entries: offsets within the block, and the block's total.
        void main() {
            uint i = gl_WorkGroupID.x * 1024u + gl_LocalInvocationID.x;
            uvec4 n = i < listCount ? work[i] : uvec4(0u);
            uvec3 inclusive = inclusiveSum(n.xyz);
            if (i < listCount) {
                work[i].xyz = uvec3(inclusive.xy - n.xy, inclusive.z);
            }
            if (gl_LocalInvocationID.x == 1023u) {
                blocks[gl_WorkGroupID.x] = uvec4(inclusive, 0u);
            }
        }
        #else
        // One workgroup over the block totals: each block's starting offset, and the grand totals.
        void main() {
            uint local = gl_LocalInvocationID.x;
            uint blockCount = (listCount + 1023u) / 1024u;
            uvec3 total = local < blockCount ? blocks[local].xyz : uvec3(0u);
            uvec3 inclusive = inclusiveSum(total);
            if (local < blockCount) {
                blocks[local].xyz = inclusive - total;
            }
            if (local == 1023u) {
                counts[0] = inclusive.x;
                counts[1] = inclusive.y;
                counts[2] = inclusive.z;
            }
        }
        #endif

        #elif defined(EMIT)
        layout(local_size_x = 256) in;

        void main() {
            uint i = gl_GlobalInvocationID.x;
            if (i >= listCount) {
                return;
            }
            uvec4 entry = work[i];
            entry.xyz += blocks[i / 1024u].xyz;
            uint slot = list[i];
            if ((entry.w & 256u) != 0u) {
                // Furthest first for translucent: this section's commands end where the nearer ones begin.
                uvec3 at = uvec3(entry.xy, counts[2] - entry.z);
                int base = sections[slot].position.w;
                uint starts[21];
                uint start = 0u;
                for (uint b = 0u; b < 21u; b++) {
                    starts[b] = start;
                    start += sections[slot].quads[b];
                }
                // Translucent buckets are each sorted furthest first along their facing; between them,
                // the faces looking toward the camera vertically go last, so ice is blended over the
                // sides of the water under it rather than under them.
                uint[7] translucentOrder = relativeOf(slot).y + 8.0 < 0.0 ? uint[7](6u, 0u, 2u, 3u, 4u, 5u, 1u) : uint[7](6u, 1u, 2u, 3u, 4u, 5u, 0u);
                uint drawn = 0u;
                for (uint layer = 0u; layer < 3u; layer++) {
                    uint layerDrawn = drawn;
                    for (uint k = 0u; k < 7u; k++) {
                        uint f = layer == 2u ? translucentOrder[k] : k;
                        uint quads = sections[slot].quads[layer * 7u + f];
                        if ((entry.w & (1u << f)) != 0u && quads != 0u) {
                            commands[layer * regionCapacity + at[layer]] = Command(min(quads, maxQuads) * 6u, 1u, 0u, base + int(starts[layer * 7u + f] * 4u), slot);
                            at[layer]++;
                            drawn += quads;
                        }
                    }
                    atomicAdd(counts[8u + layer], drawn - layerDrawn);
                }
                atomicAdd(counts[5], drawn);
            }
            if (padTo != 0u) {
                for (uint layer = 0u; layer < 3u; layer++) {
                    for (uint k = i * 7u; k < i * 7u + 7u; k++) {
                        if (k >= counts[layer] && k < padTo) {
                            commands[layer * regionCapacity + k] = Command(0u, 0u, 0u, 0, 0u);
                        }
                    }
                }
            }
        }
        #endif
        """;

    private const string ShadowSource = Common + """

        layout(local_size_x = 64) in;

        uniform uint slotCount;

        void main() {
            uint slot = gl_GlobalInvocationID.x;
            if (slot >= slotCount) {
                return;
            }
            bool visible = false;
            vec3 r = vec3(0.0);
            if (sections[slot].position.w >= 0) {
                r = relativeOf(slot);
                visible = inside(r);
            }
            if (visible) {
                origins[slot] = vec4(r, 0.0);
            }
            // Every facing at once: the buckets of a layer sit next to each other in the arena.
            uint start = 0u;
            for (uint layer = 0u; layer < 2u; layer++) {
                uint quads = 0u;
                for (uint f = 0u; f < 7u; f++) {
                    quads += sections[slot].quads[layer * 7u + f];
                }
                uint region = (3u + layer) * regionCapacity;
                if (visible && quads != 0u) {
                    uint at = padTo != 0u ? slot : atomicAdd(counts[3u + layer], 1u);
                    commands[region + at] = Command(min(quads, maxQuads) * 6u, 1u, 0u, sections[slot].position.w + int(start * 4u), slot);
                    atomicAdd(counts[6], quads);
                }
                else if (padTo != 0u) {
                    commands[region + slot] = Command(0u, 0u, 0u, 0, 0u);
                }
                start += quads;
            }
        }
        """;

    private readonly GL _gl;
    private readonly UploadRing _uploads;
    /// <summary>COUNT, SCAN, BLOCKS and EMIT, in dispatch order.</summary>
    private readonly ShaderProgram[] _main;
    private readonly ShaderProgram _shadow;
    private readonly bool _indirectCount;
    private readonly int _maxQuads;
    private readonly Stack<int> _free = new();
    private readonly List<int> _freedSinceList = [];
    private readonly uint _counts;
    private readonly uint _stats;
    private readonly uint* _statsMapped;

    private uint _sections, _list, _work, _blockSums, _commands, _origins;
    private int _capacity;
    private int _slotCount;
    private int _listCount;
    private int _listCapacity;

    public uint OriginBuffer => _origins;

    /// <summary>Raised when the buffers are replaced by larger ones, so whoever binds the origins can rebind.</summary>
    public event Action? Grown;

    /// <summary>Sections the main camera drew, a frame or two ago.</summary>
    public int VisibleSections => (int)_statsMapped[MainVisibleCount];
    public long MainQuads => _statsMapped[MainQuadsCount];
    public long LayerQuads(int layer) => _statsMapped[LayerQuadsCount + layer];
    public long ShadowQuads => _statsMapped[ShadowQuadsCount];

    public SectionCuller(GL gl, UploadRing uploads, int maxQuadsPerDraw) {
        _gl = gl;
        _uploads = uploads;
        _maxQuads = maxQuadsPerDraw;
        _main = new[] { "COUNT", "SCAN", "BLOCKS", "EMIT" }.Select(stage => new ShaderProgram(gl, $"#version 450 core\n#define {stage} 1\n" + MainSource)).ToArray();
        _shadow = new ShaderProgram(gl, "#version 450 core\n" + ShadowSource);
        _indirectCount = gl.IsExtensionPresent("GL_ARB_indirect_parameters")
                         || gl.GetInteger(GetPName.MajorVersion) * 10 + gl.GetInteger(GetPName.MinorVersion) >= 46;

        _counts = gl.CreateBuffer();
        gl.NamedBufferStorage(_counts, CountsLength * sizeof(uint), null, BufferStorageMask.None);
        _stats = gl.CreateBuffer();
        const BufferStorageMask readable = BufferStorageMask.MapReadBit | BufferStorageMask.MapPersistentBit | BufferStorageMask.MapCoherentBit;
        gl.NamedBufferStorage(_stats, CountsLength * sizeof(uint), null, readable);
        _statsMapped = (uint*)gl.MapNamedBufferRange(_stats, 0, CountsLength * sizeof(uint),
            (uint)(MapBufferAccessMask.ReadBit | MapBufferAccessMask.PersistentBit | MapBufferAccessMask.CoherentBit));
        Resize(8192);
        ResizeList(8192);
    }

    private uint Buffer(long bytes) {
        uint buffer = _gl.CreateBuffer();
        _gl.NamedBufferStorage(buffer, (nuint)Math.Max(16, bytes), null, BufferStorageMask.None);
        return buffer;
    }

    private void Resize(int capacity) {
        uint sections = Buffer((long)capacity * sizeof(GpuSection));
        if (_sections != 0) {
            _gl.CopyNamedBufferSubData(_sections, sections, 0, 0, (nuint)((long)_capacity * sizeof(GpuSection)));
            _gl.DeleteBuffer(_sections);
            _gl.DeleteBuffer(_commands);
            _gl.DeleteBuffer(_origins);
        }
        _sections = sections;
        _commands = Buffer((long)Sets * capacity * Facings * CommandSize);
        _origins = Buffer((long)capacity * sizeof(Vector4));
        _capacity = capacity;
        Grown?.Invoke();
    }

    private void ResizeList(int capacity) {
        if (_list != 0) {
            _gl.DeleteBuffer(_list);
            _gl.DeleteBuffer(_work);
            _gl.DeleteBuffer(_blockSums);
        }
        _list = Buffer((long)capacity * sizeof(uint));
        _work = Buffer((long)capacity * 4 * sizeof(uint));
        _blockSums = Buffer((long)(capacity / 1024 + 1) * 4 * sizeof(uint));
        _listCapacity = capacity;
    }

    private int RegionCapacity => _capacity * Facings;

    public int Allocate() {
        if (_free.TryPop(out int slot)) {
            return slot;
        }
        if (_slotCount == _capacity) {
            Resize(_capacity * 2);
        }
        return _slotCount++;
    }

    public void Update(int slot, int sectionX, int sectionY, int sectionZ, int baseVertex, ReadOnlySpan<int> bucketQuads) {
        GpuSection entry = new() { X = sectionX, Y = sectionY, Z = sectionZ, BaseVertex = baseVertex };
        for (int i = 0; i < bucketQuads.Length; i++) {
            entry.Quads[i] = (uint)bucketQuads[i];
        }
        _uploads.Copy(new ReadOnlySpan<GpuSection>(&entry, 1), _sections, (long)slot * sizeof(GpuSection));
    }

    /// <summary>
    /// Empties a slot. It is not handed out again until a list from a later walk, since the current one
    /// may still name it and would draw whatever moved in.
    /// </summary>
    public void Free(int slot) {
        GpuSection empty = new() { BaseVertex = -1 };
        _uploads.Copy(new ReadOnlySpan<GpuSection>(&empty, 1), _sections, (long)slot * sizeof(GpuSection));
        _freedSinceList.Add(slot);
    }

    /// <summary>Forgets every slot, for a new level.</summary>
    public void Clear() {
        _free.Clear();
        _freedSinceList.Clear();
        _slotCount = 0;
        _listCount = 0;
    }

    /// <summary>Slots emptied since the last list; a walk notes it, see <see cref="SetList"/>.</summary>
    public int FreedSinceList => _freedSinceList.Count;

    /// <summary>
    /// The slots the main camera may draw, nearest first, from a walk made when
    /// <see cref="FreedSinceList"/> was <paramref name="freedBeforeWalk"/>. Those slots can be reused
    /// now; any freed after the walk may still be named in it, so they wait for the next.
    /// </summary>
    public void SetList(ReadOnlySpan<int> slots, int freedBeforeWalk) {
        if (slots.Length > _listCapacity) {
            ResizeList(Math.Max(slots.Length, _listCapacity * 2));
        }
        _uploads.Copy(slots, _list, 0);
        _listCount = slots.Length;
        freedBeforeWalk = Math.Min(freedBeforeWalk, _freedSinceList.Count);
        for (int i = 0; i < freedBeforeWalk; i++) {
            _free.Push(_freedSinceList[i]);
        }
        _freedSinceList.RemoveRange(0, freedBeforeWalk);
    }

    private void Bind() {
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 0, _sections);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 1, _list);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 2, _commands);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 3, _counts);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 4, _origins);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 5, _work);
        _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, 6, _blockSums);
    }

    private void SetCamera(ShaderProgram program, double x, double y, double z, Frustum frustum, float maxDistance) {
        int sx = (int)Math.Floor(x / 16), sy = (int)Math.Floor(y / 16), sz = (int)Math.Floor(z / 16);
        program.Set("cameraSection", sx, sy, sz);
        program.Set("cameraOffset", new Vector3((float)(x - sx * 16.0), (float)(y - sy * 16.0), (float)(z - sz * 16.0)));
        Span<Vector4> planes = stackalloc Vector4[6];
        frustum.CopyPlanes(planes);
        program.Set("planes", planes);
        program.Set("maxDistance", maxDistance);
        program.Set("regionCapacity", (uint)RegionCapacity);
        program.Set("maxQuads", (uint)_maxQuads);
    }

    /// <summary>Starts a frame: reads back last frame's statistics and resets the counters.</summary>
    public void BeginFrame() {
        _gl.CopyNamedBufferSubData(_counts, _stats, 0, 0, CountsLength * sizeof(uint));
        uint zero = 0;
        _gl.ClearNamedBufferData(_counts, SizedInternalFormat.R32ui, PixelFormat.RedInteger, PixelType.UnsignedInt, &zero);
    }

    public void CullMain(double x, double y, double z, Frustum frustum, float maxDistance) {
        if (_listCount == 0) {
            return;
        }
        Bind();
        uint groups = (uint)(_listCount + 255) / 256;
        uint blocks = (uint)(_listCount + 1023) / 1024;
        for (int stage = 0; stage < _main.Length; stage++) {
            ShaderProgram program = _main[stage];
            program.Use();
            SetCamera(program, x, y, z, frustum, maxDistance);
            program.Set("listCount", (uint)_listCount);
            program.Set("padTo", _indirectCount ? 0u : (uint)(_listCount * Facings));
            _gl.DispatchCompute(stage switch { 1 => blocks, 2 => 1u, _ => groups }, 1, 1);
            _gl.MemoryBarrier(MemoryBarrierMask.ShaderStorageBarrierBit);
        }
    }

    public void CullShadow(double x, double y, double z, Frustum frustum, float radius) {
        if (_slotCount == 0) {
            return;
        }
        _shadow.Use();
        SetCamera(_shadow, x, y, z, frustum, radius + 16);
        _shadow.Set("slotCount", (uint)_slotCount);
        _shadow.Set("padTo", _indirectCount ? 0u : (uint)_slotCount);
        Bind();
        _gl.DispatchCompute((uint)(_slotCount + 63) / 64, 1, 1);
    }

    /// <summary>Makes the commands and origins written by the culling visible to the draws that read them.</summary>
    public void Finish() {
        _gl.MemoryBarrier(MemoryBarrierMask.CommandBarrierBit | MemoryBarrierMask.VertexAttribArrayBarrierBit | MemoryBarrierMask.ShaderStorageBarrierBit);
    }

    /// <summary>Issues one set's commands, with the vertex array and program already bound.</summary>
    public void Draw(int set) {
        bool shadow = set >= 3;
        int maxDraws = shadow ? _slotCount : _listCount * Facings;
        if (maxDraws == 0) {
            return;
        }
        _gl.BindBuffer(BufferTargetARB.DrawIndirectBuffer, _commands);
        void* offset = (void*)((long)set * RegionCapacity * CommandSize);
        if (_indirectCount) {
            _gl.BindBuffer(BufferTargetARB.ParameterBuffer, _counts);
            _gl.MultiDrawElementsIndirectCount(PrimitiveType.Triangles, DrawElementsType.UnsignedInt, offset, set * sizeof(uint),
                (uint)maxDraws, CommandSize);
        }
        else {
            _gl.MultiDrawElementsIndirect(PrimitiveType.Triangles, DrawElementsType.UnsignedInt, offset, (uint)maxDraws, CommandSize);
        }
    }

    public void Dispose() {
        foreach (ShaderProgram program in _main) {
            program.Dispose();
        }
        _shadow.Dispose();
        _gl.UnmapNamedBuffer(_stats);
        foreach (uint buffer in new[] { _sections, _list, _work, _blockSums, _commands, _origins, _counts, _stats }) {
            _gl.DeleteBuffer(buffer);
        }
    }
}
