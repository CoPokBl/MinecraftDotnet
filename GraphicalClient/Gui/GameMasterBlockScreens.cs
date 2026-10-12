using ClientLib;
using ClientLib.Commands;
using ClientLib.Entities;
using ClientLib.World.BlockEntities;
using GraphicalClient.Gui.Inventory;
using Silk.NET.Input;
using CommandBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundProgramCommandBlockPacket.CommandBlockMode;
using JigsawJointType = Minecraft.Packets.Play.ServerBound.ServerBoundProgramJigsawBlockPacket.JigsawJointType;
using TestBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundSetTestBlockPacket.TestBlockMode;

namespace GraphicalClient.Gui;

/// <summary>
/// A screen of edit boxes and buttons with vanilla's focus: a click focuses the first child under it,
/// keys and typing go to the focused child, and Enter or Space presses a focused button. Tab and arrow
/// navigation between children is not ported. Children go in <see cref="InitChildren"/>.
/// </summary>
public abstract class FocusScreen : Screen {
    private readonly List<object> _children = [];
    private object? _focused;
    private Slider? _dragging;
    private bool _initialized;

    protected const uint LabelColor = 0xFFA0A0A0;

    protected static bool Shift => ContainerScreen.ShiftHeld();

    protected static string Tr(string key) => Translations.Get(key) ?? key;

    /// <summary><c>Screen.isInGameUi</c>'s background: <c>extractTransparentBackground</c>'s gradient, flattened.</summary>
    protected static void TransparentBackground(GuiContext context) => context.Gui.Rect(0, 0, context.Width, context.Height, 0xC8101010);

    protected sealed override void Init(GuiContext context, int width, int height) {
        _children.Clear();
        _dragging = null;
        SetFocus(null);
        InitChildren(context, width, height, !_initialized);
        _initialized = true;
    }

    /// <summary><c>init</c>, which a resize runs again with <paramref name="first"/> false.</summary>
    protected abstract void InitChildren(GuiContext context, int width, int height, bool first);

    protected T AddChild<T>(T child) where T : class {
        _children.Add(child);
        return child;
    }

    protected void SetFocus(object? child) {
        if (_focused is EditBox old) {
            old.Focused = false;
        }
        _focused = child;
        if (child is EditBox box) {
            box.Focused = true;
        }
    }

    /// <summary>The buttons, highlighted while hovered or focused; edit boxes are drawn by the screen where vanilla draws them.</summary>
    protected void RenderButtons(GuiContext context) {
        foreach (object child in _children) {
            if (child is Widget { Visible: true } widget) {
                widget.Render(context, widget.Active && (widget.Contains(context.MouseX, context.MouseY) || widget == _focused));
            }
        }
    }

    private static bool IsMouseOver(object child, float x, float y) => child switch {
        EditBox box => box.IsMouseOver(x, y),
        Widget widget => widget is { Visible: true, Active: true } && widget.Contains(x, y),
        _ => false
    };

    /// <summary><c>ContainerEventHandler.mouseClicked</c>: whether a child was under the click.</summary>
    protected bool ClickChildren(GuiContext context, float x, float y, MouseButton button) {
        if (_children.FirstOrDefault(child => IsMouseOver(child, x, y)) is not { } clicked) {
            return false;
        }
        if (button == MouseButton.Left) {
            if (clicked is EditBox box) {
                box.OnClick(x, Shift);
            }
            else {
                ((Widget)clicked).OnClick(context, x);
                _dragging = clicked as Slider;
            }
            SetFocus(clicked);
        }
        return true;
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        SetMouse(x, y);
        _dragging?.SetFromMouse(x);
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        if (_dragging != null && button == MouseButton.Left) {
            _dragging = null;
            PlayDownSound(context);
        }
    }

