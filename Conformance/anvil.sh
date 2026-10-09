#!/usr/bin/env bash
# Writes a world directory through AnvilLoader and opens it with vanilla's own RegionFile and chunk
# parser, diffing every block, biome and block entity against what was meant to be stored.
#
#   Conformance/anvil.sh [version]
#
# Our round trip tests read back through our own reader, which passes whenever the writer and the
# reader share a mistake: a sector layout vanilla drops, a palette width it reads differently, a
# DataVersion it would run data fixers over. This reads the file the way a server opening the world
# does.
#
# Needs the server jar the CodeGen project downloads, so run CodeGen for the version first.
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
dotnet run --project "$repo/Conformance" -- "$work/packets.json" --anvil "$work/anvil-world" "$work/anvil.json"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/anvil-classes" "$repo/Conformance/AnvilHarness.java" "$repo/Conformance/Harness.java"
java -cp "$cp:$work/anvil-classes" AnvilHarness "$work/anvil-world" "$work/anvil.json"
