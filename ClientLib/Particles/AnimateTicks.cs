using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Physics;
using Minecraft.Placement.Helpers;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Text;
using Block = Minecraft.Data.Generated.Block;
using BlockClass = Minecraft.Data.Generated.BlockClass;
using BlockClasses = Minecraft.Data.Generated.BlockClasses;
using EnvironmentAttribute = Minecraft.Data.Generated.EnvironmentAttribute;
using Item = Minecraft.Data.Generated.Item;
using Particle = Minecraft.Data.Generated.Particle;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace ClientLib.Particles;

/// <summary>
/// <c>ClientLevel.animateTick</c>: each tick, 667 positions within 16 blocks of the player and as many within 32,
/// each running its block's and its fluid's <c>animateTick</c>, the fluid's drip through the block below, the
/// creative marker and the biome's ambient particles, and the sounds the block and fluid ticks play, which go to
/// <see cref="SoundPlayed"/>.
/// <p/>
/// What a state does is worked out once per state into a table, so a position costs a block lookup and a switch.
/// The draws come from a random of its own, never one movement or prediction reads.
/// </summary>
public sealed partial class AnimateTicks(MinecraftClient client) {
    private const int Samples = 667;

    private static readonly DustParticle Redstone = Particle.Dust with { Color = TextColor.FromDecimal(0xFF0000), Scale = 1.0F };
    private static readonly DustParticle LeverDust = Particle.Dust with { Color = TextColor.FromDecimal(0xFF0000), Scale = 0.5F };
    private static readonly DustColorTransitionParticle SculkToRedstone = Particle.DustColorTransition with {
        FromColor = TextColor.FromDecimal(3790560), ToColor = TextColor.FromDecimal(0xFF0000), Scale = 1.0F
    };
    private static readonly TintedLeavesParticle AzaleaLeaf = Particle.TintedLeaves with { Argb = -9399763 };

    /// <summary><c>RedStoneWireBlock.COLORS</c>, as dust of each power.</summary>
    private static readonly DustParticle[] WireDust = Enumerable.Range(0, 16).Select(i => {
        float power = i / 15.0F;
        float red = power * 0.6F + (power > 0.0F ? 0.4F : 0.3F);
        float green = Math.Clamp(power * power * 0.7F - 0.5F, 0.0F, 1.0F);
        float blue = Math.Clamp(power * power * 0.6F - 0.7F, 0.0F, 1.0F);
        int rgb = (int)(red * 255.0F + 0.5F) << 16 | (int)(green * 255.0F + 0.5F) << 8 | (int)(blue * 255.0F + 0.5F);
        return Particle.Dust with { Color = TextColor.FromDecimal(rgb), Scale = 1.0F };
    }).ToArray();

    /// <summary><c>Direction.values()</c> by 3D data value: down, up, north, south, west, east.</summary>
    private static readonly (int X, int Y, int Z)[] Steps = [(0, -1, 0), (0, 1, 0), (0, 0, -1), (0, 0, 1), (-1, 0, 0), (1, 0, 0)];

    /// <summary><c>Direction.Plane.HORIZONTAL</c>: north, east, south, west, as 3D data values.</summary>
    private static readonly int[] Horizontal = [2, 5, 3, 4];

    /// <summary><c>EnchantingTableBlock.BOOKSHELF_OFFSETS</c>, in <c>BlockPos.betweenClosed</c>'s x fastest order.</summary>
    private static readonly (int X, int Y, int Z)[] BookshelfOffsets = (
        from y in Enumerable.Range(0, 2)
        from z in Enumerable.Range(-2, 5)
        from x in Enumerable.Range(-2, 5)
        where Math.Abs(x) == 2 || Math.Abs(z) == 2
        select (x, y, z)).ToArray();

    /// <summary><c>CandleBlock.PARTICLE_OFFSETS</c> by candle count, in sixteenths.</summary>
    private static readonly (float X, float Y, float Z)[][] CandleOffsets = [
        [],
        [(8, 8, 8)],
        [(6, 7, 8), (10, 8, 7)],
        [(8, 5, 10), (6, 7, 8), (9, 8, 7)],
        [(7, 5, 9), (10, 7, 9), (6, 7, 6), (9, 8, 6)]
    ];

    private static readonly Identifier EnchantmentPowerProvider = "minecraft:enchantment_power_provider";
    private static readonly Identifier EnchantmentPowerTransmitter = "minecraft:enchantment_power_transmitter";
    private static readonly Identifier Impermeable = "minecraft:impermeable";
    private static readonly Identifier FireTag = "minecraft:fire";

    private enum Kind : byte {
        None,
        Torch,
        WallTorch,
        RedstoneTorch,
        RedstoneWallTorch,
        Fire,
        Campfire,
        Candle,
        CandleCake,
        RedstoneWire,
        Repeater,
        EndRod,
        EndPortal,
        EndGateway,
        NetherPortal,
        EnderChest,
        EnchantingTable,
        Leaves,
        SporeBlossom,
        PointedDripstone,
        CryingObsidian,
        RespawnAnchor,
        BrewingStand,
        Furnace,
        Smoker,
        BlastFurnace,
        SculkSensor,
        Mycelium,
        WetSponge,
        Beehive,
        Brushable,
        BubbleColumn,
        DriedGhast,
        Falling,
        FireflyBush,
        Lever,
        LightningRod,
        PotentSulfur,
        RedstoneOre,
        WitherRose,
        Sand,
        DryGrass,
        DeadBush,
        HangingMoss,
        Eyeblossom,
        CreakingHeart
    }

    /// <summary>What a state's <c>animateTick</c> and its neighbours' ask of it, read once per state.</summary>
    private struct Facts {
        public bool Known;
        public Kind Kind;

        /// <summary>The flame of a torch, the leaf of leaves.</summary>
        public IParticle? Particle;

        /// <summary>Leaves' <c>leafParticleChance</c>; whether their leaf is tinted where they stand.</summary>
        public float Chance;
        public bool Tinted;

        public bool Air, CanOcclude, SolidRender, CollisionFullBlock, TopFaceFull, Replaceable, Liquid, Flammable;
        public byte SturdyFaces;

        /// <summary>The collision shape's bounds, Min above Max when it has none.</summary>
        public float MinX, MinY, MinZ, MaxX, MaxY, MaxZ;

        /// <summary><see cref="ParticleEngine.FluidWater"/> or <see cref="ParticleEngine.FluidLava"/>, else 0.</summary>
        public byte Fluid;
        public bool FluidSourceOrFalling;
    }

    private ClientLevel? _level;
    private Facts[] _facts = [];

    /// <summary>The chunks around the player this tick, so a sample costs no dictionary lookup.</summary>
    private const int GridRadius = 3, GridSize = GridRadius * 2 + 1;
    private readonly ClientChunk?[] _grid = new ClientChunk?[GridSize * GridSize];
    private int _gridX, _gridZ;
    private readonly ParticleRandom _random = new();
    private (IParticle Particle, float Probability)[]?[] _ambient = [];
    private Dictionary<Identifier, int[]>? _tagSource;
    private readonly Dictionary<Identifier, HashSet<int>> _tags = new();

    private ParticleEngine Engine => client.Particles;

    /// <summary><c>Level.getSkyDarken</c>, which the client's renderer works out; fireflies ask for it.</summary>
    public int SkyDarkening { get; set; }

    /// <summary><c>ClientLevel.animateTick</c> around the block the player is in.</summary>
    public void Tick() {
        if (client.Player is not { } player || !Begin(player.Position.X, player.Position.Z) || _level is not { } level) {
            return;
        }
        int px = (int)Math.Floor(player.Position.X), py = (int)Math.Floor(player.Position.Y), pz = (int)Math.Floor(player.Position.Z);
        IBlock? marker = MarkerParticleTarget(player);
        for (int i = 0; i < Samples; i++) {
            Sample(level, px, py, pz, 16, marker);
            Sample(level, px, py, pz, 32, marker);
        }
    }

    /// <summary>One position's <c>doAnimateTick</c>, the random position aside.</summary>
    internal void AnimateAt(int x, int y, int z) {
        if (Begin(x, z) && _level is { } level) {
            AnimateTickAt(level, x, y, z, client.Player is { } player ? MarkerParticleTarget(player) : null);
        }
    }