    /// <summary><c>Screen.keyPressed</c> without the focus navigation: Escape, then the focused child.</summary>
    protected bool KeyToChildren(GuiContext context, Key key, bool control) {
        if (key == Key.Escape && CloseOnEscape) {
            Close(context);
            return true;
        }
        switch (_focused) {
            case EditBox box:
                return box.KeyPressed(context, key, control, Shift);
            case Widget { Visible: true, Active: true } widget when key is Key.Enter or Key.KeypadEnter or Key.Space:
                widget.OnClick(context, widget.X);
                return true;
            default:
                return false;
        }
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        KeyToChildren(context, key, control);
    }

    public override void Char(GuiContext context, char c) {
        LayOut(context);
        (_focused as EditBox)?.CharTyped(c);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        ClickChildren(context, x, y, button);
    }

    /// <summary><c>ContainerEventHandler.mouseScrolled</c>: the child under the cursor.</summary>
    protected bool ScrollChildren(double scrollY) =>
        _children.FirstOrDefault(child => IsMouseOver(child, MouseX, MouseY)) is Widget widget && widget.MouseScrolled(scrollY);

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        ScrollChildren(delta);
    }
}

/// <summary><c>AbstractCommandBlockEditScreen</c>. Narration is not ported.</summary>
public abstract class AbstractCommandBlockEditScreen : FocusScreen {
    protected EditBox CommandEdit = null!;
    private EditBox _previousEdit = null!;
    protected Button DoneButton = null!;
    protected CycleButton<bool> OutputButton = null!;
    private CommandSuggestions? _commandSuggestions;

    protected abstract BaseCommandBlock CommandBlock { get; }

    /// <summary><c>BaseCommandBlock.isValid</c>: the block entity or minecart is still there.</summary>
    protected abstract bool IsValid { get; }

    protected abstract int PreviousY { get; }

    public override void Tick(GuiContext context) {
        if (!IsValid) {
            Close(context);
        }
    }

    /// <summary><c>init</c>, and on a resize <c>resize</c>, which keeps what was typed.</summary>
    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        string? oldText = first ? null : CommandEdit.Value;
        bool trackOutput = CommandBlock.TrackOutput;
        CommandEdit = AddChild(new EditBox(context.Text, width / 2 - 150, 50, 300, 20) { MaxLength = 32500 });
        CommandEdit.SetResponder(_ => _commandSuggestions?.UpdateCommandInfo());
        _previousEdit = AddChild(new EditBox(context.Text, width / 2 - 150, PreviousY, 276, 20) { MaxLength = 32500, Editable = false, Value = "-" });
        OutputButton = AddChild(new CycleButton<bool>([true, false], trackOutput, value => value ? "O" : "X", width / 2 + 150 - 20, PreviousY, 20, value => {
            CommandBlock.TrackOutput = value;
            UpdatePreviousOutput(value);
        }));
        AddExtraControls(width);
        DoneButton = AddChild(new Button(Tr("gui.done"), width / 2 - 4 - 150, height / 4 + 120 + 12, 150, () => OnDone(context)));
        AddChild(new Button(Tr("gui.cancel"), width / 2 + 4, height / 4 + 120 + 12, 150, () => Close(context)));
        _commandSuggestions = new CommandSuggestions(context.Client, () => context.Height, CommandEdit, context.Text, true, true, 0, 7, false, 0x80000000);
        _commandSuggestions.SetAllowSuggestions(true);
        _commandSuggestions.UpdateCommandInfo();
        UpdatePreviousOutput(trackOutput);
        if (first) {
            SetFocus(CommandEdit);
        }
        else {
            CommandEdit.Value = oldText!;
            _commandSuggestions.UpdateCommandInfo();
        }
    }

    protected virtual void AddExtraControls(int width) {
    }

    protected void UpdatePreviousOutput(bool isTracking) =>
        _previousEdit.Value = isTracking ? TextFlattener.Plain(CommandBlock.LastOutput) : "-";

    private void OnDone(GuiContext context) {
        PopulateAndSendPacket(context.Client);
        if (!CommandBlock.TrackOutput) {
            CommandBlock.SetLastOutput(null);
        }
        context.Open?.Invoke(null);
    }

    protected abstract void PopulateAndSendPacket(MinecraftClient client);

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (_commandSuggestions!.KeyPressed(key, Shift) || KeyToChildren(context, key, control)) {
            return;
        }
        if (key is Key.Enter or Key.KeypadEnter) {
            OnDone(context);
        }
    }

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        if (!_commandSuggestions!.MouseScrolled(delta, (int)MouseX, (int)MouseY)) {
            ScrollChildren(delta);
        }
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (!_commandSuggestions!.MouseClicked(x, y)) {
            ClickChildren(context, x, y, button);
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        TransparentBackground(context);
        RenderButtons(context);
        int width = context.Width;
        context.Text.DrawCentred(Tr("advMode.setCommand"), width / 2, 20);
        context.Text.Draw(Tr("advMode.command"), width / 2 - 150 + 1, 40, LabelColor);
        CommandEdit.Render(context);
        int y = 75;
        if (_previousEdit.Value.Length > 0) {
            y += 5 * TextRenderer.LineHeight + 1 + PreviousY - 135;
            context.Text.Draw(Tr("advMode.previousOutput"), width / 2 - 150 + 1, y + 4, LabelColor);
            _previousEdit.Render(context);
        }
        _commandSuggestions!.Render(context, (int)context.MouseX, (int)context.MouseY);
    }
}

