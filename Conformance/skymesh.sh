#!/usr/bin/env bash
# Runs the client's SkyRenderer mesh builders, the star field above all, and writes the vertex bytes into the
# fixture SkyMeshConformanceTest replays against ClientLib.Sky.SkyMeshes.
#
#   Conformance/skymesh.sh [classpath file]
#
# This needs client classes, which the server jar does not have: pass a file holding a runnable client's
# classpath (every library jar and the client jar, colon separated). It defaults to the install the
# GraphicalClient's vanilla comparisons use. Only needed on a version bump, or when SkyMeshes changes.
set -euo pipefail

repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
classpath_file="${1:-$HOME/.local/share/MinecraftDotnet/vanilla-26.3/game-files/classpath.txt}"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ClientLib.Testing/Sky/vanilla-sky.bin.gz"

if [[ ! -f "$classpath_file" ]]; then
    echo "No client classpath at $classpath_file" >&2
    exit 2
fi

mkdir -p "$work"
cp="$(tr -d '\n' < "$classpath_file")"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/SkyMeshHarness.java"
java -cp "$cp:$work/classes" SkyMeshHarness "$fixture"
