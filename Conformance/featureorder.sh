#!/usr/bin/env bash
# Writes down the order vanilla's FeatureSorter puts every placed feature in, per decoration step, into
# the fixture FeatureOrderConformanceTest replays.
#
#   Conformance/featureorder.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# A feature's index in that list is what seeds it, so this decides where every tree, ore and patch of
# grass in the world ends up. Nothing about a feature says what its index should be: it comes out of a
# topological sort over every biome's list, with ties broken by the order the biomes were fed in, and
# both of those are easy to get plausibly wrong. The world still generates, with everything in it
# somewhere else.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Terrain/vanilla-feature-order.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/featureorder-classes" \
    "$repo/Conformance/FeatureOrderHarness.java" "$repo/Conformance/Harness.java"

java -cp "$cp:$work/featureorder-classes" FeatureOrderHarness "$fixture"
