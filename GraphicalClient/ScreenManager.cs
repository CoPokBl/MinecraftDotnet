using ClientLib;
using ClientLib.Player;
using ClientLib.World.BlockEntities;
using GraphicalClient.Gui;
using GraphicalClient.Gui.Inventory;

namespace GraphicalClient;

/// <summary>The open screen, and the screens that open and close with game state rather than a key.</summary>
public sealed class ScreenManager(MinecraftClient client, Hud hud) {
    public Screen? Current { get; private set; }
    public GuiContext Context { get; set; } = null!;

    /// <summary>Told whether to capture the mouse, which it is while no screen is open.</summary>
    public Action<bool> CaptureMouse { get; set; } = _ => { };

    public void HookClient() {
        // Vanilla's openScreen replaces whatever is open, chat included.
        client.ContainerOpened += _ => {
            if (ContainerScreens.ForOpenMenu(client) is { } screen) {
                Set(screen);
            }
        };
        client.ContainerClosed += () => {
            switch (Current) {
                case ContainerScreen container:
                    container.ClosedByServer();
                    Set(null);
                    break;
                case CreativeInventoryScreen or LecternScreen:
                    Set(null);
                    break;
            }
        };
        client.BookOpened += hand => {
            if (client.Player is { } player && ClientLib.Inventory.BookAccess.FromItem(player.ItemInHand(hand)) is { } pages) {
                Set(new BookViewScreen(pages));
            }
        };
        client.Interactions.ItemGuiOpened += (hand, stack) => {
            if (ClientLib.Inventory.BookAccess.WritableContent(stack) is { } content) {
                Set(new BookEditScreen(client, stack, hand, content));
            }
        };
        // Structure and test instance blocks have no editor here, so using one opens nothing.
        client.Interactions.GameMasterBlockOpened += blockEntity => {
            switch (blockEntity) {
                case CommandBlockEntity commandBlock:
                    Set(new CommandBlockEditScreen(commandBlock));
                    break;
                case TestBlockEntity testBlock:
                    Set(new TestBlockEditScreen(testBlock));
                    break;
                case JigsawBlockEntity jigsaw:
                    Set(new JigsawBlockEditScreen(jigsaw));
                    break;
            }
        };
        client.Interactions.MinecartCommandBlockOpened += minecart => Set(new MinecartCommandBlockEditScreen(minecart));
        client.BlockEntityDataLoaded += blockEntity => {
            if (blockEntity is CommandBlockEntity && Current is CommandBlockEditScreen screen) {
                screen.UpdateGui(Context);
            }
        };
        // LocalPlayer.handlePortalTransitionEffect: a container screen closes its menu as it goes; vanilla's
        // lectern screen is not one, so the server's lectern menu is left open.
        client.InsideConfusionPortal += () => {
            if (Current is { IsAllowedInPortal: false } screen) {
                if (screen is ContainerScreen or CreativeInventoryScreen) {
                    screen.Close(Context);
                }
                Set(null);
            }
        };
        client.Disconnected += reason => {
            Console.WriteLine($"Disconnected: {reason}");
            Set(new DisconnectedScreen(reason));
        };
    }

    public void Set(Screen? screen) {
        Current = screen;
        if (screen != null) {
            client.Interactions.Keys.ReleaseAll();
        }
        CaptureMouse(screen == null);
    }

    public void CloseIfClosed() {
        if (Current is { Closed: true }) {
            Set(null);
        }
    }

    public void OpenInventory(LocalPlayer player) {
        if (player.IsServerControlledInventory) {
            player.SendOpenInventory();
        }
        else {
            Set(ContainerScreens.PlayerInventory(client));
        }
    }

    public void OpenChat(string initial = "") => Set(new ChatScreen(hud, initial));

    /// <summary>The death screen, which follows whether the player is dead.</summary>
    public void Update() {
        LocalPlayer? player = client.Player;
        if (player is { IsDead: true, ShowDeathScreen: true } && Current is not (DeathScreen or DisconnectedScreen)) {
            Set(new DeathScreen());
        }
        else if (Current is DeathScreen && player is { IsDead: false }) {
            Set(null);
        }
    }

    /// <summary>The open screen's <c>tick</c>, then <see cref="TickBed"/>.</summary>
    public void Tick() {
        Current?.Tick(Context);
        CloseIfClosed();
        TickBed();
    }

    /// <summary><c>Gui.tick</c>'s screen check: a sleeping player gets the in bed chat, which goes once they wake.</summary>
    private void TickBed() {
        LocalPlayer? player = client.Player;
        if (Current != null || player == null) {
            if (Current is InBedChatScreen inBed && player is { IsSleeping: false }) {
                Set(inBed.OnPlayerWokeUp(Context));
            }
        }
        else if (player.IsSleeping && client.Level != null) {
            Set(new InBedChatScreen(hud));
        }
    }
}
