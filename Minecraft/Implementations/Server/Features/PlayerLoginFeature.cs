using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.NBT;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class PlayerLoginFeature(
    KnownDataPack[]? knownPacks = null, 
    Func<PlayerConnection, ClientBoundLoginPacket>? loginPacketProvider = null, 
    Func<PlayerConnection, PlayerPosition>? spawnProvider = null) : IFeature {
    
    private readonly KnownDataPack[] _knownPacks = knownPacks ?? [new KnownDataPack("minecraft", "core", "1.21.5")];
    private readonly Func<PlayerConnection, ClientBoundLoginPacket> _loginPacketProvider = loginPacketProvider ?? (_ => new ClientBoundLoginPacket(
        1,
        true,
        ["minecraft:overworld"],
        5,
        32,
        8,
        false,
        true,
        false,
        0,
        "minecraft:overworld",
        0,
        0x01,
        0x00,
        false,
        false,
        null,
        4,
        64,
        false
    ));
    private readonly Func<PlayerConnection, PlayerPosition> _spawnProvider =
        spawnProvider ?? (_ => new PlayerPosition(new Vec3(0, 64, 0), Vec3.Zero, Angle.Zero, Angle.Zero));

    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                // LOGIN
                case ServerBoundLoginStartPacket ls: {
                    e.Connection.SetCompression(1).ContinueWith(_ => {
                        e.Connection.SendPackets(new ClientBoundLoginSuccessPacket(ls.Uuid, ls.Name));
                    });
                    break;
                }
                
                case ServerBoundLoginAcknowledgedPacket: {
                    e.Connection.SendPacket(new ClientBoundKnownPacksPacket(_knownPacks));
                    break;
                }
                
                // CONFIG
                case ServerBoundKnownPacksPacket: {
                    // for now just ignore their response, we can't handle other packs anyway
                    // in reality we don't use any packs at all this is just so that
                    // the client joins.
                    
                    _ = e.Connection.SendPackets(
                        new ClientBoundRegistryDataPacket("minecraft:dimension_type",
                            new Dictionary<string, ITag?> {
                                { "minecraft:overworld", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:cat_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:tabby", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:chicken_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:warm", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:cow_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:warm", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:frog_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:warm", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:painting_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:alban", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:pig_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:warm", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:wolf_sound_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:big", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:wolf_variant",
                            new Dictionary<string, ITag?> {
                                { "minecraft:ashen", null }
                            }),
                        new ClientBoundRegistryDataPacket("minecraft:damage_type",
                        new Dictionary<string, ITag?> {
                            { "minecraft:arrow", null },
                            { "minecraft:bad_respawn_point", null },
                            { "minecraft:cactus", null },
                            { "minecraft:campfire", null },
                            { "minecraft:cramming", null },
                            { "minecraft:dragon_breath", null },
                            { "minecraft:drown", null },
                            { "minecraft:dry_out", null },
                            { "minecraft:explosion", null },
                            { "minecraft:fall", null },
                            { "minecraft:falling_anvil", null },
                            { "minecraft:falling_block", null },
                            { "minecraft:falling_stalactite", null },
                            { "minecraft:fireball", null },
                            { "minecraft:fireworks", null },
                            { "minecraft:fly_into_wall", null },
                            { "minecraft:freeze", null },
                            { "minecraft:generic", null },
                            { "minecraft:generic_kill", null },
                            { "minecraft:hot_floor", null },
                            { "minecraft:in_fire", null },
                            { "minecraft:in_wall", null },
                            { "minecraft:indirect_magic", null },
                            { "minecraft:lava", null },
                            { "minecraft:lightning_bolt", null },
                            { "minecraft:magic", null },
                            { "minecraft:mob_attack", null },
                            { "minecraft:mob_attack_no_aggro", null },
                            { "minecraft:mob_projectile", null },
                            { "minecraft:on_fire", null },
                            { "minecraft:out_of_world", null },
                            { "minecraft:outside_border", null },
                            { "minecraft:player_attack", null },
                            { "minecraft:player_explosion", null },
                            { "minecraft:sonic_boom", null },
                            { "minecraft:spit", null },
                            { "minecraft:stalagmite", null },
                            { "minecraft:starve", null },
                            { "minecraft:sting", null },
                            { "minecraft:sweet_berry_bush", null },
                            { "minecraft:thorns", null },
                            { "minecraft:thrown", null },
                            { "minecraft:trident", null },
                            { "minecraft:unattributed_fireball", null },
                            { "minecraft:wind_charge", null },
                            { "minecraft:wither", null },
                            { "minecraft:wither_skull", null },
                            { "minecraft:ender_pearl", null }
                        }),
                        new ClientBoundRegistryDataPacket("minecraft:worldgen/biome",
                            new Dictionary<string, ITag?> {
                                { "minecraft:plains", null }
                            }),
                        new ClientBoundFinishConfigurationPacket()
                    );
                    break;
                }

                case ServerBoundAcknowledgeFinishConfigurationPacket: {
                    // We are now done config and are in play
                    // the player has logged in (pending play login)
                    // send the play login packet
                    PlayerPosition spawn = _spawnProvider.Invoke(e.Connection);
                    e.Connection.SendPackets(
                        _loginPacketProvider.Invoke(e.Connection),
                        new ClientBoundSynchronisePlayerPositionPacket(Random.Shared.Next(), spawn, TeleportFlags.None),
                        new ClientBoundSetCenterChunkPacket(spawn.ChunkX, spawn.ChunkZ)
                    ).ContinueWith(_ => {
                        PlayerLoginEvent loginEvent = new() {
                            Connection = e.Connection
                        };
                        e.Connection.Events.CallEventCatchErrors(loginEvent);
                    });
                    break;
                }
            }
        });
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class PlayerLoginEvent : ServerEvent {
        public required PlayerConnection Connection { get; init; }
    }
}