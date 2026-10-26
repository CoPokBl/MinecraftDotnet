using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Text;

namespace GraphicalClient.Rendering.Entities;

/// <summary>Whose <c>shouldShowName</c> and <c>getNameTag</c> an entity's renderer has.</summary>
public enum NameTagRule : byte {
    /// <summary><c>EntityRenderer</c>'s.</summary>
    Entity,

    /// <summary><c>LivingEntityRenderer</c>'s, by the team's name tag visibility.</summary>
    Living,

    /// <summary><c>MobRenderer</c>'s: the living rule, and only while named and shown or looked at.</summary>
    Mob,

    /// <summary><c>AvatarRenderer</c>'s: the living rule, a player always and a mannequin as a mob.</summary>
    Avatar,

    /// <summary><c>ArmorStandRenderer</c>'s: exactly while the custom name is set visible.</summary>
    ArmorStand,

    /// <summary><c>ItemFrameRenderer</c>'s: a renamed item's name, while the frame is looked at.</summary>
    ItemFrame
}

/// <summary>
/// <c>EntityRenderer.extractNameTags</c> and <c>submitNameDisplay</c>, with each renderer's <c>shouldShowName</c>
/// behind a <see cref="NameTagRule"/>, so the built in art that stands in for a renderer draws names too.
/// </summary>
public static class NameTags {
    /// <summary>
    /// The rule of the renderer vanilla gives the entity, for one drawn without a renderer here. Taken from its class,
    /// which is wrong only for a mob whose renderer is not a <c>MobRenderer</c>: the ender dragon's, which has
    /// <see cref="NameTagRule.Entity"/>.
    /// </summary>
    public static NameTagRule RuleFor(ClientEntity entity) =>
        entity.Is(EntityClass.Avatar) ? NameTagRule.Avatar
        : entity.Is(EntityClass.ArmorStand) ? NameTagRule.ArmorStand
        : entity.Is(EntityClass.ItemFrame) ? NameTagRule.ItemFrame
        : entity.Is(EntityClass.Mob) ? NameTagRule.Mob
        : entity.IsLiving ? NameTagRule.Living
        : NameTagRule.Entity;

    /// <summary>
    /// <c>extractNameTags</c>: a living entity's distances are its attributes, anything else's 64 and 10. Vanilla takes
    /// the attachment only with the name and leaves a reused state's old one under a score shown alone; here it is taken
    /// for either.
    /// </summary>
    public static void Extract(ClientEntity entity, EntityRenderState state, float partialTick, EntityRenderContext context, NameTagRule rule) {
        bool living = rule is not (NameTagRule.Entity or NameTagRule.ItemFrame);
        double nameTagDistance = living ? entity.Attributes.Value(Minecraft.Data.Generated.Attribute.NameTagDistance) : 64.0;
        double belowNameDistance = living ? entity.Attributes.Value(Minecraft.Data.Generated.Attribute.BelowNameDistance) : 10.0;
        Vec3d camera = context.Camera.Position;
        double dx = entity.Position.X - camera.X, dy = entity.Position.Y - camera.Y, dz = entity.Position.Z - camera.Z;
        state.DistanceToCameraSq = dx * dx + dy * dy + dz * dz;
        state.NameTag = state.DistanceToCameraSq < nameTagDistance * nameTagDistance && ShouldShowName(rule, entity, state.DistanceToCameraSq, context)
            ? TextFlattener.Decode(TextFlattener.Flatten(NameTag(rule, entity, context))).ToList()
            : null;
        state.ScoreText = state.DistanceToCameraSq < belowNameDistance * belowNameDistance && BelowNameDisplay(entity, context.Client) is { } score
            ? TextFlattener.Decode(TextFlattener.Flatten(score)).ToList()
            : null;
        if (state.NameTag != null || state.ScoreText != null) {
            Vec3d attachment = entity.NameTagAttachmentPoint(EntityRenderer.GetYRot(entity, partialTick));
            state.NameTagAttachment = new Vector3((float)attachment.X, (float)attachment.Y, (float)attachment.Z);
        }
        else {
            state.NameTagAttachment = null;
        }
    }

