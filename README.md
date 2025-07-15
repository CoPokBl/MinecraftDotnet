# Minecraft Dotnet
This project is a WIP Minecraft protocol implementation.

It supports:
- Minecraft 1.21.7
- Serialising and deserialising packets
- Sending and receiving them over TCP
- Packet compression

It can be used as just a packet library without anything else,
or as a full Minecraft server framework that is modular so that
you can add only what you want.

Check out the `TestServer` project for an example of how you can
create a Minecraft server implementation.

## State
This project is heavily **UNDER DEVELOPMENT**.  

## Contributing
Feel free to submit a pull request with contribution. If I'm missing
a packet, then submitting a PR adding that packet is probably the most
helpful type of contribution.
