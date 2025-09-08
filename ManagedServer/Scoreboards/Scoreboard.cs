using ManagedServer.Entities.Types;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Objectives;
using Minecraft.Text;

namespace ManagedServer.Scoreboards;

public class Scoreboard(
    ClientBoundDisplayObjectivePacket.DisplayPosition position,
    TextComponent? objectiveTitle = null,
    INumberFormat? numberFormat = null,
    ClientBoundUpdateObjectivePacket.Type type = ClientBoundUpdateObjectivePacket.Type.Integer,
    string? objectiveName = null) {
    
    public string ObjectiveName { get; } = objectiveName ?? Guid.NewGuid().ToString();
    
    private readonly Dictionary<string, ScoreboardEntry> _entries = [];
    private readonly List<PlayerEntity> _viewers = [];

    public void AddViewer(PlayerEntity player) {
        _viewers.Add(player);
        InitPlayer(player);
    }
    
    public void RemoveViewer(PlayerEntity player) {
        _viewers.Remove(player);
        player.SendPacket(new ClientBoundUpdateObjectivePacket {
            ObjectiveName = ObjectiveName,
            UpdateMode = ClientBoundUpdateObjectivePacket.Mode.Remove
        });
    }
    
    public void AddEntry(ScoreboardEntry entry) {
        _entries[entry.Name] = entry;
        PacketToViewers(new ClientBoundUpdateScorePacket {
            EntityName = entry.Name,
            DisplayName = entry.DisplayName,
            NumberFormat = entry.NumberFormat ?? numberFormat,
            Value = entry.Value,
            ObjectiveName = ObjectiveName
        });
    }
    
    public void RemoveEntry(string name) {
        _entries.Remove(name);
        PacketToViewers(new ClientBoundResetScorePacket {
            EntityName = name,
            ObjectiveName = ObjectiveName
        });
    }
    
    public ScoreboardEntry[] GetEntries() => _entries.Values.ToArray();

    private void InitPlayer(PlayerEntity player) {
        player.SendPacket(new ClientBoundUpdateObjectivePacket {
            ObjectiveName = ObjectiveName,
            UpdateMode = ClientBoundUpdateObjectivePacket.Mode.Create,
            ObjectiveType = type,
            NumberFormat = Optional<INumberFormat>.FromNullable(numberFormat),
            ObjectiveValue = objectiveTitle ?? TextComponent.Text(ObjectiveName)
        });
        
        player.SendPacket(new ClientBoundDisplayObjectivePacket {
            ScoreName = ObjectiveName,
            Position = position
        });

        foreach (ScoreboardEntry entry in GetEntries()) {
            player.SendPacket(new ClientBoundUpdateScorePacket {
                EntityName = entry.Name,
                DisplayName = entry.DisplayName,
                NumberFormat = entry.NumberFormat ?? numberFormat,
                Value = entry.Value,
                ObjectiveName = ObjectiveName
            });
        }
    }

    private void PacketToViewers(ClientBoundPacket packet) {
        foreach (PlayerEntity viewer in _viewers) {
            viewer.SendPacket(packet);
        }
    }
}
