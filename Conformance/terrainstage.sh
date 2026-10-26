#!/usr/bin/env bash
# Every block the vanilla noise, surface and carver passes leave in a chunk, into the fixture
# TerrainStageConformanceTest replays.
#
#   Conformance/terrainstage.sh [version] [overworld|nether|end]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# This is the step terrain.sh stops short of. That one pins the density functions, the climate sample
# and the biome the parameter list picks, exactly; this pins what they become: the aquifer deciding
# water, lava or stone, the material rules with the ore veins in them, and the carvers.
#
# It is a pass and not a baseline. No neighbour's blocks are read and no random is shared across
# chunks; the one order dependence, the climate search's warm start, is the same on both sides because
# both generate these chunks in this order. So a difference here is the port and nothing else. The carver pass
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

version="${1:-26.3}"
dimension="${2:-overworld}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"

# The seed every worldgen fixture in the tree uses, so a chunk can be looked at with TestServer.
seed=1234567890

# One chunk per biome, all 56 of them, which is what decides whether this measures anything: the
# material rules branch on the biome before anything else, so a run over fifteen of them leaves
# forty biomes' rules touched by nothing. Coordinates are where each biome first appears at this seed,
# printed by ManagedServer.Testing/Terrain/FindStructureClusters, which searches for every biome the
# climate table can name rather than a list someone has to keep up to date.
#
# Plus one chunk that is not here for its biome. Both of the passes MaterialSystem runs around the rule
# pass have to be reached: the badlands spires come with the badlands, but an iceberg is a roll on top
# of a frozen ocean rather than a property of it, so that chunk is picked for holding one.
chunks=(
    "8:-104"      # badlands
    "8:0"         # bamboo_jungle
    "-8:-8"       # beach
    "-8:32"       # birch_forest
    "152:-152"    # cherry_grove
    "-56:-8"      # cold_ocean
    "-96:152"     # dappled_forest
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
    "-81:14"      # a frozen ocean chunk carrying a large iceberg, which is a pass of its own
)

# The nether's five biomes, from the same search with DIMENSION=nether, two chunks lying wholly
# inside a forest, since the search's hit is one quart and 0:-16 turns out to hold no warped floor,
# and five more chunks for their carving: the nether's cave carver is a cave with its own data, so a
# chunk is only worth having for it where a tunnel reaches.
nether_chunks=(
    "16:24"       # basalt_deltas
    "0:8"         # crimson_forest
    "0:0"         # nether_wastes
    "-8:8"        # soul_sand_valley
    "0:-16"       # warped_forest
    "-64:-54"     # warped_forest, all sixteen quarts of it
    "-64:-22"     # crimson_forest, all sixteen quarts of it
    "3:-5"
    "-20:11"
    "40:-33"
    "-57:-61"
    "101:7"
)

# The end's five biomes, from the same search with DIMENSION=end, and the central island across its
# middle and out to where it thins into the void, since that island is a distance function of its own
# rather than the outer islands' noise. 64:1 is the first chunk past the circle both the biome source and
# the outer islands function draw, and the rest are outer islands further out. The end has no carvers,
# so the third stage only checks that nothing carves.
end_chunks=(
    "48:48"       # end_barrens
    "-56:56"      # end_highlands
    "-48:-48"     # end_midlands
    "48:-48"      # small_end_islands
    "0:0"         # the_end
    "-1:-1"
    "3:-2"
    "-6:2"
    "0:7"
    "64:1"
    "-56:-54"     # an end city starts here
    "100:-37"
    "-210:150"
)

case "$dimension" in
    overworld) fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrainstage.bin.gz" ;;
    nether)
        fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrainstage-nether.bin.gz"
        chunks=("${nether_chunks[@]}")
        ;;
    end)
        fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrainstage-end.bin.gz"
        chunks=("${end_chunks[@]}")
        ;;
    *) echo "No dimension named $dimension: overworld, nether or end." >&2; exit 2 ;;
esac

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
    "$fixture" "$seed" "$dimension" "${chunks[@]}"
