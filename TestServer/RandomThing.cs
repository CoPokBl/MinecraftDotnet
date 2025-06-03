using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Events;

namespace TestServer;

public class RandomThing {

    [EventListener<TestEvent>]
    public static void OnTestEvent(TestEvent e) {
        Console.WriteLine("THE POTATO IS REAL");
    }
}
