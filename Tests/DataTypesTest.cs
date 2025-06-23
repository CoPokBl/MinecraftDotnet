using System.Collections;
using Minecraft;
using Minecraft.Schemas;

namespace Tests;

public class DataTypesTest {
    
    [Test]
    public void TestBlockPosition() {
        BlockPosition position = new(143, 532, 353);
        BlockPosition redone = new DataReader(new DataWriter().WritePosition(position).ToArray()).ReadPosition();
        Assert.Multiple(() => {
            Assert.That(redone.X, Is.EqualTo(position.X));
            Assert.That(redone.Y, Is.EqualTo(position.Y));
            Assert.That(redone.Z, Is.EqualTo(position.Z));
        });
    }

    [Test]
    public void TestInt() {
        byte[] norInt = new DataWriter().WriteInteger(5).ToArray();
        int backInt = new DataReader(norInt).ReadInteger();
        
        Assert.That(backInt, Is.EqualTo(5));
    }

    [Test]
    public void TestShort() {
        short backShort = new DataReader(new DataWriter().WriteShort(5).ToArray()).ReadShort();
        Assert.That(backShort, Is.EqualTo(5));
    }

    [Test]
    public void TestNBitInteger() {
        Assert.That(DataReader.FromNBitInteger(5, DataWriter.ToNBitInteger(5, 25)), Is.EqualTo(25));
        Assert.That(DataReader.FromNBitInteger(5, DataWriter.ToNBitInteger(5, 3)), Is.EqualTo(3));
    }

    [Test]
    public void TestPacketDataArray() {
        long[] someData = [31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 28, 29, 30, 1, 2, 3, 4, 5, 7];
        byte[] packedData = new DataWriter().WritePacketDataArray(5, someData).ToArray();
        long[] unpackedData = new DataReader(packedData).ReadPacketDataArray(5, someData.Length);
        Assert.That(unpackedData, Has.Length.EqualTo(someData.Length));
        
        for (int i = 0; i < someData.Length; i++) {
            Assert.That(unpackedData[i], Is.EqualTo(someData[i]));
        }
    }

    [Test]
    public void TestBitArrayRange() {
        BitArray arr = new([true, true, false, false, true, false, true]);
        BitArray range = arr.Range(1, 3);
        Assert.That(range, Is.EqualTo([true, false, false]));
    }
}