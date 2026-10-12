using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.Entities.Vehicles;

/// <summary>
/// <c>AbstractBoat</c>. Its rowing runs only on the client of whoever steers it: <c>controlBoat</c>
/// turns and pushes it from the keys <c>LocalPlayer.rideTick</c> handed it a tick earlier.
/// </summary>
public sealed class ClientBoat(MinecraftClient client) : ClientVehicle(client) {
    private static readonly Identifier CanTurnInBoats = "minecraft:can_turn_in_boats";

    private enum Status {
        InWater,
        UnderWater,
        UnderFlowingWater,
        OnLand,
        InAir
    }

    private float _outOfControlTicks;
    private float _deltaRotation;
    private bool _inputLeft, _inputRight, _inputUp, _inputDown;
    private double _waterLevel;
    private float _landFriction;
    private Status _status, _oldStatus;
    private double _lastYd;

    private bool IsRaft => Is(EntityClass.Raft) || Is(EntityClass.ChestRaft);
    private bool IsChestBoat => Is(EntityClass.AbstractChestBoat);

    /// <summary><c>AbstractBoat.getControllingPassenger</c>: whoever sits first, if alive.</summary>
    public override ClientEntity? ControllingPassenger => FirstPassenger is { IsLiving: true } passenger ? passenger : null;

    private int MaxPassengers => IsChestBoat ? 1 : 2;

    protected override double DefaultGravity => 0.04;

    protected override float AirDrag => 1.0F;

    /// <summary><c>AbstractBoat.setInput</c>.</summary>
    public void SetInput(bool left, bool right, bool up, bool down) {
        _inputLeft = left;
        _inputRight = right;
        _inputUp = up;
        _inputDown = down;
    }

    /// <summary><c>AbstractBoat.getPaddleState</c>.</summary>
    public bool PaddleState(int side) =>
        Get(side == 0 ? EntityDataFields.AbstractBoat.IdPaddleLeft : EntityDataFields.AbstractBoat.IdPaddleRight) && ControllingPassenger != null;

    /// <summary>
    /// <c>AbstractBoat.setPaddleState</c>, which writes the client's own copy of the synced data; the
    /// server sets its copy from <c>paddle_boat</c>.
    /// </summary>
    private void SetPaddleState(bool left, bool right) {
        Set(EntityDataFields.AbstractBoat.IdPaddleLeft, MetaFieldType.Boolean, left);
        Set(EntityDataFields.AbstractBoat.IdPaddleRight, MetaFieldType.Boolean, right);
    }

    /// <summary><c>AbstractBoat.tick</c> on the client of whoever steers it.</summary>
    protected override void ControlledTick() {
        _oldStatus = _status;
        _status = GetStatus();
        if (_status != Status.UnderWater && _status != Status.UnderFlowingWater) {
            _outOfControlTicks = 0.0F;
        }
        else {
            _outOfControlTicks++;
        }

        BaseTick();
        StepInterpolation();
        if (FirstPassenger is not { } first || !first.Is(EntityClass.Player)) {
            SetPaddleState(false, false);
        }
        FloatBoat();
        ControlBoat();
        Client.Send(new ServerBoundPaddleBoatPacket { LeftPaddleTurning = PaddleState(0), RightPaddleTurning = PaddleState(1) });
        Move(DeltaMovement);
        ApplyEffectsFromBlocks();
        ApplyEffectsFromBlocks();
    }

    private Status GetStatus() {
        Status? waterStatus = IsUnderwater();
        if (waterStatus is { } status) {
            _waterLevel = BoundingBox.MaxY;
            return status;
        }
        if (CheckInWater()) {
            return Status.InWater;
        }
        float friction = GetGroundFriction();
        if (friction > 0.0F) {
            _landFriction = friction;
            return Status.OnLand;
        }
        return Status.InAir;
    }

    private float WaterHeightAt(int x, int y, int z, out bool isWater, out bool isSource) {
        MovementBlocks.Entry state = BlockAt(x, y, z);
        isWater = state.Fluid == FluidKind.Water;
        isSource = isWater && state.FluidAmount == 8 && !state.FluidFalling;
        return isWater ? FluidInteraction.FluidHeight(Level, x, y, z, state) : 0.0F;
    }

