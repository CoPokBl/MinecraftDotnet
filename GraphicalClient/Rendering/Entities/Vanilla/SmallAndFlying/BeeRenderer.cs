using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BeeRenderState : LivingEntityRenderState {
    public float RollAmount;
    public bool HasStinger = true;
    public bool IsOnGround, IsAngry, HasNectar;
}

public sealed class BeeRenderer : AgeableMobRenderer<BeeRenderState, BeeModel> {
    /// <summary>Indexed by angry, nectar and baby as bits 2, 1 and 0.</summary>
    private static readonly string[] Textures = new[] {
        "bee", "bee_baby", "bee_nectar", "bee_nectar_baby", "bee_angry", "bee_angry_baby", "bee_angry_nectar", "bee_angry_nectar_baby"
    }.Select(name => $"minecraft:textures/entity/bee/{name}.png").ToArray();

    public BeeRenderer(EntityRendererContext context)
        : base(new AdultBeeModel(AdultBeeModel.CreateBodyLayer().BakeRoot()), new BabyBeeModel(BabyBeeModel.CreateBodyLayer().BakeRoot()), 0.4F) { }

    /// <summary><c>Bee.rollAmount</c> and <c>rollAmountO</c>.</summary>
    private sealed class Roll {
        public float Amount, AmountO;
    }

    /// <summary><c>Bee.updateRollAmount</c>, from <c>tick</c>.</summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        Roll roll = (Roll)(entity.RendererData ??= new Roll());
        roll.AmountO = roll.Amount;
        if (GetFlag(entity, 2)) {
            roll.Amount = Math.Min(1.0F, roll.Amount + 0.2F);
        }
        else {
            roll.Amount = Math.Max(0.0F, roll.Amount - 0.24F);
        }
    }

    /// <summary><c>Bee.getFlag</c>: 2 rolling, 4 has stung, 8 has nectar.</summary>
    private static bool GetFlag(ClientEntity entity, int flag) => (entity.Get(EntityDataFields.Bee.Flags) & flag) != 0;

    public override string GetTextureLocation(BeeRenderState state) =>
        Textures[(state.IsAngry ? 4 : 0) | (state.HasNectar ? 2 : 0) | (state.IsBaby ? 1 : 0)];

    public override void ExtractRenderState(ClientEntity entity, BeeRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.RollAmount = entity.RendererData is Roll roll ? Mth.Lerp(partialTick, roll.AmountO, roll.Amount) : 0;
        state.HasStinger = !GetFlag(entity, 4);
        double lengthSqr = entity.DeltaMovement.X * entity.DeltaMovement.X + entity.DeltaMovement.Y * entity.DeltaMovement.Y + entity.DeltaMovement.Z * entity.DeltaMovement.Z;
        state.IsOnGround = entity.OnGround && lengthSqr < 1.0E-7;
        // NeutralMob.isAngry.
        long endTime = entity.Get(EntityDataFields.Bee.AngerEndTime, -1L);
        state.IsAngry = endTime > 0L && endTime - context.Level.GameTime > 0L;
        state.HasNectar = GetFlag(entity, 8);
    }
}
