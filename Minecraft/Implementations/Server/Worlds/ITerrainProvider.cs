namespace Minecraft.Implementations.Server.Worlds;

public interface ITerrainProvider {
    public uint GetBlock(int x, int y, int z);
}