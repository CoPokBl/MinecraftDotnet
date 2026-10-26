using System.Runtime.CompilerServices;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace ClientLib;

/// <summary>Chunks, block changes, light and biomes.</summary>
public sealed partial class MinecraftClient {
    public int ServerViewDistance { get; private set; } = 12;
    public int SimulationDistance { get; private set; } = 12;
    public (int X, int Z) CenterChunk { get; private set; }

    /// <summary>Blocks other players are digging, by the digger's entity id, with the crack stage 0 to 9.</summary>
    public Dictionary<int, (int X, int Y, int Z, int Stage)> DestroyStages { get; } = new();

    /// <summary>A block entity data packet loaded into its block entity, which an open editor refreshes from.</summary>
    public event Action<ClientBlockEntity>? BlockEntityDataLoaded;

    /// <summary><c>handleOpenSignEditor</c>: the sign to edit and whether its front, for <c>LocalPlayer.openTextEdit</c>.</summary>
    public event Action<SignBlockEntity, bool>? SignEditorOpened;

    private Particles.ParticleEngine? _particles;

    /// <summary>The level's particles, which do nothing until a renderer enables them.</summary>
    public Particles.ParticleEngine Particles => _particles ??= new Particles.ParticleEngine(this);

    private Particles.AnimateTicks? _animateTicks;

    /// <summary><c>ClientLevel.animateTick</c>, which spawns its particles through <see cref="Particles"/>.</summary>
    public Particles.AnimateTicks AnimateTicks => _animateTicks ??= new Particles.AnimateTicks(this);

    /// <summary>Chunks built on the network thread, waiting for the game thread to install them.</summary>
    private readonly ConditionalWeakTable<ClientBoundChunkDataAndUpdateLightPacket, ClientChunk> _prepared = new();

