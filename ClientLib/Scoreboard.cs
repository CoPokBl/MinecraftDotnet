using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Objectives;
using Minecraft.Text;

namespace ClientLib;

public sealed record Objective(string Name, TextComponent DisplayName, ClientBoundUpdateObjectivePacket.Type RenderType, INumberFormat? NumberFormat);

public sealed record Score(int Value, TextComponent? DisplayName, INumberFormat? NumberFormat);

public sealed class Team(string name) {
    public string Name { get; } = name;
    public TextComponent? DisplayName { get; set; }
    public TextComponent? Prefix { get; set; }
    public TextComponent? Suffix { get; set; }
    public ClientBoundUpdateTeamsPacket.TeamColor? Colour { get; set; }
    public ClientBoundUpdateTeamsPacket.NameTagVisibility? NameTags { get; set; }
    public ClientBoundUpdateTeamsPacket.CollisionRule Collision { get; set; } = ClientBoundUpdateTeamsPacket.CollisionRule.Always;
    public HashSet<string> Members { get; } = [];

    /// <summary><c>TeamColor.rgb</c>, or null for a team without a colour.</summary>
    public int? Rgb => Colour is { } colour && (int)colour < 16 ? StringDecomposer.LegacyColour("0123456789abcdef"[(int)colour]) : null;

    /// <summary><c>PlayerTeam.formatNameForTeam</c>: the prefix, name and suffix, together in the team's colour.</summary>
    public static TextComponent FormatNameForTeam(Team? team, TextComponent name) {
        if (team == null) {
            return name;
        }
        TextComponent result = TextComponent.Empty();
        if (team.Prefix != null) {
            result.With(team.Prefix);
        }
        result.With(name);
        if (team.Suffix != null) {
            result.With(team.Suffix);
        }
        if (team.Colour is { } colour && (int)colour < 16 && StringDecomposer.LegacyColour("0123456789abcdef"[(int)colour]) is { } rgb) {
            result.WithColor(TextColor.FromDecimal(rgb));
        }
        return result;
    }
}

/// <summary>Objectives, scores, display slots and teams, as the server keeps the client told.</summary>
public sealed class Scoreboard {
    public Dictionary<string, Objective> Objectives { get; } = new();

    /// <summary>Scores by holder, then by objective.</summary>
    public Dictionary<string, Dictionary<string, Score>> Scores { get; } = new();

    public Dictionary<ClientBoundDisplayObjectivePacket.DisplayPosition, string> Displayed { get; } = new();
    public Dictionary<string, Team> Teams { get; } = new();
    private readonly Dictionary<string, Team> _teamOf = new();

    public Team? TeamOf(string holder) => _teamOf.GetValueOrDefault(holder);

    public Objective? DisplayedIn(ClientBoundDisplayObjectivePacket.DisplayPosition slot) {
        return Displayed.TryGetValue(slot, out string? name) ? Objectives.GetValueOrDefault(name) : null;
    }

    /// <summary>The scores on an objective, highest first then by holder, as the sidebar lists them.</summary>
    public List<(string Holder, Score Score)> Ranked(string objective) {
        List<(string, Score)> list = [];
        foreach ((string holder, Dictionary<string, Score> scores) in Scores) {
            if (scores.TryGetValue(objective, out Score? score) && !holder.StartsWith('#')) {
                list.Add((holder, score));
            }
        }
        list.Sort((a, b) => b.Item2.Value != a.Item2.Value ? b.Item2.Value.CompareTo(a.Item2.Value) : string.CompareOrdinal(a.Item1, b.Item1));
        return list;
    }

    public bool Handle(object packet) {
        switch (packet) {
            case ClientBoundUpdateObjectivePacket objective:
                if (objective.UpdateMode == ClientBoundUpdateObjectivePacket.Mode.Remove) {
                    Objectives.Remove(objective.ObjectiveName);
                    foreach (Dictionary<string, Score> scores in Scores.Values) {
                        scores.Remove(objective.ObjectiveName);
                    }
                }
                else {
                    Objectives[objective.ObjectiveName] = new Objective(objective.ObjectiveName,
                        objective.ObjectiveValue ?? TextComponent.Text(objective.ObjectiveName),
                        objective.ObjectiveType ?? ClientBoundUpdateObjectivePacket.Type.Integer,
                        objective.NumberFormat is { Present: true } format ? format.Value : null);
                }
                return true;
            case ClientBoundUpdateScorePacket score:
                if (!Scores.TryGetValue(score.EntityName, out Dictionary<string, Score>? holderScores)) {
                    holderScores = new Dictionary<string, Score>();
                    Scores[score.EntityName] = holderScores;
                }
                holderScores[score.ObjectiveName] = new Score(score.Value, score.DisplayName, score.NumberFormat);
                return true;
            case ClientBoundResetScorePacket reset:
                if (reset.ObjectiveName == null) {
                    Scores.Remove(reset.EntityName);
                }
                else if (Scores.TryGetValue(reset.EntityName, out Dictionary<string, Score>? existing)) {
                    existing.Remove(reset.ObjectiveName);
                }
                return true;
            case ClientBoundDisplayObjectivePacket display:
                if (display.ScoreName.Length == 0) {
                    Displayed.Remove(display.Position);
                }
                else {
                    Displayed[display.Position] = display.ScoreName;
                }
                return true;
            case ClientBoundUpdateTeamsPacket teams:
                HandleTeams(teams);
                return true;
        }
        return false;
    }

    private void HandleTeams(ClientBoundUpdateTeamsPacket packet) {
        if (packet.Action == ClientBoundUpdateTeamsPacket.Method.RemoveTeam) {
            if (Teams.Remove(packet.TeamName, out Team? removed)) {
                foreach (string member in removed.Members) {
                    _teamOf.Remove(member);
                }
            }
            return;
        }
        if (!Teams.TryGetValue(packet.TeamName, out Team? team)) {
            team = new Team(packet.TeamName);
            Teams[packet.TeamName] = team;
        }
        if (packet.Action is ClientBoundUpdateTeamsPacket.Method.CreateTeam or ClientBoundUpdateTeamsPacket.Method.UpdateTeamInfo) {
            team.DisplayName = packet.TeamDisplayName ?? team.DisplayName;
            team.Prefix = packet.Prefix ?? team.Prefix;
            team.Suffix = packet.Suffix ?? team.Suffix;
            team.Colour = packet.Color ?? team.Colour;
            team.NameTags = packet.NameTagVisibilityRule ?? team.NameTags;
            team.Collision = packet.CollisionRuleOption ?? team.Collision;
        }
        if (packet.Action is ClientBoundUpdateTeamsPacket.Method.CreateTeam or ClientBoundUpdateTeamsPacket.Method.AddEntities) {
            foreach (string member in packet.Entities ?? []) {
                if (_teamOf.TryGetValue(member, out Team? previous)) {
                    previous.Members.Remove(member);
                }
                team.Members.Add(member);
                _teamOf[member] = team;
            }
        }
        else if (packet.Action == ClientBoundUpdateTeamsPacket.Method.RemoveEntities) {
            foreach (string member in packet.Entities ?? []) {
                team.Members.Remove(member);
                _teamOf.Remove(member);
            }
        }
    }

    public void Clear() {
        Objectives.Clear();
        Scores.Clear();
        Displayed.Clear();
        Teams.Clear();
        _teamOf.Clear();
    }
}
