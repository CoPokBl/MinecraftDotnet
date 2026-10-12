using System.Runtime.CompilerServices;
using ClientLib.Entities;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Entities;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class SpawnerRenderState : BlockEntityRenderState {
    public ClientEntity? Entity;
    public EntityRenderState? DisplayEntity;
    public float Spin, Scale;
}

/// <summary>
/// <c>SpawnerRenderer</c> and <c>TrialSpawnerRenderer</c>: the mob the spawner will make, small and
/// turning in its cage. The mob is made from its type alone; the rest of its tag, such as a slime's
/// size, is not read.
/// </summary>
public sealed class SpawnerRenderer<E>(BlockEntityRendererContext context) : BlockEntityRenderer<E, SpawnerRenderState>
    where E : ClientBlockEntity, ISpinningMobHolder {
    private readonly ConditionalWeakTable<ClientBlockEntity, DisplayEntity> _displayEntities = new();

    private sealed record DisplayEntity(CompoundTag Tag, ClientEntity? Entity);

    public override void ExtractRenderState(E blockEntity, SpawnerRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        if (GetOrCreateDisplayEntity(blockEntity, render) is not { } entity) {
            return;
        }
        state.Entity = entity;
        if (context.Entities.RendererFor(entity) is { } renderer) {
            state.DisplayEntity = renderer.Extract(entity, partialTick, render);
            state.DisplayEntity.SkyLight = state.SkyLight;
            state.DisplayEntity.BlockLight = state.BlockLight;
        }
        state.Spin = (float)Mth.Lerp(partialTick, blockEntity.OSpin, blockEntity.Spin) * 10.0F;
        state.Scale = 0.53125F;
        float maxLength = (float)Math.Max(entity.Width, entity.Height);
        if (maxLength > 1.0) {
            state.Scale /= maxLength;
        }
    }

    /// <summary><c>getOrCreateDisplayEntity</c>: one entity per spawn data, made again when the data changes.</summary>
    private ClientEntity? GetOrCreateDisplayEntity(E blockEntity, EntityRenderContext render) {
        if (blockEntity.DisplayEntity is not { } tag) {
            return null;
        }
        if (_displayEntities.TryGetValue(blockEntity, out DisplayEntity? known) && ReferenceEquals(known.Tag, tag)) {
            return known.Entity;
        }
        ClientEntity? entity = null;
        Identifier id = Identifier.Parse(tag["id"]!.GetString());
        if (render.Client.Registry.EntityTypes.Contains(id)) {
            IEntityType type = render.Client.Registry.EntityTypes[id];
            entity = EntityKinds.Create(render.Client, type, Guid.Empty, 0);
            entity.Position = entity.OldPosition = new ClientLib.Maths.Vec3d(blockEntity.X + 0.5, blockEntity.Y, blockEntity.Z + 0.5);
        }
        _displayEntities.AddOrUpdate(blockEntity, new DisplayEntity(tag, entity));
        return entity;
    }

    public override void Submit(SpawnerRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.Entity is not { } entity) {
            return;
        }
        pose.Push();
        pose.Translate(0.5F, 0.4F, 0.5F);
        pose.RotateYDegrees(state.Spin);
        pose.Translate(0.0F, -0.2F, 0.0F);
        pose.RotateXDegrees(-30.0F);
        pose.Scale(state.Scale, state.Scale, state.Scale);
        if (state.DisplayEntity != null && context.Entities.RendererFor(entity) is { } renderer) {
            renderer.Submit(state.DisplayEntity, 0.0, 0.0, 0.0, pose, render);
        }
        else {
            context.Entities.Fallback.RenderPosed(entity, pose.Matrix, render.Batch, render.PartialTick, 0, 0, 0, state.SkyLight, state.BlockLight);
        }
        pose.Pop();
    }
}
