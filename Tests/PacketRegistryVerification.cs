using Minecraft.Packets;
using Minecraft.Packets.Registry;

namespace Tests;

public class PacketRegistryVerification {

    private void Verify(Type type, Type expectedBase) {
        Console.WriteLine("Verifying packet: " + type.FullName);
        Assert.That(type.IsAssignableTo(expectedBase), $"Packet {type.FullName} does not inherit from {expectedBase.FullName}");
        Assert.That(type.FullName!, Does.EndWith("Packet"), "Packet " + type.FullName + " does not end with 'Packet'");
    }

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
                Verify(kvp.Value.Item1, typeof(ServerBoundPacket));
            }
        }
        
        foreach (Dictionary<int, (Type, PacketDataDeserialiser)> clientBoundRegistry in clientBoundRegistries) {
            foreach (KeyValuePair<int, (Type, PacketDataDeserialiser)> kvp in clientBoundRegistry) {
                Verify(kvp.Value.Item1, typeof(ClientBoundPacket));
            }
        }
    }
}
