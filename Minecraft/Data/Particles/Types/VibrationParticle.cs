using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record VibrationParticle(Identifier Identifier, int ProtocolId, VibrationParticle.IPositionSource? PositionSource = null, int Ticks = 0) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .Write(PositionSource ?? new BlockPositionSource(BlockPosition.Zero))
            .WriteVarInt(Ticks);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry _) {
        return this with {
            PositionSource = IPositionSource.Read(reader),
            Ticks = reader.ReadVarInt()
        };
    }
    
    public interface IPositionSource : IWritable {
        public int Type { get; }

        public static IPositionSource Read(DataReader r) {
            int type = r.ReadVarInt();
            return type switch {
                0 => new BlockPositionSource(r.ReadPosition()),
                1 => new EntityPositionSource(r.ReadVarInt(), r.ReadFloat()),
                _ => throw new InvalidOperationException($"Unknown position source type: {type}")
            };
        }
    }

    public record BlockPositionSource(BlockPosition Position) : IPositionSource {
        public int Type => 0;

        public void Write(DataWriter writer) {
            writer
                .WriteVarInt(Type)
                .WritePosition(Position);
        }
    }
    
    public record EntityPositionSource(int EntityId, float EntityEyeHeight) : IPositionSource {
        public int Type => 1;

        public void Write(DataWriter writer) {
            writer
                .WriteVarInt(Type)
                .WriteVarInt(EntityId)
                .WriteFloat(EntityEyeHeight);
        }
    }
}