using System.Numerics;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Newtonsoft.Json.Linq;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// The <c>minecraft:special</c> item renderers that draw a block entity's model: chests, shulker boxes,
/// banners, pots, conduits, heads, bells, books and copper golem statues, each the block entity
/// renderer's model with what the item definition or the stack says.
/// </summary>
public static class BlockEntitySpecialRenderers {
    /// <summary>The codecs <c>SpecialModelRenderers.bootstrap</c> registers for these, by type.</summary>
    public static void AddTo(Dictionary<Identifier, Func<JObject, ISpecialModelUnbaked?>> idMapper) {
        idMapper["minecraft:chest"] = json => json.Value<string>("texture") is { } texture
            ? new ChestSpecial(Identifier.Parse(texture), json.Value<float?>("openness") ?? 0.0F,
                json.Value<string>("chest_type") is { } type ? ChestTypeExtensions.FromString(type) : ChestType.Single)
            : null;
        idMapper["minecraft:shulker_box"] = json => json.Value<string>("texture") is { } texture
            ? new ShulkerBoxSpecial(Identifier.Parse(texture), json.Value<float?>("openness") ?? 0.0F)
            : null;
        idMapper["minecraft:banner"] = json => json.Value<string>("color") is { } color && ParseDye(color) is { } dye
            ? new BannerSpecial(dye, json.Value<string>("attachment") == "wall")
            : null;
        idMapper["minecraft:decorated_pot"] = _ => DecoratedPotSpecial.Instance;
        idMapper["minecraft:conduit"] = _ => ConduitSpecial.Instance;
        idMapper["minecraft:bell"] = _ => BellSpecial.Instance;
        idMapper["minecraft:book"] = json => new BookSpecial(json.Value<float?>("open_angle") ?? 0.0F, json.Value<float?>("page1") ?? 0.0F,
            json.Value<float?>("page2") ?? 0.0F);
        idMapper["minecraft:head"] = json => json.Value<string>("kind") is { } kind && ParseSkullKind(kind) is { } skull
            ? new HeadSpecial(skull, json.Value<string>("texture") is { } texture ? Identifier.Parse(texture) : (Identifier?)null, json.Value<float?>("animation") ?? 0.0F)
            : null;
        idMapper["minecraft:player_head"] = _ => PlayerHeadSpecial.Instance;
        idMapper["minecraft:copper_golem_statue"] = json => json.Value<string>("texture") is { } texture && json.Value<string>("pose") is { } pose
            && Enum.TryParse(pose, true, out CopperGolemStatuePose parsed)
            ? new CopperGolemStatueSpecial(Identifier.Parse(texture), parsed)
            : null;
    }

    private static DyeColor? ParseDye(string name) => Enum.TryParse(name.Replace("_", ""), true, out DyeColor dye) ? dye : null;

    private static SkullKind? ParseSkullKind(string name) => Enum.TryParse(name.Replace("_", ""), true, out SkullKind kind) ? kind : null;

    /// <summary>A renderer that reads nothing off the stack, <c>NoDataSpecialModelRenderer</c>.</summary>
    private abstract class NoData : SpecialModelRenderer<object> {
        public override object? ExtractArgument(ItemStack stack) => null;
    }

    /// <summary><c>ChestSpecialRenderer.Unbaked</c>.</summary>
    private sealed record ChestSpecial(Identifier Texture, float Openness, ChestType ChestType) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(context.Sprites, ChestModel.BakeAll().Select(ChestType),
            Sheets.ChestSprite(Texture), Openness);

