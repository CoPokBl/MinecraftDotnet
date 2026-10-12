using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Physics;
using Minecraft.Registry;

namespace ClientLib.Physics;

/// <summary>
/// <c>EntityFluidInteraction</c>: how deep an entity is in water and lava, whether its eyes are, and
/// the current pushing it.
/// </summary>
public sealed class FluidInteraction {
    private readonly Tracker _water = new();
    private readonly Tracker _lava = new();

    public double WaterHeight => _water.Height;
    public double LavaHeight => _lava.Height;
    public bool InWater => _water.Height > 0.0;
    public bool InLava => _lava.Height > 0.0;
    public bool EyeInWater => _water.EyesInside;

    /// <param name="box">The entity's bounding box.</param>
    /// <param name="ignoreCurrent">True when the entity is not pushed by fluids, so flow is not worth computing.</param>
    public void Update(ClientLevel level, Box box, int eyeBlockX, double eyeY, int eyeBlockZ, bool ignoreCurrent) =>
        Update(level, box, box.Inflate(-0.001), eyeBlockX, eyeY, eyeBlockZ, ignoreCurrent);

    /// <param name="interactionBox">
    /// <c>Entity.getFluidInteractionBox</c>: the box shrunk by 0.001, as the vehicle a passenger rides
    /// changes it, or null when the vehicle keeps it out of fluids altogether.
    /// </param>
    public void Update(ClientLevel level, Box box, Box? interactionBox, int eyeBlockX, double eyeY, int eyeBlockZ, bool ignoreCurrent) {
        _water.Reset();
        _lava.Reset();
        if (interactionBox is not { } fluidBox) {
            return;
        }

        int x0 = (int)Math.Floor(fluidBox.MinX);
        int y0 = (int)Math.Floor(fluidBox.MinY);
        int z0 = (int)Math.Floor(fluidBox.MinZ);
        int x1 = (int)Math.Ceiling(fluidBox.MaxX) - 1;
        int y1 = (int)Math.Ceiling(fluidBox.MaxY) - 1;
        int z1 = (int)Math.Ceiling(fluidBox.MaxZ) - 1;
        if (!AllLoaded(level, x0 - 1, z0 - 1, x1 + 1, z1 + 1)) {
            return;
        }

        MinecraftRegistry registry = level.Registry;
        double entityY = box.MinY;
        for (int x = x0; x <= x1; x++) {
            for (int y = y0; y <= y1; y++) {
                for (int z = z0; z <= z1; z++) {
                    MovementBlocks.Entry state = MovementBlocks.Get(registry, level.GetState(x, y, z));
                    if (state.Fluid == FluidKind.Empty) {
                        continue;
                    }

                    double bottom = y;
                    double top = bottom + FluidHeight(level, x, y, z, state);
                    if (top < fluidBox.MinY) {
                        continue;
                    }

                    Tracker tracker = state.Fluid == FluidKind.Water ? _water : _lava;
                    if (x == eyeBlockX && z == eyeBlockZ && eyeY >= bottom && eyeY <= top) {
                        tracker.EyesInside = true;
                    }
                    tracker.Height = Math.Max(top - entityY, tracker.Height);
                    if (!ignoreCurrent) {
                        Vec3d flow = Flow(level, x, y, z, state);
                        if (tracker.Height < 0.4) {
                            flow *= tracker.Height;
                        }
                        tracker.Accumulated += flow;
                        tracker.Count++;
                    }
                }
            }
        }
    }

