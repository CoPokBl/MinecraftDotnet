# Minecraft Dotnet
This project is a WIP Minecraft protocol implementation.

It supports:
- Minecraft 26.2
- Serialising and deserialising packets
- Sending and receiving them over TCP
- Packet compression
- Encryption
- Mojang authentication and profile resolution

It can be used as just a packet library without anything else,
or as a full Minecraft server framework that is modular so that
you can add only what you want.

Check out the `TestServer` project for an example of how you can
create a Minecraft server implementation.

## State
This project is heavily **UNDER DEVELOPMENT**.  
But despite this it is completely possible to make a game.

Examples:  
- [Lucky Block SkyWars](https://github.com/CoPokBl/LuckyBlockSkyWars) (A version also exists in TestServer/Servers/SkyWarsLuckyBlock)
- [Parkour](https://github.com/Serble/ParkourDotnet)
- [Block Sumo FFA](https://github.com/Serble/BlockSumoFFA)
- The entire `TestServer` subproject

## Running a server
Turn on the server garbage collector in your own project file:

```xml
<PropertyGroup>
    <ServerGarbageCollection>true</ServerGarbageCollection>
    <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>
</PropertyGroup>
```

Chunk loading runs one thread pool task per chunk and each one allocates megabytes. Under the
default workstation collector that work is collected on the thread that allocated it, which means
inside a chunk load, so a joining player waits for it. This is an application's choice rather than
a library's, which is why the packages do not set it for you.

## Versioning (Protocol & Managed Server)
`0.0.x` - 1.21.5  
`0.1.x` - 1.21.10  
`0.2.x` - 1.21.11  
`0.3.x` - 26.2  

The major version is probably going to be used for Minecraft major updates.
THERE SHOULD BE **ZERO EXPECTATION** OF BACKWARDS COMPATIBILITY BETWEEN
MINECRAFT VERSIONS (unless protocol compatible). However, if you wish
to use an older version of Minecraft then just use an older nuget version
of the package.

## Contributing
Feel free to submit a pull request with contribution. If I'm missing
a packet, data component or similar, then submitting a PR adding that packet is probably the most
helpful type of contribution.
