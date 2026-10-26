#!/usr/bin/env bash
# Runs the vanilla canSurvive and updateShape over every block state and writes what they decided
# into the fixture PlacementConformanceTest replays. That is what pins the placement rules, which are
# otherwise held up by nothing but a reading of the decompile.
#
#   Conformance/placement.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
#
# getStateForPlacement is deliberately not covered here: it needs a BlockPlaceContext, which needs a
# real Level, and that is out of reach for a harness. These two hooks take interfaces.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Placement/vanilla-placement.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/placement-classes" "$repo/Conformance/PlacementHarness.java"
java -cp "$cp:$work/placement-classes" PlacementHarness "$fixture"
