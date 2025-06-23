using Minecraft.Implementations.Client.Tools;
using Minecraft.Packets.Status.ClientBound;
using Newtonsoft.Json;

ClientBoundStatusResponsePacket status = await ServerPinger.QueryServer("localhost");
Console.WriteLine($"Description: {status.Description}");
Console.WriteLine(JsonConvert.SerializeObject(status));
