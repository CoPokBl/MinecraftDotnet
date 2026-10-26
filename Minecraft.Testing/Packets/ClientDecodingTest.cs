using System.Collections;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;
using Minecraft.Data.ArgumentParsers.Types;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Advancements;
using Minecraft.Schemas.Blocks;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT.Tags;

namespace Minecraft.Testing.Packets;

/// <summary>
/// Packets a client has to decode that the server side never reads back, so a round trip through
/// our own writer is the only place a broken reader shows up before a real server sends one.
/// </summary>
public class ClientDecodingTest {
    [OneTimeSetUp]
    public void InitialiseRegistry() {
        _ = VanillaRegistry.Data;
    }

    private static T RoundTrip<T>(T packet, ConnectionState state = ConnectionState.Play) where T : MinecraftPacket {
        byte[] bytes = packet.Serialise(state);
        return (T)MinecraftPacket.Deserialise(bytes, true, state);
    }

    /// <summary>
    /// Bytes as vanilla's <c>EntityDataSerializers</c> write them: an optional block state and an optional
    /// unsigned int are one VarInt each, 0 for empty, with no presence flag in front.
    /// </summary>
    [Test]
    public void OptionalMetadataIsOneVarInt() {
        uint stone = Block.Stone.StateId;
        DataWriter bytes = new();
        bytes.Write((byte)2).WriteVarInt((int)MetaFieldType.OptionalBlockState).WriteVarInt((int)stone);
        bytes.Write((byte)3).WriteVarInt((int)MetaFieldType.OptionalBlockState).WriteVarInt(0);
        bytes.Write((byte)4).WriteVarInt((int)MetaFieldType.OptionalVarInt).WriteVarInt(8);
        bytes.Write((byte)5).WriteVarInt((int)MetaFieldType.OptionalVarInt).WriteVarInt(0);
        bytes.Write(0xFF);
        byte[] vanilla = bytes.ToArray();

        EntityMetaContainer read = new EntityMetaContainer().ReadData(VanillaRegistry.Data, new DataReader(vanilla));
        Assert.That(read.GetValue<Optional<Minecraft.Data.Blocks.IBlock>>(2)!.Value.StateId, Is.EqualTo(stone));
        Assert.That(read.GetValue<Optional<Minecraft.Data.Blocks.IBlock>>(3)!.Present, Is.False);
        Assert.That(read.GetValue<Optional<int>>(4)!.Value, Is.EqualTo(7));
        Assert.That(read.GetValue<Optional<int>>(5)!.Present, Is.False);

        DataWriter written = new();
        read.Write(VanillaRegistry.Data, written);
        Assert.That(written.ToArray(), Is.EqualTo(vanilla));
    }

    /// <summary><c>ColorParticleOption</c> sends ARGB, so any opaque colour is a negative int.</summary>
    [Test]
    public void ColourParticleKeepsItsAlpha() {
        DataWriter bytes = new();
        bytes.WriteInteger(unchecked((int)0xFF3366CC));
        IParticle read = new EntityEffectParticle("minecraft:entity_effect").ReadData(new DataReader(bytes.ToArray()), VanillaRegistry.Data);
        Assert.That(((EntityEffectParticle)read).Argb, Is.EqualTo(unchecked((int)0xFF3366CC)));
    }

    [Test]
    public void SectionUpdateKeepsNegativeSectionsAndStates() {
        uint stairs = Block.OakStairs.StateId + 5;
        ClientBoundSectionBlocksUpdatePacket packet = new() {
            ChunkSectionPosition = new Vec3<int>(-3, -2, -5),
            BlockUpdates = [
                new BlockUpdate { Block = VanillaRegistry.Data.Blocks.GetByStateId(stairs), Location = new Vec3<int>(1, 2, 3) }
            ]
        };

        ClientBoundSectionBlocksUpdatePacket read = RoundTrip(packet);

        Assert.That(read.ChunkSectionPosition, Is.EqualTo(new Vec3<int>(-3, -2, -5)));
        Assert.That(read.BlockUpdates[0].Block.StateId, Is.EqualTo(stairs));
        Assert.That(read.BlockUpdates[0].Location, Is.EqualTo(new Vec3<int>(1, 2, 3)));
    }

