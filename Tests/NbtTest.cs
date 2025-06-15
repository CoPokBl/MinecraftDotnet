using Minecraft.NBT;
using Minecraft.NBT.Tags;
using Minecraft.NBT.Text;

namespace Tests;

public class NbtTest {

    [Test]
    public void SerialiseDeserialise() {
        TestTagNoErrors(new BooleanTag(null, true), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(ByteTag)));
            Assert.That(((ByteTag)tag).Value, Is.EqualTo(0x01));
        });
        TestTagNoErrors(new ByteTag(null, 0x56), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(ByteTag)));
            Assert.That(((ByteTag)tag).Value, Is.EqualTo(0x56));
        });
        TestTagNoErrors(new DoubleTag(null, 56.34), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(DoubleTag)));
            Assert.That(((DoubleTag)tag).Value, Is.EqualTo(56.34));
        });
        TestTagNoErrors(new FloatTag(null, 56.34f), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(FloatTag)));
            Assert.That(((FloatTag)tag).Value, Is.EqualTo(56.34f));
        });
        TestTagNoErrors(new IntegerTag(null, 6), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(IntegerTag)));
            Assert.That(((IntegerTag)tag).Value, Is.EqualTo(6));
        });
        TestTagNoErrors(new StringTag(null, "hello there"), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(StringTag)));
            Assert.That(((StringTag)tag).Value, Is.EqualTo("hello there"));
        });
        TestTagNoErrors(new CompoundTag(null), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(CompoundTag)));
            Assert.That(((CompoundTag)tag).Children, Is.Empty);
        });
        TestTagNoErrors(new CompoundTag(null, 
                new BooleanTag("potato", true), 
                new IntegerTag("someint", 7)
                ), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(CompoundTag)));
            CompoundTag comp = (CompoundTag)tag;
            
            Assert.That(comp.Children, Has.Length.EqualTo(2));
            Assert.Multiple(() => {
                Assert.That(comp.Children[0], Is.AssignableTo(typeof(ByteTag)));
                Assert.That(((ByteTag)comp.Children[0]!).Value, Is.EqualTo(0x01));
                Assert.That(((ByteTag)comp.Children[0]!).Name, Is.EqualTo("potato"));
            });
            Assert.Multiple(() => {
                Assert.That(comp.Children[1], Is.AssignableTo(typeof(IntegerTag)));
                Assert.That(((IntegerTag)comp.Children[1]!).Value, Is.EqualTo(7));
                Assert.That(((IntegerTag)comp.Children[1]!).Name, Is.EqualTo("someint"));
            });
        });
        TestTagNoErrors(new ListTag<IntegerTag>(null, 
        [
            new IntegerTag(null, 7), 
            new IntegerTag(null, 2)
        ]), tag => {
            Assert.That(tag, Is.AssignableTo(typeof(ListTag<IntegerTag>)));
            ListTag<IntegerTag> comp = (ListTag<IntegerTag>)tag;
            Assert.That(comp.Tags, Has.Length.EqualTo(2));
            
            Assert.Multiple(() => {
                Assert.That(comp.Tags[0], Is.AssignableTo(typeof(IntegerTag)));
                Assert.That(comp.Tags[0].Value, Is.EqualTo(7));
            });
            Assert.Multiple(() => {
                Assert.That(comp.Tags[1], Is.AssignableTo(typeof(IntegerTag)));
                Assert.That(comp.Tags[1].Value, Is.EqualTo(2));
            });
        });
        
        // More complex
        TestTagNoErrors(
            TextComponent.Text("Hello")
                .WithColor(TextColor.Red)
                .With(TextComponent.Text(" World").WithBold()), 
            tag => TextComponent.FromTag(tag));
    }

    private static void TestTagNoErrors(ITag tag, Action<ITag>? checker = null) {
        ITag thing = NbtReader.ReadNbt(tag.Serialise());
        checker?.Invoke(thing);
    }
}