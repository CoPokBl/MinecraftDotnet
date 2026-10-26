using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Interaction;

/// <summary>
/// The player's hands: <c>MultiPlayerGameMode</c> for digging, using and attacking, and the parts of
/// <c>Minecraft</c> that turn the keys into those calls each tick.
/// </summary>
public sealed partial class MultiPlayerGameMode {
    private readonly MinecraftClient _client;
    private readonly BlockTags _tags;

    /// <summary>The block transformers the server synchronised, as a tool's use is judged by.</summary>
    public BlockTransforms Transforms { get; }

    private int _carriedIndex;
    private bool _isDestroying;
    private (int X, int Y, int Z) _destroyPos = (-1, -1, -1);
    private ItemStack _destroyingItem = ItemStack.Air;
    private float _destroyProgress;
    private float _destroyTicks;
    private int _destroyDelay;
    private BlockFace? _destroyDirection;
    private int _rightClickDelay;
    private int _missTime;

    public BlockPredictions Predictions => Level.Predictions;

    public KeyMappings Keys { get; } = new();

    /// <summary>Whether a screen is open, which stops <c>handleKeybinds</c> and holds attacks back; set by the host.</summary>
    public Func<bool> ScreenOpen { get; set; } = static () => false;

    /// <summary>Whether an overlay such as a resource reload's covers the game, which also stops <c>handleKeybinds</c>; set by the host.</summary>
    public Func<bool> OverlayOpen { get; set; } = static () => false;

    /// <summary>What the crosshair is on, refreshed every tick and every frame.</summary>
    public HitResult? Target { get; private set; }

    /// <summary>The block being dug and how far along, for drawing cracks.</summary>
    public (int X, int Y, int Z)? DestroyingBlock => _isDestroying ? _destroyPos : null;

    /// <summary><c>getDestroyStage</c>: 0 to 9, or -1 when nothing is being dug.</summary>
    public int DestroyStage => _destroyProgress > 0.0F ? (int)(_destroyProgress * 10.0F) : -1;

    /// <summary>The hand in use while an item is held to be used (eating, drawing a bow), else null.</summary>
    public Hand? UsingItem => _client.Player is { IsUsingItem: true } player ? player.UsedItemHand : null;

    /// <summary>The player's <see cref="LocalPlayer.UseItemRemainingTicks"/> and <see cref="LocalPlayer.UseDuration"/>.</summary>
    public int UseItemRemainingTicks => _client.Player?.UseItemRemainingTicks ?? 0;
    public int UseDuration => _client.Player?.UseDuration ?? 0;

    /// <summary>The player's <see cref="LocalPlayer.UseItem"/>.</summary>
    public ItemStack UsedStack => _client.Player?.UseItem ?? ItemStack.Air;

    /// <summary>
    /// The hit sound <c>addBreakingBlockEffects</c> plays as digging the block at the position starts; the
    /// server's level event 2020 brings the rest while it goes on.
    /// </summary>
    public event Action<(int X, int Y, int Z), IBlock>? DestroyHit;

    /// <summary><c>Item.use</c> starting to hold an item in use.</summary>
    public event Action<Hand, ItemStack>? StartedUsingItem;

    /// <summary><c>LocalPlayer.releaseUsingItem</c>: the use button let go of an item in use.</summary>
    public event Action<Hand, ItemStack>? ReleasedUsingItem;

    /// <summary>
    /// <c>WritableBookItem.use</c> and <c>WrittenBookItem.use</c> calling <c>LocalPlayer.openItemGui</c>, which
    /// opens the edit screen for a book with writable content. A written book is shown when the server answers.
    /// </summary>
    public event Action<Hand, ItemStack>? ItemGuiOpened;

    /// <summary>
    /// A held item's <c>useItemOn</c> the server has acknowledged, with what the clicked block and the
    /// block against the clicked face became. Only a block item's <c>useOn</c> is predicted, so what
    /// the tools do client side is read from the server's answer instead: its block updates for both
    /// positions arrive before the acknowledgement.
    /// </summary>
    public event Action<UseOnOutcome>? UsedItemOn;

    /// <summary>A <c>GameMasterBlock</c>'s <c>useWithoutItem</c> calling the <c>LocalPlayer.open...Block</c> for its block entity.</summary>
    public event Action<ClientBlockEntity>? GameMasterBlockOpened;

    /// <summary><c>MinecartCommandBlock.interact</c> calling <c>LocalPlayer.openMinecartCommandBlock</c>.</summary>
    public event Action<ClientMinecartCommandBlock>? MinecartCommandBlockOpened;

    private readonly List<(int Sequence, PendingUseOn Use)> _pendingUseOn = [];

    private readonly record struct PendingUseOn(Hand Hand, ItemStack Item, (int X, int Y, int Z) Clicked, BlockFace Face, ushort ClickedBefore, (int X, int Y, int Z) Against, ushort AgainstBefore);

