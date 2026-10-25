using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
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

/// <summary><c>TextDisplayEntityRenderState</c>.</summary>
public class TextDisplayEntityRenderState : DisplayEntityRenderState {
    public DisplayRenderer.TextRenderState? TextRenderState;

    public override bool HasSubState() => TextRenderState != null;
}

/// <summary>
/// <c>DisplayRenderer</c> and the client half of <c>Display</c>: the render state rebuilt on the tick after
/// its data changes, its transformation interpolated from where the last one had got to. The block or
/// item it shows is read each frame rather than when the render state is rebuilt, which shows a change
/// up to a tick early.
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

    /// <summary><c>Display.RenderState</c>: each interpolated field is its last value and the one it moves to, or only the second when it does not move.</summary>
    public sealed record RenderState(Transformation Previous, Transformation Current, bool Interpolates, BillboardConstraints BillboardConstraints, int BrightnessOverride,
        float ShadowRadiusFrom, float ShadowRadiusTo, float ShadowStrengthFrom, float ShadowStrengthTo) {
        /// <summary><c>TransformationInterpolator.get</c>, or the constant one's.</summary>
        public Transformation GetTransformation(float progress) => !Interpolates || progress >= 1.0 ? Current : Previous.Slerp(Current, progress);

        /// <summary><c>LinearFloatInterpolator.get</c>, or the constant one's.</summary>
        public float ShadowRadius(float progress) => Interpolates ? Mth.Lerp(progress, ShadowRadiusFrom, ShadowRadiusTo) : ShadowRadiusTo;

        /// <inheritdoc cref="ShadowRadius"/>
        public float ShadowStrength(float progress) => Interpolates ? Mth.Lerp(progress, ShadowStrengthFrom, ShadowStrengthTo) : ShadowStrengthTo;
    }

    /// <summary>
    /// <c>Display.TextDisplay.TextRenderState</c>. The opacity moves through its signed byte values, as
    /// <c>LinearIntInterpolator</c> runs, so a fade from opaque (-1) passes through clear.
    /// </summary>
    public sealed record TextRenderState(TextComponent Text, int LineWidth, int OpacityFrom, int OpacityTo, int BackgroundFrom, int BackgroundTo, bool Interpolates,
        byte Flags) {
        /// <summary><c>Mth.lerpInt</c>, as <c>LinearIntInterpolator.get</c> uses it.</summary>
        public int TextOpacity(float progress) => Interpolates ? OpacityFrom + Mth.Floor(progress * (OpacityTo - OpacityFrom)) : OpacityTo;

        /// <summary><c>ColorInterpolator.get</c>: <c>ARGB.srgbLerp</c>, each channel by <c>lerpInt</c>.</summary>
        public int BackgroundColor(float progress) {
            if (!Interpolates) {
                return BackgroundTo;
            }
            int Channel(int shift) {
                int from = BackgroundFrom >> shift & 0xFF, to = BackgroundTo >> shift & 0xFF;
                return (from + Mth.Floor(progress * (to - from))) << shift;
            }
            return Channel(24) | Channel(16) | Channel(8) | Channel(0);
        }
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
        public TextRenderState? Text;

        /// <summary>The render state filled again each frame, which a display drawn by the hundred would otherwise allocate each time.</summary>
        public DisplayEntityRenderState? Extracted;

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

    /// <summary>
    /// <c>Display.tick</c>'s client side, with <c>onSyncedDataUpdated</c>'s flags folded in. <paramref name="updateSubState"/>
    /// is <c>updateRenderSubState</c>, given whether to interpolate and the progress the last frame reached.
    /// </summary>
    public static void Tick(ClientEntity entity, ReadOnlySpan<int> subStateIds, Action<ClientEntity, ClientDisplay, bool, float>? updateSubState = null) {
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
            RenderState? previous = shouldInterpolate ? display.State : null;
            float shadowRadius = entity.Get(EntityDataFields.Display.ShadowRadius, 0.0F);
            float shadowStrength = entity.Get(EntityDataFields.Display.ShadowStrength, 1.0F);
            float progress = display.LastProgress;
            // BillboardConstraints.BY_ID reads an id out of range as FIXED.
            int billboard = entity.Get(EntityDataFields.Display.BillboardRenderConstraints);
            display.State = new RenderState(
                previous?.GetTransformation(progress) ?? current,
                current,
                previous != null,
                billboard is >= 0 and <= 3 ? (BillboardConstraints)billboard : BillboardConstraints.Fixed,
                entity.Get(EntityDataFields.Display.BrightnessOverride, -1),
                previous?.ShadowRadius(progress) ?? shadowRadius, shadowRadius,
                previous?.ShadowStrength(progress) ?? shadowStrength, shadowStrength);
            updateSubState?.Invoke(entity, display, shouldInterpolate, progress);
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

        public override void Tick(ClientEntity entity) => DisplayRenderer.Tick(entity, SubStateIds, UpdateRenderSubState);

        protected override ST RenderStateFor(ClientEntity entity) {
            ClientDisplay display = Display(entity);
            if (display.Extracted is not ST state) {
                state = CreateRenderState();
                display.Extracted = state;
            }
            return state;
        }

        /// <summary><c>updateRenderSubState</c>, for a display whose sub state interpolates.</summary>
        protected virtual void UpdateRenderSubState(ClientEntity entity, ClientDisplay display, bool shouldInterpolate, float progress) { }

        protected override float GetShadowRadius(ST state) => state.RenderState?.ShadowRadius(state.InterpolationProgress) ?? 0.0F;

        protected override float GetShadowStrength(ST state) => state.RenderState?.ShadowStrength(state.InterpolationProgress) ?? 0.0F;

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
            // The override replaces the burning entity's full block light as well.
            if (display.State is { BrightnessOverride: not -1 } overridden) {
                state.SkyLight = overridden.BrightnessOverride >> 20 & 15;
                state.BlockLight = overridden.BrightnessOverride >> 4 & 15;
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

    /// <summary><c>DisplayRenderer.TextDisplayRenderer</c>: the text goes to the frame's <see cref="TextDisplayBatch"/>, which lays it out once.</summary>
    public sealed class TextDisplayRenderer : Base<TextDisplayEntityRenderState> {
        private static readonly int[] SubState = [
            EntityDataFields.TextDisplay.Text.Index, EntityDataFields.TextDisplay.LineWidth.Index, EntityDataFields.TextDisplay.BackgroundColor.Index,
            EntityDataFields.TextDisplay.TextOpacity.Index, EntityDataFields.TextDisplay.StyleFlags.Index
        ];

        protected override ReadOnlySpan<int> SubStateIds => SubState;

        /// <summary><c>TextDisplay.updateRenderSubState</c>: <c>createInterpolatedTextRenderState</c> or <c>createFreshTextRenderState</c>.</summary>
        protected override void UpdateRenderSubState(ClientEntity entity, ClientDisplay display, bool shouldInterpolate, float progress) {
            TextComponent text = entity.Get(EntityDataFields.TextDisplay.Text) ?? TextComponent.Text("");
            int lineWidth = entity.Get(EntityDataFields.TextDisplay.LineWidth, 200);
            int opacity = entity.Get(EntityDataFields.TextDisplay.TextOpacity, (sbyte)-1);
            int background = entity.Get(EntityDataFields.TextDisplay.BackgroundColor, 0x40000000);
            byte flags = (byte)entity.Get(EntityDataFields.TextDisplay.StyleFlags);
            TextRenderState? previous = shouldInterpolate ? display.Text : null;
            display.Text = previous != null
                ? new TextRenderState(text, lineWidth, previous.TextOpacity(progress), opacity, previous.BackgroundColor(progress), background, true, flags)
                : new TextRenderState(text, lineWidth, opacity, opacity, background, background, false, flags);
        }

        public override void ExtractRenderState(ClientEntity entity, TextDisplayEntityRenderState state, float partialTick, EntityRenderContext context) {
            base.ExtractRenderState(entity, state, partialTick, context);
            state.TextRenderState = Display(entity).Text;
        }

        protected override void SubmitInner(TextDisplayEntityRenderState state, PoseStack pose, EntityRenderContext context, float interpolationProgress) =>
            context.TextDisplays?.Submit(state.Entity.Id, state.TextRenderState!, interpolationProgress, pose.Matrix, state.SkyLight, state.BlockLight);
    }
}
