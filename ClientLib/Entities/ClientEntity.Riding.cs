using ClientLib.Maths;
using Minecraft.Schemas.Vec;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Entities;

/// <summary>
/// <c>Entity</c>'s vehicle and passenger bookkeeping as the client runs it: <c>startRiding</c> is
/// always forced, and a passenger is placed on its vehicle by <c>positionRider</c> after its own tick.
/// </summary>
public partial class ClientEntity {
    private readonly List<ClientEntity> _passengers = [];

    public ClientEntity? Vehicle { get; private set; }

    public int? VehicleId => Vehicle?.Id;

    /// <summary><c>Entity.passengers</c>, in the order they were added.</summary>
    public IReadOnlyList<ClientEntity> PassengerList => _passengers;

    /// <summary>The passengers' ids, for renderers that only ask whether there are any.</summary>
    public int[] Passengers { get; private set; } = [];

    public bool IsPassenger => Vehicle != null;
    public bool IsVehicle => _passengers.Count > 0;
    public ClientEntity? FirstPassenger => _passengers.Count > 0 ? _passengers[0] : null;

    /// <summary><c>Entity.isRemoved</c>: the server removed it, or the level it was in went.</summary>
    public bool IsRemoved { get; private set; }

    /// <summary><c>Entity.getControllingPassenger</c>: the passenger whose input steers this entity.</summary>
    public virtual ClientEntity? ControllingPassenger => null;

    /// <summary><c>Entity.isLocalClientAuthoritative</c>: whether this client runs the entity's movement.</summary>
    public virtual bool IsLocalClientAuthoritative => ControllingPassenger?.IsLocalClientAuthoritative ?? false;

    /// <summary><c>Entity.isLocalInstanceAuthoritative</c> on a client.</summary>
    public bool IsLocalInstanceAuthoritative => IsLocalClientAuthoritative;

    /// <summary><c>Entity.canSimulateMovement</c> on a client: what it steers, and what both sides simulate.</summary>
    public virtual bool CanSimulateMovement => IsLocalInstanceAuthoritative;

    /// <summary><c>Entity.getControlledVehicle</c>.</summary>
    public ClientEntity? ControlledVehicle => Vehicle != null && Vehicle.ControllingPassenger == this ? Vehicle : null;

    public ClientEntity RootVehicle {
        get {
            ClientEntity result = this;
            while (result.Vehicle != null) {
                result = result.Vehicle;
            }
            return result;
        }
    }

    public bool HasPassenger(ClientEntity entity) => _passengers.Contains(entity);

    protected int PassengerIndex(ClientEntity passenger) => _passengers.IndexOf(passenger);

