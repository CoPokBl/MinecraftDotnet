using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class TestItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.AcaciaBoat)
        .With(DataComponent.ItemName, "Test Item");
    public override string Id => "test";

    public override bool Use(PlayerEntity player) {
        player.SendMessage("Hello there");
        return false;
    }
}
