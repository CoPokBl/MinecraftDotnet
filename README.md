# Minecraft Dotnet
This project is a WIP Minecraft protocol implementation.

It supports:
- Minecraft 1.21.10
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

## Versioning (Protocol & Managed Server)
`0.0.x` - 1.21.5  
`0.1.x` - 1.21.10  
`0.2.x` - 1.21.11  

The major version is probably going to be used for Minecraft major updates.

## Contributing
Feel free to submit a pull request with contribution. If I'm missing
a packet, data component or similar, then submitting a PR adding that packet is probably the most
helpful type of contribution.
