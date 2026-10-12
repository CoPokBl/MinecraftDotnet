using ClientLib;
using ClientLib.World;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Sound;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary>
/// The rain sound out of <c>ClientLevel.tickWeatherEffects</c>: it plays at the last column the rain particles
/// landed on, so the particle loop's draws are all taken even though this client spawns no rain particles.
/// </summary>
public sealed class WeatherEffectSounds(ClientSounds sounds, MinecraftClient client, Func<(double X, double Y, double Z)> camera) {
    // Options.weatherRadius and Options.particles at their defaults: ten, and ParticleStatus.ALL.
    private const int WeatherRadius = 10;

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
        int weatherDiameter = 2 * WeatherRadius + 1;
        int weatherArea = weatherDiameter * weatherDiameter;
        int rainParticles = (int)(0.225F * weatherArea * rainLevel * rainLevel);

        for (int ii = 0; ii < rainParticles; ii++) {
            int x = random.NextInt(weatherDiameter) - WeatherRadius;
            int z = random.NextInt(weatherDiameter) - WeatherRadius;
            int heightmapX = cameraX + x, heightmapZ = cameraZ + z;
            int heightmapY = level.GetHeight(HeightmapType.MotionBlocking, heightmapX, heightmapZ);
            if (heightmapY > level.MinY && heightmapY <= cameraY + 10 && heightmapY >= cameraY - 10
                && level.GetPrecipitationAt(heightmapX, heightmapY, heightmapZ) == BiomeClimate.Precipitation.Rain) {
                found = true;
                rainX = heightmapX;
                rainY = heightmapY - 1;
                rainZ = heightmapZ;
                // The particle's offset in the block.
                random.NextDouble();
                random.NextDouble();
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
}
