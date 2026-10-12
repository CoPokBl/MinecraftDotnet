#!/usr/bin/env bash
# Prints the hashes vanilla's client sends for a few data component values, for the fixtures in
# ClientLib.Testing/Inventory/ComponentHasherTest.cs.
#
#   Conformance/componenthash.sh [version]
#
# Only needed on a version bump, or when the hasher changes. Needs the server jar the CodeGen
# project downloads, so run CodeGen for the version first.
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
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/ComponentHashHarness.java"
java -cp "$cp:$work/classes" ComponentHashHarness
