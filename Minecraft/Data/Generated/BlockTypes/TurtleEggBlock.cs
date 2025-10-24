using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TurtleEggBlock(Identifier Identifier, int Eggs, int Hatch) : IBlock {
    public Identifier Category => "minecraft:turtle_egg";
    public int ProtocolId => 743;
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "metal";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:turtle_egg";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.75, 0.4375, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.75, 0.4375, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.75, 0.4375, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.turtle_egg";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Eggs switch {
                1 => Hatch switch {
                    0 => 14888,
                    1 => 14889,
                    2 => 14890,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                2 => Hatch switch {
                    0 => 14891,
                    1 => 14892,
                    2 => 14893,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                3 => Hatch switch {
                    0 => 14894,
                    1 => 14895,
                    2 => 14896,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                4 => Hatch switch {
                    0 => 14897,
                    1 => 14898,
                    2 => 14899,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Eggs), Eggs, "Unknown value for property eggs.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14888 => new TurtleEggBlock(Identifier, 1, 0),
            14889 => new TurtleEggBlock(Identifier, 1, 1),
            14890 => new TurtleEggBlock(Identifier, 1, 2),
            14891 => new TurtleEggBlock(Identifier, 2, 0),
            14892 => new TurtleEggBlock(Identifier, 2, 1),
            14893 => new TurtleEggBlock(Identifier, 2, 2),
            14894 => new TurtleEggBlock(Identifier, 3, 0),
            14895 => new TurtleEggBlock(Identifier, 3, 1),
            14896 => new TurtleEggBlock(Identifier, 3, 2),
            14897 => new TurtleEggBlock(Identifier, 4, 0),
            14898 => new TurtleEggBlock(Identifier, 4, 1),
            14899 => new TurtleEggBlock(Identifier, 4, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eggs = properties.ChildrenMap.ContainsKey("eggs") ? int.Parse(properties["eggs"].GetString()) : Eggs,
            Hatch = properties.ChildrenMap.ContainsKey("hatch") ? int.Parse(properties["hatch"].GetString()) : Hatch,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("eggs", Eggs.ToString()),
            new StringTag("hatch", Hatch.ToString())
        );
    }
    
}
