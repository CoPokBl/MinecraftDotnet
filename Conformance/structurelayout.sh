#!/usr/bin/env bash
# Every structure start the real server laid out over a spread of the world, as the fixture
# StructureLayoutConformanceTest replays.
#
#   MCDOTNET_ACCEPT_EULA=1 Conformance/structurelayout.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# This is the only measurement of the structure pass that names a structure. The decoration parity
# harness skips a chunk a structure wrote into, and world parity reports one number per scene with the
# feature pass mixed into it; what a start is, on the other hand, the server writes down in the chunk
# itself, piece by piece.
#
# A start is written the moment a chunk reaches structure_starts, the second status, and a full chunk
# needs everything within eight of it at that status for its own references. So a forceloaded two by
# two records starts for the seventeen by seventeen around it, which is why the clusters below are tiny
# and the areas read off them are not.
#
# Running the server means accepting Mojang's EULA (https://aka.ms/MinecraftEULA), which is not
# something this script can do on your behalf, hence MCDOTNET_ACCEPT_EULA.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance/structurelayout"
fixture="$repo/ManagedServer.Testing/Terrain/vanilla-structures.txt.gz"

# The seed every worldgen test in the tree uses, so a start can be looked at with TestServer.
seed=1234567890
port="${MCDOTNET_SERVER_PORT:-25598}"

# The middle chunk of each cluster to forceload. What a sample of this is worth is decided by which
# biomes it reaches, exactly as it is for the decoration parity metric, so the first block is one
# cluster per biome a structure set names rather than a scatter: an ocean monument needs deep ocean, a
# mansion needs dark forest, and a run over plains says nothing about either. The rest are spread
# across a few hundred thousand blocks for the sets that need no particular biome.
#
# The named coordinates are where each biome first appears at this seed, printed by the explicit test
# ManagedServer.Testing/Terrain/FindStructureClusters.cs. Which structures then start there is
# vanilla's answer, not this build's, so a placement that is wrong shows up as a start on one side and
# nothing on the other.
clusters=(
    "8:-104"     # badlands
    "8:0"        # bamboo jungle
    "-8:-8"      # beach
    "152:-152"   # cherry grove
    "-24:32"     # dark forest
    "24:-80"     # deep dark
    "-104:48"    # deep frozen ocean
    "-24:-40"    # deep ocean
    "64:-8"      # desert
    "-56:48"     # dripstone caves
    "-72:16"     # frozen ocean
    "-304:288"   # ice spikes
    "-8:0"       # jungle
    "8:-8"       # lukewarm ocean
    "0:0"        # lush caves
    "-104:-192"  # mangrove swamp
    "152:0"      # mushroom fields
    "-48:40"     # old growth pine taiga
    "-24:-16"    # plains
    "-16:-16"    # savanna
    "-96:48"     # snowy beach
    "-88:64"     # snowy plains
    "-80:48"     # snowy taiga
    "-48:112"    # sunflower plains
    "224:80"     # swamp
    "-56:56"     # taiga
    "64:-16"     # warm ocean
    "-120:-216"  # windswept hills

    # One candidate chunk per structure a biome cluster does not happen to contain. A village is one
    # chunk in a thousand, so being in the right biome is not enough; these come off the placement
    # arithmetic, printed by FindStructureClusters.PrintForStructures.
    "5:42"       # jungle pyramid
    "-317:-114"  # woodland mansion
    "-141:166"   # pillager outpost
    "1:179"      # ruined portal, desert
    "16:50"      # ruined portal, jungle
    "-61:-19"    # ruined portal, mountain
    "219:93"     # ruined portal, swamp
    "59:192"     # village, desert
    "68:-102"    # village, savanna
    "-290:-272"  # village, snowy

    # The scenes world parity already records, so the two fixtures describe the same places.
    "-307:-67"
    "-188:5"
    "55:-7"
    "7:-105"
    "-19:19"
    "-71:93"

    # Far out, for the sets whose placement is arithmetic over the whole world rather than a biome.
    "400:400"
    "-620:210"
    "830:-430"
    "-1100:-900"
    "1500:640"
    "-2400:1750"
    "3100:-2200"
)

# How far either side of a cluster's centre to forceload, and how far to read starts off it. Eight is
# the structure_references range, so a forceloaded chunk drags everything within eight to
# structure_starts; one less than that is the margin that keeps a read chunk inside what was written.
load=1
read_radius=7

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

# A world left over from a previous run is a world generated at whatever the clusters were then.
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

areas=()
for cluster in "${clusters[@]}"; do
    IFS=: read -r chunk_x chunk_z <<< "$cluster"

    from_x=$(( (chunk_x - load) * 16 ))
    from_z=$(( (chunk_z - load) * 16 ))
    to_x=$(( (chunk_x + load) * 16 + 15 ))
    to_z=$(( (chunk_z + load) * 16 + 15 ))

    echo "Forceloading around $chunk_x,$chunk_z"
    echo "forceload add $from_x $from_z $to_x $to_z" >&3

    areas+=("$(( chunk_x - read_radius )):$(( chunk_z - read_radius )):$(( read_radius * 2 + 1 ))")
done

# Forceloading is a request, not a generation. A chunk answers "loaded" only once it is full, so
# asking about the far corner of every cluster is what says the whole set is done.
echo "Waiting for the clusters to generate..."
ready=0
for attempt in $(seq 1 120); do
    for cluster in "${clusters[@]}"; do
        IFS=: read -r chunk_x chunk_z <<< "$cluster"
        corner_x=$(( (chunk_x + load) * 16 + 15 ))
        corner_z=$(( (chunk_z + load) * 16 + 15 ))
        echo "execute if loaded $corner_x 64 $corner_z run say LAYOUT-$chunk_x-$chunk_z-$attempt" >&3
    done

    sleep 5

    if [[ $(grep -c "LAYOUT-.*-$attempt" server.log || true) -eq ${#clusters[@]} ]]; then
        ready=1
        break
    fi
done

if [[ $ready -ne 1 ]]; then
    echo "Not every cluster generated. See $work/server.log" >&2
    exit 1
fi

echo "save-all flush" >&3
sleep 15
echo "stop" >&3
wait "$server"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/StructureLayoutHarness.java"

java -cp "$cp:$work/classes" StructureLayoutHarness \
    "$work/world/dimensions/minecraft/overworld/region" "$fixture" "$seed" "${areas[@]}"
