# Protocol Conformance Check

Connects to a running Minecraft Dotnet server as a client and checks that the configuration
phase data it sends is accepted by the **vanilla server jar's own codecs**.

Why not a normal test: `ClientLib` and `TestClient` share the protocol library with the
server, so a bug that is symmetric across read and write passes on both sides. Mojang's
classes are the oracle here instead.

No client jar, no assets, no GPU, no authentication. Runs in a couple of seconds.

## Running

Start a server with encryption disabled (`BasicsWithProxySupport` does this):

```bash
dotnet run --project TestServer -- blocksumoffa
```

Then, in another terminal:

```bash
./ProtocolConformance/run.sh                  # defaults to 127.0.0.1:25565
./ProtocolConformance/run.sh 127.0.0.1 25566
```

- Exit code 0 on pass, 1 on failure, so it drops straight into CI.
- Reads the server jar, its libraries and `reports/packets.json` from the code generator's
  working directory, so **run the generator for the target version first**.
- `MC_VERSION` and `MC_DATA_DIR` override those locations.

## What it checks

It collects the registry data and tags the server sends, then runs the same three steps the
client runs and reports whatever they throw:

1. **Built in registry tags bind** onto the real item, block and entity registries via
   `Registry.prepareTagReload(...).apply()`.
2. **Datapack registries load** through `RegistryDataLoader.load(...)`, the networked entry
   point the client uses. Catches unparseable elements, entries sent with no data, unbound
   cross references and the non-empty validators.
3. **Item components initialise** via `BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(...)`,
   where the client resolves things like armour trim materials and damage type tags by key.

There is deliberately no list of required registries or tags maintained here. Such a list
would only encode what is already known to be broken. If the client would reject it, this
reports the identical exception.

## What it does not check

- Only the configuration phase.
- Only the parts of the client that live in the server jar. `RegistryDataCollector` and
  `ClientConfigurationPacketListenerImpl` are client-only, so the client's own orchestration
  around these codecs is not exercised. That needs the real client jar and a much heavier
  setup.

## Verifying the harness itself

Checked against a known regression: dropping `has_ender_dragon_fight` from
`IDimensionType.ToNbt` makes it fail with

```
minecraft:dimension_type/minecraft:the_end did not parse: No key has_ender_dragon_fight in MapLike[...]
```

the same error the real client reported. Repeat that trick if you change the harness. A
conformance check that cannot fail is worse than none.
