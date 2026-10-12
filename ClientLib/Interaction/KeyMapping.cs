namespace ClientLib.Interaction;

/// <summary><c>KeyMapping</c>: whether a key is down, and the presses the next tick has yet to handle.</summary>
/// <param name="repeats">
/// A held keyboard key repeats, and vanilla counts every repeat as a click; a mouse button never does,
/// so pressing one that is already down is no click until it has been let go.
/// </param>
public sealed class KeyMapping(bool repeats) {
    private int _clickCount;

    public bool IsDown { get; private set; }

    /// <summary><c>KeyMapping.set</c> to down and <c>KeyMapping.click</c>.</summary>
    public void Press() {
        if (IsDown && !repeats) {
            return;
        }
        IsDown = true;
        _clickCount++;
    }

    /// <summary><c>KeyMapping.setDown</c>: a key let go, or <c>KeyMapping.setAll</c> reading the keys again. Neither is a click.</summary>
    public void SetDown(bool down) => IsDown = down;

    /// <summary><c>KeyMapping.release</c>, which a screen opening does to every mapping, presses not yet handled included.</summary>
    public void Release() {
        _clickCount = 0;
        IsDown = false;
    }

    public bool ConsumeClick() {
        if (_clickCount == 0) {
            return false;
        }
        _clickCount--;
        return true;
    }
}

/// <summary>
/// The mappings whose handling sends packets. They are read only inside <see cref="MultiPlayerGameMode.Tick"/>,
/// in <c>Minecraft.handleKeybinds</c>'s order, so whatever presses them, a window between frames or a bot
/// between ticks, nothing they do reaches the server outside a tick or faster than vanilla's delays allow.
/// </summary>
public sealed class KeyMappings {
    public KeyMapping Attack { get; } = new(false);
    public KeyMapping Use { get; } = new(false);
    public KeyMapping PickItem { get; } = new(false);

    /// <summary><c>keySpectatorHotbar</c>, on the same button as <see cref="PickItem"/>: both see a press.</summary>
    public KeyMapping SpectatorHotbar { get; } = new(false);
    public KeyMapping Drop { get; } = new(true);
    public KeyMapping SwapOffhand { get; } = new(true);
    public KeyMapping[] Hotbar { get; } = Enumerable.Range(0, 9).Select(_ => new KeyMapping(true)).ToArray();

    /// <summary><c>Minecraft.hasControlDown</c>, which a drop and a pick read as they are handled.</summary>
    public bool ControlDown { get; set; }

    /// <summary><c>KeyMapping.releaseAll</c>.</summary>
    public void ReleaseAll() {
        foreach (KeyMapping key in (KeyMapping[])[Attack, Use, PickItem, SpectatorHotbar, Drop, SwapOffhand, .. Hotbar]) {
            key.Release();
        }
    }
}
