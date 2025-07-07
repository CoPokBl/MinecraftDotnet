using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TargetBlock(Identifier Identifier, int Power) : IBlock {

    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:target";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => true;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.target";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Power switch {
                0 => 20409,
                1 => 20410,
                2 => 20411,
                3 => 20412,
                4 => 20413,
                5 => 20414,
                6 => 20415,
                7 => 20416,
                8 => 20417,
                9 => 20418,
                10 => 20419,
                11 => 20420,
                12 => 20421,
                13 => 20422,
                14 => 20423,
                15 => 20424,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20409 => new TargetBlock(Identifier, 0),
            20410 => new TargetBlock(Identifier, 1),
            20411 => new TargetBlock(Identifier, 2),
            20412 => new TargetBlock(Identifier, 3),
            20413 => new TargetBlock(Identifier, 4),
            20414 => new TargetBlock(Identifier, 5),
            20415 => new TargetBlock(Identifier, 6),
            20416 => new TargetBlock(Identifier, 7),
            20417 => new TargetBlock(Identifier, 8),
            20418 => new TargetBlock(Identifier, 9),
            20419 => new TargetBlock(Identifier, 10),
            20420 => new TargetBlock(Identifier, 11),
            20421 => new TargetBlock(Identifier, 12),
            20422 => new TargetBlock(Identifier, 13),
            20423 => new TargetBlock(Identifier, 14),
            20424 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = int.Parse(properties["power"].GetString()),
        };
    }
    
}
