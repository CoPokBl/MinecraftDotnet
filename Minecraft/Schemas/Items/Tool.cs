using Minecraft.Data;
using Minecraft.Data.Blocks;
using Minecraft.Registry;

namespace Minecraft.Schemas.Items;

public record Tool(ToolRule[] Rules, float DefaultMiningSpeed, int DamagePerBlock, bool CanMineInCreative) : INetworkType<Tool> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
        writer.WritePrefixedArray(Rules, reg);
        writer.WriteFloat(DefaultMiningSpeed);
        writer.WriteVarInt(DamagePerBlock);
        return writer.WriteBoolean(CanMineInCreative);
    }
    
    public static Tool ReadData(DataReader reader, MinecraftRegistry reg) {
        ToolRule[] rules = reader.ReadPrefixedArray<ToolRule>(reg);
        float defaultMiningSpeed = reader.ReadFloat();
        int damagePerBlock = reader.ReadVarInt();
        bool canMineInCreative = reader.ReadBoolean();
        return new Tool(rules, defaultMiningSpeed, damagePerBlock, canMineInCreative);
    }

    public float GetMiningSpeed(IBlock block) {
        foreach (ToolRule rule in Rules) {
            if (!rule.ValidFor(block)) {
                continue;
            }
            
            if (rule.Speed != null) {
                return rule.Speed.Value;
            }
        }

        return DefaultMiningSpeed;
    }

    public bool IsCorrectForDrops(IBlock block) {
        foreach (ToolRule rule in Rules) {
            if (rule.CorrectDropForBlocks != null && rule.ValidFor(block)) {
                return rule.CorrectDropForBlocks.Value;
            }
        }

        return false;
    }
}
