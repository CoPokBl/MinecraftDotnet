using ClientLib.Entities;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Block = Minecraft.Data.Generated.Block;
using BlockClass = Minecraft.Data.Generated.BlockClass;
using BlockClasses = Minecraft.Data.Generated.BlockClasses;
using Item = Minecraft.Data.Generated.Item;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary>
/// The particle half of <c>LevelEventHandler.levelEvent</c> and the helpers its cases call: what each case
/// spawns, where and how many, with the draws taken from <see cref="Random"/>.
/// </summary>
public sealed partial class ParticleEngine {
    /// <summary><c>Direction.values()</c>: down, up, north, south, west, east.</summary>
    private static readonly (int X, int Y, int Z)[] Directions = [(0, -1, 0), (0, 1, 0), (0, 0, -1), (0, 0, 1), (-1, 0, 0), (1, 0, 0)];

    private static readonly ItemParticle SplashPotionBreak = Particle.Item with { Item = new ItemStack(Item.SplashPotion) };
    private static readonly ItemParticle EnderEyeBreak = Particle.Item with { Item = new ItemStack(Item.EnderEye) };
    private static readonly SculkChargeParticle SculkChargeUpright = Particle.SculkCharge with { Roll = 0.0F };
    private static readonly SculkChargeParticle SculkChargeFlipped = Particle.SculkCharge with { Roll = MathF.PI };
    private static readonly ShriekParticle[] Shrieks = Enumerable.Range(0, 10).Select(i => Particle.Shriek with { Delay = i * 5 }).ToArray();

    /// <summary>The classes that implement <c>BonemealableBlock</c>, which their subclasses inherit.</summary>
    private static readonly HashSet<BlockClass> Bonemealable = [
        BlockClass.AzaleaBlock, BlockClass.BambooSaplingBlock, BlockClass.BambooStalkBlock, BlockClass.BigDripleafBlock, BlockClass.BigDripleafStemBlock,
        BlockClass.BonemealableFeaturePlacerBlock, BlockClass.BushBlock, BlockClass.CocoaBlock, BlockClass.CropBlock, BlockClass.FireflyBushBlock,
        BlockClass.FlowerBedBlock, BlockClass.GlowLichenBlock, BlockClass.GrassBlock, BlockClass.GrowingPlantBodyBlock, BlockClass.GrowingPlantHeadBlock,
        BlockClass.HangingMossBlock, BlockClass.MangroveLeavesBlock, BlockClass.MossyCarpetBlock, BlockClass.MushroomBlock, BlockClass.NetherFungusBlock,
        BlockClass.NetherrackBlock, BlockClass.NyliumBlock, BlockClass.PitcherCropBlock, BlockClass.RootedDirtBlock, BlockClass.SaplingBlock,
        BlockClass.SeagrassBlock, BlockClass.SeaPickleBlock, BlockClass.ShortDryGrassBlock, BlockClass.SmallDripleafBlock, BlockClass.StemBlock,
        BlockClass.SweetBerryBushBlock, BlockClass.TallDryGrassBlock, BlockClass.TallFlowerBlock, BlockClass.TallGrassBlock
    ];

    /// <summary>The bonemealable classes whose <c>getType</c> is <c>NEIGHBOR_SPREADER</c>.</summary>
    private static readonly HashSet<BlockClass> NeighbourSpreaders = [
        BlockClass.GrassBlock, BlockClass.NyliumBlock, BlockClass.NetherrackBlock, BlockClass.BonemealableFeaturePlacerBlock
    ];

    /// <summary>The bonemealable classes whose <c>getParticlePos</c> is the block below.</summary>
    private static readonly HashSet<BlockClass> ParticlesBelow = [BlockClass.RootedDirtBlock, BlockClass.MangroveLeavesBlock];

