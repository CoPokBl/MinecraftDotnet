namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>The humanoid layer definitions <c>LayerDefinitions.createRoots</c> shares between several models.</summary>
public static class HumanoidLayers {
    public static readonly CubeDeformation OuterArmorDeformation = new(1.0F);
    public static readonly CubeDeformation InnerArmorDeformation = new(0.5F);
    public static readonly CubeDeformation BabyOuterArmorDeformation = new(-0.1F, 0.5F, 0.3F);
    public static readonly CubeDeformation BabyInnerArmorDeformation = new(-0.1F, 0.3F, 0.3F);
    public static readonly CubeDeformation BabyPiglinInnerArmorDeformation = new(0.7F);
    public static readonly CubeDeformation BabyPiglinOuterArmorDeformation = new(0.7F);
    public static readonly PartPose BabyPiglinArmorArmOffset = new(0.5F, -0.5F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F);

    public static LayerDefinition HumanoidBody() => LayerDefinition.Create(HumanoidModel<HumanoidRenderState>.CreateMesh(CubeDeformation.None, 0.0F), 64, 64);

    public static ArmorModelSet<LayerDefinition> HumanoidArmor() =>
        HumanoidModel<HumanoidRenderState>.CreateArmorMeshSet(InnerArmorDeformation, OuterArmorDeformation).Map(mesh => LayerDefinition.Create(mesh, 64, 32));

    public static ArmorModelSet<LayerDefinition> HumanoidBabyArmor() =>
        HumanoidModel<HumanoidRenderState>.CreateBabyArmorMeshSet(BabyInnerArmorDeformation, BabyOuterArmorDeformation, PartPose.Zero)
            .Map(mesh => LayerDefinition.Create(mesh, 64, 64));

    public static ArmorModelSet<LayerDefinition> PlayerArmor() =>
        PlayerModel.CreateArmorMeshSet(InnerArmorDeformation, OuterArmorDeformation).Map(mesh => LayerDefinition.Create(mesh, 64, 32));

    public static ArmorModelSet<LayerDefinition> PiglinArmor() =>
        AbstractPiglinModel<HumanoidRenderState>.CreateArmorMeshSet(InnerArmorDeformation, new CubeDeformation(1.02F)).Map(mesh => LayerDefinition.Create(mesh, 64, 32));

    public static ArmorModelSet<LayerDefinition> PiglinBabyArmor() =>
        AbstractPiglinModel<HumanoidRenderState>.CreateBabyArmorMeshSet(BabyPiglinInnerArmorDeformation, BabyPiglinOuterArmorDeformation, BabyPiglinArmorArmOffset)
            .Map(mesh => LayerDefinition.Create(mesh, 64, 64));

    public static ArmorModelSet<LayerDefinition> Scaled(ArmorModelSet<LayerDefinition> set, MeshTransformer transformer) => set.Map(layer => layer.Apply(transformer));
}
