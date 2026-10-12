using ClientLib.Entities;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>ItemEntityRenderState</c> with its <c>ItemClusterRenderState</c>.</summary>
public class ItemEntityRenderState : EntityRenderState {
    public ItemStackModel? Item;
    public int Count;
    public int Seed;
    public float BobOffset;
}

/// <summary><c>ItemEntityRenderer</c>: a dropped stack bobbing and turning, more copies the bigger it is.</summary>
public sealed class ItemEntityRenderer : EntityRenderer<ItemEntityRenderState> {
    private const float ItemMinHoverHeight = 0.0625F;
    private const float FlatItemDepthThreshold = 0.0625F;

    private readonly ItemRenderer _items;

    public ItemEntityRenderer(EntityRendererContext context) : this(context.Items) { }

    public ItemEntityRenderer(ItemRenderer items) {
        _items = items;
        ShadowRadius = 0.15F;
    }

    /// <summary><c>ItemEntity.bobOffs</c>, drawn from the entity's own random when the client creates it.</summary>
    private sealed class ClientState {
        public readonly float BobOffset = Random.Shared.NextSingle() * MathF.PI * 2.0F;
    }

    public override void ExtractRenderState(ClientEntity entity, ItemEntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        entity.RendererData ??= new ClientState();
        state.BobOffset = ((ClientState)entity.RendererData).BobOffset;
        ExtractItemGroupRenderState(state, entity.Get(EntityDataFields.ItemEntity.Item), _items, context, entity);
    }

    /// <summary><c>ItemEntity.getVisualRotationYInDegrees</c>'s spin: <c>getSpin(age + 0.5, bobOffs)</c>.</summary>
    public static float Spin(ClientEntity entity) => (entity.TickCount + 0.5F) / 20.0F + ((entity.RendererData as ClientState)?.BobOffset ?? 0.0F);

    /// <summary><c>ItemClusterRenderState.extractItemGroupRenderState</c>, the stack's model read for <paramref name="owner"/>.</summary>
    public static void ExtractItemGroupRenderState(ItemEntityRenderState state, ItemStack? stack, ItemRenderer items, EntityRenderContext context,
        ClientEntity? owner = null) {
        bool empty = stack == null || stack.IsAir();
        state.Item = empty ? null : items.Resolve(stack!, ItemDisplayContext.Ground, owner);
        state.Count = RenderedAmount(stack?.Count ?? 0);
        state.Seed = empty ? 187 : context.Client.Registry.Items.GetProtocolId(stack!.Type) + stack.GetOrDefault(DataComponent.Damage, 0);
    }

    /// <summary><c>ItemClusterRenderState.getRenderedAmount</c>.</summary>
    private static int RenderedAmount(int count) => count <= 1 ? 1 : count <= 16 ? 2 : count <= 32 ? 3 : count <= 48 ? 4 : 5;

    public override void Submit(ItemEntityRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Item is not { } item) {
            return;
        }
        pose.Push();
        (System.Numerics.Vector3 min, System.Numerics.Vector3 max) = item.ModelBoundingBox;
        float minOffsetY = -min.Y + ItemMinHoverHeight;
        float bob = Mth.Sin(state.AgeInTicks / 10.0F + state.BobOffset) * 0.1F + 0.1F;
        pose.Translate(0, bob + minOffsetY, 0);
        // ItemEntity.getSpin.
        pose.RotateY(state.AgeInTicks / 20.0F + state.BobOffset);
        SubmitMultipleFromCount(_items, pose, context.Batch, item, state.Count, state.Seed, max.Z - min.Z, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    /// <summary><c>ItemEntityRenderer.submitMultipleFromCount</c>, for any renderer drawing an item cluster.</summary>
    public static void SubmitMultipleFromCount(ItemRenderer items, PoseStack pose, IModelSink sink, ItemStackModel item, int count, int seed, float modelDepth,
        float skyLight, float blockLight) {
        if (count == 0) {
            return;
        }
        JavaRandom random = new(seed);
        if (modelDepth > FlatItemDepthThreshold) {
            Draw();
            for (int i = 1; i < count; i++) {
                pose.Push();
                float xo = (random.NextFloat() * 2.0F - 1.0F) * 0.15F;
                float yo = (random.NextFloat() * 2.0F - 1.0F) * 0.15F;
                float zo = (random.NextFloat() * 2.0F - 1.0F) * 0.15F;
                pose.Translate(xo, yo, zo);
                Draw();
                pose.Pop();
            }
            return;
        }
        float offsetZ = modelDepth * 1.5F;
        pose.Translate(0, 0, -(offsetZ * (count - 1) / 2.0F));
        Draw();
        pose.Translate(0, 0, offsetZ);
        for (int i = 1; i < count; i++) {
            pose.Push();
            float xo = (random.NextFloat() * 2.0F - 1.0F) * 0.15F * 0.5F;
            float yo = (random.NextFloat() * 2.0F - 1.0F) * 0.15F * 0.5F;
            pose.Translate(xo, yo, 0);
            Draw();
            pose.Pop();
            pose.Translate(0, 0, offsetZ);
        }

        void Draw() => items.Submit(item, ItemDisplayContext.Ground, pose, sink, skyLight, blockLight);
    }
}
