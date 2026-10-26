using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.Testing.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// <c>LocalPlayer.raycastHitResult</c> with a spear held: <c>AttackRange.getClosesetHit</c> between 2 and 4.5 blocks
/// (6.5 in creative) with a 0.125 hitbox margin first, the plain pick only when that finds nothing. The player looks
/// straight down +Z from eye height, so every expected hit is worked out by hand along that line.
/// </summary>
public class AttackRangePickingTest {
    private const int Floor = 16;

    /// <summary>Half a zombie's width, which is a float upstream.</summary>
    private const double Half = 0.6F / 2.0F;

    private static (MinecraftClient Client, LocalPlayer Player, Vec3d Eye) World(bool spear = true) {
        (MinecraftClient client, LocalPlayer player) = LocalPlayerMechanicsTest.World((_, y, _) => y < Floor ? Block.Stone.StateId : 0, new Vec3d(0.5, Floor, -5.5));
        player.OldPosition = player.Position;
        player.XRot = player.XRotO = 0.0F;
        player.YRot = player.YRotO = player.YHeadRot = 0.0F;
        player.DeltaMovement = Vec3d.Zero;
        if (spear) {
            client.Inventory.SetInventorySlot(0, new ItemStack(Item.IronSpear, 1));
        }
        return (client, player, Picking.EyePosition(player));
    }

    /// <summary>A zombie whose box is centred on eye height, <paramref name="ahead"/> blocks down the look to its centre.</summary>
    private static ClientEntity Zombie(MinecraftClient client, Vec3d eye, double ahead, double aside = 0.0) {
        Vec3d feet = new(eye.X + aside, eye.Y - 1.95F / 2.0, eye.Z + ahead);
        ClientEntity zombie = new() { Id = 60, Type = EntityType.Zombie, Position = feet, OldPosition = feet };
        client.Entities[zombie.Id] = zombie;
        return zombie;
    }

    private static HitResult Pick(MinecraftClient client) {
        client.Interactions.Pick(1.0F);
        return client.Interactions.Target!;
    }

    /// <summary>
    /// The ray passes 0.1 west of a zombie whose near face is 3 ahead, inside the 0.125 margin. The inflated box is met
    /// 0.125 short of the face, and the ray from there to the zombie's centre, 0.4 east and 0.425 on, meets its near
    /// face after 0.125 / 0.425 of the way. Without the spear the plain pick misses it.
    /// </summary>
    [Test]
    public void TheMarginCatchesAnEntityTheRayJustMisses() {
        (MinecraftClient client, _, Vec3d eye) = World();
        ClientEntity zombie = Zombie(client, eye, 3.3, 0.4);
        HitResult hit = Pick(client);
        Assert.That(hit, Is.TypeOf<EntityHitResult>());
        Assert.That(((EntityHitResult)hit).Entity, Is.SameAs(zombie));
        Assert.That(hit.Location.X, Is.EqualTo(0.5 + 0.4 * (0.125 / (Half + 0.125))).Within(1e-9));
        Assert.That(hit.Location.Z, Is.EqualTo(eye.Z + 3.3 - Half).Within(1e-9));

        client.Inventory.SetInventorySlot(0, ItemStack.Air);
        Assert.That(Pick(client), Is.TypeOf<MissResult>());
    }

    /// <summary>
    /// A zombie whose far face is 1.6 ahead lies wholly short of the near reach, even with the margin, so the attack
    /// range finds nothing and the plain pick takes its near face at 1.
    /// </summary>
    [Test]
    public void AnEntityShortOfTheNearReachFallsToThePlainPick() {
        (MinecraftClient client, _, Vec3d eye) = World();
        ClientEntity zombie = Zombie(client, eye, 1.3);
        AttackRangeComponent.Data range = ItemComponents.Get(new ItemStack(Item.IronSpear, 1), DataComponent.AttackRange)!;
        Assert.That(Picking.ClosestHit(range, client.Player!, client.Level!, client.Entities.Values, client.PlayerList, 1.0F), Is.TypeOf<MissResult>());

        HitResult hit = Pick(client);
        Assert.That(hit, Is.TypeOf<EntityHitResult>());
        Assert.That(((EntityHitResult)hit).Entity, Is.SameAs(zombie));
        Assert.That(hit.Location.Z, Is.EqualTo(eye.Z + 1.3 - Half).Within(1e-9));
    }

    /// <summary>
    /// A near face 5.5 ahead is past survival's 4.5 and its margin, and past creative's plain entity range of 5, but
    /// inside creative's spear reach of 6.5.
    /// </summary>
    [Test]
    public void CreativeReachesFurther() {
        (MinecraftClient client, LocalPlayer player, Vec3d eye) = World();
        ClientEntity zombie = Zombie(client, eye, 5.8);
        Assert.That(Pick(client), Is.TypeOf<MissResult>());

        player.GameMode = GameMode.Creative;
        HitResult hit = Pick(client);
        Assert.That(hit, Is.TypeOf<EntityHitResult>());
        Assert.That(((EntityHitResult)hit).Entity, Is.SameAs(zombie));
        Assert.That(hit.Location.Z, Is.EqualTo(eye.Z + 5.8 - Half).Within(1e-9));
    }

