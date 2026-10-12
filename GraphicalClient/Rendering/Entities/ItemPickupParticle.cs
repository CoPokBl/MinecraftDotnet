using ClientLib.Entities;
using ClientLib.Player;
using GraphicalClient.Audio;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>ItemPickupParticle</c>: a taken entity, as it was when taken, flying into whoever took it.</summary>
public sealed class ItemPickupParticle {
    public const int LifeTime = 3;

    private readonly ClientEntity _target;
    public readonly EntityRenderer Renderer;
    public readonly EntityRenderState ItemRenderState;
    public int Life;
    public double TargetX, TargetY, TargetZ;
    public double TargetXOld, TargetYOld, TargetZOld;

    public bool Removed { get; private set; }

    public ItemPickupParticle(EntityRenderer renderer, EntityRenderState itemRenderState, ClientEntity target) {
        Renderer = renderer;
        ItemRenderState = itemRenderState;
        ItemRenderState.OutlineColour = 0;
        _target = target;
        UpdatePosition();
        SaveOldPosition();
    }

    public void Tick() {
        Life++;
        if (Life == LifeTime) {
            Removed = true;
        }
        SaveOldPosition();
        UpdatePosition();
    }

    private void UpdatePosition() {
        TargetX = _target.Position.X;
        // Divergence: only the local player's eye height follows its pose; another entity's is its type's
        // standing one, so a crouching remote player draws the item a little higher than vanilla does.
        double eyeHeight = _target is LocalPlayer player ? player.CurrentEyeHeight : _target.EyeHeight;
        TargetY = (_target.Position.Y + (_target.Position.Y + eyeHeight)) / 2.0;
        TargetZ = _target.Position.Z;
    }

    private void SaveOldPosition() {
        TargetXOld = TargetX;
        TargetYOld = TargetY;
        TargetZOld = TargetZ;
    }
}

/// <summary>
/// <c>ItemPickupParticleGroup</c> with the parts of <c>ParticleEngine</c> and <c>ParticleGroup</c> it goes
/// through: a particle added waits in the engine's queue until the end of the next tick, so it is neither
/// ticked nor drawn before then.
/// </summary>
public sealed class ItemPickupParticleGroup {
    private const int MaxParticles = 16384;
    private const int ReservoirSize = 4096;
    private const int ReservoirStart = 12288;

    private readonly List<ItemPickupParticle> _particles = [];
    private readonly Queue<ItemPickupParticle> _particlesToAdd = new();
    // ParticleEngine.random.
    private readonly LegacyRandom _random = new();

    public void Add(ItemPickupParticle particle) => _particlesToAdd.Enqueue(particle);

    /// <summary><c>ParticleEngine.setLevel</c>.</summary>
    public void Clear() {
        _particles.Clear();
        _particlesToAdd.Clear();
    }

    /// <summary><c>ParticleEngine.tick</c> for this group.</summary>
    public void Tick() {
        for (int i = 0; i < _particles.Count; i++) {
            _particles[i].Tick();
        }
        _particles.RemoveAll(particle => particle.Removed);
        while (_particlesToAdd.TryDequeue(out ItemPickupParticle? particle)) {
            AddToGroup(particle);
        }
    }

    /// <summary><c>ParticleGroup.add</c>: past the reservoir's start a new particle is refused ever more often.</summary>
    private void AddToGroup(ItemPickupParticle particle) {
        int currentSize = _particles.Count;
        if (currentSize >= MaxParticles) {
            return;
        }
        if (currentSize >= ReservoirStart) {
            float freeSpace = (MaxParticles - currentSize) / (float)ReservoirSize;
            if (_random.NextFloat() >= freeSpace * freeSpace) {
                return;
            }
        }
        _particles.Add(particle);
    }

    /// <summary><c>ParticleInstance.fromParticle</c> and <c>State.submit</c>.</summary>
    public void Render(EntityRenderContext context) {
        float partialTick = context.PartialTick;
        ClientLib.Maths.Vec3d camera = context.Camera.Position;
        foreach (ItemPickupParticle particle in _particles) {
            float time = (particle.Life + partialTick) / ItemPickupParticle.LifeTime;
            time *= time;
            double xt = Mth.Lerp((double)partialTick, particle.TargetXOld, particle.TargetX);
            double yt = Mth.Lerp((double)partialTick, particle.TargetYOld, particle.TargetY);
            double zt = Mth.Lerp((double)partialTick, particle.TargetZOld, particle.TargetZ);
            EntityRenderState state = particle.ItemRenderState;
            double xx = Mth.Lerp((double)time, state.X, xt);
            double yy = Mth.Lerp((double)time, state.Y, yt);
            double zz = Mth.Lerp((double)time, state.Z, zt);
            particle.Renderer.Submit(state, xx - camera.X, yy - camera.Y, zz - camera.Z, context);
        }
    }
}
