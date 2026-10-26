using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Particles.Types;

/// <summary><c>ItemParticleOption</c>, sent as an <c>ItemStackTemplate</c>: the item before the count, and never empty.</summary>
public record ItemParticle(Identifier Identifier,  ItemStack? Item = null) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return (Item ?? ItemStack.Air).WriteTemplateData(writer, registry);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Item = ItemStack.ReadTemplateData(reader, registry)
        };
    }
}
