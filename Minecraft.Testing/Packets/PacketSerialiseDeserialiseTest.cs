using System.Reflection;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Text;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace Minecraft.Testing.Packets;

public class PacketSerialiseDeserialiseTest {

    [Test]
    public void TestClientBoundPackets() {
        ClientBoundStatusResponsePacket statusResponse = new() {
            VersionName = "Potato",
            VersionProtocol = 69,
            MaxPlayers = 5,
            OnlinePlayers = 1,
            SamplePlayers = [new SamplePlayer("CopokBl", "a")],
            Description = "Welcome to my server!",
            PreventsChatReports = true
        };
        
        TestPacket(statusResponse, ConnectionState.Status, true);

        ClientBoundLoginPacket login = new() {
            DimensionName = "hell",
            Dimensions = ["hell", "overworld"],
            DimensionType = 1,
            DoLimitedCrafting = false,
            EnableRespawnScreen = false,
            EnforcesSecureChat = false,
            EntityId = 69,
            GameMode = GameMode.Creative,
            HashedSeed = 0,
            IsDebug = false,
            IsFlat = false,
            IsHardcore = false,
            SeaLevel = 8,
            PortalCooldown = 14,
            PreviousGameMode = GameMode.Spectator,
            ReducedDebugInfo = false,
            SimulationDistance = 5,
            ViewDistance = 6,
            MaxPlayers = 1
        };
        TestPacket(login, ConnectionState.Play, true);
        
        MinecraftPacket upi = new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.InitializeChat,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateLatency,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListed)
                .WithPlayer(Guid.NewGuid(), new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = "Potato Man",
                    Properties = []
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateLatency {
                    Latency = 5
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListed {
                    Listed = false
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.InitializeChat {
                    ChatSessionId = Guid.NewGuid(),
                    EncodedPublicKey = [0,0,0,0,0,0],
                    HasData = true,
                    PublicKeyExpiryTime = 100L,
                    PublicKeySignature = [0,0,01,0,05,9]
                })
        };
        TestPacket(upi, ConnectionState.Play, true);
        
        TestPacket(new ClientBoundSetContainerContentPacket {
            CursorItem = ItemStack.Air,
            SlotData = [
                new ItemStack(Item.IronBoots)
                    .With(DataComponent.AttributeModifiers, [
                        new ItemAttributeModifier(Attribute.Scale, "minecraft:thing", 0.5, AttributeOperation.Add, EquipmentSlotGroup.Any, ItemAttributeModifier.Display.DefaultMode())
                    ])
            ],
            StateId = 5,
            WindowId = 100
        }, ConnectionState.Play, true);
        
        ChunkData cd = new(ChunkData.VanillaOverworldHeight);
        cd.SetBlock(10, 100, 10, 10);
        cd.SetBlock(1, 2, 3, 11);
        cd.SetBlock(7, 53, 2, 5);
        ClientBoundChunkDataAndUpdateLightPacket chunk = new() {
            ChunkX = 0,
            ChunkZ = 0,
            Data = cd,
            Light = LightData.FullBright
        };
        TestPacket(chunk, ConnectionState.Play, true);
        
        ClientBoundSpawnEntityPacket spawnEntityPacket = new() {
            Data = 0,
            EntityType = EntityType.Allay,
            HeadYaw = 93,
            Id = 53,
            Pitch = 0,
            Position = (0, 5, 123),
            Uuid = Guid.NewGuid(),
            Velocity = (10, 0, -13),
            Yaw = 180
        };
        TestPacket(spawnEntityPacket, ConnectionState.Play, true);
    }

    [Test]
    public void TestServerBoundPackets() {
        ServerBoundChatMessagePacket cm = new() {
            Acknowledged = [0, 0, 0],
            Checksum = 1,
            Message = "Hello, world!",
            MessageCount = 1,
            Salt = 1,
            Signature = new byte[256],
            Timestamp = 5L
        };
        TestPacket(cm, ConnectionState.Play, false);
        
        TestPacket(new ServerBoundLoginStartPacket {
            Uuid = Guid.NewGuid(),
            Name = "TestPlayer"
        }, ConnectionState.Login, false);
    }

    private void TestPacket<T>(T packet, ConnectionState state, bool clientBound) where T : MinecraftPacket {
        byte[] data = packet.Serialise(state, 0);
        MinecraftPacket deserialised = MinecraftPacket.Deserialise(data, clientBound, state, 
            true, false);
        
        Assert.That(deserialised.GetType(), Is.EqualTo(packet.GetType()));
        
        // check all fields using some reflection magic
        foreach (FieldInfo field in typeof(T).GetFields()) {
            if (field.FieldType == typeof(TextComponent)) {
                continue;  // TextComponents do not implement equality
            }
            
            object? originalValue = field.GetValue(packet);
            object? deserialisedValue = field.GetValue(deserialised);
            
            Assert.That(deserialisedValue, Is.EqualTo(originalValue), 
                $"Field {field.Name} does not match.");
        }
    }
}
