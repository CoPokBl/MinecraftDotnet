using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.Testing.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// The shapes <c>BlockGetter.clip</c> meets under <c>ClipContext.Block.OUTLINE</c> where the generated table cannot
/// hold them, and <c>ProjectileUtil.getEntityHitResult</c>'s per entity box. Each expected hit is worked out by hand
/// from the ray and the vanilla shape.
/// </summary>
public class PickingTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player) World() =>
        LocalPlayerMechanicsTest.World((_, y, _) => y < Floor ? Block.Stone.StateId : 0, new Vec3d(0.5, Floor, -5.5));

    private static void AssertHit(HitResult hit, int x, int y, int z, BlockFace face, Vec3d location) {
        Assert.That(hit, Is.TypeOf<BlockHitResult>());
        BlockHitResult block = (BlockHitResult)hit;
        Assert.That((block.X, block.Y, block.Z), Is.EqualTo((x, y, z)));
        Assert.That(block.Face, Is.EqualTo(face));
        Assert.That(block.Location.X, Is.EqualTo(location.X).Within(1e-9));
        Assert.That(block.Location.Y, Is.EqualTo(location.Y).Within(1e-9));
        Assert.That(block.Location.Z, Is.EqualTo(location.Z).Within(1e-9));
    }

    /// <summary>
    /// <c>ShulkerBoxBlock.getShape</c> is the block entity's lid, raised by half the progress, which three ticks of
    /// opening take to 0.3. A ray falling 1.5 over 3 east meets the lid's top at 1 + 0.15 inside the block, where
    /// a closed box's top at 1 would have been met further on.
    /// </summary>
    [Test]
    public void TheRayMeetsAnOpeningShulkerBoxsLid() {
        (MinecraftClient client, _) = World();
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.RedShulkerBox with { Facing = Cardinal.Up } });
        Vec3d from = new(-1.5, Floor + 2, 0.5), to = new(1.5, Floor + 0.5, 0.5);
        AssertHit(Picking.ClipBlocks(client.Level!, from, to), 0, Floor, 0, BlockFace.PosY, new Vec3d(0.5, Floor + 1, 0.5));

        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.RedShulkerBox, ActionId = 1, ActionParameter = 1
        });
        float progressOld = 0.0F, progress = 0.0F;
        for (int tick = 0; tick < 3; tick++) {
            client.Tick();
            progressOld = progress;
            progress += 0.1F;
        }
        double lid = 1.0 + 0.5F * (progressOld + 1.0F * (progress - progressOld));
        double scale = (2.0 - lid) / 1.5;
        AssertHit(Picking.ClipBlocks(client.Level!, from, to), 0, Floor, 0, BlockFace.PosY,
            new Vec3d(-1.5 + 3.0 * scale, Floor + lid, 0.5));
        Assert.That(-1.5 + 3.0 * scale, Is.EqualTo(0.2).Within(1e-6));

        for (int tick = 0; tick < 10; tick++) {
            client.Tick();
        }
        // Fully open the lid's top is at 1.5, above where the ray crosses the west face at 1.25.
        AssertHit(Picking.ClipBlocks(client.Level!, from, to), 0, Floor, 0, BlockFace.NegX, new Vec3d(0, Floor + 1.25, 0.5));
    }

    /// <summary>
    /// <c>MovingPistonBlock.getShape</c> is empty whatever <c>PistonMovingBlockEntity.getCollisionShape</c> holds, so
    /// the extending head, which collides, is passed through to the extended base's east face at 12/16.
    /// </summary>
    [Test]
    public void TheRayPassesThroughAnExtendingHead() {
        (MinecraftClient client, _) = World();
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston with { Facing = Cardinal.East } });
        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston, ActionId = 0, ActionParameter = (byte)Cardinal.East
        });
        ClientLevel level = client.Level!;
        Assert.That(level.GetBlock(1, Floor, 0), Is.TypeOf<MovingPistonBlock>());
        Assert.That(LevelCollisions.CollisionShapeAt(level, 1, Floor, 0, default), Is.Not.Empty);
        Assert.That(Picking.OutlineShape(level, 1, Floor, 0), Is.Empty);

        AssertHit(Picking.ClipBlocks(level, new Vec3d(3.5, Floor + 0.5, 0.5), new Vec3d(-1.5, Floor + 0.5, 0.5)),
            0, Floor, 0, BlockFace.PosX, new Vec3d(0.75, Floor + 0.5, 0.5));
    }

    /// <summary><c>LightBlock.getShape</c>: empty unless the entity the ray starts from holds a light.</summary>
    [Test]
    public void ALightBlockIsHitOnlyWhileHoldingALight() {
        (MinecraftClient client, _) = World();
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.Light });
        Vec3d from = new(0.5, Floor + 3.5, 0.5), to = new(0.5, Floor - 1.5, 0.5);
        AssertHit(Picking.ClipBlocks(client.Level!, from, to), 0, Floor - 1, 0, BlockFace.PosY, new Vec3d(0.5, Floor, 0.5));
        AssertHit(Picking.ClipBlocks(client.Level!, from, to, Item.Light), 0, Floor, 0, BlockFace.PosY, new Vec3d(0.5, Floor + 1, 0.5));
    }

    /// <summary>
    /// <c>Projectile.getPickRadius</c>: a shulker bullet 0.9 to the side of the ray is hit, its box grown by a block
    /// meeting the ray 1 + 0.15625 short of its centre.
    /// </summary>
    [Test]
    public void AProjectilesBoxGrowsByItsPickRadius() {
        (MinecraftClient client, LocalPlayer player) = World();
        Vec3d eye = Picking.EyePosition(player, 1.0F);
        ClientEntity bullet = new() {
            Id = 50, Type = EntityType.ShulkerBullet, Position = new Vec3d(eye.X + 0.9, eye.Y - 0.1, eye.Z + 2.5),
            OldPosition = new Vec3d(eye.X + 0.9, eye.Y - 0.1, eye.Z + 2.5)
        };
        client.Entities[bullet.Id] = bullet;
        client.Interactions.Pick(1.0F);
        Assert.That(client.Interactions.Target, Is.TypeOf<EntityHitResult>());
        EntityHitResult hit = (EntityHitResult)client.Interactions.Target!;
        Assert.That(hit.Entity, Is.SameAs(bullet));
        Assert.That(hit.Location.Z, Is.EqualTo(eye.Z + 2.5 - 0.3125 / 2 - 1.0).Within(1e-9));
    }

    /// <summary><c>SulfurCube.canBePickedFromInside</c>: false while it carries a block in its body slot.</summary>
    [Test]
    public void ASulfurCubeCarryingABlockIsNotPickedFromInside() {
        (MinecraftClient client, LocalPlayer player) = World();
        Vec3d eye = Picking.EyePosition(player, 1.0F);
        ClientEntity cube = new() { Id = 51, Type = EntityType.SulfurCube, Position = player.Position, OldPosition = player.Position };
        double height = cube.BoundingBox.MaxY - cube.BoundingBox.MinY;
        cube.Position = cube.OldPosition = new Vec3d(eye.X, eye.Y - height / 2, eye.Z);
        client.Entities[cube.Id] = cube;
        Minecraft.Physics.Box box = cube.BoundingBox;
        Assert.That(eye.X >= box.MinX && eye.X < box.MaxX && eye.Y >= box.MinY && eye.Y < box.MaxY && eye.Z >= box.MinZ && eye.Z < box.MaxZ, Is.True);

        client.Interactions.Pick(1.0F);
        Assert.That(client.Interactions.Target is EntityHitResult { Entity: var picked } && picked == cube, Is.True);

        cube.Equipment[EquipmentSlot.Body] = new ItemStack(Item.Stone);
        client.Interactions.Pick(1.0F);
        Assert.That(client.Interactions.Target is EntityHitResult, Is.False);
    }
}
