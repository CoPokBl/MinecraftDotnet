using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperChainBlock(Identifier Identifier, Axis Axis, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chain";
    public double Hardness => 5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "chain";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:copper_chain";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.40625, 0.0, 0.40625] -> [0.59375, 1.0, 0.59375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.40625, 0.0, 0.40625] -> [0.59375, 1.0, 0.59375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.40625, 0.0, 0.40625] -> [0.59375, 1.0, 0.59375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.copper_chain";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => Waterlogged switch {
                    true => 8252,
                    false => 8253,
                },
                Axis.Y => Waterlogged switch {
                    true => 8254,
                    false => 8255,
                },
                Axis.Z => Waterlogged switch {
                    true => 8256,
                    false => 8257,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8252 => new CopperChainBlock(Identifier, Axis.X, true),
            8253 => new CopperChainBlock(Identifier, Axis.X, false),
            8254 => new CopperChainBlock(Identifier, Axis.Y, true),
            8255 => new CopperChainBlock(Identifier, Axis.Y, false),
            8256 => new CopperChainBlock(Identifier, Axis.Z, true),
            8257 => new CopperChainBlock(Identifier, Axis.Z, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.Contains("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("axis", new StringTag(Axis.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
