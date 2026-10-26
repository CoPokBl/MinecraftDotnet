using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

using Minecraft.Data.Generated;

namespace Minecraft.Placement.Rules;

/// <summary>
/// The block classes whose whole <c>getStateForPlacement</c> is "face the player", or "face away from
/// the player", plus waterlogging where they have it.
/// <p/>
/// One class per vanilla class rather than one rule with a list, because they are separate overrides
/// upstream and a diff against the jar should show that. Which way round is <b>not</b> inheritable:
/// <c>HorizontalDirectionalBlock</c> does not override placement at all, and of its subclasses that
/// do, 11 face the player and 21 face away. Getting one backwards puts a furnace's front against the
/// wall, so the two are separate types here rather than a boolean nobody would read twice.
/// </summary>
public abstract class HorizontalFacingPlacementRule : IBlockPlacementRule {
    public abstract BlockClass VanillaClass { get; }

    /// <summary>Whether the block faces away from the placer, vanilla's <c>.getOpposite()</c>.</summary>
    protected abstract bool Opposite { get; }

    public virtual IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing facing) {
            return block;
        }

        IBlock state = facing.WithFacing(Opposite
            ? context.HorizontalDirection.Opposite()
            : context.HorizontalDirection);
        return PlacementHelpers.Waterlog(state, context);
    }

    /// <summary>
    /// Virtual only so a subclass can be dispatched to. A class that implements the interface fixes
    /// its mapping, so a subclass declaring the hook without <c>override</c> writes a method nothing
    /// calls and the interface default answers instead. <c>RuleDispatchTest</c> is the backstop.
    /// </summary>
    public virtual bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) => true;

    /// <inheritdoc cref="CanSurvive"/>
    public virtual IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) => block;
}

/// <summary>Faces the way the placer is looking.</summary>
public abstract class FacesPlacer : HorizontalFacingPlacementRule {
    protected override bool Opposite => false;
}

/// <summary>Faces back at the placer, which is what puts a furnace's front towards you.</summary>
public abstract class FacesAwayFromPlacer : HorizontalFacingPlacementRule {
    protected override bool Opposite => true;
}

public sealed class AnvilPlacementRule : FacesPlacer {
    public override BlockClass VanillaClass => BlockClass.AnvilBlock;
}

/// <summary>
/// <c>CampfireBlock</c>. Faces the player, and reads the block below for <c>signal_fire</c>: a
/// campfire over a hay bale sends its smoke ten times as high.
/// <p/>
/// It does not go through the shared waterlog line either. A campfire placed into water comes out
/// waterlogged <b>and unlit</b>, which is one expression rather than two independent ones.
/// </summary>
public sealed class CampfirePlacementRule : FacesPlacer {
    private static readonly Identifier HayBlock = "minecraft:hay_block";

    public override BlockClass VanillaClass => BlockClass.CampfireBlock;

    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        bool replacedWater = PlacementHelpers.IsWaterAt(context.World, context.PlacePos);

        IBlock state = block is IWaterlogged waterloggable
            ? waterloggable.WithWaterlogged(replacedWater)
            : block;
        state = WithSignalFire(state, context.World.GetBlock(context.PlacePos.WithY(context.PlacePos.Y - 1)));
        state = state is ILit campfireLit ? campfireLit.WithLit(!replacedWater) : state;

        return state is IHorizontalFacing campfire
            ? campfire.WithFacing(context.HorizontalDirection)
            : state;
    }

    /// <summary>Only the block below can change it, and nothing else about the state moves.</summary>
    public override IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY ? WithSignalFire(block, neighbourState) : block;
    }

    /// <summary><c>isSmokeSource</c>, which is the hay block and nothing else.</summary>
    private static IBlock WithSignalFire(IBlock block, IBlock below) {
        return block is ISignalFire smoke ? smoke.WithSignalFire(below.Identifier == HayBlock) : block;
    }
}

public sealed class DecoratedPotPlacementRule : FacesPlacer {
    public override BlockClass VanillaClass => BlockClass.DecoratedPotBlock;
}

public sealed class AbstractFurnacePlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.AbstractFurnaceBlock;
}

public sealed class BeehivePlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.BeehiveBlock;
}

public sealed class CarvedPumpkinPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.CarvedPumpkinBlock;
}

public sealed class ChiseledBookShelfPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.ChiseledBookShelfBlock;
}

public sealed class CopperGolemStatuePlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.CopperGolemStatueBlock;
}

public sealed class CrafterPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.CrafterBlock;
}

/// <summary>Repeaters and comparators, vanilla's <c>DiodeBlock</c>.</summary>
public sealed class DiodePlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.DiodeBlock;

    /// <summary>
    /// <c>canSurviveOn</c>: the up face of the block below as <c>SupportType.RIGID</c>, the outer
    /// frame rather than the whole face. It is the same test a pressure plate makes, and the reason a
    /// repeater sits on a hopper but not on a fence post.
    /// </summary>
    public override bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        return PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y - 1), BlockFace.PosY,
            SupportType.Rigid);
    }
}

public sealed class DriedGhastPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.DriedGhastBlock;
}

public sealed class EnderChestPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.EnderChestBlock;
}

public sealed class EndPortalFramePlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.EndPortalFrameBlock;
}

public sealed class GlazedTerracottaPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.GlazedTerracottaBlock;
}

public sealed class JigsawPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.JigsawBlock;
}

public sealed class LecternPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.LecternBlock;
}

public sealed class LoomPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.LoomBlock;
}

public sealed class ShelfPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.ShelfBlock;
}

public sealed class StonecutterPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.StonecutterBlock;
}

public sealed class VaultPlacementRule : FacesAwayFromPlacer {
    public override BlockClass VanillaClass => BlockClass.VaultBlock;
}
