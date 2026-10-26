#!/usr/bin/env bash
# What the real EnvironmentAttributeSystem says every environment attribute comes to, over the vanilla pack's
# dimension types, biomes and timelines, for EnvironmentAttributeConformanceTest to replay.
#
#   Conformance/environmentattributes.sh [version]
#
# Each case is a dimension, a clock time, a rain and thunder level and a position, and each positional attribute is
# asked both with the camera's blend of the biomes round the position and without it. The biomes come from a layout
# both sides compute, so what is pinned is the layering, the timelines' keyframes and easing, the weather's blends
# and the biome interpolation, not anyone's terrain.
#
# Only needed on a version bump, or when the evaluator changes. Needs the server jar the CodeGen project downloads,
# so run CodeGen for the version first.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/Minecraft.Testing/Data/vanilla-environment-attributes.txt.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/environment-classes" "$repo/Conformance/EnvironmentAttributeHarness.java"
(cd "$work" && java -cp "$cp:$work/environment-classes" EnvironmentAttributeHarness "$fixture")
