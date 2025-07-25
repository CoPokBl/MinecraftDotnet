using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerInfoUpdatePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_info_update";
    
    public required PlayerData Data;
    
    [Flags]
    public enum PlayerActions {
        AddPlayer = 0x01,
        InitializeChat = 0x02,
        UpdateGameMode = 0x04,
        UpdateListed = 0x08,
        UpdateLatency = 0x10,
        UpdateDisplayName = 0x20,
        UpdateListPriority = 0x40,
        UpdateHat = 0x80
    }
    
    public class PlayerData(params PlayerActions[] actions) {
        public PlayerActions[] Actions { get; } = actions;
        public List<(Guid, IPlayerAction[])> Data = [];

        public PlayerData WithPlayer(Guid uuid, params IPlayerAction[] playerActions) {
            List<PlayerActions> needed = new(Actions);
            foreach (IPlayerAction pa in playerActions) {
                if (!needed.Contains(pa.Action)) {  // we don't need it
                    throw new Exception("Only actions specified in 'actions' in the constructor may be provided");
                }

                needed.Remove(pa.Action);
            }
            
            // okay, so needed should be empty
            if (needed.Count != 0) {
                string missing = needed.Aggregate("", (current, missed) => current + (missed + ", "));
                throw new Exception($"Not all specified player actions were provided, missing: {missing[..^2]}");
            }
            
            Data.Add((uuid, playerActions));
            return this;
        }
        
        public interface IPlayerAction {
            PlayerActions Action { get; }
            byte[] Serialise();
        }
        
        public class AddPlayer : IPlayerAction {
            public required string Name;
            public Property[] Properties = [];

            public PlayerActions Action => PlayerActions.AddPlayer;
        
            public class Property {
                public required string Name;
                public required string Value;
                public string? Signature;
            }

            public byte[] Serialise() {
                if (Name.Length > 16) {
                    throw new ArgumentException("Player name cannot be longer than 16 characters.");
                }
                
                return new DataWriter()
                    .WriteString(Name)
                    .WritePrefixedArray(Properties,
                        (property, writer) => writer
                            .WriteString(property.Name)
                            .WriteString(property.Value)
                            .WritePrefixedOptional(property.Signature, (s, dataWriter) => dataWriter.WriteString(s)))
                    .ToArray();
            }

            public static AddPlayer Deserialise(DataReader r) {
                return new AddPlayer {
                    Name = r.ReadString(),
                    Properties = r.ReadPrefixedArray(re => {
                        return new Property {
                            Name = re.ReadString(),
                            Value = re.ReadString(),
                            Signature = re.ReadPrefixedOptional(red => red.ReadString())
                        };
                    })
                };
            }
        }
        
        public class InitializeChat : IPlayerAction {
            public required bool HasData;
            public Guid? ChatSessionId;
            public long? PublicKeyExpiryTime;
            public byte[]? EncodedPublicKey;
            public byte[]? PublicKeySignature;
            public PlayerActions Action => PlayerActions.InitializeChat;
            
            public byte[] Serialise() {
                if (!HasData) {
                    return new DataWriter().WriteBoolean(false).ToArray();
                }

                if (ChatSessionId == null || PublicKeyExpiryTime == null || EncodedPublicKey == null || PublicKeySignature == null) {
                    throw new Exception("If HasData is true all fields must be set.");
                }

                return new DataWriter()
                    .WriteBoolean(true) // prefixed optional
                    .WriteUuid(ChatSessionId.Value)
                    .WriteLong(PublicKeyExpiryTime.Value)
                    .WritePrefixedArray(EncodedPublicKey, (b, writer) => writer.Write(b))
                    .WritePrefixedArray(PublicKeySignature, (b, writer) => writer.Write(b))
                    .ToArray();
            }

            public static InitializeChat Deserialise(DataReader r) {
                if (!r.ReadBoolean()) {
                    return new InitializeChat {
                        HasData = false
                    };
                }

                return new InitializeChat {
                    HasData = true,
                    ChatSessionId = r.ReadUuid(),
                    PublicKeyExpiryTime = r.ReadLong(),
                    EncodedPublicKey = r.ReadPrefixedArray(red => red.Read()),
                    PublicKeySignature = r.ReadPrefixedArray(red => red.Read())
                };
            }
        }

        public class UpdateGameMode : IPlayerAction {
            public required GameMode GameMode;
            public PlayerActions Action => PlayerActions.UpdateGameMode;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt((int)GameMode)
                    .ToArray();
            }

            public static UpdateGameMode Deserialise(DataReader r) {
                return new UpdateGameMode {
                    GameMode = (GameMode)r.ReadVarInt()
                };
            }
        }
        
        public class UpdateListed : IPlayerAction {
            public required bool Listed;
            public PlayerActions Action => PlayerActions.UpdateListed;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteBoolean(Listed)
                    .ToArray();
            }
            
            public static UpdateListed Deserialise(DataReader r) {
                return new UpdateListed {
                    Listed = r.ReadBoolean()
                };
            }
        }
        
        public class UpdateLatency : IPlayerAction {
            public required int Latency;
            public PlayerActions Action => PlayerActions.UpdateLatency;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt(Latency)
                    .ToArray();
            }
            
            public static UpdateLatency Deserialise(DataReader r) {
                return new UpdateLatency {
                    Latency = r.ReadVarInt()
                };
            }
        }
        
        public class UpdateDisplayName : IPlayerAction {
            public required TextComponent? DisplayName;
            public PlayerActions Action => PlayerActions.UpdateDisplayName;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WritePrefixedOptional(DisplayName, (component, writer) => writer.WriteNbt(component))
                    .ToArray();
            }
            
            public static UpdateDisplayName Deserialise(DataReader r) {
                return new UpdateDisplayName {
                    DisplayName = r.ReadPrefixedOptional(re => re.ReadText())
                };
            }
        }
        
        public class UpdateListPriority : IPlayerAction {
            public required int Priority;
            public PlayerActions Action => PlayerActions.UpdateListPriority;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt(Priority)
                    .ToArray();
            }
            
            public static UpdateListPriority Deserialise(DataReader r) {
                return new UpdateListPriority {
                    Priority = r.ReadVarInt()
                };
            }
        }
        
        public class UpdateHat : IPlayerAction {
            public required bool Visible;
            public PlayerActions Action => PlayerActions.UpdateHat;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteBoolean(Visible)
                    .ToArray();
            }
            
            public static UpdateHat Deserialise(DataReader r) {
                return new UpdateHat {
                    Visible = r.ReadBoolean()
                };
            }
        }
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUnsignedByte((byte)Data.Actions.CombineFlags())
            .WritePrefixedArray(Data.Data.ToArray(), (val, writer) => writer
                .WriteUuid(val.Item1)
                .WriteArray(val.Item2.OrderBy(e => e.Action), (action, dataWriter) => dataWriter.Write(action.Serialise())));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        PlayerActions actions = (PlayerActions)r.Read();
        PlayerActions[] setFlags = Enum.GetValues(typeof(PlayerActions))
            .Cast<PlayerActions>()
            .Where(flag => actions.HasFlag(flag))
            .ToArray();

        (Guid, PlayerData.IPlayerAction[])[] dat = r.ReadPrefixedArray(reader => {
            return (reader.ReadUuid(), reader.ReadArray<PlayerData.IPlayerAction>(setFlags.Length, (r2, i) => {
                return setFlags[i] switch {
                    PlayerActions.AddPlayer => PlayerData.AddPlayer.Deserialise(r2),
                    PlayerActions.InitializeChat => PlayerData.InitializeChat.Deserialise(r2),
                    PlayerActions.UpdateGameMode => PlayerData.UpdateGameMode.Deserialise(r2),
                    PlayerActions.UpdateListed => PlayerData.UpdateListed.Deserialise(r2),
                    PlayerActions.UpdateLatency => PlayerData.UpdateLatency.Deserialise(r2),
                    PlayerActions.UpdateDisplayName => PlayerData.UpdateDisplayName.Deserialise(r2),
                    PlayerActions.UpdateListPriority => PlayerData.UpdateListPriority.Deserialise(r2),
                    PlayerActions.UpdateHat => PlayerData.UpdateHat.Deserialise(r2),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }));
        });
        
        return new ClientBoundPlayerInfoUpdatePacket {
            Data = new PlayerData(setFlags) {
                Data = dat.ToList()
            }
        };
    };
}
