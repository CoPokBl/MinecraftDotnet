using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Dialogs;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chat;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using NBT.Tags;

namespace Conformance;

/// <summary>
/// Packets whose fields reflection can't fill: either they hang off an abstract type it can't
/// pick a member of, or the field is a discriminated union whose tag and payload have to agree.
/// </summary>
/// <remarks>
/// Without these the harness reports the packets as skipped, which is the same as no coverage.
/// They are worth the hand maintenance because the client drops the connection on a packet it
/// can't decode, and nothing else in the build would notice.
/// </remarks>
public static class RichSamples {
    /// <summary>Packets built here, so the reflection pass leaves them alone.</summary>
    public static readonly HashSet<Type> Covered = [
        typeof(ClientBoundShowDialogPacket),
        typeof(ClientBoundDisguisedChatMessagePacket),
        typeof(ClientBoundPlayerChatMessagePacket),
        typeof(ClientBoundDamageEventPacket),
        typeof(ClientBoundWaypointPacket),
        typeof(ClientBoundPlaceGhostRecipePacket),
        typeof(ClientBoundRecipeBookAddPacket),
        typeof(ClientBoundUpdateLightPacket),
        typeof(ClientBoundDebugBlockValuePacket),
        typeof(ClientBoundDebugChunkValuePacket),
        typeof(ClientBoundDebugEntityValuePacket),
        typeof(ClientBoundDebugEventPacket)
    ];

    /// <summary>
    /// A channel that carries a value. The first debug subscription doesn't, and vanilla refuses
    /// to decode an update for one of those at all.
    /// </summary>
    private static readonly Identifier ValuedSubscription = "minecraft:neighbor_updates";

    /// <summary>A block position, which is what the neighbour update channel carries.</summary>
    private static readonly byte[] SubscriptionValue = new DataWriter().WriteLong(0).ToArray();

