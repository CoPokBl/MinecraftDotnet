#!/usr/bin/env bash
# Dumps the multi noise biome source presets out of the jar, as the fixture that pins the
# transcription of them.
#
#   Conformance/biome-parameters.sh [version]
#
# The overworld's climate to biome table lives in OverworldBiomeBuilder in the jar and in no datapack
# file, so it is one of the few pieces of worldgen content that is transcribed rather than read from
# a source. OverworldBiomeBuilderTest compares all 7599 regions of the transcription against what
# this dumps, in order. Re-run it on a version bump, with the rest of the fixtures.
#
# Needs the server jar CodeGen downloads, so run CodeGen for the version first.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
output="$repo/ManagedServer.Testing/Terrain/vanilla-biome-parameters.json"
# The overworld table is 7599 regions and repeats a few dozen biome names throughout, so it is about
# a megabyte flat and a twentieth of that gzipped. Committed, so it is committed compressed.
compressed="$output.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$output")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/biome-parameters-classes" "$repo/Conformance/BiomeParametersHarness.java"
java -cp "$cp:$work/biome-parameters-classes" BiomeParametersHarness "$output"
gzip -9 -f "$output"
echo "Compressed to $compressed ($(du -h "$compressed" | cut -f1))."
