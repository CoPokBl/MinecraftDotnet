#!/usr/bin/env bash
# The order the real java.util.HashSet iterates a set of block positions in, into the fixture
# JavaHashSetConformanceTest replays.
#
#   Conformance/hashset.sh
#
# Only needed when the fixture is being regenerated. The test itself just reads the committed file.
#
# This is the one harness here that does not need the server jar, and takes no version: the order is
# java.util.HashMap's and nothing about it is Minecraft's, so the JDK is the whole of the authority.
# What is Minecraft's is that the order matters at all. A tree's logs and leaves and a vegetation
# patch's surface columns are collected into a HashSet and then looped over with a fixed number of
# draws per entry, so the set decides which block each draw lands on while the draw count is identical
# either way. Nothing but the blocks can see it.
#
# What makes it worth a fixture rather than a reading of the algorithm is the treeified bucket. A
# bucket of nine becomes a red-black tree whose root is then moved to the front of the chain the
# iterator walks, so the order stops being a function of the size and the insertion order alone. A
# vegetation patch reaches nine within a hundred chunks.
set -euo pipefail

repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
work="${TMPDIR:-/tmp}/mcdotnet-conformance"
fixture="$repo/Minecraft.Testing/Schemas/vanilla-hashset.txt.gz"

mkdir -p "$work"

javac -nowarn -d "$work/hashset-classes" "$repo/Conformance/HashSetHarness.java"
java -cp "$work/hashset-classes" HashSetHarness "$fixture"
