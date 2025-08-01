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
        AddEventListener<PlayerLoginEvent>(e => {
            tabList.AddPlayer(e.Player);
        });

        Scope.Server.Scheduler.ScheduleRepeatingTask(TimeSpan.FromSeconds(2), () => {
            tabList.Refresh();
            return true;
        });
    }
}
