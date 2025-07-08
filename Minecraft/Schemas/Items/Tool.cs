using Minecraft.Data.Blocks;

namespace Minecraft.Schemas.Items;

public record Tool(ToolRule[] Rules, float DefaultMiningSpeed, int DamagePerBlock, bool CanMineInCreative) : IWritable {
    
    public void Write(DataWriter writer) {
        writer.WritePrefixedArray(Rules, (rule, w) => rule.Write(w));
        writer.WriteFloat(DefaultMiningSpeed);
        writer.WriteVarInt(DamagePerBlock);
        writer.WriteBoolean(CanMineInCreative);
    }
    
    public static Tool Read(DataReader reader) {
        ToolRule[] rules = reader.ReadPrefixedArray(ToolRule.Read);
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
