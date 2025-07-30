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
    public int ProtocolId => 866;
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
                Orientation.DownEast => 20415,
                Orientation.DownNorth => 20416,
                Orientation.DownSouth => 20417,
                Orientation.DownWest => 20418,
                Orientation.UpEast => 20419,
                Orientation.UpNorth => 20420,
                Orientation.UpSouth => 20421,
                Orientation.UpWest => 20422,
                Orientation.WestUp => 20423,
                Orientation.EastUp => 20424,
                Orientation.NorthUp => 20425,
                Orientation.SouthUp => 20426,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20415 => new JigsawBlock(Identifier, Orientation.DownEast),
            20416 => new JigsawBlock(Identifier, Orientation.DownNorth),
            20417 => new JigsawBlock(Identifier, Orientation.DownSouth),
            20418 => new JigsawBlock(Identifier, Orientation.DownWest),
            20419 => new JigsawBlock(Identifier, Orientation.UpEast),
            20420 => new JigsawBlock(Identifier, Orientation.UpNorth),
            20421 => new JigsawBlock(Identifier, Orientation.UpSouth),
            20422 => new JigsawBlock(Identifier, Orientation.UpWest),
            20423 => new JigsawBlock(Identifier, Orientation.WestUp),
            20424 => new JigsawBlock(Identifier, Orientation.EastUp),
            20425 => new JigsawBlock(Identifier, Orientation.NorthUp),
            20426 => new JigsawBlock(Identifier, Orientation.SouthUp),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Orientation = OrientationExtensions.FromString(properties["orientation"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("orientation", Orientation.ToName())
        );
    }
    
}
