using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;
using Particle = Minecraft.Data.Generated.Particle;

namespace GraphicalClient.Assets;

/// <summary>
/// The built in art's particle sprites: simple shapes drawn here, one list of frames per particle type. White
/// shapes are for the particles that are tinted from code; the rest carry their own colour. A frame list runs
/// in the order the particle ages through it, which for puffs is largest first.
/// </summary>
public static class DevArtParticles {
    private enum Shape : byte { Puff, Dot, Star, Cross, Glyph, DropHang, DropFall, DropLand, Bubble, BubblePop, Flame, Heart, Note, Leaf, Burst, Ring, Sweep, Swirl, Diamond, Splash, Square }

    private readonly record struct Art(Shape Shape, int Frames, uint Rgb, int Size = 8);

    private const uint White = 0xFFFFFF;

    private static readonly Dictionary<Identifier, Art> Table = new() {
        [Particle.AngryVillager.Identifier] = new(Shape.Cross, 1, 0x3A3A3A),
        [Particle.Ash.Identifier] = new(Shape.Dot, 1, White),
        [Particle.Bubble.Identifier] = new(Shape.Bubble, 1, 0xDDEEFF),
        [Particle.BubbleColumnUp.Identifier] = new(Shape.Bubble, 1, 0xDDEEFF),
        [Particle.BubblePop.Identifier] = new(Shape.BubblePop, 5, 0xDDEEFF),
        [Particle.CampfireCosySmoke.Identifier] = new(Shape.Puff, 12, 0xD8D8D8, 16),
        [Particle.CampfireSignalSmoke.Identifier] = new(Shape.Puff, 12, 0xD8D8D8, 16),
        [Particle.CherryLeaves.Identifier] = new(Shape.Leaf, 12, 0xF4B6D2),
        [Particle.Cloud.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Composter.Identifier] = new(Shape.Diamond, 1, 0x7CC24A),
        [Particle.CopperFireFlame.Identifier] = new(Shape.Flame, 1, 0x4FD8A0),
        [Particle.CrimsonSpore.Identifier] = new(Shape.Dot, 1, White),
        [Particle.Crit.Identifier] = new(Shape.Star, 1, White),
        [Particle.CurrentDown.Identifier] = new(Shape.Bubble, 1, 0xDDEEFF),
        [Particle.DamageIndicator.Identifier] = new(Shape.Heart, 1, 0x5A1010),
        [Particle.Dolphin.Identifier] = new(Shape.Dot, 1, White),
        [Particle.DragonBreath.Identifier] = new(Shape.Puff, 3, White),
        [Particle.Dust.Identifier] = new(Shape.Puff, 8, White),
        [Particle.DustColorTransition.Identifier] = new(Shape.Puff, 8, White),
        [Particle.DustPlume.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Effect.Identifier] = new(Shape.Swirl, 8, White),
        [Particle.EggCrack.Identifier] = new(Shape.Diamond, 1, 0xF2EBD0),
        [Particle.ElectricSpark.Identifier] = new(Shape.Star, 1, White),
        [Particle.EnchantedHit.Identifier] = new(Shape.Star, 1, 0x7FE7FF),
        [Particle.Enchant.Identifier] = new(Shape.Glyph, 26, White),
        [Particle.EndRod.Identifier] = new(Shape.Star, 8, White),
        [Particle.EntityEffect.Identifier] = new(Shape.Swirl, 8, White),
        [Particle.Explosion.Identifier] = new(Shape.Burst, 16, 0xE8E2D6, 16),
        [Particle.FallingDust.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Firefly.Identifier] = new(Shape.Dot, 1, 0xE6FF7A),
        [Particle.Firework.Identifier] = new(Shape.Star, 8, White),
        [Particle.Fishing.Identifier] = new(Shape.Splash, 4, 0xC8DCFF),
        [Particle.Flame.Identifier] = new(Shape.Flame, 1, 0xFFA020),
        [Particle.Flash.Identifier] = new(Shape.Puff, 1, White, 16),
        [Particle.GeyserBase.Identifier] = new(Shape.Puff, 8, White),
        [Particle.GeyserPlume.Identifier] = new(Shape.Puff, 8, White),
        [Particle.GeyserPoof.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Glow.Identifier] = new(Shape.Dot, 1, White),
        [Particle.GlowSquidInk.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Gust.Identifier] = new(Shape.Swirl, 12, 0xF0F6FF, 16),
        [Particle.HappyVillager.Identifier] = new(Shape.Diamond, 1, 0x58D858),
        [Particle.Heart.Identifier] = new(Shape.Heart, 1, 0xE0303A),
        [Particle.Infested.Identifier] = new(Shape.Square, 1, 0x8A8A8A),
        [Particle.InstantEffect.Identifier] = new(Shape.Star, 8, White),
        [Particle.LargeSmoke.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Lava.Identifier] = new(Shape.Dot, 1, 0xFF7A10),
        [Particle.Mycelium.Identifier] = new(Shape.Dot, 1, White),
        [Particle.Nautilus.Identifier] = new(Shape.Glyph, 1, 0x7FD0E0),
        [Particle.Note.Identifier] = new(Shape.Note, 1, White),
        [Particle.NoxiousGas.Identifier] = new(Shape.Puff, 8, 0xC8D860),
        [Particle.OminousSpawning.Identifier] = new(Shape.Dot, 1, White),
        [Particle.PaleOakLeaves.Identifier] = new(Shape.Leaf, 12, 0xA8B4A0),
        [Particle.PauseMobGrowth.Identifier] = new(Shape.Diamond, 1, 0xB0B0FF),
        [Particle.Poof.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Portal.Identifier] = new(Shape.Puff, 8, White),
        [Particle.RaidOmen.Identifier] = new(Shape.Square, 1, 0x50A050),
        [Particle.Rain.Identifier] = new(Shape.Splash, 4, 0xB8D0FF),
        [Particle.ResetMobGrowth.Identifier] = new(Shape.Diamond, 1, 0xFFB0B0),
        [Particle.ReversePortal.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Scrape.Identifier] = new(Shape.Dot, 1, White),
        [Particle.SculkCharge.Identifier] = new(Shape.Swirl, 7, 0x2FD3E8),
        [Particle.SculkChargePop.Identifier] = new(Shape.BubblePop, 4, 0x2FD3E8),
        [Particle.SculkSoul.Identifier] = new(Shape.Flame, 11, 0x40E0F0),
        [Particle.Shriek.Identifier] = new(Shape.Ring, 1, 0x2FD3E8, 16),
        [Particle.SmallFlame.Identifier] = new(Shape.Flame, 1, 0xFFA020),
        [Particle.SmallGust.Identifier] = new(Shape.Swirl, 7, 0xF0F6FF),
        [Particle.Smoke.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Sneeze.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Snowflake.Identifier] = new(Shape.Star, 8, White),
        [Particle.SonicBoom.Identifier] = new(Shape.Ring, 16, 0x56E3F0, 16),
        [Particle.Soul.Identifier] = new(Shape.Flame, 11, 0x8FE6F0),
        [Particle.SoulFireFlame.Identifier] = new(Shape.Flame, 1, 0x40C8F0),
        [Particle.Spit.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Splash.Identifier] = new(Shape.Splash, 4, 0xB8D0FF),
        [Particle.SporeBlossomAir.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.SquidInk.Identifier] = new(Shape.Puff, 8, White),
        [Particle.SulfurBubbles.Identifier] = new(Shape.Bubble, 1, White),
        [Particle.SulfurCubeGoo.Identifier] = new(Shape.Square, 1, 0xD8C840),
        [Particle.SweepAttack.Identifier] = new(Shape.Sweep, 8, 0xF0F0F0, 16),
        [Particle.TintedLeaves.Identifier] = new(Shape.Leaf, 12, White),
        [Particle.TotemOfUndying.Identifier] = new(Shape.Star, 8, White),
        [Particle.Trail.Identifier] = new(Shape.Dot, 1, White),
        [Particle.TrialOmen.Identifier] = new(Shape.Square, 1, 0x40B0C8),
        [Particle.TrialSpawnerDetection.Identifier] = new(Shape.Flame, 5, 0xFFB040),
        [Particle.TrialSpawnerDetectionOminous.Identifier] = new(Shape.Flame, 5, 0x60A0FF),
        [Particle.Underwater.Identifier] = new(Shape.Dot, 1, White),
        [Particle.VaultConnection.Identifier] = new(Shape.Diamond, 1, 0xFFE08A),
        [Particle.Vibration.Identifier] = new(Shape.Diamond, 1, 0x2FD3E8),
        [Particle.WarpedSpore.Identifier] = new(Shape.Dot, 1, White),
        [Particle.WaxOff.Identifier] = new(Shape.Dot, 1, White),
        [Particle.WaxOn.Identifier] = new(Shape.Dot, 1, White),
        [Particle.WhiteAsh.Identifier] = new(Shape.Dot, 1, White),
        [Particle.WhiteSmoke.Identifier] = new(Shape.Puff, 8, White),
        [Particle.Witch.Identifier] = new(Shape.Star, 8, White),
        [Particle.DrippingLava.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.DrippingWater.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.DrippingHoney.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.DrippingObsidianTear.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.DrippingDripstoneLava.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.DrippingDripstoneWater.Identifier] = new(Shape.DropHang, 1, White),
        [Particle.FallingLava.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingWater.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingHoney.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingNectar.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingObsidianTear.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingSporeBlossom.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingDripstoneLava.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.FallingDripstoneWater.Identifier] = new(Shape.DropFall, 1, White),
        [Particle.LandingLava.Identifier] = new(Shape.DropLand, 1, White),
        [Particle.LandingHoney.Identifier] = new(Shape.DropLand, 1, White),
        [Particle.LandingObsidianTear.Identifier] = new(Shape.DropLand, 1, White)
    };