    /// <summary>
    /// The particle half of <c>LevelEventHandler.levelEvent</c>, for events from the server and the level's own.
    /// The cases vanilla gives no particles (sounds, jukeboxes, 1009's fire, 3001's growl) fall through.
    /// </summary>
    public void LevelEvent(int type, int x, int y, int z, int data) {
        if (!Ready()) {
            return;
        }
        ParticleRandom random = Random;
        switch (type) {
            case 1500:
                ComposterFill(x, y, z);
                break;
            case 1501:
                for (int i = 0; i < 8; i++) {
                    AddParticle(Particle.LargeSmoke, x + random.NextDouble(), y + 1.2, z + random.NextDouble(), 0.0, 0.0, 0.0);
                }
                break;
            case 1502:
                for (int i = 0; i < 5; i++) {
                    AddParticle(Particle.Smoke, x + random.NextDouble() * 0.6 + 0.2, y + random.NextDouble() * 0.6 + 0.2, z + random.NextDouble() * 0.6 + 0.2,
                        0.0, 0.0, 0.0);
                }
                break;
            case 1503:
                for (int i = 0; i < 16; i++) {
                    AddParticle(Particle.Smoke, x + (5.0 + random.NextDouble() * 6.0) / 16.0, y + 0.8125, z + (5.0 + random.NextDouble() * 6.0) / 16.0,
                        0.0, 0.0, 0.0);
                }
                break;
            case 1504:
                DripstoneDrip(x, y, z);
                break;
            case 1505:
                GrowthParticles(x, y, z, data);
                break;
            case 2000:
                ShootParticles(data, x, y, z, Particle.Smoke);
                break;
            case 2001:
            case 3008:
                // Block.stateById: an id the registry does not know is air, which makes nothing.
                if ((uint)data < _level!.Registry.Blocks.StatesCount) {
                    Destroy(x, y, z, (uint)data);
                }
                break;
            case 2002:
            case 2007:
                PotionSplash(x, y, z, data, type == 2007 ? Particle.InstantEffect : Particle.Effect);
                break;
            case 2003:
                EyeOfEnderBreak(x, y, z);
                break;
            case 2004:
                for (int i = 0; i < 20; i++) {
                    double px = x + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    double py = y + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    double pz = z + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    AddParticle(Particle.Smoke, px, py, pz, 0.0, 0.0, 0.0);
                    AddParticle(Particle.Flame, px, py, pz, 0.0, 0.0, 0.0);
                }
                break;
            case 2006:
                for (int i = 0; i < 200; i++) {
                    float distance = random.NextFloat() * 4.0F;
                    float angle = random.NextFloat() * (MathF.PI * 2.0F);
                    double xd = MathF.Cos(angle) * distance;
                    double yd = 0.01 + random.NextDouble() * 0.5;
                    double zd = MathF.Sin(angle) * distance;
                    AddParticle(Particle.DragonBreath with { Power = distance }, x + xd * 0.1, y + 0.3, z + zd * 0.1, xd, yd, zd);
                }
                break;
            case 2008:
                AddParticle(Particle.Explosion, x + 0.5, y + 0.5, z + 0.5, 0.0, 0.0, 0.0);
                break;
            case 2009:
                for (int i = 0; i < 8; i++) {
                    AddParticle(Particle.Cloud, x + random.NextDouble(), y + 1.2, z + random.NextDouble(), 0.0, 0.0, 0.0);
                }
                break;
            case 2010:
                ShootParticles(data, x, y, z, Particle.WhiteSmoke);
                break;
            case 2011:
            case 2012:
                SpawnParticleInBlock(x, y, z, data, Particle.HappyVillager);
                break;
            case 2013:
                SmashAttack(x, y, z, data);
                break;
            case 3000:
                AddAlwaysVisibleParticle(Particle.ExplosionEmitter, true, x + 0.5, y + 0.5, z + 0.5, 0.0, 0.0, 0.0);
                break;
            case 3002:
                if (data is >= 0 and < 3) {
                    SparksAlongAxis(data, x, y, z);
                }
                else {
                    SpawnParticlesOnBlockFaces(x, y, z, Particle.ElectricSpark, 3, 5);
                }
                break;
            case 3003:
                SpawnParticlesOnBlockFaces(x, y, z, Particle.WaxOn, 3, 5);
                break;
            case 3004:
                SpawnParticlesOnBlockFaces(x, y, z, Particle.WaxOff, 3, 5);
                break;
            case 3005:
                SpawnParticlesOnBlockFaces(x, y, z, Particle.Scrape, 3, 5);
                break;
            case 3006:
                SculkCharge(x, y, z, data);
                break;
            case 3007:
                // SculkShriekerBlock.TOP_Y is the top of its shape, half a block up.
                foreach (ShriekParticle shriek in Shrieks) {
                    AddParticle(shriek, x + 0.5, y + 0.5, z + 0.5, 0.0, 0.0, 0.0);
                }
                break;
            case 3009:
                SpawnParticlesOnBlockFaces(x, y, z, Particle.EggCrack, 3, 6);
                break;
            case 3011:
            case 3012:
            case 3021:
                TrialSpawnParticles(x, y, z, TrialFlame(data));
                break;
            case 3013:
                TrialDetectPlayerParticles(x, y, z, data, Particle.TrialSpawnerDetection);
                break;
            case 3014:
            case 3017:
                TrialEjectItemParticles(x, y, z);
                break;
            case 3015:
                VaultActivation(x, y, z, data == 0 ? Particle.SmallFlame : Particle.SoulFireFlame);
                break;
            case 3016:
                for (int i = 0; i < 20; i++) {
                    double px = x + Between(0.4, 0.6), py = y + Between(0.4, 0.6), pz = z + Between(0.4, 0.6);
                    AddParticle(data == 0 ? Particle.SmallFlame : Particle.SoulFireFlame, px, py, pz,
                        random.NextGaussian() * 0.02, random.NextGaussian() * 0.02, random.NextGaussian() * 0.02);
                }
                break;
            case 3018:
                for (int i = 0; i < 10; i++) {
                    double xd = random.NextGaussian() * 0.02, yd = random.NextGaussian() * 0.02, zd = random.NextGaussian() * 0.02;
                    AddParticle(Particle.Poof, x + random.NextDouble(), y + random.NextDouble(), z + random.NextDouble(), xd, yd, zd);
                }
                break;
            case 3019:
                TrialDetectPlayerParticles(x, y, z, data, Particle.TrialSpawnerDetectionOminous);
                break;
            case 3020:
                TrialDetectPlayerParticles(x, y, z, 0, Particle.TrialSpawnerDetectionOminous);
                for (int i = 0; i < 20; i++) {
                    double px = x + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    double py = y + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    double pz = z + 0.5 + (random.NextDouble() - 0.5) * 2.0;
                    double xd = random.NextGaussian() * 0.02, yd = random.NextGaussian() * 0.02, zd = random.NextGaussian() * 0.02;
                    AddParticle(Particle.TrialOmen, px, py, pz, xd, yd, zd);
                    AddParticle(Particle.SoulFireFlame, px, py, pz, xd, yd, zd);
                }
                break;
        }
    }

