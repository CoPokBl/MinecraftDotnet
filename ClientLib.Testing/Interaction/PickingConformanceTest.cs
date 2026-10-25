using System.IO.Compression;
using System.Text;
using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.Testing.Player;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// Holds <see cref="Picking.ClipBlocks"/> against the game's own <c>BlockGetter.clip</c> under
/// <c>ClipContext.Block.OUTLINE</c>, over the scenes whose outline is not the state's alone: a shulker box at
/// every tick of opening and closing, a light block and scaffolding under each held item, and the moving pistons
/// a piston leaves. The scenes are rebuilt here the way the server would build them, by block updates, block
/// events and ticks, so the block entities are the client's own. Block, face, location and the inside flag must
/// all match exactly: each goes into the use packet.
/// <para>
/// It also holds <see cref="Picking.HitEntitiesAlong"/> and <see cref="Picking.ClosestHit"/> against
/// <c>ProjectileUtil.getHitEntitiesAlong</c> and <c>AttackRange.getClosesetHit</c>, the pick a held attack range
/// makes first: a player in either game mode with entities around its near and far reach, some behind blocks or a
/// world border, every candidate and the chosen hit compared whole.
/// </para>
/// <para>The fixture is the server jar's; regenerate it on a version bump with Conformance/picking.sh.</para>
/// </summary>
public class PickingConformanceTest {
    private const string Fixture = "Interaction/vanilla-picking.bin.gz";

    private static readonly BlockFace[] Faces = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    private static (MinecraftClient Client, ClientLevel Level) World() {
        (MinecraftClient client, _) = LocalPlayerMechanicsTest.World((_, y, _) => y < -40 ? Block.Stone.StateId : 0, new Vec3d(0.5, -40, 0.5));
        return (client, client.Level!);
    }