    public MultiPlayerGameMode(MinecraftClient client) {
        _client = client;
        _tags = new BlockTags(client);
        Transforms = new BlockTransforms(client, _tags);
        // A new level counts its sequence from zero again, so an old use would match a new acknowledgement.
        client.LevelChanged += _ => _pendingUseOn.Clear();
    }

    private LocalPlayer Player => _client.Player!;
    private ClientLevel Level => _client.Level!;

    /// <summary><c>Minecraft.pick</c>, from wherever the frame is.</summary>
    public void Pick(float partialTick) {
        if (_client.Player == null || _client.Level == null) {
            Target = null;
            return;
        }
        Target = Picking.Pick(Player, _client.CameraEntity ?? Player, Level, _client.Entities.Values, _client.PlayerList, partialTick);
    }

    /// <summary><c>MouseHandler.grabMouse</c>'s <c>missTime = 10000</c>, so the click that takes the mouse attacks nothing.</summary>
    public void OnMouseGrabbed() => _missTime = 10000;

    /// <summary>
    /// The interaction half of <c>Minecraft.tick</c>, in its order: delays, game mode tick, pick, then
    /// <c>handleKeybinds</c> unless a screen is open. <paramref name="hostKeybinds"/> is the host's own
    /// part of <c>handleKeybinds</c>, the camera, chat and inventory screen keys, which come first and
    /// may open a screen.
    /// </summary>
    public void Tick(Action? hostKeybinds = null) {
        if (_client.Player == null || _client.Level == null) {
            return;
        }
        if (_rightClickDelay > 0) {
            _rightClickDelay--;
        }
        EnsureHasSentCarriedItem();
        // MultiPlayerGameMode.tick ticks the connection, whose listener sends a new chat session.
        _client.TickChatSession();
        Pick(1.0F);
        if (ScreenOpen()) {
            _missTime = 10000;
            return;
        }
        if (OverlayOpen()) {
            return;
        }
        hostKeybinds?.Invoke();
        HandleKeybinds();
        if (_missTime > 0) {
            _missTime--;
        }
    }

    /// <summary><c>Minecraft.handleKeybinds</c> from the hotbar keys on. The saved toolbar activators are not bound here.</summary>
    private void HandleKeybinds() {
        for (int i = 0; i < Keys.Hotbar.Length; i++) {
            if (Keys.Hotbar[i].ConsumeClick()) {
                if (Player.IsSpectator) {
                    _client.SpectatorGui.OnHotbarSelected(i);
                }
                else {
                    _client.Inventory.SelectedSlot = i;
                }
            }
        }
        while (Keys.SwapOffhand.ConsumeClick()) {
            if (!Player.IsSpectator) {
                _client.Send(Action(ServerBoundPlayerActionPacket.Status.SwapItem));
            }
        }
        while (Keys.Drop.ConsumeClick()) {
            if (!Player.IsSpectator) {
                DropItem(Keys.ControlDown);
            }
        }

        bool instantAttack = false;
        if (Player.IsUsingItem) {
            if (!Keys.Use.IsDown) {
                ReleaseUsingItem();
            }
            while (Keys.Attack.ConsumeClick()) {
            }
            while (Keys.Use.ConsumeClick()) {
            }
            while (Keys.PickItem.ConsumeClick()) {
            }
        }
        else {
            while (Keys.Attack.ConsumeClick()) {
                instantAttack |= StartAttack();
            }
            while (Keys.Use.ConsumeClick()) {
                StartUseItem();
            }
            while (Keys.PickItem.ConsumeClick()) {
                PickBlock(Keys.ControlDown);
            }
            if (Player.IsSpectator) {
                while (Keys.SpectatorHotbar.ConsumeClick()) {
                    _client.SpectatorGui.OnHotbarActionKeyPressed();
                }
            }
        }
        if (Keys.Use.IsDown && _rightClickDelay == 0 && !Player.IsUsingItem) {
            StartUseItem();
        }
        ContinueAttack(!ScreenOpen() && !instantAttack && Keys.Attack.IsDown);
    }

    private void EnsureHasSentCarriedItem() {
        int index = _client.Inventory.SelectedSlot;
        if (index != _carriedIndex) {
            _carriedIndex = index;
            _client.Send(new ServerBoundSetHeldItemPacket { Slot = (short)index });
        }
    }

    private bool HasMissTime => !Player.IsCreative;

