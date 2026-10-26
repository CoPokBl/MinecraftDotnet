using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns render.json into the per state flags the client's block model lighter reads. Vanilla's
/// <c>getShadeBrightness</c> answers one of two values for every state, so it packs into a bit; a
/// version that grows a third fails here rather than rounding to one of them.
/// </summary>
public static class BlockRenderCodeGen {
    public static void GenerateBlockRenderCode(JObject _) {
        JObject render = JObject.Parse(CodeGenUtils.ReadDumpFile("render.json"));
        bool[] solidRender = render["solidRender"]!.ToObject<bool[]>()!;
        bool[] lightPermeable = render["lightPermeable"]!.ToObject<bool[]>()!;
        bool[] collisionFull = render["collisionShapeFullBlock"]!.ToObject<bool[]>()!;
        float[] shadeBrightness = render["shadeBrightness"]!.ToObject<float[]>()!;
        bool[] emissive = render["emissiveRendering"]!.ToObject<bool[]>()!;
        int[] faceFull = render["faceOcclusionFull"]!.ToObject<int[]>()!;
        int[] faceEmpty = render["faceOcclusionEmpty"]!.ToObject<int[]>()!;

        int stateCount = solidRender.Length;
        if (lightPermeable.Length != stateCount || collisionFull.Length != stateCount || shadeBrightness.Length != stateCount || emissive.Length != stateCount
            || faceFull.Length != stateCount || faceEmpty.Length != stateCount) {
            throw new InvalidOperationException("render.json's arrays disagree about how many states there are");
        }

        byte[] flags = new byte[stateCount];
        for (int state = 0; state < stateCount; state++) {
            int value = 0;
            if (solidRender[state]) value |= 1;
            if (lightPermeable[state]) value |= 2;
            if (collisionFull[state]) value |= 4;
            if (emissive[state]) value |= 8;
            if (shadeBrightness[state] == 0.2F) {
                value |= 16;
            }
            else if (shadeBrightness[state] != 1.0F) {
                throw new InvalidOperationException($"State {state} has a shade brightness of {shadeBrightness[state]}, which BlockRenderTable cannot hold");
            }
            flags[state] = (byte)value;
        }

        string file = Template
            .Replace("{stateCount}", stateCount.ToString())
            .Replace("{flags}", Convert.ToBase64String(flags))
            .Replace("{faceFull}", Convert.ToBase64String(faceFull.Select(mask => (byte)mask).ToArray()))
            .Replace("{faceEmpty}", Convert.ToBase64String(faceEmpty.Select(mask => (byte)mask).ToArray()));
        File.WriteAllText("BlockRenderTable.cs", file);
        Console.WriteLine($"  {stateCount} states");
    }

    private const string Template =
        """
        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.

        /// <summary>
        /// What the client's block model lighter reads off a block state, indexed by state id. The ones
        /// vanilla asks with a level are answered for an empty one at the origin, which is what its per
        /// state cache holds for every block without a dynamic shape.
        /// </summary>
        public static class BlockRenderTable {
            public const int StateCount = {stateCount};

            /// <summary><c>BlockState.isSolidRender</c>: the occlusion shape is the whole cube.</summary>
            public const byte SolidRender = 1;

            /// <summary><c>BlockState.isLightPermeable</c>: not solid render, or it dampens no light.</summary>
            public const byte LightPermeable = 2;

            /// <summary><c>BlockState.isCollisionShapeFullBlock</c>.</summary>
            public const byte CollisionShapeFullBlock = 4;

            /// <summary><c>BlockState.emissiveRendering</c>: drawn at full brightness whatever the light around it.</summary>
            public const byte EmissiveRendering = 8;

            /// <summary><c>BlockState.getShadeBrightness</c> is 0.2 rather than 1.</summary>
            public const byte DarkShade = 16;

            /// <summary>The flags of a state id, or none if it isn't one.</summary>
            public static byte FlagsOf(uint stateId) {
                return stateId < StateCount ? StateFlags[stateId] : (byte)0;
            }

            /// <summary><c>BlockState.getShadeBrightness</c>.</summary>
            public static float ShadeBrightnessOf(uint stateId) {
                return (FlagsOf(stateId) & DarkShade) != 0 ? 0.2F : 1.0F;
            }

            /// <summary>
            /// Bit per <c>Direction</c> ordinal where <c>getFaceOcclusionShape</c> is the <c>Shapes.block()</c>
            /// singleton. A face covered by a shape with more than one cell across it is not.
            /// </summary>
            public static byte FullFacesOf(uint stateId) {
                return stateId < StateCount ? StateFaceFull[stateId] : (byte)0;
            }

            /// <summary>Bit per <c>Direction</c> ordinal where <c>getFaceOcclusionShape</c> is empty.</summary>
            public static byte EmptyFacesOf(uint stateId) {
                return stateId < StateCount ? StateFaceEmpty[stateId] : (byte)0x3F;
            }

            public static readonly byte[] StateFlags =
                Convert.FromBase64String(
                    "{flags}");

            public static readonly byte[] StateFaceFull =
                Convert.FromBase64String(
                    "{faceFull}");

            public static readonly byte[] StateFaceEmpty =
                Convert.FromBase64String(
                    "{faceEmpty}");
        }

        """;
}
