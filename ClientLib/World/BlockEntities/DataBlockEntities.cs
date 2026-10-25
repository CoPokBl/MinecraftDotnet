using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace ClientLib.World.BlockEntities;

/// <summary><c>SignText</c>: four lines, their filtered copies, the dye and whether a glow ink sac has been used.</summary>
public sealed record SignText(TextComponent[] Messages, TextComponent[] FilteredMessages, DyeColor Color, bool HasGlowingText) {
    public static readonly SignText Empty = new(EmptyLines(), EmptyLines(), DyeColor.Black, false);

    private static TextComponent[] EmptyLines() => [TextComponent.Empty(), TextComponent.Empty(), TextComponent.Empty(), TextComponent.Empty()];

    public TextComponent[] GetMessages(bool shouldFilter) => shouldFilter ? FilteredMessages : Messages;

    public TextComponent GetMessage(int line, bool shouldFilter) => GetMessages(shouldFilter)[line];

    /// <summary><c>setMessage(int, Component)</c>: one line, filtered and not, in a new text.</summary>
    public SignText SetMessage(int line, TextComponent message) {
        TextComponent[] messages = (TextComponent[])Messages.Clone(), filtered = (TextComponent[])FilteredMessages.Clone();
        messages[line] = message;
        filtered[line] = message;
        return this with { Messages = messages, FilteredMessages = filtered };
    }

    /// <summary><c>DIRECT_CODEC</c>; the empty text when the tag is not one, as <c>orElseGet(SignText::new)</c>.</summary>
    public static SignText Read(INbtTag? tag) {
        if (tag is not CompoundTag compound || Lines(compound["messages"]) is not { } messages) {
            return Empty;
        }
        TextComponent[] filtered = Lines(compound["filtered_messages"]) ?? messages;
        DyeColor color = compound["color"] is StringTag name && Enum.TryParse(name.Value.Replace("_", ""), true, out DyeColor parsed) ? parsed : DyeColor.Black;
        bool glowing = compound["has_glowing_text"] is { } glow && glow.GetBoolean();
        return new SignText(messages, filtered, color, glowing);
    }

    /// <summary><c>LINES_CODEC</c>: exactly four components.</summary>
    private static TextComponent[]? Lines(INbtTag? tag) {
        if (tag is not ListTag list || list.Tags.Length != 4) {
            return null;
        }
        try {
            return list.Tags.ToArray().Select(TextComponent.FromTag).ToArray();
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            // FromTag throws a bare Exception for content it does not know; the codec would fail the same way.
            return null;
        }
    }
}

/// <summary><c>SignBlockEntity</c> and <c>HangingSignBlockEntity</c>.</summary>
public sealed class SignBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public SignText FrontText { get; private set; } = SignText.Empty;
    public SignText BackText { get; private set; } = SignText.Empty;

    public bool IsHanging => Is(BlockEntityType.HangingSign);

    public int TextLineHeight => IsHanging ? 9 : 10;
    public int MaxTextLineWidth => IsHanging ? 60 : 90;

    public SignText GetText(bool isFrontText) => isFrontText ? FrontText : BackText;

    /// <summary><c>setText</c>, as the editor does to show what is typed before the server has it.</summary>
    public void SetText(SignText text, bool isFrontText) {
        if (isFrontText) {
            FrontText = text;
        }
        else {
            BackText = text;
        }
    }

    /// <summary>
    /// <c>playerIsTooFarAwayToEdit</c> for the local player, the one the editor asks about:
    /// <c>Player.isWithinBlockInteractionRange(pos, 4.0)</c>, the block's box against the eyes.
    /// </summary>
    public bool PlayerIsTooFarAwayToEdit(Player.LocalPlayer? player) {
        if (player == null) {
            return true;
        }
        double maxRange = player.Attributes.Value(Minecraft.Data.Generated.Attribute.BlockInteractionRange) + 4.0;
        Maths.Vec3d eye = Interaction.Picking.EyePosition(player, 1.0F);
        double dx = Math.Max(Math.Max(X - eye.X, eye.X - (X + 1)), 0.0);
        double dy = Math.Max(Math.Max(Y - eye.Y, eye.Y - (Y + 1)), 0.0);
        double dz = Math.Max(Math.Max(Z - eye.Z, eye.Z - (Z + 1)), 0.0);
        return !(dx * dx + dy * dy + dz * dz < maxRange * maxRange);
    }

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        FrontText = SignText.Read(tag["front_text"]);
        BackText = SignText.Read(tag["back_text"]);
    }
}

