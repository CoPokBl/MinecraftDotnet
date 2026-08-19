#!/usr/bin/env bash
# The decoration parity number: how much of what this build's feature and structure passes write is
# what vanilla's would have written, given the same world in front of both.
#
#   rm -rf /tmp/parity && FEATURE_PARITY_DUMP=/tmp/parity \
#       dotnet test ManagedServer.Testing/ManagedServer.Testing.csproj \
#       --filter "FullyQualifiedName~WorldParityConformanceTest"
#   Conformance/decorationparity.sh /tmp/parity
#
# This is the number to optimise against. WorldParityConformanceTest compares against a world vanilla
# generated on its own, which carries the order its chunks were made in: a chunk decorates through its
# neighbours, so what one forked in before a chunk started sits in front of that chunk's own features
# and what it forks in later sits on top. Varying only that order moves its count by about a third,
# which is more than most fixes are worth, so a change of that size cannot be read there at all.
#
# Here both sides start from the same bytes, so the order drops out and what is left is the port.
#
# PARITY_STRUCTURES=1 on the dumping run turns the structure pass on, which is what makes the
# structure half of the number mean anything: the dump then records which starts reached each chunk
# and the harness lays the same ones out with vanilla and places them, in the interleaved loop
# vanilla runs the two passes in. Without it every chunk simply has no structures on either side.
# DecorationParityScatterTest's own sample runs without them by default, since a structure is about
# one chunk in a hundred and the dump costs the layout either way.
set -euo pipefail

if [[ $# -lt 1 ]]; then
    echo "usage: decorationparity.sh <dump directory>" >&2
    exit 2
fi

version="${VERSION:-26.2}"
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
javac -nowarn -cp "$cp" -d "$work/decorationparity-classes" "$repo"/Conformance/*.java

java -cp "$cp:$work/decorationparity-classes" DecorationParityHarness "$1" 2>/dev/null \
    | sed 's/.*\[STDOUT\]: //'
