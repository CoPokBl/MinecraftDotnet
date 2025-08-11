using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta.Types;

namespace ManagedServer.Entities.Types;

public class NpcEntity(PlayerMeta? meta = null) : LivingEntity(EntityType.Player, meta) {
    public string Name = Guid.NewGuid().ToString()[..16];
    
    public new PlayerMeta Meta {
        get => (PlayerMeta)base.Meta;
        set => base.Meta = value;
    }
    
    public GameMode GameMode {
        get => _gameMode;
        set {
            _gameMode = value;
            UpdateGameMode();
        }
    }
    
    public PlayerSkin? Skin { get; set; }
    public double EyeHeight => Crouching ? 1.27 : EntityType.Player.EyeHeight;
    
    private GameMode _gameMode;

    public void UpdateGameMode() {
        SendToSelfAndViewers(new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                    GameMode = GameMode
                })
        });
    }
    
    public MinecraftPacket GetPlayerInfoPacket() {
        return new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions
                    .AddPlayer)
                .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = Name,
                    Properties = Skin == null
                        ? []
                        : [
                            new ProfileProperty {
                                Name = "textures",
                                Value = Skin.Textures,
                                Signature = Skin.Signature
                            }
                        ]
                })
        };
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        MinecraftPacket[] arr = [
            GetPlayerInfoPacket()
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }
}
