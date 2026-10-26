using ClientLib.Entities;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>MinecartTntRenderState</c>.</summary>
public class MinecartTntRenderState : MinecartRenderState {
    public float FuseRemainingInTicks;
}

/// <summary><c>TntMinecartRenderer</c>.</summary>
public sealed class TntMinecartRenderer : AbstractMinecartRenderer<MinecartTntRenderState> {
    /// <summary><c>Entity.EVENT_TNT_MINECART_PRIME</c>, which <c>MinecartTNT.handleEntityEvent</c> primes the fuse on.</summary>
    private const byte PrimeEvent = 70;

    private readonly BlockModelRenderer _blocks;

    public TntMinecartRenderer(EntityRendererContext context) : base(context) {
        _blocks = context.Blocks;
    }

    /// <summary><c>MinecartTNT.fuse</c>, which is never synced: the client hears of it only through the prime event.</summary>
    private sealed class ClientTntMinecart : ClientMinecart {
        public int Fuse = -1;
    }

    protected override ClientMinecart CreateClientState() => new ClientTntMinecart();

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == PrimeEvent) {
            ((ClientTntMinecart)Cart(entity)).Fuse = 80;
        }
    }

    public override void Tick(ClientEntity entity) {
        base.Tick(entity);
        ClientTntMinecart cart = (ClientTntMinecart)Cart(entity);
        if (cart.Fuse > 0) {
            cart.Fuse--;
        }
    }

    protected override void SubmitMinecartContents(MinecartTntRenderState state, IBlock block, PoseStack pose, EntityRenderContext context) {
        float fuse = state.FuseRemainingInTicks;
        if (fuse > -1.0F && fuse < 10.0F) {
            float swell = TntRenderer.GetSwellAmount(fuse);
            pose.Translate(-swell * 0.5F, 0.0F, -swell * 0.5F);
            float scale = 1.0F + swell;
            pose.Scale(scale, scale, scale);
        }
        SubmitWhiteSolidBlock(_blocks, block, pose, context, state.SkyLight, state.BlockLight, TntRenderer.IsLit(fuse));
    }

    /// <summary><c>submitWhiteSolidBlock</c>: <c>OverlayTexture.u(1.0F)</c> while lit.</summary>
    public static void SubmitWhiteSolidBlock(BlockModelRenderer blocks, IBlock block, PoseStack pose, EntityRenderContext context, float skyLight, float blockLight, bool white) =>
        blocks.Render(block, pose, context.Batch, skyLight, blockLight, 0xFFFFFFFF, white ? 1.0F : 0.0F);

    public override void ExtractRenderState(ClientEntity entity, MinecartTntRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        int fuse = ((ClientTntMinecart)Cart(entity)).Fuse;
        state.FuseRemainingInTicks = fuse > -1 ? fuse - partialTick + 1.0F : -1.0F;
    }
}
