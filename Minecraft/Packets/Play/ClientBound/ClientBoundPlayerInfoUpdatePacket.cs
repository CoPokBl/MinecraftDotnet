using Minecraft.NBT.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerInfoUpdatePacket(ClientBoundPlayerInfoUpdatePacket.PlayerData data) : MinecraftPacket {
    public PlayerData Data { get; } = data;

    public ClientBoundPlayerInfoUpdatePacket() : this(new PlayerData()) { }
    
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
        public readonly List<(Guid, IPlayerAction[])> Data = [];

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
                return new DataWriter()
                    .WriteString(Name)
                    .WritePrefixedArray(Properties,
                        (property, writer) => writer
                            .WriteString(property.Name)
                            .WriteString(property.Value)
                            .WritePrefixedOptional(property.Signature, (s, dataWriter) => dataWriter.WriteString(s)))
                    .ToArray();
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
        }

        public class UpdateGameMode : IPlayerAction {
            public required int GameMode;
            public PlayerActions Action => PlayerActions.UpdateGameMode;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt(GameMode)
                    .ToArray();
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
        }
        
        public class UpdateLatency : IPlayerAction {
            public required int Latency;
            public PlayerActions Action => PlayerActions.UpdateLatency;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt(Latency)
                    .ToArray();
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
        }
        
        public class UpdateListPriority : IPlayerAction {
            public required int Priority;
            public PlayerActions Action => PlayerActions.UpdateListPriority;
            
            public byte[] Serialise() {
                return new DataWriter()
                    .WriteVarInt(Priority)
                    .ToArray();
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
        }
    }

    public override int GetPacketId() {
        return 0x3F;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)Data.Actions.CombineFlags())
            .WritePrefixedArray(Data.Data.ToArray(), (val, writer) => writer
                .WriteUuid(val.Item1)
                .WriteArray(val.Item2.OrderBy(e => e.Action), (action, dataWriter) => dataWriter.Write(action.Serialise())))
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        throw new NotImplementedException();  // uses nbt for display name
    }
}