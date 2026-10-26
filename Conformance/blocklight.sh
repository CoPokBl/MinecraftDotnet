#!/usr/bin/env bash
# Draws a set of scenes with the vanilla ModelBlockRenderer and FluidRenderer and writes every vertex's
# position, colour and light coords into the fixture BlockLightConformanceTest replays, which pins the
# graphical client's smooth lighting, flat lighting, face shading and fluid lighting to the game's.
#
#   Conformance/blocklight.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump or when a scene is added. The
# test itself just reads the committed file. Needs a client install with its libraries, the classpath
# file of which is the one the client launcher writes.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
game="${MINECRAFT_CLIENT_DIR:-$HOME/.local/share/MinecraftDotnet/vanilla-$version/game-files}"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/GraphicalClient.Testing/Lighting/vanilla-block-light.bin.gz"

if [[ ! -f "$game/classpath.txt" ]]; then
    echo "No client classpath at $game/classpath.txt" >&2
    echo "Install the $version client (or point MINECRAFT_CLIENT_DIR at one) first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$(cat "$game/classpath.txt")"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/BlockLightHarness.java"
(cd "$game" && java -cp "$cp:$work/classes" BlockLightHarness "$fixture")