    [Test]
    public void ChunkPacketCarriesItsLight() {
        byte[] section = new byte[2048];
        section[0] = 0xF3;
        BitArray mask = new(26) { [3] = true };
        LightData light = new() {
            SkyLightMask = mask,
            BlockLightMask = new BitArray(26),
            EmptySkyLightMask = new BitArray(26),
            EmptyBlockLightMask = new BitArray(26),
            SkyLight = [section],
            BlockLight = []
        };
        ClientBoundChunkDataAndUpdateLightPacket packet = new() {
            ChunkX = 2,
            ChunkZ = -7,
            Data = new ChunkData(ChunkData.VanillaOverworldHeight),
            Light = light
        };

        ClientBoundChunkDataAndUpdateLightPacket read = RoundTrip(packet);

        Assert.That(read.Light.SkyLightMask[3], Is.True);
        Assert.That(read.Light.SkyLight, Has.Length.EqualTo(1));
        Assert.That(read.Light.SkyLight[0][0], Is.EqualTo(0xF3));
    }

    [Test]
    public void ReadRemainingConsumesTheRest() {
        DataReader reader = new([1, 2, 3, 4]);
        reader.ReadByte();

        Assert.That(reader.ReadRemaining(), Is.EqualTo(new byte[] { 2, 3, 4 }));
        Assert.That(reader.HasRemaining, Is.False);
    }

    [Test]
    public void AdvancementWithoutBackgroundReads() {
        AdvancementDisplay display = new() {
            Title = "Title",
            Description = "Description",
            Icon = new ItemStack(Item.IronIngot),
            X = 1,
            Y = 2
        };
        DataWriter writer = new();
        display.Write(writer, VanillaRegistry.Data);

        AdvancementDisplay read = AdvancementDisplay.Read(new DataReader(writer.ToArray()), VanillaRegistry.Data);

        // The position travels beside the advancement, not in the display.
        Assert.That(read.Background, Is.Null);
        Assert.That(read.X, Is.EqualTo(0));
    }

    /// <summary>
    /// What vanilla sends for <c>/give</c>: a translation whose arguments mix an int and a component,
    /// which NBT can only hold by wrapping each in a compound with one unnamed entry.
    /// </summary>
    [Test]
    public void WrappedTranslationArgumentsAndUnknownEventsParse() {
        CompoundTag tag = new(
            ("translate", new StringTag("commands.give.success.single")),
            ("with", new ListTag<CompoundTag>(
                new CompoundTag(("", new IntegerTag(1))),
                new CompoundTag(("", new StringTag("Diamond Sword"))))),
            ("hover_event", new CompoundTag(
                ("action", new StringTag("show_entity")),
                ("id", new StringTag("minecraft:pig")),
                ("uuid", new StringTag("00000000-0000-0000-0000-000000000000")))));

        TextComponent component = TextComponent.FromTag(tag);

        Assert.That(component.HoverEvent?.Action, Is.EqualTo("show_entity"));
        Assert.That(component.Content.Type, Is.EqualTo("translatable"));
    }

    [Test]
    public void CommandTreeWithEntityArgumentsRoundTrips() {
        ClientBoundCommandsPacket packet = new() {
            Nodes = [
                new RootNode(CommandNodeFlag.RootType, [1], null, null),
                new ArgumentNode(CommandNodeFlag.ArgumentType | CommandNodeFlag.IsExecutable, [], null, "target",
                    new EntityArgumentType(Single: true, PlayersOnly: true), null)
            ],
            RootIndex = 0
        };

        ClientBoundCommandsPacket read = RoundTrip(packet);

        ArgumentNode argument = (ArgumentNode)read.Nodes[1];
        Assert.That(argument.Parser, Is.EqualTo(new EntityArgumentType(true, true)));
    }

    [Test]
    public void TokenArgumentKeepsBracketedSelectorsWhole() {
        string input = "@e[type=cow, limit=1] rest";
        string token = new EntityArgumentType().Parse(ref input, VanillaRegistry.Data);

        Assert.That(token, Is.EqualTo("@e[type=cow, limit=1]"));
        Assert.That(input, Is.EqualTo("rest"));
    }
}
