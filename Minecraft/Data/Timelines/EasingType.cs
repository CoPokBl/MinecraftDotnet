using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Timelines;

/// <summary><c>EasingType</c>: how a keyframe track moves between two keyframes.</summary>
public abstract class EasingType {
    public abstract float Apply(float x);

    private sealed class Simple(Func<float, float> ease) : EasingType {
        public override float Apply(float x) => ease(x);
    }

    public static readonly EasingType Constant = new Simple(_ => 0.0F);
    public static readonly EasingType Linear = new Simple(x => x);

    private static readonly Dictionary<string, EasingType> SimpleRegistry = new() {
        ["constant"] = Constant,
        ["linear"] = Linear,
        ["in_back"] = new Simple(Ease.InBack),
        ["in_bounce"] = new Simple(Ease.InBounce),
        ["in_circ"] = new Simple(Ease.InCirc),
        ["in_cubic"] = new Simple(Ease.InCubic),
        ["in_elastic"] = new Simple(Ease.InElastic),
        ["in_expo"] = new Simple(Ease.InExpo),
        ["in_quad"] = new Simple(Ease.InQuad),
        ["in_quart"] = new Simple(Ease.InQuart),
        ["in_quint"] = new Simple(Ease.InQuint),
        ["in_sine"] = new Simple(Ease.InSine),
        ["in_out_back"] = new Simple(Ease.InOutBack),
        ["in_out_bounce"] = new Simple(Ease.InOutBounce),
        ["in_out_circ"] = new Simple(Ease.InOutCirc),
        ["in_out_cubic"] = new Simple(Ease.InOutCubic),
        ["in_out_elastic"] = new Simple(Ease.InOutElastic),
        ["in_out_expo"] = new Simple(Ease.InOutExpo),
        ["in_out_quad"] = new Simple(Ease.InOutQuad),
        ["in_out_quart"] = new Simple(Ease.InOutQuart),
        ["in_out_quint"] = new Simple(Ease.InOutQuint),
        ["in_out_sine"] = new Simple(Ease.InOutSine),
        ["out_back"] = new Simple(Ease.OutBack),
        ["out_bounce"] = new Simple(Ease.OutBounce),
        ["out_circ"] = new Simple(Ease.OutCirc),
        ["out_cubic"] = new Simple(Ease.OutCubic),
        ["out_elastic"] = new Simple(Ease.OutElastic),
        ["out_expo"] = new Simple(Ease.OutExpo),
        ["out_quad"] = new Simple(Ease.OutQuad),
        ["out_quart"] = new Simple(Ease.OutQuart),
        ["out_quint"] = new Simple(Ease.OutQuint),
        ["out_sine"] = new Simple(Ease.OutSine)
    };

    public static EasingType CubicBezier(float x1, float y1, float x2, float y2) => new CubicBezierEasing(x1, y1, x2, y2);

    public static EasingType SymmetricCubicBezier(float x1, float y1) => CubicBezier(x1, y1, 1.0F - x1, 1.0F - y1);

    /// <summary><c>EasingType.CODEC</c>: a simple easing's name, or <c>{cubic_bezier: [x1, y1, x2, y2]}</c>.</summary>
    public static EasingType FromNbt(INbtTag tag) {
        if (tag is StringTag name) {
            return SimpleRegistry.TryGetValue(name.Value, out EasingType? easing)
                ? easing
                : throw new FormatException($"Unknown easing type {name.Value}");
        }
        float[] controls = ((CompoundTag)tag)["cubic_bezier"]!.AsList().Select(c => c.AsFloat()).ToArray();
        return controls.Length == 4 ? CubicBezier(controls[0], controls[1], controls[2], controls[3]) : throw new FormatException("cubic_bezier takes four floats");
    }

    /// <summary><c>EasingType.CubicBezier</c>: x solved for t by four Newton steps, then by bisection.</summary>
    private sealed class CubicBezierEasing : EasingType {
        private readonly CubicCurve _xCurve;
        private readonly CubicCurve _yCurve;

        public CubicBezierEasing(float x1, float y1, float x2, float y2) {
            _xCurve = CurveFromControls(x1, x2);
            _yCurve = CurveFromControls(y1, y2);
        }

        private static CubicCurve CurveFromControls(float v1, float v2) => new(3.0F * v1 - 3.0F * v2 + 1.0F, -6.0F * v1 + 3.0F * v2, 3.0F * v1);

        public override float Apply(float x) => _yCurve.Sample(SolveT(x));

        private float SolveT(float x) {
            float t = x;
            for (int i = 0; i < 4; i++) {
                float error = _xCurve.Sample(t) - x;
                if (Math.Abs(error) < 1.0E-5F) {
                    return t;
                }
                float gradient = _xCurve.SampleGradient(t);
                if (gradient < 1.0E-5F) {
                    break;
                }
                t -= Mth.Clamp(error / gradient, -0.25F, 0.25F);
            }
            return SolveTBisect(x, t);
        }

        private float SolveTBisect(float x, float initialT) {
            float t0 = 0.0F;
            float t1 = 1.0F;
            float t;
            for (t = initialT; t0 < t1; t = (t1 + t0) / 2.0F) {
                float error = _xCurve.Sample(t) - x;
                if (Math.Abs(error) < 1.0E-5F) {
                    return t;
                }
                if (error < 0.0F) {
                    t0 = t;
                }
                else {
                    t1 = t;
                }
            }
            return t;
        }