    private bool StartAttack() {
        if (_missTime > 0) {
            return false;
        }
        if (Target == null) {
            if (HasMissTime) {
                _missTime = 10;
            }
            return false;
        }
        if (Player.HandsBusy) {
            return false;
        }
        if (Player.IsSpectator) {
            _client.Send(new ServerBoundSpectatorActionPacket { SpectateEntityId = Target is EntityHitResult spectated ? spectated.Entity.Id : null });
            return true;
        }

        ItemStack held = _client.Inventory.MainHand;
        if (CannotAttackWithItem(held)) {
            return false;
        }
        SwingAnimation attackAnimation = AttackAnimationOf(held);
        if (ItemComponents.Has(held, DataComponent.PiercingWeapon)) {
            PiercingAttack(attackAnimation);
            return true;
        }

        bool endAttack = false;
        switch (Target) {
            case EntityHitResult entityHit:
                if (ItemComponents.Get(held, DataComponent.AttackRange) is not { } range || InAttackRange(range, entityHit.Location)) {
                    Attack(entityHit.Entity);
                }
                break;
            case BlockHitResult blockHit when !Level.IsAir(Level.GetState(blockHit.X, blockHit.Y, blockHit.Z)):
                StartDestroyBlock(blockHit.X, blockHit.Y, blockHit.Z, blockHit.Face);
                endAttack = Level.IsAir(Level.GetState(blockHit.X, blockHit.Y, blockHit.Z));
                break;
            default:
                if (HasMissTime) {
                    _missTime = 10;
                }
                Player.ResetAttackStrengthTicker();
                break;
        }
        Punch(attackAnimation);
        return endAttack;
    }

    /// <summary><c>Player.cannotAttackWithItem</c> with no tolerance: a weapon that needs a charge before it swings.</summary>
    private bool CannotAttackWithItem(ItemStack held) {
        float requiredStrength = ItemComponents.Get(held, DataComponent.MinimumAttackCharge);
        float optimisticStrength = Player.AttackStrengthTicker / Player.CurrentItemAttackStrengthDelay;
        return requiredStrength > 0.0F && optimisticStrength < requiredStrength;
    }

    /// <summary><c>AttackRange.isInRange</c> from the eyes to where the crosshair met the entity.</summary>
    private bool InAttackRange(AttackRangeComponent.Data range, Vec3d location) {
        double distance = Math.Sqrt(location.DistanceToSqr(Picking.EyePosition(Player)));
        double minReach = (Player.IsCreative ? range.MinCreativeReach : range.MinReach) - range.HitboxMargin;
        double maxReach = (Player.IsCreative ? range.MaxCreativeReach : range.MaxReach) + range.HitboxMargin;
        return distance >= minReach && distance <= maxReach;
    }

    /// <summary><c>MultiPlayerGameMode.attack</c>: the packet goes before the client's half of the attack runs.</summary>
    private void Attack(ClientEntity entity) {
        EnsureHasSentCarriedItem();
        _client.Send(new ServerBoundAttackPacket { EntityId = entity.Id });
        Player.Attack(entity);
        Player.ResetAttackStrengthTicker();
        if (Player.InstaBuild) {
            _destroyDelay = 5;
        }
    }

    /// <summary><c>MultiPlayerGameMode.piercingAttack</c>: the stab is the server's, and its sound is not played here.</summary>
    private void PiercingAttack(SwingAnimation attackAnimation) {
        EnsureHasSentCarriedItem();
        _client.Send(Action(ServerBoundPlayerActionPacket.Status.Stab));
        Player.OnAttack();
        Player.Swing(Hand.MainHand, attackAnimation);
    }

    private void ContinueAttack(bool down) {
        if (!down) {
            _missTime = 0;
        }
        if (_missTime > 0 || UsingItem != null || ItemComponents.Has(_client.Inventory.MainHand, DataComponent.PiercingWeapon)) {
            return;
        }
        if (down && Target is BlockHitResult blockHit && !Level.IsAir(Level.GetState(blockHit.X, blockHit.Y, blockHit.Z))) {
            if (ContinueDestroyBlock(blockHit.X, blockHit.Y, blockHit.Z, blockHit.Face)) {
                Punch(AttackAnimationOf(_client.Inventory.MainHand));
            }
        }
        else {
            StopDestroyBlock();
        }
    }

    /// <summary>
    /// An attack's swing, which is the one swing the server is told about: everything else is swung on
    /// the server by the use it answers.
    /// </summary>
    private void Punch(SwingAnimation attackAnimation) {
        Player.Swing(Hand.MainHand, attackAnimation);
        _client.Send(new ServerBoundPunchPacket());
    }

    private static SwingAnimation AttackAnimationOf(ItemStack stack) => ItemComponents.Get(stack, DataComponent.AttackAnimation) ?? SwingAnimation.Default;

    private void StartPrediction(Func<int, ServerBoundPacket> action) {
        int sequence = Predictions.Begin();
        try {
            _client.Send(action(sequence));
        }
        finally {
            Predictions.End();
        }
    }

    private static ServerBoundPlayerActionPacket Action(ServerBoundPlayerActionPacket.Status status, (int X, int Y, int Z) pos = default,
        BlockFace face = BlockFace.NegY, int sequence = 0) => new() {
        ActionStatus = status,
        Location = new Vec3<int>(pos.X, pos.Y, pos.Z),
        Face = face,
        Sequence = sequence
    };