    /// <summary><c>Mth.nextDouble</c>.</summary>
    private double Between(double min, double max) => min >= max ? min : Random.NextDouble() * (max - min) + min;

    /// <summary><c>Mth.randomBetweenInclusive</c>, as <c>UniformInt.sample</c> draws.</summary>
    private int BetweenInclusive(int min, int max) => min + Random.NextInt(max - min + 1);

    /// <summary>The top of a block's shape, moved by its offset: <c>getShape(level, pos).max(Y)</c>, or null for an empty one.</summary>
    private static double? ShapeTop(IBlock block, int x, int y, int z) {
        Box[] shape = ShapeOf(block, x, y, z);
        return shape.Length == 0 ? null : shape.Max(b => b.MaxY);
    }

    /// <summary><c>LevelEventHandler.shootParticles</c>: ten thrown out of the face <c>Direction.from3DDataValue</c> names.</summary>
    private void ShootParticles(int data, int x, int y, int z, IParticle particle) {
        (int nx, int ny, int nz) = Directions[Math.Abs(data % 6)];
        for (int i = 0; i < 10; i++) {
            double pow = Random.NextDouble() * 0.2 + 0.01;
            double px = x + nx * 0.6 + 0.5 + nx * 0.01 + (Random.NextDouble() - 0.5) * nz * 0.5;
            double py = y + ny * 0.6 + 0.5 + ny * 0.01 + (Random.NextDouble() - 0.5) * ny * 0.5;
            double pz = z + nz * 0.6 + 0.5 + nz * 0.01 + (Random.NextDouble() - 0.5) * nx * 0.5;
            AddParticle(particle, px, py, pz,
                nx * pow + Random.NextGaussian() * 0.01, ny * pow + Random.NextGaussian() * 0.01, nz * pow + Random.NextGaussian() * 0.01);
        }
    }

