using ClientLib.Entities;
using ClientLib.Entities.Vehicles;
using ClientLib.Maths;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Player;

/// <summary>The local player as a passenger: <c>LocalPlayer.rideTick</c>, the riding jump and what it sends.</summary>
public sealed partial class LocalPlayer {
    /// <summary><c>LivingEntity.xxa</c>: this tick's sideways input after <c>applyInput</c>, which a mount reads.</summary>
    public float Xxa => _xxa;

    /// <summary><c>LivingEntity.zza</c>: this tick's forward input after <c>applyInput</c>.</summary>
    public float Zza => _zza;

    /// <summary><c>LocalPlayer.handsBusy</c>: rowing a boat, which keeps the hands off attacking and using.</summary>
    public bool HandsBusy { get; private set; }

    private int _jumpRidingTicks;

    /// <summary><c>LocalPlayer.jumpRidingScale</c>: how far the jump bar has charged, 0 to 1.</summary>
    public float JumpRidingScale { get; private set; }

    /// <summary><c>LocalPlayer.startRiding</c>, after the mount took: where the riding sound loops start.</summary>
    public event Action<ClientEntity>? StartedRiding;

    public override bool IsLocalClientAuthoritative => true;

    protected override void SetStandingPose() => Pose = EntityPose.Standing;

    public override bool StartRiding(ClientEntity vehicle) {
        if (!base.StartRiding(vehicle)) {
            return false;
        }
        StartedRiding?.Invoke(vehicle);
        return true;
    }

    /// <summary><c>LocalPlayer.removeVehicle</c>.</summary>
    public override void RemoveVehicle() {
        base.RemoveVehicle();
        HandsBusy = false;
    }

    /// <summary><c>LocalPlayer.jumpableVehicle</c>.</summary>
    public IPlayerRideableJumping? JumpableVehicle => ControlledVehicle is IPlayerRideableJumping jumping && jumping.CanJump ? jumping : null;

    /// <summary><c>LocalPlayer.vehicleCanSprint</c>: only a camel, and only one this client steers.</summary>
    private static bool VehicleCanSprint(ClientEntity vehicle) => vehicle is ClientCamel && vehicle.IsLocalInstanceAuthoritative;

    /// <summary>
    /// <c>LocalPlayer.rideTick</c>, through <c>Player</c>, <c>LivingEntity</c> and <c>Entity.rideTick</c>
    /// and <c>AbstractClientPlayer</c>'s dropped bob. The boat gets this tick's keys only after it has
    /// moved, so it steers by the previous tick's.
    /// </summary>
    public override void RideTick() {
        DeltaMovement = Vec3d.Zero;
        ClientTick();
        Vehicle?.PositionRider(this);
        FallDistance = 0.0;
        BobO = Bob;
        Bob = 0.0F;
        HandsBusy = false;
        if (ControlledVehicle is ClientBoat boat) {
            boat.SetInput(KeyPresses.Left, KeyPresses.Right, KeyPresses.Forward, KeyPresses.Backward);
            HandsBusy |= KeyPresses.Left || KeyPresses.Right || KeyPresses.Forward || KeyPresses.Backward;
        }
    }

    /// <summary>
    /// <c>LocalPlayer.tick</c>'s passenger branch: only the look goes out for the player, and the vehicle
    /// it steers reports its own position.
    /// </summary>
    private void SendRidingPosition() {
        _client.Send(new ServerBoundSetPlayerRotationPacket { Yaw = YRot, Pitch = XRot, Flags = MovementFlags });
        ClientEntity vehicle = RootVehicle;
        if (vehicle != this && vehicle.IsLocalInstanceAuthoritative) {
            _client.SendMoveVehicle(vehicle);
            SendIsSprintingIfNeeded();
        }
    }

    /// <summary><c>LocalPlayer.aiStep</c>'s charge of the riding jump, released by letting go of jump.</summary>
    private void TickRidingJump(bool wasJumping) {
        IPlayerRideableJumping? jumpableVehicle = JumpableVehicle;
        if (jumpableVehicle == null || jumpableVehicle.JumpCooldown != 0) {
            JumpRidingScale = 0.0F;
            return;
        }
        if (_jumpRidingTicks < 0) {
            _jumpRidingTicks++;
            if (_jumpRidingTicks == 0) {
                JumpRidingScale = 0.0F;
            }
        }
        if (wasJumping && !KeyPresses.Jump) {
            _jumpRidingTicks = -10;
            jumpableVehicle.OnPlayerJump((int)Math.Floor(JumpRidingScale * 100.0F));
            SendRidingJump();
        }
        else if (!wasJumping && KeyPresses.Jump) {
            _jumpRidingTicks = 0;
            JumpRidingScale = 0.0F;
        }
        else if (wasJumping) {
            _jumpRidingTicks++;
            JumpRidingScale = _jumpRidingTicks < 10 ? _jumpRidingTicks * 0.1F : 0.8F + 2.0F / (_jumpRidingTicks - 9) * 0.1F;
        }
    }

    /// <summary><c>LocalPlayer.sendRidingJump</c>.</summary>
    private void SendRidingJump() {
        _client.Send(new ServerBoundPlayerCommandPacket {
            EntityId = Id,
            PlayAction = PlayerAction.StartHorseJump,
            JumpBoost = (int)Math.Floor(JumpRidingScale * 100.0F)
        });
    }

    /// <summary>
    /// <c>MultiPlayerGameMode.isServerControlledInventory</c>: riding something with an inventory of its
    /// own, whose screen the server opens.
    /// </summary>
    public bool IsServerControlledInventory =>
        Vehicle is ClientHorse or ClientNautilus || Vehicle is ClientBoat && Vehicle.Is(Minecraft.Data.Generated.EntityClass.AbstractChestBoat);

    /// <summary><c>LocalPlayer.sendOpenInventory</c>: the inventory key while riding opens the mount's.</summary>
    public void SendOpenInventory() {
        _client.Send(new ServerBoundPlayerCommandPacket { EntityId = Id, PlayAction = PlayerAction.OpenVehicleInventory, JumpBoost = 0 });
    }
}