    private bool SameDestroyTarget(int x, int y, int z) {
        ItemStack held = _client.Inventory.MainHand;
        return _destroyPos == (x, y, z) && held.Type.Identifier.Equals(_destroyingItem.Type.Identifier)
            && held.Components.Count == _destroyingItem.Components.Count;
    }

    /// <summary>The creative branch of <c>startDestroyBlock</c> and <c>continueDestroyBlock</c>.</summary>
    private void DestroyInstantly(int x, int y, int z, BlockFace face) {
        StartPrediction(sequence => {
            DestroyBlock(x, y, z);
            return Action(ServerBoundPlayerActionPacket.Status.StartedDigging, (x, y, z), face, sequence);
        });
        _destroyDelay = 5;
    }

    internal bool StartDestroyBlock(int x, int y, int z, BlockFace face) {
        if (!Level.WorldBorder.IsWithinBounds(x, z)) {
            return false;
        }
        if (Player.InstaBuild) {
            DestroyInstantly(x, y, z, face);
            return true;
        }
        if (_isDestroying && SameDestroyTarget(x, y, z)) {
            return true;
        }
        if (_isDestroying) {
            _client.Send(Action(ServerBoundPlayerActionPacket.Status.CancelledDigging, _destroyPos, face));
        }

        ushort state = Level.GetState(x, y, z);
        StartPrediction(sequence => {
            bool notAir = !Level.IsAir(state);
            if (notAir && DestroyProgress(state) >= 1.0F) {
                DestroyBlock(x, y, z);
            }
            else {
                _isDestroying = true;
                _destroyPos = (x, y, z);
                _destroyDirection = face;
                _destroyingItem = _client.Inventory.MainHand;
                _destroyProgress = 0.0F;
                _destroyTicks = 0.0F;
                AddBreakingBlockEffects(x, y, z, face);
            }
            return Action(ServerBoundPlayerActionPacket.Status.StartedDigging, (x, y, z), face, sequence);
        });
        return true;
    }

    internal void StopDestroyBlock() {
        if (!_isDestroying) {
            return;
        }
        _client.Send(Action(ServerBoundPlayerActionPacket.Status.CancelledDigging, _destroyPos));
        _isDestroying = false;
        _destroyProgress = 0.0F;
        Player.ResetAttackStrengthTicker();
    }

    private bool ContinueDestroyBlock(int x, int y, int z, BlockFace face) {
        EnsureHasSentCarriedItem();
        if (_destroyDelay > 0) {
            _destroyDelay--;
            return true;
        }
        if (Player.InstaBuild && Level.WorldBorder.IsWithinBounds(x, z)) {
            DestroyInstantly(x, y, z, face);
            return true;
        }
        if (!SameDestroyTarget(x, y, z)) {
            return StartDestroyBlock(x, y, z, face);
        }

        ushort state = Level.GetState(x, y, z);
        if (Level.IsAir(state)) {
            _isDestroying = false;
            return false;
        }
        _destroyProgress += DestroyProgress(state);
        _destroyTicks++;
        if (_destroyProgress >= 1.0F) {
            _isDestroying = false;
            StartPrediction(sequence => {
                DestroyBlock(x, y, z);
                return Action(ServerBoundPlayerActionPacket.Status.FinishedDigging, (x, y, z), face, sequence);
            });
            _destroyDirection = null;
            _destroyProgress = 0.0F;
            _destroyTicks = 0.0F;
            _destroyDelay = 5;
        }
        else if (_destroyDirection != face) {
            _destroyDirection = face;
            _client.Send(Action(ServerBoundPlayerActionPacket.Status.ChangeDestroyDirection, (x, y, z), face));
        }
        return true;
    }

    /// <summary>
    /// <c>ClientLevel.addBreakingBlockEffects</c> with its sound: the hit sound and one crack particle off
    /// the face, for a block that is not air.
    /// </summary>
    private void AddBreakingBlockEffects(int x, int y, int z, BlockFace face) {
        ushort state = Level.GetState(x, y, z);
        if (Level.IsAir(state)) {
            return;
        }
        DestroyHit?.Invoke((x, y, z), Level.Registry.Blocks.GetByStateId(state));
        _client.Particles.Crack(x, y, z, face);
    }