    /// <summary>The frames for a particle type; empty for a type that draws no sprite of its own.</summary>
    public static TextureImage[] Frames(Identifier type) {
        if (!Table.TryGetValue(type, out Art art)) {
            return [];
        }
        TextureImage[] frames = new TextureImage[art.Frames];
        for (int i = 0; i < art.Frames; i++) {
            float t = art.Frames == 1 ? 0.0F : i / (float)(art.Frames - 1);
            frames[i] = Draw(art, i, t, DevArt.Hash(type.ToString()));
        }
        return frames;
    }

    private static TextureImage Draw(Art art, int frame, float t, int seed) {
        int size = art.Size;
        byte[] rgba = new byte[size * size * 4];
        for (int py = 0; py < size; py++) {
            for (int px = 0; px < size; px++) {
                // -1 to 1 across the sprite, y up.
                float x = (px + 0.5F) / size * 2.0F - 1.0F, y = 1.0F - (py + 0.5F) / size * 2.0F;
                float coverage = Coverage(art.Shape, x, y, frame, t, seed, px, py, size);
                if (coverage <= 0.0F) {
                    continue;
                }
                float shade = 0.85F + 0.15F * DevArt.Noise(seed + frame, px, py);
                if (art.Shape is Shape.Flame) {
                    // Hotter toward the base.
                    shade = 0.75F + 0.5F * Math.Clamp(0.5F - y * 0.5F, 0.0F, 1.0F);
                }
                uint colour = DevArt.Shade(art.Rgb, shade);
                DevArt.Put(rgba, py * size + px, (uint)(Math.Clamp(coverage, 0.0F, 1.0F) * 255.0F) << 24 | colour & 0xFFFFFF);
            }
        }
        return new TextureImage(size, size, rgba);
    }

