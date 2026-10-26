using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Schemas;

namespace ClientLib.Testing.Play;

/// <summary><c>ClientCommonPacketListenerImpl.handlePostEffects</c>, which sets the player's own list.</summary>
public class PostEffectsTest {
    [Test]
    public void TheServersPostEffectsReplaceThePlayersList() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        client.StartOffline(level);
        client.Dispatch(new ClientBoundPostEffectsPacket { PostEffects = ["minecraft:creeper", "minecraft:invert"] });
        Assert.That(client.Player!.ActivePostEffects, Is.EqualTo(new Identifier[] { "minecraft:creeper", "minecraft:invert" }));
        client.Dispatch(new ClientBoundPostEffectsPacket { PostEffects = [] });
        Assert.That(client.Player.ActivePostEffects, Is.Empty);
    }
}
