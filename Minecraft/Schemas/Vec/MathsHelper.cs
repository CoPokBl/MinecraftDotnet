using System.Numerics;

namespace Minecraft.Schemas.Vec;

public static class MathsHelper {

    public static double ToDouble<T>(this T value) where T : INumber<T> {
        return value switch {
            double d => d,
            float f => f,
            int i => i,
            long l => l,
            short s => s,
            byte b => b,
            decimal dec => (double)dec,
            sbyte sb => sb,
            uint ui => ui,
            ulong ul => ul,
            ushort us => us,
            BigInteger bi => (double)bi,
            Int128 i => (double)i,
            UInt128 ui => (double)ui,
            nuint ui => ui,
            nint ni => ni,
            char c => c,
            Half h => (double)h,
            _ => throw new InvalidCastException($"Cannot convert {typeof(T)} to double.")
        };
    }
    
    public static T FromDouble<T>(this double value) where T : INumber<T> {
        return T.CreateChecked(value);
    }
    
    public static float ToFloat<T>(this T value) where T : INumber<T> {
        return value switch {
            double d => (float)d,
            float f => f,
            int i => i,
            long l => l,
            short s => s,
            byte b => b,
            decimal dec => (float)dec,
            sbyte sb => sb,
            uint ui => ui,
            ulong ul => ul,
            ushort us => us,
            BigInteger bi => (float)bi,
            Int128 i => (float)i,
            UInt128 ui => (float)ui,
            nuint ui => ui,
            nint ni => ni,
            char c => c,
            Half h => (float)h,
            _ => throw new InvalidCastException($"Cannot convert {typeof(T)} to float.")
        };
    }
}