    /// <summary>
    /// Moving 0.4 a tick along the look lengthens the far reach to 4.9, which takes in a near face at 4.7 that
    /// standing still, 4.5 and a 0.125 margin, falls short of.
    /// </summary>
    [Test]
    public void MovingForwardLengthensTheFarReach() {
        (MinecraftClient client, LocalPlayer player, Vec3d eye) = World();
        ClientEntity zombie = Zombie(client, eye, 5.0);
        Assert.That(Pick(client), Is.TypeOf<MissResult>());

        player.DeltaMovement = new Vec3d(0.0, 0.0, 0.4);
        HitResult hit = Pick(client);
        Assert.That(hit, Is.TypeOf<EntityHitResult>());
        Assert.That(((EntityHitResult)hit).Entity, Is.SameAs(zombie));
        Assert.That(hit.Location.Z, Is.EqualTo(eye.Z + 5.0 - Half).Within(1e-9));
    }

    /// <summary>
    /// A block met 1.5 ahead, nearer than the near reach, is the answer outright; one met at 2.5 cuts the reach short
    /// of the zombie behind it, so the block is the answer again.
    /// </summary>
    [Test]
    public void ABlockInFrontShieldsTheEntity() {
        (MinecraftClient client, _, Vec3d eye) = World();
        Zombie(client, eye, 3.3);
        int eyeBlock = (int)Math.Floor(eye.Y);
        foreach (int z in (int[])[-4, -3]) {
            client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, eyeBlock, z), Block = Block.Stone });
            HitResult hit = Pick(client);
            Assert.That(hit, Is.TypeOf<BlockHitResult>());
            BlockHitResult block = (BlockHitResult)hit;
            Assert.That((block.X, block.Y, block.Z, block.Face), Is.EqualTo((0, eyeBlock, z, BlockFace.NegZ)));
            Assert.That(block.Location.Z, Is.EqualTo(z).Within(1e-9));
            client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, eyeBlock, z), Block = Block.Air });
        }
    }

    /// <summary>
    /// Two interactions shaped like zombies: A on the ray from 2.85 ahead, B 0.08 east of it from 2.2. The plain pick
    /// takes A; the spear's margin takes B, which is nearer, so the right click goes to B. An interaction that has not
    /// asked for a response consumes the click without a swing, so the spear is not then used as well.
    /// </summary>
    [Test]
    public void TheRightClickGoesToTheEntityTheMarginCaught() {
        (MinecraftClient client, _, Vec3d eye) = World();
        ClientEntity Interaction(int id, double aside, double ahead) {
            Vec3d feet = new(eye.X + aside, eye.Y - 1.0, eye.Z + ahead);
            ClientEntity entity = new() { Id = id, Type = EntityType.Interaction, Position = feet, OldPosition = feet };
            entity.Metadata[EntityDataFields.Interaction.Width.Index] = new MetaField<float>(MetaFieldType.Float, 0.6F);
            entity.Metadata[EntityDataFields.Interaction.Height.Index] = new MetaField<float>(MetaFieldType.Float, 1.95F);
            client.Entities[id] = entity;
            return entity;
        }
        ClientEntity a = Interaction(70, 0.0, 3.15);
        ClientEntity b = Interaction(71, Half + 0.08, 2.5);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;

        client.Interactions.Keys.Use.Press();
        client.Interactions.Tick();
        Assert.That(sent.OfType<ServerBoundInteractPacket>().Select(p => p.EntityId), Is.EqualTo(new[] { b.Id }));
        Assert.That(sent.OfType<ServerBoundUseItemPacket>(), Is.Empty);
        Assert.That(sent.OfType<ServerBoundPunchPacket>(), Is.Empty);

        client.Inventory.SetInventorySlot(0, ItemStack.Air);
        Assert.That(Pick(client) is EntityHitResult { Entity: var picked } && picked == a, Is.True);
    }

    /// <summary>
    /// <c>clipIncludingBorder</c>: a border 3 ahead stops the reach, as a hit on the south face of the block just
    /// inside it, 1e-5 short of the edge, flagged as the border's for the use packet.
    /// </summary>
    [Test]
    public void TheWorldBorderStopsTheReach() {
        (MinecraftClient client, _, Vec3d eye) = World();
        client.Level!.WorldBorder.SetCenter(0.5, eye.Z);
        client.Level.WorldBorder.SetSize(6.0);
        HitResult hit = Pick(client);
        Assert.That(hit, Is.TypeOf<BlockHitResult>());
        BlockHitResult block = (BlockHitResult)hit;
        Assert.That(block.WorldBorderHit, Is.True);
        Assert.That(block.Face, Is.EqualTo(BlockFace.PosZ));
        Assert.That(block.Location.Z, Is.EqualTo(eye.Z + 3.0 - 1.0E-5F));
        Assert.That((block.X, block.Y, block.Z), Is.EqualTo((0, (int)Math.Floor(eye.Y), -3)));
    }
}
