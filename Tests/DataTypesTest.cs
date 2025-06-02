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

        byte[] norInt = new DataWriter().WriteInt(5).ToArray();
        int backInt = new DataReader(norInt).ReadInteger();
        
        Assert.That(backInt, Is.EqualTo(5));
        
        short backShort = new DataReader(new DataWriter().WriteShort(5).ToArray()).ReadShort();
        Assert.That(backShort, Is.EqualTo(5));
        
        // long[] someData = [34, 56, 78, 90];
        // byte[] packedData = new DataWriter().WritePacketDataArray(5, someData, true).ToArray();
        // long[] unpackedData = new DataReader(packedData).ReadPacketDataArray(5, -1);
        // Assert.That(unpackedData.Length, Is.EqualTo(someData.Length));
        //
        // for (int i = 0; i < someData.Length; i++) {
        //     Assert.That(unpackedData[i], Is.EqualTo(someData[i]));
        // }
    }
}