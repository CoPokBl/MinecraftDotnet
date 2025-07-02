using Minecraft.Registry;

namespace Minecraft.Packets;

public delegate MinecraftPacket PacketDataDeserialiser(DataReader r, MinecraftRegistry registry);