/// <summary><c>CommandBlockEditScreen</c>: greyed until the server's data for the block arrives.</summary>
public sealed class CommandBlockEditScreen(CommandBlockEntity autoCommandBlock) : AbstractCommandBlockEditScreen {
    private static readonly CommandBlockMode[] Modes = [CommandBlockMode.Sequence, CommandBlockMode.Auto, CommandBlockMode.Redstone];

    private CycleButton<CommandBlockMode> _modeButton = null!;
    private CycleButton<bool> _conditionalButton = null!;
    private CycleButton<bool> _autoexecButton = null!;
    private CommandBlockMode _mode = CommandBlockMode.Redstone;
    private bool _conditional;
    private bool _autoexec;

    protected override BaseCommandBlock CommandBlock => autoCommandBlock.CommandBlock;
    protected override bool IsValid => !autoCommandBlock.Removed;
    protected override int PreviousY => 135;

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        base.InitChildren(context, width, height, first);
        // A resize enables them whether or not the data has come.
        EnableControls(!first);
    }

    protected override void AddExtraControls(int width) {
        _modeButton = AddChild(new CycleButton<CommandBlockMode>(Modes, _mode, mode => Tr(mode switch {
            CommandBlockMode.Sequence => "advMode.mode.sequence",
            CommandBlockMode.Auto => "advMode.mode.auto",
            _ => "advMode.mode.redstone"
        }), width / 2 - 50 - 100 - 4, 165, 100, value => _mode = value));
        _conditionalButton = AddChild(new CycleButton<bool>([true, false], _conditional,
            value => Tr(value ? "advMode.mode.conditional" : "advMode.mode.unconditional"), width / 2 - 50, 165, 100, value => _conditional = value));
        _autoexecButton = AddChild(new CycleButton<bool>([true, false], _autoexec,
            value => Tr(value ? "advMode.mode.autoexec.bat" : "advMode.mode.redstoneTriggered"), width / 2 + 50 + 4, 165, 100, value => _autoexec = value));
    }

    private void EnableControls(bool state) {
        DoneButton.Active = state;
        OutputButton.Active = state;
        _modeButton.Active = state;
        _conditionalButton.Active = state;
        _autoexecButton.Active = state;
    }

    /// <summary><c>updateGui</c>, run when block entity data for a command block arrives.</summary>
    public void UpdateGui(GuiContext context) {
        LayOut(context);
        BaseCommandBlock commandBlock = autoCommandBlock.CommandBlock;
        CommandEdit.Value = commandBlock.Command;
        bool trackOutput = commandBlock.TrackOutput;
        _mode = autoCommandBlock.Mode;
        _conditional = autoCommandBlock.IsConditional;
        _autoexec = autoCommandBlock.Automatic;
        OutputButton.SetValue(trackOutput);
        _modeButton.SetValue(_mode);
        _conditionalButton.SetValue(_conditional);
        _autoexecButton.SetValue(_autoexec);
        UpdatePreviousOutput(trackOutput);
        EnableControls(true);
    }

    protected override void PopulateAndSendPacket(MinecraftClient client) =>
        client.Send(autoCommandBlock.SetCommandPacket(CommandEdit.Value, _mode, _conditional, _autoexec));
}

