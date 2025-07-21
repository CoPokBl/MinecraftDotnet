using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class TestItem : LuckyBlockItem {
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.AcaciaBoat)
        .With(DataComponent.ItemName, "Test Item");
    public override string Id => "test";

    public override void Use(PlayerEntity player) {
        player.SendMessage("Hello there");
    }
}
