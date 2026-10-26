using ClientLib.Commands;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT;
using NBT.Tags;
using CommandBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundProgramCommandBlockPacket.CommandBlockMode;
using JigsawJointType = Minecraft.Packets.Play.ServerBound.ServerBoundProgramJigsawBlockPacket.JigsawJointType;
using TestBlockMode = Minecraft.Packets.Play.ServerBound.ServerBoundSetTestBlockPacket.TestBlockMode;

namespace ClientLib.World.BlockEntities;

/// <summary><c>BaseCommandBlock</c>: what a command block or a command block minecart shows its editor.</summary>
public sealed class BaseCommandBlock {
    private TextComponent? _lastOutput;

    public string Command { get; private set; } = "";
    public int SuccessCount { get; private set; }
    public TextComponent? CustomName { get; private set; }
    public bool TrackOutput { get; set; } = true;

    /// <summary><c>getLastOutput</c>: the empty text when there is none.</summary>
    public TextComponent LastOutput => _lastOutput ?? TextComponent.Empty();

    public void SetLastOutput(TextComponent? lastOutput) => _lastOutput = lastOutput;

    public void SetCommand(string command) {
        Command = command;
        SuccessCount = 0;
    }

    /// <summary><c>load</c>, without the last execution tick, which only the server reads.</summary>
    public void Load(CompoundTag tag) {
        Command = tag["Command"] is StringTag command ? command.Value : "";
        SuccessCount = tag["SuccessCount"] is { } count ? count.GetInteger() : 0;
        CustomName = ParseCustomNameSafe(tag["CustomName"]);
        TrackOutput = tag["TrackOutput"] is not { } track || track.GetBoolean();
        _lastOutput = TrackOutput ? ParseCustomNameSafe(tag["LastOutput"]) : null;
    }

    /// <summary><c>BlockEntity.parseCustomNameSafe</c>: null for a tag that is missing or not a component.</summary>
    private static TextComponent? ParseCustomNameSafe(INbtTag? tag) {
        if (tag == null) {
            return null;
        }
        try {
            return TextComponent.FromTag(tag);
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            return null;
        }
    }
}

/// <summary>
/// <c>CommandBlockEntity</c>. Its update tag is empty, so the command only arrives when an operator
/// opens the block: <c>ServerPlayer.openCommandBlock</c> answers the use with its full tag.
/// </summary>
public sealed class CommandBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public BaseCommandBlock CommandBlock { get; } = new();
    public bool Powered { get; private set; }
    public bool ConditionMet { get; private set; }
    public bool Automatic { get; private set; }

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        CommandBlock.Load(tag);
        Powered = tag["powered"] is { } powered && powered.GetBoolean();
        ConditionMet = tag["conditionMet"] is { } conditionMet && conditionMet.GetBoolean();
        Automatic = tag["auto"] is { } auto && auto.GetBoolean();
    }

    /// <summary>What <c>CommandBlockEditScreen.populateAndSendPacket</c> sends: the edits, with the block's own track output.</summary>
    public ServerBoundProgramCommandBlockPacket SetCommandPacket(string command, CommandBlockMode mode, bool conditional, bool automatic) => new() {
        Location = new Vec3<int>(X, Y, Z),
        Command = command,
        Mode = mode,
        TrackOutput = CommandBlock.TrackOutput,
        Conditional = conditional,
        Automatic = automatic
    };

    /// <summary><c>getMode</c>, which the block decides.</summary>
    public CommandBlockMode Mode =>
        State.Identifier == Block.RepeatingCommandBlock.Identifier ? CommandBlockMode.Auto
        : State.Identifier == Block.ChainCommandBlock.Identifier ? CommandBlockMode.Sequence
        : CommandBlockMode.Redstone;

    /// <summary><c>isConditional</c>.</summary>
    public bool IsConditional => State switch {
        CommandBlockBlock impulse => impulse.Conditional,
        ChainCommandBlockBlock chain => chain.Conditional,
        RepeatingCommandBlockBlock repeating => repeating.Conditional,
        _ => false
    };
}

