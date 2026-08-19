#!/usr/bin/env bash
# Generates a world with the real server and writes down every block and biome it put in a set of
# scenes, into the fixture WorldParityConformanceTest replays.
#
#   MCDOTNET_ACCEPT_EULA=1 Conformance/worldparity.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# This is the only fixture here whose input is a world rather than a method. Every other harness drives
# one vanilla method over inputs we chose, and none of them can see a stage that is correct in
# isolation and wired up wrong: a village whose houses all fail to attach, or an ore landing somewhere
# else, is a world built entirely out of right answers.
#
# Running the server means accepting Mojang's EULA (https://aka.ms/MinecraftEULA), which is not
# something this script can do on your behalf, hence MCDOTNET_ACCEPT_EULA.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance/worldparity"
fixture="$repo/ManagedServer.Testing/Terrain/vanilla-world.bin.gz"

# The seed every worldgen test in the tree uses, so a scene can be looked at with TestServer.
seed=1234567890
port="${MCDOTNET_SERVER_PORT:-25599}"

# name:chunkX:chunkZ:size, the bottom left chunk of each scene and how many chunks square it is. Chosen
# for what is over and under them rather than at random: two villages, an ocean whose floor is an
# aquifer, and four biomes whose surface rules and vegetation differ.
scenes=(
    "jungle:-1:-1:3"
    "desert:55:-7:3"
    "badlands:7:-105:3"
    "deep_ocean:-19:19:3"
    "jagged_peaks:-71:93:3"
    "plains_village:-307:-67:3"
    "taiga_village:-188:5:3"
)

# What a chunk's features may write into a neighbour, which is one chunk: vanilla decorates through a
# WorldGenRegion spanning the three by three around the chunk. Loaded two out anyway, since a chunk
# only runs its own features once the ring around it exists and the cost of a wider ring is nothing.
margin=2

bundler="$jars/$version.jar"
server_jar="$jars/versions/$version/server-$version.jar"

if [[ ! -f "$bundler" || ! -f "$server_jar" ]]; then
    echo "No server jar at $bundler / $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

if [[ "${MCDOTNET_ACCEPT_EULA:-}" != "1" ]]; then
    echo "This runs the vanilla dedicated server, which needs Mojang's EULA accepted:" >&2
    echo "  https://aka.ms/MinecraftEULA" >&2
    echo "Re-run with MCDOTNET_ACCEPT_EULA=1 if you accept it." >&2
    exit 2
fi

# A world left over from a previous run is a world generated at whatever the scenes were then.
rm -rf "$work"
mkdir -p "$work"

cp "$bundler" "$work/server.jar"
echo "eula=true" > "$work/eula.txt"

cat > "$work/server.properties" <<PROPERTIES
level-seed=$seed
server-port=$port
online-mode=false
# The watchdog kills the server for a tick spent generating a few hundred chunks.
max-tick-time=-1
view-distance=2
simulation-distance=2
spawn-protection=0
enable-status=false
sync-chunk-writes=true
PROPERTIES

cd "$work"

rm -f commands.fifo
mkfifo commands.fifo
: > server.log

java -Xmx3G -jar server.jar nogui < commands.fifo > server.log 2>&1 &
server=$!
exec 3> commands.fifo

echo "Starting the server..."
for _ in $(seq 1 240); do
    grep -q 'Done (' server.log && break
    sleep 2
done

if ! grep -q 'Done (' server.log; then
    echo "The server never finished starting. See $work/server.log" >&2
    exit 1
fi

harness_scenes=()
for scene in "${scenes[@]}"; do
    IFS=: read -r name chunk_x chunk_z size <<< "$scene"
    harness_scenes+=("$scene")

    from_x=$(( (chunk_x - margin) * 16 ))
    from_z=$(( (chunk_z - margin) * 16 ))
    to_x=$(( (chunk_x + size - 1 + margin) * 16 + 15 ))
    to_z=$(( (chunk_z + size - 1 + margin) * 16 + 15 ))

    echo "Forceloading $name, chunks $((chunk_x - margin)),$((chunk_z - margin)) to $((chunk_x + size - 1 + margin)),$((chunk_z + size - 1 + margin))"
    echo "forceload add $from_x $from_z $to_x $to_z" >&3
done

# Forceloading is a request, not a generation. A chunk answers "loaded" only once it is full, so
# asking about the far corner of every scene is what says the whole set is done.
echo "Waiting for the scenes to generate..."
ready=0
for attempt in $(seq 1 120); do
    for scene in "${scenes[@]}"; do
        IFS=: read -r name chunk_x chunk_z size <<< "$scene"
        corner_x=$(( (chunk_x + size - 1) * 16 + 15 ))
        corner_z=$(( (chunk_z + size - 1) * 16 + 15 ))
        echo "execute if loaded $corner_x 64 $corner_z run say PARITY-$name-$attempt" >&3
    done

    sleep 5

    if [[ $(grep -c "PARITY-.*-$attempt" server.log || true) -eq ${#scenes[@]} ]]; then
        ready=1
        break
    fi
done

if [[ $ready -ne 1 ]]; then
    echo "Not every scene generated. See $work/server.log" >&2
    exit 1
fi

echo "save-all flush" >&3
sleep 15
echo "stop" >&3
wait "$server"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" \
    "$repo/Conformance/WorldParityHarness.java" "$repo/Conformance/Harness.java"

java -cp "$cp:$work/classes" WorldParityHarness \
    "$work/world/dimensions/minecraft/overworld/region" "$fixture" "$seed" "${harness_scenes[@]}"
