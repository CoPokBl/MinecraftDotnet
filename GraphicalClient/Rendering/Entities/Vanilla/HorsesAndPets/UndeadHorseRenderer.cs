namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>For the skeleton and zombie horses: both adults bake the unscaled horse body, both babies the baby horse.</summary>
public sealed class UndeadHorseRenderer : AbstractHorseRenderer<EquineRenderState, AbstractEquineModel<EquineRenderState>> {
    /// <summary><c>UndeadHorseRenderer.Type</c>, with the adult and baby types folded into one.</summary>
    public sealed record Type(string Texture, string BabyTexture, EquipmentClientInfo.LayerType SaddleLayer) {
        public static readonly Type Skeleton = new("minecraft:textures/entity/horse/horse_skeleton.png", "minecraft:textures/entity/horse/horse_skeleton_baby.png",
            EquipmentClientInfo.LayerType.SkeletonHorseSaddle);
        public static readonly Type Zombie = new("minecraft:textures/entity/horse/horse_zombie.png", "minecraft:textures/entity/horse/horse_zombie_baby.png",
            EquipmentClientInfo.LayerType.ZombieHorseSaddle);
    }

    private readonly Type _type;

    public UndeadHorseRenderer(EntityRendererContext context, Type type) : base(
        new HorseModel<EquineRenderState>(AbstractEquineModel<EquineRenderState>.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
        new BabyHorseModel<EquineRenderState>(BabyHorseModel<EquineRenderState>.CreateBabyLayer(CubeDeformation.None).BakeRoot())) {
        _type = type;
        AddBodyArmorAndSaddleLayers(context, type.SaddleLayer, mesh => mesh);
    }

    public override string GetTextureLocation(EquineRenderState state) => state.IsBaby ? _type.BabyTexture : _type.Texture;
}
