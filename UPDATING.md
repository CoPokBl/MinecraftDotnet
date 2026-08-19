# Tasks Required To Bump Minecraft Version

### 1. Code Gen
- Ensure that `VanillaJarUrls.cs` has the URL for the new version. (Find URLs at [mcversions.net](https://mcversions.net/))
- See if any new complex particles were added (particles with custom data), if so
create a new class for them in `/Data/Particles/Types/` and then specify them in
`CodeGen/Data/complex_particles.json`. Find new particles on the [Minecraft Wiki](https://minecraft.wiki/w/Java_Edition_protocol/Particles).
- Run the code generator (make sure to set the correct version as an argument). It needs a
JDK on `PATH` that is at least as new as the server jar: it runs the vanilla data generator
and compiles `CodeGen/Data/Dumper.java` against the unpacked jar.
- If `Dumper.java` no longer compiles, a method it calls was renamed or hidden upstream. Fix it
there rather than working around it, and check `EntityTypeCodeGen.Computed` still describes the
right classes.
- Read the dumper's own warnings. It reflects over `BlockBehaviour.Properties`, `BlockState` and
`EntityType` at the end of a run and names any member nothing dumps, which is how a newly added
block property gets noticed instead of silently missing.

### 2. Check for Changes
- New packets
- Check code gen for warnings of missing types (data components, etc.)
- Run `./Conformance/run.sh <version>` and fix everything it reports. Packets whose *fields*
changed don't fail to compile and still round-trip through our own deserialiser, so this is
what catches them: it decodes our packets with the vanilla codecs the client uses.
- Regenerate the other fixtures too: `registries.sh`, `lighting.sh`, `clip.sh`, `fluid-wall.sh`,
`pathtype.sh`, `placement.sh`, `heightmap.sh`, `terrain.sh`, `terrainstage.sh`, `blocktransform.sh`,
`featureorder.sh`, `worldparity.sh` and `structurelayout.sh`, each with the same version. They are committed answers from the old jar, so until they are regenerated
they pin last version's behaviour. `worldparity.sh` and `structurelayout.sh` run the dedicated server,
so they want `MCDOTNET_ACCEPT_EULA=1`. World parity's baselines belong to the fixture rather than to
the seed: re-record every number in `WorldParityConformanceTest.Baseline` from the run against the new
one. `structurelayout.sh`'s cluster list is one chunk per biome and is reprinted by the explicit
`FindStructureClusters` test if the biome layout moves.
- `hashset.sh` is deliberately **not** on that list. It pins `java.util.HashMap`'s iteration order,
which is the JDK's rather than the jar's, so a Minecraft version cannot move it and regenerating it
on a bump only risks re-recording it from a JDK whose behaviour changed. Regenerate it if the JDK
changes that order, which would show as `JavaHashSetConformanceTest` failing.
- Add the new server jar URL to `ManagedServer/Terrain/Data/VanillaDatapack.cs`. That is the only
place a version is wired to a download, and the tests, the benchmarks and the demos all resolve their
worldgen data and loot tables through it. There is no vanilla data in this repository to refresh.
- Re-dump the climate tables with `Conformance/biome-parameters.sh <version>` and re-run
`OverworldBiomeBuilderTest`. `OverworldBiomeBuilder` is transcribed rather than read, because the table
lives in code in the jar and in no datapack file, so an upstream change to it is a silently different
world until that test fails.
- Run `dotnet test`. The physics fixtures carry numbers taken from vanilla, so a change in
how it moves entities shows up as a failure there rather than as a client desync.