        private readonly record struct CubicCurve(float A, float B, float C) {
            public float Sample(float t) => ((A * t + B) * t + C) * t;

            public float SampleGradient(float t) => (3.0F * A * t + 2.0F * B) * t + C;
        }
    }
}

/// <summary><c>Ease</c>, the simple easing curves.</summary>
public static class Ease {
    public static float InBack(float x) => Mth.Square(x) * (2.70158F * x - 1.70158F);

    public static float InBounce(float x) => 1.0F - OutBounce(1.0F - x);

    public static float InCubic(float x) => Mth.Cube(x);

    public static float InElastic(float x) {
        if (x == 0.0F) {
            return 0.0F;
        }
        if (x == 1.0F) {
            return 1.0F;
        }
        return (float)(-Math.Pow(2.0, 10.0 * x - 10.0) * Math.Sin((x * 10.0 - 10.75) * (float)(Math.PI * 2.0 / 3.0)));
    }

    public static float InExpo(float x) => x == 0.0F ? 0.0F : (float)Math.Pow(2.0, 10.0 * x - 10.0);

    public static float InQuart(float x) => Mth.Square(Mth.Square(x));

    public static float InQuint(float x) => Mth.Square(Mth.Square(x)) * x;

    public static float InSine(float x) => 1.0F - Mth.Cos(x * (float)(Math.PI / 2));

    public static float InOutBounce(float x) => x < 0.5F ? (1.0F - OutBounce(1.0F - 2.0F * x)) / 2.0F : (1.0F + OutBounce(2.0F * x - 1.0F)) / 2.0F;

    public static float InOutCirc(float x) => x < 0.5F
        ? (float)((1.0 - Math.Sqrt(1.0 - Math.Pow(2.0 * x, 2.0))) / 2.0)
        : (float)((Math.Sqrt(1.0 - Math.Pow(-2.0 * x + 2.0, 2.0)) + 1.0) / 2.0);

    public static float InOutCubic(float x) => x < 0.5F ? 4.0F * Mth.Cube(x) : (float)(1.0 - Math.Pow(-2.0 * x + 2.0, 3.0) / 2.0);

    public static float InOutQuad(float x) => x < 0.5F ? 2.0F * Mth.Square(x) : (float)(1.0 - Math.Pow(-2.0 * x + 2.0, 2.0) / 2.0);

    public static float InOutQuart(float x) => x < 0.5F ? 8.0F * Mth.Square(Mth.Square(x)) : (float)(1.0 - Math.Pow(-2.0 * x + 2.0, 4.0) / 2.0);

    public static float InOutQuint(float x) => x < 0.5 ? 16.0F * x * x * x * x * x : (float)(1.0 - Math.Pow(-2.0 * x + 2.0, 5.0) / 2.0);

    public static float OutBounce(float x) {
        if (x < 0.36363637F) {
            return 7.5625F * Mth.Square(x);
        }
        if (x < 0.72727275F) {
            return 7.5625F * Mth.Square(x - 0.54545456F) + 0.75F;
        }
        return x < 0.9090909090909091 ? 7.5625F * Mth.Square(x - 0.8181818F) + 0.9375F : 7.5625F * Mth.Square(x - 0.95454544F) + 0.984375F;
    }

    public static float OutElastic(float x) {
        if (x == 0.0F) {
            return 0.0F;
        }
        return x == 1.0F ? 1.0F : (float)(Math.Pow(2.0, -10.0 * x) * Math.Sin((x * 10.0 - 0.75) * (float)(Math.PI * 2.0 / 3.0)) + 1.0);
    }

    public static float OutExpo(float x) => x == 1.0F ? 1.0F : 1.0F - (float)Math.Pow(2.0, -10.0 * x);

    public static float OutQuad(float x) => 1.0F - Mth.Square(1.0F - x);

    public static float OutQuint(float x) => 1.0F - (float)Math.Pow(1.0 - x, 5.0);

    public static float OutSine(float x) => Mth.Sin(x * (float)(Math.PI / 2));

    public static float InOutSine(float x) => -(Mth.Cos((float)Math.PI * x) - 1.0F) / 2.0F;

    public static float OutBack(float x) => 1.0F + 2.70158F * Mth.Cube(x - 1.0F) + 1.70158F * Mth.Square(x - 1.0F);

    public static float OutQuart(float x) => 1.0F - Mth.Square(Mth.Square(1.0F - x));

    public static float OutCubic(float x) => 1.0F - Mth.Cube(1.0F - x);

    public static float InOutExpo(float x) {
        if (x < 0.5F) {
            return x == 0.0F ? 0.0F : (float)(Math.Pow(2.0, 20.0 * x - 10.0) / 2.0);
        }
        return x == 1.0F ? 1.0F : (float)((2.0 - Math.Pow(2.0, -20.0 * x + 10.0)) / 2.0);
    }

    public static float InQuad(float x) => x * x;

    public static float OutCirc(float x) => (float)Math.Sqrt(1.0F - Mth.Square(x - 1.0F));

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

    public static float InCirc(float x) => (float)-Math.Sqrt(1.0F - x * x) + 1.0F;

    public static float InOutBack(float x) {
        if (x < 0.5F) {
            return 4.0F * x * x * (7.189819F * x - 2.5949094F) / 2.0F;
        }
        float dt = 2.0F * x - 2.0F;
        return (dt * dt * (3.5949094F * dt + 2.5949094F) + 2.0F) / 2.0F;
    }
}
