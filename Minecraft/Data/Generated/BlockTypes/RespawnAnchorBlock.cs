using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RespawnAnchorBlock(Identifier Identifier, int Charges) : IBlock {
    public Identifier Category => "minecraft:respawn_anchor";
    public int ProtocolId => 916;
    public double Hardness => 50;
    public double ExplosionResistance => 1200;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:respawn_anchor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.respawn_anchor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Charges switch {
                0 => 21619,
                1 => 21620,
                2 => 21621,
                3 => 21622,
                4 => 21623,
                _ => throw new ArgumentOutOfRangeException(nameof(Charges), Charges, "Unknown value for property charges.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21619 => new RespawnAnchorBlock(Identifier, 0),
            21620 => new RespawnAnchorBlock(Identifier, 1),
            21621 => new RespawnAnchorBlock(Identifier, 2),
            21622 => new RespawnAnchorBlock(Identifier, 3),
            21623 => new RespawnAnchorBlock(Identifier, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Charges = properties.ChildrenMap.ContainsKey("charges") ? int.Parse(properties["charges"].GetString()) : Charges,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("charges", Charges.ToString())
        );
    }
    
}
