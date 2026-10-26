namespace GraphicalClient.Rendering.Entities;

/// <summary><c>Ease</c>: the curves the spear's animations read.</summary>
public static class Ease {
    public static float InQuad(float x) => x * x;

    public static float InCirc(float x) => (float)-Math.Sqrt(1.0F - x * x) + 1.0F;

    public static float OutCirc(float x) => (float)Math.Sqrt(1.0F - Mth.Square(x - 1.0F));

    public static float OutCubic(float x) => 1.0F - Mth.Cube(1.0F - x);

    public static float OutQuart(float x) => 1.0F - Mth.Square(Mth.Square(1.0F - x));

    public static float InOutSine(float x) => -(Mth.Cos(MathF.PI * x) - 1.0F) / 2.0F;

    public static float OutBack(float x) => 1.0F + 2.70158F * Mth.Cube(x - 1.0F) + 1.70158F * Mth.Square(x - 1.0F);

    public static float InOutBack(float x) {
        if (x < 0.5F) {
            return 4.0F * x * x * (7.189819F * x - 2.5949094F) / 2.0F;
        }
        float dt = 2.0F * x - 2.0F;
        return (dt * dt * (3.5949094F * dt + 2.5949094F) + 2.0F) / 2.0F;
    }

    public static float InOutExpo(float x) {
        if (x < 0.5F) {
            return x == 0.0F ? 0.0F : (float)(Math.Pow(2.0, 20.0 * x - 10.0) / 2.0);
        }
        return x == 1.0F ? 1.0F : (float)((2.0 - Math.Pow(2.0, -20.0 * x + 10.0)) / 2.0);
    }

    public static float InOutElastic(float x) {
        if (x == 0.0F) {
            return 0.0F;
        }
        if (x == 1.0F) {
            return 1.0F;
        }
        double sin = Math.Sin((20.0 * x - 11.125) * (float)Math.PI * 4.0F / 9.0F);
        return x < 0.5F ? (float)(-(Math.Pow(2.0, 20.0 * x - 10.0) * sin) / 2.0) : (float)(Math.Pow(2.0, -20.0 * x + 10.0) * sin / 2.0 + 1.0);
    }
}
