#!/usr/bin/env bash
# Every block the vanilla noise, surface and carver passes leave in a chunk, into the fixture
# TerrainStageConformanceTest replays.
#
#   Conformance/terrainstage.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# This is the step terrain.sh stops short of. That one pins all fifteen entries of the NoiseRouter, the
# climate sample and the biome the parameter list picks, at exact zero tolerance; it says nothing about
# what those numbers become. The aquifer turning barrier and the two fluid_level noises into water, lava
# or stone, OreVeinifier turning the three vein noises into ore, the interpolation walk over the cells,
# and the whole surface rule tree on top of it were all visible only through worldparity.sh, whose error
# bar is about a third of its own value.
#
# It is a pass and not a baseline. All three are pure functions of the world seed and the chunk
# position: no neighbour's blocks are read, no random is shared across chunks, and nothing depends on
# the order chunks were asked for. So a difference here is the port and nothing else. The carver pass
# replaying every chunk within eight is not an exception: a source chunk's carvers are seeded from the
# world seed, the carver's index in that chunk's biome's list and the source chunk position alone.
#
# The carve is also the one stage the harness transcribes vanilla's loop for rather than calling it,
# because ChunkGenerator.applyCarvers takes a WorldGenRegion and everything under it takes a
# ChunkAccess. See TerrainStageHarness.carve for what that does and does not measure.
#
# The fixture regenerates byte for byte identical, which is the check that vanilla's own three passes
# are reproducible run to run over these chunks. A pass fixture is only worth having while that holds.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrainstage.bin.gz"

# The seed every worldgen fixture in the tree uses, so a chunk can be looked at with TestServer.
seed=1234567890

# One chunk per biome, all 55 of them, which is what decides whether this measures anything: the
# surface rule tree branches on the biome before anything else, so a run over fifteen of them leaves
# forty biomes' rules touched by nothing. Coordinates are where each biome first appears at this seed,
# printed by ManagedServer.Testing/Terrain/FindStructureClusters, which searches for every biome the
# climate table can name rather than a list someone has to keep up to date.
#
# Plus one chunk that is not here for its biome. Both of the passes SurfaceSystem runs around the rule
# pass have to be reached: the badlands spires come with the badlands, but an iceberg is a roll on top
# of a frozen ocean rather than a property of it, so that chunk is picked for holding one.
chunks=(
    "8:-104"      # badlands
    "8:0"         # bamboo_jungle
    "-8:-8"       # beach
    "-8:32"       # birch_forest
    "152:-152"    # cherry_grove
    "-56:-8"      # cold_ocean
    "-24:32"      # dark_forest
    "-64:-48"     # deep_cold_ocean
    "24:-80"      # deep_dark
    "-104:48"     # deep_frozen_ocean
    "0:-16"       # deep_lukewarm_ocean
    "-24:-40"     # deep_ocean
    "64:-8"       # desert
    "-56:48"      # dripstone_caves
    "8:-112"      # eroded_badlands
    "-32:112"     # flower_forest
    "-16:0"       # forest
    "-72:16"      # frozen_ocean
    "80:-160"     # frozen_peaks
    "-88:32"      # frozen_river
    "-96:120"     # grove
    "-304:288"    # ice_spikes
    "-200:-80"    # jagged_peaks
    "-8:0"        # jungle
    "8:-8"        # lukewarm_ocean
    "0:0"         # lush_caves
    "-104:-192"   # mangrove_swamp
    "-72:56"      # meadow
    "152:0"       # mushroom_fields
    "-16:16"      # ocean
    "-40:-32"     # old_growth_birch_forest
    "-48:40"      # old_growth_pine_taiga
    "-64:-16"     # old_growth_spruce_taiga
    "-192:-48"    # pale_garden
    "-24:-16"     # plains
    "-8:8"        # river
    "-16:-16"     # savanna
    "-8:104"      # savanna_plateau
    "-96:48"      # snowy_beach
    "-88:64"      # snowy_plains
    "-72:96"      # snowy_slopes
    "-80:48"      # snowy_taiga
    "16:-8"       # sparse_jungle
    "48:-88"      # stony_peaks
    "-48:-24"     # stony_shore
    "40:40"       # sulfur_caves
    "-48:112"     # sunflower_plains
    "224:80"      # swamp
    "-56:56"      # taiga
    "64:-16"      # warm_ocean
    "224:56"      # windswept_forest
    "208:88"      # windswept_gravelly_hills
    "-120:-216"   # windswept_hills
    "232:48"      # windswept_savanna
    "24:168"      # wooded_badlands
    "-82:14"      # a frozen ocean chunk carrying a large iceberg, which is a pass of its own
)

server_jar="$jars/versions/$version/server-$version.jar"

if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/terrainstage-classes" \
    "$repo/Conformance/TerrainStageHarness.java" "$repo/Conformance/Harness.java"

java -Xmx3G -cp "$cp:$work/terrainstage-classes" TerrainStageHarness \
    "$fixture" "$seed" "${chunks[@]}"
