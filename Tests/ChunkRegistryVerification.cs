using Minecraft.Packets;
using Minecraft.Packets.Registry;

namespace Tests;

public class ChunkRegistryVerification {

    [Test]
    public void ClientVsServerBoundVerify() {
        Dictionary<int,(Type, PacketDataDeserialiser)>[] clientBoundRegistries = [
            PacketRegistry.ClientBoundLogin,
            PacketRegistry.ClientBoundStatus,
            PacketRegistry.ClientBoundConfig,
            PacketRegistry.ClientBoundPlay
        ];
        
        Dictionary<int,(Type, PacketDataDeserialiser)>[] serverBoundRegistries = [
            PacketRegistry.ServerBoundLogin,
            PacketRegistry.ServerBoundStatus,
            PacketRegistry.ServerBoundConfig,
            PacketRegistry.ServerBoundPlay,
            PacketRegistry.ServerBoundStateless
        ];

        foreach (Dictionary<int, (Type, PacketDataDeserialiser)> serverBoundRegistry in serverBoundRegistries) {
            foreach (KeyValuePair<int, (Type, PacketDataDeserialiser)> kvp in serverBoundRegistry) {
                Console.WriteLine("Verifying server bound packet: " + kvp.Value.Item1.FullName);
                Assert.That(kvp.Value.Item1.IsAssignableTo(typeof(ServerBoundPacket)));
            }
        }
        
        foreach (Dictionary<int, (Type, PacketDataDeserialiser)> clientBoundRegistry in clientBoundRegistries) {
            foreach (KeyValuePair<int, (Type, PacketDataDeserialiser)> kvp in clientBoundRegistry) {
                Console.WriteLine("Verifying client bound packet: " + kvp.Value.Item1.FullName);
                Assert.That(kvp.Value.Item1.IsAssignableTo(typeof(ClientBoundPacket)));
            }
        }
    }
}