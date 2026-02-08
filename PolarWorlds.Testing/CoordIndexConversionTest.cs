namespace PolarWorlds.Testing;

public class CoordIndexConversionTest {
    
    [Test]
    public void TestCoordIndexes() {
        for (int x = 0; x < 16; x++) {
            for (int y = -256; y < 256; y++) {
                for (int z = 0; z < 16; z++) {
                    TestIndex(x, y, z);
                }
            }
        }
    }

    private static void TestIndex(int x, int y, int z) {
        int index = PolarLoader.GetIndexFromCoords(x, y, z);
        int x2 = PolarLoader.GetXFromIndex(index);
        int y2 = PolarLoader.GetYFromIndex(index);
        int z2 = PolarLoader.GetZFromIndex(index);
        Assert.That(x2, Is.EqualTo(x));
        Assert.That(y2, Is.EqualTo(y));
        Assert.That(z2, Is.EqualTo(z));
    }
}
