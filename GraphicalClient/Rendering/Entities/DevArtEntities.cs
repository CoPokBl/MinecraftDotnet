using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using GraphicalClient.Assets;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// Entities as developer art: coloured boxes sized from the entity's dimensions and shaped by body plan,
/// posed by head, body and walk cycle. What a type with no renderer draws as.
/// </summary>
public sealed class DevArtEntities {
    private enum Plan {
        Box,
        Humanoid,
        Quadruped,
        Item
    }

    private static readonly HashSet<string> Humanoids = [
        "player", "zombie", "husk", "drowned", "skeleton", "stray", "wither_skeleton", "bogged", "zombie_villager",
        "villager", "wandering_trader", "witch", "pillager", "vindicator", "evoker", "illusioner", "piglin",
        "piglin_brute", "zombified_piglin", "enderman", "creeper", "iron_golem", "snow_golem", "armor_stand",
        "giant", "allay", "vex", "blaze", "copper_golem", "parched", "zombie_nautilus"
    ];

    private static readonly HashSet<string> Quadrupeds = [
        "cow", "mooshroom", "pig", "sheep", "horse", "donkey", "mule", "skeleton_horse", "zombie_horse", "llama",
        "trader_llama", "wolf", "fox", "cat", "ocelot", "goat", "polar_bear", "panda", "camel", "sniffer", "hoglin",
        "zoglin", "ravager", "strider", "frog", "turtle", "armadillo", "camel_husk", "rabbit"
    ];

    private readonly IResourceSource _art;
    private readonly Dictionary<IEntityType, uint> _colours = new();
    private readonly Dictionary<IEntityType, Plan> _plans = new();

    public DevArtEntities(IResourceSource art) {
        _art = art;
    }

