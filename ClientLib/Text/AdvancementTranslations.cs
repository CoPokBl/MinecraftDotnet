namespace ClientLib;

/// <summary>This client's own wording for the advancement screen, its toasts and the notification time option, under vanilla's keys.</summary>
internal static class AdvancementTranslations {
    public static readonly Dictionary<string, string> Table = new() {
        ["advancements.toast.task"] = "Milestone Reached",
        ["advancements.toast.goal"] = "Goal Met",
        ["advancements.toast.challenge"] = "Challenge Conquered",
        ["advancements.progress"] = "%s/%s",
        ["advancements.empty"] = "Nothing to work towards here yet.",
        ["advancements.sad_label"] = ":(",
        ["options.notifications.display_time"] = "Popup Duration",
        ["options.multiplier"] = "%sx"
    };
}