        private sealed class Renderer(ISpriteGetter sprites, ChestModel model, SpriteId sprite, float openness) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
                model.SetupAnim(openness);
                model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(sprite), 0xFFFFFFFF, skyLight, blockLight, 0));
            }

            public override void GetExtents(Action<Vector3> output) {
                model.SetupAnim(openness);
                model.RootPart.GetExtentsForGui(new PoseStack(), output);
            }
        }
    }

    /// <summary><c>ShulkerBoxSpecialRenderer.Unbaked</c>.</summary>
    private sealed record ShulkerBoxSpecial(Identifier Texture, float Openness) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) =>
            new Renderer(new ShulkerBoxRenderer(context.Sprites), Openness, Sheets.ShulkerSprite(Texture));

        private sealed class Renderer(ShulkerBoxRenderer renderer, float openness, SpriteId sprite) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                renderer.Submit(pose, sink, skyLight, blockLight, openness, sprite);

            public override void GetExtents(Action<Vector3> output) => renderer.GetExtents(openness, output);
        }
    }

    /// <summary><c>BannerSpecialRenderer.Unbaked</c>: the colour is the item's, the patterns the stack's.</summary>
    private sealed record BannerSpecial(DyeColor BaseColor, bool Wall) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(new BannerRenderer(context.Sprites), BaseColor, Wall);

        private sealed class Renderer(BannerRenderer renderer, DyeColor baseColor, bool wall) : SpecialModelRenderer<BannerPatternsComponent.Layer[]> {
            public override BannerPatternsComponent.Layer[]? ExtractArgument(ItemStack stack) => stack.GetOrNull(DataComponent.BannerPatterns);

            public override void Submit(BannerPatternsComponent.Layer[]? patterns, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                renderer.SubmitBanner(pose, sink, skyLight, blockLight, wall, 0.0F, baseColor, patterns ?? []);

            public override void GetExtents(Action<Vector3> output) => renderer.GetExtents(output);

            public override string? IdentityOf(BannerPatternsComponent.Layer[]? patterns) =>
                patterns is not { Length: > 0 } ? null : "banner:" + string.Join("|", patterns.Select(l => l.Pattern.AssetId + "=" + l.Color));
        }
    }

    /// <summary><c>DecoratedPotSpecialRenderer.Unbaked</c>: the sherds are the stack's.</summary>
    private sealed record DecoratedPotSpecial : ISpecialModelUnbaked {
        public static readonly DecoratedPotSpecial Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(new DecoratedPotRenderer(context.Sprites));

        private sealed class Renderer(DecoratedPotRenderer renderer) : SpecialModelRenderer<IItem?[]> {
            public override IItem?[]? ExtractArgument(ItemStack stack) =>
                stack.GetOrNull(DataComponent.PotDecorations) is { } items ? ClientLib.World.BlockEntities.DecoratedPotBlockEntity.Decorations(items) : null;

            public override void Submit(IItem?[]? decorations, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                renderer.Submit(pose, sink, skyLight, blockLight, decorations ?? new IItem?[4]);

            public override void GetExtents(Action<Vector3> output) => renderer.GetExtents(output);

            public override string? IdentityOf(IItem?[]? decorations) =>
                decorations == null || decorations.All(d => d == null) ? null : "pot:" + string.Join("|", decorations.Select(d => d?.Identifier.ToString() ?? ""));
        }
    }

    /// <summary><c>ConduitSpecialRenderer.Unbaked</c>: the shell alone.</summary>
    private sealed record ConduitSpecial : ISpecialModelUnbaked {
        public static readonly ConduitSpecial Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(context.Sprites, ConduitRenderer.BakeShell());

        private sealed class Renderer(ISpriteGetter sprites, ModelPart model) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                model.Render(pose, sink, new ModelDrawState(sprites.Get(ConduitRenderer.ShellTexture), 0xFFFFFFFF, skyLight, blockLight, 0));

            public override void GetExtents(Action<Vector3> output) => model.GetExtentsForGui(new PoseStack(), output);
        }
    }

    /// <summary><c>BellSpecialRenderer.Unbaked</c>.</summary>
    private sealed record BellSpecial : ISpecialModelUnbaked {
        public static readonly BellSpecial Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(context.Sprites, new BellModel(BellModel.CreateBodyLayer().BakeRoot()));

        private sealed class Renderer(ISpriteGetter sprites, BellModel model) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
                model.SetupAnim(0.0F, null);
                model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(BellRenderer.BellTexture), 0xFFFFFFFF, skyLight, blockLight, 0));
            }

            public override void GetExtents(Action<Vector3> output) {
                model.SetupAnim(0.0F, null);
                model.RootPart.GetExtentsForGui(new PoseStack(), output);
            }
        }
    }

    /// <summary><c>BookSpecialRenderer.Unbaked</c>.</summary>
    private sealed record BookSpecial(float OpenAngle, float Page1, float Page2) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) =>
            new Renderer(context.Sprites, new BookModel(BookModel.CreateBodyLayer().BakeRoot()), new BookModel.State(OpenAngle * Mth.DegToRad, Page1, Page2));

        private sealed class Renderer(ISpriteGetter sprites, BookModel model, BookModel.State state) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
                model.SetupAnim(state);
                model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(EnchantTableRenderer.BookTexture), 0xFFFFFFFF, skyLight, blockLight, 0));
            }

            public override void GetExtents(Action<Vector3> output) {
                model.SetupAnim(state);
                model.RootPart.GetExtentsForGui(new PoseStack(), output);
            }
        }
    }

    /// <summary><c>SkullSpecialRenderer.Unbaked</c>: a texture override names a file under <c>textures/entity/</c>.</summary>
    private sealed record HeadSpecial(SkullKind Kind, Identifier? TextureOverride, float Animation) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) {
            SpriteId texture = TextureOverride is { } over
                ? Sheets.TextureSprite(new Identifier(over.Namespace, "textures/entity/" + over.Key + ".png"))
                : SkullBlockRenderer.SkinByType(Kind);
            return new Renderer(context.Sprites, SkullBlockRenderer.CreateModel(Kind), Animation, texture);
        }

        private sealed class Renderer(ISpriteGetter sprites, SkullModelBase model, float animation, SpriteId texture) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                SkullBlockRenderer.SubmitSkull(animation, pose, sink, skyLight, blockLight, model, sprites.Get(texture));

            public override void GetExtents(Action<Vector3> output) {
                model.SetupAnim(new SkullModelBase.State { AnimationPos = animation });
                model.RootPart.GetExtentsForGui(new PoseStack(), output);
            }
        }
    }

    /// <summary>
    /// <c>PlayerHeadSpecialRenderer.Unbaked</c>: the head in the skin of the stack's profile, which is the
    /// default skin its id picks until skins are downloaded.
    /// </summary>
    private sealed record PlayerHeadSpecial : ISpecialModelUnbaked {
        public static readonly PlayerHeadSpecial Instance = new();

        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) => new Renderer(context.Sprites, SkullBlockRenderer.CreateModel(SkullKind.Player));

        private sealed class Renderer(ISpriteGetter sprites, SkullModelBase model) : SpecialModelRenderer<ProfileComponent.Data> {
            public override ProfileComponent.Data? ExtractArgument(ItemStack stack) => stack.GetOrNull(DataComponent.Profile);

            public override void Submit(ProfileComponent.Data? profile, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
                SkullBlockRenderer.SubmitSkull(0.0F, pose, sink, skyLight, blockLight, model,
                    sprites.Get(SkullBlockRenderer.ProfileSkin(profile) ?? SkullBlockRenderer.SkinByType(SkullKind.Player)));

            public override void GetExtents(Action<Vector3> output) => model.RootPart.GetExtentsForGui(new PoseStack(), output);

            public override string? IdentityOf(ProfileComponent.Data? profile) => profile?.UniqueId is { } id ? "head:" + id : null;
        }
    }

    /// <summary><c>CopperGolemStatueSpecialRenderer.Unbaked</c>.</summary>
    private sealed record CopperGolemStatueSpecial(Identifier Texture, CopperGolemStatuePose Pose) : ISpecialModelUnbaked {
        public ISpecialModelRenderer Bake(SpecialModelBakingContext context) =>
            new Renderer(context.Sprites, new CopperGolemStatueModel(CopperGolemStatueModel.Layer(Pose).BakeRoot()), Sheets.TextureSprite(Texture));

        private sealed class Renderer(ISpriteGetter sprites, CopperGolemStatueModel model, SpriteId texture) : NoData {
            public override void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
                model.SetupAnim();
                model.RenderToBuffer(pose, sink, new ModelDrawState(sprites.Get(texture), 0xFFFFFFFF, skyLight, blockLight, 0));
            }

            public override void GetExtents(Action<Vector3> output) {
                model.SetupAnim();
                model.RootPart.GetExtentsForGui(new PoseStack(), output);
            }
        }
    }
}
