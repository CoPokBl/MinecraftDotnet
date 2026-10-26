using System.Numerics;
using ClientLib.World;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// The dig cracks: the block's own model quads again, textured with <c>destroy_stage_N</c> through
/// <c>SheetedDecalTextureGenerator</c>, which projects each corner's place in the block onto the face it
/// points out of. The pipeline draws them as the <c>crumbling</c> geometry.
/// </summary>
public sealed class CrumblingRenderer {
    private const int DestroyStages = 10;

    private readonly ResourcePackSource? _pack;
    private readonly EntityTextures _textures;
    private readonly Dictionary<IBlock, BakedBlockModel?> _models = new();

    // Direction.getRotation, each after the decal's own turn of rotateY(pi) then rotateX(-pi/2). JOML
    // turns a column vector, so the row vector products here run in the opposite order.
    private static readonly Matrix4x4[] Projections = BuildProjections();

    public CrumblingRenderer(ResourcePackSource? pack, EntityTextures textures) {
        _pack = pack;
        _textures = textures;
    }

    private static Matrix4x4[] BuildProjections() {
        Matrix4x4 sheet = Matrix4x4.CreateRotationY(MathF.PI) * Matrix4x4.CreateRotationX(-MathF.PI / 2);
        Matrix4x4 XYZ(float x, float y, float z) => Matrix4x4.CreateRotationZ(z) * Matrix4x4.CreateRotationY(y) * Matrix4x4.CreateRotationX(x);
        Matrix4x4[] directions = [
            Matrix4x4.CreateRotationX(MathF.PI),
            Matrix4x4.Identity,
            XYZ(MathF.PI / 2, 0, MathF.PI),
            Matrix4x4.CreateRotationX(MathF.PI / 2),
            XYZ(MathF.PI / 2, 0, MathF.PI / 2),
            XYZ(MathF.PI / 2, 0, -MathF.PI / 2)
        ];
        return directions.Select(d => sheet * d).ToArray();
    }

    /// <summary>False when there is nothing to draw it with, so the caller can draw its own.</summary>
    public bool Render(ClientLevel level, Camera camera, EntityBatch batch, int x, int y, int z, int stage) {
        if (_pack == null || stage is < 0 or >= DestroyStages) {
            return false;
        }
        EntityTexture? texture = _textures.Get($"minecraft:textures/block/destroy_stage_{stage}.png");
        IBlock state = level.GetBlock(x, y, z);
        if (!_models.TryGetValue(state, out BakedBlockModel? model)) {
            model = _pack.BlockModel(state);
            _models[state] = model;
        }
        if (texture == null || model == null) {
            return false;
        }
        BakedOption[] chosen = new BakedOption[model.Parts.Length];
        model.Choose(x, y, z, chosen);
        Vector3 origin = new((float)(x - camera.Position.X), (float)(y - camera.Position.Y), (float)(z - camera.Position.Z));
        ModelDrawState draw = new(texture, 0xFFFFFFFF, 15, 15, 0);
        Span<Vector3> corners = stackalloc Vector3[4];
        Span<Vector2> uvs = stackalloc Vector2[4];
        foreach (BakedOption option in chosen) {
            foreach (BakedQuad quad in option.Quads) {
                Matrix4x4 projection = Projections[quad.Direction];
                float minU = float.MaxValue, minV = float.MaxValue;
                for (int i = 0; i < 4; i++) {
                    Vector3 projected = Vector3.Transform(quad.Positions[i], projection);
                    uvs[i] = new Vector2(-projected.X, -projected.Y);
                    minU = MathF.Min(minU, uvs[i].X);
                    minV = MathF.Min(minV, uvs[i].Y);
                    corners[i] = origin + quad.Positions[i];
                }
                // The crumbling texture repeats, and a face that projects to negative coordinates is
                // the same tile one over. The atlas cannot repeat, so the whole quad moves back into
                // the tile instead; a face that spans more than one, which only a model reaching past
                // its block has, clamps at the tile's edge.
                Vector2 shift = new(MathF.Floor(minU + 1e-4F), MathF.Floor(minV + 1e-4F));
                for (int i = 0; i < 4; i++) {
                    uvs[i] = Vector2.Clamp(uvs[i] - shift, Vector2.Zero, Vector2.One);
                }
                batch.Quad(corners, uvs, Directions.Normals[quad.Direction], draw);
            }
        }
        return true;
    }
}
