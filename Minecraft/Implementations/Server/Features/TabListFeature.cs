using System.Security.Cryptography;
using System.Text;
using Minecraft.Implementations.Server.Connections;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;

namespace Minecraft.Implementations.Server.Features;

public class TabListFeature : IFeature {
    private readonly int _updatePeriod;
    private readonly Func<TextComponent> _headerProvider;
    private readonly Func<TextComponent> _footerProvider;
    private MinecraftServer _server = null!;
    private readonly Func<TabListEntry[]> _entriesProvider;
    private Guid[] _lastEntries = [];
    private readonly List<PlayerConnection> _recipients = [];

    public TabListFeature(
        Func<TabListEntry[]>? entriesProvider = null, 
        int updatePeriod = -1, 
        Func<TextComponent>? headerProvider = null, 
        Func<TextComponent>? footerProvider = null) {
        _updatePeriod = updatePeriod;
        _headerProvider = headerProvider ?? TextComponent.Empty;
        _footerProvider = footerProvider ?? TextComponent.Empty;
        _entriesProvider = entriesProvider ?? (() => {
            bool playerInfoFeature = _server.Feature<PlayerInfoFeature>() != null;
            List<TabListEntry> entries = [];
            foreach (PlayerConnection connection in _server.Connections) {
                string? name = playerInfoFeature ? PlayerInfoFeature.GetInfo(connection).Username : "Mineman";
                if (name == null) {
                    continue;  // Haven't logged in
                }
                entries.Add(new TabListEntry(CreateSeededGuid(connection.GetHashCode().ToString()), TextComponent.Text(name)));
            }
            entries.Add(new TabListEntry(CreateSeededGuid("potato"), TextComponent.Text($"Second: {DateTime.Now.Second}")));

            return entries.ToArray();
        });
    }
    
    public static Guid CreateSeededGuid(string seed) {
        // Use SHA1 (20 bytes), and take the first 16 bytes for GUID
        byte[] hash = SHA1.HashData(Encoding.UTF8.GetBytes(seed));
        Array.Resize(ref hash, 16); // Guid is 16 bytes
        return new Guid(hash);
    }

    public void Register(MinecraftServer server) {
        _server = server;
        
        // just in case
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            RegisterPlayer(e.Connection);
            Update();
        });

        if (_updatePeriod != -1) {
            _ = UpdateThread();
        }
    }

    private async Task UpdateThread() {
        while (true) {
            Update();
            await Task.Delay(_updatePeriod);
        }
    }

    public void Update() {
        // lets build the packet
        MinecraftPacket[] packets = BuildPackets();
        foreach (PlayerConnection connection in _recipients) {
            connection.SendPackets(packets);
        }
    }

    private MinecraftPacket[] BuildPackets() {
        TabListEntry[] entries = _entriesProvider.Invoke();
        
        // Okay, what do we need to remove?
        // everything from last time not in entries
        Guid[] toRemove = _lastEntries.Where(e => !entries.Any(e2 => e2.Uuid.Equals(e))).ToArray();

        List<MinecraftPacket> packets = [];
        if (toRemove.Length > 0) {
            packets.Add(new ClientBoundPlayerInfoRemovePacket(toRemove));
        }
        
        ClientBoundPlayerInfoUpdatePacket.PlayerData data = new(
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateDisplayName,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateLatency,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListed,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListPriority);

        int priority = entries.Length;
        foreach (TabListEntry entry in entries) {
            data.WithPlayer(entry.Uuid, 
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = "a",
                    Properties = []
                },
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateDisplayName {
                    DisplayName = entry.Text
                },
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                    GameMode = entry.GameMode
                },
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateLatency {
                    Latency = entry.Latency
                },
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListed {
                    Listed = true
                },
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListPriority {
                    Priority = priority--
                });
        }
        
        packets.Add(new ClientBoundPlayerInfoUpdatePacket(data));
        packets.Add(new ClientBoundSetTabListHeaderFooterPacket(_headerProvider.Invoke(), _footerProvider.Invoke()));

        _lastEntries = entries.Select(e => e.Uuid).ToArray();
        return packets.ToArray();
    }

    public void RegisterPlayer(PlayerConnection connection) {
        _recipients.Add(connection);

        connection.Disconnected += () => {
            _recipients.Remove(connection);
        };
    }

    public Type[] GetDependencies() {
        return [];
    }

    public record TabListEntry(Guid Uuid, TextComponent Text, int Latency = 1, byte GameMode = 0);
}