/// <summary><c>MinecartCommandBlockEditScreen</c>.</summary>
public sealed class MinecartCommandBlockEditScreen(ClientMinecartCommandBlock minecart) : AbstractCommandBlockEditScreen {
    protected override BaseCommandBlock CommandBlock => minecart.CommandBlock;
    protected override bool IsValid => !minecart.IsRemoved;
    protected override int PreviousY => 150;

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        base.InitChildren(context, width, height, first);
        if (first) {
            CommandEdit.Value = CommandBlock.Command;
        }
    }

    protected override void PopulateAndSendPacket(MinecraftClient client) => client.Send(minecart.SetCommandPacket(CommandEdit.Value));
}

/// <summary><c>TestBlockEditScreen</c>.</summary>
public sealed class TestBlockEditScreen(TestBlockEntity block) : FocusScreen {
    private static readonly TestBlockMode[] Modes = [TestBlockMode.Start, TestBlockMode.Log, TestBlockMode.Fail, TestBlockMode.Accept];

    private TestBlockMode _mode = block.Mode;
    private string _message = block.Message;
    private EditBox _messageEdit = null!;

    private static string ModeName(TestBlockMode mode) => mode.ToString().ToLowerInvariant();

    public override bool IsAllowedInPortal => false;

    /// <summary><c>init</c>, from the message as it was last saved: a resize drops what was typed, as vanilla's does.</summary>
    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        _messageEdit = AddChild(new EditBox(context.Text, width / 2 - 152, 80, 240, 20) { MaxLength = 128, Value = _message });
        UpdateMode(_mode);
        AddChild(new CycleButton<TestBlockMode>(Modes, _mode, mode => Tr("test_block.mode." + ModeName(mode)), width / 2 - 4 - 150, 185, 50, UpdateMode));
        AddChild(new Button(Tr("gui.done"), width / 2 - 4 - 150, 210, 150, () => OnDone(context)));
        AddChild(new Button(Tr("gui.cancel"), width / 2 + 4, 210, 150, () => Close(context)));
        if (first && _messageEdit.Visible) {
            SetFocus(_messageEdit);
        }
    }

    private void OnDone(GuiContext context) {
        _message = _messageEdit.Value;
        context.Client.Send(block.SetTestBlockPacket(_mode, _message));
        Close(context);
    }

    private void UpdateMode(TestBlockMode value) {
        _mode = value;
        _messageEdit.Visible = value != TestBlockMode.Start;
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        TransparentBackground(context);
        _messageEdit.Render(context);
        RenderButtons(context);
        int width = context.Width;
        context.Text.DrawCentred(Tr(Minecraft.Data.Generated.Block.TestBlock.TranslationKey), width / 2, 10);
        if (_mode != TestBlockMode.Start) {
            context.Text.Draw(Tr("test_block.message"), width / 2 - 153, 70, LabelColor);
        }
        context.Text.Draw(Tr("test_block.mode_info." + ModeName(_mode)), width / 2 - 153, 174, LabelColor);
    }
}

/// <summary><c>JigsawBlockEditScreen</c>.</summary>
public sealed class JigsawBlockEditScreen(JigsawBlockEntity jigsawEntity) : FocusScreen {
    private const int TooltipWidth = 170;