    public static IEnumerable<(string Name, MinecraftPacket Packet)> Build() {
        // A path rather than one jump: the step count rides in the properties varint, and each step
        // carries its own tick offset ahead of its shorts.
        MovementDelta.Step[] steps = [new(1, new Vec3<float>(0.5F, 0, -0.25F)), new(3, new Vec3<float>(0, 1, 0))];
        yield return ("ClientBoundUpdateEntityPositionPacket[stepped]", new ClientBoundUpdateEntityPositionPacket {
            EntityId = 7, Delta = new Vec3<float>(0.5F, 1, -0.25F), OnGround = true, Steps = steps
        });
        yield return ("ClientBoundUpdateEntityPosAndRotPacket[stepped]", new ClientBoundUpdateEntityPosAndRotPacket {
            EntityId = 7, Delta = new Vec3<float>(0.5F, 1, -0.25F), Yaw = Angle.FromDegrees(90), Pitch = Angle.FromDegrees(-45),
            OnGround = false, Steps = steps
        });
        yield return ("ClientBoundTeleportEntityPacket[stepped]", new ClientBoundTeleportEntityPacket {
            EntityId = 7, Position = new Vec3<double>(4, 65, 2), Yaw = Angle.FromDegrees(90), Pitch = Angle.Zero, OnGround = true,
            Steps = [new(new Vec3<double>(3, 64, 2), 2), new(new Vec3<double>(4, 65, 2), 5)]
        });

        yield return ("ClientBoundShowDialogPacket",
            ClientBoundShowDialogPacket.Reference(Dialog.QuickActions.Identifier));

        // The inline form carries the whole dialog as NBT, so this is the only check on the shape
        // ManagedServer's dialog builder writes
        yield return ("ClientBoundShowDialogPacket[inline]", ClientBoundShowDialogPacket.Inline(
            new MultiActionDialog(
                ClientBoundShowDialogPacket.InlineIdentifier,
                new CommonDialogData(
                    TextComponent.Text("Title"),
                    Body: [
                        new DialogBody.PlainMessage(TextComponent.Text("Body")),
                        new DialogBody.ItemBody(new DialogItem(Item.DiamondSword.Identifier, 3),
                            new DialogBody.PlainMessage(TextComponent.Text("An item")))
                    ],
                    Inputs: [
                        new DialogInput("name", new InputControl.Text(TextComponent.Text("Name"))),
                        new DialogInput("story", new InputControl.Text(TextComponent.Text("Story"),
                            MaxLength: 200, Multiline: new MultilineOptions(4, 60))),
                        new DialogInput("agree", new InputControl.Boolean(TextComponent.Text("Agree"))),
                        new DialogInput("amount",
                            new InputControl.NumberRange(TextComponent.Text("Amount"), new RangeInfo(0, 10, null, 1))),
                        new DialogInput("colour", new InputControl.SingleOption(TextComponent.Text("Colour"),
                            [new SingleOptionEntry("red", TextComponent.Text("Red"), true)]))
                    ]),
                [
                    new DialogActionButton(TextComponent.Text("Send"),
                        Action: new DialogAction.Custom("managedserver:dialog/sample/0", null)),
                    // The client handles these two itself. A command template has to name at least
                    // one input, and vanilla parses the URL, so both are more than a string check
                    new DialogActionButton(TextComponent.Text("Run"),
                        Action: new DialogAction.RunCommandTemplate("helloworld $(amount)")),
                    new DialogActionButton(TextComponent.Text("Open"),
                        Action: new DialogAction.Static("minecraft:open_url",
                            [("url", new StringTag("https://github.com/CoPokBl/MinecraftDotnet"))]))
                ],
                new DialogActionButton(TextComponent.Text("Back")))));

        // A dialog that stays open after a button. Vanilla refuses one that pauses the game
        // without unpausing it again, so the pause flag has to come off with it
        yield return ("ClientBoundShowDialogPacket[stays open]", ClientBoundShowDialogPacket.Inline(
            new MultiActionDialog(
                ClientBoundShowDialogPacket.InlineIdentifier,
                new CommonDialogData(TextComponent.Text("Menu"), Pause: false,
                    AfterAction: DialogAfterAction.None),
                [
                    new DialogActionButton(TextComponent.Text("One"),
                        Action: new DialogAction.Custom("managedserver:dialog/sample/0", null)),
                    new DialogActionButton(TextComponent.Text("Two"),
                        Action: new DialogAction.Custom("managedserver:dialog/sample/1", null))
                ],
                new DialogActionButton(TextComponent.Text("Done")))));

        // The other two shapes a server is likely to send inline
        yield return ("ClientBoundShowDialogPacket[notice]", ClientBoundShowDialogPacket.Inline(
            new NoticeDialog(ClientBoundShowDialogPacket.InlineIdentifier,
                new CommonDialogData(TextComponent.Text("Notice"),
                    Body: [new DialogBody.PlainMessage(TextComponent.Text("Body"))]),
                NoticeDialog.DefaultAction)));

        yield return ("ClientBoundShowDialogPacket[confirmation]", ClientBoundShowDialogPacket.Inline(
            new ConfirmationDialog(ClientBoundShowDialogPacket.InlineIdentifier,
                new CommonDialogData(TextComponent.Text("Sure?")),
                new DialogActionButton(TextComponent.Translatable("gui.yes"),
                    Action: new DialogAction.Custom("managedserver:dialog/sample/0", null)),
                new DialogActionButton(TextComponent.Translatable("gui.no"),
                    Action: new DialogAction.Custom("managedserver:dialog/sample/1", null)))));

        // Item components only reach the wire as a stack's own patch, so nothing built by reflection
        // carries one. These two are the fiddly ones: a list of records, two optional holder sets and
        // two optional sounds each written as an id or inline.
        yield return ("ClientBoundSetContainerSlotPacket[blocks_attacks]", Slot(
            new Minecraft.Schemas.Items.ItemStack(Item.Shield)
                .With(DataComponent.BlocksAttacks, new BlocksAttacksComponent.Data(
                    0.25f, 1f,
                    [
                        BlocksAttacksComponent.DamageReduction.Everything,
                        // A reduction scoped to damage types, which is the other branch of the optional
                        // holder set. Ids rather than a tag, since the harness has no tags loaded.
                        new BlocksAttacksComponent.DamageReduction(45f, new IdSet.Ids([0, 1]), 2f, 0.5f)
                    ],
                    new BlocksAttacksComponent.ItemDamage(3f, 1f, 1f),
                    new IdSet.Ids([2]),
                    SoundType.ShieldBlock,
                    new SoundEvent(SoundType.ShieldBreak, 12f)))));

        yield return ("ClientBoundSetContainerSlotPacket[weapon]", Slot(
            new Minecraft.Schemas.Items.ItemStack(Item.DiamondAxe)
                .With(DataComponent.Weapon, new WeaponComponent.Data(2, 5f))));

        yield return ("ClientBoundDisguisedChatMessagePacket", new ClientBoundDisguisedChatMessagePacket {
            Message = TextComponent.Empty(),
            ChatType = BoundChatType.Reference(ChatType.Chat.Identifier, TextComponent.Empty())
        });

        yield return ("ClientBoundPlayerChatMessagePacket", new ClientBoundPlayerChatMessagePacket {
            GlobalIndex = 1,
            Sender = Guid.Empty,
            Index = 0,
            Signature = null,
            Content = "hello",
            Timestamp = DateTimeOffset.UnixEpoch,
            Salt = 0,
            LastSeen = [],
            UnsignedContent = null,
            FilterMask = ChatFilterMask.PassThrough,
            ChatType = BoundChatType.Reference(ChatType.Chat.Identifier, TextComponent.Empty())
        });

        yield return ("ClientBoundDamageEventPacket", new ClientBoundDamageEventPacket {
            EntityId = 1,
            SourceType = DamageType.Generic,
            SourceCauseId = null,
            SourceDirectId = null,
            SourcePosition = null
        });

        // One per waypoint shape: the position is written differently for each
        yield return ("ClientBoundWaypointPacket[empty]", Waypoint(new TrackedWaypoint.Empty {
            Id = Or<Guid, string>.FromValue1(Guid.Empty)
        }));
        yield return ("ClientBoundWaypointPacket[position]", Waypoint(new TrackedWaypoint.Position {
            Id = Or<Guid, string>.FromValue1(Guid.Empty),
            Location = new Vec3<int>(1, 2, 3)
        }));
        yield return ("ClientBoundWaypointPacket[chunk]", Waypoint(new TrackedWaypoint.Chunk {
            Id = Or<Guid, string>.FromValue2("marker"),
            ChunkX = 1,
            ChunkZ = 2
        }));
        yield return ("ClientBoundWaypointPacket[azimuth]", Waypoint(new TrackedWaypoint.Azimuth {
            Id = Or<Guid, string>.FromValue1(Guid.Empty),
            Icon = new WaypointIcon { Color = 0x336699 },
            Angle = 1.5f
        }));

        yield return ("ClientBoundPlaceGhostRecipePacket", new ClientBoundPlaceGhostRecipePacket {
            WindowId = 1,
            Recipe = new RecipeDisplay.ShapedCrafting(
                2, 2,
                [
                    new SlotDisplay.Item(Item.Stick),
                    SlotDisplay.Empty.Instance,
                    new SlotDisplay.Tag(new IdSet.Tag("minecraft:planks")),
                    new SlotDisplay.Composite([new SlotDisplay.Stack(new Minecraft.Schemas.Items.ItemStack(Item.Stone, 3))])
                ],
                new SlotDisplay.Item(Item.Torch),
                new SlotDisplay.Item(Item.CraftingTable))
        });

        // The flags byte follows each entry, and a group and the requirements are both optional.
        yield return ("ClientBoundRecipeBookAddPacket", new ClientBoundRecipeBookAddPacket {
            Entries = [
                new ClientBoundRecipeBookAddPacket.Entry(new RecipeDisplayEntry {
                    Id = 1234,
                    Display = new RecipeDisplay.ShapelessCrafting(
                        [new SlotDisplay.Tag(new IdSet.Tag("minecraft:planks")), new SlotDisplay.Item(Item.Stick)],
                        new SlotDisplay.Item(Item.Torch),
                        new SlotDisplay.Item(Item.CraftingTable)),
                    Group = 7,
                    Category = RecipeBookCategory.CraftingMisc,
                    CraftingRequirements = [new IdSet.Ids([1, 2]), new IdSet.Tag("minecraft:planks")]
                }, true, false),
                new ClientBoundRecipeBookAddPacket.Entry(new RecipeDisplayEntry {
                    Id = 3,
                    Display = new RecipeDisplay.Furnace(
                        new SlotDisplay.Item(Item.RawIron),
                        SlotDisplay.AnyFuel.Instance,
                        new SlotDisplay.Item(Item.IronIngot),
                        new SlotDisplay.Item(Item.Furnace),
                        200,
                        0.7f),
                    Category = RecipeBookCategory.FurnaceMisc
                }, false, true)
            ],
            Replace = true
        });

        yield return ("ClientBoundUpdateLightPacket", new ClientBoundUpdateLightPacket {
            ChunkX = 1,
            ChunkZ = 2,
            Light = LightData.FullBright
        });

        yield return ("ClientBoundDebugBlockValuePacket", new ClientBoundDebugBlockValuePacket {
            Location = new Vec3<int>(1, 2, 3),
            Update = Update()
        });

        yield return ("ClientBoundDebugChunkValuePacket", new ClientBoundDebugChunkValuePacket {
            ChunkX = 1,
            ChunkZ = 2,
            Update = Update()
        });

        yield return ("ClientBoundDebugEntityValuePacket", new ClientBoundDebugEntityValuePacket {
            EntityId = 1,
            Update = Update()
        });

        yield return ("ClientBoundDebugEventPacket", new ClientBoundDebugEventPacket {
            Subscription = VanillaRegistry.Data.DebugSubscriptions[ValuedSubscription],
            Value = SubscriptionValue
        });
    }

    /// <summary>A stack in a container, which is the shortest packet that carries item components.</summary>
    private static ClientBoundSetContainerSlotPacket Slot(Minecraft.Schemas.Items.ItemStack item) {
        return new ClientBoundSetContainerSlotPacket {
            WindowId = 0,
            StateId = 1,
            SlotId = 0,
            Data = item
        };
    }

    private static ClientBoundWaypointPacket Waypoint(TrackedWaypoint waypoint) {
        return new ClientBoundWaypointPacket {
            Operation = ClientBoundWaypointPacket.WaypointOperation.Track,
            Waypoint = waypoint
        };
    }

    private static DebugSubscriptionUpdate Update() {
        return new DebugSubscriptionUpdate {
            Subscription = VanillaRegistry.Data.DebugSubscriptions[ValuedSubscription],
            Value = SubscriptionValue
        };
    }
}
