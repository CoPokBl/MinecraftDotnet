using ClientLib;
using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class WitherRenderState : LivingEntityRenderState {
    public readonly float[] XHeadRots = new float[2];
    public readonly float[] YHeadRots = new float[2];
    public float InvulnerableTicks;
    public bool IsPowered;
}

/// <summary><c>WitherBossRenderer</c>.</summary>
public sealed class WitherBossRenderer : MobRenderer<WitherRenderState, WitherBossModel> {
    private const string WitherInvulnerableLocation = "minecraft:textures/entity/wither/wither_invulnerable.png";
    private const string WitherLocation = "minecraft:textures/entity/wither/wither.png";

    // The heads aim at other entities, which a tick has no way to look up, so the client is taken from the last frame.
    private MinecraftClient? _client;

    public WitherBossRenderer(EntityRendererContext context) : base(new WitherBossModel(WitherBossModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), 1.0F) {
        AddLayer(new WitherArmorLayer(this));
    }

    /// <summary><c>WitherBoss.xRotHeads</c> and <c>yRotHeads</c>, which the client turns itself.</summary>
    private sealed class Heads {
        public readonly float[] XRotHeads = new float[2];
        public readonly float[] YRotHeads = new float[2];
    }

    /// <summary>
    /// <c>WitherBoss.aiStep</c>'s side heads. It runs before <c>tickHeadTurn</c> moves the body, so the
    /// body rotation it reads is the one the tick started with.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        Heads heads = (Heads)(entity.RendererData ??= new Heads());
        float yBodyRot = entity.YBodyRotO;
        float scale = (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);
        for (int i = 0; i < 2; i++) {
            int entityId = i == 0 ? entity.Get(EntityDataFields.WitherBoss.TargetB) : entity.Get(EntityDataFields.WitherBoss.TargetC);
            ClientEntity? target = null;
            if (entityId > 0) {
                _client?.Entities.TryGetValue(entityId, out target);
            }
            if (target != null) {
                double hx = GetHeadX(entity, yBodyRot, scale, i + 1);
                double hy = GetHeadY(entity, scale, i + 1);
                double hz = GetHeadZ(entity, yBodyRot, scale, i + 1);
                double xd = target.Position.X - hx;
                double ydx = target.Position.Y + target.EyeHeight - hy;
                double zd = target.Position.Z - hz;
                double sd = Math.Sqrt(xd * xd + zd * zd);
                float yRotD = (float)(Math.Atan2(zd, xd) * 180.0F / (float)Math.PI) - 90.0F;
                float xRotD = (float)-(Math.Atan2(ydx, sd) * 180.0F / (float)Math.PI);
                heads.XRotHeads[i] = Rotlerp(heads.XRotHeads[i], xRotD, 40.0F);
                heads.YRotHeads[i] = Rotlerp(heads.YRotHeads[i], yRotD, 10.0F);
            }
            else {
                heads.YRotHeads[i] = Rotlerp(heads.YRotHeads[i], yBodyRot, 10.0F);
            }
        }
    }

    private static double GetHeadX(ClientEntity entity, float yBodyRot, float scale, int index) {
        if (index <= 0) {
            return entity.Position.X;
        }
        float headAngle = (yBodyRot + 180 * (index - 1)) * (float)(Math.PI / 180.0);
        float cos = Mth.Cos(headAngle);
        return entity.Position.X + cos * 1.3 * scale;
    }

    private static double GetHeadY(ClientEntity entity, float scale, int index) {
        float height = index <= 0 ? 3.0F : 2.2F;
        return entity.Position.Y + height * scale;
    }

    private static double GetHeadZ(ClientEntity entity, float yBodyRot, float scale, int index) {
        if (index <= 0) {
            return entity.Position.Z;
        }
        float headAngle = (yBodyRot + 180 * (index - 1)) * (float)(Math.PI / 180.0);
        float sin = Mth.Sin(headAngle);
        return entity.Position.Z + sin * 1.3 * scale;
    }

    private static float Rotlerp(float a, float b, float max) {
        float diff = Mth.WrapDegrees(b - a);
        if (diff > max) {
            diff = max;
        }
        if (diff < -max) {
            diff = -max;
        }
        return a + diff;
    }

    public override string GetTextureLocation(WitherRenderState state) {
        int invulnerableTicks = Mth.Floor(state.InvulnerableTicks);
        return invulnerableTicks > 0 && (invulnerableTicks > 80 || invulnerableTicks / 5 % 2 != 1) ? WitherInvulnerableLocation : WitherLocation;
    }

    protected override void Scale(WitherRenderState state, PoseStack pose) {
        float scale = 2.0F;
        if (state.InvulnerableTicks > 0.0F) {
            scale -= state.InvulnerableTicks / 220.0F * 0.5F;
        }
        pose.Scale(scale, scale, scale);
    }

    public override void ExtractRenderState(ClientEntity entity, WitherRenderState state, float partialTick, EntityRenderContext context) {
        _client = context.Client;
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
        int invulnerableTicks = entity.Get(EntityDataFields.WitherBoss.IdInv);
        state.InvulnerableTicks = invulnerableTicks > 0 ? invulnerableTicks - partialTick : 0.0F;
        if (entity.RendererData is Heads heads) {
            Array.Copy(heads.XRotHeads, state.XHeadRots, 2);
            Array.Copy(heads.YRotHeads, state.YHeadRots, 2);
        }
        // WitherBoss.isPowered.
        float maxHealth = (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.MaxHealth);
        state.IsPowered = entity.CurrentHealth <= maxHealth / 2.0F;
    }
}

/// <summary><c>WitherArmorLayer</c>.</summary>
public sealed class WitherArmorLayer(LivingEntityRenderer<WitherRenderState, WitherBossModel> parent) : EnergySwirlLayer<WitherRenderState, WitherBossModel>(parent) {
    // LayerDefinitions.INNER_ARMOR_DEFORMATION.
    protected override WitherBossModel Model { get; } = new(WitherBossModel.CreateBodyLayer(new CubeDeformation(0.5F)).BakeRoot());

    protected override bool IsPowered(WitherRenderState state) => state.IsPowered;

    protected override float XOffset(float t) => Mth.Cos(t * 0.02F) * 3.0F;

    protected override string TextureLocation => "minecraft:textures/entity/wither/wither_armor.png";
}