    private bool HandleWorldPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundChunkDataAndUpdateLightPacket chunk:
                HandleChunk(chunk);
                return true;
            case ClientBoundUnloadChunkPacket unload:
                Level?.RemoveChunk(unload.X, unload.Z);
                return true;
            case ClientBoundUpdateLightPacket light:
                HandleLight(light);
                return true;
            case ClientBoundBlockUpdatePacket update:
                SetServerVerifiedState(update.Location.X, update.Location.Y, update.Location.Z, (ushort)update.Block.StateId);
                return true;
            case ClientBoundSectionBlocksUpdatePacket section:
                if (Level != null) {
                    (int baseX, int baseY, int baseZ) = (section.ChunkSectionPosition.X << 4, section.ChunkSectionPosition.Y << 4, section.ChunkSectionPosition.Z << 4);
                    foreach (Minecraft.Schemas.Blocks.BlockUpdate update in section.BlockUpdates) {
                        SetServerVerifiedState(baseX + update.Location.X, baseY + update.Location.Y, baseZ + update.Location.Z, (ushort)update.Block.StateId);
                    }
                }
                return true;
            case ClientBoundMapDataPacket map when Level != null:
                HandleMapData(map);
                return true;
            case ClientBoundBlockEntityDataPacket blockEntityData:
                // handleBlockEntityData: getBlockEntity(pos, type), loaded only when the type matches.
                if (Level?.GetBlockEntity(blockEntityData.Position.X, blockEntityData.Position.Y, blockEntityData.Position.Z) is { } target
                    && target.Is(blockEntityData.Type) && blockEntityData.Data is CompoundTag data) {
                    target.Load(data, Level.Registry);
                    BlockEntityDataLoaded?.Invoke(target);
                }
                return true;
            case ClientBoundOpenSignEditorPacket openSign:
                if (Level?.GetBlockEntity(openSign.Location.X, openSign.Location.Y, openSign.Location.Z) is SignBlockEntity sign) {
                    SignEditorOpened?.Invoke(sign, openSign.IsFrontText);
                }
                else {
                    Info($"Ignoring openTextEdit on an invalid entity at {openSign.Location.X} {openSign.Location.Y} {openSign.Location.Z}");
                }
                return true;
            case ClientBoundBlockActionPacket blockEvent:
                Level?.BlockEvent(blockEvent.Location.X, blockEvent.Location.Y, blockEvent.Location.Z, blockEvent.ActionId, blockEvent.ActionParameter);
                // NoteBlock.triggerEvent's note, coloured by its pitch, over a block whose instrument can be tuned.
                if (Level?.GetBlock(blockEvent.Location.X, blockEvent.Location.Y, blockEvent.Location.Z) is
                    Minecraft.Data.Generated.BlockTypes.NoteBlockBlock { InstrumentValue: < Minecraft.Schemas.Blocks.BlockEnums.NoteBlockInstrument.Zombie } note) {
                    Particles.AddParticle(Minecraft.Data.Generated.Particle.Note, blockEvent.Location.X + 0.5, blockEvent.Location.Y + 1.2,
                        blockEvent.Location.Z + 0.5, note.Note / 24.0, 0.0, 0.0);
                }
                return true;
            case ClientBoundAcknowledgeBlockChangePacket acknowledge:
                Interactions.Acknowledge(acknowledge.SequenceId);
                return true;
            case ClientBoundChunkBiomesPacket biomes:
                HandleBiomes(biomes);
                return true;
            case ClientBoundSetBlockDestroyStagePacket destroy:
                // LevelRenderer.destroyBlockProgress: a stage outside 0 to 9 ends it.
                if (destroy.Stage < 10) {
                    DestroyStages[destroy.EntityId] = (destroy.Block.X, destroy.Block.Y, destroy.Block.Z, destroy.Stage);
                }
                else {
                    DestroyStages.Remove(destroy.EntityId);
                }
                return true;
            case ClientBoundSetCenterChunkPacket center:
                CenterChunk = (center.X, center.Z);
                return true;
            case ClientBoundSetRenderDistancePacket distance:
                ServerViewDistance = distance.ViewDistance;
                return true;
            case ClientBoundSetSimulationDistancePacket simulation:
                SimulationDistance = simulation.SimulationDistance;
                return true;
            case ClientBoundSetDefaultSpawnPositionPacket spawn when Level != null:
                Level.RespawnPosition = (spawn.Dimension, spawn.Location.X, spawn.Location.Y, spawn.Location.Z);
                return true;
            case ClientBoundInitialiseWorldBorderPacket border when Level != null:
                Level.WorldBorder.SetCenter(border.X, border.Z);
                if (border.Speed > 0L) {
                    Level.WorldBorder.LerpSizeBetween(border.OldDiameter, border.NewDiameter, border.Speed);
                }
                else {
                    Level.WorldBorder.SetSize(border.NewDiameter);
                }
                Level.WorldBorder.SetAbsoluteMaxSize(border.PortalTeleportBoundary);
                Level.WorldBorder.WarningBlocks = border.WarningBlocks;
                Level.WorldBorder.WarningTime = border.WarningTime;
                return true;
            case ClientBoundSetBorderCenterPacket center when Level != null:
                Level.WorldBorder.SetCenter(center.X, center.Z);
                return true;
            case ClientBoundSetBorderLerpSizePacket lerp when Level != null:
                Level.WorldBorder.LerpSizeBetween(lerp.OldDiameter, lerp.NewDiameter, lerp.Speed);
                return true;
            case ClientBoundSetBorderSizePacket size when Level != null:
                Level.WorldBorder.SetSize(size.Diameter);
                return true;
            case ClientBoundSetBorderWarningDistancePacket warning when Level != null:
                Level.WorldBorder.WarningBlocks = warning.WarningBlocks;
                return true;
            case ClientBoundSetBorderWarningDelayPacket delay when Level != null:
                Level.WorldBorder.WarningTime = delay.WarningTime;
                return true;
            case ClientBoundParticlePacket particles:
                Particles.HandlePacket(particles);
                return true;
            case ClientBoundWorldEventPacket levelEvent:
                // ClientPacketListener.handleLevelEvent: a global event goes to globalLevelEvent, which only sounds.
                if (!levelEvent.DisableRelativeVolume) {
                    Particles.LevelEvent(levelEvent.Event, levelEvent.Location.X, levelEvent.Location.Y, levelEvent.Location.Z, levelEvent.Data);
                }
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// <c>ClientLevel.setServerVerifiedBlockState</c>: while a local prediction is pending for the
    /// position the server's word is held back until the acknowledgement, so it cannot flicker.
    /// </summary>
    private void SetServerVerifiedState(int x, int y, int z, ushort state) {
        if (Level != null && !Level.Predictions.UpdateServerState(x, y, z, state)) {
            Level.SetState(x, y, z, state);
        }
    }

    /// <summary>
    /// Decodes a chunk into the client's own sections as it arrives, on the network thread, so the game
    /// thread only has to install it. Built for the level current when it arrived; a chunk that is
    /// handled in another level is built again there.
    /// </summary>
    private void PrepareChunk(ClientBoundChunkDataAndUpdateLightPacket packet) {
        if (Level is { } level) {
            _prepared.AddOrUpdate(packet, BuildChunk(level, packet));
        }
    }

    private void HandleChunk(ClientBoundChunkDataAndUpdateLightPacket packet) {
        ClientLevel? level = Level;
        if (level == null) {
            return;
        }
        ClientChunk chunk = _prepared.TryGetValue(packet, out ClientChunk? prepared) && prepared.Sections.Length == level.SectionCount && prepared.Level == level
            ? prepared
            : BuildChunk(level, packet);
        _prepared.Remove(packet);
        level.AddChunk(chunk);
    }

