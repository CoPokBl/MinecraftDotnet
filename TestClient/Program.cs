using Minecraft.Implementations.Client.Tools;

// ClientBoundStatusResponsePacket status = await ServerPinger.QueryServer("mc.emortal.dev");
// Console.WriteLine($"Description: {status.Description!.ToJsonString()}");

Console.WriteLine("Microsoft logging in");
MicrosoftAuthenticator auth = new();
await auth.Authenticate(u => {
    Console.WriteLine(u);
});

// Console.WriteLine(JsonConvert.SerializeObject(status));
