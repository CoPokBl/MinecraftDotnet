using System.Numerics;
using ClientLib;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.MapDecorationTypes;
using Minecraft.Packets.Play.ClientBound;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>MapRenderer</c> and <c>MapTextureManager</c>: a filled map's pixels as a texture in the entity atlas,
/// sent again whenever the server changes them, with its markers and their labels over it.
/// </summary>
public sealed class MapRenderer(EntityTextures textures, WorldText font) {
    private sealed class Instance {
        public EntityTexture? Texture;
        public ClientMapData? Data;
        public int Version;
    }

    /// <summary><c>MapDecorationType</c>'s <c>assetId</c> and <c>showOnItemFrame</c>, which the generated types do not carry.</summary>
    private static readonly Dictionary<IMapDecorationType, (string Asset, bool ShowOnItemFrame)> Decorations = new() {
        [MapDecorationType.Player] = ("player", false),
        [MapDecorationType.Frame] = ("frame", true),
        [MapDecorationType.RedMarker] = ("red_marker", false),
        [MapDecorationType.BlueMarker] = ("blue_marker", false),
        [MapDecorationType.TargetX] = ("target_x", true),
        [MapDecorationType.TargetPoint] = ("target_point", true),
        [MapDecorationType.PlayerOffMap] = ("player_off_map", false),
        [MapDecorationType.PlayerOffLimits] = ("player_off_limits", false),
        [MapDecorationType.Mansion] = ("woodland_mansion", true),
        [MapDecorationType.Monument] = ("ocean_monument", true),
        [MapDecorationType.BannerWhite] = ("white_banner", true),
        [MapDecorationType.BannerOrange] = ("orange_banner", true),
        [MapDecorationType.BannerMagenta] = ("magenta_banner", true),
        [MapDecorationType.BannerLightBlue] = ("light_blue_banner", true),
        [MapDecorationType.BannerYellow] = ("yellow_banner", true),
        [MapDecorationType.BannerLime] = ("lime_banner", true),
        [MapDecorationType.BannerPink] = ("pink_banner", true),
        [MapDecorationType.BannerGray] = ("gray_banner", true),
        [MapDecorationType.BannerLightGray] = ("light_gray_banner", true),
        [MapDecorationType.BannerCyan] = ("cyan_banner", true),
        [MapDecorationType.BannerPurple] = ("purple_banner", true),
        [MapDecorationType.BannerBlue] = ("blue_banner", true),
        [MapDecorationType.BannerBrown] = ("brown_banner", true),
        [MapDecorationType.BannerGreen] = ("green_banner", true),
        [MapDecorationType.BannerRed] = ("red_banner", true),
        [MapDecorationType.BannerBlack] = ("black_banner", true),
        [MapDecorationType.RedX] = ("red_x", true),
        [MapDecorationType.VillageDesert] = ("desert_village", true),
        [MapDecorationType.VillagePlains] = ("plains_village", true),
        [MapDecorationType.VillageSavanna] = ("savanna_village", true),
        [MapDecorationType.VillageSnowy] = ("snowy_village", true),
        [MapDecorationType.VillageTaiga] = ("taiga_village", true),
        [MapDecorationType.JungleTemple] = ("jungle_temple", true),
        [MapDecorationType.SwampHut] = ("swamp_hut", true),
        [MapDecorationType.TrialChambers] = ("trial_chambers", true)
    };

    private readonly Dictionary<int, Instance> _maps = new();

    public EntityTextures Textures => textures;

    /// <summary><c>prepareMapTexture</c>: the map's texture, its pixels sent again when the data changed since they last were.</summary>
    private EntityTexture? Texture(int id, ClientMapData data) {
        if (!_maps.TryGetValue(id, out Instance? instance)) {
            instance = new Instance();
            _maps[id] = instance;
        }
        instance.Texture ??= textures.GetNow($"map:{id}", () => new TextureImage(ClientMapData.Size, ClientMapData.Size, new byte[ClientMapData.Size * ClientMapData.Size * 4]));
        if (instance.Texture != null && (instance.Data != data || instance.Version != data.Version)) {
            byte[] rgba = new byte[ClientMapData.Size * ClientMapData.Size * 4];
            for (int i = 0; i < data.Colors.Length; i++) {
                uint argb = MapColors.FromPackedId(data.Colors[i]);
                rgba[i * 4] = (byte)(argb >> 16);
                rgba[i * 4 + 1] = (byte)(argb >> 8);
                rgba[i * 4 + 2] = (byte)argb;
                rgba[i * 4 + 3] = (byte)(argb >> 24);
            }
            textures.Replace(instance.Texture, rgba);
            instance.Data = data;
            instance.Version = data.Version;
        }
        return instance.Texture;
    }