    private static ClientChunk BuildChunk(ClientLevel level, ClientBoundChunkDataAndUpdateLightPacket packet) {
        ChunkData data = packet.Data;
        int sectionCount = level.SectionCount;
        ClientSection[] sections = new ClientSection[sectionCount];
        ushort[][] biomes = new ushort[sectionCount][];
        uint[] flat = new uint[ClientSection.Volume];
        for (int i = 0; i < sectionCount; i++) {
            biomes[i] = new ushort[64];
            if (i >= data.Sections.Length) {
                sections[i] = new ClientSection(0, true);
                continue;
            }

            ChunkSection section = data.Sections[i];
            if (section.UniformState is { } uniform) {
                sections[i] = new ClientSection((ushort)uniform, level.IsAir(uniform));
            }
            else {
                section.FillFlatStateIds(flat);
                sections[i] = new ClientSection(flat, level.IsAir);
            }
            CopyBiomes(section, biomes[i]);
        }

        ClientChunk chunk = new(packet.ChunkX, packet.ChunkZ, sections, biomes) { Level = level };
        // LevelChunk.replaceWithPacketData: a block entity for each the packet names whose block has one.
        foreach (BlockEntity blockEntity in data.BlockEntities.Values) {
            int x = packet.ChunkX << 4 | blockEntity.X, y = blockEntity.Y, z = packet.ChunkZ << 4 | blockEntity.Z;
            int section = (y - level.MinY) >> 4;
            if ((uint)section >= (uint)sectionCount) {
                continue;
            }
            IBlock state = level.Registry.Blocks.GetByStateId(sections[section].Get(x & 15, y & 15, z & 15));
            if (ClientBlockEntity.Create(level.Registry, x, y, z, state) is { } created) {
                if (created.Is(blockEntity.Type) && blockEntity.Data is CompoundTag tag) {
                    created.Load(tag, level.Registry);
                }
                chunk.BlockEntities[new Vec3<int>(x, y, z)] = created;
            }
        }
        chunk.ApplyLight(packet.Light);
        return chunk;
    }

    private static void CopyBiomes(ChunkSection section, ushort[] cells) {
        for (int y = 0; y < 4; y++) {
            for (int z = 0; z < 4; z++) {
                for (int x = 0; x < 4; x++) {
                    cells[y << 4 | z << 2 | x] = (ushort)section.GetBiome(x, y, z);
                }
            }
        }
    }

    private void HandleLight(ClientBoundUpdateLightPacket packet) {
        ClientLevel? level = Level;
        ClientChunk? chunk = level?.GetChunk(packet.ChunkX, packet.ChunkZ);
        if (chunk == null) {
            return;
        }

        ulong changed = chunk.ApplyLight(packet.Light);
        for (int section = 0; section < level!.SectionCount; section++) {
            if ((changed & (1UL << section)) == 0) {
                continue;
            }
            for (int dx = -1; dx <= 1; dx++) {
                for (int dy = -1; dy <= 1; dy++) {
                    for (int dz = -1; dz <= 1; dz++) {
                        level.MarkSectionDirty(packet.ChunkX + dx, section + dy, packet.ChunkZ + dz);
                    }
                }
            }
        }
    }

    private void HandleBiomes(ClientBoundChunkBiomesPacket packet) {
        ClientLevel? level = Level;
        if (level == null) {
            return;
        }
        foreach (ClientBoundChunkBiomesPacket.ChunkBiomeData data in packet.Chunks) {
            ClientChunk? chunk = level.GetChunk(data.ChunkX, data.ChunkZ);
            if (chunk == null) {
                continue;
            }
            Minecraft.DataReader reader = new(data.Biomes);
            for (int i = 0; i < level.SectionCount; i++) {
                Palette palette = Palette.Deserialise(ChunkSection.BiomeDimension, ChunkSection.BiomesMaxBpe, ChunkSection.BiomesMinBpe,
                    ChunkSection.BiomesMaxBpe, reader, level.Registry.Biomes.Count);
                CopyBiomes(new ChunkSection { BiomesPalette = palette }, chunk.Biomes[i]);
            }
            for (int dx = -1; dx <= 1; dx++) {
                for (int dz = -1; dz <= 1; dz++) {
                    for (int y = 0; y < level.SectionCount; y++) {
                        level.MarkSectionDirty(data.ChunkX + dx, y, data.ChunkZ + dz);
                    }
                }
            }
        }
    }

    /// <summary><c>Level.tickBlockEntities</c>, with the players the tickers look for.</summary>
    private void TickBlockEntities() {
        if (Level is not { } level) {
            return;
        }
        List<TickingPlayer> players = [];
        List<IBlockEntityMovable> movable = [];
        foreach (Entities.ClientEntity entity in Entities.Values) {
            if (entity.Type.Identifier == Minecraft.Data.Generated.EntityType.Player.Identifier && !IsSpectator(entity)) {
                players.Add(new TickingPlayer(entity.Position, entity.CurrentHealth > 0.0F));
            }
            if (entity is IBlockEntityMovable moved and (ClientLib.Player.LocalPlayer or ClientLib.Entities.SimulatedEntity or ClientLib.Entities.Vehicles.ClientVehicle { IsLocalInstanceAuthoritative: true })) {
                movable.Add(moved);
            }
        }
        level.TickBlockEntities(new BlockEntityTickContext(level, players, movable, this), level.TickRateManager.RunsNormally);
    }

    private bool IsSpectator(Entities.ClientEntity player) => player is Player.LocalPlayer local
        ? local.IsSpectator
        : PlayerInfoOf(player)?.GameMode == Minecraft.Schemas.GameMode.Spectator;
}
