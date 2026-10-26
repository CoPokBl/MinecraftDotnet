#!/usr/bin/env bash
# Runs the real vanilla noise router over a grid of positions and writes down every number it produced,
# into the fixture TerrainConformanceTest replays.
#
#   Conformance/terrain.sh [version] [overworld|nether|end]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# This is the only thing that can tell the density function port from a plausible impostor: a wrong
# constant, a wrong spline derivative or a noise seeded from the wrong name all produce terrain that
# looks like Minecraft and is not the world vanilla would have generated.
set -euo pipefail

version="${1:-26.3}"
dimension="${2:-overworld}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
case "$dimension" in
    overworld) fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrain.bin.gz" ;;
    nether) fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrain-nether.bin.gz" ;;
    end) fixture="$repo/ManagedServer.Testing/Terrain/vanilla-terrain-end.bin.gz" ;;
    *) echo "No dimension named $dimension: overworld, nether or end." >&2; exit 2 ;;
esac

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/terrain-classes" "$repo/Conformance/TerrainHarness.java" "$repo/Conformance/Harness.java"
java -cp "$cp:$work/terrain-classes" TerrainHarness "$fixture" "$dimension"
