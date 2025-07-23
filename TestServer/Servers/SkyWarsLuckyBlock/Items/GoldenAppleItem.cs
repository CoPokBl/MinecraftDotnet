using ManagedServer.Entities.Types;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;

namespace TestServer.Servers.SkyWarsLuckyBlock.Items;

public class GoldenAppleItem : SkyWarsItem {
    public override ItemStack Item => new ItemStack(1, Minecraft.Data.Generated.Item.GoldenApple)
        .With(DataComponent.Consumable, new ConsumableComponent.Data(1f, ConsumableComponent.ConsumeAnimation.Spyglass, 
            Or<ISoundType, SoundEvent>.FromValue1(SoundType.AllayHurt), true, []));
    
    public override string Id => "golden_apple";

    public override void OnEat(PlayerEntity player) {
        player.Heal(4);
    }
}