    /// <summary><c>ComposterBlock.handleFill</c>: ten in the bin above its contents.</summary>
    private void ComposterFill(int x, int y, int z) {
        // VoxelShape.max(Y, 0.5, 0.5): the top of the shape in the column through the middle, which is the contents.
        double? floor = null;
        foreach (Box box in ShapeOf(BlockAt(x, y, z), x, y, z)) {
            if (box.MinX <= 0.5 && box.MaxX >= 0.5 && box.MinZ <= 0.5 && box.MaxZ >= 0.5 && (floor == null || box.MaxY > floor)) {
                floor = box.MaxY;
            }
        }
        if (floor is not { } top) {
            return;
        }
        double centerHeight = top + 0.03125;
        for (int i = 0; i < 10; i++) {
            double xa = Random.NextGaussian() * 0.02, ya = Random.NextGaussian() * 0.02, za = Random.NextGaussian() * 0.02;
            AddParticle(Particle.Composter, x + 0.1875 + 0.625 * Random.NextFloat(), y + centerHeight + Random.NextFloat() * (1.0 - centerHeight),
                z + 0.1875 + 0.625 * Random.NextFloat(), xa, ya, za);
        }
    }

    /// <summary>
    /// <c>PointedDripstoneBlock.spawnDripParticle</c> at a stalactite's tip, for what sits above the block it hangs
    /// from. The server only sends this for water or lava, so a dry stalactite, whose particle is the dimension's
    /// <c>DEFAULT_DRIPSTONE_PARTICLE</c>, makes nothing here.
    /// </summary>
    private void DripstoneDrip(int x, int y, int z) {
        IBlock tip = BlockAt(x, y, z);
        if (tip is not PointedDripstoneBlock { VerticalDirection: VerticalDirection.Down }) {
            return;
        }
        // findRootBlock: up the column of downward dripstone to the first block that is not dripstone.
        int rootY = int.MinValue;
        for (int i = 1; i < 11; i++) {
            int py = y + i;
            IBlock state = BlockAt(x, py, z);
            if (state is not PointedDripstoneBlock) {
                rootY = py;
                break;
            }
            if (py >= _level!.MinY + _level.SectionCount * 16 || state is not PointedDripstoneBlock { VerticalDirection: VerticalDirection.Down }) {
                return;
            }
        }
        if (rootY == int.MinValue) {
            return;
        }
        IBlock above = BlockAt(x, rootY + 1, z);
        // Mud drips water wherever water does not evaporate, the only place the server sends this for it.
        byte fluid = above.Identifier.Equals(Block.Mud.Identifier) ? FluidWater : FluidAt(x, rootY + 1, z).Fluid;
        IParticle? drip = fluid switch {
            FluidWater => Particle.DrippingDripstoneWater,
            FluidLava => Particle.DrippingDripstoneLava,
            _ => null
        };
        if (drip == null) {
            return;
        }
        Vec3<double> offset = tip.ShapeOffset(new Vec3<int>(x, y, z));
        // STALACTITE_DRIP_START_PIXEL is the bottom of the tip's shape, five pixels up.
        AddParticle(drip, x + 0.5 + offset.X, y + 5.0 / 16.0 - 0.0625, z + 0.5 + offset.Z, 0.0, 0.0, 0.0);
    }

