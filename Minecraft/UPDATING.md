# Tasks Required To Bump Minecraft Version

### 1. Code Gen
- Ensure that `VanillaJarUrls.cs` has the URL for the new version. (Find URLs at [mcversions.net](https://mcversions.net/))
- Go to the Minestom data extractor and get the block.json and item.json files. For more info
see the [README](../CodeGen/Data/README.md).
- See if any new complex particles were added (particles with custom data), if so
create a new class for them in `/Data/Particles/Types/` and then specify them in
`CodeGen/Data/complex_particles.json`. Find new particles on the [Minecraft Wiki](https://minecraft.wiki/w/Java_Edition_protocol/Particles).
- Run the code generator (make sure to set the correct version as an argument)

### 2. Check for Changes
- New packets
- New data components
