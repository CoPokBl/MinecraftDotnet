using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CreeperHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {

    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 429;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:skull";
    public Identifier? Item => "minecraft:creeper_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.creeper_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 9796,
                    1 => 9797,
                    2 => 9798,
                    3 => 9799,
                    4 => 9800,
                    5 => 9801,
                    6 => 9802,
                    7 => 9803,
                    8 => 9804,
                    9 => 9805,
                    10 => 9806,
                    11 => 9807,
                    12 => 9808,
                    13 => 9809,
                    14 => 9810,
                    15 => 9811,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9812,
                    1 => 9813,
                    2 => 9814,
                    3 => 9815,
                    4 => 9816,
                    5 => 9817,
                    6 => 9818,
                    7 => 9819,
                    8 => 9820,
                    9 => 9821,
                    10 => 9822,
                    11 => 9823,
                    12 => 9824,
                    13 => 9825,
                    14 => 9826,
                    15 => 9827,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9796 => new CreeperHeadBlock(Identifier, true, 0),
            9797 => new CreeperHeadBlock(Identifier, true, 1),
            9798 => new CreeperHeadBlock(Identifier, true, 2),
            9799 => new CreeperHeadBlock(Identifier, true, 3),
            9800 => new CreeperHeadBlock(Identifier, true, 4),
            9801 => new CreeperHeadBlock(Identifier, true, 5),
            9802 => new CreeperHeadBlock(Identifier, true, 6),
            9803 => new CreeperHeadBlock(Identifier, true, 7),
            9804 => new CreeperHeadBlock(Identifier, true, 8),
            9805 => new CreeperHeadBlock(Identifier, true, 9),
            9806 => new CreeperHeadBlock(Identifier, true, 10),
            9807 => new CreeperHeadBlock(Identifier, true, 11),
            9808 => new CreeperHeadBlock(Identifier, true, 12),
            9809 => new CreeperHeadBlock(Identifier, true, 13),
            9810 => new CreeperHeadBlock(Identifier, true, 14),
            9811 => new CreeperHeadBlock(Identifier, true, 15),
            9812 => new CreeperHeadBlock(Identifier, false, 0),
            9813 => new CreeperHeadBlock(Identifier, false, 1),
            9814 => new CreeperHeadBlock(Identifier, false, 2),
            9815 => new CreeperHeadBlock(Identifier, false, 3),
            9816 => new CreeperHeadBlock(Identifier, false, 4),
            9817 => new CreeperHeadBlock(Identifier, false, 5),
            9818 => new CreeperHeadBlock(Identifier, false, 6),
            9819 => new CreeperHeadBlock(Identifier, false, 7),
            9820 => new CreeperHeadBlock(Identifier, false, 8),
            9821 => new CreeperHeadBlock(Identifier, false, 9),
            9822 => new CreeperHeadBlock(Identifier, false, 10),
            9823 => new CreeperHeadBlock(Identifier, false, 11),
            9824 => new CreeperHeadBlock(Identifier, false, 12),
            9825 => new CreeperHeadBlock(Identifier, false, 13),
            9826 => new CreeperHeadBlock(Identifier, false, 14),
            9827 => new CreeperHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString())
        );
    }
    
}
