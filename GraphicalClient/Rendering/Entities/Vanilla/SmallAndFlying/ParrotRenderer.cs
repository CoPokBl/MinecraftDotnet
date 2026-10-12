using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>Parrot.Variant</c>, by its synced id.</summary>
public enum ParrotVariant {
    RedBlue = 0,
    Blue = 1,
    Green = 2,
    YellowBlue = 3,
    Gray = 4
}

public class ParrotRenderState : LivingEntityRenderState {
    public ParrotVariant Variant = ParrotVariant.RedBlue;
    public float FlapAngle;
    /// <summary>Hides the entity pose, as vanilla's field does; <see cref="LivingEntityRenderState.HasPose"/> still reads that one.</summary>
    public new ParrotPose Pose = ParrotPose.Flying;
}

/// <summary>
/// <c>ParrotRenderer</c>. A party parrot is never drawn dancing: <c>setRecordPlayingNearby</c> comes
/// from the jukebox level event, which nothing on this client passes to an entity.
/// </summary>
public sealed class ParrotRenderer : MobRenderer<ParrotRenderState, ParrotModel> {
    private static readonly string[] Textures =
        new[] { "red_blue", "blue", "green", "yellow_blue", "grey" }.Select(name => $"minecraft:textures/entity/parrot/parrot_{name}.png").ToArray();

    public ParrotRenderer(EntityRendererContext context) : base(new ParrotModel(ParrotModel.CreateBodyLayer().BakeRoot()), 0.3F) { }

    /// <summary><c>Parrot.flap</c>, <c>flapSpeed</c> and the rest of what <c>calculateFlapping</c> keeps.</summary>
    private sealed class Wings {
        public float Flap, FlapSpeed, OFlapSpeed, OFlap;
        public float Flapping = 1.0F;
    }

    /// <summary><c>Parrot.calculateFlapping</c>.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Wings f = (Wings)(entity.RendererData ??= new Wings());
        f.OFlap = f.Flap;
        f.OFlapSpeed = f.FlapSpeed;
        f.FlapSpeed = f.FlapSpeed + (!entity.OnGround && entity.VehicleId == null ? 4 : -1) * 0.3F;
        f.FlapSpeed = Mth.Clamp(f.FlapSpeed, 0.0F, 1.0F);
        if (!entity.OnGround && f.Flapping < 1.0F) {
            f.Flapping = 1.0F;
        }
        f.Flapping *= 0.9F;
        f.Flap = f.Flap + f.Flapping * 2.0F;
    }

    public override string GetTextureLocation(ParrotRenderState state) => Textures[(int)state.Variant];

    public override void ExtractRenderState(ClientEntity entity, ParrotRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Variant = VariantById(entity.Get(EntityDataFields.Parrot.Variant));
        float flap = 0, flapSpeed = 0;
        if (entity.RendererData is Wings f) {
            flap = Mth.Lerp(partialTick, f.OFlap, f.Flap);
            flapSpeed = Mth.Lerp(partialTick, f.OFlapSpeed, f.FlapSpeed);
        }
        state.FlapAngle = (Mth.Sin(flap) + 1.0F) * flapSpeed;
        state.Pose = GetPose(entity);
    }

    /// <summary><c>ParrotModel.getPose</c>, with <c>isPartyParrot</c> always false.</summary>
    private static ParrotPose GetPose(ClientEntity entity) {
        // TamableAnimal.isInSittingPose.
        if ((entity.Get(EntityDataFields.TamableAnimal.Flags) & 1) != 0) {
            return ParrotPose.Sitting;
        }
        // Parrot.isFlying.
        return !entity.OnGround ? ParrotPose.Flying : ParrotPose.Standing;
    }

    /// <summary><c>Parrot.Variant.byId</c>, which clamps.</summary>
    private static ParrotVariant VariantById(int id) => (ParrotVariant)Math.Clamp(id, 0, 4);
}
