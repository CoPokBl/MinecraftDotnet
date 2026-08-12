using ManagedServer;
using ManagedServer.Dialogs;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Dialogs;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.Dialogs;

/// <summary>
/// Dialog API demo. Type a word in chat to open the dialog it names.
/// </summary>
public static class DialogTest {

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New(ManagedMinecraftServer.BasicsBundle);
        World world = server.CreateWorld(new VoidProvider());

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3<double>(0, 64, 0));
            e.Player.SendMessage("Say 'form', 'confirm', 'notice' or 'menu' to open a dialog.");
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            switch (e.RawMessage) {
                case "form":
                    ShowForm(e.Player);
                    break;

                case "confirm":
                    e.Player.ShowDialog(ManagedDialog.Confirmation("Are you sure?", "This will do nothing.",
                        r => r.Player.SendMessage("You said yes."),
                        r => r.Player.SendMessage("You said no.")));
                    break;

                case "notice":
                    e.Player.ShowDialog(ManagedDialog.Notice("Notice", "Nothing has happened."));
                    break;

                case "menu":
                    ShowMenu(e.Player);
                    break;
            }
        });

        server.Start();
        await server.ListenTcp(25565);
    }

    private static void ShowForm(Player player) {
        player.ShowDialog(new DialogBuilder("Tell me about yourself")
            .Body("Every input comes back keyed by the name it was given.")
            .TextInput("name", "Name", maxLength: 16)
            .NumberInput("age", "Age", 0, 100, initial: 20, step: 1)
            .OptionInput("colour", "Favourite colour",
                new SingleOptionEntry("red", "Red", true),
                new SingleOptionEntry("green", "Green"),
                new SingleOptionEntry("blue", "Blue"))
            .BooleanInput("loud", "Shout it")
            .Button("Send", r => {
                string name = r.GetString("name", "nobody");
                string message = $"{name}, {r.GetInt("age")}, likes {r.GetString("colour")}";
                r.Player.SendMessage(r.GetBool("loud") ? message.ToUpperInvariant() : message);
            })
            .Button("Cancel", null));
    }

    private static void ShowMenu(Player player) {
        // Left up so the buttons keep working, which means it has to be closed by hand
        player.ShowDialog(new DialogBuilder("Menu")
            .AfterAction(DialogAfterAction.None)
            .Body("This one stays open until you press Done.")
            .Button("Day", r => r.Player.World!.Time = 1000)
            .Button("Night", r => r.Player.World!.Time = 13000)
            .Button("Heal", r => r.Player.Heal())
            .ExitButton("Done", r => r.Player.CloseDialog()));
    }
}
