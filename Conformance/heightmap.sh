#!/usr/bin/env bash
# Runs vanilla's own Heightmap.primeHeightmaps over a set of scenes and diffs its answers against
# ours, column by column.
#
#   Conformance/heightmap.sh [version]
#
# Every rule in HeightmapStates is a reading of the jar: whether MOTION_BLOCKING is blocksMotion()
# alone or that or a fluid, whether leaves are excluded by class or by tag, and whether the stored
# number is the highest matching block or one above it. Our own tests encode the same reading, so
# they cannot catch a misreading of it. This can.
#
# Needs the server jar the CodeGen project downloads, so run CodeGen for the version first.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work"
dotnet run --project "$repo/Conformance" -- "$work/packets.json" --heightmaps "$work/heightmaps.json"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/heightmap-classes" "$repo/Conformance/HeightmapHarness.java" "$repo/Conformance/Harness.java"
java -cp "$cp:$work/heightmap-classes" HeightmapHarness "$work/heightmaps.json"