    /// <summary><c>Entity.hasIndirectPassenger</c>.</summary>
    public bool HasIndirectPassenger(ClientEntity entity) {
        for (ClientEntity? ridden = entity.Vehicle; ridden != null; ridden = ridden.Vehicle) {
            if (ridden == this) {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// <c>Entity.startRiding(entity, true, false)</c>, the only way a client mounts anything: the server
    /// has already decided, so only a cycle stops it.
    /// </summary>
    public virtual bool StartRiding(ClientEntity vehicle) {
        if (vehicle == Vehicle) {
            return false;
        }
        for (ClientEntity riding = vehicle; riding.Vehicle != null; riding = riding.Vehicle) {
            if (riding.Vehicle == this) {
                return false;
            }
        }
        if (IsPassenger) {
            StopRiding();
        }
        SetStandingPose();
        Vehicle = vehicle;
        vehicle.AddPassenger(this);
        return true;
    }

    /// <summary>The <c>setPose(Pose.STANDING)</c> in <c>startRiding</c>, for the classes that keep a pose of their own.</summary>
    protected virtual void SetStandingPose() {
    }

    /// <summary><c>Entity.removeVehicle</c>.</summary>
    public virtual void RemoveVehicle() {
        if (Vehicle is { } oldVehicle) {
            Vehicle = null;
            oldVehicle.RemovePassenger(this);
        }
    }

    /// <summary><c>Entity.stopRiding</c>; the dismount that <c>LivingEntity</c> adds runs on the server only.</summary>
    public void StopRiding() => RemoveVehicle();

    /// <summary><c>Entity.addPassenger</c>: on a client a new passenger always goes last.</summary>
    protected virtual void AddPassenger(ClientEntity passenger) {
        _passengers.Add(passenger);
        Passengers = [.._passengers.Select(p => p.Id)];
    }

    private void RemovePassenger(ClientEntity passenger) {
        _passengers.Remove(passenger);
        Passengers = [.._passengers.Select(p => p.Id)];
    }

    /// <summary><c>Entity.ejectPassengers</c>.</summary>
    public void EjectPassengers() {
        for (int i = _passengers.Count - 1; i >= 0; i--) {
            _passengers[i].StopRiding();
        }
    }

    /// <summary><c>Entity.setRemoved</c>: whatever rode it gets off.</summary>
    public void SetRemoved() {
        IsRemoved = true;
        foreach (ClientEntity passenger in _passengers.ToArray()) {
            passenger.StopRiding();
        }
    }

    /// <summary><c>Entity.rideTick</c>, which <c>ClientLevel.tickPassenger</c> runs in place of <c>tick</c>.</summary>
    public virtual void RideTick() {
        DeltaMovement = Vec3d.Zero;
        Tick();
        Vehicle?.PositionRider(this);
    }

    /// <summary><c>Entity.positionRider(passenger)</c>.</summary>
    public void PositionRider(ClientEntity passenger) {
        if (HasPassenger(passenger)) {
            PositionRiderAt(passenger);
        }
    }

    /// <summary><c>Entity.positionRider(passenger, Entity::setPos)</c>.</summary>
    protected virtual void PositionRiderAt(ClientEntity passenger) {
        Vec3d position = PassengerRidingPosition(passenger);
        Vec3d offset = passenger.VehicleAttachmentPoint(this);
        passenger.Position = new Vec3d(position.X - offset.X, position.Y - offset.Y, position.Z - offset.Z);
    }

    /// <summary><c>Entity.onPassengerTurned</c>: the passenger moved its view.</summary>
    public virtual void OnPassengerTurned(ClientEntity passenger) {
    }

    /// <summary><c>Entity.getVehicleAttachmentPoint</c>.</summary>
    public virtual Vec3d VehicleAttachmentPoint(ClientEntity vehicle) => AttachmentPoint(Type.Attachments.Vehicle, 0, YRot, 1.0F);

    /// <summary><c>Entity.getPassengerRidingPosition</c>, with <c>LivingEntity</c>'s scale.</summary>
    public virtual Vec3d PassengerRidingPosition(ClientEntity passenger) => Position + PassengerAttachmentPoint(passenger, AttachmentScale);

    /// <summary><c>LivingEntity.getScale() * getAgeScale()</c>, or 1 for anything else.</summary>
    protected float AttachmentScale => IsLiving ? (float)Attributes.Value(Minecraft.Data.Generated.Attribute.Scale) * (IsBaby ? 0.5F : 1.0F) : 1.0F;

    /// <summary><c>Entity.getDefaultPassengerAttachmentPoint</c>: the point at the passenger's index, clamped.</summary>
    protected virtual Vec3d PassengerAttachmentPoint(ClientEntity passenger, float scale) =>
        AttachmentPoint(Type.Attachments.Passenger, PassengerIndex(passenger), YRot, scale);

    /// <summary><c>EntityAttachments.getClamped</c>, on attachments scaled as <c>EntityDimensions.scale</c> scales them.</summary>
    protected static Vec3d AttachmentPoint(Vec3<double>[] points, int index, float yRot, float scale) {
        Vec3<double> point = points[Math.Clamp(index, 0, points.Length - 1)];
        return YRotate(new Vec3d(point.X * scale, point.Y * scale, point.Z * scale), -yRot * (MathF.PI / 180.0F));
    }

    /// <summary><c>Vec3.xRot</c>.</summary>
    public static Vec3d XRotate(Vec3d v, float radians) {
        float cos = Mth.Cos(radians);
        float sin = Mth.Sin(radians);
        return new Vec3d(v.X, v.Y * cos + v.Z * sin, v.Z * cos - v.Y * sin);
    }

    /// <summary><c>Vec3.yRot</c>.</summary>
    public static Vec3d YRotate(Vec3d v, float radians) {
        float cos = Mth.Cos(radians);
        float sin = Mth.Sin(radians);
        return new Vec3d(v.X * cos + v.Z * sin, v.Y, v.Z * cos - v.X * sin);
    }

    /// <summary><c>Entity.absSnapRotationTo</c>.</summary>
    public void AbsSnapRotationTo(float yRot, float xRot) {
        YRot = yRot % 360.0F;
        XRot = Math.Clamp(xRot, -90.0F, 90.0F) % 360.0F;
        YRotO = YRot;
        XRotO = XRot;
    }
}