    /// <summary>Takes up the client's level and the chunks around a point, false when there is nothing to animate.</summary>
    private bool Begin(double x, double z) {
        ClientLevel? level = client.Level;
        if (level == null || !Engine.Enabled) {
            return false;
        }
        if (!ReferenceEquals(level, _level)) {
            _level = level;
            _facts = new Facts[(int)level.Registry.Blocks.StatesCount];
            _ambient = new (IParticle, float)[]?[(int)level.Registry.Biomes.Count];
            _tracks = null;
        }
        _gridX = ((int)Math.Floor(x) >> 4) - GridRadius;
        _gridZ = ((int)Math.Floor(z) >> 4) - GridRadius;
        for (int i = 0; i < _grid.Length; i++) {
            _grid[i] = level.GetChunk(_gridX + i % GridSize, _gridZ + i / GridSize);
        }
        return true;
    }

    /// <summary><c>getMarkerParticleTarget</c>: a barrier or light held in creative shows the blocks it places.</summary>
    private IBlock? MarkerParticleTarget(Player.LocalPlayer player) {
        if (player.GameMode != GameMode.Creative) {
            return null;
        }
        ItemStack held = client.Inventory.MainHand;
        if (held.Type.Identifier == Item.Barrier.Identifier) {
            return Block.Barrier;
        }
        return held.Type.Identifier == Item.Light.Identifier ? Block.Light : null;
    }

    /// <summary><c>doAnimateTick</c>.</summary>
    private void Sample(ClientLevel level, int px, int py, int pz, int r, IBlock? marker) {
        ParticleRandom random = _random;
        int x = px + random.NextInt(r) - random.NextInt(r);
        int y = py + random.NextInt(r) - random.NextInt(r);
        int z = pz + random.NextInt(r) - random.NextInt(r);
        AnimateTickAt(level, x, y, z, marker);
    }

    private void AnimateTickAt(ClientLevel level, int x, int y, int z, IBlock? marker) {
        ParticleRandom random = _random;
        ClientChunk? chunk = ChunkAt(level, x, z);
        int section = (y - level.MinY) >> 4;
        ushort state = chunk != null && (uint)section < (uint)level.SectionCount ? chunk.Sections[section].Get(x & 15, y & 15, z & 15) : (ushort)0;
        ref Facts facts = ref FactsOf(state);
        if (facts.Kind != Kind.None) {
            AnimateBlock(level, ref facts, state, x, y, z);
        }
        if (facts.Fluid != 0) {
            AnimateFluid(ref facts, x, y, z);
            if (random.NextInt(10) == 0) {
                bool watertightBottom = (facts.SturdyFaces & 1 << (int)BlockFace.NegY) != 0;
                TrySpawnDripParticles(level, x, y - 1, z, facts.Fluid == ParticleEngine.FluidLava ? Particle.DrippingLava : Particle.DrippingWater,
                    watertightBottom);
            }
        }
        if (marker != null && marker.Identifier == level.Registry.Blocks.GetByStateId(state).Identifier) {
            Engine.AddParticle(Particle.BlockMarker with { BlockState = state }, x + 0.5, y + 0.5, z + 0.5, 0.0, 0.0, 0.0);
        }
        if (!facts.CollisionFullBlock && chunk != null && AmbientAt(level, chunk, x, y, z) is { } ambient) {
            foreach ((IParticle particle, float probability) in ambient) {
                // AmbientParticle.canSpawn.
                if (random.NextFloat() <= probability) {
                    Engine.AddParticle(particle, x + random.NextDouble(), y + random.NextDouble(), z + random.NextDouble(), 0.0, 0.0, 0.0);
                }
            }
        }
    }

    #region Fluids

    /// <summary><c>WaterFluid.animateTick</c> and <c>LavaFluid.animateTick</c>.</summary>
    private void AnimateFluid(ref Facts facts, int x, int y, int z) {
        ParticleRandom random = _random;
        if (facts.Fluid == ParticleEngine.FluidWater) {
            if (!facts.FluidSourceOrFalling) {
                if (random.NextInt(64) == 0) {
                    Sound(SoundType.WaterAmbient, SoundCategory.Ambient, x + 0.5, y + 0.5, z + 0.5, random.NextFloat() * 0.25F + 0.75F,
                        random.NextFloat() + 0.5F);
                }
            }
            else if (random.NextInt(10) == 0) {
                Engine.AddParticle(Particle.Underwater, x + random.NextDouble(), y + random.NextDouble(), z + random.NextDouble(), 0.0, 0.0, 0.0);
            }
            return;
        }
        ref Facts above = ref FactsAt(_level!, x, y + 1, z);
        if (!above.Air || above.SolidRender) {
            return;
        }
        if (random.NextInt(100) == 0) {
            double xx = x + random.NextDouble(), yy = y + 1.0, zz = z + random.NextDouble();
            Engine.AddParticle(Particle.Lava, xx, yy, zz, 0.0, 0.0, 0.0);
            Sound(SoundType.LavaPop, SoundCategory.Ambient, xx, yy, zz, 0.2F + random.NextFloat() * 0.2F, 0.9F + random.NextFloat() * 0.15F);
        }
        if (random.NextInt(200) == 0) {
            Sound(SoundType.LavaAmbient, SoundCategory.Ambient, x, y, z, 0.2F + random.NextFloat() * 0.2F, 0.9F + random.NextFloat() * 0.15F);
        }
    }

    /// <summary><c>ClientLevel.trySpawnDripParticles</c>: a fluid seeping through the block under it, from its underside.</summary>
    private void TrySpawnDripParticles(ClientLevel level, int x, int y, int z, IParticle drip, bool isTopSolid) {
        ushort state = StateAt(level, x, y, z);
        ref Facts facts = ref FactsOf(state);
        if (facts.Fluid != 0) {
            return;
        }
        if (facts.MaxY < 1.0F) {
            if (isTopSolid) {
                SpawnFluidParticle(x, x + 1, z, z + 1, y + 1 - 0.05, drip);
            }
        }
        else if (!InTag(level, Impermeable, state)) {
            if (facts.MinY > 0.0F) {
                SpawnFluidParticle(x + facts.MinX, x + facts.MaxX, z + facts.MinZ, z + facts.MaxZ, y + facts.MinY - 0.05, drip);
            }
            else {
                ref Facts below = ref FactsAt(level, x, y - 1, z);
                if (below.MaxY < 1.0F && below.Fluid == 0) {
                    SpawnFluidParticle(x + facts.MinX, x + facts.MaxX, z + facts.MinZ, z + facts.MaxZ, y - 0.05, drip);
                }
            }
        }
    }

    private void SpawnFluidParticle(double x1, double x2, double z1, double z2, double y, IParticle drip) =>
        Engine.AddParticle(drip, x1 + _random.NextDouble() * (x2 - x1), y, z1 + _random.NextDouble() * (z2 - z1), 0.0, 0.0, 0.0);

    #endregion

    #region Biome ambience

    /// <summary>
    /// The <c>visual/ambient_particles</c> attribute where a position is: its quart cell's biome, else the dimension's.
    /// Only constant values and overrides are read, which is all a list attribute takes.
    /// </summary>
    private (IParticle Particle, float Probability)[]? AmbientAt(ClientLevel level, ClientChunk chunk, int x, int y, int z) {
        int section = Math.Clamp((y - level.MinY) >> 4, 0, level.SectionCount - 1);
        int biome = chunk.GetBiome(x & 15, section, (y - level.MinY) & 15, z & 15);
        if ((uint)biome >= (uint)_ambient.Length) {
            return null;
        }
        (IParticle, float)[]? known = _ambient[biome];
        if (known != null) {
            return known.Length == 0 ? null : known;
        }
        IEnvironmentAttribute attribute = EnvironmentAttribute.VisualAmbientParticles;
        EnvironmentAttributeValue? value = Constant(level, attribute, level.Registry.Biomes[biome].Attributes[attribute])
            ?? DimensionConstant(level, attribute);
        List<(IParticle, float)> particles = [];
        if (value is EnvironmentAttributeValue.AmbientParticles list) {
            foreach (AmbientParticle ambient in list.Values) {
                // Only a type with no options of its own can be made from the data form; every vanilla biome's is one.
                if (ambient.Particle.Options.Count == 0 && level.Registry.Particles.Contains(ambient.Particle.Type)) {
                    particles.Add((level.Registry.Particles[ambient.Particle.Type], ambient.Probability));
                }
            }
        }
        _ambient[biome] = particles.ToArray();
        return particles.Count == 0 ? null : _ambient[biome];
    }

