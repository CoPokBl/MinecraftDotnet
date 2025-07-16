using ManagedServer.Events;

namespace ManagedServer.Features;

public class DropItemsOnGroundFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerDropItemEvent>(e => {
            if (e.Cancelled) {
                return;
            }
            
            e.World.DropItem(e.Player.Position, e.Item);
        });
    }
}
