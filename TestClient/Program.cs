using Minecraft.Implementations.Client.Tools;
using Minecraft.NBT;
using Minecraft.Packets.Status.ClientBound;

ClientBoundStatusResponsePacket status = await ServerPinger.QueryServer("mc.emortal.dev");
Console.WriteLine($"Description: {status.Description!.ToJsonString()}");
// Console.WriteLine(JsonConvert.SerializeObject(status));
