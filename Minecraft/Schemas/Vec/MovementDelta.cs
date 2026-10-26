namespace Minecraft.Schemas.Vec;

/// <summary>
/// <c>VecDelta</c>, how a relative move packet spells a move: in 1/4096ths of a block, a short per
/// axis, either as one jump or as a path of steps each landing some ticks after the packet.
/// </summary>
/// <remarks>
/// Each step is relative to the step before it, not to where the entity started.
/// </remarks>
public static class MovementDelta {
    /// <param name="Ticks">How many ticks after the packet the entity should be at the end of this step.</param>
    public sealed record Step(int Ticks, Vec3<float> Delta);

    /// <summary>
    /// <c>packProperties</c>: the on ground flag in the low bit and the number of steps above it. A
    /// count of zero is what makes the delta a single jump.
    /// </summary>
    public static DataWriter WriteProperties(DataWriter writer, bool onGround, IReadOnlyList<Step>? steps) {
        return writer.WriteVarInt((onGround ? 1 : 0) | (steps?.Count ?? 0) << 1);
    }

    public static DataWriter WriteDelta(DataWriter writer, Vec3<float> delta, IReadOnlyList<Step>? steps) {
        if (steps is not { Count: > 0 }) {
            return WriteShorts(writer, delta);
        }

        foreach (Step step in steps) {
            WriteShorts(writer.WriteVarInt(step.Ticks), step.Delta);
        }

        return writer;
    }

    /// <summary>
    /// <c>VecDelta.read</c>. The delta handed back for a path is where the last step ends, which is
    /// what a reader that does not follow the steps needs.
    /// </summary>
    public static (Vec3<float> Delta, Step[]? Steps) Read(DataReader reader, int properties) {
        int count = properties >>> 1;
        if (count <= 0) {
            return (ReadShorts(reader), null);
        }

        Step[] steps = new Step[count];
        float x = 0, y = 0, z = 0;
        for (int i = 0; i < count; i++) {
            int ticks = reader.ReadVarInt();
            Vec3<float> delta = ReadShorts(reader);
            steps[i] = new Step(ticks, delta);
            x += delta.X;
            y += delta.Y;
            z += delta.Z;
        }

        return (new Vec3<float>(x, y, z), steps);
    }

    public static bool OnGround(int properties) => (properties & 1) != 0;

    private static DataWriter WriteShorts(DataWriter writer, Vec3<float> delta) {
        return writer.WriteVec3(new Vec3<short>((short)(delta.X * 4096), (short)(delta.Y * 4096), (short)(delta.Z * 4096)));
    }

    private static Vec3<float> ReadShorts(DataReader reader) {
        return new Vec3<float>((float)reader.ReadShort() / 4096, (float)reader.ReadShort() / 4096, (float)reader.ReadShort() / 4096);
    }
}
