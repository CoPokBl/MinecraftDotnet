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
                Orientation.DownEast => 21726,
                Orientation.DownNorth => 21727,
                Orientation.DownSouth => 21728,
                Orientation.DownWest => 21729,
                Orientation.UpEast => 21730,
                Orientation.UpNorth => 21731,
                Orientation.UpSouth => 21732,
                Orientation.UpWest => 21733,
                Orientation.WestUp => 21734,
                Orientation.EastUp => 21735,
                Orientation.NorthUp => 21736,
                Orientation.SouthUp => 21737,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21726 => new JigsawBlock(Identifier, Orientation.DownEast),
            21727 => new JigsawBlock(Identifier, Orientation.DownNorth),
            21728 => new JigsawBlock(Identifier, Orientation.DownSouth),
            21729 => new JigsawBlock(Identifier, Orientation.DownWest),
            21730 => new JigsawBlock(Identifier, Orientation.UpEast),
            21731 => new JigsawBlock(Identifier, Orientation.UpNorth),
            21732 => new JigsawBlock(Identifier, Orientation.UpSouth),
            21733 => new JigsawBlock(Identifier, Orientation.UpWest),
            21734 => new JigsawBlock(Identifier, Orientation.WestUp),
            21735 => new JigsawBlock(Identifier, Orientation.EastUp),
            21736 => new JigsawBlock(Identifier, Orientation.NorthUp),
            21737 => new JigsawBlock(Identifier, Orientation.SouthUp),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Orientation = properties.Contains("orientation") ? OrientationExtensions.FromString(properties["orientation"].GetString()) : Orientation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("orientation", new StringTag(Orientation.ToName()))
        );
    }
    
}
