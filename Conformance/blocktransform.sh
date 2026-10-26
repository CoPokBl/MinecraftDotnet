#!/usr/bin/env bash
# Runs vanilla's BlockState.rotate and BlockState.mirror over every block state in the game and
# writes the answers into the fixture BlockTransformConformanceTest replays.
#
#   Conformance/blocktransform.sh [version]
#
# Only needed when the fixture is being regenerated, ie. on a version bump. The test itself just
# reads the committed file. Needs the server jar the CodeGen project downloads, so run CodeGen for
# the version first.
#
# This is what holds up BlockStateTransform, which is written per block property where vanilla writes
# one override per block class. Without it a block class whose rule that side does not implement is
# silently left unturned, and a structure placed facing the wrong way is the symptom, several
# thousand blocks later.
set -euo pipefail

version="${1:-26.3}"
repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
jars="$repo/CodeGen/bin/Debug/net10.0"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/ManagedServer.Testing/Terrain/vanilla-blocktransform.bin.gz"

server_jar="$jars/versions/$version/server-$version.jar"
if [[ ! -f "$server_jar" ]]; then
    echo "No server jar at $server_jar" >&2
    echo "Run 'cd CodeGen/bin/Debug/net10.0 && ./CodeGen $version' first." >&2
    exit 2
fi

mkdir -p "$work" "$(dirname "$fixture")"
cp="$server_jar:$(find "$jars/libraries" -name '*.jar' | tr '\n' ':')"
javac -nowarn -cp "$cp" -d "$work/blocktransform-classes" "$repo/Conformance/BlockTransformHarness.java"
java -cp "$cp:$work/blocktransform-classes" BlockTransformHarness "$fixture"
