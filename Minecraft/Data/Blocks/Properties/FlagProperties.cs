using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Data.Blocks.Properties;

//
// The one property families: a name that one block class, or one small family, has and nothing else
// shares. They are here rather than left to WithProperty for two reasons.
//
// A rule naming one of these as a string is the bug the whole Properties folder exists to stop, and
// PlacementHelpers.WithProperty only turns it from silent into a runtime throw, which is a backstop
// and not a type.
//
// And the string route is expensive in a place that cannot afford it. It goes through
// ToStateNbt(), which allocates a CompoundTag and a StringTag for every property the block has,
// then WithState(CompoundTag), which allocates another and re-parses all of them by name. These
// run inside the updateShape cascade, which visits six neighbours per write and recurses, so a
// fence gate flipping in_wall was allocating about ten objects to change one bool.
//

/// <summary>
/// <c>in_wall</c>, the 12 fence gates. Lowers the gate by three pixels so its top lines up with a
/// wall's, and it is read off the two cells across the gate's axis rather than the two it faces.
/// </summary>
public interface IInWall : IBlock {
    public bool InWall { get; }

    public IBlock WithInWall(bool inWall);
}

/// <summary>
/// <c>locked</c>, the repeater alone. A repeater with another one pointing into either of its sides
/// holds its output. <c>Placement/Redstone.cs</c> is what would answer it, and it is a stub.
/// </summary>
public interface ILocked : IBlock {
    public bool Locked { get; }

    public IBlock WithLocked(bool locked);
}

/// <summary>
/// <c>berries</c>, the two cave vines blocks. It is the one thing carried across when a growing
/// plant's head and body convert into each other, through the overrides of
/// <c>updateBodyAfterConvertedFromHead</c> and <c>updateHeadAfterConvertedFromBody</c>.
/// </summary>
public interface IBerried : IBlock {
    public bool Berries { get; }

    public IBlock WithBerries(bool berries);
}

/// <summary>
/// <c>bottom</c>, scaffolding and the pale moss carpet. It means different things to the two:
/// a scaffold's bottom is the unsupported underside a player falls through, a carpet's is the piece
/// on the ground as opposed to the tuft climbing a wall beside it.
/// </summary>
public interface IBottomed : IBlock {
    public bool Bottom { get; }

    public IBlock WithBottom(bool bottom);
}

/// <summary>
/// <c>snowy</c>, grass, podzol and mycelium. Purely how the block is drawn, set from whether what is
/// above it is snow.
/// </summary>
public interface ISnowy : IBlock {
    public bool Snowy { get; }

    public IBlock WithSnowy(bool snowy);
}

/// <summary>
/// <c>signal_fire</c>, the two campfires. A campfire over a hay bale sends its smoke ten times as
/// high, and it is the one thing a campfire recomputes when the block below it changes.
/// </summary>
public interface ISignalFire : IBlock {
    public bool SignalFire { get; }

    public IBlock WithSignalFire(bool signalFire);
}

/// <summary>
/// <c>persistent</c>, the 11 leaves. Placed leaves are persistent and do not decay; leaves generated
/// by a tree are not, and lose themselves when their log goes.
/// </summary>
public interface IPersistent : IBlock {
    public bool Persistent { get; }

    public IBlock WithPersistent(bool persistent);
}

/// <summary><c>enabled</c>, the hopper alone. A hopper is disabled while it is powered.</summary>
public interface IEnabled : IBlock {
    public bool Enabled { get; }

    public IBlock WithEnabled(bool enabled);
}

/// <summary>
/// <c>hanging</c>, the lanterns and the mangrove propagule. Which way round the block is attached,
/// and the two forms ask entirely different survival questions: a hanging one wants the block above,
/// a standing one the block below.
/// </summary>
public interface IHanging : IBlock {
    public bool Hanging { get; }

    public IBlock WithHanging(bool hanging);
}

/// <summary>
/// <c>attached</c>, the hanging signs and the tripwire pair. Not to be confused with
/// <see cref="IAttachFaced"/>, which is <c>face</c>, one of floor, wall or ceiling. This is a flag.
/// </summary>
public interface IAttached : IBlock {
    public bool Attached { get; }

    public IBlock WithAttached(bool attached);
}

/// <summary>
/// <c>occupied</c>, the 16 beds. Both halves carry it and a bed's <c>updateShape</c> copies it from
/// the other half, so the two never disagree.
/// </summary>
public interface IOccupied : IBlock {
    public bool Occupied { get; }

    public IBlock WithOccupied(bool occupied);
}

/// <summary>
/// <c>tip</c>, pale hanging moss alone. Whether this is the bottom piece of the strand, which is
/// what decides the drawn frayed end, recomputed when the block below changes.
/// </summary>
public interface ITipped : IBlock {
    public bool Tip { get; }