    private static EnvironmentAttributeValue? Constant(ClientLevel level, IEnvironmentAttribute attribute, EnvironmentAttributeEntry? entry) => entry switch {
        EnvironmentAttributeEntry.Constant constant => constant.Value,
        EnvironmentAttributeEntry.Modified { Operation: EnvironmentAttributeOperation.Override } overridden =>
            EnvironmentAttributeValue.FromNbt(attribute.ValueKind, overridden.Argument, level.Registry),
        _ => null
    };

    #endregion

    #region Blocks

    private void AnimateBlock(ClientLevel level, ref Facts facts, ushort state, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        ParticleRandom random = _random;
        ParticleEngine engine = Engine;
        switch (facts.Kind) {
            case Kind.Torch:
                engine.AddParticle(Particle.Smoke, x + 0.5, y + 0.7, z + 0.5, 0.0, 0.0, 0.0);
                engine.AddParticle(facts.Particle!, x + 0.5, y + 0.7, z + 0.5, 0.0, 0.0, 0.0);
                break;
            case Kind.WallTorch: {
                (int ox, _, int oz) = Steps[Opposite(Data((block as IHorizontalFacing)?.Facing ?? Direction.North))];
                double tx = x + 0.5 + 0.27 * ox, ty = y + 0.7 + 0.22, tz = z + 0.5 + 0.27 * oz;
                engine.AddParticle(Particle.Smoke, tx, ty, tz, 0.0, 0.0, 0.0);
                engine.AddParticle(facts.Particle!, tx, ty, tz, 0.0, 0.0, 0.0);
                break;
            }
            case Kind.RedstoneTorch when block is ILit { Lit: true }:
                engine.AddParticle(Redstone, x + 0.5 + (random.NextDouble() - 0.5) * 0.2, y + 0.7 + (random.NextDouble() - 0.5) * 0.2,
                    z + 0.5 + (random.NextDouble() - 0.5) * 0.2, 0.0, 0.0, 0.0);
                break;
            case Kind.RedstoneWallTorch when block is ILit { Lit: true }: {
                (int ox, _, int oz) = Steps[Opposite(Data((block as IHorizontalFacing)?.Facing ?? Direction.North))];
                engine.AddParticle(Redstone, x + 0.5 + (random.NextDouble() - 0.5) * 0.2 + 0.27 * ox, y + 0.7 + (random.NextDouble() - 0.5) * 0.2 + 0.22,
                    z + 0.5 + (random.NextDouble() - 0.5) * 0.2 + 0.27 * oz, 0.0, 0.0, 0.0);
                break;
            }
            case Kind.Fire:
                Fire(level, ref facts, x, y, z);
                break;
            case Kind.Campfire when block is CampfireBlock { Lit: true } or SoulCampfireBlock { Lit: true }:
                if (random.NextInt(10) == 0) {
                    Sound(SoundType.CampfireCrackle, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5, 0.5F + random.NextFloat(), random.NextFloat() * 0.7F + 0.6F);
                }
                if (facts.Particle != null && random.NextInt(5) == 0) {
                    engine.AddParticle(Particle.Lava, x + 0.5, y + 0.5, z + 0.5, random.NextFloat() / 2.0F, 5.0E-5, random.NextFloat() / 2.0F);
                }
                break;
            case Kind.Candle when block is ILit { Lit: true }:
                foreach ((float ox, float oy, float oz) in CandleOffsets[Math.Clamp((block as IStackable)?.Count ?? 1, 1, 4)]) {
                    CandleFlame(x + ox / 16.0, y + oy / 16.0, z + oz / 16.0);
                }
                break;
            case Kind.CandleCake when block is ILit { Lit: true }:
                CandleFlame(x + 0.5, y + 1.0, z + 0.5);
                break;
            case Kind.RedstoneWire when block is RedstoneWireBlock { Power: > 0 } wire:
                RedstoneWire(wire, x, y, z);
                break;
            case Kind.Repeater when block is RepeaterBlock { Powered: true } repeater: {
                double rx = x + 0.5 + (random.NextDouble() - 0.5) * 0.2;
                double ry = y + 0.4 + (random.NextDouble() - 0.5) * 0.2;
                double rz = z + 0.5 + (random.NextDouble() - 0.5) * 0.2;
                float offset = -5.0F;
                if (random.NextBool()) {
                    offset = repeater.Delay * 2 - 1;
                }
                offset /= 16.0F;
                (int sx, _, int sz) = Steps[Data(repeater.Facing)];
                engine.AddParticle(Redstone, rx + offset * sx, ry, rz + offset * sz, 0.0, 0.0, 0.0);
                break;
            }
            case Kind.EndRod: {
                (int sx, int sy, int sz) = Steps[(int)((block as IDirectional)?.Facing ?? Cardinal.Up)];
                double ex = x + 0.55 - random.NextFloat() * 0.1F;
                double ey = y + 0.55 - random.NextFloat() * 0.1F;
                double ez = z + 0.55 - random.NextFloat() * 0.1F;
                double r = 0.4F - (random.NextFloat() + random.NextFloat()) * 0.4F;
                if (random.NextInt(5) == 0) {
                    engine.AddParticle(Particle.EndRod, ex + sx * r, ey + sy * r, ez + sz * r,
                        random.NextGaussian() * 0.005, random.NextGaussian() * 0.005, random.NextGaussian() * 0.005);
                }
                break;
            }
            case Kind.EndPortal:
                engine.AddParticle(Particle.Smoke, x + random.NextDouble(), y + 0.8, z + random.NextDouble(), 0.0, 0.0, 0.0);
                break;
            case Kind.EndGateway:
                EndGateway(level, x, y, z);
                break;
            case Kind.NetherPortal:
                NetherPortal(level, block, x, y, z);
                break;
            case Kind.EnderChest:
                for (int i = 0; i < 3; i++) {
                    int flipX = random.NextInt(2) * 2 - 1;
                    int flipZ = random.NextInt(2) * 2 - 1;
                    double cy = y + random.NextFloat();
                    double xa = random.NextFloat() * flipX;
                    double ya = (random.NextFloat() - 0.5) * 0.125;
                    double za = random.NextFloat() * flipZ;
                    engine.AddParticle(Particle.Portal, x + 0.5 + 0.25 * flipX, cy, z + 0.5 + 0.25 * flipZ, xa, ya, za);
                }
                break;
            case Kind.EnchantingTable:
                foreach ((int ox, int oy, int oz) in BookshelfOffsets) {
                    if (random.NextInt(16) == 0 && InTag(level, EnchantmentPowerProvider, StateAt(level, x + ox, y + oy, z + oz))
                        && InTag(level, EnchantmentPowerTransmitter, StateAt(level, x + ox / 2, y + oy, z + oz / 2))) {
                        engine.AddParticle(Particle.Enchant, x + 0.5, y + 2.0, z + 0.5,
                            ox + random.NextFloat() - 0.5, oy - random.NextFloat() - 1.0F, oz + random.NextFloat() - 0.5);
                    }
                }
                break;
            case Kind.Leaves:
                Leaves(level, ref facts, state, x, y, z);
                break;
            case Kind.SporeBlossom:
                SporeBlossom(level, x, y, z);
                break;
            case Kind.PointedDripstone:
                PointedDripstone(level, block, x, y, z);
                break;
            case Kind.CryingObsidian:
                if (random.NextInt(5) == 0) {
                    int dir = random.NextInt(6);
                    if (dir != (int)BlockFace.PosY) {
                        DripFromFace(level, ref facts, Particle.DrippingObsidianTear, x, y, z, dir, 0.6, false);
                    }
                }
                break;
            case Kind.RespawnAnchor when block is RespawnAnchorBlock { Charges: > 0 }:
                if (random.NextInt(100) == 0) {
                    Sound(SoundType.RespawnAnchorAmbient, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5, 1.0F, 1.0F);
                }
                engine.AddParticle(Particle.ReversePortal, x + 0.5 + (0.5 - random.NextDouble()), y + 1.0, z + 0.5 + (0.5 - random.NextDouble()),
                    0.0, random.NextFloat() * 0.04, 0.0);
                break;
            case Kind.BrewingStand:
                engine.AddParticle(Particle.Smoke, x + 0.4 + random.NextFloat() * 0.2, y + 0.7 + random.NextFloat() * 0.3,
                    z + 0.4 + random.NextFloat() * 0.2, 0.0, 0.0, 0.0);
                break;
            case Kind.Furnace or Kind.BlastFurnace when block is ILit { Lit: true }: {
                if (random.NextDouble() < 0.1) {
                    Sound(facts.Kind == Kind.Furnace ? SoundType.FurnaceFireCrackle : SoundType.BlastfurnaceFireCrackle, SoundCategory.Blocks,
                        x + 0.5, y, z + 0.5, 1.0F, 1.0F);
                }
                Direction facing = (block as IHorizontalFacing)?.Facing ?? Direction.North;
                (int sx, _, int sz) = Steps[Data(facing)];
                double ss = random.NextDouble() * 0.6 - 0.3;
                double dx = sx != 0 ? sx * 0.52 : ss;
                double dy = random.NextDouble() * (facts.Kind == Kind.Furnace ? 6.0 : 9.0) / 16.0;
                double dz = sz != 0 ? sz * 0.52 : ss;
                engine.AddParticle(Particle.Smoke, x + 0.5 + dx, y + dy, z + 0.5 + dz, 0.0, 0.0, 0.0);
                if (facts.Kind == Kind.Furnace) {
                    engine.AddParticle(Particle.Flame, x + 0.5 + dx, y + dy, z + 0.5 + dz, 0.0, 0.0, 0.0);
                }
                break;
            }
            case Kind.Smoker when block is ILit { Lit: true }:
                if (random.NextDouble() < 0.1) {
                    Sound(SoundType.SmokerSmoke, SoundCategory.Blocks, x + 0.5, y, z + 0.5, 1.0F, 1.0F);
                }
                engine.AddParticle(Particle.Smoke, x + 0.5, y + 1.1, z + 0.5, 0.0, 0.0, 0.0);
                break;
            case Kind.SculkSensor when block is SculkSensorBlock { SculkSensorPhase: SculkSensorPhase.Active }
                or CalibratedSculkSensorBlock { SculkSensorPhase: SculkSensorPhase.Active }: {
                int dir = random.NextInt(6);
                if (dir > 1) {
                    (int sx, _, int sz) = Steps[dir];
                    double sxp = x + 0.5 + (sx == 0 ? 0.5 - random.NextDouble() : sx * 0.6);
                    double szp = z + 0.5 + (sz == 0 ? 0.5 - random.NextDouble() : sz * 0.6);
                    engine.AddParticle(SculkToRedstone, sxp, y + 0.25, szp, 0.0, random.NextFloat() * 0.04, 0.0);
                }
                break;
            }
            case Kind.Mycelium:
                if (random.NextInt(10) == 0) {
                    engine.AddParticle(Particle.Mycelium, x + random.NextDouble(), y + 1.1, z + random.NextDouble(), 0.0, 0.0, 0.0);
                }
                break;
            case Kind.WetSponge: {
                int dir = random.NextInt(6);
                if (dir != (int)BlockFace.PosY) {
                    DripFromFace(level, ref facts, Particle.DrippingWater, x, y, z, dir, 0.0, true);
                }
                break;
            }
            case Kind.Beehive when block is BeehiveBlock { HoneyLevel: >= 5 }:
                BeehiveDrip(level, ref facts, x, y, z);
                break;
            case Kind.Brushable or Kind.Falling or Kind.Sand:
                if (random.NextInt(16) == 0 && IsFree(level, x, y - 1, z)) {
                    engine.AddParticle(Particle.FallingDust with { BlockState = state }, x + random.NextDouble(), y - 0.05, z + random.NextDouble(),
                        0.0, 0.0, 0.0);
                }
                if (facts.Kind == Kind.Sand) {
                    AmbientSand(level, x, y, z);
                }
                break;
            case Kind.BubbleColumn: {
                bool drag = block is BubbleColumnBlock { Drag: true };
                if (drag) {
                    engine.AddAlwaysVisibleParticle(Particle.CurrentDown, x + 0.5, y + 0.8, z, 0.0, 0.0, 0.0);
                }
                else {
                    engine.AddAlwaysVisibleParticle(Particle.BubbleColumnUp, x + 0.5, y, z + 0.5, 0.0, 0.04, 0.0);
                    engine.AddAlwaysVisibleParticle(Particle.BubbleColumnUp, x + random.NextFloat(), y + random.NextFloat(), z + random.NextFloat(), 0.0, 0.04, 0.0);
                }
                if (random.NextInt(200) == 0) {
                    Sound(drag ? SoundType.BubbleColumnWhirlpoolAmbient : SoundType.BubbleColumnUpwardsAmbient, SoundCategory.Blocks, x, y, z,
                        0.2F + random.NextFloat() * 0.2F, 0.9F + random.NextFloat() * 0.15F);
                }
                break;
            }
            case Kind.DriedGhast: {
                bool waterlogged = block is IWaterlogged { Waterlogged: true };
                if (random.NextInt(40) == 0 && (waterlogged || InTag(level, DriedGhastSoundBlocks, StateAt(level, x, y - 1, z)))) {
                    Sound(waterlogged ? SoundType.DriedGhastAmbientWater : SoundType.DriedGhastAmbient, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5,
                        1.0F, 1.0F);
                }
                if (random.NextInt(6) == 0) {
                    if (waterlogged) {
                        engine.AddParticle(Particle.HappyVillager, x + 0.5 + (random.NextFloat() * 2.0F - 1.0F) / 3.0F, y + 0.9,
                            z + 0.5 + (random.NextFloat() * 2.0F - 1.0F) / 3.0F, 0.0, random.NextFloat(), 0.0);
                    }
                    else {
                        engine.AddParticle(Particle.WhiteSmoke, x + 0.5, y + 0.5, z + 0.5, 0.0, 0.02, 0.0);
                    }
                }
                break;
            }
            case Kind.FireflyBush:
                if (random.NextInt(30) == 0 && BooleanAttribute(level, ChunkAt(level, x, z), EnvironmentAttribute.AudioFireflyBushSounds, x, y, z)
                    && level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.MotionBlockingNoLeaves, x, z) <= y) {
                    Sound(SoundType.FireflyBushIdle, SoundCategory.Ambient, x + 0.5, y + 0.5, z + 0.5, 1.0F, 1.0F);
                }
                if (level.MaxLocalRawBrightness(x, y, z, SkyDarkening) <= 13 && random.NextDouble() <= 0.7) {
                    engine.AddParticle(Particle.Firefly, x + random.NextDouble() * 10.0 - 5.0, y + random.NextDouble() * 5.0,
                        z + random.NextDouble() * 10.0 - 5.0, 0.0, 0.0, 0.0);
                }
                break;
            case Kind.Lever when block is LeverBlock { Powered: true } lever && random.NextFloat() < 0.25F: {
                (int ox, int oy, int oz) = Steps[Opposite(Data(lever.Facing))];
                int connected = lever.Face switch {
                    AttachDirection.Ceiling => (int)BlockFace.NegY,
                    AttachDirection.Floor => (int)BlockFace.PosY,
                    _ => Data(lever.Facing)
                };
                (int cx, int cy, int cz) = Steps[Opposite(connected)];
                engine.AddParticle(LeverDust, x + 0.5 + 0.1 * ox + 0.2 * cx, y + 0.5 + 0.1 * oy + 0.2 * cy, z + 0.5 + 0.1 * oz + 0.2 * cz, 0.0, 0.0, 0.0);
                break;
            }
            case Kind.LightningRod when block is LightningRodBlock rod:
                LightningRod(level, rod, x, y, z);
                break;
            case Kind.PotentSulfur when block is PotentSulfurBlock { PotentSulfurState: not PotentSulfurState.Dry }:
                if (FactsAt(level, x, y + 1, z) is { Fluid: ParticleEngine.FluidWater, FluidSourceOrFalling: true }
                    && BlockAt(level, x, y + 1, z) is not WaterBlock { Level: >= 8 }) {
                    for (int i = 0; i < 2; i++) {
                        engine.AddAlwaysVisibleParticle(Particle.SulfurBubbles, x + random.NextFloat(), y + 1 + random.NextFloat(), z + random.NextFloat(),
                            0.0, 0.0, 0.0);
                    }
                    if (random.NextInt(10) == 0) {
                        Sound(SoundType.PotentSulfurNoxiousGas, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
                    }
                }
                break;
            case Kind.RedstoneOre when block is ILit { Lit: true }:
                RedstoneOre(level, x, y, z);
                break;
            case Kind.WitherRose: {
                Box[] shape = BlockPhysicsData.CollisionBoxesOf(block.BlockShape);
                Minecraft.Schemas.Vec.Vec3<double> offset = block.Info.OffsetType == BlockOffsetType.None
                    ? new Minecraft.Schemas.Vec.Vec3<double>(0, 0, 0)
                    : block.ShapeOffset(new Minecraft.Schemas.Vec.Vec3<int>(x, y, z));
                double cx = shape.Length == 0 ? 0.5 : (shape.Min(b => b.MinX) + shape.Max(b => b.MaxX)) / 2.0 + offset.X;
                double cz = shape.Length == 0 ? 0.5 : (shape.Min(b => b.MinZ) + shape.Max(b => b.MaxZ)) / 2.0 + offset.Z;
                for (int i = 0; i < 3; i++) {
                    if (random.NextBool()) {
                        engine.AddParticle(Particle.Smoke, x + cx + random.NextDouble() / 5.0, y + (0.5 - random.NextDouble()), z + cz + random.NextDouble() / 5.0,
                            0.0, 0.0, 0.0);
                    }
                }
                break;
            }
            case Kind.DryGrass:
                AmbientDryGrass(level, x, y, z);
                break;
            case Kind.DeadBush:
                AmbientDeadBush(level, x, y, z);
                break;
            case Kind.HangingMoss:
                if (random.NextInt(500) == 0) {
                    ushort above = StateAt(level, x, y + 1, z);
                    if (InTag(level, PaleOakLogs, above) || level.Registry.Blocks.GetByStateId(above).Identifier == Block.PaleOakLeaves.Identifier) {
                        Sound(SoundType.PaleHangingMossIdle, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
                    }
                }
                break;
            case Kind.Eyeblossom:
                // EyeblossomBlock.Type.emitSounds: only the open one.
                if (block.Identifier == Block.OpenEyeblossom.Identifier && random.NextInt(700) == 0
                    && BlockAt(level, x, y - 1, z).Identifier == Block.PaleMossBlock.Identifier) {
                    Sound(SoundType.EyeblossomIdle, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
                }
                break;
            case Kind.CreakingHeart when block is CreakingHeartBlock { CreakingHeartState: not CreakingHeartState.Uprooted }:
                if (BooleanAttribute(level, ChunkAt(level, x, z), EnvironmentAttribute.GameplayCreakingActive, x, y, z) && random.NextInt(16) == 0
                    && IsSurroundedByLogs(level, x, y, z)) {
                    Sound(SoundType.CreakingHeartIdle, SoundCategory.Blocks, x, y, z, 1.0F, 1.0F);
                }
                break;
        }
    }

    /// <summary><c>AbstractCandleBlock.addParticlesAndSound</c>; the sound sits half a block on from the flame.</summary>
    private void CandleFlame(double x, double y, double z) {
        float chance = _random.NextFloat();
        if (chance < 0.3F) {
            Engine.AddParticle(Particle.Smoke, x, y, z, 0.0, 0.0, 0.0);
            if (chance < 0.17F) {
                Sound(SoundType.CandleAmbient, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5, 1.0F + _random.NextFloat(), _random.NextFloat() * 0.7F + 0.3F);
            }
        }
        Engine.AddParticle(Particle.SmallFlame, x, y, z, 0.0, 0.0, 0.0);
    }

    /// <summary><c>BaseFireBlock.animateTick</c>: smoke through the fire, or along the burnable blocks it clings to.</summary>
    private void Fire(ClientLevel level, ref Facts facts, int x, int y, int z) {
        ParticleRandom random = _random;
        if (random.NextInt(24) == 0) {
            Sound(SoundType.FireAmbient, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5, 1.0F + random.NextFloat(), random.NextFloat() * 0.7F + 0.3F);
        }
        ref Facts below = ref FactsAt(level, x, y - 1, z);
        bool soul = facts.Particle != null;
        if (!CanBurn(ref below, soul) && (below.SturdyFaces & 1 << (int)BlockFace.PosY) == 0) {
            if (CanBurn(ref FactsAt(level, x - 1, y, z), soul)) {
                for (int i = 0; i < 2; i++) {
                    LargeSmoke(x + random.NextDouble() * 0.1F, y + random.NextDouble(), z + random.NextDouble());
                }
            }
            if (CanBurn(ref FactsAt(level, x + 1, y, z), soul)) {
                for (int i = 0; i < 2; i++) {
                    LargeSmoke(x + 1 - random.NextDouble() * 0.1F, y + random.NextDouble(), z + random.NextDouble());
                }
            }
            if (CanBurn(ref FactsAt(level, x, y, z - 1), soul)) {
                for (int i = 0; i < 2; i++) {
                    LargeSmoke(x + random.NextDouble(), y + random.NextDouble(), z + random.NextDouble() * 0.1F);
                }
            }
            if (CanBurn(ref FactsAt(level, x, y, z + 1), soul)) {
                for (int i = 0; i < 2; i++) {
                    LargeSmoke(x + random.NextDouble(), y + random.NextDouble(), z + 1 - random.NextDouble() * 0.1F);
                }
            }
            if (CanBurn(ref FactsAt(level, x, y + 1, z), soul)) {
                for (int i = 0; i < 2; i++) {
                    LargeSmoke(x + random.NextDouble(), y + 1 - random.NextDouble() * 0.1F, z + random.NextDouble());
                }
            }
        }
        else {
            for (int i = 0; i < 3; i++) {
                LargeSmoke(x + random.NextDouble(), y + random.NextDouble() * 0.5 + 0.5, z + random.NextDouble());
            }
        }
    }

    /// <summary><c>FireBlock.canBurn</c> is the flammability table; <c>SoulFireBlock.canBurn</c> is always true.</summary>
    private static bool CanBurn(ref Facts facts, bool soul) => soul || facts.Flammable;

    private void LargeSmoke(double x, double y, double z) => Engine.AddParticle(Particle.LargeSmoke, x, y, z, 0.0, 0.0, 0.0);

    /// <summary><c>RedStoneWireBlock.animateTick</c> and <c>spawnParticlesAlongLine</c>.</summary>
    private void RedstoneWire(RedstoneWireBlock wire, int x, int y, int z) {
        DustParticle dust = WireDust[Math.Clamp(wire.Power, 0, 15)];
        foreach (int horizontal in Horizontal) {
            RedstoneWireConnection connection = horizontal switch {
                2 => wire.North,
                5 => wire.East,
                3 => wire.South,
                _ => wire.West
            };
            switch (connection) {
                case RedstoneWireConnection.Up:
                    AlongLine(dust, x, y, z, horizontal, (int)BlockFace.PosY, -0.5F, 0.5F);
                    AlongLine(dust, x, y, z, (int)BlockFace.NegY, horizontal, 0.0F, 0.5F);
                    break;
                case RedstoneWireConnection.Side:
                    AlongLine(dust, x, y, z, (int)BlockFace.NegY, horizontal, 0.0F, 0.5F);
                    break;
                default:
                    AlongLine(dust, x, y, z, (int)BlockFace.NegY, horizontal, 0.0F, 0.3F);
                    break;
            }
        }
    }

    private void AlongLine(DustParticle dust, int x, int y, int z, int side, int along, float from, float to) {
        float span = to - from;
        if (_random.NextFloat() >= 0.2F * span) {
            return;
        }
        float positionOnLine = from + span * _random.NextFloat();
        (int sx, int sy, int sz) = Steps[side];
        (int ax, int ay, int az) = Steps[along];
        Engine.AddParticle(dust, x + 0.5 + 0.4375F * sx + positionOnLine * ax, y + 0.5 + 0.4375F * sy + positionOnLine * ay,
            z + 0.5 + 0.4375F * sz + positionOnLine * az, 0.0, 0.0, 0.0);
    }

    /// <summary><c>EndGatewayBlock.animateTick</c>: one portal particle per face the gateway shows.</summary>
    private void EndGateway(ClientLevel level, int x, int y, int z) {
        int count = 0;
        foreach ((int sx, int sy, int sz) in Steps) {
            if (!FactsAt(level, x + sx, y + sy, z + sz).SolidRender) {
                count++;
            }
        }
        ParticleRandom random = _random;
        for (int i = 0; i < count; i++) {
            double px = x + random.NextDouble();
            double py = y + random.NextDouble();
            double pz = z + random.NextDouble();
            double xa = (random.NextDouble() - 0.5) * 0.5;
            double ya = (random.NextDouble() - 0.5) * 0.5;
            double za = (random.NextDouble() - 0.5) * 0.5;
            int flip = random.NextInt(2) * 2 - 1;
            if (random.NextBool()) {
                pz = z + 0.5 + 0.25 * flip;
                za = random.NextFloat() * 2.0F * flip;
            }
            else {
                px = x + 0.5 + 0.25 * flip;
                xa = random.NextFloat() * 2.0F * flip;
            }
            Engine.AddParticle(Particle.Portal, px, py, pz, xa, ya, za);
        }
    }

    /// <summary><c>NetherPortalBlock.animateTick</c>: four particles drawn in toward the portal's plane.</summary>
    private void NetherPortal(ClientLevel level, IBlock block, int x, int y, int z) {
        ParticleRandom random = _random;
        if (random.NextInt(100) == 0) {
            Sound(SoundType.PortalAmbient, SoundCategory.Blocks, x + 0.5, y + 0.5, z + 0.5, 0.5F, random.NextFloat() * 0.4F + 0.8F);
        }
        Identifier portal = block.Identifier;
        bool alongX = BlockAt(level, x - 1, y, z).Identifier == portal || BlockAt(level, x + 1, y, z).Identifier == portal;
        for (int i = 0; i < 4; i++) {
            double px = x + random.NextDouble();
            double py = y + random.NextDouble();
            double pz = z + random.NextDouble();
            double xa = (random.NextFloat() - 0.5) * 0.5;
            double ya = (random.NextFloat() - 0.5) * 0.5;
            double za = (random.NextFloat() - 0.5) * 0.5;
            int flip = random.NextInt(2) * 2 - 1;
            if (!alongX) {
                px = x + 0.5 + 0.25 * flip;
                xa = random.NextFloat() * 2.0F * flip;
            }
            else {
                pz = z + 0.5 + 0.25 * flip;
                za = random.NextFloat() * 2.0F * flip;
            }
            Engine.AddParticle(Particle.Portal, px, py, pz, xa, ya, za);
        }
    }

    /// <summary><c>LeavesBlock.animateTick</c>: rain dripping through, and the falling leaf.</summary>
    private void Leaves(ClientLevel level, ref Facts facts, ushort state, int x, int y, int z) {
        ParticleRandom random = _random;
        ref Facts below = ref FactsAt(level, x, y - 1, z);
        // makeDrippingWaterParticles.
        if (level.RainLevel > 0.2F && level.IsRainingAt(x, y + 1, z) && random.NextInt(15) == 1
            && (!below.CanOcclude || (below.SturdyFaces & 1 << (int)BlockFace.PosY) == 0)) {
            Engine.AddParticle(Particle.DrippingWater, x + random.NextDouble(), y - 0.05, z + random.NextDouble(), 0.0, 0.0, 0.0);
        }
        // makeFallingLeavesParticles.
        if (random.NextFloat() >= facts.Chance || below.TopFaceFull) {
            return;
        }
        IParticle leaf = facts.Particle!;
        if (facts.Tinted) {
            int tint = Engine.Colours?.TerrainTint(state, x, y, z) ?? -1;
            leaf = Particle.TintedLeaves with { Argb = tint };
        }
        Engine.AddParticle(leaf, x + random.NextDouble(), y - 0.05, z + random.NextDouble(), 0.0, 0.0, 0.0);
    }

    /// <summary><c>SporeBlossomBlock.animateTick</c>: a falling spore under it, and fourteen tries at a drifting one nearby.</summary>
    private void SporeBlossom(ClientLevel level, int x, int y, int z) {
        ParticleRandom random = _random;
        Engine.AddParticle(Particle.FallingSporeBlossom, x + random.NextDouble(), y + 0.7, z + random.NextDouble(), 0.0, 0.0, 0.0);
        for (int i = 0; i < 14; i++) {
            int ax = x + random.NextInt(21) - 10;
            int ay = y - random.NextInt(10);
            int az = z + random.NextInt(21) - 10;
            if (!FactsAt(level, ax, ay, az).CollisionFullBlock) {
                Engine.AddParticle(Particle.SporeBlossomAir, ax + random.NextDouble(), ay + random.NextDouble(), az + random.NextDouble(), 0.0, 0.0, 0.0);
            }
        }
    }

    /// <summary><c>PointedDripstoneBlock.animateTick</c>: a free hanging tip drips what stands above its root.</summary>
    private void PointedDripstone(ClientLevel level, IBlock block, int x, int y, int z) {
        if (block is not PointedDripstoneBlock { VerticalDirection: VerticalDirection.Down, Thickness: SpeleothemThickness.Tip, Waterlogged: false }) {
            return;
        }
        float randomValue = _random.NextFloat();
        if (randomValue > 0.12F) {
            return;
        }
        // findRootBlock: up through stalactite pieces to the first block that is not dripstone.
        int rootY = -1;
        for (int i = 1; i < 11; i++) {
            int cy = y + i;
            IBlock above = BlockAt(level, x, cy, z);
            if (above is not PointedDripstoneBlock) {
                rootY = cy - 1;
                break;
            }
            if (cy >= level.MinY + level.Height || above is not PointedDripstoneBlock { VerticalDirection: VerticalDirection.Down }) {
                return;
            }
        }
        if (rootY < 0) {
            return;
        }
        int aboveY = rootY + 1;
        IBlock source = BlockAt(level, x, aboveY, z);
        byte fluid = source.Identifier == Block.Mud.Identifier
            && DimensionConstant(level, EnvironmentAttribute.GameplayWaterEvaporates) is not EnvironmentAttributeValue.Boolean { Value: true }
            ? ParticleEngine.FluidWater
            : FactsAt(level, x, aboveY, z).Fluid;
        if (!(randomValue < 0.02F || fluid != 0)) {
            return;
        }
        IParticle drip = fluid switch {
            ParticleEngine.FluidLava => Particle.DrippingDripstoneLava,
            ParticleEngine.FluidWater => Particle.DrippingDripstoneWater,
            _ => DefaultDripstoneParticle(level)
        };
        Minecraft.Schemas.Vec.Vec3<double> offset = block.ShapeOffset(new Minecraft.Schemas.Vec.Vec3<int>(x, y, z));
        // STALACTITE_DRIP_START_PIXEL is the tip shape's bottom, five sixteenths up.
        Engine.AddParticle(drip, x + 0.5 + offset.X, y + 5.0 / 16.0 - 0.0625, z + 0.5 + offset.Z, 0.0, 0.0, 0.0);
    }

    /// <summary>The <c>visual/default_dripstone_particle</c> attribute, read from the dimension only.</summary>
    private static IParticle DefaultDripstoneParticle(ClientLevel level) =>
        DimensionConstant(level, EnvironmentAttribute.VisualDefaultDripstoneParticle) is EnvironmentAttributeValue.Particle { Value: { Options.Count: 0 } value }
        && level.Registry.Particles.Contains(value.Type)
            ? level.Registry.Particles[value.Type]
            : Particle.DrippingDripstoneWater;

    /// <summary>An attribute's value as the dimension sets it, ignoring what biomes, weather and timelines do to it.</summary>
    private static EnvironmentAttributeValue? DimensionConstant(ClientLevel level, IEnvironmentAttribute attribute) =>
        level.DimensionType.Attributes?[attribute.Identifier.ToString()] is { } tag
            ? Constant(level, attribute, EnvironmentAttributeEntry.FromNbt(attribute, tag, level.Registry))
            : null;

    /// <summary>
    /// <c>CryingObsidianBlock</c> and <c>WetSpongeBlock</c>: a drip from a face that is not covered. The sponge's
    /// drip sits on the face with a lower one under it; the tear sits <paramref name="out"/> out from the middle.
    /// </summary>
    private void DripFromFace(ClientLevel level, ref Facts facts, IParticle particle, int x, int y, int z, int dir, double outward, bool sponge) {
        ParticleRandom random = _random;
        (int sx, int sy, int sz) = Steps[dir];
        int opposite = Opposite(dir);
        if (facts.CanOcclude && (FactsAt(level, x + sx, y + sy, z + sz).SturdyFaces & 1 << opposite) != 0) {
            return;
        }
        if (!sponge) {
            double xo = sx == 0 ? random.NextDouble() : 0.5 + sx * outward;
            double yo = sy == 0 ? random.NextDouble() : 0.5 + sy * outward;
            double zo = sz == 0 ? random.NextDouble() : 0.5 + sz * outward;
            Engine.AddParticle(particle, x + xo, y + yo, z + zo, 0.0, 0.0, 0.0);
            return;
        }
        double xx = x, yy = y, zz = z;
        if (dir == (int)BlockFace.NegY) {
            yy -= 0.05;
            xx += random.NextDouble();
            zz += random.NextDouble();
        }
        else {
            yy += random.NextDouble() * 0.8;
            if (sx != 0) {
                zz += random.NextDouble();
                xx += sx > 0 ? 1.0 : 0.05;
            }
            else {
                xx += random.NextDouble();
                zz += sz > 0 ? 1.0 : 0.05;
            }
        }
        Engine.AddParticle(particle, xx, yy, zz, 0.0, 0.0, 0.0);
    }

    /// <summary><c>BeehiveBlock.trySpawnDripParticles</c>: honey from under a full hive.</summary>
    private void BeehiveDrip(ClientLevel level, ref Facts facts, int x, int y, int z) {
        if (facts.Fluid != 0 || _random.NextFloat() < 0.3F || facts.MaxY < 1.0F || InTag(level, Impermeable, StateAt(level, x, y, z))) {
            return;
        }
        if (facts.MinY > 0.0F) {
            SpawnFluidParticle(x + facts.MinX, x + facts.MaxX, z + facts.MinZ, z + facts.MaxZ, y + facts.MinY - 0.05, Particle.DrippingHoney);
            return;
        }
        ref Facts below = ref FactsAt(level, x, y - 1, z);
        if ((below.MaxY < 1.0F || !below.CollisionFullBlock) && below.Fluid == 0) {
            SpawnFluidParticle(x + facts.MinX, x + facts.MaxX, z + facts.MinZ, z + facts.MaxZ, y - 0.05, Particle.DrippingHoney);
        }
    }

    /// <summary><c>FallingBlock.isFree</c>.</summary>
    private bool IsFree(ClientLevel level, int x, int y, int z) {
        ushort state = StateAt(level, x, y, z);
        ref Facts facts = ref FactsOf(state);
        return facts.Air || facts.Liquid || facts.Replaceable || InTag(level, FireTag, state);
    }

    /// <summary>
    /// <c>LightningRodBlock.animateTick</c>: sparks along a rod at the top of the world's surface during a
    /// thunderstorm, more often the longer it has been since the storm's last two hundred tick boundary.
    /// </summary>
    private void LightningRod(ClientLevel level, LightningRodBlock rod, int x, int y, int z) {
        ParticleRandom random = _random;
        if (level.ThunderLevel <= 0.9F || random.NextInt(200) > level.GameTime % 200L
            || y != level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.WorldSurface, x, z) - 1) {
            return;
        }
        int axis = rod.Facing switch {
            Cardinal.East or Cardinal.West => 0,
            Cardinal.Up or Cardinal.Down => 1,
            _ => 2
        };
        int count = 1 + random.NextInt(2);
        for (int i = 0; i < count; i++) {
            double px = x + 0.5 + (random.NextDouble() * 2.0 - 1.0) * (axis == 0 ? 0.5 : 0.125);
            double py = y + 0.5 + (random.NextDouble() * 2.0 - 1.0) * (axis == 1 ? 0.5 : 0.125);
            double pz = z + 0.5 + (random.NextDouble() * 2.0 - 1.0) * (axis == 2 ? 0.5 : 0.125);
            double xa = axis == 0 ? random.NextDouble() * 2.0 - 1.0 : 0.0;
            double ya = axis == 1 ? random.NextDouble() * 2.0 - 1.0 : 0.0;
            double za = axis == 2 ? random.NextDouble() * 2.0 - 1.0 : 0.0;
            Engine.AddParticle(Particle.ElectricSpark, px, py, pz, xa, ya, za);
        }
    }

    /// <summary><c>RedStoneOreBlock.spawnParticles</c>: dust just off every face not against a solid block.</summary>
    private void RedstoneOre(ClientLevel level, int x, int y, int z) {
        ParticleRandom random = _random;
        for (int dir = 0; dir < 6; dir++) {
            (int sx, int sy, int sz) = Steps[dir];
            if (FactsAt(level, x + sx, y + sy, z + sz).SolidRender) {
                continue;
            }
            double dx = sx != 0 ? 0.5 + 0.5625 * sx : random.NextFloat();
            double dy = sy != 0 ? 0.5 + 0.5625 * sy : random.NextFloat();
            double dz = sz != 0 ? 0.5 + 0.5625 * sz : random.NextFloat();
            Engine.AddParticle(Redstone, x + dx, y + dy, z + dz, 0.0, 0.0, 0.0);
        }
    }

    #endregion

    #region Facts

    private ref Facts FactsAt(ClientLevel level, int x, int y, int z) => ref FactsOf(StateAt(level, x, y, z));

    private ClientChunk? ChunkAt(ClientLevel level, int x, int z) {
        uint gx = (uint)((x >> 4) - _gridX), gz = (uint)((z >> 4) - _gridZ);
        return gx < GridSize && gz < GridSize ? _grid[gz * GridSize + gx] : level.GetChunk(x >> 4, z >> 4);
    }

    private IBlock BlockAt(ClientLevel level, int x, int y, int z) => level.Registry.Blocks.GetByStateId(StateAt(level, x, y, z));

    /// <summary><see cref="ClientLevel.GetState"/> through this tick's chunks.</summary>
    private ushort StateAt(ClientLevel level, int x, int y, int z) {
        int section = (y - level.MinY) >> 4;
        if ((uint)section >= (uint)level.SectionCount) {
            return 0;
        }
        return ChunkAt(level, x, z)?.Sections[section].Get(x & 15, y & 15, z & 15) ?? 0;
    }

    private ref Facts FactsOf(ushort state) {
        if (state >= _facts.Length) {
            return ref _facts[0];
        }
        ref Facts facts = ref _facts[state];
        if (!facts.Known) {
            facts = Build(_level!, state);
        }
        return ref facts;
    }

    private static Facts Build(ClientLevel level, ushort state) {
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        Facts facts = new() {
            Known = true,
            Air = level.IsAir(state),
            CanOcclude = block.Occludes,
            Replaceable = block.Replaceable,
            Liquid = block.Liquid,
            Flammable = block.StateInfo.Flammable
        };
        Box[] collision = BlockPhysicsData.Get(level.Registry, state).Collision;
        facts.CollisionFullBlock = ShapeSupport.IsShapeFullBlock(block.CollisionShape);
        facts.SolidRender = block.Occludes && ShapeSupport.IsShapeFullBlock(block.OcclusionShape);
        for (int face = 0; face < 6; face++) {
            if (ShapeSupport.IsFaceSturdy(block, (BlockFace)face)) {
                facts.SturdyFaces |= (byte)(1 << face);
            }
        }
        if (collision.Length == 0) {
            (facts.MinX, facts.MinY, facts.MinZ, facts.MaxX, facts.MaxY, facts.MaxZ) = (1, 1, 1, 0, 0, 0);
        }
        else {
            facts.MinX = (float)collision.Min(b => b.MinX);
            facts.MinY = (float)collision.Min(b => b.MinY);
            facts.MinZ = (float)collision.Min(b => b.MinZ);
            facts.MaxX = (float)collision.Max(b => b.MaxX);
            facts.MaxY = (float)collision.Max(b => b.MaxY);
            facts.MaxZ = (float)collision.Max(b => b.MaxZ);
        }
        // Block.isFaceFull(shape, UP): the boxes reaching the top cover it, and they never overlap.
        facts.TopFaceFull = collision.Where(b => b.MaxY >= 1.0).Sum(b => (b.MaxX - b.MinX) * (b.MaxZ - b.MinZ)) >= 1.0 - 1.0E-7;
        if (block.Fluid is { } fluid) {
            facts.Fluid = fluid.Key is "water" or "flowing_water" ? ParticleEngine.FluidWater : fluid.Key is "lava" or "flowing_lava" ? ParticleEngine.FluidLava : (byte)0;
            int fluidLevel = block switch {
                WaterBlock water => water.Level,
                LavaBlock lava => lava.Level,
                _ => 0
            };
            facts.FluidSourceOrFalling = fluidLevel == 0 || fluidLevel >= 8;
        }
        Classify(block, ref facts);
        return facts;
    }

    /// <summary>Which vanilla class's <c>animateTick</c> a block runs, most specific class first.</summary>
    private static void Classify(IBlock block, ref Facts facts) {
        Identifier id = block.Identifier;
        bool Is(BlockClass type) => BlockClasses.Is(id, type);

        if (Is(BlockClass.RedstoneWallTorchBlock)) {
            facts.Kind = Kind.RedstoneWallTorch;
        }
        else if (Is(BlockClass.RedstoneTorchBlock)) {
            facts.Kind = Kind.RedstoneTorch;
        }
        else if (Is(BlockClass.WallTorchBlock) || Is(BlockClass.TorchBlock)) {
            facts.Kind = Is(BlockClass.WallTorchBlock) ? Kind.WallTorch : Kind.Torch;
            facts.Particle = id == Block.SoulTorch.Identifier || id == Block.SoulWallTorch.Identifier ? Particle.SoulFireFlame
                : id == Block.CopperTorch.Identifier || id == Block.CopperWallTorch.Identifier ? Particle.CopperFireFlame
                : Particle.Flame;
        }
        else if (Is(BlockClass.BaseFireBlock)) {
            facts.Kind = Kind.Fire;
            // Marks soul fire, whose canBurn is always true.
            facts.Particle = Is(BlockClass.SoulFireBlock) ? Particle.SoulFireFlame : null;
        }
        else if (Is(BlockClass.CampfireBlock)) {
            facts.Kind = Kind.Campfire;
            // CampfireBlock.spawnParticles: only the plain campfire throws embers.
            facts.Particle = id == Block.Campfire.Identifier ? Particle.Lava : null;
        }
        else if (Is(BlockClass.CandleCakeBlock)) {
            facts.Kind = Kind.CandleCake;
        }
        else if (Is(BlockClass.CandleBlock)) {
            facts.Kind = Kind.Candle;
        }
        else if (Is(BlockClass.RedStoneWireBlock)) {
            facts.Kind = Kind.RedstoneWire;
        }
        else if (Is(BlockClass.RepeaterBlock)) {
            facts.Kind = Kind.Repeater;
        }
        else if (Is(BlockClass.EndRodBlock)) {
            facts.Kind = Kind.EndRod;
        }
        else if (Is(BlockClass.EndPortalBlock)) {
            facts.Kind = Kind.EndPortal;
        }
        else if (Is(BlockClass.EndGatewayBlock)) {
            facts.Kind = Kind.EndGateway;
        }
        else if (Is(BlockClass.NetherPortalBlock)) {
            facts.Kind = Kind.NetherPortal;
        }
        else if (Is(BlockClass.EnderChestBlock)) {
            facts.Kind = Kind.EnderChest;
        }
        else if (Is(BlockClass.EnchantingTableBlock)) {
            facts.Kind = Kind.EnchantingTable;
        }
        else if (Is(BlockClass.LeavesBlock)) {
            facts.Kind = Kind.Leaves;
            Leaf(id, ref facts);
        }
        else if (Is(BlockClass.SporeBlossomBlock)) {
            facts.Kind = Kind.SporeBlossom;
        }
        else if (Is(BlockClass.PointedDripstoneBlock)) {
            facts.Kind = Kind.PointedDripstone;
        }
        else if (Is(BlockClass.CryingObsidianBlock)) {
            facts.Kind = Kind.CryingObsidian;
        }
        else if (Is(BlockClass.RespawnAnchorBlock)) {
            facts.Kind = Kind.RespawnAnchor;
        }
        else if (Is(BlockClass.BrewingStandBlock)) {
            facts.Kind = Kind.BrewingStand;
        }
        else if (Is(BlockClass.BlastFurnaceBlock)) {
            facts.Kind = Kind.BlastFurnace;
        }
        else if (Is(BlockClass.SmokerBlock)) {
            facts.Kind = Kind.Smoker;
        }
        else if (Is(BlockClass.FurnaceBlock)) {
            facts.Kind = Kind.Furnace;
        }
        else if (Is(BlockClass.SculkSensorBlock)) {
            facts.Kind = Kind.SculkSensor;
        }
        else if (Is(BlockClass.MyceliumBlock)) {
            facts.Kind = Kind.Mycelium;
        }
        else if (Is(BlockClass.WetSpongeBlock)) {
            facts.Kind = Kind.WetSponge;
        }
        else if (Is(BlockClass.BeehiveBlock)) {
            facts.Kind = Kind.Beehive;
        }
        else if (Is(BlockClass.BrushableBlock)) {
            facts.Kind = Kind.Brushable;
        }
        else if (Is(BlockClass.BubbleColumnBlock)) {
            facts.Kind = Kind.BubbleColumn;
        }
        else if (Is(BlockClass.DriedGhastBlock)) {
            facts.Kind = Kind.DriedGhast;
        }
        else if (Is(BlockClass.SandBlock)) {
            facts.Kind = Kind.Sand;
        }
        else if (Is(BlockClass.FallingBlock)) {
            facts.Kind = Kind.Falling;
        }
        else if (Is(BlockClass.FireflyBushBlock)) {
            facts.Kind = Kind.FireflyBush;
        }
        else if (Is(BlockClass.LeverBlock)) {
            facts.Kind = Kind.Lever;
        }
        else if (Is(BlockClass.LightningRodBlock)) {
            facts.Kind = Kind.LightningRod;
        }
        else if (Is(BlockClass.PotentSulfurBlock)) {
            facts.Kind = Kind.PotentSulfur;
        }
        else if (Is(BlockClass.RedStoneOreBlock)) {
            facts.Kind = Kind.RedstoneOre;
        }
        else if (Is(BlockClass.WitherRoseBlock)) {
            facts.Kind = Kind.WitherRose;
        }
        else if (Is(BlockClass.ShortDryGrassBlock) || Is(BlockClass.TallDryGrassBlock)) {
            facts.Kind = Kind.DryGrass;
        }
        else if (Is(BlockClass.DryVegetationBlock)) {
            facts.Kind = Kind.DeadBush;
        }
        else if (Is(BlockClass.HangingMossBlock)) {
            facts.Kind = Kind.HangingMoss;
        }
        else if (Is(BlockClass.EyeblossomBlock)) {
            facts.Kind = Kind.Eyeblossom;
        }
        else if (Is(BlockClass.CreakingHeartBlock)) {
            facts.Kind = Kind.CreakingHeart;
        }
    }

    /// <summary>The <c>Blocks</c> registrations' leaf particle and chance, which the class chain does not carry.</summary>
    private static void Leaf(Identifier id, ref Facts facts) {
        facts.Chance = 0.01F;
        if (id == Block.CherryLeaves.Identifier) {
            facts.Particle = Particle.CherryLeaves;
            facts.Chance = 0.1F;
        }
        else if (id == Block.PaleOakLeaves.Identifier) {
            facts.Particle = Particle.PaleOakLeaves;
            facts.Chance = 0.02F;
        }
        else if (id == Block.AzaleaLeaves.Identifier || id == Block.FloweringAzaleaLeaves.Identifier) {
            facts.Particle = AzaleaLeaf;
        }
        else {
            facts.Particle = Particle.TintedLeaves;
            facts.Tinted = true;
        }
    }

    /// <summary><c>state.is(tag)</c> against the tags the server sent, cached until it sends others.</summary>
    private bool InTag(ClientLevel level, Identifier tag, ushort state) {
        if (!ReferenceEquals(_tagSource, client.Tags.GetValueOrDefault("minecraft:block"))) {
            _tagSource = client.Tags.GetValueOrDefault("minecraft:block");
            _tags.Clear();
        }
        if (!_tags.TryGetValue(tag, out HashSet<int>? members)) {
            members = _tagSource != null && _tagSource.TryGetValue(tag, out int[]? ids) ? [..ids] : [];
            _tags[tag] = members;
        }
        return members.Count > 0 && members.Contains(level.Registry.Blocks.GetProtocolId(level.Registry.Blocks.GetByStateId(state)));
    }

    #endregion

    /// <summary>A horizontal direction's 3D data value.</summary>
    private static int Data(Direction direction) => direction switch {
        Direction.North => 2,
        Direction.South => 3,
        Direction.West => 4,
        _ => 5
    };

    private static int Opposite(int data) => data ^ 1;
}