/// <summary><c>BannerBlockEntity</c>: the colour is the block's, the patterns the tag's.</summary>
public sealed class BannerBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public BannerPatternsComponent.Layer[] Patterns { get; private set; } = [];

    public DyeColor BaseColor => DyedBlocks.BannerColor(State)?.Color ?? DyeColor.White;

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        Patterns = tag["patterns"] is { } patterns ? Decode<BannerPatternsComponent.Layer[]>(() => DataComponent.BannerPatterns.FromNbt(patterns, registry)) ?? [] : [];
    }

    internal static T? Decode<T>(Func<object> read) where T : class {
        try {
            return read() as T;
        }
        catch (Exception e) when (e is InvalidOperationException or ArgumentException or KeyNotFoundException or InvalidCastException) {
            return null;
        }
    }
}

/// <summary><c>DecoratedPotBlockEntity</c>: the sherds, and the wobble a hit starts.</summary>
public sealed class DecoratedPotBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public enum WobbleStyle { Positive, Negative }

    /// <summary><c>WobbleStyle.duration</c>.</summary>
    public static int Duration(WobbleStyle style) => style == WobbleStyle.Positive ? 7 : 10;

    /// <summary><c>PotDecorations</c> in back, left, right, front order; null for a side with no sherd, which a brick also is.</summary>
    public IItem?[] Sherds { get; private set; } = new IItem?[4];

    public long WobbleStartedAtTick;
    public WobbleStyle? LastWobbleStyle;

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        IItem[] items = tag["sherds"] is { } sherds ? BannerBlockEntity.Decode<IItem[]>(() => DataComponent.PotDecorations.FromNbt(sherds, registry)) ?? [] : [];
        Sherds = Decorations(items);
    }

    /// <summary><c>new PotDecorations(List)</c>.</summary>
    public static IItem?[] Decorations(IReadOnlyList<IItem> items) {
        IItem?[] sides = new IItem?[4];
        for (int i = 0; i < 4 && i < items.Count; i++) {
            sides[i] = items[i].Identifier.Equals(Item.Brick.Identifier) ? null : items[i];
        }
        return sides;
    }

    public override bool TriggerEvent(int b0, int b1) {
        if (Level != null && b0 == 1 && b1 >= 0 && b1 < 2) {
            WobbleStartedAtTick = Level.GameTime;
            LastWobbleStyle = (WobbleStyle)b1;
            return true;
        }
        return false;
    }

    public Direction Direction => State is Minecraft.Data.Blocks.Properties.IHorizontalFacing facing ? facing.Facing : Direction.North;
}

