using ClientLib.Entities;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.DimensionType;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace ClientLib;

/// <summary>The play phase: joining a level, leaving it, and the packets each part of the client handles.</summary>
public sealed partial class MinecraftClient {
    public ClientLevel? Level { get; private set; }
    public LocalPlayer? Player { get; private set; }
    public Dictionary<int, ClientEntity> Entities { get; } = new();
    public PlayerInventory Inventory { get; private set; } = new();
    public ContainerMenu? OpenContainer { get; private set; }

    public bool Hardcore { get; private set; }
    /// <summary>The login packet's <c>enforcesSecureChat</c>, which <see cref="EnforcesSecureChat"/> also needs the services' keys for.</summary>
    public bool ServerEnforcesSecureChat { get; private set; }
    public Identifier[] Dimensions { get; private set; } = [];

    /// <summary>The player's hands: digging, using, attacking and what the crosshair is on.</summary>
    public Interaction.MultiPlayerGameMode Interactions { get; }

    /// <summary>What the number keys and the wheel drive in spectator mode instead of the hotbar.</summary>
    public Interaction.SpectatorGui SpectatorGui { get; }

    /// <summary>Whether <c>player_loaded</c> has gone out for the current level.</summary>
    public bool ClientLoaded { get; private set; }

    /// <summary>
    /// Whether the section the player stands in is ready to be shown. A renderer sets this to the
    /// section having been meshed, which is what vanilla waits for; headless, a loaded chunk is enough.
    /// </summary>
    public Func<bool>? PlayerSectionReady { get; set; }

    private ClientEntity? _cameraEntity;

    /// <summary><c>Minecraft.getCameraEntity</c>: what the view follows, the player unless it spectates another entity.</summary>
    public ClientEntity? CameraEntity => _cameraEntity ?? Player;

    /// <summary>
    /// <c>Minecraft.setCameraEntity</c>. Vanilla also picks the creeper, spider and enderman post effects
    /// here, which this client's shader packs have no counterpart for.
    /// </summary>
    private void SetCameraEntity(ClientEntity? entity) => _cameraEntity = entity;

    /// <summary>A new level replaced the old one: login, respawn into another dimension, or reconfiguration.</summary>
    public event Action<ClientLevel>? LevelChanged;

    /// <summary>
    /// A tick the player spent in a portal with the confusion transition, where vanilla closes an open screen
    /// that is not <c>isAllowedInPortal</c>, sending a container's close first.
    /// </summary>
    public event Action? InsideConfusionPortal;

    internal void OnInsideConfusionPortal() => InsideConfusionPortal?.Invoke();

    private ClientClockManager _clocks = new();
    private LevelLoadState _levelLoad = LevelLoadState.None;
    private long _levelLoadTimeout;

    private enum LevelLoadState {
        None,
        WaitingForServer,
        WaitingForPlayerChunk
    }

    /// <summary>Puts the client in a level with no server behind it, for driving the player in tests.</summary>
    internal LocalPlayer StartOffline(ClientLevel level, int entityId = 1) {
        Level = level;
        Player = new LocalPlayer(this) {
            Id = entityId,
            Uuid = Profile.Uuid,
            Type = Minecraft.Data.Generated.EntityType.Player
        };
        Entities.Clear();
        Entities[entityId] = Player;
        _cameraEntity = null;
        _clocks = level.Clocks;
        Phase = ClientPhase.Play;
        ClientLoaded = true;
        return Player;
    }