    private static bool ShouldShowName(NameTagRule rule, ClientEntity entity, double distanceToCameraSq, EntityRenderContext context) => rule switch {
        NameTagRule.Entity => ShownOrLookedAt(entity, context),
        NameTagRule.Living => LivingShouldShowName(entity, distanceToCameraSq, context),
        NameTagRule.Mob => LivingShouldShowName(entity, distanceToCameraSq, context) && ShownOrLookedAt(entity, context),
        // Player.shouldShowName is always true; a mannequin keeps Entity's.
        NameTagRule.Avatar => LivingShouldShowName(entity, distanceToCameraSq, context) && (entity.Is(EntityClass.Player) || ShownOrLookedAt(entity, context)),
        NameTagRule.ArmorStand => entity.Get(EntityDataFields.Entity.CustomNameVisible),
        NameTagRule.ItemFrame => !context.HideGui && IsCrosshairPick(entity, context)
                                 && entity.Get(EntityDataFields.ItemFrame.Item) is { } item && ItemNames.CustomName(item) != null,
        _ => false
    };

    /// <summary><c>getNameTag</c>: <c>Entity.getDisplayName</c>, or a frame's item's hover name.</summary>
    private static TextComponent NameTag(NameTagRule rule, ClientEntity entity, EntityRenderContext context) =>
        rule == NameTagRule.ItemFrame && entity.Get(EntityDataFields.ItemFrame.Item) is { } item ? ItemNames.HoverName(item) : context.Client.DisplayNameOf(entity);

    /// <summary><c>EntityRenderer.shouldShowName</c>: always while the custom name is set visible, else while it is looked at and named.</summary>
    private static bool ShownOrLookedAt(ClientEntity entity, EntityRenderContext context) =>
        entity.Get(EntityDataFields.Entity.CustomNameVisible) || entity.Get(EntityDataFields.Entity.CustomName) is { Present: true } && IsCrosshairPick(entity, context);

    private static bool IsCrosshairPick(ClientEntity entity, EntityRenderContext context) =>
        context.Client.Interactions.Target is EntityHitResult { Entity: var picked } && picked == entity;

    /// <summary><c>LivingEntityRenderer.shouldShowName</c>: by the team's name tag rule, else to anyone but the camera.</summary>
    private static bool LivingShouldShowName(ClientEntity entity, double distanceToCameraSq, EntityRenderContext context) {
        if (entity.IsCrouching && distanceToCameraSq >= 1024.0) {
            return false;
        }
        MinecraftClient client = context.Client;
        bool isVisibleToPlayer = !IsInvisibleToPlayer(entity, client);
        if (entity != client.Player && client.TeamOf(entity) is { } team) {
            Team? myTeam = client.Player is { } player ? client.TeamOf(player) : null;
            // PlayerTeam.isAlliedTo: the same team.
            return team.NameTags switch {
                ClientBoundUpdateTeamsPacket.NameTagVisibility.Never => false,
                ClientBoundUpdateTeamsPacket.NameTagVisibility.HideForOtherTeams => myTeam == null
                    ? isVisibleToPlayer
                    : team == myTeam && (team.SeeFriendlyInvisibles || isVisibleToPlayer),
                ClientBoundUpdateTeamsPacket.NameTagVisibility.HideForOwnTeam => myTeam == null ? isVisibleToPlayer : team != myTeam && isVisibleToPlayer,
                _ => isVisibleToPlayer
            };
        }
        return !context.HideGui && entity != client.CameraEntity && isVisibleToPlayer && !entity.IsVehicle;
    }

