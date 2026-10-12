using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>VillagerProfessionLayer</c>: the type, profession and level textures over the base skin.</summary>
public class VillagerProfessionLayer<S, M> : RenderLayer<S, M>
    where S : LivingEntityRenderState, IVillagerDataHolderRenderState, new()
    where M : EntityModel<S>, IVillagerLikeModel<S> {
    private static readonly string[] LevelLocations = ["stone", "iron", "gold", "emerald", "diamond"];

    private enum Hat {
        None,
        Partial,
        Full
    }

    private readonly Dictionary<string, Hat> _hatCache = new();
    private readonly GraphicalClient.Assets.ResourcePacks.ResourcePackSource _pack;
    private readonly string _path;
    private readonly M _noHatModel, _noHatBabyModel;

    public VillagerProfessionLayer(LivingEntityRenderer<S, M> parent, GraphicalClient.Assets.ResourcePacks.ResourcePackSource pack, string path, M noHatModel,
        M noHatBabyModel) : base(parent) {
        _pack = pack;
        _path = path;
        _noHatModel = noHatModel;
        _noHatBabyModel = noHatBabyModel;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        if (state.IsInvisible || state.GetVillagerData() is not { } villagerData) {
            return;
        }
        // A holder with no key draws the missing texture in vanilla; an id this side cannot name is left out.
        Identifier? type = context.Client.Registry.VillagerTypes.Contains(villagerData.Type)
            ? context.Client.Registry.VillagerTypes.NameOf(villagerData.Type)
            : (Identifier?)null;
        string? professionKey = VillagerProfessions.KeyOf(villagerData.Profession);
        Identifier? profession = professionKey == null ? (Identifier?)null : new Identifier("minecraft", professionKey);
        Hat typeHat = GetHatData("type", type);
        Hat professionHat = GetHatData("profession", profession);
        M model = Parent.CurrentModel;
        bool typeHatVisible = professionHat == Hat.None || (professionHat == Hat.Partial && typeHat != Hat.Full);
        M noHatModel = state.IsBaby ? _noHatBabyModel : _noHatModel;
        if (type is { } typeKey) {
            RenderColoredCutoutModel(typeHatVisible ? model : noHatModel, GetIdentifier(state.IsBaby ? "baby" : "type", typeKey), pose, context, state, 0xFFFFFFFF);
        }
        if (villagerData.Profession != VillagerProfessions.None && !state.IsBaby && profession is { } professionId) {
            RenderColoredCutoutModel(model, GetIdentifier("profession", professionId), pose, context, state, 0xFFFFFFFF);
            if (villagerData.Profession != VillagerProfessions.Nitwit) {
                string level = LevelLocations[Math.Clamp(villagerData.Level, 1, LevelLocations.Length) - 1];
                RenderColoredCutoutModel(model, GetIdentifier("profession_level", new Identifier("minecraft", level)), pose, context, state, 0xFFFFFFFF);
            }
        }
    }

    private string GetIdentifier(string type, Identifier key) => $"{key.Namespace}:textures/entity/{_path}/{type}/{key.Key}.png";

    /// <summary><c>getHatData</c>: the <c>villager</c> section of the texture's <c>.mcmeta</c>.</summary>
    private Hat GetHatData(string name, Identifier? key) {
        if (key is not { } id) {
            return Hat.None;
        }
        string file = $"assets/{id.Namespace}/textures/entity/{_path}/{name}/{id.Key}.png.mcmeta";
        if (_hatCache.TryGetValue(file, out Hat hat)) {
            return hat;
        }
        hat = Hat.None;
        if (_pack.ReadFile(file) is { } meta) {
            try {
                hat = (JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["villager"]?["hat"]?.Value<string>()) switch {
                    "partial" => Hat.Partial,
                    "full" => Hat.Full,
                    _ => Hat.None
                };
            }
            catch (Newtonsoft.Json.JsonException) { }
        }
        _hatCache[file] = hat;
        return hat;
    }
}
