namespace ManagedServer.Fluids;

/// <summary>
/// Which fluid a state is, standing in for vanilla's <c>Fluids</c> registry. Vanilla keeps the
/// source and the flowing form of a fluid as two separate <c>Fluid</c> instances; that split lives
/// on <see cref="FluidState.Source"/> here instead, because everything except tick scheduling
/// treats the pair as one fluid through <c>Fluid.isSame</c>.
/// </summary>
public enum FluidKind {
    Empty,
    Water,
    Lava
}
