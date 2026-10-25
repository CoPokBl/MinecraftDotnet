#!/usr/bin/env bash
# Runs the vanilla outline clip the crosshair makes over the scenes whose shape the per state table
# cannot hold, and the pick a held attack range makes, and writes what they decided into the fixture
# PickingConformanceTest replays. That is what pins Picking.ClipBlocks, which decides the block, face and
# cursor position of every use packet, and Picking.ClosestHit, which decides what a spear is aimed at.
#
#   Conformance/picking.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
set -euo pipefail

version="${1:-26.2}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ClientLib.Testing/Interaction/vanilla-picking.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/PickingHarness.java"
java -cp "$cp:$work/classes" PickingHarness "$fixture"
