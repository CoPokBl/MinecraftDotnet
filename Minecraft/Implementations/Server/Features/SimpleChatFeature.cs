using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.NBT.Text;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;

namespace Minecraft.Implementations.Server.Features;

public class SimpleChatFeature : IFeature {
    private readonly Func<string, PlayerConnection, TextComponent> _messageProvider;
    private readonly Func<PlayerConnection, PlayerConnection, bool> _shouldReceivePredicate;  // from, to
    private MinecraftServer _server = null!;
    
    public SimpleChatFeature(
        Func<string, PlayerConnection, TextComponent>? messageProvider = null, 
        Func<PlayerConnection, PlayerConnection, bool>? shouldReceivePredicate = null) {
        
        _messageProvider = messageProvider ?? ((msg, connection) => {  // default msg provider
            string username = _server.Feature<PlayerInfoFeature>() == null ? "Player" : PlayerInfoFeature.GetInfo(connection).Username ?? "Player";
            return TextComponent.Text($"<{username}> {msg}");
        });
        
        _shouldReceivePredicate = shouldReceivePredicate ?? ((_, _) => true);
    }
    
    public void Register(MinecraftServer server) {
        _server = server;

        server.Events.AddListener<PacketHandleEvent>(handleEvent => {
            if (handleEvent.Packet is not ServerBoundChatMessagePacket chatMessage) {
                return;
            }

            string msg = chatMessage.Message;
            TextComponent finalMsg = _messageProvider.Invoke(msg, handleEvent.Connection);

            List<PlayerConnection> recipients = [];
            recipients.AddRange(server.Connections.Where(other => _shouldReceivePredicate.Invoke(handleEvent.Connection, other)));

            SimpleChatEvent e = new() {
                Connection = handleEvent.Connection,
                Msg = msg,
                Recipients = recipients,
                FinalMessage = finalMsg
            };

            handleEvent.Connection.Events.CallEvent(e);

            if (e.Cancelled) {
                return;
            }

            // alright, let's send it
            foreach (PlayerConnection recipient in recipients) {
                recipient.SendPacket(new ClientBoundSystemChatMessagePacket(e.FinalMessage, false));
            }
        });
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class SimpleChatEvent : ServerEvent, ICancelableEvent {
        public PlayerConnection Connection { get; init; }
        public string Msg { get; init; }
        public List<PlayerConnection> Recipients { get; set; }
        public TextComponent FinalMessage { get; set; }
        public bool Cancelled { get; set; }
    }
}