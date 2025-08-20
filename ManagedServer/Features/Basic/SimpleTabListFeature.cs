using ManagedServer.Events;
using ManagedServer.TabList;
using Minecraft.Text;

namespace ManagedServer.Features.Basic;

public class SimpleTabListFeature : ScopedFeature {
    
    public override void Register() {
        CustomTabList tabList = new() {
            EntriesProvider = _ => {
                return Scope.Players.Select(p => new TabListEntry(
                    Guid.NewGuid(), 
                    TextComponent.Text(p.Name),
                    0,
                    p.GameMode,
                    p.Name,
                    p.Skin));
            }
        };
        AddEventHandler<PlayerLoginEvent>(e => {
            tabList.AddPlayer(e.Player);
        });

        Scope.Server.Scheduler.ScheduleRepeatingTask(2 * Scope.Server.TargetTicksPerSecond, () => {
            tabList.Refresh();
            return true;
        });
    }
}
