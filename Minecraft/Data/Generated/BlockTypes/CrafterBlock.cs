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
    public int ProtocolId => 1093;
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
                        true => 27682,
                        false => 27683,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 27684,
                        false => 27685,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 27686,
                        false => 27687,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 27688,
                        false => 27689,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 27690,
                        false => 27691,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 27692,
                        false => 27693,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 27694,
                        false => 27695,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 27696,
                        false => 27697,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 27698,
                        false => 27699,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 27700,
                        false => 27701,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 27702,
                        false => 27703,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 27704,
                        false => 27705,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
                false => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 27706,
                        false => 27707,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 27708,
                        false => 27709,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 27710,
                        false => 27711,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 27712,
                        false => 27713,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 27714,
                        false => 27715,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 27716,
                        false => 27717,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 27718,
                        false => 27719,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 27720,
                        false => 27721,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 27722,
                        false => 27723,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 27724,
                        false => 27725,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 27726,
                        false => 27727,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 27728,
                        false => 27729,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27682 => new CrafterBlock(Identifier, true, Orientation.DownEast, true),
            27683 => new CrafterBlock(Identifier, true, Orientation.DownEast, false),
            27684 => new CrafterBlock(Identifier, true, Orientation.DownNorth, true),
            27685 => new CrafterBlock(Identifier, true, Orientation.DownNorth, false),
            27686 => new CrafterBlock(Identifier, true, Orientation.DownSouth, true),
            27687 => new CrafterBlock(Identifier, true, Orientation.DownSouth, false),
            27688 => new CrafterBlock(Identifier, true, Orientation.DownWest, true),
            27689 => new CrafterBlock(Identifier, true, Orientation.DownWest, false),
            27690 => new CrafterBlock(Identifier, true, Orientation.UpEast, true),
            27691 => new CrafterBlock(Identifier, true, Orientation.UpEast, false),
            27692 => new CrafterBlock(Identifier, true, Orientation.UpNorth, true),
            27693 => new CrafterBlock(Identifier, true, Orientation.UpNorth, false),
            27694 => new CrafterBlock(Identifier, true, Orientation.UpSouth, true),
            27695 => new CrafterBlock(Identifier, true, Orientation.UpSouth, false),
            27696 => new CrafterBlock(Identifier, true, Orientation.UpWest, true),
            27697 => new CrafterBlock(Identifier, true, Orientation.UpWest, false),
            27698 => new CrafterBlock(Identifier, true, Orientation.WestUp, true),
            27699 => new CrafterBlock(Identifier, true, Orientation.WestUp, false),
            27700 => new CrafterBlock(Identifier, true, Orientation.EastUp, true),
            27701 => new CrafterBlock(Identifier, true, Orientation.EastUp, false),
            27702 => new CrafterBlock(Identifier, true, Orientation.NorthUp, true),
            27703 => new CrafterBlock(Identifier, true, Orientation.NorthUp, false),
            27704 => new CrafterBlock(Identifier, true, Orientation.SouthUp, true),
            27705 => new CrafterBlock(Identifier, true, Orientation.SouthUp, false),
            27706 => new CrafterBlock(Identifier, false, Orientation.DownEast, true),
            27707 => new CrafterBlock(Identifier, false, Orientation.DownEast, false),
            27708 => new CrafterBlock(Identifier, false, Orientation.DownNorth, true),
            27709 => new CrafterBlock(Identifier, false, Orientation.DownNorth, false),
            27710 => new CrafterBlock(Identifier, false, Orientation.DownSouth, true),
            27711 => new CrafterBlock(Identifier, false, Orientation.DownSouth, false),
            27712 => new CrafterBlock(Identifier, false, Orientation.DownWest, true),
            27713 => new CrafterBlock(Identifier, false, Orientation.DownWest, false),
            27714 => new CrafterBlock(Identifier, false, Orientation.UpEast, true),
            27715 => new CrafterBlock(Identifier, false, Orientation.UpEast, false),
            27716 => new CrafterBlock(Identifier, false, Orientation.UpNorth, true),
            27717 => new CrafterBlock(Identifier, false, Orientation.UpNorth, false),
            27718 => new CrafterBlock(Identifier, false, Orientation.UpSouth, true),
            27719 => new CrafterBlock(Identifier, false, Orientation.UpSouth, false),
            27720 => new CrafterBlock(Identifier, false, Orientation.UpWest, true),
            27721 => new CrafterBlock(Identifier, false, Orientation.UpWest, false),
            27722 => new CrafterBlock(Identifier, false, Orientation.WestUp, true),
            27723 => new CrafterBlock(Identifier, false, Orientation.WestUp, false),
            27724 => new CrafterBlock(Identifier, false, Orientation.EastUp, true),
            27725 => new CrafterBlock(Identifier, false, Orientation.EastUp, false),
            27726 => new CrafterBlock(Identifier, false, Orientation.NorthUp, true),
            27727 => new CrafterBlock(Identifier, false, Orientation.NorthUp, false),
            27728 => new CrafterBlock(Identifier, false, Orientation.SouthUp, true),
            27729 => new CrafterBlock(Identifier, false, Orientation.SouthUp, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Crafting = properties.ChildrenMap.ContainsKey("crafting") ? properties["crafting"].GetString() == "true" : Crafting,
            Orientation = properties.ChildrenMap.ContainsKey("orientation") ? OrientationExtensions.FromString(properties["orientation"].GetString()) : Orientation,
            Triggered = properties.ChildrenMap.ContainsKey("triggered") ? properties["triggered"].GetString() == "true" : Triggered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("crafting", Crafting.ToString().ToLower()),
            new StringTag("orientation", Orientation.ToName()),
            new StringTag("triggered", Triggered.ToString().ToLower())
        );
    }
    
}
