using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using SchemaQuaternion = Minecraft.Schemas.Quaternion;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>DisplayEntityRenderState</c>.</summary>
public abstract class DisplayEntityRenderState : EntityRenderState {
    public DisplayRenderer.RenderState? RenderState;
    public float InterpolationProgress;
    public float EntityYRot;
    public float EntityXRot;
    public float CameraYRot;
    public float CameraXRot;

    public abstract bool HasSubState();
}

/// <summary><c>BlockDisplayEntityRenderState</c>.</summary>
public class BlockDisplayEntityRenderState : DisplayEntityRenderState {
    public IBlock? BlockModel;

    public override bool HasSubState() => BlockModel != null;
}

/// <summary><c>ItemDisplayEntityRenderState</c>.</summary>
public class ItemDisplayEntityRenderState : DisplayEntityRenderState {
    public ItemStack? Item;
    public ItemDisplayContext ItemTransform;

    public override bool HasSubState() => Item != null && !Item.IsAir();
}

/// <summary>
/// <c>DisplayRenderer</c> and the client half of <c>Display</c>: the render state rebuilt on the tick after
/// its data changes, its transformation interpolated from where the last one had got to. The block or
/// item it shows is read each frame rather than when the render state is rebuilt, which shows a change
/// up to a tick early. Text displays are not drawn: nothing draws text in the world yet.
/// </summary>
public static class DisplayRenderer {
    /// <summary><c>com.mojang.math.Transformation</c> in its decomposed form.</summary>
    public readonly record struct Transformation(Vector3 Translation, Quaternion LeftRotation, Vector3 Scale, Quaternion RightRotation) {
        /// <summary><c>slerp</c>.</summary>
        public Transformation Slerp(Transformation that, float progress) => new(
            Vector3.Lerp(Translation, that.Translation, progress),
            JomlSlerp(LeftRotation, that.LeftRotation, progress),
            Vector3.Lerp(Scale, that.Scale, progress),
            JomlSlerp(RightRotation, that.RightRotation, progress));

        /// <summary><c>PoseStack.mulPose(Transformation)</c>: <c>compose</c>'s translation, rotation, scale, rotation.</summary>
        public void Apply(PoseStack pose) {
            pose.Translate(Translation);
            pose.Rotate(CameraOrientation.JomlRotation(LeftRotation.X, LeftRotation.Y, LeftRotation.Z, LeftRotation.W));
            pose.Scale(Scale.X, Scale.Y, Scale.Z);
            pose.Rotate(CameraOrientation.JomlRotation(RightRotation.X, RightRotation.Y, RightRotation.Z, RightRotation.W));
        }

        /// <summary>JOML's <c>Quaternionf.slerp</c>, which takes the short way round without normalising.</summary>
        private static Quaternion JomlSlerp(Quaternion a, Quaternion b, float alpha) {
            float cosom = a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
            float absCosom = Math.Abs(cosom);
            float scale0, scale1;
            if (1.0F - absCosom > 1.0E-6F) {
                float sinSqr = 1.0F - absCosom * absCosom;
                float sinom = 1.0F / MathF.Sqrt(sinSqr);
                float omega = MathF.Atan2(sinSqr * sinom, absCosom);
                scale0 = (float)(Math.Sin((1.0 - alpha) * omega) * sinom);
                scale1 = (float)(Math.Sin(alpha * omega) * sinom);
            }
            else {
                scale0 = 1.0F - alpha;
                scale1 = alpha;
            }
            scale1 = cosom >= 0.0F ? scale1 : -scale1;
            return new Quaternion(scale0 * a.X + scale1 * b.X, scale0 * a.Y + scale1 * b.Y, scale0 * a.Z + scale1 * b.Z, scale0 * a.W + scale1 * b.W);
        }
    }

    /// <summary><c>Display.BillboardConstraints</c>, by id.</summary>
    public enum BillboardConstraints : byte {
        Fixed,
        Vertical,
        Horizontal,
        Center
    }

