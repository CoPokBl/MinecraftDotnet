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
                Orientation.DownEast => 20383,
                Orientation.DownNorth => 20384,
                Orientation.DownSouth => 20385,
                Orientation.DownWest => 20386,
                Orientation.UpEast => 20387,
                Orientation.UpNorth => 20388,
                Orientation.UpSouth => 20389,
                Orientation.UpWest => 20390,
                Orientation.WestUp => 20391,
                Orientation.EastUp => 20392,
                Orientation.NorthUp => 20393,
                Orientation.SouthUp => 20394,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20383 => new JigsawBlock(Identifier, Orientation.DownEast),
            20384 => new JigsawBlock(Identifier, Orientation.DownNorth),
            20385 => new JigsawBlock(Identifier, Orientation.DownSouth),
            20386 => new JigsawBlock(Identifier, Orientation.DownWest),
            20387 => new JigsawBlock(Identifier, Orientation.UpEast),
            20388 => new JigsawBlock(Identifier, Orientation.UpNorth),
            20389 => new JigsawBlock(Identifier, Orientation.UpSouth),
            20390 => new JigsawBlock(Identifier, Orientation.UpWest),
            20391 => new JigsawBlock(Identifier, Orientation.WestUp),
            20392 => new JigsawBlock(Identifier, Orientation.EastUp),
            20393 => new JigsawBlock(Identifier, Orientation.NorthUp),
            20394 => new JigsawBlock(Identifier, Orientation.SouthUp),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Orientation = OrientationExtensions.FromString(properties["orientation"].GetString()),
        };
    }
    
}
