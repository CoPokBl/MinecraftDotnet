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
                    0 => 15090,
                    1 => 15091,
                    2 => 15092,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                2 => Hatch switch {
                    0 => 15093,
                    1 => 15094,
                    2 => 15095,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                3 => Hatch switch {
                    0 => 15096,
                    1 => 15097,
                    2 => 15098,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                4 => Hatch switch {
                    0 => 15099,
                    1 => 15100,
                    2 => 15101,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Eggs), Eggs, "Unknown value for property eggs.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15090 => new TurtleEggBlock(Identifier, 1, 0),
            15091 => new TurtleEggBlock(Identifier, 1, 1),
            15092 => new TurtleEggBlock(Identifier, 1, 2),
            15093 => new TurtleEggBlock(Identifier, 2, 0),
            15094 => new TurtleEggBlock(Identifier, 2, 1),
            15095 => new TurtleEggBlock(Identifier, 2, 2),
            15096 => new TurtleEggBlock(Identifier, 3, 0),
            15097 => new TurtleEggBlock(Identifier, 3, 1),
            15098 => new TurtleEggBlock(Identifier, 3, 2),
            15099 => new TurtleEggBlock(Identifier, 4, 0),
            15100 => new TurtleEggBlock(Identifier, 4, 1),
            15101 => new TurtleEggBlock(Identifier, 4, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eggs = properties.Contains("eggs") ? int.Parse(properties["eggs"].GetString()) : Eggs,
            Hatch = properties.Contains("hatch") ? int.Parse(properties["hatch"].GetString()) : Hatch,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("eggs", new StringTag(Eggs.ToString())),
            ("hatch", new StringTag(Hatch.ToString()))
        );
    }
    
}
