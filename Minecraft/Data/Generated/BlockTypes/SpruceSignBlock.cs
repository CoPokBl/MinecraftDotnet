using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 210;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:spruce_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5166,
                    false => 5167,
                },
                1 => Waterlogged switch {
                    true => 5168,
                    false => 5169,
                },
                2 => Waterlogged switch {
                    true => 5170,
                    false => 5171,
                },
                3 => Waterlogged switch {
                    true => 5172,
                    false => 5173,
                },
                4 => Waterlogged switch {
                    true => 5174,
                    false => 5175,
                },
                5 => Waterlogged switch {
                    true => 5176,
                    false => 5177,
                },
                6 => Waterlogged switch {
                    true => 5178,
                    false => 5179,
                },
                7 => Waterlogged switch {
                    true => 5180,
                    false => 5181,
                },
                8 => Waterlogged switch {
                    true => 5182,
                    false => 5183,
                },
                9 => Waterlogged switch {
                    true => 5184,
                    false => 5185,
                },
                10 => Waterlogged switch {
                    true => 5186,
                    false => 5187,
                },
                11 => Waterlogged switch {
                    true => 5188,
                    false => 5189,
                },
                12 => Waterlogged switch {
                    true => 5190,
                    false => 5191,
                },
                13 => Waterlogged switch {
                    true => 5192,
                    false => 5193,
                },
                14 => Waterlogged switch {
                    true => 5194,
                    false => 5195,
                },
                15 => Waterlogged switch {
                    true => 5196,
                    false => 5197,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5166 => new SpruceSignBlock(Identifier, 0, true),
            5167 => new SpruceSignBlock(Identifier, 0, false),
            5168 => new SpruceSignBlock(Identifier, 1, true),
            5169 => new SpruceSignBlock(Identifier, 1, false),
            5170 => new SpruceSignBlock(Identifier, 2, true),
            5171 => new SpruceSignBlock(Identifier, 2, false),
            5172 => new SpruceSignBlock(Identifier, 3, true),
            5173 => new SpruceSignBlock(Identifier, 3, false),
            5174 => new SpruceSignBlock(Identifier, 4, true),
            5175 => new SpruceSignBlock(Identifier, 4, false),
            5176 => new SpruceSignBlock(Identifier, 5, true),
            5177 => new SpruceSignBlock(Identifier, 5, false),
            5178 => new SpruceSignBlock(Identifier, 6, true),
            5179 => new SpruceSignBlock(Identifier, 6, false),
            5180 => new SpruceSignBlock(Identifier, 7, true),
            5181 => new SpruceSignBlock(Identifier, 7, false),
            5182 => new SpruceSignBlock(Identifier, 8, true),
            5183 => new SpruceSignBlock(Identifier, 8, false),
            5184 => new SpruceSignBlock(Identifier, 9, true),
            5185 => new SpruceSignBlock(Identifier, 9, false),
            5186 => new SpruceSignBlock(Identifier, 10, true),
            5187 => new SpruceSignBlock(Identifier, 10, false),
            5188 => new SpruceSignBlock(Identifier, 11, true),
            5189 => new SpruceSignBlock(Identifier, 11, false),
            5190 => new SpruceSignBlock(Identifier, 12, true),
            5191 => new SpruceSignBlock(Identifier, 12, false),
            5192 => new SpruceSignBlock(Identifier, 13, true),
            5193 => new SpruceSignBlock(Identifier, 13, false),
            5194 => new SpruceSignBlock(Identifier, 14, true),
            5195 => new SpruceSignBlock(Identifier, 14, false),
            5196 => new SpruceSignBlock(Identifier, 15, true),
            5197 => new SpruceSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