/// <summary><c>CampfireBlockEntity</c> and <c>ShelfBlockEntity</c>: items laid out by slot.</summary>
public sealed class ItemDisplayBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public ItemStack[] Items { get; private set; } = Empty(type);

    /// <summary><c>ShelfBlockEntity.getAlignItemsToBottom</c>.</summary>
    public bool AlignItemsToBottom { get; private set; }

    private static ItemStack[] Empty(IBlockEntityType type) =>
        Enumerable.Repeat(ItemStack.Air, type.Identifier.Equals(BlockEntityType.Shelf.Identifier) ? 3 : 4).ToArray();

    /// <summary><c>CampfireBlock.getTicker</c>: a lit campfire's client ticker is its <c>particleTick</c>.</summary>
    public override bool HasClientTicker => Type.Identifier.Equals(BlockEntityType.Campfire.Identifier) && State is Minecraft.Data.Blocks.Properties.ILit { Lit: true };

    /// <summary><c>CampfireBlockEntity.particleTick</c>: smoke columns now and then, and smoke off each cooking item.</summary>
    public override void Tick(BlockEntityTickContext context) {
        if (context.Particles is not { } particles) {
            return;
        }
        Particles.ParticleRandom random = particles.Random;
        bool signalFire = State is Minecraft.Data.Blocks.Properties.ISignalFire { SignalFire: true };
        if (random.NextFloat() < 0.11F) {
            int columns = random.NextInt(2) + 2;
            for (int i = 0; i < columns; i++) {
                particles.CampfireSmoke(X, Y, Z, signalFire, false);
            }
        }
        // Direction.get2DDataValue of the facing: south, west, north, east.
        int rotation = State is Minecraft.Data.Blocks.Properties.IHorizontalFacing facing ? facing.Facing switch {
            Direction.South => 0,
            Direction.West => 1,
            Direction.North => 2,
            _ => 3
        } : 2;
        for (int slot = 0; slot < Items.Length; slot++) {
            if (Items[slot].IsAir() || random.NextFloat() >= 0.2F) {
                continue;
            }
            // Direction.from2DDataValue, and its clockwise neighbour.
            (int sx, int sz, int cx, int cz) = ((slot + rotation) & 3) switch {
                0 => (0, 1, -1, 0),
                1 => (-1, 0, 0, -1),
                2 => (0, -1, 1, 0),
                _ => (1, 0, 0, 1)
            };
            double x = X + 0.5 - sx * 0.3125F + cx * 0.3125F;
            double z = Z + 0.5 - sz * 0.3125F + cz * 0.3125F;
            for (int i = 0; i < 4; i++) {
                particles.AddParticle(Particle.Smoke, x, Y + 0.5, z, 0.0, 5.0E-4, 0.0);
            }
        }
    }

    /// <summary><c>ContainerHelper.loadAllItems</c>.</summary>
    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        Items = Empty(Type);
        LoadItems(tag, registry, Items);
        AlignItemsToBottom = tag["align_items_to_bottom"] is { } align && align.GetBoolean();
    }

    internal static void LoadItems(CompoundTag tag, MinecraftRegistry registry, ItemStack[] into) {
        if (tag["Items"] is not ListTag list) {
            return;
        }
        foreach (INbtTag entry in list.Tags) {
            if (entry is not CompoundTag item || item["Slot"] is not { } slotTag) {
                continue;
            }
            int slot = slotTag.GetByte() & 255;
            if (slot < into.Length && ReadStack(item, registry) is { } stack) {
                into[slot] = stack;
            }
        }
    }

    internal static ItemStack? ReadStack(INbtTag tag, MinecraftRegistry registry) {
        try {
            return ItemStack.FromNbt(tag, registry);
        }
        catch (Exception e) when (e is InvalidOperationException or ArgumentException or KeyNotFoundException or InvalidCastException) {
            return null;
        }
    }
}

/// <summary><c>BrushableBlockEntity</c>: the item showing through the sand and the side it is being brushed from.</summary>
public sealed class BrushableBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public ItemStack Item { get; private set; } = ItemStack.Air;
    public Cardinal? HitDirection { get; private set; }

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        Item = tag["item"] is { } item ? ItemDisplayBlockEntity.ReadStack(item, registry) ?? ItemStack.Air : ItemStack.Air;
        HitDirection = tag["hit_direction"] is { } hit ? DirectionUtil.From3DDataValue(hit.GetInteger()) : null;
    }

    /// <summary>The <c>dusted</c> property of suspicious sand and gravel.</summary>
    public int Dusted => State switch {
        SuspiciousSandBlock sand => sand.Dusted,
        SuspiciousGravelBlock gravel => gravel.Dusted,
        _ => 0
    };
}

