using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Text;

namespace Minecraft.Implementations.Server.Features;

public class SimpleChatFeature : IServerFeature {
    private readonly Func<string, PlayerConnection, TextComponent> _messageProvider;
    private readonly Func<PlayerConnection, PlayerConnection, bool> _shouldReceivePredicate;  // from, to
    private MinecraftServer _server = null!;
    
    public SimpleChatFeature(
        Func<string, PlayerConnection, TextComponent>? messageProvider = null, 
        Func<PlayerConnection, PlayerConnection, bool>? shouldReceivePredicate = null) {
        
        _messageProvider = messageProvider ?? ((msg, connection) => {  // default msg provider
            string username = _server.Feature<PlayerInfoFeature>() == null ? "Player" : PlayerInfoFeature.GetInfo(connection).Username ?? "Player";
            return TextComponent.Text($"<{username}> ").With(TextComponent.FromLegacyString(msg));
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

            handleEvent.Connection.Events.CallEventCatchErrors(e);

            if (e.Cancelled) {
                return;
            }

            // alright, let's send it
            foreach (PlayerConnection recipient in recipients) {
                recipient.SendPacket(new ClientBoundSystemChatMessagePacket {
                    Content = e.FinalMessage,
                    ActionBar = false
                });
            }
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class SimpleChatEvent : IServerEvent, ICancelableEvent {
        public required PlayerConnection Connection { get; init; }
        public required string Msg { get; init; }
        public required List<PlayerConnection> Recipients { get; set; }
        public required TextComponent FinalMessage { get; set; }
        public bool Cancelled { get; set; }
    }
}