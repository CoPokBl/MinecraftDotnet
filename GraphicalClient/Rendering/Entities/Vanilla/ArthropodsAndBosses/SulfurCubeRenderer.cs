using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SulfurCubeRenderState</c>. A null <see cref="ContainedBlock"/> is vanilla's empty <c>BlockModelRenderState</c>.</summary>
public sealed class SulfurCubeRenderState : SlimeRenderState {
    public IBlock? ContainedBlock;
    public float FuseRemainingTicks;
}

public sealed class SulfurCubeRenderer : AbstractCubeMobRenderer<SulfurCubeRenderState, SulfurCubeModel> {
    private const string SulfurCubeLocation = "minecraft:textures/entity/sulfur_cube/sulfur_cube_outer.png";
    private const string SulfurCubeSmallLocation = "minecraft:textures/entity/sulfur_cube/sulfur_cube_outer_small.png";

    private readonly SulfurCubeModel _normalModel;
    private readonly SmallSulfurCubeModel _smallModel;

    public SulfurCubeRenderer(EntityRendererContext context) : base(new SulfurCubeModel(SulfurCubeModel.CreateOuterBodyLayer().BakeRoot())) {
        _normalModel = Model;
        _smallModel = new SmallSulfurCubeModel(SmallSulfurCubeModel.CreateOuterBodyLayer().BakeRoot());
        AddLayer(new SulfurCubeInnerLayer(this, context.Blocks));
    }

    /// <summary>
    /// <c>SulfurCube.fuse</c>: set from <c>MAX_FUSE</c> whenever it is synced and counted down by
    /// <c>tickFuse</c>. A sync that repeats the value it already held is not seen here, so a cube primed
    /// twice with the same fuse keeps counting from the first.
    /// </summary>
    private sealed class SulfurCubeData : CubeMobData {
        public int Fuse = -1;
        public int SyncedMaxFuse = -1;
    }

    protected override CubeMobData CreateData() => new SulfurCubeData();

    /// <summary><c>SulfurCube.tick</c>: <c>tickFuse</c>, then the squish.</summary>
    public override void Tick(ClientEntity entity) {
        SulfurCubeData data = (SulfurCubeData)(entity.RendererData ??= CreateData());
        int maxFuse = entity.Get(EntityDataFields.SulfurCube.MaxFuse, -1);
        if (maxFuse != data.SyncedMaxFuse) {
            data.SyncedMaxFuse = maxFuse;
            data.Fuse = maxFuse;
        }
        if (data.Fuse > 0) {
            data.Fuse--;
        }
        base.Tick(entity);
    }

    public override void Submit(SulfurCubeRenderState state, PoseStack pose, EntityRenderContext context) {
        Model = state.IsBaby ? _smallModel : _normalModel;
        base.Submit(state, pose, context);
    }

    protected override void Scale(SulfurCubeRenderState state, PoseStack pose) {
        DownscaleSlightly(pose);
        base.Scale(state, pose);
        float fuse = state.FuseRemainingTicks;
        if (fuse < 10.0F && fuse > 0.0F) {
            float s = 1.0F + GetSwellAmount(fuse);
            pose.Scale(s, s, s);
        }
        float vOffset = state.IsBaby ? 1.24F : 0.98F;
        float extraDownscale = state.IsBaby ? 1.0F : 0.5F;
        float onePixelUpIfVisible = (state.IsInvisible ? 0.0F : 1.0F) / 16.0F;
        pose.Scale(extraDownscale, extraDownscale, extraDownscale);
        pose.Translate(-0.0F, vOffset - onePixelUpIfVisible, -0.0F);
    }

    /// <summary><c>TntRenderer.getSwellAmount</c>.</summary>
    private static float GetSwellAmount(float fuse) {
        float g = 1.0F - fuse / 10.0F;
        g = Mth.Clamp(g, 0.0F, 1.0F);
        g *= g;
        g *= g;
        return g * 0.3F;
    }

    /// <summary><c>TntRenderer.isLit</c>.</summary>
    public static bool IsLit(float fuse) => !(fuse < 0.0F) && (int)(fuse / 5.0F) % 2 == 0;

    public override string GetTextureLocation(SulfurCubeRenderState state) => state.IsBaby ? SulfurCubeSmallLocation : SulfurCubeLocation;

    public override void ExtractRenderState(ClientEntity entity, SulfurCubeRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        int fuse = entity.RendererData is SulfurCubeData data ? data.Fuse : -1;
        state.FuseRemainingTicks = fuse >= 0 ? fuse - partialTick + 1.0F : 0.0F;
        state.ContainedBlock = null;
        ItemStack containedBlock = entity.GetItemBySlot(EquipmentSlot.Body);
        if (!containedBlock.IsAir() && containedBlock.Type.CorrespondingBlock is { } blockId && context.Level.Registry.Blocks.Contains(blockId)) {
            IBlock block = context.Level.Registry.Blocks[blockId];
            state.ContainedBlock = ApplyBlockStateProperties(block, containedBlock.GetOrDefault(DataComponent.BlockState, []));
        }
    }

    /// <summary><c>BlockItemStateProperties.apply</c>: each named property the block has and the value is valid for.</summary>
    private static IBlock ApplyBlockStateProperties(IBlock block, Dictionary<string, string> properties) {
        if (properties.Count == 0) {
            return block;
        }
        Dictionary<string, INbtTag> state = block.ToStateNbt().Children.ToDictionary(c => c.key, c => c.child);
        bool changed = false;
        foreach ((string name, string value) in properties) {
            if (state.ContainsKey(name)) {
                state[name] = new StringTag(value);
                changed = true;
            }
        }
        if (!changed) {
            return block;
        }
        try {
            return block.WithState(new CompoundTag(state));
        }
        catch (Exception) {
            // An invalid value leaves vanilla's state as it was.
            return block;
        }
    }

    protected override void ApplySizeAndSquish(SulfurCubeRenderState state, PoseStack pose) {
        float size = state.Size;
        float ss = state.ContainedBlock == null ? state.Squish / (size * 0.5F + 1.0F) : 0.0F;
        float w = 1.0F / (ss + 1.0F);
        pose.Scale(w * size, 1.0F / w * size, w * size);
    }
}
