using Minecraft.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Packets.Play.ServerBound
{
    public class ServerBoundEditBookPacket : ServerBoundPacket
    {
        public override Identifier Identifier => "minecraft:edit_book";

        public required int Slot { get; init; }
        public required int Count { get; init; }
        public required string[] Entries { get; init; }
        public required bool HasTitle { get; init; }
        public required string Title { get; init; }

        protected override DataWriter WriteData(DataWriter w)
        {

            w.WriteVarInt(Slot)
            .WriteVarInt(Count)
            .WriteArray(Entries, (s, w) => w.WriteString(s))
            .WriteBoolean(HasTitle);

            if (HasTitle)
                w.WriteString(Title);
            return w;

        }

        public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
            var Slot = r.ReadVarInt();
            var Count = r.ReadVarInt();
            var Entries = r.ReadArray(Count, (w, l) => w.ReadString());
            var HasTitle = r.ReadBoolean();
            var Title = HasTitle ? r.ReadString() : "";
            return new ServerBoundEditBookPacket
            {
                Slot = Slot,
                Count = Count,
                Entries = Entries,
                HasTitle = HasTitle,
                Title = Title
            };
        };
    }
}
