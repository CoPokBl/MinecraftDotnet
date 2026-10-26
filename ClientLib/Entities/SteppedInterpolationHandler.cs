using ClientLib.Maths;

namespace ClientLib.Entities;

/// <summary>
/// <c>SteppedInterpolationHandler</c>, every living entity's: it follows each step of a stepped path in
/// the ticks the server gave it, and runs faster than one tick a tick while it has fallen behind.
/// </summary>
public sealed class SteppedInterpolationHandler(MinecraftClient client, ClientEntity entity, int updateInterval)
    : AbstractInterpolationHandler(client, entity, updateInterval) {
    private readonly Data _data = new();

    protected override MutablePositionAndRotation InterpolationData => _data;

    /// <remarks>
    /// The end is compared with the last target even when nothing is in progress, so a path that ends
    /// where the previous one did is taken in one step whatever it passes through.
    /// </remarks>
    protected override void StartInterpolating(PositionPath position, float yRot, float xRot) {
        if (!HasActiveInterpolation) {
            _data.SetStartingPoint(Entity.Position, Entity.YRot, Entity.XRot);
        }

        Vec3d endPosition = position.EndPosition;
        if (PositionPath.JavaEquals(endPosition, _data.Position)) {
            _data.AddStep(endPosition, yRot, xRot, InterpolationSteps);
        }
        else {
            _data.AddSteps(position, yRot, xRot, InterpolationSteps);
        }

        _data.Set(endPosition, yRot, xRot);
    }

    protected override void DoInterpolate() {
        PositionAndRotation target = _data.GetNewPositionAndRotation();
        Entity.Position = target.Position;
        Entity.SetRot(target.YRot, target.XRot);
        _data.Advance(RelativeTickSpeed, InterpolationSteps);
    }

    public override bool HasActiveInterpolation => _data.RemainingSteps.Count > 0;

    public override void Cancel() => _data.Reset();

    private static float Lerp(float alpha, float from, float to) => from + alpha * (to - from);

    private static float RotLerp(float alpha, float from, float to) => from + alpha * ClientEntity.Wrap(to - from);

    private sealed class Data : MutablePositionAndRotation {
        public readonly LinkedList<Step> RemainingSteps = new();
        private readonly MutablePositionAndRotation _lastStepPosRot = new();
        private float _currentStepTicks;
        private float _remainingTicks;
        private float _interpolationSpeed = 1.0F;

        public void Advance(float ticks, int interpolationSteps) {
            float targetSpeed = Math.Max(_remainingTicks / interpolationSteps, 1.0F);
            _interpolationSpeed = Lerp(1.0F / interpolationSteps, _interpolationSpeed, targetSpeed);
            if (ticks * _interpolationSpeed < _remainingTicks) {
                ticks *= _interpolationSpeed;
            }
            else {
                ticks = _remainingTicks;
                _interpolationSpeed = 1.0F;
            }

            _currentStepTicks += ticks;
            _remainingTicks -= ticks;
        }

        public void Reset() {
            RemainingSteps.Clear();
            _remainingTicks = 0.0F;
            _interpolationSpeed = 1.0F;
        }

        public override void AddDelta(Vec3d delta) {
            base.AddDelta(delta);
            foreach (Step step in RemainingSteps) {
                step.AddDelta(delta);
            }
            _lastStepPosRot.AddDelta(delta);
        }

        public override void AddRotation(float yRot, float xRot) {
            base.AddRotation(yRot, xRot);
            foreach (Step step in RemainingSteps) {
                step.AddRotation(yRot, xRot);
            }
            _lastStepPosRot.AddRotation(yRot, xRot);
        }

        public void SetStartingPoint(Vec3d position, float yRot, float xRot) {
            _lastStepPosRot.Set(position, yRot, xRot);
            _currentStepTicks = 1.0F;
        }

        public void AddStep(Vec3d position, float yRot, float xRot, int interpolationSteps) {
            RemainingSteps.AddLast(new Step(position, yRot, xRot, interpolationSteps));
            _remainingTicks += interpolationSteps;
        }

        /// <remarks>
        /// A turn is spread over the steps by how far through the path's ticks each one lands, starting
        /// from the last target's rotation rather than the entity's.
        /// </remarks>
        public void AddSteps(PositionPath position, float yRot, float xRot, int interpolationSteps) {
            switch (position) {
                case PositionPath.Linear linear:
                    AddStep(linear.End, yRot, xRot, interpolationSteps);
                    break;
                case PositionPath.Stepped stepped: {
                    IReadOnlyList<PositionStep> steps = stepped.Steps;
                    if (yRot == YRot && xRot == XRot) {
                        foreach (PositionStep step in steps) {
                            AddStep(step.Position, yRot, xRot, step.TickOffset);
                        }
                        return;
                    }

                    int totalInterpolationTicks = 0;
                    foreach (PositionStep step in steps) {
                        totalInterpolationTicks += step.TickOffset;
                    }
                    int offset = 0;
                    foreach (PositionStep step in steps) {
                        offset += step.TickOffset;
                        float a = (float)offset / totalInterpolationTicks;
                        AddStep(step.Position, RotLerp(a, YRot, yRot), Lerp(a, XRot, xRot), step.TickOffset);
                    }
                    break;
                }
            }
        }

        public PositionAndRotation GetNewPositionAndRotation() {
            while (RemainingSteps.First is { } first) {
                Step step = first.Value;
                int offset = step.TickOffset;
                if (_currentStepTicks < offset) {
                    float a = _currentStepTicks / offset;
                    Vec3d from = _lastStepPosRot.Position;
                    Vec3d to = step.Position;
                    return new PositionAndRotation(
                        new Vec3d(ClientEntity.Lerp(a, from.X, to.X), ClientEntity.Lerp(a, from.Y, to.Y), ClientEntity.Lerp(a, from.Z, to.Z)),
                        RotLerp(a, _lastStepPosRot.YRot, step.YRot),
                        Lerp(a, _lastStepPosRot.XRot, step.XRot));
                }

                _currentStepTicks -= offset;
                _lastStepPosRot.Set(step.Position, step.YRot, step.XRot);
                RemainingSteps.RemoveFirst();
            }

            return Immutable();
        }
    }

    private sealed class Step : MutablePositionAndRotation {
        public readonly int TickOffset;

        public Step(Vec3d position, float yRot, float xRot, int tickOffset) {
            TickOffset = tickOffset;
            Set(position, yRot, xRot);
        }
    }
}
