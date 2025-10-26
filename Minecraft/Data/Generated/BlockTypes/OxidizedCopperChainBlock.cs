using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperChainBlock(Identifier Identifier, Axis Axis, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chain";
    public int ProtocolId => 353;
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
    public Identifier? Item => "minecraft:oxidized_copper_chain";
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
    public string TranslationKey => "block.minecraft.oxidized_copper_chain";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => Waterlogged switch {
                    true => 8069,
                    false => 8070,
                },
                Axis.Y => Waterlogged switch {
                    true => 8071,
                    false => 8072,
                },
                Axis.Z => Waterlogged switch {
                    true => 8073,
                    false => 8074,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8069 => new OxidizedCopperChainBlock(Identifier, Axis.X, true),
            8070 => new OxidizedCopperChainBlock(Identifier, Axis.X, false),
            8071 => new OxidizedCopperChainBlock(Identifier, Axis.Y, true),
            8072 => new OxidizedCopperChainBlock(Identifier, Axis.Y, false),
            8073 => new OxidizedCopperChainBlock(Identifier, Axis.Z, true),
            8074 => new OxidizedCopperChainBlock(Identifier, Axis.Z, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.ChildrenMap.ContainsKey("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("axis", Axis.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