    /// <summary><c>BoneMealItem.addGrowthParticles</c>.</summary>
    private void GrowthParticles(int x, int y, int z, int count) {
        IBlock block = BlockAt(x, y, z);
        BlockClass[] chain = BlockClasses.Of(block.Identifier);
        if (chain.Any(Bonemealable.Contains)) {
            if (chain.Any(NeighbourSpreaders.Contains)) {
                SpawnParticles(x, y + 1, z, count * 3, 3.0, 1.0, false, Particle.HappyVillager);
            }
            else {
                SpawnParticleInBlock(x, chain.Any(ParticlesBelow.Contains) ? y - 1 : y, z, count, Particle.HappyVillager);
            }
        }
        else if (block.Identifier.Equals(Block.Water.Identifier)) {
            SpawnParticles(x, y, z, count * 3, 3.0, 1.0, false, Particle.HappyVillager);
        }
    }

    /// <summary><c>ParticleUtils.spawnParticleInBlock</c>: spread through the block's height, or a whole block of air.</summary>
    private void SpawnParticleInBlock(int x, int y, int z, int count, IParticle particle) {
        IBlock block = BlockAt(x, y, z);
        if ((block.Air ? 1.0 : ShapeTop(block, x, y, z)) is { } height) {
            SpawnParticles(x, y, z, count, 0.5, height, true, particle);
        }
    }

    /// <summary><c>ParticleUtils.spawnParticles</c>: those not allowed to float need something other than air below them.</summary>
    private void SpawnParticles(int x, int y, int z, int count, double spreadWidth, double spreadHeight, bool allowFloating, IParticle particle) {
        double start = 0.5 - spreadWidth;
        for (int i = 0; i < count; i++) {
            double xd = Random.NextGaussian() * 0.02, yd = Random.NextGaussian() * 0.02, zd = Random.NextGaussian() * 0.02;
            double px = x + start + Random.NextDouble() * spreadWidth * 2.0;
            double py = y + Random.NextDouble() * spreadHeight;
            double pz = z + start + Random.NextDouble() * spreadWidth * 2.0;
            if (allowFloating || !IsAirAt(px, py - 1.0, pz)) {
                AddParticle(particle, px, py, pz, xd, yd, zd);
            }
        }
    }

    /// <summary><c>ParticleUtils.spawnParticlesOnBlockFaces</c>: a few on every face, sliding across it.</summary>
    private void SpawnParticlesOnBlockFaces(int x, int y, int z, IParticle particle, int min, int max) {
        for (int face = 0; face < Directions.Length; face++) {
            int count = BetweenInclusive(min, max);
            for (int i = 0; i < count; i++) {
                SpawnParticleOnFace(x, y, z, face, particle, Between(-0.5, 0.5), Between(-0.5, 0.5), Between(-0.5, 0.5), 0.55);
            }
        }
    }

    /// <summary><c>ParticleUtils.spawnParticleOnFace</c>: somewhere across the face, moving only along it.</summary>
    private void SpawnParticleOnFace(int x, int y, int z, int face, IParticle particle, double sx, double sy, double sz, double stepFactor) {
        (int stepX, int stepY, int stepZ) = Directions[face];
        double px = x + 0.5 + (stepX == 0 ? Between(-0.5, 0.5) : stepX * stepFactor);
        double py = y + 0.5 + (stepY == 0 ? Between(-0.5, 0.5) : stepY * stepFactor);
        double pz = z + 0.5 + (stepZ == 0 ? Between(-0.5, 0.5) : stepZ * stepFactor);
        AddParticle(particle, px, py, pz, stepX == 0 ? sx : 0.0, stepY == 0 ? sy : 0.0, stepZ == 0 ? sz : 0.0);
    }

