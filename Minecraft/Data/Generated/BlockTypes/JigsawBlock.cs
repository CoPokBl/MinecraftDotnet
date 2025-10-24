using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JigsawBlock(Identifier Identifier, Orientation Orientation) : IBlock {
    public Identifier Category => "minecraft:jigsaw";
    public int ProtocolId => 904;
    public double Hardness => -1;
    public double ExplosionResistance => 3600000;
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
    public Identifier? BlockEntity => "minecraft:jigsaw";
    public Identifier? Item => "minecraft:jigsaw";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.jigsaw";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Orientation switch {
                Orientation.DownEast => 21524,
                Orientation.DownNorth => 21525,
                Orientation.DownSouth => 21526,
                Orientation.DownWest => 21527,
                Orientation.UpEast => 21528,
                Orientation.UpNorth => 21529,
                Orientation.UpSouth => 21530,
                Orientation.UpWest => 21531,
                Orientation.WestUp => 21532,
                Orientation.EastUp => 21533,
                Orientation.NorthUp => 21534,
                Orientation.SouthUp => 21535,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21524 => new JigsawBlock(Identifier, Orientation.DownEast),
            21525 => new JigsawBlock(Identifier, Orientation.DownNorth),
            21526 => new JigsawBlock(Identifier, Orientation.DownSouth),
            21527 => new JigsawBlock(Identifier, Orientation.DownWest),
            21528 => new JigsawBlock(Identifier, Orientation.UpEast),
            21529 => new JigsawBlock(Identifier, Orientation.UpNorth),
            21530 => new JigsawBlock(Identifier, Orientation.UpSouth),
            21531 => new JigsawBlock(Identifier, Orientation.UpWest),
            21532 => new JigsawBlock(Identifier, Orientation.WestUp),
            21533 => new JigsawBlock(Identifier, Orientation.EastUp),
            21534 => new JigsawBlock(Identifier, Orientation.NorthUp),
            21535 => new JigsawBlock(Identifier, Orientation.SouthUp),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Orientation = properties.ChildrenMap.ContainsKey("orientation") ? OrientationExtensions.FromString(properties["orientation"].GetString()) : Orientation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("orientation", Orientation.ToName())
        );
    }
    
}
