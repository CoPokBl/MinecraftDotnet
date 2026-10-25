using System.Diagnostics;
using ClientLib;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Gui;

/// <summary>The F3 screen: where you are, what you look at, and what the client is costing.</summary>
public sealed class DebugOverlay {
    public bool Visible { get; set; }

    // Reading the working set goes through /proc, which costs more than the rest of the frame's CPU work.
    private long _workingSet;
    private long _workingSetRead;

    /// <summary><c>ParticleEngine.countParticles</c>: each group's shorthand and size, then the total.</summary>
    private static string ParticleCounts(MinecraftClient client) {
        (int quads, int noRender, int elderGuardians) = client.Particles.Counts;
        return $"P: SQ {quads} NR {noRender} EG {elderGuardians} T {quads + noRender + elderGuardians}";
    }

    public void Render(GuiContext context, DebugStats stats) {
        if (!Visible) {
            return;
        }
        MinecraftClient client = context.Client;
        LocalPlayer? player = client.Player;
        ClientLevel? level = client.Level;
        List<string> left = [
            $"mcdotnet ({Minecraft.ProtocolConstants.CurrentVersionString}, protocol {Minecraft.ProtocolConstants.ProtocolVersion})",
            $"{stats.Fps} fps, frame {stats.FrameMs:F1} ms",
            $"Server: {client.ServerBrand ?? "?"}, {client.Connection?.PacketsReceived ?? 0} packets in, {(client.Connection?.BytesReceived ?? 0) / 1024} KiB",
            $"C: {stats.VisibleSections}/{stats.LoadedSections} sections, {stats.PendingSections} pending, {client.Entities.Count} entities",
            ParticleCounts(client),
            ""
        ];
        // Minecraft.showOnlyReducedInfo: the server's say or the player's own option.
        if (player != null && level != null && !player.ReducedDebugInfo && context.Settings?.ReducedDebugInfo != true) {
            // Where the view is, which while spectating is the camera entity rather than the player.
            ClientLib.Maths.Vec3d at = (client.CameraEntity ?? player).Position;
            int bx = (int)Math.Floor(at.X), by = (int)Math.Floor(at.Y), bz = (int)Math.Floor(at.Z);
            left.Add($"XYZ: {at.X:F3} / {at.Y:F5} / {at.Z:F3}");
            left.Add($"Block: {bx} {by} {bz} [{bx & 15} {by & 15} {bz & 15}]");
            left.Add($"Chunk: {bx >> 4} {by >> 4} {bz >> 4}");
            left.Add($"Facing: {Facing(player.YRot)} ({ClientLib.Entities.ClientEntity.Wrap(player.YRot):F1} / {player.XRot:F1})");
            left.Add($"Light: {level.GetSkyLight(bx, by, bz)} sky, {level.GetBlockLight(bx, by, bz)} block");
            ushort biome = level.GetBiome(bx, by, bz);
            string biomeName = biome < level.Registry.Biomes.Count ? level.Registry.Biomes[biome].Identifier.ToString() : biome.ToString();
            left.Add($"Biome: {biomeName}");
            long dayTime = level.DefaultClockTime;
            left.Add($"Day {dayTime / 24000}, time {dayTime % 24000}, rain {level.RainLevel:F2}");
            left.Add($"Dimension: {level.Name}");
            left.Add($"Pose: {player.Pose}{(player.Sprinting ? ", sprinting" : "")}{(player.OnGround ? ", on ground" : "")}{(player.Flying ? ", flying" : "")}");
        }

        if (_workingSetRead == 0 || Stopwatch.GetElapsedTime(_workingSetRead).TotalSeconds >= 1) {
            using Process process = Process.GetCurrentProcess();
            _workingSet = process.WorkingSet64;
            _workingSetRead = Stopwatch.GetTimestamp();
        }
        List<string> right = [
            $".NET {Environment.Version}",
            $"Mem: {GC.GetTotalMemory(false) / 1048576} MiB managed, {_workingSet / 1048576} MiB total",
            $"GC: {GC.CollectionCount(0)}/{GC.CollectionCount(1)}/{GC.CollectionCount(2)}",
            $"CPU: {Environment.ProcessorCount} threads",
            "",
            stats.Renderer
        ];
        if (stats.Target is { } target && level != null) {
            IBlock block = level.GetBlock(target.X, target.Y, target.Z);
            right.Add("");
            right.Add($"Targeted block: {target.X}, {target.Y}, {target.Z}");
            right.Add(block.Identifier.ToString());
            foreach ((string key, NBT.INbtTag value) in block.ToStateNbt().Children) {
                right.Add($"{key}: {(value is NBT.Tags.StringTag s ? s.Value : value.ToString())}");
            }
        }

        DrawColumn(context, left, false);
        DrawColumn(context, right, true);
    }

    private static void DrawColumn(GuiContext context, List<string> lines, bool rightAligned) {
        for (int i = 0; i < lines.Count; i++) {
            if (lines[i].Length == 0) {
                continue;
            }
            int width = context.Text.Width(lines[i]);
            float x = rightAligned ? context.Width - width - 2 : 2;
            context.Gui.Rect(x - 1, 2 + i * 9 - 1, width + 2, 9, 0x90505050);
            context.Text.Draw(lines[i], x, 2 + i * 9, 0xFFE0E0E0, false);
        }
    }

    private static string Facing(float yaw) => ((int)Math.Floor(ClientLib.Entities.ClientEntity.Wrap(yaw) / 90.0 + 0.5) & 3) switch {
        0 => "south (Towards positive Z)",
        1 => "west (Towards negative X)",
        2 => "north (Towards negative Z)",
        _ => "east (Towards positive X)"
    };
}

public sealed record DebugStats(
    int Fps,
    double FrameMs,
    int VisibleSections,
    int LoadedSections,
    int PendingSections,
    string Renderer,
    (int X, int Y, int Z)? Target);