    /// <summary>
    /// <c>ParticleUtils.spawnParticlesAlongAxis</c> for a lightning rod: ten to nineteen sparks along the rod's
    /// axis (<c>Direction.Axis.VALUES</c>, x then y then z), an eighth of a block out from it.
    /// </summary>
    private void SparksAlongAxis(int axis, int x, int y, int z) {
        bool stepX = axis == 0, stepY = axis == 1, stepZ = axis == 2;
        int count = BetweenInclusive(10, 19);
        for (int i = 0; i < count; i++) {
            double px = x + 0.5 + Between(-1.0, 1.0) * (stepX ? 0.5 : 0.125);
            double py = y + 0.5 + Between(-1.0, 1.0) * (stepY ? 0.5 : 0.125);
            double pz = z + 0.5 + Between(-1.0, 1.0) * (stepZ ? 0.5 : 0.125);
            double xd = stepX ? Between(-1.0, 1.0) : 0.0;
            double yd = stepY ? Between(-1.0, 1.0) : 0.0;
            double zd = stepZ ? Between(-1.0, 1.0) : 0.0;
            AddParticle(Particle.ElectricSpark, px, py, pz, xd, yd, zd);
        }
    }

    /// <summary>The potion splash of 2002 and 2007: glass from a splash potion, and a ring of the potion's colour.</summary>
    private void PotionSplash(int x, int y, int z, int rgb, SpellParticle type) {
        double cx = x + 0.5, cz = z + 0.5;
        for (int i = 0; i < 8; i++) {
            AddParticle(SplashPotionBreak, cx, y, cz, Random.NextGaussian() * 0.15, Random.NextDouble() * 0.2, Random.NextGaussian() * 0.15);
        }
        float red = (rgb >> 16 & 0xFF) / 255.0F, green = (rgb >> 8 & 0xFF) / 255.0F, blue = (rgb & 0xFF) / 255.0F;
        for (int i = 0; i < 100; i++) {
            double distance = Random.NextDouble() * 4.0;
            double angle = Random.NextDouble() * Math.PI * 2.0;
            double xd = Math.Cos(angle) * distance;
            double yd = 0.01 + Random.NextDouble() * 0.5;
            double zd = Math.Sin(angle) * distance;
            float brightness = 0.75F + Random.NextFloat() * 0.25F;
            // SpellParticleOption.create: ARGB.colorFromFloat, eight bits a channel.
            int colour = Channel(red * brightness) << 16 | Channel(green * brightness) << 8 | Channel(blue * brightness);
            AddParticle(type with { Rgb = colour, Power = (float)distance }, cx + xd * 0.1, y + 0.3, cz + zd * 0.1, xd, yd, zd);
        }
    }

    /// <summary><c>ARGB.as8BitChannel</c>.</summary>
    private static int Channel(float value) => (int)Math.Floor(value * 255.0F);

    /// <summary>The ender eye of 2003 shattering: its pieces, and portal particles drawn in from a ring five blocks out.</summary>
    private void EyeOfEnderBreak(int x, int y, int z) {
        double cx = x + 0.5, cz = z + 0.5;
        for (int i = 0; i < 8; i++) {
            AddParticle(EnderEyeBreak, cx, y, cz, Random.NextGaussian() * 0.15, Random.NextDouble() * 0.2, Random.NextGaussian() * 0.15);
        }
        for (double angle = 0.0; angle < Math.PI * 2; angle += Math.PI / 20) {
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            AddParticle(Particle.Portal, cx + cos * 5.0, y - 0.4, cz + sin * 5.0, cos * -5.0, 0.0, sin * -5.0);
            AddParticle(Particle.Portal, cx + cos * 5.0, y - 0.4, cz + sin * 5.0, cos * -7.0, 0.0, sin * -7.0);
        }
    }

    /// <summary><c>ParticleUtils.spawnSmashAttackParticles</c>: dust of the block landed on, a pillar and a ring.</summary>
    private void SmashAttack(int x, int y, int z, int count) {
        DustPillarParticle particle = Particle.DustPillar with { BlockState = StateAt(x, y, z) };
        double cx = x + 0.5, cy = y + 1.0, cz = z + 0.5;
        for (int i = 0; i < count / 3.0F; i++) {
            double px = cx + Random.NextGaussian() / 2.0, pz = cz + Random.NextGaussian() / 2.0;
            AddParticle(particle, px, cy, pz, Random.NextGaussian() * 0.2F, Random.NextGaussian() * 0.2F, Random.NextGaussian() * 0.2F);
        }
        for (int i = 0; i < count / 1.5F; i++) {
            double px = cx + 3.5 * Math.Cos(i) + Random.NextGaussian() / 2.0, pz = cz + 3.5 * Math.Sin(i) + Random.NextGaussian() / 2.0;
            AddParticle(particle, px, cy, pz, Random.NextGaussian() * 0.05F, Random.NextGaussian() * 0.05F, Random.NextGaussian() * 0.05F);
        }
    }

