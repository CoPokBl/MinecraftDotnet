using ClientLib;
using ClientLib.Physics;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Sound;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary>
/// <c>ClientLevel.tickWeatherEffects</c>: the rain's splashes, or smoke where it falls on something hot, on the
/// columns round the camera, and the rain sound at the last of them. The sound's draws follow the splashes', so
/// the Particles option changes them as it does in vanilla: Decreased halves the splashes and Minimal stops at the
/// first column.
/// </summary>
/// <param name="weatherRadius"><c>Options.weatherRadius</c>.</param>
public sealed class WeatherEffectSounds(ClientSounds sounds, MinecraftClient client, Func<(double X, double Y, double Z)> camera, Func<int> weatherRadius) {
    private ClientLevel? _level;
    private int _rainSoundTime;

    public void Tick() {
        ClientLevel? level = client.Level;
        if (level != _level) {
            _level = level;
            _rainSoundTime = 0;
        }
        if (level == null) {
            return;
        }
        float rainLevel = level.RainLevel;
        if (rainLevel <= 0.0F) {
            return;
        }
        // RandomSource.createThreadLocalInstance(seed) is a SingleThreadedRandomSource: the same generator as LegacyRandomSource.
        LegacyRandomSource random = new(level.GameTime * 312987231L);
        (double camX, double camY, double camZ) = camera();
        int cameraX = Mth.Floor(camX), cameraY = Mth.Floor(camY), cameraZ = Mth.Floor(camZ);
        bool found = false;
        int rainX = 0, rainY = 0, rainZ = 0;
        int radius = weatherRadius();
        int weatherDiameter = 2 * radius + 1;
        int weatherArea = weatherDiameter * weatherDiameter;
        ParticleStatus status = client.Options.Particles;
        int rainParticles = (int)(0.225F * weatherArea * rainLevel * rainLevel) / (status == ParticleStatus.Decreased ? 2 : 1);

        for (int ii = 0; ii < rainParticles; ii++) {
            int x = random.NextInt(weatherDiameter) - radius;
            int z = random.NextInt(weatherDiameter) - radius;
            int heightmapX = cameraX + x, heightmapZ = cameraZ + z;
            int heightmapY = level.GetHeight(HeightmapType.MotionBlocking, heightmapX, heightmapZ);
            if (heightmapY > level.MinY && heightmapY <= cameraY + 10 && heightmapY >= cameraY - 10
                && level.GetPrecipitationAt(heightmapX, heightmapY, heightmapZ) == BiomeClimate.Precipitation.Rain) {
                found = true;
                rainX = heightmapX;
                rainY = heightmapY - 1;
                rainZ = heightmapZ;
                if (status == ParticleStatus.Minimal) {
                    break;
                }
                double blockX = random.NextDouble();
                double blockZ = random.NextDouble();
                Splash(level, rainX, rainY, rainZ, blockX, blockZ);
            }
        }

        if (found && random.NextInt(3) < _rainSoundTime++) {
            _rainSoundTime = 0;
            if (rainY > cameraY + 1 && level.GetHeight(HeightmapType.MotionBlocking, cameraX, cameraZ) > Mth.Floor((float)cameraY)) {
                sounds.Play(SoundType.RainAbove, SoundCategory.Weather, 0.1F, 0.5F, rainX + 0.5, rainY + 0.5, rainZ + 0.5);
            }
            else {
                sounds.Play(SoundType.Rain, SoundCategory.Weather, 0.2F, 1.0F, rainX + 0.5, rainY + 0.5, rainZ + 0.5);
            }
        }
    }

    /// <summary>A rain splash on top of what is in the block, or smoke off lava, magma or a lit campfire.</summary>
    private void Splash(ClientLevel level, int x, int y, int z, double blockX, double blockZ) {
        ushort state = level.GetState(x, y, z);
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        double blockTop = 0.0;
        foreach (Box box in BlockPhysicsData.Get(level.Registry, state).Collision) {
            if (blockX >= box.MinX && blockX <= box.MaxX && blockZ >= box.MinZ && blockZ <= box.MaxZ) {
                blockTop = Math.Max(blockTop, box.MaxY);
            }
        }
        MovementBlocks.Entry fluid = MovementBlocks.Get(level.Registry, state);
        // FluidState.getHeight: a full block under the same fluid, else the fluid's own height.
        double fluidTop = fluid.Fluid == FluidKind.Empty ? 0.0
            : MovementBlocks.Get(level.Registry, level.GetState(x, y + 1, z)).Fluid == fluid.Fluid ? 1.0
            : fluid.FluidAmount / 9.0;
        bool hot = fluid.Fluid == FluidKind.Lava || block.Identifier == Block.MagmaBlock.Identifier
            || block is CampfireBlock { Lit: true } or SoulCampfireBlock { Lit: true };
        client.Particles.AddParticle(hot ? Particle.Smoke : Particle.Rain, x + blockX, y + Math.Max(blockTop, fluidTop), z + blockZ, 0.0, 0.0, 0.0);
    }
}
