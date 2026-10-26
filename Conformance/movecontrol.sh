#!/usr/bin/env bash
# Prints what vanilla's MoveControl decides, for the fixtures in
# ManagedServer.Testing/Ai/MoveControlTest.cs.
#
#   Conformance/movecontrol.sh [version]
#
# MoveControl.tick itself needs a live Mob and a level and is out of reach, but its arithmetic is
# not: rotlerp is reached reflectively and the wanted yaw formula is driven directly, so the two
# things a transcription could get wrong (the 90 degree cap and its unusual wrap, and the widened
# float radians constant) are answered by the jar rather than by us. It prints the arrays rather
# than writing a fixture; paste them into the test.
#
# Only needed on a version bump, or when the port changes. Needs the server jar the CodeGen
# project downloads, so run CodeGen for the version first.
set -euo pipefail

version="${1:-26.3}"
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
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/MoveControlHarness.java"
java -cp "$cp:$work/classes" MoveControlHarness
