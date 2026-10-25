#!/usr/bin/env bash
# Secure chat against the jar: what our client signs and acknowledges, checked as the vanilla server checks it.
#
#   Conformance/chatsigning.sh [version]           checks a fresh corpus from ChatSigningSamples.cs
#   Conformance/chatsigning.sh [version] fixture   prints vanilla signed messages for IncomingChatTest.cs
#
# Needs the server jar the CodeGen project downloads, so run CodeGen for the version first.
set -euo pipefail

version="${1:-26.2}"
mode="${2:-verify}"
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
javac -nowarn -cp "$cp" -d "$work/chat-classes" "$repo/Conformance/ChatSigningHarness.java"
if [[ "$mode" == "fixture" ]]; then
    java -cp "$cp:$work/chat-classes" ChatSigningHarness fixture
else
    dotnet run --project "$repo/Conformance" -- "$work/packets.json" --chat-signing "$work/chat-signing.json"
    java -cp "$cp:$work/chat-classes" ChatSigningHarness verify "$work/chat-signing.json"
fi
