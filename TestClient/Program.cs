using System.Text.Json;
using Minecraft.Implementations.Client.Tools;
using Minecraft.Packets.Status.ClientBound;
using Newtonsoft.Json;

ClientBoundStatusResponsePacket status = await ServerPinger.QueryServer("mc.hypixel.net");
Console.WriteLine($"Description: {status.Description}");
Console.WriteLine(JsonConvert.SerializeObject(status));