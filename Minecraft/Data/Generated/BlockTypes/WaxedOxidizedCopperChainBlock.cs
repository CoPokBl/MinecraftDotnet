using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperChainBlock(Identifier Identifier, Axis Axis, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:chain";
    public int ProtocolId => 357;
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_chain";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_chain";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => Waterlogged switch {
                    true => 8093,
                    false => 8094,
                },
                Axis.Y => Waterlogged switch {
                    true => 8095,
                    false => 8096,
                },
                Axis.Z => Waterlogged switch {
                    true => 8097,
                    false => 8098,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8093 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.X, true),
            8094 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.X, false),
            8095 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Y, true),
            8096 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Y, false),
            8097 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Z, true),
            8098 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Z, false),
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