    /// <summary><c>Display.RenderState</c>, without the shadow, which nothing draws.</summary>
    public sealed record RenderState(Transformation Previous, Transformation Current, bool Interpolates, BillboardConstraints BillboardConstraints, int BrightnessOverride) {
        /// <summary><c>TransformationInterpolator.get</c>, or the constant one's.</summary>
        public Transformation GetTransformation(float progress) => !Interpolates || progress >= 1.0 ? Current : Previous.Slerp(Current, progress);
    }

    private static readonly int[] RenderStateIds = [
        EntityDataFields.Display.Translation.Index, EntityDataFields.Display.Scale.Index, EntityDataFields.Display.LeftRotation.Index,
        EntityDataFields.Display.RightRotation.Index, EntityDataFields.Display.BillboardRenderConstraints.Index,
        EntityDataFields.Display.BrightnessOverride.Index, EntityDataFields.Display.ShadowRadius.Index, EntityDataFields.Display.ShadowStrength.Index
    ];

    /// <summary>What <c>Display</c> keeps on the client.</summary>
    public sealed class ClientDisplay {
        private readonly Dictionary<int, MetaField> _seen = new();
        public long InterpolationStartClientTick = int.MinValue;
        public int InterpolationDuration;
        public float LastProgress;
        public RenderState? State;

        /// <summary>Whether a packet has set the field since the last tick, as <c>onSyncedDataUpdated</c> hears.</summary>
        public bool Updated(ClientEntity entity, int index) {
            if (!entity.Metadata.TryGetValue(index, out MetaField? field) || (_seen.TryGetValue(index, out MetaField? seen) && ReferenceEquals(seen, field))) {
                return false;
            }
            _seen[index] = field;
            return true;
        }
    }

    public static ClientDisplay Display(ClientEntity entity) => (ClientDisplay)(entity.RendererData ??= new ClientDisplay());

    /// <summary><c>Display.tick</c>'s client side, with <c>onSyncedDataUpdated</c>'s flags folded in.</summary>
    public static void Tick(ClientEntity entity, ReadOnlySpan<int> subStateIds) {
        ClientDisplay display = Display(entity);
        bool updateStartTick = display.Updated(entity, EntityDataFields.Display.TransformationInterpolationStartDeltaTicks.Index);
        bool updateInterpolationDuration = display.Updated(entity, EntityDataFields.Display.TransformationInterpolationDuration.Index);
        bool updateRenderState = false;
        foreach (int id in RenderStateIds) {
            updateRenderState |= display.Updated(entity, id);
        }
        foreach (int id in subStateIds) {
            updateRenderState |= display.Updated(entity, id);
        }
        if (updateStartTick) {
            int interpolationStartDelta = entity.Get(EntityDataFields.Display.TransformationInterpolationStartDeltaTicks);
            display.InterpolationStartClientTick = entity.TickCount + interpolationStartDelta;
        }
        if (updateInterpolationDuration) {
            display.InterpolationDuration = entity.Get(EntityDataFields.Display.TransformationInterpolationDuration);
        }
        if (updateRenderState) {
            bool shouldInterpolate = display.InterpolationDuration != 0;
            Transformation current = CreateTransformation(entity);
            display.State = new RenderState(
                shouldInterpolate && display.State != null ? display.State.GetTransformation(display.LastProgress) : current,
                current,
                shouldInterpolate && display.State != null,
                (BillboardConstraints)Math.Clamp((int)entity.Get(EntityDataFields.Display.BillboardRenderConstraints), 0, 3),
                entity.Get(EntityDataFields.Display.BrightnessOverride, -1));
        }
    }