    private EditBox _nameEdit = null!;
    private EditBox _targetEdit = null!;
    private EditBox _poolEdit = null!;
    private EditBox _finalStateEdit = null!;
    private EditBox _selectionPriorityEdit = null!;
    private EditBox _placementPriorityEdit = null!;
    private int _levels;
    private double _levelsSlider;
    private bool _keepJigsaws = true;
    private JigsawJointType _joint;
    private Button _doneButton = null!;
    private Button _generateButton = null!;

    private void OnDone(GuiContext context) {
        SendToServer(context.Client);
        context.Open?.Invoke(null);
    }

    private void SendToServer(MinecraftClient client) => client.Send(jigsawEntity.SetJigsawBlockPacket(
        Identifiers.TryParse(_nameEdit.Value)!.Value, Identifiers.TryParse(_targetEdit.Value)!.Value, Identifiers.TryParse(_poolEdit.Value)!.Value,
        _finalStateEdit.Value, _joint, ParseAsInt(_selectionPriorityEdit.Value), ParseAsInt(_placementPriorityEdit.Value)));

    /// <summary><c>Integer.parseInt</c>, 0 where it throws: a sign is allowed, spaces are not.</summary>
    private static int ParseAsInt(string value) =>
        int.TryParse(value, System.Globalization.NumberStyles.AllowLeadingSign, System.Globalization.CultureInfo.InvariantCulture, out int parsed) ? parsed : 0;