    private void HandlePlay(MinecraftPacket packet) {
        if (HandleCommon(packet) || HandleWorldPacket(packet) || HandleEntityPacket(packet) || HandlePlayerPacket(packet) || HandleHudPacket(packet)
            || HandleAdvancementPacket(packet) || HandleStatsPacket(packet) || HandleRecipePacket(packet)) {
            return;
        }
        switch (packet) {
            case ClientBoundLoginPacket login:
                HandleLogin(login);
                break;
            case ClientBoundRespawnPacket respawn:
                HandleRespawn(respawn);
                break;
            case ClientBoundStartConfigurationPacket:
                HandleStartConfiguration();
                break;
            case ClientBoundGameEventPacket gameEvent:
                HandleGameEvent(gameEvent);
                break;
            case ClientBoundUpdateTimePacket time:
                HandleTime(time);
                break;
            case ClientBoundSetCameraPacket camera:
                // ClientPacketListener.handleSetCamera: an entity this client does not know leaves the view alone.
                if (Entities.TryGetValue(camera.EntityId, out ClientEntity? viewed)) {
                    SetCameraEntity(viewed);
                }
                break;
            case ClientBoundSetTickingStatePacket ticking when Level != null:
                Level.TickRateManager.SetTickRate(ticking.TickRate);
                Level.TickRateManager.IsFrozen = ticking.IsFrozen;
                break;
            case ClientBoundStepTickPacket step when Level != null:
                Level.TickRateManager.FrozenTicksToRun = step.TickSteps;
                break;
            case ClientBoundSetContainerContentPacket or ClientBoundSetContainerSlotPacket or ClientBoundSetPlayerInventorySlotPacket
                or ClientBoundSetCursorItemPacket or ClientBoundOpenScreenPacket or ClientBoundCloseContainerPacket
                or ClientBoundSetContainerPropertyPacket or ClientBoundUpdateRecipesPacket or ClientBoundMerchantOffersPacket
                or ClientBoundOpenBookPacket:
                HandleContainerPacket(packet);
                break;
            case ClientBoundCommandsPacket or ClientBoundCommandSuggestionsResponsePacket or ClientBoundChatSuggestionsPacket:
                HandleCommandPacket(packet);
                break;
            case ClientBoundEntityEventPacket entityEvent:
                if (Entities.TryGetValue(entityEvent.EntityId, out ClientEntity? target)) {
                    target.HandleEntityEvent(entityEvent.Status);
                    if (entityEvent.Status == ClientBoundEntityEventPacket.EntityEventType.FishingHookPull && target.Is(EntityClass.FishingHook)) {
                        PullHookedEntity(target);
                    }
                }
                HandleCommandPacket(packet);
                break;
        }
    }

    private void HandleLogin(ClientBoundLoginPacket login) {
        ResetCommands();
        ResetRecipeBookForLogin();
        ResetAdvancements();
        Dimensions = login.Dimensions;
        ServerViewDistance = login.ViewDistance;
        SimulationDistance = login.SimulationDistance;
        Hardcore = login.IsHardcore;
        ResetChatForLogin(login);
        ResetStatsForLogin();
        // Vanilla's clocks belong to the packet listener, which each entry to the play phase makes anew.
        _clocks = new ClientClockManager();

        // Vanilla makes a new MultiPlayerGameMode here and nowhere else, so a respawn keeps what it holds.
        Interactions.Reset();
        _maps.Clear();
        SetLevel(login.DimensionName, login.DimensionType, login.SeaLevel, login.IsFlat, login.HashedSeed);

        Player = new LocalPlayer(this) {
            Id = login.EntityId,
            Uuid = Profile.Uuid,
            Type = Minecraft.Data.Generated.EntityType.Player,
            YRot = -180.0F,
            GameMode = login.GameMode,
            PreviousGameMode = login.PreviousGameMode,
            ReducedDebugInfo = login.ReducedDebugInfo,
            ShowDeathScreen = login.EnableRespawnScreen,
            LastDeathLocation = DeathLocationOf(login.Location),
            PortalCooldown = login.PortalCooldown
        };
        Player.UpdateAbilities(login.GameMode);
        OnPlayerCreated();
        Entities.Clear();
        Entities[Player.Id] = Player;
        SetCameraEntity(Player);
        BossOverlay.Reset();
        Scoreboard.Clear();
        Inventory = new PlayerInventory();
        OpenContainer = null;
        StartWaitingForLevel();
        Info($"Joined {login.DimensionName} as entity {login.EntityId} in {login.GameMode}");
    }

    private void SetLevel(Identifier name, int dimensionType, int seaLevel, bool flat, long seed) {
        IDimensionType type = Registry.DimensionTypes[dimensionType];
        Level?.Clear();
        Level = new ClientLevel(Registry, name, type, seaLevel, flat, seed, _clocks);
        LevelChanged?.Invoke(Level);
    }