    /// <summary>
    /// <c>MultiPlayerGameMode.destroyBlock</c>: the block becomes whatever fluid it held, ahead of the
    /// server. Game master blocks stay for anyone not allowed to break them.
    /// </summary>
    private void DestroyBlock(int x, int y, int z) {
        ushort old = Level.GetState(x, y, z);
        if (Level.IsAir(old)) {
            return;
        }
        IBlock block = Level.Registry.Blocks.GetByStateId(old);
        if (IsGameMasterBlock(block) && !_client.CanUseGameMasterBlocks) {
            return;
        }
        // Block.playerWillDestroy's spawnDestroyParticles, which BaseFireBlock overrides to nothing.
        // Divergence: DecoratedPotBlock first cracks a pot hit with an item that breaks pots, so vanilla's
        // event carries the cracked state and its sound; the item tag check is not ported.
        if (!BlockClasses.Is(block.Identifier, BlockClass.BaseFireBlock)) {
            Level.RaiseLevelEvent(2001, x, y, z, old);
        }
        ushort replacement = block.Fluid?.Key is "water" or "flowing_water" ? (ushort)Block.Water.StateId : (ushort)0;
        SetPredicted(x, y, z, replacement);
    }

    /// <summary>The <c>GameMasterBlock</c> implementors.</summary>
    private static readonly BlockClass[] GameMasterBlocks =
        [BlockClass.CommandBlock, BlockClass.StructureBlock, BlockClass.JigsawBlock, BlockClass.TestBlock, BlockClass.TestInstanceBlock];

    private static bool IsGameMasterBlock(IBlock block) => GameMasterBlocks.Any(type => BlockClasses.Is(block.Identifier, type));

    /// <summary><c>ClientLevel.setBlock</c> during a prediction.</summary>
    public void SetPredicted(int x, int y, int z, ushort state) {
        if (Predictions.Predicting) {
            Predictions.RetainServerState(x, y, z, Level.GetState(x, y, z), Player.Position);
        }
        Level.SetState(x, y, z, state);
    }

    /// <summary><c>BlockBehaviour.getDestroyProgress</c> for the local player.</summary>
    public float DestroyProgress(ushort stateId) {
        IBlock state = Level.Registry.Blocks.GetByStateId(stateId);
        float hardness = state.Hardness;
        if (hardness == -1.0F) {
            return 0.0F;
        }
        int modifier = HasCorrectToolForDrops(state) ? 30 : 100;
        return DestroySpeed(state) / hardness / modifier;
    }

    private bool HasCorrectToolForDrops(IBlock state) {
        if (!state.RequiresTool) {
            return true;
        }
        Tool? tool = ItemComponents.Get(_client.Inventory.MainHand, DataComponent.Tool);
        if (tool == null) {
            return false;
        }
        foreach (ToolRule rule in tool.Rules) {
            if (rule.CorrectDropForBlocks is { } correct && _tags.Contains(rule.Blocks, state)) {
                return correct;
            }
        }
        return false;
    }

    /// <summary><c>Player.getDestroySpeed</c>.</summary>
    private float DestroySpeed(IBlock state) {
        float speed = 1.0F;
        Tool? tool = ItemComponents.Get(_client.Inventory.MainHand, DataComponent.Tool);
        if (tool != null) {
            speed = tool.DefaultMiningSpeed;
            foreach (ToolRule rule in tool.Rules) {
                if (rule.Speed is { } ruleSpeed && _tags.Contains(rule.Blocks, state)) {
                    speed = ruleSpeed;
                    break;
                }
            }
        }

        if (speed > 1.0F) {
            speed += (float)Player.Attributes.Value(Attribute.MiningEfficiency);
        }

        MobEffectInstance? haste = Player.GetEffect(PotionEffectType.Haste);
        MobEffectInstance? conduit = Player.GetEffect(PotionEffectType.ConduitPower);
        if (haste != null || conduit != null) {
            int amplification = Math.Max(haste?.Amplifier ?? 0, conduit?.Amplifier ?? 0);
            speed *= 1.0F + (amplification + 1) * 0.2F;
        }

        if (Player.GetEffect(PotionEffectType.MiningFatigue) is { } fatigue) {
            speed *= (float)Math.Pow(0.3, fatigue.Amplifier + 1);
        }

        speed *= (float)Player.Attributes.Value(Attribute.BlockBreakSpeed);
        if (Player.IsUnderWater) {
            speed *= (float)Player.Attributes.Value(Attribute.SubmergedMiningSpeed);
        }
        if (!Player.OnGround) {
            speed /= 5.0F;
        }
        return speed;
    }

    /// <summary>Handles <c>block_changed_ack</c>.</summary>
    public void Acknowledge(int sequence) {
        if (_client.Level == null || _client.Player == null) {
            return;
        }
        Predictions.Acknowledge(sequence, Level, MoveBackIfStuck);
        for (int i = 0; i < _pendingUseOn.Count;) {
            (int pendingSequence, PendingUseOn use) = _pendingUseOn[i];
            if (pendingSequence > sequence) {
                i++;
                continue;
            }
            _pendingUseOn.RemoveAt(i);
            UseOnOutcome outcome = new(use.Hand, use.Item,
                use.Clicked, use.Face, use.ClickedBefore, Level.GetState(use.Clicked.X, use.Clicked.Y, use.Clicked.Z),
                use.Against, use.AgainstBefore, Level.GetState(use.Against.X, use.Against.Y, use.Against.Z));
            outcome = outcome with { Tool = ToolUseOn.Classify(Transforms, Level, outcome) };
            UsedItemOn?.Invoke(outcome);
            ToolUseOn.RaiseLevelEvents(Level, outcome);
        }
    }

