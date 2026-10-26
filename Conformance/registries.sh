#!/usr/bin/env bash
# Parses the datapack driven registries we send with the vanilla element codecs, which is what the
# client does with them and what decoding the registry_data packet does not.
#
#   Conformance/registries.sh [version]
#
# Needs the server jar the CodeGen project downloads, so run CodeGen for the version first.
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
dotnet run --project "$repo/Conformance" -- "$work/corpus.json" "$work/registries.json"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/RegistryHarness.java"
java -cp "$cp:$work/classes" RegistryHarness "$work/registries.json"