    private static void Set(MinecraftClient client, Vec3<int> pos, uint state) =>
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = pos, Block = VanillaRegistry.Data.Blocks.GetByStateId(state) });

    private static void Event(MinecraftClient client, Vec3<int> pos, uint state, byte b0, byte b1) =>
        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = pos, Block = VanillaRegistry.Data.Blocks.GetByStateId(state), ActionId = b0, ActionParameter = b1
        });

    [Test]
    public void EveryPickAgreesWithVanilla() {
        string path = Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True, $"{Fixture} is missing. Regenerate it with Conformance/picking.sh.");
        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);
        Assert.That(Encoding.ASCII.GetString(reader.ReadBytes(7)), Is.EqualTo("MCPICK1"), "unexpected fixture format");

        Vec3<int> origin = new(ReadInt(reader), ReadInt(reader), ReadInt(reader));
        (Vec3d From, Vec3d To)[] rays = new (Vec3d, Vec3d)[ReadInt(reader)];
        for (int i = 0; i < rays.Length; i++) {
            rays[i] = (new Vec3d(origin.X + ReadDouble(reader), origin.Y + ReadDouble(reader), origin.Z + ReadDouble(reader)),
                new Vec3d(origin.X + ReadDouble(reader), origin.Y + ReadDouble(reader), origin.Z + ReadDouble(reader)));
        }

        (MinecraftClient Client, ClientLevel Level) world = World();
        (MinecraftClient Client, ClientLevel Level) contextWorld = World();
        (MinecraftClient Client, ClientLevel Level) spearWorld = World();
        int scenes = 0, mismatches = 0, spearScenes = 0;
        string first = "";
        while (true) {
            int kind = reader.ReadByte();
            if (kind == 255) {
                break;
            }
            scenes++;
            if (kind == 3) {
                spearScenes++;
                string? wrong = ReplaySpearScene(reader, spearWorld.Client, spearScenes);
                if (wrong != null) {
                    mismatches++;
                    if (first.Length == 0) {
                        first = wrong;
                    }
                }
                continue;
            }
            ClientLevel level;
            IItem? held = null;
            string scene;
            switch (kind) {
                case 0: {
                    uint state = (uint)ReadInt(reader);
                    int step = reader.ReadByte();
                    float progressOld = ReadFloat(reader), progress = ReadFloat(reader);
                    if (step == 0) {
                        world = World();
                        Set(world.Client, origin, state);
                    }
                    else {
                        if (step == 1 || step == 11) {
                            Event(world.Client, origin, state, 1, (byte)(step == 1 ? 1 : 0));
                        }
                        world.Client.Tick();
                    }
                    level = world.Level;
                    ShulkerBoxBlockEntity box = (ShulkerBoxBlockEntity)level.GetBlockEntity(origin.X, origin.Y, origin.Z)!;
                    Assert.That((box.GetProgress(0.0F), box.GetProgress(1.0F)), Is.EqualTo((progressOld, progress)), $"shulker {state} step {step}");
                    scene = $"shulker box {state} at step {step}";
                    break;
                }
                case 1: {
                    uint state = (uint)ReadInt(reader);
                    string item = ReadUtf(reader);
                    level = contextWorld.Level;
                    Set(contextWorld.Client, origin, state);
                    held = item.Length == 0 ? null : VanillaRegistry.Data.Items[item];
                    scene = $"{level.GetBlock(origin.X, origin.Y, origin.Z).Identifier}[{state}] holding '{item}'";
                    break;
                }
                case 2: {
                    uint baseState = (uint)ReadInt(reader), extended = (uint)ReadInt(reader), head = (uint)ReadInt(reader);
                    byte facing = reader.ReadByte();
                    int action = reader.ReadByte();
                    world = World();
                    Vec3<int> arm = new(origin.X + Step(facing, 0), origin.Y + Step(facing, 1), origin.Z + Step(facing, 2));
                    if (action < 2) {
                        Set(world.Client, origin, baseState);
                        if (action == 1) {
                            Set(world.Client, arm, Block.Stone.StateId);
                        }
                        Event(world.Client, origin, baseState, 0, facing);
                    }
                    else {
                        Set(world.Client, origin, extended);
                        Set(world.Client, arm, head);
                        Event(world.Client, origin, extended, 1, facing);
                    }
                    level = world.Level;
                    scene = $"piston {baseState} action {action}";
                    break;
                }
                default:
                    throw new InvalidDataException($"scene kind {kind}");
            }

            foreach ((Vec3d from, Vec3d to) in rays) {
                string wanted = reader.ReadByte() == 0
                    ? "miss"
                    : Describe(new Vec3<int>(ReadInt(reader), ReadInt(reader), ReadInt(reader)), Faces[reader.ReadByte()],
                        new Vec3d(ReadDouble(reader), ReadDouble(reader), ReadDouble(reader)), reader.ReadByte() != 0);
                string got = Picking.ClipBlocks(level, from, to, held) is BlockHitResult hit
                    ? Describe(new Vec3<int>(hit.X, hit.Y, hit.Z), hit.Face, hit.Location, hit.Inside)
                    : "miss";
                if (got == wanted) {
                    continue;
                }
                mismatches++;
                if (first.Length == 0) {
                    first = $"first in {scene}, ray {from} -> {to}: got {got}, vanilla says {wanted}";
                }
            }
        }

        Assert.That(scenes, Is.GreaterThan(0));
        Assert.That(spearScenes, Is.GreaterThan(0));
        Assert.That(mismatches, Is.Zero, $"{mismatches} picks over {scenes} scenes differ from vanilla, {first}");
    }

    /// <summary>One attack range scene, set up on the shared level and taken down again; null when it agrees.</summary>
    private static string? ReplaySpearScene(BinaryReader reader, MinecraftClient client, int number) {
        ClientLevel level = client.Level!;
        LocalPlayer player = client.Player!;
        player.GameMode = reader.ReadByte() != 0 ? GameMode.Creative : GameMode.Survival;
        player.Position = ReadVec(reader);
        player.OldPosition = ReadVec(reader);
        player.XRot = ReadFloat(reader);
        player.YRot = ReadFloat(reader);
        player.YHeadRot = ReadFloat(reader);
        player.DeltaMovement = ReadVec(reader);
        float partialTick = ReadFloat(reader);
        AttackRangeComponent.Data range = new(ReadFloat(reader), ReadFloat(reader), ReadFloat(reader), ReadFloat(reader), ReadFloat(reader), ReadFloat(reader));
        bool border = reader.ReadByte() != 0;
        double borderX = ReadDouble(reader), borderZ = ReadDouble(reader), borderSize = ReadDouble(reader);
        if (border) {
            level.WorldBorder.SetCenter(borderX, borderZ);
            level.WorldBorder.SetSize(borderSize);
        }

        List<Vec3<int>> placed = [];
        int blocks = reader.ReadByte();
        for (int i = 0; i < blocks; i++) {
            Vec3<int> pos = new(ReadInt(reader), ReadInt(reader), ReadInt(reader));
            Set(client, pos, (uint)ReadInt(reader));
            placed.Add(pos);
        }

        string scene = $"attack range scene {number} ({(player.GameMode == GameMode.Creative ? "creative" : "survival")}, {range})";
        string? wrong = null;
        List<ClientEntity> targets = [];
        int count = reader.ReadByte();
        for (int i = 0; i < count; i++) {
            string type = ReadUtf(reader);
            bool marker = reader.ReadByte() != 0;
            float width = ReadFloat(reader), height = ReadFloat(reader);
            Vec3d position = ReadVec(reader);
            Minecraft.Physics.Box box = new(ReadDouble(reader), ReadDouble(reader), ReadDouble(reader), ReadDouble(reader), ReadDouble(reader), ReadDouble(reader));
            ClientEntity target = new() { Id = 100 + i, Type = VanillaRegistry.Data.EntityTypes[type], Position = position, OldPosition = position };
            if (target.Is(EntityClass.Interaction)) {
                target.Metadata[EntityDataFields.Interaction.Width.Index] = new MetaField<float>(MetaFieldType.Float, width);
                target.Metadata[EntityDataFields.Interaction.Height.Index] = new MetaField<float>(MetaFieldType.Float, height);
            }
            if (marker) {
                target.Metadata[EntityDataFields.ArmorStand.ClientFlags.Index] = new MetaField<sbyte>(MetaFieldType.Byte, 16);
            }
            // A marker armor stand is sized as any other here and never picked either way.
            else if (target.BoundingBox != box) {
                wrong ??= $"{scene}: {type} #{i} has box {Describe(target.BoundingBox)}, vanilla {Describe(box)}";
            }
            targets.Add(target);
        }

        Dictionary<Guid, PlayerListEntry> players = [];
        string wantedAlong;
        if (reader.ReadByte() == 0) {
            wantedAlong = "left " + ReadHit(reader);
        }
        else {
            int hits = reader.ReadByte();
            List<string> each = [];
            for (int i = 0; i < hits; i++) {
                each.Add(ReadHit(reader));
            }
            wantedAlong = "right " + string.Join("; ", each);
        }
        string wantedClosest = ReadHit(reader);

        (HitResult? block, List<EntityHitResult>? found) = Picking.HitEntitiesAlong(range, player, level, targets, players);
        string gotAlong = block != null ? "left " + Describe(block, targets) : "right " + string.Join("; ", found!.Select(hit => Describe(hit, targets)));
        string gotClosest = Describe(Picking.ClosestHit(range, player, level, targets, players, partialTick), targets);
        if (gotAlong != wantedAlong) {
            wrong ??= $"{scene}: candidates {gotAlong}, vanilla says {wantedAlong}";
        }
        if (gotClosest != wantedClosest) {
            wrong ??= $"{scene}: closest {gotClosest}, vanilla says {wantedClosest}";
        }

        foreach (Vec3<int> pos in placed) {
            Set(client, pos, 0);
        }
        if (border) {
            level.WorldBorder.SetCenter(0.0, 0.0);
            level.WorldBorder.SetSize(ClientLib.World.WorldBorder.MaxSize);
        }
        return wrong;
    }

    private static string ReadHit(BinaryReader reader) {
        switch (reader.ReadByte()) {
            case 0:
                return $"miss {Describe(ReadVec(reader))}";
            case 1: {
                Vec3<int> pos = new(ReadInt(reader), ReadInt(reader), ReadInt(reader));
                BlockFace face = Faces[reader.ReadByte()];
                Vec3d location = ReadVec(reader);
                bool inside = reader.ReadByte() != 0, worldBorder = reader.ReadByte() != 0;
                return $"block {Describe(pos, face, location, inside)}{(worldBorder ? " border" : "")}";
            }
            default:
                return $"entity #{reader.ReadByte()} {Describe(ReadVec(reader))}";
        }
    }

    private static string Describe(HitResult hit, List<ClientEntity> targets) => hit switch {
        BlockHitResult block => $"block {Describe(new Vec3<int>(block.X, block.Y, block.Z), block.Face, block.Location, block.Inside)}{(block.WorldBorderHit ? " border" : "")}",
        EntityHitResult entity => $"entity #{targets.IndexOf(entity.Entity)} {Describe(entity.Location)}",
        _ => $"miss {Describe(hit.Location)}"
    };

    private static string Describe(Vec3d location) => $"({location.X:R}, {location.Y:R}, {location.Z:R})";

    private static string Describe(Minecraft.Physics.Box box) =>
        $"{Describe(new Vec3d(box.MinX, box.MinY, box.MinZ))} to {Describe(new Vec3d(box.MaxX, box.MaxY, box.MaxZ))}";

    private static Vec3d ReadVec(BinaryReader reader) => new(ReadDouble(reader), ReadDouble(reader), ReadDouble(reader));

    private static int Step(byte direction, int axis) => (direction, axis) switch {
        (0, 1) => -1, (1, 1) => 1, (2, 2) => -1, (3, 2) => 1, (4, 0) => -1, (5, 0) => 1, _ => 0
    };

    /// <summary>The doubles are written round trip, so two hits agree only when they are the same bits.</summary>
    private static string Describe(Vec3<int> pos, BlockFace face, Vec3d location, bool inside) =>
        $"{pos} {face} {Describe(location)}{(inside ? " inside" : "")}";

    /// <summary>Java writes big endian, <see cref="BinaryReader"/> reads little.</summary>
    private static int ReadInt(BinaryReader reader) {
        byte[] bytes = reader.ReadBytes(4);
        return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
    }

    private static float ReadFloat(BinaryReader reader) => BitConverter.Int32BitsToSingle(ReadInt(reader));

    private static double ReadDouble(BinaryReader reader) {
        byte[] bytes = reader.ReadBytes(8);
        Array.Reverse(bytes);
        return BitConverter.ToDouble(bytes);
    }

    private static string ReadUtf(BinaryReader reader) {
        byte[] length = reader.ReadBytes(2);
        return Encoding.UTF8.GetString(reader.ReadBytes(length[0] << 8 | length[1]));
    }
}
