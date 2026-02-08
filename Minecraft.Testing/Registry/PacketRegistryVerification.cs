using Minecraft.Data.Generated;
using Minecraft.Packets;

namespace Minecraft.Testing.Registry;

public class PacketRegistryVerification {

    private static void Verify(Type type, Type expectedBase) {
        Console.WriteLine("Verifying packet: " + type.FullName);
        Assert.That(type.IsAssignableTo(expectedBase), $"Packet {type.FullName} does not inherit from {expectedBase.FullName}");
        Assert.That(type.FullName!, Does.EndWith("Packet"), "Packet " + type.FullName + " does not end with 'Packet'");
    }

    [Test]
    public void ClientVsServerBoundVerify() {
        ISet<Type> clientBound = VanillaRegistry.Data.Packets.GetPacketTypes(true);
        ISet<Type> serverBound = VanillaRegistry.Data.Packets.GetPacketTypes(false);

        foreach (Type packet in serverBound) {
            Verify(packet, typeof(ServerBoundPacket));
        }
        
        foreach (Type packet in clientBound) {
            Verify(packet, typeof(ClientBoundPacket));
        }
    }
}
