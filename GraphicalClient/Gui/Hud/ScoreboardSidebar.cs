using ClientLib;
using Minecraft.Schemas.Objectives;
using Minecraft.Text;
using NBT;
using NBT.Tags;
using DisplayPosition = Minecraft.Packets.Play.ClientBound.ClientBoundDisplayObjectivePacket.DisplayPosition;

namespace GraphicalClient.Gui;

/// <summary>The sidebar objective, vanilla's <c>displayScoreboardSidebar</c>: holders left, scores right.</summary>
public static class ScoreboardSidebar {
    /// <summary><c>Hud.extractScoreboardSidebar</c>: the objective for the player's team colour, else the sidebar's.</summary>
    public static void Draw(GuiContext context, MinecraftClient client, int w, int h) {
        Objective? teamObjective = null;
        if (client.Scoreboard.TeamOf(client.Profile.Username) is { Colour: { } colour } && (int)colour < 16) {
            teamObjective = client.Scoreboard.DisplayedIn(DisplayPosition.TeamBlack + (int)colour);
        }
        if ((teamObjective ?? client.Scoreboard.DisplayedIn(DisplayPosition.Sidebar)) is not { } objective) {
            return;
        }
        List<(List<TextRun> Name, List<TextRun> Score, int ScoreWidth)> entries = [];
        foreach ((string holder, Score score) in client.Scoreboard.Ranked(objective.Name).Take(15)) {
            TextComponent ownerName = score.DisplayName ?? TextComponent.Text(holder);
            List<TextRun> name = TextFlattener.Flatten(Team.FormatNameForTeam(client.Scoreboard.TeamOf(holder), ownerName));
            List<TextRun> scoreString = TextFlattener.Flatten(FormatValue(score.NumberFormat ?? objective.NumberFormat, score.Value));
            entries.Add((name, scoreString, context.Text.Width(scoreString)));
        }

        List<TextRun> objectiveDisplayName = TextFlattener.Flatten(objective.DisplayName);
        int objectiveDisplayNameWidth = context.Text.Width(objectiveDisplayName);
        int biggestWidth = objectiveDisplayNameWidth;
        int spacerWidth = context.Text.Width(": ");
        foreach ((List<TextRun> name, _, int scoreWidth) in entries) {
            biggestWidth = Math.Max(biggestWidth, context.Text.Width(name) + (scoreWidth > 0 ? spacerWidth + scoreWidth : 0));
        }

        int entriesCount = entries.Count;
        int height = entriesCount * 9;
        int bottom = h / 2 + height / 3;
        int left = w - biggestWidth - 3;
        int right = w - 3 + 2;
        int headerY = bottom - entriesCount * 9;
        context.Gui.Rect(left - 2, headerY - 9 - 1, right - (left - 2), 9, 0x66000000);
        context.Gui.Rect(left - 2, headerY - 1, right - (left - 2), bottom - (headerY - 1), 0x4C000000);
        context.Text.Draw(objectiveDisplayName, left + biggestWidth / 2 - objectiveDisplayNameWidth / 2, headerY - 9, shadow: false);
        for (int i = 0; i < entriesCount; i++) {
            int y = bottom - (entriesCount - i) * 9;
            context.Text.Draw(entries[i].Name, left, y, shadow: false);
            context.Text.Draw(entries[i].Score, right - entries[i].ScoreWidth, y, shadow: false);
        }
    }

    /// <summary><c>NumberFormat.format</c>, with the sidebar's default of red numbers.</summary>
    private static TextComponent FormatValue(INumberFormat? format, int value) => format switch {
        BlankNumberFormat => TextComponent.Text(""),
        FixedNumberFormat fixedFormat => fixedFormat.Content,
        StyledNumberFormat styled => TextComponent.FromTag(new CompoundTag(styled.Styling.Children
            .Where(c => c.key != "text").Append(("text", new StringTag(value.ToString()))).ToArray())),
        _ => TextComponent.Text(value.ToString()).WithColor(TextColor.Red)
    };
}