/// <summary><c>TestBlockEntity</c>.</summary>
public sealed class TestBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public TestBlockMode Mode { get; private set; } = state is TestBlockBlock test ? ModeOf(test.ModeValue) : TestBlockMode.Start;
    public string Message { get; private set; } = "";

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        Mode = (tag["mode"] as StringTag)?.Value switch {
            "start" => TestBlockMode.Start,
            "log" => TestBlockMode.Log,
            "accept" => TestBlockMode.Accept,
            _ => TestBlockMode.Fail
        };
        Message = tag["message"] is StringTag message ? message.Value : "";
    }

    private static TestBlockMode ModeOf(TestBlockBlock.Mode mode) => mode switch {
        TestBlockBlock.Mode.Start => TestBlockMode.Start,
        TestBlockBlock.Mode.Log => TestBlockMode.Log,
        TestBlockBlock.Mode.Fail => TestBlockMode.Fail,
        _ => TestBlockMode.Accept
    };

    /// <summary>What <c>TestBlockEditScreen.onDone</c> sends.</summary>
    public ServerBoundSetTestBlockPacket SetTestBlockPacket(TestBlockMode mode, string message) =>
        new() { Location = new Vec3<int>(X, Y, Z), Mode = mode, Message = message };
}

/// <summary><c>JigsawBlockEntity</c>.</summary>
public sealed class JigsawBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    /// <summary><c>EMPTY_ID</c>, which is also <c>Pools.EMPTY</c>'s location.</summary>
    public static readonly Identifier EmptyId = new("minecraft", "empty");

    public Identifier Name { get; private set; } = EmptyId;
    public Identifier Target { get; private set; } = EmptyId;
    public Identifier Pool { get; private set; } = EmptyId;
    public string FinalState { get; private set; } = "minecraft:air";
    public JigsawJointType Joint { get; private set; } = JigsawJointType.Rollable;
    public int PlacementPriority { get; private set; }
    public int SelectionPriority { get; private set; }

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        Name = ReadIdentifier(tag["name"]) ?? EmptyId;
        Target = ReadIdentifier(tag["target"]) ?? EmptyId;
        Pool = ReadIdentifier(tag["pool"]) ?? EmptyId;
        FinalState = tag["final_state"] is StringTag finalState ? finalState.Value : "minecraft:air";
        Joint = (tag["joint"] as StringTag)?.Value switch {
            "rollable" => JigsawJointType.Rollable,
            "aligned" => JigsawJointType.Aligned,
            _ => FrontIsVertical ? JigsawJointType.Rollable : JigsawJointType.Aligned
        };
        PlacementPriority = tag["placement_priority"] is { } placement ? placement.GetInteger() : 0;
        SelectionPriority = tag["selection_priority"] is { } selection ? selection.GetInteger() : 0;
    }

    private static Identifier? ReadIdentifier(INbtTag? tag) => tag is StringTag text ? Identifiers.TryParse(text.Value) : null;

    /// <summary>Whether <c>JigsawBlock.getFrontFacing</c> is up or down.</summary>
    public bool FrontIsVertical => State is JigsawBlock { Orientation: var orientation } && orientation is Orientation.DownEast or Orientation.DownNorth
        or Orientation.DownSouth or Orientation.DownWest or Orientation.UpEast or Orientation.UpNorth or Orientation.UpSouth or Orientation.UpWest;

    /// <summary>What <c>JigsawBlockEditScreen.sendGenerate</c> sends.</summary>
    public ServerBoundGenerateStructurePacket GeneratePacket(int levels, bool keepJigsaws) =>
        new() { Location = new Vec3<int>(X, Y, Z), Levels = levels, KeepJigsaws = keepJigsaws };

    /// <summary>What <c>JigsawBlockEditScreen.sendToServer</c> sends, from identifiers the screen has checked parse.</summary>
    public ServerBoundProgramJigsawBlockPacket SetJigsawBlockPacket(Identifier name, Identifier target, Identifier pool, string finalState,
        JigsawJointType joint, int selectionPriority, int placementPriority) => new() {
        Location = new Vec3<int>(X, Y, Z),
        Name = name,
        Target = target,
        Pool = pool,
        FinalState = finalState,
        Joint = joint,
        SelectionPriority = selectionPriority,
        PlacementPriority = placementPriority
    };
}
