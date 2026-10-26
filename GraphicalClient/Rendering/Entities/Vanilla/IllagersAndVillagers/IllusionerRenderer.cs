using System.Numerics;
using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class IllusionerRenderState : IllagerRenderState {
    public System.Numerics.Vector3[] IllusionOffsets = [];
    public bool IsCastingSpell;
}

/// <summary>
/// <c>IllusionerRenderer</c>: drawn even while invisible, as four copies at its illusion offsets. Vanilla
/// widens its culling box by three blocks for the copies; the dispatcher culls on the entity's own box,
/// so a copy can vanish at the edge of the view a little before vanilla's would.
/// </summary>
public sealed class IllusionerRenderer : IllagerRenderer<IllusionerRenderState> {
    private const string Illusioner = "minecraft:textures/entity/illager/illusioner.png";

    public IllusionerRenderer(EntityRendererContext context) : base(context) {
        AddLayer(new ConditionalItemInHandLayer(this, context.Items, state => state.IsCastingSpell || state.IsAggressive));
        Model.Hat.Visible = true;
    }

    /// <summary><c>Illusioner</c>'s client side illusion: two sets of four offsets it eases between.</summary>
    private sealed class IllusionerData : HumanoidEntityData {
        // The entity's own RandomSource; nothing compares these draws with vanilla's.
        private readonly Random _random = new();
        public int ClientSideIllusionTicks;
        public readonly Vector3d[][] ClientSideIllusionOffsets = [new Vector3d[4], new Vector3d[4]];

        /// <summary>The client half of <c>Illusioner.aiStep</c>.</summary>
        public override void Tick(ClientEntity entity) {
            base.Tick(entity);
            if (!entity.IsInvisible) {
                return;
            }
            ClientSideIllusionTicks--;
            if (ClientSideIllusionTicks < 0) {
                ClientSideIllusionTicks = 0;
            }
            if (entity.HurtTime == 1 || entity.TickCount % 1200 == 0) {
                ClientSideIllusionTicks = 3;
                for (int i = 0; i < 4; i++) {
                    ClientSideIllusionOffsets[0][i] = ClientSideIllusionOffsets[1][i];
                    ClientSideIllusionOffsets[1][i] = new Vector3d(
                        (-6.0F + _random.Next(13)) * 0.5, Math.Max(0, _random.Next(6) - 4), (-6.0F + _random.Next(13)) * 0.5);
                }
            }
            // hurtDuration is always 10.
            else if (entity.HurtTime == 10 - 1) {
                ClientSideIllusionTicks = 3;
                for (int i = 0; i < 4; i++) {
                    ClientSideIllusionOffsets[0][i] = ClientSideIllusionOffsets[1][i];
                    ClientSideIllusionOffsets[1][i] = new Vector3d(0.0, 0.0, 0.0);
                }
            }
        }

        /// <summary><c>getIllusionOffsets</c>.</summary>
        public Vector3d[] GetIllusionOffsets(float a) {
            if (ClientSideIllusionTicks <= 0) {
                return ClientSideIllusionOffsets[1];
            }
            double scale = (ClientSideIllusionTicks - a) / 3.0F;
            scale = Math.Pow(scale, 0.25);
            Vector3d[] offsets = new Vector3d[4];
            for (int i = 0; i < 4; i++) {
                offsets[i] = ClientSideIllusionOffsets[1][i] * (1.0 - scale) + ClientSideIllusionOffsets[0][i] * scale;
            }
            return offsets;
        }
    }

    private readonly record struct Vector3d(double X, double Y, double Z) {
        public static Vector3d operator *(Vector3d v, double s) => new(v.X * s, v.Y * s, v.Z * s);
        public static Vector3d operator +(Vector3d a, Vector3d b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<IllusionerData>(entity);

    public override string GetTextureLocation(IllusionerRenderState state) => Illusioner;

    /// <summary><c>Illusioner.getArmPose</c>.</summary>
    protected override IllagerArmPose GetArmPose(ClientEntity entity) {
        if (IsCastingSpell(entity)) {
            return IllagerArmPose.Spellcasting;
        }
        return HumanoidEntityData.IsAggressive(entity) ? IllagerArmPose.BowAndArrow : IllagerArmPose.Crossed;
    }

    public override void ExtractRenderState(ClientEntity entity, IllusionerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        Vector3d[] offsets = entity.RendererData is IllusionerData data ? data.GetIllusionOffsets(partialTick) : new Vector3d[4];
        state.IllusionOffsets = offsets.Select(o => new Vector3((float)o.X, (float)o.Y, (float)o.Z)).ToArray();
        state.IsCastingSpell = IsCastingSpell(entity);
    }

    public override void Submit(IllusionerRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.IsInvisible) {
            Vector3[] offsets = state.IllusionOffsets;
            for (int i = 0; i < offsets.Length; i++) {
                pose.Push();
                pose.Translate(
                    offsets[i].X + Mth.Cos(i + state.AgeInTicks * 0.5F) * 0.025F,
                    offsets[i].Y + Mth.Cos(i + state.AgeInTicks * 0.75F) * 0.0125F,
                    offsets[i].Z + Mth.Cos(i + state.AgeInTicks * 0.7F) * 0.025F);
                base.Submit(state, pose, context);
                pose.Pop();
            }
        }
        else {
            base.Submit(state, pose, context);
        }
    }

    protected override bool IsBodyVisible(IllusionerRenderState state) => true;
}
