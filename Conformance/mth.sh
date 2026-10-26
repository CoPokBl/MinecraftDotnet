#!/usr/bin/env bash
# Prints what vanilla's Mth and LegacyRandomSource answer, for the fixtures in
# Minecraft.Testing/Schemas/MthTest.cs and RandomSourceTest.cs.
#
#   Conformance/mth.sh [version]
#
# This one really does drive vanilla, unlike travel.sh beside it: Mth is static and
# LegacyRandomSource takes nothing but a seed. It prints the arrays rather than writing a fixture;
# paste them into the tests.
#
# Only needed on a version bump, or when either port changes. Needs the server jar the CodeGen
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
javac -nowarn -cp "$cp" -d "$work/classes" "$repo/Conformance/MthHarness.java"
java -cp "$cp:$work/classes" MthHarness
