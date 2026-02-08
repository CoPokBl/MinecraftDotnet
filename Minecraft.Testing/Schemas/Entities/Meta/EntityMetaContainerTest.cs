using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Testing.Schemas.Entities.Meta;

public class EntityMetaContainerTest {
    // to properly test, this needs to have one of each field
    private static readonly (MetaFieldType Type, object Value)[] TestFields = [
        (MetaFieldType.Byte, (sbyte)123),
        (MetaFieldType.VarInt, 12345),
        (MetaFieldType.VarLong, 1234567890123456789),
        (MetaFieldType.Float, 3.14f),
        (MetaFieldType.String, "Hello, world!"),
        (MetaFieldType.TextComponent, TextComponent.Text("Hello, world!")),
        (MetaFieldType.OptionalTextComponent, new Optional<TextComponent>(TextComponent.Text("Hello, world!"))),
        (MetaFieldType.Slot, new ItemStack(Item.AcaciaBoat)),
        (MetaFieldType.Boolean, true),
        (MetaFieldType.Rotations, new Vec3<float>(1.0f, 2.0f, 3.0f)),
        (MetaFieldType.Position, new Vec3<int>(100, 64, 100)),
        (MetaFieldType.OptionalPosition, new Optional<Vec3<int>>(new Vec3<int>(100, 64, 100))),
        (MetaFieldType.Direction, Cardinal.North),
        (MetaFieldType.OptionalLivingEntityReference, new Optional<Guid>(Guid.NewGuid())),
        (MetaFieldType.BlockState, Block.AcaciaLog with {
            Axis = Axis.Z
        }),
        (MetaFieldType.OptionalBlockState, new Optional<IBlock>(Block.AcaciaLog with {
            Axis = Axis.Z
        })),
        (MetaFieldType.Particle, Particle.BubbleColumnUp),
        (MetaFieldType.Particles, new IParticle[] {Particle.AngryVillager}),
        (MetaFieldType.VillagerData, (0, 1, 2)),
        (MetaFieldType.OptionalVarInt, new Optional<int>(12345)),
        (MetaFieldType.Pose, EntityPose.Inhaling),
        (MetaFieldType.CatVariant, 7),
        (MetaFieldType.CowVariant, 3),
        (MetaFieldType.WolfVariant, 5),
        (MetaFieldType.WolfSoundVariant, 2),
        (MetaFieldType.FrogVariant, 1),
        (MetaFieldType.PigVariant, 4),
        (MetaFieldType.ChickenVariant, 6),
        (MetaFieldType.ZombieNautilusVariant, 2),
        (MetaFieldType.OptionalGlobalPosition, new Optional<(Identifier Dimension, Vec3<int> Position)>(("minecraft:overworld", new Vec3<int>(100, 64, 100)))),
        (MetaFieldType.PaintingVariant, Or<int, PaintingVariant>.FromValue1(5)),
        (MetaFieldType.SnifferState, SnifferState.Rising),
        (MetaFieldType.ArmadilloState, ArmadilloState.Rolling),
        (MetaFieldType.CopperGolemState, CopperGolemState.GettingItem),
        (MetaFieldType.WeatheringCopperState, WeatheringCopperState.Exposed),
        (MetaFieldType.Vector3, new Vec3<float>(1.0f, 2.0f, 3.0f)),
        (MetaFieldType.Quaternion, new Quaternion(5, 6, 7, 8)),
        (MetaFieldType.HumanoidArm, HumanoidArm.Right)
    ];

    [Test]
    public void SerialiseDeserialise() {
        EntityMetaContainer container = new();
        
        for (int i = 0; i < TestFields.Length; i++) {
            (MetaFieldType fieldType, object value) = TestFields[i];
            container.Fields.Add(i, new MetaField(fieldType, value));
        }
        
        DataWriter writer = new();
        container.Write(VanillaRegistry.Data, writer);
        
        DataReader reader = new(writer.ToArray());
        EntityMetaContainer deserialised = new();
        deserialised.ReadData(VanillaRegistry.Data, reader);
        
        Assert.That(deserialised.Fields.Count, Is.EqualTo(TestFields.Length));
        for (int i = 0; i < TestFields.Length; i++) {
            (MetaFieldType fieldType, object value) = TestFields[i];
            Assert.That(deserialised.Fields.ContainsKey(i), $"Field {i} is missing");
            MetaField field = deserialised.Fields[i];
            Assert.That(field.Type, Is.EqualTo(fieldType), $"Field {i} has incorrect type");

            if (field.Type is MetaFieldType.TextComponent 
                or MetaFieldType.OptionalTextComponent) {
                continue;  // no .Equals support
            }
            
            Assert.That(field.Value, Is.EqualTo(value), $"Field {i} has incorrect value");
        }
    }

    [Test]
    public void LoadingIntoObjects() {
        EntityMetaContainer container = new();
        container.WithField(0, MetaFieldType.Byte, (sbyte)EntityStatus.Invisible);
        container.WithField(8, MetaFieldType.Byte, (sbyte)HandState.IsRiptideSpinAttacking);
        container.WithField(16, MetaFieldType.Byte, (sbyte)SkinParts.LeftSleeveEnabled);
        
        AvatarMeta meta = (AvatarMeta)new AvatarMeta().LoadFields(container);
        Assert.That(meta.Status, Is.EqualTo(EntityStatus.Invisible));
        Assert.That(meta.HandStates, Is.EqualTo(HandState.IsRiptideSpinAttacking));
        Assert.That(meta.SkinFlags, Is.EqualTo(SkinParts.LeftSleeveEnabled));
    }
}
