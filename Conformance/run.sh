#!/usr/bin/env bash
# Serialises every client bound packet we implement and decodes it with the vanilla stream
# codecs, which catches packets whose wire format drifted from the game's.
#
#   Conformance/run.sh [version]
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
dotnet run --project "$repo/Conformance" -- "$work/corpus.json"

cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/Harness.java"
java -cp "$cp:$work/classes" Harness "$work/corpus.json"