    private static (Identifier, int, int, int)? DeathLocationOf(DeathLocation? location) =>
        location == null ? null : (location.Dimension, location.Position.X, location.Position.Y, location.Position.Z);

    private void HandleRespawn(ClientBoundRespawnPacket respawn) {
        LocalPlayer old = Player!;
        // A respawn is a new LocalPlayer in vanilla, whose first health is not a hit.
        _healthReceived = false;
        if (Level == null || !Level.Name.Equals(respawn.DimensionName)) {
            SetLevel(respawn.DimensionName, respawn.DimensionType, respawn.SeaLevel, respawn.IsFlat, respawn.HashedSeed);
        }

        if (Inventory.ActiveMenu != Inventory.Menu) {
            CloseContainer();
            ContainerClosed?.Invoke();
        }

        bool keepMetadata = (respawn.DataKept & ClientBoundRespawnPacket.DataKeptTypes.Metadata) != 0;
        LocalPlayer player = new(this, keepMetadata ? old : null) {
            Id = old.Id,
            Uuid = old.Uuid,
            Type = old.Type,
            GameMode = respawn.GameMode,
            PreviousGameMode = respawn.PreviousGameMode,
            ReducedDebugInfo = old.ReducedDebugInfo,
            ShowDeathScreen = old.ShowDeathScreen,
            LastDeathLocation = DeathLocationOf(respawn.Location),
            PortalCooldown = respawn.PortalCooldown,
            PortalEffectIntensity = old.PortalEffectIntensity,
            OPortalEffectIntensity = old.OPortalEffectIntensity
        };
        // The abilities start from their defaults: adjustPlayer applies the old game mode, setLocalMode the new.
        player.UpdateAbilities(old.GameMode);
        player.UpdateAbilities(respawn.GameMode);
        player.Attributes.CopyFrom(old.Attributes, (respawn.DataKept & ClientBoundRespawnPacket.DataKeptTypes.Attributes) != 0);
        if (keepMetadata) {
            foreach ((int index, MetaField field) in old.Metadata) {
                player.Metadata[index] = field;
            }
            player.DeltaMovement = old.DeltaMovement;
            player.YRot = old.YRot;
            player.XRot = old.XRot;
        }
        else {
            player.YRot = -180.0F;
        }

        Entities.Clear();
        Entities[player.Id] = player;
        Player = player;
        OnPlayerCreated();
        SetCameraEntity(player);
        DeathMessage = null;
        // The inventory is the player's, so the new one starts on the first slot until the server says otherwise.
        Inventory = new PlayerInventory(Inventory.Data);
        OpenContainer = null;
        StartWaitingForLevel();
    }

    /// <summary><c>ClientPacketListener.handleConfigurationStart</c>: the level goes, the connection carries on.</summary>
    private void HandleStartConfiguration() {
        FlushChatForConfiguration();
        Level?.Clear();
        Level = null;
        Player = null;
        Entities.Clear();
        SetCameraEntity(null);
        ClientLoaded = false;
        Phase = ClientPhase.Configuration;
        _pendingRegistries.Clear();
        _pendingTags.Clear();
        Send(new ServerBoundAcknowledgeConfigurationPacket());
        Connection!.OutboundState = ConnectionState.Configuration;
        Connection.SetInboundState(ConnectionState.Configuration);
    }

    private void StartWaitingForLevel() {
        ClientLoaded = false;
        _levelLoad = LevelLoadState.WaitingForServer;
        _levelLoadTimeout = Environment.TickCount64 + 30000;
    }

