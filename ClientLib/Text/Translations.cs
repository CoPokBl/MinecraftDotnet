namespace ClientLib;

/// <summary>A resource pack's language over this client's own English for the keys servers send most.</summary>
public static class Translations {
    private static volatile IReadOnlyDictionary<string, string> _pack = new Dictionary<string, string>();

    private static readonly Dictionary<string, string> Table = new() {
        ["chat.type.text"] = "<%s> %s",
        ["chat.type.text.narrate"] = "%s says: %s",
        ["chat.type.emote"] = "* %s %s",
        ["chat.type.announcement"] = "[%s] %s",
        ["chat.type.admin"] = "[%s: %s]",
        ["chat.type.team.text"] = "%s <%s> %s",
        ["chat.type.team.sent"] = "-> %s <%s> %s",
        ["chat.type.advancement.task"] = "%s unlocked %s",
        ["chat.type.advancement.goal"] = "%s made it to %s",
        ["chat.type.advancement.challenge"] = "%s conquered %s",
        ["commands.message.display.incoming"] = "%s leans in: %s",
        ["commands.message.display.outgoing"] = "You lean in to %s: %s",
        ["multiplayer.player.joined"] = "%s wandered in",
        ["multiplayer.player.joined.renamed"] = "%s (formerly %s) wandered in",
        ["multiplayer.player.left"] = "%s wandered off",
        ["multiplayer.disconnect.kicked"] = "An operator showed you the door",
        ["multiplayer.disconnect.server_shutdown"] = "The server has packed up for the day",
        ["multiplayer.disconnect.duplicate_login"] = "Someone else just signed in as you",
        ["multiplayer.disconnect.not_whitelisted"] = "You are not on the guest list",
        ["multiplayer.disconnect.server_full"] = "No room at the inn: the server is full",
        ["multiplayer.disconnect.outdated_client"] = "This client is behind the times; the server wants %s",
        ["multiplayer.disconnect.incompatible"] = "Version mismatch; the server speaks %s",
        ["multiplayer.disconnect.idling"] = "You dozed off for too long",
        ["multiplayer.disconnect.invalid_player_movement"] = "The server did not believe that move",
        ["multiplayer.disconnect.flying"] = "No flying allowed here",
        ["multiplayer.disconnect.unverified_username"] = "Nobody could vouch for that username",
        ["disconnect.timeout"] = "The server stopped answering",
        ["disconnect.disconnected"] = "Disconnected",
        ["disconnect.closed"] = "The connection was closed",
        ["disconnect.lost"] = "The connection slipped away",
        ["disconnect.endOfStream"] = "The server hung up mid-sentence",
        ["death.attack.generic"] = "%1$s has perished",
        ["death.attack.player"] = "%1$s was bested by %2$s",
        ["death.attack.mob"] = "%1$s lost a scuffle with %2$s",
        ["death.attack.fall"] = "%1$s misjudged the drop",
        ["death.fell.accident.generic"] = "%1$s took a tumble",
        ["death.attack.outOfWorld"] = "%1$s dropped into the void",
        ["death.attack.lava"] = "%1$s went for a swim in lava",
        ["death.attack.inFire"] = "%1$s got too close to the fire",
        ["death.attack.onFire"] = "%1$s burned to a crisp",
        ["death.attack.drown"] = "%1$s forgot to come up for air",
        ["death.attack.starve"] = "%1$s forgot to eat",
        ["death.attack.explosion"] = "%1$s went out with a bang",
        ["death.attack.explosion.player"] = "%1$s was blasted by %2$s",
        ["death.attack.arrow"] = "%1$s caught an arrow from %2$s",
        ["death.attack.kill"] = "%1$s was removed from play",
        ["commands.gamemode.success.self"] = "You are now playing in %s",
        ["commands.gamemode.success.other"] = "%s is now playing in %s",
        ["gameMode.survival"] = "Survival",
        ["gameMode.creative"] = "Creative",
        ["gameMode.adventure"] = "Adventure",
        ["gameMode.spectator"] = "Spectator",
        ["spectatorMenu.close"] = "Close this menu",
        ["spectatorMenu.next_page"] = "Next page",
        ["spectatorMenu.previous_page"] = "Previous page",
        ["spectatorMenu.root.prompt"] = "Pick a number, then press it again to go",
        ["spectatorMenu.teleport"] = "Hop over to a player",
        ["spectatorMenu.teleport.prompt"] = "Who do you want to visit?",
        ["spectatorMenu.team_teleport"] = "Hop over to a teammate",
        ["spectatorMenu.team_teleport.prompt"] = "Which team?",
        ["commands.teleport.success.entity.single"] = "Whisked %s over to %s",
        ["commands.teleport.success.location.single"] = "Whisked %s off to %s, %s, %s",
        ["commands.time.set"] = "The clock now reads %s",
        ["commands.weather.set.clear"] = "The skies have cleared",
        ["commands.weather.set.rain"] = "Let it rain",
        ["commands.weather.set.thunder"] = "A storm rolls in",
        ["commands.give.success.single"] = "Handed over %s %s to %s",
        ["commands.op.success"] = "%s now holds the keys to the server",
        ["commands.help.failed"] = "No such command, or you are not allowed to use it",
        ["command.unknown.command"] = "That command does not ring a bell",
        ["command.unknown.argument"] = "That argument does not fit here",
        ["command.context.here"] = "<-- here",
        ["command.context.parse_error"] = "%s, at position %s: %s",
        ["chat.square_brackets"] = "[%s]",
        ["chat.coordinates"] = "%s, %s, %s",
        ["sleep.players_sleeping"] = "%s of %s are snoozing",
        ["block.minecraft.spawn.not_valid"] = "Your bed is missing or blocked, so there is nowhere to respawn",
        ["gui.done"] = "Done",
        ["gui.cancel"] = "Cancel",
        ["advMode.setCommand"] = "What should this block run?",
        ["advMode.command"] = "Command",
        ["advMode.previousOutput"] = "What it said last",
        ["advMode.mode.redstone"] = "Impulse",
        ["advMode.mode.sequence"] = "Chain",
        ["advMode.mode.auto"] = "Repeat",
        ["advMode.mode.conditional"] = "Conditional",
        ["advMode.mode.unconditional"] = "Unconditional",
        ["advMode.mode.redstoneTriggered"] = "Waits for Redstone",
        ["advMode.mode.autoexec.bat"] = "Always Running",
        ["advMode.setCommand.success"] = "Command is now: %s",
        ["options.generic_value"] = "%s: %s",
        ["test_block.message"] = "Message:",
        ["test_block.mode.start"] = "Start",
        ["test_block.mode.log"] = "Log",
        ["test_block.mode.fail"] = "Fail",
        ["test_block.mode.accept"] = "Accept",
        ["test_block.mode_info.start"] = "Start: where the test begins",
        ["test_block.mode_info.log"] = "Log: writes the message to the log",
        ["test_block.mode_info.fail"] = "Fail: the test fails here",
        ["test_block.mode_info.accept"] = "Accept: this part of the test passes",
        ["jigsaw_block.pool"] = "Pool:",
        ["jigsaw_block.name"] = "Name:",
        ["jigsaw_block.target"] = "Target:",
        ["jigsaw_block.final_state"] = "Becomes:",
        ["jigsaw_block.selection_priority"] = "Pick Order:",
        ["jigsaw_block.selection_priority.tooltip"] = "The order this jigsaw tries to connect to its target while its piece is processed. Higher goes first; ties are random.",
        ["jigsaw_block.placement_priority"] = "Build Order:",
        ["jigsaw_block.placement_priority.tooltip"] = "The order the piece this jigsaw connects to is processed in. Higher goes first; ties go in the order they were added.",
        ["jigsaw_block.joint_label"] = "Joint:",
        ["jigsaw_block.joint.rollable"] = "Rollable",
        ["jigsaw_block.joint.aligned"] = "Aligned",
        ["jigsaw_block.levels"] = "Depth: %s",
        ["jigsaw_block.keep_jigsaws"] = "Leave Jigsaws",
        ["jigsaw_block.generate"] = "Generate",
        ["book.pageIndicator"] = "Page %1$s / %2$s",
        ["book.signButton"] = "Sign",
        ["book.editTitle"] = "Give your book a title:",
        ["book.byAuthor"] = "written by %1$s",
        ["book.finalizeButton"] = "Sign & Close",
        ["book.finalizeWarning"] = "Heads up: once signed, this book is sealed for good.",
        ["block.minecraft.beacon.primary"] = "Main Power",
        ["block.minecraft.beacon.secondary"] = "Bonus Power",
        ["connect.connecting"] = "Knocking on the server's door...",
        ["connect.authorizing"] = "Showing our ID...",
        ["connect.joining"] = "Stepping inside...",
        ["multiplayer.downloadingTerrain"] = "Unpacking the scenery...",
        ["menu.game"] = "Paused (sort of)",
        ["menu.returnToGame"] = "Jump Back In",
        ["menu.options"] = "Settings...",
        ["menu.disconnect"] = "Leave Server",
        ["options.title"] = "Settings",
        ["options.on"] = "On",
        ["options.off"] = "Off",
        ["options.sounds"] = "Sounds & Music...",
        ["options.sounds.title"] = "Sounds & Music",
        ["options.video"] = "Graphics...",
        ["options.videoTitle"] = "Graphics",
        ["options.accessibility"] = "Accessibility...",
        ["options.accessibility.title"] = "Accessibility",
        ["options.fov"] = "Field of View",
        ["options.fov.min"] = "Default",
        ["options.fov.max"] = "Fish-eye",
        ["options.sensitivity"] = "Mouse Speed",
        ["options.sensitivity.min"] = "Glacial",
        ["options.sensitivity.max"] = "Ludicrous",
        ["options.entityDistanceScaling"] = "Entity Range",
        ["options.vignette"] = "Edge Shading",
        ["options.screenEffectScale"] = "Screen Wobble",
        ["options.fovEffectScale"] = "Zoom Effects",
        ["options.glintSpeed"] = "Shimmer Speed",
        ["options.glintStrength"] = "Shimmer Strength",
        ["soundCategory.master"] = "Everything",
        ["soundCategory.music"] = "Music",
        ["soundCategory.record"] = "Jukeboxes & Note Blocks",
        ["soundCategory.weather"] = "Weather",
        ["soundCategory.block"] = "Blocks",
        ["soundCategory.hostile"] = "Monsters",
        ["soundCategory.neutral"] = "Animals & Friends",
        ["soundCategory.player"] = "Players",
        ["soundCategory.ambient"] = "Surroundings",
        ["soundCategory.voice"] = "Voices",
        ["soundCategory.ui"] = "Menus",
        ["multiplayer.stopSleeping"] = "Get Up",
        ["itemGroup.search.hint"] = "Find an item...",
        ["lectern.take_book"] = "Take the Book",
        ["effect.duration.infinite"] = "**:**",
        ["enchantment.level.1"] = "I",
        ["enchantment.level.2"] = "II",
        ["enchantment.level.3"] = "III",
        ["enchantment.level.4"] = "IV",
        ["enchantment.level.5"] = "V",
        ["enchantment.level.6"] = "VI",
        ["enchantment.level.7"] = "VII",
        ["enchantment.level.8"] = "VIII",
        ["enchantment.level.9"] = "IX",
        ["enchantment.level.10"] = "X",
    };

