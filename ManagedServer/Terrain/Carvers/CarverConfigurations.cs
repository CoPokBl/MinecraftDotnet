using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CarverDebugSettings</c>: the four states a carver writes instead of carving when its debug mode
/// is on.
/// </summary>
/// <remarks>
/// Off in every vanilla file, and the states are still parsed and carried because the branch that
/// reads them is transcribed. Upstream it is also forced on by <c>SharedConstants.DEBUG_CARVERS</c>,
/// which is a constant false in a released jar; there is no equivalent here, so the setting is the
/// only way in.
/// </remarks>
public sealed record CarverDebugSettings(bool DebugMode, uint AirState, uint WaterState, uint LavaState,
    uint BarrierState);

/// <summary>
/// <c>CarverConfiguration</c>: what every carver has, whatever shape it cuts.
/// </summary>
/// <remarks>
/// <see cref="Replaceable"/> is a <c>HolderSet</c> of blocks, resolved to the flat set of block ids
/// when the file is parsed. A candidate is carved on <b>being in that set</b> rather than on being
/// solid, which is what stops a carver eating through bedrock or through the blocks a previous carver
/// left.
/// </remarks>
public record CarverConfiguration(float Probability, HeightProvider Y, IFloatProvider YScale,
    VerticalAnchor LavaLevel, CarverDebugSettings DebugSettings, IReadOnlySet<Identifier> Replaceable);

/// <summary><c>CaveCarverConfiguration</c>: the tunnels, and the nether's variant of them.</summary>
public sealed record CaveCarverConfiguration(float Probability, HeightProvider Y, IFloatProvider YScale,
    VerticalAnchor LavaLevel, CarverDebugSettings DebugSettings, IReadOnlySet<Identifier> Replaceable,
    IFloatProvider HorizontalRadiusMultiplier, IFloatProvider VerticalRadiusMultiplier,
    IFloatProvider FloorLevel)
    : CarverConfiguration(Probability, Y, YScale, LavaLevel, DebugSettings, Replaceable);

/// <summary>
/// <c>CanyonCarverConfiguration.CanyonShapeConfiguration</c>: how a ravine's cross section varies as it
/// runs.
/// </summary>
/// <remarks>
/// <see cref="WidthSmoothness"/> is a <b>divisor of a draw</b>, not a distance: the width factor is
/// redrawn at one height in every <c>WidthSmoothness</c>, so a larger number gives longer runs of the
/// same width and therefore smoother walls.
/// </remarks>
public sealed record CanyonShapeConfiguration(IFloatProvider DistanceFactor, IFloatProvider Thickness,
    int WidthSmoothness, IFloatProvider HorizontalRadiusFactor, float VerticalRadiusDefaultFactor,
    float VerticalRadiusCenterFactor);

/// <summary><c>CanyonCarverConfiguration</c>: the ravines.</summary>
public sealed record CanyonCarverConfiguration(float Probability, HeightProvider Y, IFloatProvider YScale,
    VerticalAnchor LavaLevel, CarverDebugSettings DebugSettings, IReadOnlySet<Identifier> Replaceable,
    IFloatProvider VerticalRotation, CanyonShapeConfiguration Shape)
    : CarverConfiguration(Probability, Y, YScale, LavaLevel, DebugSettings, Replaceable);
