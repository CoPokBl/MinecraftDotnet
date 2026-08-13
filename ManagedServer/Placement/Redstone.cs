using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement;

/// <summary>
/// The one question placement asks of redstone, and the one place to answer it once redstone exists.
/// <p/>
/// <b>This is a stub and it is a known divergence.</b> Doors, trapdoors, fence gates and a handful of
/// other blocks read <c>level.hasNeighborSignal(pos)</c> when they are placed, so that a trapdoor put
/// down beside a lever that is already on comes out open. Answering it properly needs the redstone
/// engine: <c>getSignal</c> per neighbour, wire power levels, repeaters and comparators, and blocks
/// that are strongly powered by something adjacent to them. None of that is modelled here yet.
/// <p/>
/// Returning false is wrong for exactly one case and right for the rest: a block placed next to
/// something already emitting power comes out unpowered, and will stay that way until the redstone
/// around it changes. A block placed anywhere else is correct. It is written as a seam rather than
/// left out of the rules so that the rules stay transcriptions with the branch visible in them, and
/// so that wiring redstone in later is one method rather than a hunt.
/// </summary>
public static class Redstone {
    /// <summary>
    /// <c>Level.hasNeighborSignal</c>: whether any of the six neighbours is powering this position.
    /// Always false until there is a redstone engine to ask. See the type comment.
    /// </summary>
    public static bool HasNeighbourSignal(World world, Vec3<int> pos) {
        return false;
    }
}