    private void TickLevelLoad() {
        if (_levelLoad != LevelLoadState.WaitingForPlayerChunk || ClientLoaded || Player == null || Level == null) {
            return;
        }

        bool ready;
        if (Environment.TickCount64 > _levelLoadTimeout) {
            Info("Timed out waiting for the player's chunk, joining anyway");
            ready = true;
        }
        else if (Player.Position.Y < Level.MinY || Player.Position.Y > Level.MaxY || Player.IsSpectator || Player.IsDead) {
            ready = true;
        }
        else {
            ready = PlayerSectionReady?.Invoke() ?? Level.HasChunk((int)Math.Floor(Player.Position.X) >> 4, (int)Math.Floor(Player.Position.Z) >> 4);
        }

        if (ready) {
            Send(new ServerBoundPlayerLoadedPacket());
            ClientLoaded = true;
            _levelLoad = LevelLoadState.None;
        }
    }

    private void HandleGameEvent(ClientBoundGameEventPacket packet) {
        switch (packet.Event) {
            // Vanilla starts rain at zero and a stop at one: the server's level changes then fade it.
            case GameEvent.BeginRaining when Level != null:
                Level.RainLevel = 0.0F;
                break;
            case GameEvent.EndRaining when Level != null:
                Level.RainLevel = 1.0F;
                break;
            case GameEvent.WinGame:
                // The end credits would play here; the client goes straight back instead.
                Respawn();
                break;
            case GameEvent.RainLevelChange when Level != null:
                Level.RainLevel = Math.Clamp(packet.Value, 0.0F, 1.0F);
                break;
            case GameEvent.ThunderLevelChange when Level != null:
                Level.ThunderLevel = Math.Clamp(packet.Value, 0.0F, 1.0F);
                break;
            case GameEvent.ChangeGameMode when Player != null: {
                // MultiPlayerGameMode.setLocalMode.
                GameMode mode = (GameMode)(int)packet.Value;
                if (mode != Player.GameMode) {
                    Player.PreviousGameMode = Player.GameMode;
                }
                Player.GameMode = mode;
                Player.UpdateAbilities(mode);
                break;
            }
            case GameEvent.EnableRespawnScreen when Player != null:
                Player.ShowDeathScreen = packet.Value == 0.0F;
                break;
            case GameEvent.StartWaitingForLevelChunks when _levelLoad == LevelLoadState.WaitingForServer:
                _levelLoad = LevelLoadState.WaitingForPlayerChunk;
                break;
        }
    }

    /// <summary><c>ClientPacketListener.handleSetTime</c>.</summary>
    private void HandleTime(ClientBoundUpdateTimePacket time) {
        if (Level == null) {
            return;
        }
        Level.GameTime = time.GameTime;
        Level.Clocks.HandleUpdates(time.GameTime,
            time.ClockUpdates.Select(clock => (Registry.WorldClocks.NameOf(clock.ClockId), clock.TotalTicks, clock.PartialTick, clock.Rate)));
    }

    /// <summary>
    /// <c>Minecraft.getTickTargetMillis</c>: the client follows a server ticking slower than twenty a
    /// second, never a faster one, and keeps twenty while the server is frozen.
    /// </summary>
    public float TickTargetMillis(float defaultTickTargetMillis) =>
        Level is { TickRateManager: { RunsNormally: true } manager } ? Math.Max(defaultTickTargetMillis, manager.MillisecondsPerTick) : defaultTickTargetMillis;

    private void TickPlay() {
        Level?.TickRateManager.Tick();
        TickLevelLoad();
        // Gui.tick's chat listener, then Hud.tick's chat window.
        ChatListener.Tick();
        ChatMessages.Tick();

        if (Options.AutoRespawn && Player is { IsDead: true } && ClientTicks - _respawnRequestedTick > 40) {
            Respawn();
        }

        if (ActionBarTime > 0) {
            ActionBarTime--;
        }
        if (TitleTime > 0) {
            TitleTime--;
        }

        ClientLevel? level = Level;
        level?.Light.Tick();
        TickEntities();
        TickBlockEntities();
        if (level is { TickRateManager.RunsNormally: true }) {
            level.WorldBorder.Tick();
            level.TickTime();
        }
        if (level != null) {
            Particles.TickExplosions();
        }
        // Minecraft.tick runs the particle engine after the level's entities, and the animate tick before it.
        if (level is { TickRateManager.RunsNormally: true }) {
            AnimateTicks.Tick();
        }
        Particles.Tick();
        Send(new ServerBoundClientTickEndPacket());
    }
}
