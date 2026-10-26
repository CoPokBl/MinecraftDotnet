namespace ClientLib.Entities;

public partial class ClientEntity {
    /// <summary>What <see cref="Particles.EntityParticles"/> keeps for this entity between ticks; null until it first looks.</summary>
    internal Particles.EntityEmitter? Emitter { get; set; }
}