    public void Render(ClientEntity entity, EntityRenderContext context) {
        if (entity.IsInvisible && entity != context.Client.Player) {
            return;
        }
        ClientLevel level = context.Level;
        Vec3d camera = context.Camera.Position;
        float partialTick = context.PartialTick;
        Vec3d position = new(
            ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X),
            ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y),
            ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z));
        Vector3 relative = new((float)(position.X - camera.X), (float)(position.Y - camera.Y), (float)(position.Z - camera.Z));
        int bx = (int)Math.Floor(position.X), by = (int)Math.Floor(position.Y + entity.Height / 2), bz = (int)Math.Floor(position.Z);
        float sky = level.GetSkyLight(bx, by, bz);
        float block = entity.IsOnFire ? 15 : level.GetBlockLight(bx, by, bz);
        float bodyYaw = (float)ClientEntity.Lerp(partialTick, entity.YRotO, entity.YRot);
        float headYaw = (float)ClientEntity.Lerp(partialTick, entity.YHeadRotO, entity.YHeadRot);
        float pitch = (float)ClientEntity.Lerp(partialTick, entity.XRotO, entity.XRot);
        float scale = (float)entity.Attributes.Value(Attribute.Scale);
        Draw(context.Batch, Matrix4x4.CreateTranslation(relative), entity, partialTick, bodyYaw, headYaw, pitch, sky, block, scale > 0 ? scale : 1);
    }

    /// <summary>
    /// An entity at the origin of <paramref name="root"/>, turned as given rather than as it stands in
    /// the world, for a doll in a GUI.
    /// </summary>
    public void RenderPosed(ClientEntity entity, Matrix4x4 root, EntityBatch batch, float partialTick, float bodyYaw, float headYaw, float pitch,
        float sky, float block) =>
        Draw(batch, root, entity, partialTick, bodyYaw, headYaw, pitch, sky, block, 1.0F);

    private void Draw(EntityBatch overlay, Matrix4x4 root, ClientEntity entity, float partialTick, float bodyYaw, float headYaw, float pitch,
        float sky, float block, float scale) {
        uint colour = ColourOf(entity.Type);
        if (entity.HurtTime > 0) {
            colour = Tint(colour, 0xFFFF4040, 0.5F);
        }
        float walk = entity.WalkPosition - entity.WalkSpeed * (1 - partialTick);
        float walkSpeed = (float)ClientEntity.Lerp(partialTick, entity.WalkSpeedOld, entity.WalkSpeed);
        if (!_plans.TryGetValue(entity.Type, out Plan plan)) {
            plan = PlanOf(entity.Type);
            _plans[entity.Type] = plan;
        }
        switch (plan) {
            case Plan.Humanoid:
                Humanoid(overlay, root, entity, bodyYaw, headYaw, pitch, walk, walkSpeed, colour, sky, block, scale);
                break;
            case Plan.Quadruped:
                Quadruped(overlay, root, entity, bodyYaw, headYaw, pitch, walk, walkSpeed, colour, sky, block, scale);
                break;
            case Plan.Item:
                ItemEntity(overlay, root, entity, partialTick, sky, block);
                break;
            default:
                float w = (float)entity.Width * scale, h = (float)entity.Height * scale;
                Matrix4x4 m = Matrix4x4.CreateRotationY(-bodyYaw * MathF.PI / 180.0F) * root;
                overlay.Cuboid(m, new Vector3(-w / 2, 0, -w / 2), new Vector3(w / 2, h, w / 2), colour, sky, block);
                // A darker patch on the front, so which way it faces reads.
                overlay.Cuboid(m, new Vector3(-w / 4, h * 0.6F, w / 2), new Vector3(w / 4, h * 0.85F, w / 2 + 0.02F), Tint(colour, 0xFF000000, 0.5F), sky, block);
                break;
        }
    }

    private uint ColourOf(IEntityType type) {
        if (!_colours.TryGetValue(type, out uint colour)) {
            colour = type.Identifier.Key == "player" ? 0xFF3A6EA5 : 0xFF000000 | _art.ColourOf(type.Identifier.Key);
            _colours[type] = colour;
        }
        return colour;
    }

    private static Plan PlanOf(IEntityType type) => type.Identifier.Key switch {
        "item" => Plan.Item,
        var path when Humanoids.Contains(path) => Plan.Humanoid,
        var path when Quadrupeds.Contains(path) => Plan.Quadruped,
        _ => Plan.Box
    };

    private static uint Tint(uint argb, uint towards, float amount) {
        uint Channel(int shift) => (uint)((((argb >> shift) & 0xFF) * (1 - amount)) + (((towards >> shift) & 0xFF) * amount)) & 0xFF;
        return (argb & 0xFF000000) | Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }

    /// <summary>
    /// The upright plan in eighths of the entity's height: legs to 3/8, body to 6/8, head above, arms
    /// either side of the body. Limbs swing about the hip and shoulder with the walk cycle.
    /// </summary>
    private static void Humanoid(EntityBatch overlay, Matrix4x4 at, ClientEntity entity, float bodyYaw, float headYaw, float pitch,
        float walk, float walkSpeed, uint colour, float sky, float block, float scale) {
        float h = (float)entity.Height * scale;
        bool crouching = entity.IsCrouching;
        float u = h / 8.0F;
        float halfBody = u * 1.0F;
        float limb = u * 0.5F;
        float swing = MathF.Cos(walk * 0.6662F) * 1.4F * Math.Min(walkSpeed, 1.0F) * 0.5F;
        Matrix4x4 body = Matrix4x4.CreateRotationY(-bodyYaw * MathF.PI / 180.0F) * at;

        uint legs = Tint(colour, 0xFF202040, 0.4F);
        uint skin = Tint(colour, 0xFFE0B090, entity.Type.Identifier.Key == "player" ? 0.7F : 0.25F);
        float hip = u * 3;
        Limb(overlay, body, new Vector3(-limb, hip, 0), swing, new Vector3(-limb, -hip, -limb), new Vector3(limb, 0, limb), legs, sky, block);
        Limb(overlay, body, new Vector3(limb, hip, 0), -swing, new Vector3(-limb, -hip, -limb), new Vector3(limb, 0, limb), legs, sky, block);

        float lean = crouching ? 0.5F : 0.0F;
        Matrix4x4 torso = Matrix4x4.CreateRotationX(lean) * Matrix4x4.CreateTranslation(0, hip, 0) * body;
        overlay.Cuboid(torso, new Vector3(-halfBody, 0, -limb), new Vector3(halfBody, u * 3, limb), colour, sky, block);

        float shoulder = u * 3;
        float armSwing = -swing;
        if (entity.SwingState.Animation > 0) {
            armSwing -= MathF.Sin(entity.SwingState.Animation * MathF.PI) * 1.2F;
        }
        Limb(overlay, torso, new Vector3(-halfBody - limb, shoulder, 0), -swing, new Vector3(-limb, -u * 3, -limb), new Vector3(limb, 0, limb), skin, sky, block);
        Limb(overlay, torso, new Vector3(halfBody + limb, shoulder, 0), armSwing, new Vector3(-limb, -u * 3, -limb), new Vector3(limb, 0, limb), skin, sky, block);

        float relativeHead = ClientEntity.Wrap(headYaw - bodyYaw);
        Matrix4x4 head = Matrix4x4.CreateRotationX(pitch * MathF.PI / 180.0F) * Matrix4x4.CreateRotationY(-relativeHead * MathF.PI / 180.0F)
                         * Matrix4x4.CreateTranslation(0, u * 3, 0) * torso;
        float halfHead = u;
        overlay.Cuboid(head, new Vector3(-halfHead, 0, -halfHead), new Vector3(halfHead, u * 2, halfHead), skin, sky, block);
        // Eyes on the face, so which way it looks reads.
        uint eyes = Tint(skin, 0xFF000000, 0.7F);
        overlay.Cuboid(head, new Vector3(-halfHead * 0.6F, u * 1.0F, halfHead), new Vector3(-halfHead * 0.2F, u * 1.3F, halfHead + 0.01F), eyes, sky, block);
        overlay.Cuboid(head, new Vector3(halfHead * 0.2F, u * 1.0F, halfHead), new Vector3(halfHead * 0.6F, u * 1.3F, halfHead + 0.01F), eyes, sky, block);
    }

    private static void Limb(EntityBatch overlay, Matrix4x4 parent, Vector3 pivot, float angle, Vector3 min, Vector3 max, uint colour, float sky, float block) {
        Matrix4x4 m = Matrix4x4.CreateRotationX(angle) * Matrix4x4.CreateTranslation(pivot) * parent;
        overlay.Cuboid(m, min, max, colour, sky, block);
    }

    /// <summary>Body along the facing, head out front, a leg at each corner.</summary>
    private static void Quadruped(EntityBatch overlay, Matrix4x4 at, ClientEntity entity, float bodyYaw, float headYaw, float pitch,
        float walk, float walkSpeed, uint colour, float sky, float block, float scale) {
        float w = (float)entity.Width * scale, h = (float)entity.Height * scale;
        float legHeight = h * 0.4F;
        float leg = w * 0.12F;
        float swing = MathF.Cos(walk * 0.6662F) * 1.4F * Math.Min(walkSpeed, 1.0F) * 0.5F;
        Matrix4x4 body = Matrix4x4.CreateRotationY(-bodyYaw * MathF.PI / 180.0F) * at;
        float halfWidth = w * 0.4F, halfLength = w * 0.7F;
        uint legs = Tint(colour, 0xFF000000, 0.25F);
        foreach ((float x, float z, float sign) in new[] { (-1F, -1F, 1F), (1F, -1F, -1F), (-1F, 1F, -1F), (1F, 1F, 1F) }) {
            Limb(overlay, body, new Vector3(x * (halfWidth - leg), legHeight, z * (halfLength - leg)), swing * sign,
                new Vector3(-leg, -legHeight, -leg), new Vector3(leg, 0, leg), legs, sky, block);
        }
        overlay.Cuboid(body, new Vector3(-halfWidth, legHeight, -halfLength), new Vector3(halfWidth, h * 0.85F, halfLength), colour, sky, block);

        float relativeHead = ClientEntity.Wrap(headYaw - bodyYaw);
        float headSize = w * 0.35F;
        Matrix4x4 head = Matrix4x4.CreateRotationX(pitch * MathF.PI / 180.0F) * Matrix4x4.CreateRotationY(-relativeHead * MathF.PI / 180.0F)
                         * Matrix4x4.CreateTranslation(0, h * 0.75F, halfLength) * body;
        overlay.Cuboid(head, new Vector3(-headSize, -headSize, 0), new Vector3(headSize, headSize, headSize * 1.6F), Tint(colour, 0xFFFFFFFF, 0.1F), sky, block);
        uint eyes = Tint(colour, 0xFF000000, 0.75F);
        overlay.Cuboid(head, new Vector3(-headSize * 0.7F, 0, headSize * 1.6F), new Vector3(-headSize * 0.3F, headSize * 0.35F, headSize * 1.6F + 0.01F), eyes, sky, block);
        overlay.Cuboid(head, new Vector3(headSize * 0.3F, 0, headSize * 1.6F), new Vector3(headSize * 0.7F, headSize * 0.35F, headSize * 1.6F + 0.01F), eyes, sky, block);
    }

    /// <summary>A dropped item: a small cube that bobs and turns, as <c>ItemEntityRenderer</c> animates one.</summary>
    private void ItemEntity(EntityBatch overlay, Matrix4x4 at, ClientEntity entity, float partialTick, float sky, float block) {
        ItemStack? stack = entity.Get(EntityDataFields.ItemEntity.Item);
        uint colour = 0xFF000000 | (stack != null ? _art.ColourOf(stack.Type.Identifier.Key) : 0xA0A0A0u);
        float age = entity.TickCount + partialTick;
        float bob = MathF.Sin(age / 10.0F + entity.Id) * 0.1F + 0.1F;
        float spin = (age / 20.0F + entity.Id) * 57.29578F;
        Matrix4x4 m = Matrix4x4.CreateRotationY(spin * MathF.PI / 180.0F) * Matrix4x4.CreateTranslation(0, bob + 0.125F, 0) * at;
        overlay.Cuboid(m, new Vector3(-0.125F), new Vector3(0.125F), colour, sky, block);
    }
}
