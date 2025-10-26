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
    public int ProtocolId => 1154;
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
                        true => 29407,
                        false => 29408,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 29409,
                        false => 29410,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 29411,
                        false => 29412,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 29413,
                        false => 29414,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 29415,
                        false => 29416,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 29417,
                        false => 29418,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 29419,
                        false => 29420,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 29421,
                        false => 29422,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 29423,
                        false => 29424,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 29425,
                        false => 29426,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 29427,
                        false => 29428,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 29429,
                        false => 29430,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
                false => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 29431,
                        false => 29432,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 29433,
                        false => 29434,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 29435,
                        false => 29436,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 29437,
                        false => 29438,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 29439,
                        false => 29440,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 29441,
                        false => 29442,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 29443,
                        false => 29444,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 29445,
                        false => 29446,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 29447,
                        false => 29448,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 29449,
                        false => 29450,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 29451,
                        false => 29452,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 29453,
                        false => 29454,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29407 => new CrafterBlock(Identifier, true, Orientation.DownEast, true),
            29408 => new CrafterBlock(Identifier, true, Orientation.DownEast, false),
            29409 => new CrafterBlock(Identifier, true, Orientation.DownNorth, true),
            29410 => new CrafterBlock(Identifier, true, Orientation.DownNorth, false),
            29411 => new CrafterBlock(Identifier, true, Orientation.DownSouth, true),
            29412 => new CrafterBlock(Identifier, true, Orientation.DownSouth, false),
            29413 => new CrafterBlock(Identifier, true, Orientation.DownWest, true),
            29414 => new CrafterBlock(Identifier, true, Orientation.DownWest, false),
            29415 => new CrafterBlock(Identifier, true, Orientation.UpEast, true),
            29416 => new CrafterBlock(Identifier, true, Orientation.UpEast, false),
            29417 => new CrafterBlock(Identifier, true, Orientation.UpNorth, true),
            29418 => new CrafterBlock(Identifier, true, Orientation.UpNorth, false),
            29419 => new CrafterBlock(Identifier, true, Orientation.UpSouth, true),
            29420 => new CrafterBlock(Identifier, true, Orientation.UpSouth, false),
            29421 => new CrafterBlock(Identifier, true, Orientation.UpWest, true),
            29422 => new CrafterBlock(Identifier, true, Orientation.UpWest, false),
            29423 => new CrafterBlock(Identifier, true, Orientation.WestUp, true),
            29424 => new CrafterBlock(Identifier, true, Orientation.WestUp, false),
            29425 => new CrafterBlock(Identifier, true, Orientation.EastUp, true),
            29426 => new CrafterBlock(Identifier, true, Orientation.EastUp, false),
            29427 => new CrafterBlock(Identifier, true, Orientation.NorthUp, true),
            29428 => new CrafterBlock(Identifier, true, Orientation.NorthUp, false),
            29429 => new CrafterBlock(Identifier, true, Orientation.SouthUp, true),
            29430 => new CrafterBlock(Identifier, true, Orientation.SouthUp, false),
            29431 => new CrafterBlock(Identifier, false, Orientation.DownEast, true),
            29432 => new CrafterBlock(Identifier, false, Orientation.DownEast, false),
            29433 => new CrafterBlock(Identifier, false, Orientation.DownNorth, true),
            29434 => new CrafterBlock(Identifier, false, Orientation.DownNorth, false),
            29435 => new CrafterBlock(Identifier, false, Orientation.DownSouth, true),
            29436 => new CrafterBlock(Identifier, false, Orientation.DownSouth, false),
            29437 => new CrafterBlock(Identifier, false, Orientation.DownWest, true),
            29438 => new CrafterBlock(Identifier, false, Orientation.DownWest, false),
            29439 => new CrafterBlock(Identifier, false, Orientation.UpEast, true),
            29440 => new CrafterBlock(Identifier, false, Orientation.UpEast, false),
            29441 => new CrafterBlock(Identifier, false, Orientation.UpNorth, true),
            29442 => new CrafterBlock(Identifier, false, Orientation.UpNorth, false),
            29443 => new CrafterBlock(Identifier, false, Orientation.UpSouth, true),
            29444 => new CrafterBlock(Identifier, false, Orientation.UpSouth, false),
            29445 => new CrafterBlock(Identifier, false, Orientation.UpWest, true),
            29446 => new CrafterBlock(Identifier, false, Orientation.UpWest, false),
            29447 => new CrafterBlock(Identifier, false, Orientation.WestUp, true),
            29448 => new CrafterBlock(Identifier, false, Orientation.WestUp, false),
            29449 => new CrafterBlock(Identifier, false, Orientation.EastUp, true),
            29450 => new CrafterBlock(Identifier, false, Orientation.EastUp, false),
            29451 => new CrafterBlock(Identifier, false, Orientation.NorthUp, true),
            29452 => new CrafterBlock(Identifier, false, Orientation.NorthUp, false),
            29453 => new CrafterBlock(Identifier, false, Orientation.SouthUp, true),
            29454 => new CrafterBlock(Identifier, false, Orientation.SouthUp, false),
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