    /// <summary><c>createTransformation</c>, from the synced fields or their defaults.</summary>
    private static Transformation CreateTransformation(ClientEntity entity) {
        Vec3<float> translation = entity.Get(EntityDataFields.Display.Translation, Vec3<float>.Zero);
        Vec3<float> scale = entity.Get(EntityDataFields.Display.Scale, Vec3<float>.One);
        SchemaQuaternion left = entity.Get(EntityDataFields.Display.LeftRotation, SchemaQuaternion.Identity);
        SchemaQuaternion right = entity.Get(EntityDataFields.Display.RightRotation, SchemaQuaternion.Identity);
        return new Transformation(new Vector3(translation.X, translation.Y, translation.Z), new Quaternion(left.X, left.Y, left.Z, left.W),
            new Vector3(scale.X, scale.Y, scale.Z), new Quaternion(right.X, right.Y, right.Z, right.W));
    }

    /// <summary><c>calculateInterpolationProgress</c>.</summary>
    private static float CalculateInterpolationProgress(ClientEntity entity, ClientDisplay display, float partialTickTime) {
        int duration = display.InterpolationDuration;
        if (duration <= 0) {
            return 1.0F;
        }
        float ticksSinceUpdate = entity.TickCount - display.InterpolationStartClientTick;
        float partialTicksSinceLastUpdate = ticksSinceUpdate + partialTickTime;
        // Mth.inverseLerp.
        float result = Mth.Clamp((partialTicksSinceLastUpdate - 0.0F) / (duration - 0.0F), 0.0F, 1.0F);
        display.LastProgress = result;
        return result;
    }

    /// <summary>The abstract <c>DisplayRenderer</c>.</summary>
    public abstract class Base<ST> : EntityRenderer<ST> where ST : DisplayEntityRenderState, new() {
        protected abstract ReadOnlySpan<int> SubStateIds { get; }

        public override void Tick(ClientEntity entity) => DisplayRenderer.Tick(entity, SubStateIds);

        /// <summary><c>Display.shouldRenderAtSqrDistance</c>.</summary>
        public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
            double range = entity.Get(EntityDataFields.Display.ViewRange, 1.0F) * 64.0 * ViewScale;
            return distanceSqr < range * range;
        }

        /// <summary><c>affectedByCulling</c>: <c>updateCulling</c> turns culling off while either size is zero, as it is by default.</summary>
        public override bool AffectedByCulling(ClientEntity entity) =>
            entity.Get(EntityDataFields.Display.Width) != 0.0F && entity.Get(EntityDataFields.Display.Height) != 0.0F;

        public override (Vector3 Min, Vector3 Max)? BoundingBoxForCulling(ClientEntity entity) {
            float w = entity.Get(EntityDataFields.Display.Width) / 2.0F;
            return (new Vector3(-w, 0, -w), new Vector3(w, entity.Get(EntityDataFields.Display.Height), w));
        }

        public override void Submit(ST state, PoseStack pose, EntityRenderContext context) {
            RenderState? renderState = state.RenderState;
            if (renderState != null && state.HasSubState()) {
                float interpolationProgress = state.InterpolationProgress;
                pose.Push();
                CalculateOrientation(renderState, state, pose);
                renderState.GetTransformation(interpolationProgress).Apply(pose);
                SubmitInner(state, pose, context, interpolationProgress);
                pose.Pop();
            }
        }

        private static void CalculateOrientation(RenderState renderState, ST state, PoseStack pose) {
            (float y, float x) = renderState.BillboardConstraints switch {
                BillboardConstraints.Fixed => (-Mth.DegToRad * state.EntityYRot, Mth.DegToRad * state.EntityXRot),
                BillboardConstraints.Horizontal => (-Mth.DegToRad * state.EntityYRot, Mth.DegToRad * TransformXRot(state.CameraXRot)),
                BillboardConstraints.Vertical => (-Mth.DegToRad * TransformYRot(state.CameraYRot), Mth.DegToRad * state.EntityXRot),
                _ => (-Mth.DegToRad * TransformYRot(state.CameraYRot), Mth.DegToRad * TransformXRot(state.CameraXRot))
            };
            // rotationYXZ(y, x, 0).
            pose.RotateY(y);
            pose.RotateX(x);
        }

        private static float TransformYRot(float cameraYRot) => cameraYRot - 180.0F;