    /// <summary>
    /// <c>ClientLevel.syncBlockState</c>: a correction that puts a block back where the player now stands
    /// moves them back to where they were when they changed it.
    /// </summary>
    private void MoveBackIfStuck(Vec3d where, int x, int y, int z) {
        Minecraft.Physics.Box box = Player.BoundingBox;
        if (box.MaxX > x && box.MinX < x + 1 && box.MaxY > y && box.MinY < y + 1 && box.MaxZ > z && box.MinZ < z + 1) {
            Player.Position = where;
        }
    }

    private enum UseResult {
        Pass,
        /// <summary>Consumed, with the swing predicted on this side.</summary>
        Success,
        /// <summary>Consumed with no swing here, <c>SwingSource.NONE</c> or <c>SERVER_ONLY</c>.</summary>
        Consume,
        /// <summary>Refused: nothing else is tried for the click.</summary>
        Fail
    }

    private static readonly Hand[] Hands = [Hand.MainHand, Hand.OffHand];

    /// <summary><c>Minecraft.startUseItem</c>.</summary>
    private void StartUseItem() {
        if (_isDestroying) {
            return;
        }
        _rightClickDelay = 4;
        if (Player.HandsBusy) {
            return;
        }
        foreach (Hand hand in Hands) {
            ItemStack held = hand == Hand.MainHand ? _client.Inventory.MainHand : _client.Inventory.Offhand;
            SwingAnimation swingAnimation = ItemComponents.Get(held, DataComponent.InteractAnimation) ?? SwingAnimation.Default;
            UseResult result = Target switch {
                EntityHitResult entityHit when !Level.WorldBorder.IsWithinBounds((int)Math.Floor(entityHit.Entity.Position.X),
                    (int)Math.Floor(entityHit.Entity.Position.Z)) => UseResult.Fail,
                EntityHitResult entityHit when WithinEntityRange(entityHit.Entity) => Interact(entityHit, hand, held),
                BlockHitResult blockHit => UseItemOn(hand, blockHit, held),
                _ => UseResult.Pass
            };
            if (result == UseResult.Pass && !ItemComponents.IsEmpty(held)) {
                result = UseItem(hand, held);
            }
            if (result == UseResult.Success) {
                Player.Swing(hand, swingAnimation);
            }
            if (result != UseResult.Pass) {
                return;
            }
        }
    }

    private bool WithinEntityRange(ClientEntity entity) {
        double range = Player.Attributes.Value(Attribute.EntityInteractionRange);
        Minecraft.Physics.Box box = Picking.BoundingBox(entity);
        Vec3d eye = Picking.EyePosition(Player);
        double dx = Math.Max(Math.Max(box.MinX - eye.X, eye.X - box.MaxX), 0);
        double dy = Math.Max(Math.Max(box.MinY - eye.Y, eye.Y - box.MaxY), 0);
        double dz = Math.Max(Math.Max(box.MinZ - eye.Z, eye.Z - box.MaxZ), 0);
        return dx * dx + dy * dy + dz * dz < range * range;
    }

    private UseResult Interact(EntityHitResult hit, Hand hand, ItemStack held) {
        EnsureHasSentCarriedItem();
        Vec3d relative = hit.Location - hit.Entity.Position;
        _client.Send(new ServerBoundInteractPacket {
            EntityId = hit.Entity.Id,
            UsedHand = hand,
            Target = new Vec3<double>(relative.X, relative.Y, relative.Z),
            SneakPressed = Player.KeyPresses.Shift
        });
        if (Player.IsSpectator) {
            return UseResult.Pass;
        }
        if (hit.Entity is ClientMinecartCommandBlock minecart) {
            if (!_client.CanUseGameMasterBlocks) {
                return UseResult.Pass;
            }
            MinecartCommandBlockOpened?.Invoke(minecart);
            return UseResult.Success;
        }
        // Interaction.interact: CONSUME, no swing, unless the server asked for a response.
        if (hit.Entity.Is(EntityClass.Interaction)) {
            return hit.Entity.Get(EntityDataFields.Interaction.Response) ? UseResult.Success : UseResult.Consume;
        }
        return UsePrediction.InteractWithEntity(_client, Player, hit.Entity, held, Player.KeyPresses.Shift) switch {
            InteractionResult.Success => UseResult.Success,
            InteractionResult.Consume => UseResult.Consume,
            _ => UseResult.Pass
        };
    }

