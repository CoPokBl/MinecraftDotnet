using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.TrimMaterial;

public interface ITrimMaterial : IProtocolType, INetworkType<ITrimMaterial> {
    /// <summary>
    /// The colour palette the client recolours a trim pattern's texture with, which also decides the
    /// darker variant armour of the same material gets.
    /// </summary>
    public Identifier PaletteId { get; }

    /// <summary>Name shown on a trimmed item's tooltip, coloured to match the material.</summary>
    public TextComponent Description { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("palette_id", new StringTag(PaletteId.ToString())),
            ("description", Description.SerialiseToTag()));
    }

    public static ITrimMaterial FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleTrimMaterial(ident, tag["palette_id"]!.GetString(), TextComponent.FromTag(tag["description"]!));
    }

    DataWriter INetworkType<ITrimMaterial>.WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .Write(PaletteId)
            .WriteNbt(Description);
    }

    static ITrimMaterial INetworkType<ITrimMaterial>.ReadData(DataReader reader, MinecraftRegistry registry) {
        return ReadData(reader, registry);
    }

    /// <remarks>
    /// An inline material has no registry name, so the palette it names stands in as its identifier.
    /// </remarks>
    public new static ITrimMaterial ReadData(DataReader reader, MinecraftRegistry registry) {
        Identifier palette = reader.ReadString();
        return new SimpleTrimMaterial(palette, palette, reader.ReadText());
    }
}