    /// <summary>1 where the shape covers a point, 0 elsewhere.</summary>
    private static float Coverage(Shape shape, float x, float y, int frame, float t, int seed, int px, int py, int size) {
        float r = MathF.Sqrt(x * x + y * y);
        switch (shape) {
            case Shape.Puff: {
                float radius = 1.0F - t * 0.7F;
                float edge = radius * (0.85F + 0.15F * DevArt.Noise(seed, px, py));
                return r <= edge ? 1.0F : 0.0F;
            }
            case Shape.Dot:
                return r <= 0.55F ? 1.0F : 0.0F;
            case Shape.Star: {
                float scale = 1.0F - t * 0.6F;
                float ax = MathF.Abs(x) / scale, ay = MathF.Abs(y) / scale;
                return ax * ay < 0.04F && ax + ay < 1.0F || r < 0.3F * scale ? 1.0F : 0.0F;
            }
            case Shape.Cross:
                return MathF.Abs(MathF.Abs(x) - MathF.Abs(y)) < 0.3F && r < 0.95F ? 1.0F : 0.0F;
            case Shape.Glyph: {
                // A 3 by 4 grid of strokes picked by the frame, inside a margin.
                int gx = (int)((x + 1.0F) * 2.0F), gy = (int)((1.0F - y) * 2.0F);
                if (px == 0 || py == 0 || px == size - 1 || py == size - 1) {
                    return 0.0F;
                }
                return DevArt.Noise(seed + frame * 31, gx, gy) > 0.45F ? 1.0F : 0.0F;
            }
            case Shape.DropHang:
                return x * x + (y - 0.3F) * (y - 0.3F) * 4.0F < 0.25F || MathF.Abs(x) < 0.15F && y > 0.3F ? 1.0F : 0.0F;
            case Shape.DropFall:
                return x * x * 4.0F + y * y * 2.0F < 1.0F ? 1.0F : 0.0F;
            case Shape.DropLand:
                return MathF.Abs(y + 0.6F) < 0.25F && MathF.Abs(x) < 0.9F ? 1.0F : 0.0F;
            case Shape.Bubble:
                return r is > 0.55F and < 0.9F || (x + 0.3F) * (x + 0.3F) + (y - 0.3F) * (y - 0.3F) < 0.03F ? 1.0F : 0.0F;
            case Shape.BubblePop: {
                float radius = 0.4F + t * 0.55F;
                bool gap = DevArt.Noise(seed + frame, px, py) < t * 0.6F;
                return MathF.Abs(r - radius) < 0.18F && !gap ? 1.0F : 0.0F;
            }
            case Shape.Flame: {
                // A teardrop pointing up, swaying a little by frame.
                float sway = MathF.Sin(frame * 1.7F) * 0.15F * y;
                float fx = x - sway;
                float width = 0.75F * (1.0F - (y + 1.0F) * 0.45F);
                return y < 0.9F && y > -0.9F && MathF.Abs(fx) < width * MathF.Sqrt(Math.Max(0.0F, 1.0F - (y + 0.3F) * (y + 0.3F) * 0.6F)) ? 1.0F : 0.0F;
            }
            case Shape.Heart: {
                float hx = MathF.Abs(x);
                return (hx - 0.4F) * (hx - 0.4F) + (y - 0.3F) * (y - 0.3F) < 0.2F || y < 0.3F && hx < 0.85F * (y + 0.9F) / 1.2F ? 1.0F : 0.0F;
            }
            case Shape.Note:
                return (x + 0.25F) * (x + 0.25F) + (y + 0.5F) * (y + 0.5F) < 0.12F || MathF.Abs(x - 0.05F) < 0.12F && y > -0.5F && y < 0.85F
                    || y > 0.55F && y < 0.85F && x > 0.05F && x < 0.6F ? 1.0F : 0.0F;
            case Shape.Leaf: {
                float angle = t * MathF.Tau;
                float lx = x * MathF.Cos(angle) - y * MathF.Sin(angle), ly = x * MathF.Sin(angle) + y * MathF.Cos(angle);
                return lx * lx * 3.0F + ly * ly < 0.7F ? 1.0F : 0.0F;
            }
            case Shape.Burst: {
                float radius = 0.35F + t * 0.6F;
                float hole = t * 0.7F;
                float noise = DevArt.Noise(seed + frame, px / 2, py / 2);
                return r < radius * (0.8F + 0.3F * noise) && noise > hole * 0.8F ? 1.0F : 0.0F;
            }
            case Shape.Ring: {
                float radius = 0.35F + t * 0.55F;
                return MathF.Abs(r - radius) < 0.12F ? 1.0F : 0.0F;
            }
            case Shape.Sweep: {
                float angle = MathF.Atan2(y, x);
                float start = -MathF.PI * 0.2F + t * MathF.PI * 0.6F;
                return r is > 0.55F and < 0.85F && angle > start && angle < start + MathF.PI * 0.6F ? 1.0F : 0.0F;
            }
            case Shape.Swirl: {
                float angle = MathF.Atan2(y, x) + t * MathF.Tau;
                float arm = (angle / MathF.Tau % 1.0F + 1.0F) % 1.0F;
                return r < 0.95F && MathF.Abs(r - arm * 0.9F) < 0.14F ? 1.0F : 0.0F;
            }
            case Shape.Diamond:
                return MathF.Abs(x) + MathF.Abs(y) < 0.8F && (MathF.Abs(x) < 0.15F || MathF.Abs(y) < 0.15F || MathF.Abs(x) + MathF.Abs(y) < 0.4F) ? 1.0F : 0.0F;
            case Shape.Splash: {
                float spread = 0.3F + t * 0.5F;
                return (x - spread) * (x - spread) + (y + 0.2F - t * 0.4F) * (y + 0.2F - t * 0.4F) < 0.06F
                    || (x + spread) * (x + spread) + (y + 0.2F - t * 0.4F) * (y + 0.2F - t * 0.4F) < 0.06F
                    || x * x + (y - 0.3F + t * 0.2F) * (y - 0.3F + t * 0.2F) < 0.05F ? 1.0F : 0.0F;
            }
            case Shape.Square:
                return MathF.Abs(x) < 0.6F && MathF.Abs(y) < 0.6F ? 1.0F : 0.0F;
        }
        return 0.0F;
    }
}