    public IBlock WithTip(bool tip);
}

/// <summary>
/// <c>age</c>, 22 blocks. Deliberately <b>not</b> one meaning: it is growth for a crop, a countdown
/// to the next growth step for a growing plant's head, and a stage for fire and chorus flowers. The
/// interface says the block has a number called age, and each rule knows what its own means.
/// <p/>
/// The maximum is per block and is not exposed, unlike <c>IStackable.MaxCount</c>, because nothing
/// in placement needs it: the rules that write an age write a literal from the jar.
/// </summary>
public interface IAged : IBlock {
    public int Age { get; }

    public IBlock WithAge(int age);
}

/// <summary>
/// <c>distance</c>, the leaves and scaffolding. How far the block is from something holding it up,
/// counted differently by the two: leaves count from the nearest log, scaffolding from the nearest
/// solid face, with the scaffold below counting as its own distance rather than one more so a
/// vertical column is free.
/// </summary>
public interface IDistanced : IBlock {
    public int Distance { get; }

    public IBlock WithDistance(int distance);
}

//
// The same idea where the values are an enum rather than a flag. Each of these needed its value set
// adding to BlockCodeGen's shared enum tables first: a nested enum on one record, which is what they
// all were, cannot be named from an interface. That is also a fix in its own right, since pointed
// dripstone and the sulfur spike had two separate Thickness enums that could not be compared.
//

/// <summary>
/// <c>type</c> on the ten chests. Read and written by the pairing rule, which is the one placement
/// rule that changes a <b>neighbour</b>'s state as well as its own.
/// </summary>
public interface IChestTyped : IBlock {
    public ChestType Type { get; }

    public IBlock WithType(ChestType type);
}

/// <summary>
/// <c>thickness</c> on pointed dripstone and the sulfur spike, the busier half of
/// <c>SpeleothemBlock</c>'s state. Recomputed whenever either vertical neighbour changes.
/// </summary>
public interface ISpeleothem : IBlock {
    public SpeleothemThickness Thickness { get; }

    public IBlock WithThickness(SpeleothemThickness thickness);
}

/// <summary><c>vertical_direction</c>, which way a speleothem's tip points.</summary>
public interface IVerticallyDirected : IBlock {
    public VerticalDirection VerticalDirection { get; }

    public IBlock WithVerticalDirection(VerticalDirection verticalDirection);
}

/// <summary><c>attachment</c> on the bell.</summary>
public interface IBellAttached : IBlock {
    public BellAttachType Attachment { get; }

    public IBlock WithAttachment(BellAttachType attachment);
}

/// <summary><c>creaking_heart_state</c> on the creaking heart.</summary>
public interface ICreakingHearted : IBlock {
    public CreakingHeartState CreakingHeartState { get; }

    public IBlock WithCreakingHeartState(CreakingHeartState creakingHeartState);
}

/// <summary><c>potent_sulfur_state</c> on potent sulfur.</summary>
public interface IPotentSulfured : IBlock {
    public PotentSulfurState PotentSulfurState { get; }

    public IBlock WithPotentSulfurState(PotentSulfurState potentSulfurState);
}

/// <summary>
/// <c>shape</c> on the plain rail, the ten value one. The six value rails carry
/// <see cref="RailDirection"/> instead and do not implement this.
/// </summary>
public interface IRailShaped : IBlock {
    public RailShape Shape { get; }

    public IBlock WithShape(RailShape shape);
}

/// <summary>
/// <c>shape</c> on the powered, detector and activator rails, the six value one. Vanilla has a single
/// <c>RailShape</c> enum and narrows the property (<c>RAIL_SHAPE_STRAIGHT</c>); the generator keys
/// its shared enums on the value set, so the two arrive here as separate types. Keeping them separate
/// is the safer half of that trade: a <c>WithShape(RailShape.SouthEast)</c> on a powered rail would
/// otherwise compile and produce a state that does not exist.
/// </summary>
public interface IRailDirected : IBlock {
    public RailDirection Shape { get; }

    public IBlock WithShape(RailDirection shape);
}

/// <summary>
/// <c>instrument</c> on the note block, and the one member here not named after its property.
/// <p/>
/// <c>Instrument</c> is already taken, by the sound every block reads off its
/// <c>BlockStateInfo</c>, and the two are genuinely different things: that one is what a note block
/// <b>underneath</b> would play, this one is the note block's own state. <c>GetPascalPropName</c>
/// gives the state property the <c>Value</c> suffix for exactly that reason, so the interface takes
/// the suffixed name rather than papering over the clash.
/// </summary>
public interface IInstrumented : IBlock {
    public NoteBlockInstrument InstrumentValue { get; }

    public IBlock WithInstrument(NoteBlockInstrument instrument);
}