/// <summary><c>ConduitBlockEntity</c>'s client tick: the frame it checks every two seconds and the shell's turn.</summary>
public sealed class ConduitBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    private static readonly IBlock[] ValidBlocks = [Block.Prismarine, Block.PrismarineBricks, Block.SeaLantern, Block.DarkPrismarine];

    public int TickCount;
    private float _activeRotation;
    private readonly List<(int X, int Y, int Z)> _effectBlocks = [];

    public bool IsActive { get; private set; }
    public bool IsHunting { get; private set; }

    /// <summary><c>destroyTarget</c>: the entity the conduit is attacking, by its UUID.</summary>
    private Guid? _destroyTarget;

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        _destroyTarget = BlockEntityTags.ReadUuid(tag["Target"]);
    }

    public override bool HasClientTicker => true;

    /// <summary><c>clientTick</c>.</summary>
    public override void Tick(BlockEntityTickContext context) {
        TickCount++;
        if (context.Level.GameTime % 40L == 0L) {
            IsActive = UpdateShape(context.Level, X, Y, Z, _effectBlocks);
            IsHunting = _effectBlocks.Count >= 42;
        }
        if (context.Particles is { } particles) {
            AnimationTick(context.Client!, particles);
        }
        if (IsActive) {
            _activeRotation++;
        }
    }

    /// <summary><c>animationTick</c>: nautilus particles drawn from the frame blocks into the eye, and from around its target.</summary>
    private void AnimationTick(MinecraftClient client, Particles.ParticleEngine particles) {
        Particles.ParticleRandom random = particles.Random;
        float bob = MathF.Sin((TickCount + 35) * 0.1F) / 2.0F + 0.5F;
        bob = (bob * bob + bob) * 0.3F;
        double endX = X + 0.5, endY = Y + 1.5 + bob, endZ = Z + 0.5;
        foreach ((int bx, int by, int bz) in _effectBlocks) {
            if (random.NextInt(50) == 0) {
                float dx = -0.5F + random.NextFloat() + (bx - X);
                float dy = -2.0F + random.NextFloat() + (by - Y);
                float dz = -0.5F + random.NextFloat() + (bz - Z);
                particles.AddParticle(Particle.Nautilus, endX, endY, endZ, dx, dy, dz);
            }
        }
        if (_destroyTarget is not { } uuid) {
            return;
        }
        foreach (Entities.ClientEntity target in client.Entities.Values) {
            if (target.Uuid != uuid || !target.IsLiving) {
                continue;
            }
            Minecraft.Physics.Box box = target.BoundingBox;
            double width = box.MaxX - box.MinX, height = box.MaxY - box.MinY;
            float randX = (-0.5F + random.NextFloat()) * (3.0F + (float)width);
            float randY = -1.0F + random.NextFloat() * (float)height;
            float randZ = (-0.5F + random.NextFloat()) * (3.0F + (float)width);
            particles.AddParticle(Particle.Nautilus, target.Position.X, target.Position.Y + target.CurrentEyeHeight, target.Position.Z, randX, randY, randZ);
            break;
        }
    }

    public float GetActiveRotation(float a) => (_activeRotation + a) * -0.0375F;

    /// <summary><c>updateShape</c>: water all round, and at least sixteen frame blocks on the three rings.</summary>
    internal static bool UpdateShape(ClientLevel level, int x, int y, int z, List<(int X, int Y, int Z)> effectBlocks) {
        effectBlocks.Clear();
        for (int ox = -1; ox <= 1; ox++) {
            for (int oy = -1; oy <= 1; oy++) {
                for (int oz = -1; oz <= 1; oz++) {
                    if (!IsWater(level.GetBlock(x + ox, y + oy, z + oz))) {
                        return false;
                    }
                }
            }
        }
        for (int ox = -2; ox <= 2; ox++) {
            for (int oy = -2; oy <= 2; oy++) {
                for (int oz = -2; oz <= 2; oz++) {
                    int ax = Math.Abs(ox), ay = Math.Abs(oy), az = Math.Abs(oz);
                    if ((ax > 1 || ay > 1 || az > 1) && (ox == 0 && (ay == 2 || az == 2) || oy == 0 && (ax == 2 || az == 2) || oz == 0 && (ax == 2 || ay == 2))) {
                        IBlock test = level.GetBlock(x + ox, y + oy, z + oz);
                        foreach (IBlock valid in ValidBlocks) {
                            if (test.Identifier.Equals(valid.Identifier)) {
                                effectBlocks.Add((x + ox, y + oy, z + oz));
                            }
                        }
                    }
                }
            }
        }
        return effectBlocks.Count >= 16;
    }

    /// <summary><c>Level.isWaterAt</c>: the state's fluid is water, flowing or still, as a waterlogged block's is.</summary>
    private static bool IsWater(IBlock block) => block is WaterBlock || block.Fluid is { } fluid && fluid.Key.Contains("water");
}