        private static float TransformXRot(float cameraXRot) => -cameraXRot;

        protected abstract void SubmitInner(ST state, PoseStack pose, EntityRenderContext context, float interpolationProgress);

        public override void ExtractRenderState(ClientEntity entity, ST state, float partialTick, EntityRenderContext context) {
            base.ExtractRenderState(entity, state, partialTick, context);
            ClientDisplay display = Display(entity);
            state.RenderState = display.State;
            state.InterpolationProgress = CalculateInterpolationProgress(entity, display, partialTick);
            state.EntityYRot = GetYRot(entity, partialTick);
            state.EntityXRot = GetXRot(entity, partialTick);
            state.CameraXRot = context.Camera.Pitch;
            state.CameraYRot = context.Camera.Yaw;
            // getSkyLightLevel and getBlockLightLevel: LightCoordsUtil's packing, block in bits 4 to 7 and sky in 20 to 23.
            if (display.State is { BrightnessOverride: not -1 } overridden) {
                state.SkyLight = overridden.BrightnessOverride >> 20 & 15;
                state.BlockLight = entity.IsOnFire ? 15 : overridden.BrightnessOverride >> 4 & 15;
            }
        }
    }

    /// <summary><c>DisplayRenderer.BlockDisplayRenderer</c>.</summary>
    public sealed class BlockDisplayRenderer : Base<BlockDisplayEntityRenderState> {
        private static readonly int[] SubState = [EntityDataFields.BlockDisplay.BlockState.Index];

        private readonly BlockModelRenderer _blocks;

        public BlockDisplayRenderer(EntityRendererContext context) {
            _blocks = context.Blocks;
        }

        protected override ReadOnlySpan<int> SubStateIds => SubState;

        public override void ExtractRenderState(ClientEntity entity, BlockDisplayEntityRenderState state, float partialTick, EntityRenderContext context) {
            base.ExtractRenderState(entity, state, partialTick, context);
            IBlock? block = entity.Get(EntityDataFields.BlockDisplay.BlockState);
            state.BlockModel = block is { Air: false } ? block : null;
        }

        protected override void SubmitInner(BlockDisplayEntityRenderState state, PoseStack pose, EntityRenderContext context, float interpolationProgress) =>
            _blocks.Render(state.BlockModel!, pose, context.Batch, state.SkyLight, state.BlockLight);
    }

    /// <summary><c>DisplayRenderer.ItemDisplayRenderer</c>.</summary>
    public sealed class ItemDisplayRenderer : Base<ItemDisplayEntityRenderState> {
        private static readonly int[] SubState = [EntityDataFields.ItemDisplay.ItemStack.Index, EntityDataFields.ItemDisplay.ItemDisplayId.Index];

        private readonly ItemRenderer _items;

        public ItemDisplayRenderer(EntityRendererContext context) {
            _items = context.Items;
        }

        protected override ReadOnlySpan<int> SubStateIds => SubState;

        public override void ExtractRenderState(ClientEntity entity, ItemDisplayEntityRenderState state, float partialTick, EntityRenderContext context) {
            base.ExtractRenderState(entity, state, partialTick, context);
            state.Item = entity.Get(EntityDataFields.ItemDisplay.ItemStack);
            // ItemDisplayContext.BY_ID, which reads an id out of range as NONE; the enum lists the contexts in id order.
            int id = entity.Get(EntityDataFields.ItemDisplay.ItemDisplayId);
            state.ItemTransform = id is >= 0 and <= (int)ItemDisplayContext.OnShelf ? (ItemDisplayContext)id : ItemDisplayContext.None;
        }

        protected override void SubmitInner(ItemDisplayEntityRenderState state, PoseStack pose, EntityRenderContext context, float interpolationProgress) {
            pose.RotateY(MathF.PI);
            _items.Render(state.Item, state.ItemTransform, pose, context.Batch, state.SkyLight, state.BlockLight, state.Entity);
        }
    }
}
