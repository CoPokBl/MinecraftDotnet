using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundClientInformationPacketConfig(
    string locale, 
    byte viewDistance, 
    ChatMode chatMode, 
    bool chatColors, 
    SkinParts displayedSkinParts, 
    DominantHand mainHand, 
    bool enableTextFiltering, 
    bool allowServerListing, 
    ParticleStatus particleStatus) : MinecraftPacket {
    
    public ParticleStatus ParticleStatus = particleStatus;
    public bool AllowServerListing = allowServerListing;
    public bool EnableTextFiltering = enableTextFiltering;
    public DominantHand MainHand = mainHand;
    public SkinParts DisplayedSkinParts = displayedSkinParts;
    public bool ChatColors = chatColors;
    public ChatMode TextChatMode = chatMode;
    public byte ViewDistance = viewDistance;
    public string Locale = locale;

    public ServerBoundClientInformationPacketConfig() : this("en_US", 0, ChatMode.Enabled, true, SkinParts.All, DominantHand.Right, false, true, ParticleStatus.All) { }

    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Locale)
            .WriteByte(ViewDistance)
            .WriteVarInt((int)TextChatMode)
            .WriteBoolean(ChatColors)
            .WriteUnsignedByte((byte)DisplayedSkinParts)
            .WriteVarInt((int)MainHand)
            .WriteBoolean(EnableTextFiltering)
            .WriteBoolean(AllowServerListing)
            .WriteVarInt((int)ParticleStatus)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Locale = r.ReadString();
        ViewDistance = (byte)r.ReadByte();
        TextChatMode = (ChatMode)r.ReadVarInt();
        ChatColors = r.ReadBoolean();
        DisplayedSkinParts = (SkinParts)r.Read();
        MainHand = (DominantHand)r.ReadVarInt();
        EnableTextFiltering = r.ReadBoolean();
        AllowServerListing = r.ReadBoolean();
        ParticleStatus = (ParticleStatus)r.ReadVarInt();
        return this;
    }
}