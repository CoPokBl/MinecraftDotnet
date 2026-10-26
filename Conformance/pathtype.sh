#!/usr/bin/env bash
# Runs the vanilla WalkNodeEvaluator classification over every block state and over built scenes, and
# writes what it decided into the fixture PathTypeConformanceTest replays. That is what pins the C#
# block classification, which is the whole fidelity risk of the pathfinder: a wrong rule is one our
# own tests would encode too.
#
#   Conformance/pathtype.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just reads
# the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for the
# version first.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Pathfinding/vanilla-pathtype.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/pathtype-classes" "$repo/Conformance/PathTypeHarness.java"
java -cp "$cp:$work/pathtype-classes" PathTypeHarness "$fixture"
