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
what catches them — it decodes our packets with the vanilla codecs the client uses.
- Regenerate the other fixtures too: `registries.sh`, `lighting.sh`, `clip.sh`, `fluid-wall.sh`
and `pathtype.sh`, each with the same version. They are committed answers from the old jar, so
until they are regenerated they pin last version's behaviour.
- Run `dotnet test`. The physics fixtures carry numbers taken from vanilla, so a change in
how it moves entities shows up as a failure there rather than as a client desync.
