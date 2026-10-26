# Block property interfaces

What a generated block record implements because of the state properties it has, so that code
holding an `IBlock` can read and set a property without knowing which of the 764 records it is
holding.

These are **generated onto the records** by `BlockCodeGen`, chosen by property name plus value set
using the same tables that decide the shared enum mapping. The interfaces themselves are written by
hand here; the `WithX` bodies are emitted.

The reason they exist is `getStateForPlacement`. Vanilla's placement code is written against the
block class (`StairBlock`, `SlabBlock`), and every one of its methods reads and writes properties
through `BlockState.setValue(FACING, ...)`. There is no C# class per vanilla block to hang that on,
and the alternative generic route, `IBlock.WithState(CompoundTag)`, takes string keys and
**silently ignores one it does not recognise**, so a misspelt property is a no-op rather than an
error. A rule written against these fails to compile instead.

A property renamed or retyped upstream therefore breaks the build at the rule that reads it, which
is the same bargain `Dumper.java` already makes by naming the accessors it wants.

There is a second reason beyond type safety, and it is why `FlagProperties.cs` covers properties only
one block has. The string route is not just loose, it is **expensive**: `WithProperty` calls
`ToStateNbt()`, allocating a `CompoundTag` and a `StringTag` per property the block has, then
`WithState(CompoundTag)`, which allocates another and re-parses all of them by name. The placement
rules run inside the `updateShape` cascade, which visits six neighbours per write and recurses, so a
fence gate flipping `in_wall` was allocating about ten objects to change one bool. An interface makes
it a record `with` and nothing else.

**Every property a placement rule touches now has one**, and `PlacementHelpers.WithProperty` is gone
as a result. Reaching the last few meant making their value sets **shared** enums in
`BlockCodeGen` rather than enums nested inside one record, because an interface cannot name a nested
type. That is a fix in its own right and not only a means to one: pointed dripstone and the sulfur
spike had two separate `Thickness` enums that could not be compared, and the ten chests had ten
`Type` enums. `ChestType`, `SpeleothemThickness`, `VerticalDirection`, `BellAttachType`,
`CreakingHeartState`, `PotentSulfurState` and `RailShape` are the enums that came out of it, named
after vanilla's own.

One member is not named after its property. `IInstrumented.InstrumentValue` keeps the suffix
`GetPascalPropName` gives it, because `Instrument` is already the sound every block reads off its
`BlockStateInfo` and the two mean different things.

`RailShape` and `RailDirection` stay separate for the opposite reason: vanilla has one enum and
narrows the property, but the generator keys on the value set, and keeping them apart is the safer
half of that trade. `WithShape(RailShape.SouthEast)` on a powered rail would otherwise compile and
produce a state that does not exist.

Two pairs are deliberately kept apart because vanilla keeps them apart:

- `IHalved` (`TopBottom`, which half of its own cube, from the click point) versus `IDoubleHalved`
  (`BlockHalf`, which cell of a two block tall block, from the partner cell). Vanilla spells them
  `Half` and `DoubleBlockHalf`.
- `IFenceConnected` (boolean sides, fences and panes) versus `IWallConnected` (`WallSide` sides,
  walls). A wall's side has a height, a fence's does not.
