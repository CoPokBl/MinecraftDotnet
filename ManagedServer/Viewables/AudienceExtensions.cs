using Minecraft.Data.Particles;
using Minecraft.Data.Sounds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ManagedServer.Viewables;

public static class AudienceExtensions {
    
    public static void SendPackets(this IAudience audience, params MinecraftPacket[] packets) {
        foreach (MinecraftPacket packet in packets) {
            audience.SendPacket(packet);
        }
    }
    
    public static void SendMessage(this IAudience audience, TextComponent msg) {
        audience.SendPacket(new ClientBoundSystemChatMessagePacket {
            ActionBar = false,
            Content = msg
        });
    }
    
    public static void SendActionBar(this IAudience audience, TextComponent msg) {
        audience.SendPacket(new ClientBoundSystemChatMessagePacket {
            ActionBar = true,
            Content = msg
        });
    }
    
    public static void SendTitle(this IAudience audience, TextComponent text, TextComponent? subtitle = null, int fadeIn = 10, int stay = 40, int fadeOut = 10) {
        audience.SendPackets(
            new ClientBoundSetTitleTextPacket {
                Text = text
            },
            new ClientBoundSetSubtitleTextPacket {
                Text = subtitle ?? TextComponent.Empty()
            },
            new ClientBoundSetTitleAnimationTimesPacket {
                FadeIn = fadeIn,
                FadeOut = fadeOut,
                Stay = stay
            });
    }
    
    public static void ClearTitles(this IAudience audience) {
        audience.SendPacket(new ClientBoundClearTitlesPacket {
            Reset = true
        });
    }

    public static void ShowParticle(this IAudience audience, IParticle particle, Vec3 position, int count = 1, 
        float maxSpeed = 1f, bool longDistance = false, bool alwaysVisible = false, FVec3 offset = default) {
        audience.SendPacket(new ClientBoundParticlePacket {
            Particle = particle,
            Position = position,
            ParticleCount = count,
            MaxSpeed = maxSpeed,
            LongDistance = longDistance,
            AlwaysVisible = alwaysVisible,
            Offset = offset
        });
    }

    public static void PlaySound(this IAudience audience, ISoundType type, Vec3 pos, SoundCategory category = SoundCategory.Master, float volume = 1f) {
        audience.SendPacket(new ClientBoundSoundEffectPacket {
            Category = category,
            Type = type,
            Pos = pos,
            Volume = volume,
            Seed = Random.Shared.NextInt64(),
            Pitch = 1f
        });
    }
}
