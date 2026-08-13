#!/usr/bin/env bash
# Prints the walk trajectories EntityTravelInputTest pins: a living entity holding its forward input
# on stone and on ice, run against the real Mth table out of the server jar.
#
#   Conformance/travel.sh [version]
#
# Unlike the harnesses beside it this one transcribes the vanilla method rather than driving it, so
# read the header of TravelHarness.java for what it does and does not prove. It prints the two arrays
# rather than writing a fixture; paste them into the test.
#
# Only needed on a version bump, or when the travel arithmetic changes. Needs the server jar the
# CodeGen project downloads, so run CodeGen for the version first.
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
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/TravelHarness.java"
java -cp "$cp:$work/classes" TravelHarness
