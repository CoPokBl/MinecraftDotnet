using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrafterBlock(Identifier Identifier, bool Crafting, Orientation Orientation, bool Triggered) : IBlock {

    public Identifier Category => "minecraft:crafter";
    public double Hardness => 1.5;
    public double ExplosionResistance => 3.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:crafter";
    public Identifier? Item => "minecraft:crafter";
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
    public string TranslationKey => "block.minecraft.crafter";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Crafting switch {
                true => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 27650,
                        false => 27651,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 27652,
                        false => 27653,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 27654,
                        false => 27655,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 27656,
                        false => 27657,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 27658,
                        false => 27659,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 27660,
                        false => 27661,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 27662,
                        false => 27663,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 27664,
                        false => 27665,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 27666,
                        false => 27667,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 27668,
                        false => 27669,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 27670,
                        false => 27671,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 27672,
                        false => 27673,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
                false => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 27674,
                        false => 27675,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 27676,
                        false => 27677,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 27678,
                        false => 27679,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 27680,
                        false => 27681,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 27682,
                        false => 27683,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 27684,
                        false => 27685,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 27686,
                        false => 27687,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 27688,
                        false => 27689,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 27690,
                        false => 27691,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 27692,
                        false => 27693,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 27694,
                        false => 27695,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 27696,
                        false => 27697,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27650 => new CrafterBlock(Identifier, true, Orientation.DownEast, true),
            27651 => new CrafterBlock(Identifier, true, Orientation.DownEast, false),
            27652 => new CrafterBlock(Identifier, true, Orientation.DownNorth, true),
            27653 => new CrafterBlock(Identifier, true, Orientation.DownNorth, false),
            27654 => new CrafterBlock(Identifier, true, Orientation.DownSouth, true),
            27655 => new CrafterBlock(Identifier, true, Orientation.DownSouth, false),
            27656 => new CrafterBlock(Identifier, true, Orientation.DownWest, true),
            27657 => new CrafterBlock(Identifier, true, Orientation.DownWest, false),
            27658 => new CrafterBlock(Identifier, true, Orientation.UpEast, true),
            27659 => new CrafterBlock(Identifier, true, Orientation.UpEast, false),
            27660 => new CrafterBlock(Identifier, true, Orientation.UpNorth, true),
            27661 => new CrafterBlock(Identifier, true, Orientation.UpNorth, false),
            27662 => new CrafterBlock(Identifier, true, Orientation.UpSouth, true),
            27663 => new CrafterBlock(Identifier, true, Orientation.UpSouth, false),
            27664 => new CrafterBlock(Identifier, true, Orientation.UpWest, true),
            27665 => new CrafterBlock(Identifier, true, Orientation.UpWest, false),
            27666 => new CrafterBlock(Identifier, true, Orientation.WestUp, true),
            27667 => new CrafterBlock(Identifier, true, Orientation.WestUp, false),
            27668 => new CrafterBlock(Identifier, true, Orientation.EastUp, true),
            27669 => new CrafterBlock(Identifier, true, Orientation.EastUp, false),
            27670 => new CrafterBlock(Identifier, true, Orientation.NorthUp, true),
            27671 => new CrafterBlock(Identifier, true, Orientation.NorthUp, false),
            27672 => new CrafterBlock(Identifier, true, Orientation.SouthUp, true),
            27673 => new CrafterBlock(Identifier, true, Orientation.SouthUp, false),
            27674 => new CrafterBlock(Identifier, false, Orientation.DownEast, true),
            27675 => new CrafterBlock(Identifier, false, Orientation.DownEast, false),
            27676 => new CrafterBlock(Identifier, false, Orientation.DownNorth, true),
            27677 => new CrafterBlock(Identifier, false, Orientation.DownNorth, false),
            27678 => new CrafterBlock(Identifier, false, Orientation.DownSouth, true),
            27679 => new CrafterBlock(Identifier, false, Orientation.DownSouth, false),
            27680 => new CrafterBlock(Identifier, false, Orientation.DownWest, true),
            27681 => new CrafterBlock(Identifier, false, Orientation.DownWest, false),
            27682 => new CrafterBlock(Identifier, false, Orientation.UpEast, true),
            27683 => new CrafterBlock(Identifier, false, Orientation.UpEast, false),
            27684 => new CrafterBlock(Identifier, false, Orientation.UpNorth, true),
            27685 => new CrafterBlock(Identifier, false, Orientation.UpNorth, false),
            27686 => new CrafterBlock(Identifier, false, Orientation.UpSouth, true),
            27687 => new CrafterBlock(Identifier, false, Orientation.UpSouth, false),
            27688 => new CrafterBlock(Identifier, false, Orientation.UpWest, true),
            27689 => new CrafterBlock(Identifier, false, Orientation.UpWest, false),
            27690 => new CrafterBlock(Identifier, false, Orientation.WestUp, true),
            27691 => new CrafterBlock(Identifier, false, Orientation.WestUp, false),
            27692 => new CrafterBlock(Identifier, false, Orientation.EastUp, true),
            27693 => new CrafterBlock(Identifier, false, Orientation.EastUp, false),
            27694 => new CrafterBlock(Identifier, false, Orientation.NorthUp, true),
            27695 => new CrafterBlock(Identifier, false, Orientation.NorthUp, false),
            27696 => new CrafterBlock(Identifier, false, Orientation.SouthUp, true),
            27697 => new CrafterBlock(Identifier, false, Orientation.SouthUp, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Crafting = properties["crafting"].GetString() == "true",
            Orientation = OrientationExtensions.FromString(properties["orientation"].GetString()),
            Triggered = properties["triggered"].GetString() == "true",
        };
    }
    
}
