#!/usr/bin/env bash
# Asks the vanilla shape code whether a fluid gets through the boundary between two blocks, for every
# pair of collision shapes in the game, and writes the answers into the fixture
# FluidWallConformanceTest replays. That is what pins the one part of the fluid port that was built
# from the boxes rather than transcribed from a vanilla method.
#
#   Conformance/fluid-wall.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Fluids/vanilla-fluid-wall.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/FluidWallHarness.java"
java -cp "$cp:$work/classes" FluidWallHarness "$fixture"
