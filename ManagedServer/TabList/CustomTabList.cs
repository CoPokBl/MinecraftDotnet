using ManagedServer.Entities.Types;
using Minecraft;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ManagedServer.TabList;

public class CustomTabList {
    private static readonly Tag<Guid[]> LastEntriesTag = new("simpletablist:last_entries");
    
    public TextComponent Header { get; set; } = TextComponent.Text("");
    public TextComponent Footer { get; set; } = TextComponent.Text("");
    public Func<PlayerEntity, IEnumerable<TabListEntry>> EntriesProvider { get; set; } = _ => [];
    
    private readonly List<PlayerEntity> _players = [];

    public void AddPlayer(PlayerEntity player) {
        _players.Add(player);
        UpdateTabListFor(player);
    }
    
    public void Refresh() {
        foreach (PlayerEntity player in _players) {
            UpdateTabListFor(player);
        }
    }

    public void UpdateTabListFor(PlayerEntity player) {
        ClientBoundSetTabListHeaderFooterPacket headerFooterPacket = new() {
            Header = Header,
            Footer = Footer
        };
        player.SendPacket(headerFooterPacket);

        // Remove existing entries
        Guid[]? lastEntries = player.GetTagOrNull(LastEntriesTag);
        if (lastEntries != null) {
            ClientBoundPlayerInfoRemovePacket removePacket = new() {
                Uuids = lastEntries
            };
            player.SendPacket(removePacket);
        }

        ClientBoundPlayerInfoUpdatePacket.PlayerData data = new(
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateDisplayName,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateLatency,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListed,
            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListPriority
        );

        IEnumerable<TabListEntry> entries = EntriesProvider(player);
        List<Guid> addedUuids = [];
        int priority = 999;
        foreach (TabListEntry entry in entries) {
            data.WithPlayer(entry.Uuid, 
                new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = entry.Username,
                    Properties = entry.Skin == null ? [] : [
                        new ProfileProperty {
                            Name = "textures",
                            Signature = entry.Skin.Signature,
                            Value = entry.Skin.Textures
                        }
                    ]
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
                    Priority = priority
                }
            );
            addedUuids.Add(entry.Uuid);
            priority--;
        }

        ClientBoundPlayerInfoUpdatePacket updatePacket = new() {
            Data = data
        };
        player.SendPacket(updatePacket);
        player.SetTag(LastEntriesTag, addedUuids.ToArray());
    }
}
