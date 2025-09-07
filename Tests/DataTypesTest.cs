using System.Collections;
using Minecraft;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Newtonsoft.Json;

namespace Tests;

public class DataTypesTest {
    
    [Test]
    public void TestBlockPosition() {
        Vec3<int> position = new(143, 532, 353);
        Vec3<int> redone = new DataReader(new DataWriter().WritePosition(position).ToArray()).ReadPosition();
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
    
    public static long[] PackToLongArray(int[] data, int bitsPerEntry) {
        double intsPerLong = Math.Floor(64d / bitsPerEntry);
        int intsPerLongCeil = (int)Math.Ceiling(intsPerLong);
        
        int longCount = (int)Math.Ceiling((double)data.Length / intsPerLongCeil);
        long[] outp = new long[longCount];

        long mask = (1L << bitsPerEntry) - 1L;
        for (int i = 0; i < data.Length; i++) {
            int longIndex = i / intsPerLongCeil;
            int subIndex = i % intsPerLongCeil;

            outp[longIndex] |= ((long)data[i] & mask) << (bitsPerEntry * subIndex);
        }

        return outp;
    }

    [Test]
    public void TestPacketDataArray() {
        ushort[] someData = [31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 28, 29, 30, 1, 2, 3, 4, 5, 7];
        byte[] packedData = new DataWriter().WritePacketDataArray(5, someData).ToArray();
        ushort[] unpackedData = new DataReader(packedData).ReadPacketDataArray(5, someData.Length);
        
        long[] packed = PackToLongArray(someData.Select(us => (int)us).ToArray(), 5);
        
        byte[] packedData2 = new DataWriter().WriteArray(packed, (l, writer) => writer.WriteLong(l)).ToArray();
        
        Assert.That(packedData.SequenceEqual(packedData2), Is.True);
        
        Assert.That(unpackedData, Has.Length.EqualTo(someData.Length));
        
        for (int i = 0; i < someData.Length; i++) {
            Assert.That(unpackedData[i], Is.EqualTo(someData[i]));
        }
    }

    [Test]
    public void TestLengthPrefixedPacketDataArray() {
        ushort[] someData = [31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 31, 23, 04, 16, 28, 29, 30, 1, 2, 3, 4, 5, 7];
        byte[] packedData = new DataWriter().WritePrefixedPacketDataArray(5, someData).ToArray();
        ushort[] unpackedData = new DataReader(packedData).ReadPrefixedPacketDataArray(5);
        
    }

    [Test]
    public void TestBitArrayRange() {
        BitArray arr = new(new bool[] {true, true, false, false, true, false, true});
        BitArray range = arr.Range(1, 3);
        Assert.That(range, Is.EqualTo(new bool[] {true, false, false}));
    }
    
    [Test]
    public void TestDouble() {
        const double value = 123.456789;
        byte[] data = new DataWriter().WriteDouble(value).ToArray();
        double back = new DataReader(data).ReadDouble();
        
        Assert.That(back, Is.EqualTo(value));
    }

    [Test]
    public void TestIdentifierJson() {
        Identifier id = "minecraft:stone";
        Console.WriteLine(id);
        string json = JsonConvert.SerializeObject(id);
        Console.WriteLine(json);
        Identifier back = JsonConvert.DeserializeObject<Identifier>(json);
        Console.WriteLine(back);
        Assert.That(back, Is.EqualTo(id));
    }
}