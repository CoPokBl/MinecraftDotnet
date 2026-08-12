using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chat;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

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
        yield return ("ClientBoundShowDialogPacket",
            ClientBoundShowDialogPacket.Reference(Dialog.QuickActions.Identifier));

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
                    new SlotDisplay.Tag("minecraft:planks"),
                    new SlotDisplay.Composite([new SlotDisplay.Stack(new Minecraft.Schemas.Items.ItemStack(Item.Stone, 3))])
                ],
                new SlotDisplay.Item(Item.Torch),
                new SlotDisplay.Item(Item.CraftingTable))
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