    /// <summary>
    /// The sculk charge of 3006. With a charge it creeps over the faces the data packs, or every face of a
    /// whole block; without one it pops in a burst, wider out of a full block.
    /// </summary>
    private void SculkCharge(int x, int y, int z, int data) {
        int count = data >> 6;
        if (count > 0) {
            int faces = data & 63;
            for (int face = 0; face < Directions.Length; face++) {
                if (faces != 0 && (faces & 1 << face) == 0) {
                    continue;
                }
                // A whole block flips the charge on its underside, a sculk vein the one on its top.
                bool flipped = faces == 0 ? face == 0 : face == 1;
                double factor = faces != 0 ? 0.35 : Directions[face].Y != 0 ? 0.65 : 0.57;
                int repetitions = BetweenInclusive(0, count);
                for (int i = 0; i < repetitions; i++) {
                    SpawnParticleOnFace(x, y, z, face, flipped ? SculkChargeFlipped : SculkChargeUpright,
                        Between(-0.005F, 0.005F), Between(-0.005F, 0.005F), Between(-0.005F, 0.005F), factor);
                }
            }
            return;
        }
        bool solid = IsFullBlock(CollisionOf(StateAt(x, y, z)));
        int particles = solid ? 40 : 20;
        float spread = solid ? 0.45F : 0.25F;
        for (int i = 0; i < particles; i++) {
            float xd = 2.0F * Random.NextFloat() - 1.0F, yd = 2.0F * Random.NextFloat() - 1.0F, zd = 2.0F * Random.NextFloat() - 1.0F;
            AddParticle(Particle.SculkChargePop, x + 0.5 + xd * spread, y + 0.5 + yd * spread, z + 0.5 + zd * spread, xd * 0.07F, yd * 0.07F, zd * 0.07F);
        }
    }

    /// <summary><c>isCollisionShapeFullBlock</c> on the split boxes, which never overlap.</summary>
    private static bool IsFullBlock(Box[] boxes) {
        double volume = 0.0;
        foreach (Box box in boxes) {
            if (box.MinX < 0.0 || box.MinY < 0.0 || box.MinZ < 0.0 || box.MaxX > 1.0 || box.MaxY > 1.0 || box.MaxZ > 1.0) {
                return false;
            }
            volume += (box.MaxX - box.MinX) * (box.MaxY - box.MinY) * (box.MaxZ - box.MinZ);
        }
        return volume > 1.0 - 1.0E-7;
    }

    /// <summary><c>TrialSpawner.FlameParticle.decode</c>: ominous is 1, and anything it does not know is the normal flame.</summary>
    private static IParticle TrialFlame(int data) => data == 1 ? Particle.SoulFireFlame : Particle.Flame;