    /// <summary><c>Entity.isInvisibleTo</c> the local player.</summary>
    private static bool IsInvisibleToPlayer(ClientEntity entity, MinecraftClient client) {
        if (client.Player is not { } player) {
            return entity.IsInvisible;
        }
        if (player.IsSpectator) {
            return false;
        }
        Team? team = client.TeamOf(entity);
        return (team == null || client.TeamOf(player) != team || !team.SeeFriendlyInvisibles) && entity.IsInvisible;
    }

    /// <summary><c>Entity.belowNameDisplay</c>: the score on the objective shown under names, then its name.</summary>
    private static TextComponent? BelowNameDisplay(ClientEntity entity, MinecraftClient client) {
        Scoreboard scoreboard = client.Scoreboard;
        if (scoreboard.DisplayedIn(ClientBoundDisplayObjectivePacket.DisplayPosition.BelowName) is not { } objective
            || scoreboard.ScoreOf(client.ScoreboardName(entity), objective.Name) is not { } score) {
            return null;
        }
        // numberFormatOrDefault(StyledFormat.NO_STYLE), under the score's own.
        TextComponent line = TextComponent.Text("");
        line.Children.AddRange([Gui.ScoreboardSidebar.FormatValue(score.NumberFormat ?? objective.NumberFormat, score.Value, null), TextComponent.Text(" "), objective.DisplayName]);
        return line;
    }

    /// <summary><c>submitNameDisplay</c>, at the entity's position in the pose: the score, then the name a line and a bit over it.</summary>
    public static void Submit(EntityRenderState state, PoseStack pose, EntityRenderContext context, int offset = 0) {
        if (context.TextDisplays is not { } batch || state.NameTagAttachment is not { } attachment) {
            return;
        }
        pose.Push();
        if (state.ScoreText != null) {
            SubmitNameTag(batch, pose, state, attachment, offset, state.ScoreText, TextDisplayBatch.MeshSlot.Score, context);
            pose.Translate(0.0F, 9.0F * 1.15F * 0.025F, 0.0F);
        }
        if (state.NameTag != null) {
            SubmitNameTag(batch, pose, state, attachment, offset, state.NameTag, TextDisplayBatch.MeshSlot.NameTag, context);
        }
        pose.Pop();
    }

    /// <summary>
    /// <c>SubmitNodeCollection.submitNameTag</c>: facing the camera, a fortieth of a block to a font pixel. A name that
    /// is not discrete is drawn twice, fully opaque where nothing is in front of it and faint through whatever is.
    /// </summary>
    private static void SubmitNameTag(TextDisplayBatch batch, PoseStack pose, EntityRenderState state, Vector3 attachment, int offset, List<TextRun> text,
        TextDisplayBatch.MeshSlot slot, EntityRenderContext context) {
        pose.Push();
        pose.Translate(attachment.X, attachment.Y + 0.5F, attachment.Z);
        CameraOrientation.Apply(pose, context.Camera);
        pose.Scale(0.025F, -0.025F, 0.025F);
        float x = -batch.Width(text) / 2.0F;
        uint background = batch.DefaultBackground & 0xFF000000;
        float backgroundAlpha = (background >> 24) / 255.0F;
        byte textAlpha = (byte)Mth.Floor(Math.Max((backgroundAlpha + 0.75F) * 0.5F, 0.5F) * 255.0F);
        int id = state.Entity.Id;
        if (!state.IsDiscrete) {
            // LightCoordsUtil.lightCoordsWithEmission(lightCoords, 2).
            batch.SubmitLine(id, slot, text, pose.Matrix, x, offset, false, 255, 0, state.SkyLight, Math.Max(state.BlockLight, 2));
            batch.SubmitLine(id, slot, text, pose.Matrix, x, offset, true, textAlpha, background, state.SkyLight, state.BlockLight);
        }
        else {
            batch.SubmitLine(id, slot, text, pose.Matrix, x, offset, false, textAlpha, background, state.SkyLight, state.BlockLight);
        }
        pose.Pop();
    }
}
