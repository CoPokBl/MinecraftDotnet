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
    public int ProtocolId => 481;
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
                    true => 11230,
                    false => 11231,
                },
                Cardinal.East => Triggered switch {
                    true => 11232,
                    false => 11233,
                },
                Cardinal.South => Triggered switch {
                    true => 11234,
                    false => 11235,
                },
                Cardinal.West => Triggered switch {
                    true => 11236,
                    false => 11237,
                },
                Cardinal.Up => Triggered switch {
                    true => 11238,
                    false => 11239,
                },
                Cardinal.Down => Triggered switch {
                    true => 11240,
                    false => 11241,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11230 => new DropperBlock(Identifier, Cardinal.North, true),
            11231 => new DropperBlock(Identifier, Cardinal.North, false),
            11232 => new DropperBlock(Identifier, Cardinal.East, true),
            11233 => new DropperBlock(Identifier, Cardinal.East, false),
            11234 => new DropperBlock(Identifier, Cardinal.South, true),
            11235 => new DropperBlock(Identifier, Cardinal.South, false),
            11236 => new DropperBlock(Identifier, Cardinal.West, true),
            11237 => new DropperBlock(Identifier, Cardinal.West, false),
            11238 => new DropperBlock(Identifier, Cardinal.Up, true),
            11239 => new DropperBlock(Identifier, Cardinal.Up, false),
            11240 => new DropperBlock(Identifier, Cardinal.Down, true),
            11241 => new DropperBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Triggered = properties.ChildrenMap.ContainsKey("triggered") ? properties["triggered"].GetString() == "true" : Triggered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("triggered", Triggered.ToString().ToLower())
        );
    }
    
}
