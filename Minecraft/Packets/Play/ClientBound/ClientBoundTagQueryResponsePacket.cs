using Minecraft.Schemas;
using NBT;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Answers a <c>ServerBoundQueryBlockEntityTagPacket</c> or <c>ServerBoundQueryEntityTagPacket</c>.
/// </summary>
public class ClientBoundTagQueryResponsePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:tag_query";

    /// <summary>Matches the transaction id of the request this answers.</summary>
    public required int TransactionId { get; init; }

    /// <summary>The queried NBT, or null when the target didn't exist.</summary>
    public INbtTag? Nbt { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteVarInt(TransactionId);
        // An absent tag goes out as a bare END tag.
        return Nbt == null ? w.WriteUnsignedByte(0) : w.WriteNbt(Nbt);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int transactionId = r.ReadVarInt();
        byte[] nbt = r.ReadRemaining();
        return new ClientBoundTagQueryResponsePacket {
            TransactionId = transactionId,
            Nbt = nbt.Length != 0 && nbt[0] != 0 ? new DataReader(nbt).ReadNbt() : null
        };
    };
}
