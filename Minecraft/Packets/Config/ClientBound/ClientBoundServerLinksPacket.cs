using System.Diagnostics.CodeAnalysis;
using Minecraft.NBT.Text;
using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundServerLinksPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:server_links";
    
    public required ServerLink[] Links;

    [SetsRequiredMembers]
    public ClientBoundServerLinksPacket(params ServerLink[] links) : this() {
        Links = links;
    }
    
    public abstract class ServerLink : IWritable {
        
        public static ServerLink Override(BuiltinLabel label, string url) {
            return new OverrideLink(label, url);
        }
        
        public static ServerLink Custom(TextComponent label, string url) {
            return new CustomLink(label, url);
        }
        
        public class OverrideLink(BuiltinLabel label, string url) : ServerLink {
            public BuiltinLabel Label { get; } = label;
            public string Url { get; } = url;
        }
        
        public class CustomLink(TextComponent label, string url) : ServerLink {
            public TextComponent Label { get; } = label;
            public string Url { get; } = url;
        }
        
        public void Write(DataWriter writer) {
            writer.WriteBoolean(this is OverrideLink);  // true for varint (link type), false for custom link (text component)
            switch (this) {
                case OverrideLink overrideLink:
                    writer.WriteVarInt((int)overrideLink.Label);  // Write the BuiltinLabel as a varint
                    writer.WriteString(overrideLink.Url);
                    break;
                case CustomLink customLink:
                    writer.WriteNbt(customLink.Label);  // Write the TextComponent for custom links
                    writer.WriteString(customLink.Url);
                    break;
            }
        }

        public static ServerLink Read(DataReader r) {
            if (r.ReadBoolean()) {  // Check if it's an override link
                BuiltinLabel label = (BuiltinLabel)r.ReadVarInt();
                string url = r.ReadString();
                return Override(label, url);
            } else {  // It's a custom link
                TextComponent label = r.ReadText();
                string url = r.ReadString();
                return Custom(label, url);
            }
        }
    }
    
    public enum BuiltinLabel {
        /// <summary>
        /// Displayed on connection error screen, included as a comment in the disconnection report.
        /// </summary>
        BugReport = 0,
        CommunityGuidelines = 1,
        Support = 2,
        Status = 3,
        Feedback = 4,
        Community = 5,
        Website = 6,
        Forums = 7,
        News = 8,
        Announcements = 9
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(Links, (link, wr) => link.Write(wr))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundServerLinksPacket {
        Links = r.ReadPrefixedArray(ServerLink.Read)
    };
}
