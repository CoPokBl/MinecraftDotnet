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

Two pairs are deliberately kept apart because vanilla keeps them apart:

- `IHalved` (`TopBottom`, which half of its own cube, from the click point) versus `IDoubleHalved`
  (`BlockHalf`, which cell of a two block tall block, from the partner cell). Vanilla spells them
  `Half` and `DoubleBlockHalf`.
- `IFenceConnected` (boolean sides, fences and panes) versus `IWallConnected` (`WallSide` sides,
  walls). A wall's side has a height, a fence's does not.