    /// <summary><c>AbstractBoat.getWaterLevelAbove</c>.</summary>
    public float GetWaterLevelAbove() {
        Box box = BoundingBox;
        int minX = (int)Math.Floor(box.MinX);
        int maxX = (int)Math.Ceiling(box.MaxX);
        int minY = (int)Math.Floor(box.MaxY);
        int maxY = (int)Math.Ceiling(box.MaxY - _lastYd);
        int minZ = (int)Math.Floor(box.MinZ);
        int maxZ = (int)Math.Ceiling(box.MaxZ);
        for (int y = minY; y < maxY; y++) {
            float blockHeight = 0.0F;
            for (int x = minX; x < maxX && blockHeight < 1.0F; x++) {
                for (int z = minZ; z < maxZ; z++) {
                    float height = WaterHeightAt(x, y, z, out bool isWater, out _);
                    if (isWater) {
                        blockHeight = Math.Max(blockHeight, height);
                    }
                    if (blockHeight >= 1.0F) {
                        break;
                    }
                }
            }
            if (blockHeight < 1.0F) {
                return y + blockHeight;
            }
        }
        return maxY + 1;
    }

    /// <summary><c>AbstractBoat.getGroundFriction</c>: the average friction of the blocks under the hull, lily pads aside.</summary>
    public float GetGroundFriction() {
        Box bb = BoundingBox;
        Box box = new(bb.MinX, bb.MinY - 0.001, bb.MinZ, bb.MaxX, bb.MinY, bb.MaxZ);
        int x0 = (int)Math.Floor(box.MinX) - 1;
        int x1 = (int)Math.Ceiling(box.MaxX) + 1;
        int y0 = (int)Math.Floor(box.MinY) - 1;
        int y1 = (int)Math.Ceiling(box.MaxY) + 1;
        int z0 = (int)Math.Floor(box.MinZ) - 1;
        int z1 = (int)Math.Ceiling(box.MaxZ) + 1;
        float friction = 0.0F;
        int count = 0;
        for (int x = x0; x < x1; x++) {
            for (int z = z0; z < z1; z++) {
                int edges = (x != x0 && x != x1 - 1 ? 0 : 1) + (z != z0 && z != z1 - 1 ? 0 : 1);
                if (edges == 2) {
                    continue;
                }
                for (int y = y0; y < y1; y++) {
                    if (edges > 0 && (y == y0 || y == y1 - 1)) {
                        continue;
                    }
                    uint state = Level.GetState(x, y, z);
                    if (BlockClasses.Is(Level.Registry.Blocks.GetByStateId(state).Identifier, BlockClass.LilyPadBlock)) {
                        continue;
                    }
                    if (LevelCollisions.CollidesAt(Level, x, y, z, box)) {
                        friction += BlockPhysicsData.Get(Level.Registry, state).Friction;
                        count++;
                    }
                }
            }
        }
        return friction / count;
    }

    /// <summary><c>AbstractBoat.checkInWater</c>.</summary>
    private bool CheckInWater() {
        Box bb = BoundingBox;
        int minX = (int)Math.Floor(bb.MinX);
        int maxX = (int)Math.Ceiling(bb.MaxX);
        int minY = (int)Math.Floor(bb.MinY);
        int maxY = (int)Math.Ceiling(bb.MinY + 0.001);
        int minZ = (int)Math.Floor(bb.MinZ);
        int maxZ = (int)Math.Ceiling(bb.MaxZ);
        bool inWater = false;
        _waterLevel = -double.MaxValue;
        for (int x = minX; x < maxX; x++) {
            for (int y = minY; y < maxY; y++) {
                for (int z = minZ; z < maxZ; z++) {
                    float fluidHeight = WaterHeightAt(x, y, z, out bool isWater, out _);
                    if (isWater) {
                        float height = y + fluidHeight;
                        _waterLevel = Math.Max(height, _waterLevel);
                        inWater |= bb.MinY < height;
                    }
                }
            }
        }
        return inWater;
    }