    /// <summary><c>MultiPlayerGameMode.useItemOn</c>: the packet always goes, the result decides what follows.</summary>
    private UseResult UseItemOn(Hand hand, BlockHitResult hit, ItemStack held) {
        EnsureHasSentCarriedItem();
        if (!Level.WorldBorder.IsWithinBounds(hit.X, hit.Z)) {
            return UseResult.Fail;
        }
        UseResult result = UseResult.Pass;
        StartPrediction(sequence => {
            result = PerformUseItemOn(hand, hit, held, out bool itemUsedOn);
            if (itemUsedOn) {
                (int X, int Y, int Z) against = Relative(hit.X, hit.Y, hit.Z, hit.Face);
                _pendingUseOn.Add((sequence, new PendingUseOn(hand, held, (hit.X, hit.Y, hit.Z), hit.Face, Level.GetState(hit.X, hit.Y, hit.Z),
                    against, Level.GetState(against.X, against.Y, against.Z))));
            }
            Vec3d inside = hit.Location - new Vec3d(hit.X, hit.Y, hit.Z);
            return new ServerBoundUseItemOnPacket {
                ActiveHand = hand,
                Position = new Vec3<int>(hit.X, hit.Y, hit.Z),
                Face = hit.Face,
                CursorPosition = new Vec3<float>((float)inside.X, (float)inside.Y, (float)inside.Z),
                InsideBlock = hit.Inside,
                WorldBorderHit = hit.WorldBorderHit,
                Sequence = sequence
            };
        });
        return result;
    }

    private static (int X, int Y, int Z) Relative(int x, int y, int z, BlockFace face) => face switch {
        BlockFace.NegY => (x, y - 1, z),
        BlockFace.PosY => (x, y + 1, z),
        BlockFace.NegZ => (x, y, z - 1),
        BlockFace.PosZ => (x, y, z + 1),
        BlockFace.NegX => (x - 1, y, z),
        _ => (x + 1, y, z)
    };

    private UseResult PerformUseItemOn(Hand hand, BlockHitResult hit, ItemStack held, out bool itemUsedOn) {
        itemUsedOn = false;
        if (Player.IsSpectator) {
            return UseResult.Consume;
        }
        bool haveSomething = !ItemComponents.IsEmpty(_client.Inventory.MainHand) || !ItemComponents.IsEmpty(_client.Inventory.Offhand);
        bool suppressUsingBlock = Player.KeyPresses.Shift && haveSomething;
        IBlock block = Level.GetBlock(hit.X, hit.Y, hit.Z);
        if (!suppressUsingBlock && hand == Hand.MainHand && IsGameMasterBlock(block)) {
            if (Level.GetBlockEntity(hit.X, hit.Y, hit.Z) is { } gameMasterBlock && _client.CanUseGameMasterBlocks) {
                GameMasterBlockOpened?.Invoke(gameMasterBlock);
                return UseResult.Success;
            }
        }
        else if (!suppressUsingBlock && UsePrediction.BlockConsumesUse(block, hand)) {
            return UseResult.Success;
        }
        if (ItemComponents.IsEmpty(held) || Player.Cooldowns.IsOnCooldown(held)) {
            return UseResult.Pass;
        }
        // ItemStack.useOn: an adventure player may only use an item on what its can_place_on allows.
        // Divergence: the block predicates are not evaluated, so that case is left to the server.
        if (Player.GameMode == GameMode.Adventure) {
            return UseResult.Pass;
        }
        if (held.Type.CorrespondingBlock != null) {
            UseResult placed = BlockItemUseOn(hand, hit, held);
            return placed is UseResult.Pass or UseResult.Fail && ItemComponents.Has(held, DataComponent.Consumable)
                ? StartConsuming(hand, held)
                : placed;
        }
        itemUsedOn = true;
        // Item.useOn: a block transformer is the whole of what the item does on a block.
        if (ItemComponents.Has(held, DataComponent.BlockTransformer)) {
            return !BlockingItemUseIntent(hand) && Transforms.Find(held, hit.X, hit.Y, hit.Z, hit.Face, Level.GetState) != null
                ? UseResult.Success
                : UseResult.Pass;
        }
        switch (UsePrediction.ItemUseOn(held, block, hit.Face, Player.IsFallFlying, _tags)) {
            case InteractionResult.Success:
                return UseResult.Success;
            case InteractionResult.Consume:
                // BrushItem.useOn: the brush is held in use on the block from here.
                Player.StartUsingItem(hand);
                StartedUsingItem?.Invoke(hand, held);
                return UseResult.Consume;
            default:
                return UseResult.Pass;
        }
    }

    /// <summary>
    /// <c>BlockTransformer.playerHasBlockingItemUseIntent</c>: a shield in the off hand wins the main hand's
    /// click unless the player is sneaking.
    /// </summary>
    private bool BlockingItemUseIntent(Hand hand) =>
        hand == Hand.MainHand && ItemComponents.Has(_client.Inventory.Offhand, DataComponent.BlocksAttacks) && !Player.KeyPresses.Shift;