    /// <summary><c>Language.UNSUPPORTED_FORMAT_PATTERN</c>: a number format the formatter cannot do becomes a plain <c>%s</c>.</summary>
    private static readonly System.Text.RegularExpressions.Regex UnsupportedFormat = new(@"%(\d+\$)?[\d.]*[df]");

    /// <summary><c>ClientLanguage.loadFrom</c>: language files lowest pack first, a later value replacing an earlier one.</summary>
    public static void Load(IEnumerable<IReadOnlyDictionary<string, string>> files) {
        Dictionary<string, string> merged = new();
        foreach (IReadOnlyDictionary<string, string> file in files) {
            foreach ((string key, string value) in file) {
                merged[key] = UnsupportedFormat.Replace(value, "%$1s");
            }
        }
        _pack = merged;
    }

    public static string? Get(string key) {
        if (_pack.TryGetValue(key, out string? value) || Table.TryGetValue(key, out value) || CommandTranslations.Table.TryGetValue(key, out value)) {
            return value;
        }
        if (key.StartsWith("death.", StringComparison.Ordinal)) {
            return key.Contains(".player") || key.Contains(".item") ? "%1$s was bested by %2$s" : "%1$s has perished";
        }
        return NameFromKey(key);
    }

    private static readonly string[] NamedKinds = ["item.", "block.", "entity.", "biome.", "effect.", "enchantment.", "container."];

    /// <summary><c>item.minecraft.diamond_sword</c> reads as "Diamond Sword".</summary>
    private static string? NameFromKey(string key) {
        if (key.StartsWith("advancements.", StringComparison.Ordinal) && key.EndsWith(".title", StringComparison.Ordinal)) {
            return TitleCase(key.Split('.')[^2]);
        }
        return NamedKinds.Any(kind => key.StartsWith(kind, StringComparison.Ordinal)) ? TitleCase(key[(key.LastIndexOf('.') + 1)..]) : null;
    }

    private static string TitleCase(string path) =>
        string.Join(' ', path.Split('_', StringSplitOptions.RemoveEmptyEntries).Select(word => char.ToUpperInvariant(word[0]) + word[1..]));
}
