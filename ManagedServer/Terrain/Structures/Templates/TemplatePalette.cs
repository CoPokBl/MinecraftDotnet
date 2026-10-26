using Minecraft.Registry;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>StructureTemplate.Palette</c>: one whole set of blocks for a template.
/// </summary>
/// <remarks>
/// A template usually has one, and twenty of the vanilla ones have several: those are a piece written
/// out in each of its material variants, and a placement picks between them with its own random. So a
/// palette is not a block table but an alternative version of the template.
/// <p/>
/// The per block lookups are memoised because a piece asks the same two questions of the same template
/// every time it is placed, and the structure pass replays 289 source chunks. Memoised under a lock
/// rather than left to a race: the pass runs on the thread pool, and a template is shared by every
/// piece naming it.
/// </remarks>
public sealed class TemplatePalette {
    private readonly TemplateBlockInfo[] _blocks;
    private readonly Dictionary<Identifier, TemplateBlockInfo[]> _byBlock = [];
    private readonly Lock _gate = new();

    private JigsawBlockInfo[]? _jigsaws;

    public TemplatePalette(TemplateBlockInfo[] blocks) {
        _blocks = blocks;
    }

    public IReadOnlyList<TemplateBlockInfo> Blocks => _blocks;

    /// <summary>Every block of one kind, in the template's own coordinates.</summary>
    public IReadOnlyList<TemplateBlockInfo> BlocksOf(Identifier block, MinecraftRegistry registry) {
        return Of(block, registry);
    }

    /// <summary>The jigsaw blocks, read out of the block entity tag each one carries.</summary>
    public IReadOnlyList<JigsawBlockInfo> Jigsaws(MinecraftRegistry registry) {
        TemplateBlockInfo[] blocks = Of(Block.Jigsaw.Identifier, registry);

        lock (_gate) {
            return _jigsaws ??= blocks.Select(info => JigsawBlockInfo.Of(info, registry)).ToArray();
        }
    }

    private TemplateBlockInfo[] Of(Identifier block, MinecraftRegistry registry) {
        lock (_gate) {
            if (_byBlock.TryGetValue(block, out TemplateBlockInfo[]? found)) {
                return found;
            }
        }

        // Built outside the lock: it is a scan of the whole template through the registry, and two
        // threads racing to build the same list store equal answers.
        TemplateBlockInfo[] built = _blocks
            .Where(info => registry.Blocks.GetByStateId(info.StateId).Identifier.Equals(block))
            .ToArray();

        lock (_gate) {
            _byBlock[block] = built;
            return built;
        }
    }
}
