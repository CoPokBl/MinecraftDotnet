using ClientLib.Events;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;

namespace ClientLib.Features.Basic;

public class GravityFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<TickEvent>(e => {
            int maxY = Scope.Client.World.Dimension.MinY + Scope.Client.World.Dimension.Height - 1;
            int currentX = (int)Math.Floor(Scope.Client.Position.X);
            int currentZ = (int)Math.Floor(Scope.Client.Position.Z);
            for (int i = maxY; i > Scope.Client.World.Dimension.MinY; i--) {
                IBlock block = Scope.Client.World.GetBlock(new Vec3<int>(currentX, i, currentZ));
                if (block.Identifier != Block.Air.Identifier) {
                    // Found a block, set the Y position to the top of this block
                    Scope.Client.Position = new Vec3<double>(Scope.Client.Position.X, i + 1, Scope.Client.Position.Z);
                    Console.WriteLine("Found block at Y: " + i + ", setting position to: " + Scope.Client.Position);
                    Console.WriteLine("Standing on block: " + block.Identifier);
                    break;
                }
            }
        });
    }
}