    /// <summary><c>init</c>, and on a resize <c>resize</c>, which keeps the edits.</summary>
    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        string[]? old = first ? null : [_nameEdit.Value, _targetEdit.Value, _poolEdit.Value, _finalStateEdit.Value, _selectionPriorityEdit.Value, _placementPriorityEdit.Value];
        JigsawJointType oldJoint = _joint;
        _poolEdit = AddChild(Edit(context, width / 2 - 153, 20, 300, 128, jigsawEntity.Pool.ToString()));
        _nameEdit = AddChild(Edit(context, width / 2 - 153, 55, 300, 128, jigsawEntity.Name.ToString()));
        _targetEdit = AddChild(Edit(context, width / 2 - 153, 90, 300, 128, jigsawEntity.Target.ToString()));
        _finalStateEdit = AddChild(new EditBox(context.Text, width / 2 - 153, 125, 300, 20) { MaxLength = 256, Value = jigsawEntity.FinalState });
        _selectionPriorityEdit = AddChild(new EditBox(context.Text, width / 2 - 153, 160, 98, 20) { MaxLength = 3, Value = jigsawEntity.SelectionPriority.ToString() });
        _placementPriorityEdit = AddChild(new EditBox(context.Text, width / 2 - 50, 160, 98, 20) { MaxLength = 3, Value = jigsawEntity.PlacementPriority.ToString() });
        _joint = jigsawEntity.Joint;
        CycleButton<JigsawJointType> jointButton = AddChild(new CycleButton<JigsawJointType>([JigsawJointType.Rollable, JigsawJointType.Aligned], _joint,
            joint => Tr(joint == JigsawJointType.Rollable ? "jigsaw_block.joint.rollable" : "jigsaw_block.joint.aligned"), width / 2 + 54, 160, 100,
            value => _joint = value));
        bool vertical = jigsawEntity.FrontIsVertical;
        jointButton.Active = vertical;
        jointButton.Visible = vertical;
        // A new slider starts at the bottom even where a resize kept the levels.
        _levelsSlider = 0.0;
        AddChild(new Slider(width / 2 - 154, 185, 100, () => _levelsSlider, value => {
            _levelsSlider = value;
            _levels = (int)Math.Floor(Math.Clamp(value, 0.0, 1.0) * 20.0);
        }, _ => TextFlattener.Plain(Component.Translatable("jigsaw_block.levels", _levels))));
        // CycleButton.onOffBuilder, which shows its name as well.
        AddChild(new CycleButton<bool>([true, false], _keepJigsaws, value => TextFlattener.Plain(Component.Translatable("options.generic_value",
            Component.Translatable("jigsaw_block.keep_jigsaws"), Component.Translatable(value ? "options.on" : "options.off"))), width / 2 - 50, 185, 100,
            value => _keepJigsaws = value));
        _generateButton = AddChild(new Button(Tr("jigsaw_block.generate"), width / 2 + 54, 185, 100, () => {
            OnDone(context);
            context.Client.Send(jigsawEntity.GeneratePacket(_levels, _keepJigsaws));
        }));
        _doneButton = AddChild(new Button(Tr("gui.done"), width / 2 - 4 - 150, 210, 150, () => OnDone(context)));
        AddChild(new Button(Tr("gui.cancel"), width / 2 + 4, 210, 150, () => Close(context)));
        if (old != null) {
            (_nameEdit.Value, _targetEdit.Value, _poolEdit.Value, _finalStateEdit.Value) = (old[0], old[1], old[2], old[3]);
            _joint = oldJoint;
            jointButton.SetValue(oldJoint);
            (_selectionPriorityEdit.Value, _placementPriorityEdit.Value) = (old[4], old[5]);
        }
        UpdateValidity();
        if (first) {
            SetFocus(_poolEdit);
        }
    }

    private EditBox Edit(GuiContext context, int x, int y, int width, int maxLength, string value) {
        EditBox box = new(context.Text, x, y, width, 20) { MaxLength = maxLength, Value = value };
        box.SetResponder(_ => UpdateValidity());
        return box;
    }

    private void UpdateValidity() {
        if (_doneButton == null) {
            return;
        }
        bool isValid = Identifiers.TryParse(_nameEdit.Value) != null && Identifiers.TryParse(_targetEdit.Value) != null && Identifiers.TryParse(_poolEdit.Value) != null;
        _doneButton.Active = isValid;
        _generateButton.Active = isValid;
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (!KeyToChildren(context, key, control) && _doneButton.Active && key is Key.Enter or Key.KeypadEnter) {
            OnDone(context);
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        TransparentBackground(context);
        RenderButtons(context);
        int width = context.Width;
        context.Text.Draw(Tr("jigsaw_block.pool"), width / 2 - 153, 10, LabelColor);
        _poolEdit.Render(context);
        context.Text.Draw(Tr("jigsaw_block.name"), width / 2 - 153, 45, LabelColor);
        _nameEdit.Render(context);
        context.Text.Draw(Tr("jigsaw_block.target"), width / 2 - 153, 80, LabelColor);
        _targetEdit.Render(context);
        context.Text.Draw(Tr("jigsaw_block.final_state"), width / 2 - 153, 115, LabelColor);
        _finalStateEdit.Render(context);
        context.Text.Draw(Tr("jigsaw_block.selection_priority"), width / 2 - 153, 150, LabelColor);
        _placementPriorityEdit.Render(context);
        context.Text.Draw(Tr("jigsaw_block.placement_priority"), width / 2 - 50, 150, LabelColor);
        _selectionPriorityEdit.Render(context);
        if (jigsawEntity.FrontIsVertical) {
            context.Text.Draw(Tr("jigsaw_block.joint_label"), width / 2 + 53, 150, LabelColor);
        }
        if (_selectionPriorityEdit.IsMouseOver(context.MouseX, context.MouseY)) {
            Tooltip(context, "jigsaw_block.selection_priority.tooltip");
        }
        else if (_placementPriorityEdit.IsMouseOver(context.MouseX, context.MouseY)) {
            Tooltip(context, "jigsaw_block.placement_priority.tooltip");
        }
    }

    /// <summary><c>Tooltip.create</c>, split to its width, shown while the box is hovered.</summary>
    private void Tooltip(GuiContext context, string key) =>
        Tooltips.Draw(context, context.Text.Splitter.SplitLines(TextFlattener.Formatted(Tr(key)), TooltipWidth), context.MouseX, context.MouseY);
}