    /// <summary><c>AbstractBoat.isUnderwater</c>.</summary>
    private Status? IsUnderwater() {
        Box box = BoundingBox;
        double maxY = box.MaxY + 0.001;
        int x0 = (int)Math.Floor(box.MinX);
        int x1 = (int)Math.Ceiling(box.MaxX);
        int y0 = (int)Math.Floor(box.MaxY);
        int y1 = (int)Math.Ceiling(maxY);
        int z0 = (int)Math.Floor(box.MinZ);
        int z1 = (int)Math.Ceiling(box.MaxZ);
        bool underWater = false;
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                for (int z = z0; z < z1; z++) {
                    float height = WaterHeightAt(x, y, z, out bool isWater, out bool isSource);
                    if (isWater && maxY < y + height) {
                        if (!isSource) {
                            return Status.UnderFlowingWater;
                        }
                        underWater = true;
                    }
                }
            }
        }
        return underWater ? Status.UnderWater : null;
    }

    /// <summary><c>AbstractBoat.floatBoat</c>.</summary>
    private void FloatBoat() {
        double vspeed = -Gravity;
        double buoyancy = 0.0;
        float invFriction = 0.05F;
        if (_oldStatus == Status.InAir && _status != Status.InAir && _status != Status.OnLand) {
            _waterLevel = Position.Y + Height;
            double targetY = GetWaterLevelAbove() - Height + 0.101;
            if (NoCollision(BoundingBox.Translate(0.0, targetY - Position.Y, 0.0))) {
                Position = new Vec3d(Position.X, targetY, Position.Z);
                DeltaMovement = DeltaMovement.Multiply(1.0, 0.0, 1.0);
                _lastYd = 0.0;
            }
            _status = Status.InWater;
            return;
        }

        if (_status == Status.InWater) {
            buoyancy = (_waterLevel - Position.Y) / Height;
            invFriction = 0.9F;
        }
        else if (_status == Status.UnderFlowingWater) {
            vspeed = -7.0E-4;
            invFriction = 0.9F;
        }
        else if (_status == Status.UnderWater) {
            buoyancy = 0.01F;
            invFriction = 0.45F;
        }
        else if (_status == Status.InAir) {
            invFriction = 0.9F;
        }
        else if (_status == Status.OnLand) {
            invFriction = _landFriction;
            if (ControllingPassenger is { } controller && controller.Is(EntityClass.Player)) {
                _landFriction /= 2.0F;
            }
        }

        Vec3d movement = DeltaMovement;
        DeltaMovement = new Vec3d(movement.X * invFriction, movement.Y + vspeed, movement.Z * invFriction);
        _deltaRotation *= invFriction;
        if (buoyancy > 0.0) {
            Vec3d deltaMovement = DeltaMovement;
            DeltaMovement = new Vec3d(deltaMovement.X, (deltaMovement.Y + buoyancy * (DefaultGravity / 0.65)) * 0.75, deltaMovement.Z);
        }
    }

    /// <summary><c>AbstractBoat.controlBoat</c>.</summary>
    private void ControlBoat() {
        if (!IsVehicle) {
            return;
        }
        float acceleration = 0.0F;
        if (_inputLeft) {
            _deltaRotation--;
        }
        if (_inputRight) {
            _deltaRotation++;
        }
        if (_inputRight != _inputLeft && !_inputUp && !_inputDown) {
            acceleration += 0.005F;
        }
        YRot += _deltaRotation;
        if (_inputUp) {
            acceleration += 0.04F;
        }
        if (_inputDown) {
            acceleration -= 0.005F;
        }
        DeltaMovement = DeltaMovement.Add(
            Mth.Sin(-YRot * (MathF.PI / 180.0F)) * acceleration, 0.0, Mth.Cos(YRot * (MathF.PI / 180.0F)) * acceleration);
        SetPaddleState(_inputRight && !_inputLeft || _inputUp, _inputLeft && !_inputRight || _inputUp);
    }

    /// <summary>
    /// <c>AbstractBoat.onAboveBubbleColumn</c>: on a client only the odd splash. The bubble time it starts is
    /// the server's, whose launch arrives as a motion packet.
    /// </summary>
    protected override void OnAboveBubbleColumn(bool dragDown) {
    }

    /// <summary><c>AbstractBoat.checkFallDamage</c>.</summary>
    protected override void CheckFallDamage(double ya, bool onGround) {
        _lastYd = DeltaMovement.Y;
        if (IsPassenger) {
            return;
        }
        if (onGround) {
            FallDistance = 0.0;
        }
        else if (BlockAt(BlockX, (int)Math.Floor(Position.Y) - 1, BlockZ).Fluid != FluidKind.Water && ya < 0.0) {
            FallDistance -= (float)ya;
        }
    }

    /// <summary><c>AbstractBoat.isUnderWater</c>, which only a steered boat keeps up to date.</summary>
    public bool IsUnderWater => _status is Status.UnderWater or Status.UnderFlowingWater;

    /// <summary>
    /// <c>AbstractBoat.modifyPassengerFluidInteractionBox</c>: a passenger only touches the water above
    /// the hull, and none at all when the hull is taller.
    /// </summary>
    public Box? ModifyPassengerFluidInteractionBox(Box passengerBox) {
        if (IsUnderWater) {
            return passengerBox;
        }
        Box boatBox = MakeBoundingBox(Position);
        if (boatBox.MaxY >= passengerBox.MaxY) {
            return null;
        }
        double minY = Math.Max(passengerBox.MinY, boatBox.MaxY);
        return new Box(passengerBox.MinX, minY, passengerBox.MinZ, passengerBox.MaxX, passengerBox.MaxY, passengerBox.MaxZ);
    }

    /// <summary><c>Boat.rideHeight</c> and <c>Raft.rideHeight</c>.</summary>
    private double RideHeight => IsRaft ? (float)Height * 0.8888889F : (float)Height / 3.0F;

    /// <summary><c>AbstractBoat.getPassengerAttachmentPoint</c>: two seats, front and back.</summary>
    protected override Vec3d PassengerAttachmentPoint(ClientEntity passenger, float scale) {
        float offset = IsChestBoat ? 0.15F : 0.0F;
        if (PassengerList.Count > 1) {
            int index = PassengerIndex(passenger);
            offset = index == 0 ? 0.2F : -0.6F;
            if (passenger.Is(EntityClass.Animal)) {
                offset += 0.2F;
            }
        }
        return YRotate(new Vec3d(0.0, RideHeight, offset), -YRot * (MathF.PI / 180.0F));
    }

    /// <summary><c>AbstractBoat.positionRider</c>: a passenger turns with the boat, within its clamp.</summary>
    protected override void PositionRiderAt(ClientEntity passenger) {
        base.PositionRiderAt(passenger);
        if (Client.InEntityTypeTag(passenger.Type, CanTurnInBoats)) {
            return;
        }
        passenger.YRot += _deltaRotation;
        passenger.YHeadRot += _deltaRotation;
        ClampRotation(passenger);
        if (passenger.Is(EntityClass.Animal) && PassengerList.Count == MaxPassengers) {
            int rotationOffset = passenger.Id % 2 == 0 ? 90 : 270;
            passenger.YBodyRot += rotationOffset;
            passenger.YHeadRot += rotationOffset;
        }
    }

    /// <summary><c>AbstractBoat.clampRotation</c>: a passenger looks at most 105 degrees off the bow.</summary>
    private void ClampRotation(ClientEntity passenger) {
        passenger.YBodyRot = YRot;
        float delta = Wrap(passenger.YRot - YRot);
        float targetDelta = Math.Clamp(delta, -105.0F, 105.0F);
        passenger.YRotO += targetDelta - delta;
        passenger.YRot += targetDelta - delta;
        passenger.YHeadRot = passenger.YRot;
    }

    public override void OnPassengerTurned(ClientEntity passenger) => ClampRotation(passenger);
}