    /// <summary><c>TrialSpawner.addSpawnParticles</c>: smoke and flame through a two block cube.</summary>
    private void TrialSpawnParticles(int x, int y, int z, IParticle flame) {
        for (int i = 0; i < 20; i++) {
            double px = x + 0.5 + (Random.NextDouble() - 0.5) * 2.0;
            double py = y + 0.5 + (Random.NextDouble() - 0.5) * 2.0;
            double pz = z + 0.5 + (Random.NextDouble() - 0.5) * 2.0;
            AddParticle(Particle.Smoke, px, py, pz, 0.0, 0.0, 0.0);
            AddParticle(flame, px, py, pz, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>TrialSpawner.addDetectPlayerParticles</c>: five more for each player detected, up to ten.</summary>
    private void TrialDetectPlayerParticles(int x, int y, int z, int players, IParticle type) {
        int count = 30 + Math.Min(players, 10) * 5;
        for (int i = 0; i < count; i++) {
            double spreadX = (2.0F * Random.NextFloat() - 1.0F) * 0.65;
            double spreadZ = (2.0F * Random.NextFloat() - 1.0F) * 0.65;
            AddParticle(type, x + 0.5 + spreadX, y + 0.1 + Random.NextFloat() * 0.8, z + 0.5 + spreadZ, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>TrialSpawner.addEjectItemParticles</c>, which a vault ejecting an item makes too.</summary>
    private void TrialEjectItemParticles(int x, int y, int z) {
        for (int i = 0; i < 20; i++) {
            double px = x + 0.4 + Random.NextDouble() * 0.2;
            double py = y + 0.4 + Random.NextDouble() * 0.2;
            double pz = z + 0.4 + Random.NextDouble() * 0.2;
            double xd = Random.NextGaussian() * 0.02, yd = Random.NextGaussian() * 0.02, zd = Random.NextGaussian() * 0.02;
            AddParticle(Particle.SmallFlame, px, py, pz, xd, yd, zd * 0.25);
            AddParticle(Particle.Smoke, px, py, pz, xd, yd, zd);
        }
    }

    /// <summary>
    /// <c>VaultBlockEntity.Client.emitActivationParticles</c>, only where a vault's block entity is: the
    /// connection to each player in range, then smoke and flame through the cage.
    /// </summary>
    private void VaultActivation(int x, int y, int z, IParticle flame) {
        if (_level!.GetBlockEntity(x, y, z) is not VaultBlockEntity vault) {
            return;
        }
        EmitVaultConnections(vault);
        for (int i = 0; i < 20; i++) {
            double px = x + Between(0.1, 0.9), py = y + Between(0.25, 0.75), pz = z + Between(0.1, 0.9);
            AddParticle(Particle.Smoke, px, py, pz, 0.0, 0.0, 0.0);
            AddParticle(flame, px, py, pz, 0.0, 0.0, 0.0);
        }
    }

    /// <summary>
    /// <c>VaultBlockEntity.Client.emitConnectionParticlesForNearbyPlayers</c>: two to five particles from the
    /// keyhole toward the middle of each connected player within the vault's range.
    /// </summary>
    public void EmitVaultConnections(VaultBlockEntity vault) {
        if (!Ready() || vault.ConnectedPlayers.Count == 0 || vault.State is not VaultBlock block) {
            return;
        }
        (int stepX, int stepZ) = DirectionUtil.Step(block.Facing);
        double kx = vault.X + 0.5 + stepX * 0.5, ky = vault.Y + 1.75, kz = vault.Z + 0.5 + stepZ * 0.5;
        double rangeSqr = vault.ConnectedParticlesRange * vault.ConnectedParticlesRange;
        foreach (ClientEntity entity in _client.Entities.Values) {
            if (!entity.Type.Identifier.Equals(Minecraft.Data.Generated.EntityType.Player.Identifier) || !vault.ConnectedPlayers.Contains(entity.Uuid)) {
                continue;
            }
            // Player.blockPosition().distSqr(vaultPos), between the two blocks' corners.
            double dx = Math.Floor(entity.Position.X) - vault.X, dy = Math.Floor(entity.Position.Y) - vault.Y, dz = Math.Floor(entity.Position.Z) - vault.Z;
            if (dx * dx + dy * dy + dz * dz > rangeSqr) {
                continue;
            }
            double tx = entity.Position.X - kx;
            double ty = entity.Position.Y + (entity.BoundingBox.MaxY - entity.BoundingBox.MinY) / 2.0 - ky;
            double tz = entity.Position.Z - kz;
            int count = BetweenInclusive(2, 5);
            for (int i = 0; i < count; i++) {
                // Vec3.offsetRandom by one block.
                AddParticle(Particle.VaultConnection, kx, ky, kz,
                    tx + (Random.NextFloat() - 0.5F), ty + (Random.NextFloat() - 0.5F), tz + (Random.NextFloat() - 0.5F));
            }
        }
    }
}
