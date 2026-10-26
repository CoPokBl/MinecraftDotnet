using ClientLib.Interaction;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Player;

/// <summary>Vanilla's <c>ItemCooldowns</c>: groups the server has put on cooldown, counted in the player's ticks.</summary>
public sealed class ItemCooldowns {
    private readonly Dictionary<Identifier, (int StartTime, int EndTime)> _cooldowns = new();
    private int _tickCount;

    public bool IsOnCooldown(ItemStack item) => GetCooldownPercent(item, 0.0F) > 0.0F;

    public float GetCooldownPercent(ItemStack item, float a) {
        if (!_cooldowns.TryGetValue(GetCooldownGroup(item), out (int StartTime, int EndTime) cooldown)) {
            return 0.0F;
        }
        float duration = cooldown.EndTime - cooldown.StartTime;
        float remaining = cooldown.EndTime - (_tickCount + a);
        return Math.Clamp(remaining / duration, 0.0F, 1.0F);
    }

    public void Tick() {
        _tickCount++;
        foreach ((Identifier group, (int _, int endTime)) in _cooldowns.ToArray()) {
            if (endTime <= _tickCount) {
                _cooldowns.Remove(group);
            }
        }
    }

    public static Identifier GetCooldownGroup(ItemStack item) =>
        ItemComponents.Get(item, DataComponent.UseCooldown)?.CooldownGroup ?? item.Type.Identifier;

    public void AddCooldown(Identifier cooldownGroup, int time) => _cooldowns[cooldownGroup] = (_tickCount, _tickCount + time);

    public void RemoveCooldown(Identifier cooldownGroup) => _cooldowns.Remove(cooldownGroup);
}
