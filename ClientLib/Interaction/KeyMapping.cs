using ClientLib.Player;

namespace ClientLib.Interaction;

/// <summary><c>KeyMapping</c>: whether a key is down, and the presses the next tick has yet to handle.</summary>
/// <param name="repeats">
/// A held keyboard key repeats, and vanilla counts every repeat as a click; a mouse button never does,
/// so pressing one that is already down is no click until it has been let go.
/// </param>
public sealed class KeyMapping(bool repeats) {
    private int _clickCount;
    private bool _releasedByScreenWhenDown;

    public bool IsDown { get; private set; }

    /// <summary>
    /// <c>ToggleKeyMapping</c>'s <c>needsToggle</c>, set only on the mappings vanilla makes one of. Such a
    /// mapping keeps its presses through <see cref="Release"/> whether or not it toggles.
    /// </summary>
    public Func<bool>? NeedsToggle { get; init; }

    /// <summary><c>ToggleKeyMapping.shouldRestore</c>: a toggled key is pressed again when the screen that released it closes.</summary>
    public bool RestoresAfterScreen { get; init; }

    private bool Toggles => NeedsToggle?.Invoke() == true;

    /// <summary><c>KeyMapping.set</c> to down and <c>KeyMapping.click</c>.</summary>
    public void Press() {
        if (IsDown && !repeats && !Toggles) {
            return;
        }
        SetDown(true);
        _clickCount++;
    }

    /// <summary><c>KeyMapping.click</c>: a press for the next tick, which the window counts after setting the key down.</summary>
    public void Click() => _clickCount++;

    /// <summary>
    /// <c>KeyMapping.setDown</c>: a key let go, or <c>KeyMapping.setAll</c> reading the keys again. Neither is
    /// a click. A toggling mapping flips on a press and ignores the release.
    /// </summary>
    public void SetDown(bool down) {
        if (!Toggles) {
            IsDown = down;
        }
        else if (down) {
            IsDown = !IsDown;
        }
    }

    /// <summary>
    /// <c>KeyMapping.release</c>, which a screen opening does to every mapping, presses not yet handled
    /// included; <c>ToggleKeyMapping.release</c> lets go but keeps the presses, noting a toggled key it let go.
    /// </summary>
    public void Release() {
        if (NeedsToggle != null) {
            if (Toggles && IsDown || _releasedByScreenWhenDown) {
                _releasedByScreenWhenDown = true;
            }
            IsDown = false;
            return;
        }
        _clickCount = 0;
        IsDown = false;
    }

    /// <summary>
    /// <c>ToggleKeyMapping.shouldRestoreStateOnScreenClosed</c>, which forgets the release it read.
    /// </summary>
    /// <param name="onKeyboard">The mapping is bound to a keyboard key by its key code.</param>
    public bool ShouldRestoreStateOnScreenClosed(bool onKeyboard) {
        bool restore = RestoresAfterScreen && Toggles && onKeyboard && _releasedByScreenWhenDown;
        _releasedByScreenWhenDown = false;
        return restore;
    }

    /// <summary><c>ToggleKeyMapping.reset</c>: let go without toggling.</summary>
    public void ResetToggle() {
        if (NeedsToggle != null) {
            IsDown = false;
        }
    }

    /// <summary><c>KeyMapping.shouldSetOnIngameFocus</c>, given that the key is a known keyboard key: not a toggling one.</summary>
    public bool FollowsKeyOnFocus => !Toggles;

    public bool ConsumeClick() {
        if (_clickCount == 0) {
            return false;
        }
        _clickCount--;
        return true;
    }
}

/// <summary>
/// The mappings whose handling sends packets, and the movement keys <see cref="KeyboardInput"/> reads. The
/// first are read only inside <see cref="MultiPlayerGameMode.Tick"/>, in <c>Minecraft.handleKeybinds</c>'s
/// order, so whatever presses them, a window between frames or a bot between ticks, nothing they do
/// reaches the server outside a tick or faster than vanilla's delays allow.
/// </summary>
public sealed class KeyMappings {
    private Func<bool> _toggleAttack = () => false, _toggleUse = () => false, _toggleCrouch = () => false, _toggleSprint = () => false;

    public KeyMappings() {
        Attack = new KeyMapping(false) { NeedsToggle = () => _toggleAttack(), RestoresAfterScreen = true };
        Use = new KeyMapping(false) { NeedsToggle = () => _toggleUse() };
        Sneak = new KeyMapping(true) { NeedsToggle = () => _toggleCrouch(), RestoresAfterScreen = true };
        Sprint = new KeyMapping(true) { NeedsToggle = () => _toggleSprint(), RestoresAfterScreen = true };
    }

    public KeyMapping Attack { get; }
    public KeyMapping Use { get; }
    public KeyMapping PickItem { get; } = new(false);

    /// <summary><c>keySpectatorHotbar</c>, on the same button as <see cref="PickItem"/>: both see a press.</summary>
    public KeyMapping SpectatorHotbar { get; } = new(false);
    public KeyMapping Drop { get; } = new(true);
    public KeyMapping SwapOffhand { get; } = new(true);
    public KeyMapping[] Hotbar { get; } = Enumerable.Range(0, 9).Select(_ => new KeyMapping(true)).ToArray();
    public KeyMapping Forward { get; } = new(true);
    public KeyMapping Left { get; } = new(true);
    public KeyMapping Back { get; } = new(true);
    public KeyMapping Right { get; } = new(true);
    public KeyMapping Jump { get; } = new(true);
    public KeyMapping Sneak { get; }
    public KeyMapping Sprint { get; }

    /// <summary><c>Minecraft.hasControlDown</c>, which a drop and a pick read as they are handled.</summary>
    public bool ControlDown { get; set; }

    /// <summary>Where the options <c>toggleAttack</c>, <c>toggleUse</c>, <c>toggleCrouch</c> and <c>toggleSprint</c> are read, each time a mapping needs one.</summary>
    public void UseToggleOptions(Func<bool> attack, Func<bool> use, Func<bool> crouch, Func<bool> sprint) =>
        (_toggleAttack, _toggleUse, _toggleCrouch, _toggleSprint) = (attack, use, crouch, sprint);

    private IEnumerable<KeyMapping> All => [Attack, Use, PickItem, SpectatorHotbar, Drop, SwapOffhand, .. Hotbar, Forward, Left, Back, Right, Jump, Sneak, Sprint];

    /// <summary><c>KeyMapping.releaseAll</c>.</summary>
    public void ReleaseAll() {
        foreach (KeyMapping key in All) {
            key.Release();
        }
    }

    /// <summary><c>KeyMapping.resetToggleKeys</c>, which a respawn does.</summary>
    public void ResetToggleKeys() {
        foreach (KeyMapping key in All) {
            key.ResetToggle();
        }
    }

    /// <summary><c>KeyboardInput.tick</c>'s key reads.</summary>
    public PlayerInput KeyboardInput() => new(Forward.IsDown, Back.IsDown, Left.IsDown, Right.IsDown, Jump.IsDown, Sneak.IsDown, Sprint.IsDown);
}