    /// <summary><c>Consumable.startConsuming</c>, which a block item that could not be placed falls back to.</summary>
    private UseResult StartConsuming(Hand hand, ItemStack held) {
        (bool consumes, int duration) = UsePrediction.ItemUse(held, Player);
        if (!consumes) {
            return UseResult.Fail;
        }
        if (duration == 0) {
            return UseResult.Success;
        }
        Player.StartUsingItem(hand);
        StartedUsingItem?.Invoke(hand, held);
        return UseResult.Consume;
    }

    /// <summary><c>MultiPlayerGameMode.useItem</c>.</summary>
    private UseResult UseItem(Hand hand, ItemStack held) {
        if (Player.IsSpectator) {
            return UseResult.Pass;
        }
        EnsureHasSentCarriedItem();
        UseResult result = UseResult.Pass;
        StartPrediction(sequence => {
            (bool consumes, int duration) = UsePrediction.ItemUse(held, Player);
            if (consumes && !Player.Cooldowns.IsOnCooldown(held)) {
                result = duration != 0 ? UseResult.Consume : UseResult.Success;
                if (duration != 0) {
                    Player.StartUsingItem(hand);
                    StartedUsingItem?.Invoke(hand, held);
                }
                if (held.Type.Identifier == Item.WritableBook.Identifier || held.Type.Identifier == Item.WrittenBook.Identifier) {
                    ItemGuiOpened?.Invoke(hand, held);
                }
            }
            return new ServerBoundUseItemPacket {
                UsedHand = hand,
                Sequence = sequence,
                Yaw = Player.YRot,
                Pitch = Player.XRot
            };
        });
        return result;
    }

    /// <summary><c>MultiPlayerGameMode.releaseUsingItem</c>.</summary>
    private void ReleaseUsingItem() {
        EnsureHasSentCarriedItem();
        _client.Send(Action(ServerBoundPlayerActionPacket.Status.UpdateHeldItem));
        Hand hand = Player.UsedItemHand;
        ItemStack stack = Player.UseItem;
        Player.ReleaseUsingItem();
        ReleasedUsingItem?.Invoke(hand, stack);
    }

    /// <summary><c>MultiPlayerGameMode.dropItem</c>: the hand is emptied here first, and swings only if it held something.</summary>
    private void DropItem(bool all) {
        ItemStack held = _client.Inventory.MainHand;
        if (!ItemComponents.IsEmpty(held)) {
            int remaining = all ? 0 : held.Count - 1;
            _client.Inventory.SetInventorySlot(_client.Inventory.SelectedSlot, remaining <= 0 ? ItemStack.Air : held.WithCount(remaining));
        }
        EnsureHasSentCarriedItem();
        _client.Send(Action(all ? ServerBoundPlayerActionPacket.Status.DropItemStack : ServerBoundPlayerActionPacket.Status.DropItem));
        if (!ItemComponents.IsEmpty(held)) {
            Player.Swing(Hand.MainHand, SwingAnimation.Default);
        }
    }

    /// <summary><c>Minecraft.pickBlock</c>: the server decides what goes in the hand.</summary>
    private void PickBlock(bool includeData) {
        switch (Target) {
            case BlockHitResult block when !Level.IsAir(Level.GetState(block.X, block.Y, block.Z)):
                _client.Send(new ServerBoundPickItemFromBlockPacket { Location = new Vec3<int>(block.X, block.Y, block.Z), IncludeData = includeData });
                break;
            case EntityHitResult entity:
                _client.Send(new ServerBoundPickItemFromEntityPacket { EntityId = entity.Entity.Id, IncludeData = includeData });
                break;
        }
    }

    /// <summary>Back to a new <c>MultiPlayerGameMode</c>'s state, for a login. <c>Minecraft</c>'s own delays carry on.</summary>
    public void Reset() {
        _carriedIndex = 0;
        _isDestroying = false;
        _destroyPos = (-1, -1, -1);
        _destroyingItem = ItemStack.Air;
        _destroyProgress = 0.0F;
        _destroyTicks = 0.0F;
        _destroyDelay = 0;
        _destroyDirection = null;
        Target = null;
    }
}

/// <summary>
/// What one acknowledged <c>use_item_on</c> did: the clicked block and the block against its face, before
/// and after, and the tool use that explains the change if one does.
/// </summary>
public readonly record struct UseOnOutcome(
    Hand Hand,
    ItemStack Item,
    (int X, int Y, int Z) Clicked,
    BlockFace Face,
    ushort ClickedBefore,
    ushort ClickedAfter,
    (int X, int Y, int Z) Against,
    ushort AgainstBefore,
    ushort AgainstAfter) {
    public ToolUse? Tool { get; init; }
}