    /// <summary>
    /// <c>render</c>: the map 128 units square from the pose's origin, then each marker, all but those
    /// <c>showOnItemFrame</c> leaves out when <paramref name="showOnlyFrame"/>, each a little nearer than
    /// the last, with its name under it.
    /// </summary>
    /// <param name="translucent">Where the labels' backgrounds blend; null leaves them out, for a pass that cannot blend.</param>
    public void Render(int id, ClientMapData data, PoseStack pose, IModelSink batch, IModelSink? translucent, bool showOnlyFrame, float skyLight,
        float blockLight) {
        // RenderTypes.text: lit, but with no side of it shaded darker than another.
        Vector3 normal = pose.TransformNormal(-Vector3.UnitZ);
        if (Texture(id, data) is { } texture) {
            Matrix4x4 m = pose.Matrix;
            batch.Quad([Vector3.Transform(new Vector3(0.0F, 128.0F, -0.01F), m), Vector3.Transform(new Vector3(128.0F, 128.0F, -0.01F), m),
                    Vector3.Transform(new Vector3(128.0F, 0.0F, -0.01F), m), Vector3.Transform(new Vector3(0.0F, 0.0F, -0.01F), m)],
                [new(0.0F, 1.0F), new(1.0F, 1.0F), new(1.0F, 0.0F), new(0.0F, 0.0F)], normal, new ModelDrawState(texture, 0xFFFFFFFF, skyLight, blockLight, 0));
        }
        int count = 0;
        foreach (ClientBoundMapDataPacket.Decoration decoration in data.Decorations) {
            (string asset, bool showOnItemFrame) = Decorations.GetValueOrDefault(decoration.Type, ("", false));
            if (showOnlyFrame && !showOnItemFrame) {
                continue;
            }
            pose.Push();
            pose.Translate(decoration.X / 2.0F + 64.0F, decoration.Z / 2.0F + 64.0F, -0.02F);
            pose.RotateZDegrees(decoration.Rotation * 360 / 16.0F);
            pose.Scale(4.0F, 4.0F, 3.0F);
            pose.Translate(-0.125F, 0.125F, 0.0F);
            EntityTexture sprite = textures.Get($"minecraft:textures/map/decorations/{asset}.png") ?? textures.Missing;
            float z = count * -0.001F;
            Matrix4x4 m = pose.Matrix;
            batch.Quad([Vector3.Transform(new Vector3(-1.0F, 1.0F, z), m), Vector3.Transform(new Vector3(1.0F, 1.0F, z), m),
                    Vector3.Transform(new Vector3(1.0F, -1.0F, z), m), Vector3.Transform(new Vector3(-1.0F, -1.0F, z), m)],
                [new(0.0F, 0.0F), new(1.0F, 0.0F), new(1.0F, 1.0F), new(0.0F, 1.0F)], normal, new ModelDrawState(sprite, 0xFFFFFFFF, skyLight, blockLight, 0));
            pose.Pop();
            if (decoration.Name is { } name) {
                List<TextRun> runs = TextFlattener.Flatten(name, 0xFFFFFF);
                float width = font.Width(runs);
                float scale = Math.Clamp(25.0F / width, 0.0F, 6.0F / 9.0F);
                pose.Push();
                pose.Translate(decoration.X / 2.0F + 64.0F - width * scale / 2.0F, decoration.Z / 2.0F + 64.0F + 4.0F, -0.025F);
                pose.Scale(scale, scale, -1.0F);
                pose.Translate(0.0F, 0.0F, 0.1F);
                // The background Font lays behind text drawn with one: a pixel round it, the line's height below.
                Matrix4x4 m2 = pose.Matrix;
                translucent?.Quad([Vector3.Transform(new Vector3(-1.0F, -1.0F, -0.01F), m2), Vector3.Transform(new Vector3(-1.0F, 9.0F, -0.01F), m2),
                        Vector3.Transform(new Vector3(width, 9.0F, -0.01F), m2), Vector3.Transform(new Vector3(width, -1.0F, -0.01F), m2)],
                    [new(0.5F, 0.5F), new(0.5F, 0.5F), new(0.5F, 0.5F), new(0.5F, 0.5F)], pose.TransformNormal(Vector3.UnitZ),
                    new ModelDrawState(textures.White, 0x80000000, skyLight, blockLight, 0));
                font.Draw(runs, 0.0F, 0.0F, 255, 0, pose, batch, skyLight, blockLight);
                pose.Pop();
            }
            count++;
        }
    }
}