    /// <summary>
    /// <c>hasFluidAndLoaded</c> asks every chunk in the range to be loaded; whether a section has fluid
    /// at all is only a shortcut and is left to the per block test.
    /// </summary>
    private static bool AllLoaded(ClientLevel level, int x0, int z0, int x1, int z1) {
        for (int cz = z0 >> 4; cz <= z1 >> 4; cz++) {
            for (int cx = x0 >> 4; cx <= x1 >> 4; cx++) {
                if (!level.HasChunk(cx, cz)) {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary><c>Tracker.applyCurrentTo</c>: a player averages the flows it is in, anything else normalises their sum.</summary>
    public Vec3d CurrentImpulse(FluidKind kind, Vec3d oldMovement, double scale, bool player = true) {
        Tracker tracker = kind == FluidKind.Water ? _water : _lava;
        if (tracker.Count == 0 || tracker.Accumulated.LengthSqr() < 1.0E-5F) {
            return Vec3d.Zero;
        }

        Vec3d impulse = player ? tracker.Accumulated * (1.0 / tracker.Count) : tracker.Accumulated.Normalize();
        impulse *= scale;
        if (Math.Abs(oldMovement.X) < 0.003 && Math.Abs(oldMovement.Z) < 0.003 && impulse.Length() < 0.0045000000000000005) {
            impulse = impulse.Normalize() * 0.0045000000000000005;
        }
        return impulse;
    }

    /// <summary><c>FluidState.getHeight</c>: full when the same fluid sits above.</summary>
    public static float FluidHeight(ClientLevel level, int x, int y, int z, MovementBlocks.Entry state) {
        MovementBlocks.Entry above = MovementBlocks.Get(level.Registry, level.GetState(x, y + 1, z));
        return above.Fluid == state.Fluid ? 1.0F : state.FluidAmount / 9.0F;
    }

    /// <summary><c>FlowingFluid.getFlow</c>.</summary>
    public static Vec3d Flow(ClientLevel level, int x, int y, int z, MovementBlocks.Entry state) {
        MinecraftRegistry registry = level.Registry;
        float ownHeight = state.FluidAmount / 9.0F;
        double flowX = 0.0;
        double flowZ = 0.0;
        foreach (Face direction in Faces.Horizontal) {
            int nx = x + Faces.StepX(direction);
            int nz = z + Faces.StepZ(direction);
            MovementBlocks.Entry neighbour = MovementBlocks.Get(registry, level.GetState(nx, y, nz));
            if (!AffectsFlow(state, neighbour)) {
                continue;
            }

            float neighbourHeight = OwnHeight(neighbour);
            float distance = 0.0F;
            if (neighbourHeight == 0.0F) {
                if (!neighbour.BlocksMotion) {
                    MovementBlocks.Entry below = MovementBlocks.Get(registry, level.GetState(nx, y - 1, nz));
                    if (AffectsFlow(state, below)) {
                        neighbourHeight = OwnHeight(below);
                        if (neighbourHeight > 0.0F) {
                            distance = ownHeight - (neighbourHeight - 0.8888889F);
                        }
                    }
                }
            }
            else if (neighbourHeight > 0.0F) {
                distance = ownHeight - neighbourHeight;
            }

            if (distance != 0.0F) {
                flowX += Faces.StepX(direction) * distance;
                flowZ += Faces.StepZ(direction) * distance;
            }
        }

        Vec3d flow = new(flowX, 0.0, flowZ);
        if (state.FluidFalling) {
            foreach (Face direction in Faces.Horizontal) {
                int nx = x + Faces.StepX(direction);
                int nz = z + Faces.StepZ(direction);
                if (IsSolidFace(level, state, nx, y, nz, direction) || IsSolidFace(level, state, nx, y + 1, nz, direction)) {
                    flow = flow.Normalize().Add(0.0, -6.0, 0.0);
                    break;
                }
            }
        }
        return flow.Normalize();
    }

    private static float OwnHeight(MovementBlocks.Entry state) => state.FluidAmount / 9.0F;

    private static bool AffectsFlow(MovementBlocks.Entry fluid, MovementBlocks.Entry neighbour) {
        return neighbour.Fluid == FluidKind.Empty || neighbour.Fluid == fluid.Fluid;
    }

    /// <summary><c>FlowingFluid.isSolidFace</c>. Ice never counts, which the sturdy face table does not know, so it is asked here.</summary>
    private static bool IsSolidFace(ClientLevel level, MovementBlocks.Entry fluid, int x, int y, int z, Face direction) {
        uint stateId = level.GetState(x, y, z);
        MovementBlocks.Entry state = MovementBlocks.Get(level.Registry, stateId);
        if (state.Fluid == fluid.Fluid) {
            return false;
        }
        if (direction == Face.Up) {
            return true;
        }
        if (Minecraft.Data.Generated.BlockClasses.Is(level.Registry.Blocks.GetByStateId(stateId).Identifier,
                Minecraft.Data.Generated.BlockClass.IceBlock)) {
            return false;
        }
        return (state.SturdyFaces & (1 << (int)direction)) != 0;
    }

    private sealed class Tracker {
        public double Height;
        public bool EyesInside;
        public Vec3d Accumulated;
        public int Count;

        public void Reset() {
            Height = 0.0;
            EyesInside = false;
            Accumulated = Vec3d.Zero;
            Count = 0;
        }
    }
}
