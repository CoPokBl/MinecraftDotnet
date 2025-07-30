using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DropperBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock {

    public Identifier Category => "minecraft:dropper";
    public int ProtocolId => 451;
    public double Hardness => 3.5;
    public double ExplosionResistance => 3.5;
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
    public Identifier? BlockEntity => "minecraft:dropper";
    public Identifier? Item => "minecraft:dropper";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.dropper";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Triggered switch {
                    true => 10153,
                    false => 10154,
                },
                Cardinal.East => Triggered switch {
                    true => 10155,
                    false => 10156,
                },
                Cardinal.South => Triggered switch {
                    true => 10157,
                    false => 10158,
                },
                Cardinal.West => Triggered switch {
                    true => 10159,
                    false => 10160,
                },
                Cardinal.Up => Triggered switch {
                    true => 10161,
                    false => 10162,
                },
                Cardinal.Down => Triggered switch {
                    true => 10163,
                    false => 10164,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10153 => new DropperBlock(Identifier, Cardinal.North, true),
            10154 => new DropperBlock(Identifier, Cardinal.North, false),
            10155 => new DropperBlock(Identifier, Cardinal.East, true),
            10156 => new DropperBlock(Identifier, Cardinal.East, false),
            10157 => new DropperBlock(Identifier, Cardinal.South, true),
            10158 => new DropperBlock(Identifier, Cardinal.South, false),
            10159 => new DropperBlock(Identifier, Cardinal.West, true),
            10160 => new DropperBlock(Identifier, Cardinal.West, false),
            10161 => new DropperBlock(Identifier, Cardinal.Up, true),
            10162 => new DropperBlock(Identifier, Cardinal.Up, false),
            10163 => new DropperBlock(Identifier, Cardinal.Down, true),
            10164 => new DropperBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Triggered = properties["triggered"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("facing", Facing.ToName()),
            new StringTag("triggered", Triggered.ToString().ToLower())
        );
    }
    
}
