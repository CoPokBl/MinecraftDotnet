#!/usr/bin/env bash
# Checks a running Minecraft Dotnet server's configuration phase against the vanilla
# server jar's own codecs. See README.md.
set -euo pipefail

HOST="${1:-127.0.0.1}"
PORT="${2:-25565}"
VERSION="${MC_VERSION:-26.2}"

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DATA_DIR="${MC_DATA_DIR:-$HERE/../CodeGen/bin/Debug/net10.0}"

SERVER_JAR="$DATA_DIR/versions/$VERSION/server-$VERSION.jar"
VANILLA_DATA="$DATA_DIR/vanilladata$VERSION"

if [[ ! -f "$SERVER_JAR" ]]; then
    echo "Could not find $SERVER_JAR" >&2
    echo "Run the code generator for $VERSION first, it unpacks the jar and the reports." >&2
    exit 2
fi

CP="$SERVER_JAR:$(find "$DATA_DIR/libraries" -name '*.jar' | tr '\n' ':')"
OUT="$HERE/build"

mkdir -p "$OUT"
javac -nowarn -cp "$CP" -d "$OUT" "$HERE/ConformanceCheck.java"
exec java -cp "$CP:$OUT" ConformanceCheck "$HOST" "$PORT" "$VANILLA_DATA"
