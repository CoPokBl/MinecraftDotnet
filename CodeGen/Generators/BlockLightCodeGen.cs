using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns light.json into the table the lighting engine indexes by block state id.
/// <para>
/// Vanilla decides whether light crosses a face with <c>Shapes.faceShapeOccludes</c> of the two
/// faces meeting at it, and how much it loses with <c>max(1, getLightDampening())</c>. Both come
/// straight out of the dump; all this does is pack them.
/// </para>
/// <para>
/// States are collapsed into classes: a class is a distinct combination of six face shapes and a
/// dampening, and there are under a hundred of them for thirty thousand states. That is what makes
/// the engine's per block byte enough to describe a block's whole light behaviour.
/// </para>
/// </summary>
public static class BlockLightCodeGen {
    private const int Faces = 6;

    /// <summary>
    /// The engine stores one class id per block in a byte array, so the table cannot outgrow one.
    /// Nothing is close (26.2 has 85), but a version that adds enough shapes to cross it has to
    /// widen that array rather than have the ids silently wrap.
    /// </summary>
    private const int MaxClasses = 256;

    public static void GenerateBlockLightCode(JObject _) {
        JObject light = JObject.Parse(CodeGenUtils.ReadDumpFile("light.json"));

        string[] faceShapes = light["faceShapes"]!.ToObject<string[]>()!;
        string[] faceOccludes = light["faceOccludes"]!.ToObject<string[]>()!;
        int[] stateFaces = light["stateFaces"]!.ToObject<int[]>()!;
        int[] stateDampening = light["stateDampening"]!.ToObject<int[]>()!;
        int[] stateEmission = light["stateEmission"]!.ToObject<int[]>()!;

        int stateCount = stateDampening.Length;
        if (stateFaces.Length != stateCount * Faces) {
            throw new InvalidOperationException("light.json has " + stateFaces.Length +
                                                " face ids for " + stateCount + " states");
        }

        // A row of the occlusion matrix is a ulong, one bit per face it could meet, which is the
        // tightest the engine can look one up in. 26.2 has 55 faces.
        if (faceShapes.Length > 64) {
            throw new InvalidOperationException("Too many distinct light occlusion faces: " + faceShapes.Length +
                                                ". BlockLightTable.FaceOccludes holds a row in a ulong.");
        }

        // "Occludes on its own" is the fast path the engine takes before it looks at the block it
        // is crossing into: a face that covers the square by itself does so whatever meets it.
        int emptyFace = Array.IndexOf(faceShapes, "[]");
        if (emptyFace < 0) {
            throw new InvalidOperationException("light.json has no empty face shape");
        }

        Dictionary<string, int> classIds = new();
        List<byte[]> classFaces = [];
        List<int> classDampening = [];
        byte[] stateClass = new byte[stateCount];
        byte[] stateEmissionBytes = new byte[stateCount];

        for (int stateId = 0; stateId < stateCount; stateId++) {
            byte[] faces = new byte[Faces];
            StringBuilder key = new();
            for (int face = 0; face < Faces; face++) {
                faces[face] = (byte)stateFaces[stateId * Faces + face];
                key.Append(faces[face]).Append(',');
            }
            key.Append(stateDampening[stateId]);

            if (!classIds.TryGetValue(key.ToString(), out int classId)) {
                classId = classFaces.Count;
                classIds[key.ToString()] = classId;
                classFaces.Add(faces);
                classDampening.Add(stateDampening[stateId]);
            }

            stateClass[stateId] = (byte)classId;
            stateEmissionBytes[stateId] = (byte)stateEmission[stateId];
        }

        // Anything the engine has no block for - an unloaded neighbour, a state id past the end of
        // the table - takes this one. Dampening 15 is what makes light neither enter nor leave it,
        // which is how vanilla treats a section it isn't storing light for.
        int voidClass = classFaces.Count;
        classFaces.Add(new byte[Faces]);
        for (int face = 0; face < Faces; face++) {
            classFaces[voidClass][face] = (byte)emptyFace;
        }
        classDampening.Add(15);

        if (classFaces.Count > MaxClasses) {
            throw new InvalidOperationException("Too many distinct light classes: " + classFaces.Count +
                                                ". CalculatedLightingProvider stores one per block in a byte.");
        }

        StringBuilder file = new();
        file.Append(Header
            .Replace("{stateCount}", stateCount.ToString())
            .Replace("{classCount}", classFaces.Count.ToString())
            .Replace("{faceCount}", faceShapes.Length.ToString())
            .Replace("{voidClass}", voidClass.ToString()));

        file.Append(Field("FaceOccludes", "ulong",
            faceOccludes.Select(row => "0x" + RowBits(row).ToString("x16") + "UL")));
        file.Append(Field("ClassFaceIds", "byte", classFaces.SelectMany(faces => faces).Select(id => id.ToString())));

        // Everything the search asks about a block, in the one read: it looks each of these up for
        // both sides of every boundary it tries to cross.
        file.Append(Field("ClassInfo", "ushort", classFaces.Select((faces, id) => {
            int attenuation = Math.Max(1, classDampening[id]);
            int notEmpty = Mask(faces, face => face != emptyFace);
            int occludesAlone = Mask(faces, face => faceOccludes[face][emptyFace] == '1');
            return (attenuation | (notEmpty << 4) | (occludesAlone << 10)).ToString();
        })));

        file.Append(Field("ClassDampens", "bool",
            classDampening.Select(dampening => dampening != 0 ? "true" : "false")));

        file.Append(Blob("StateClass", stateClass));
        file.Append(Blob("StateEmission", stateEmissionBytes));
        file.Append(Footer);

        File.WriteAllText("BlockLightTable.cs", file.ToString());
        Console.WriteLine($"  {stateCount} states, {classFaces.Count} light classes, " +
                          $"{faceShapes.Length} distinct faces");
    }

    /// <summary>One bit per face shape, set where <c>faceShapeOccludes</c> holds against it.</summary>
    private static ulong RowBits(string row) {
        ulong bits = 0;
        for (int i = 0; i < row.Length; i++) {
            if (row[i] == '1') {
                bits |= 1UL << i;
            }
        }
        return bits;
    }

    private static int Mask(byte[] faces, Func<byte, bool> predicate) {
        int mask = 0;
        for (int face = 0; face < Faces; face++) {
            if (predicate(faces[face])) {
                mask |= 1 << face;
            }
        }
        return mask;
    }

    private static string Field(string name, string type, IEnumerable<string> values) {
        return $"{CodeGenUtils.GetIndentation(1)}public static readonly {type}[] {name} = [\n" +
               $"{CodeGenUtils.GetIndentation(2)}{string.Join(", ", values)}\n" +
               $"{CodeGenUtils.GetIndentation(1)}];\n\n";
    }

    /// <summary>
    /// One byte per state is too many for an array initialiser the compiler would have to walk, so
    /// the two state indexed tables go out as base64 and come back at type load.
    /// </summary>
    private static string Blob(string name, byte[] values) {
        return $"{CodeGenUtils.GetIndentation(1)}public static readonly byte[] {name} =\n" +
               $"{CodeGenUtils.GetIndentation(2)}Convert.FromBase64String(\n" +
               $"{CodeGenUtils.GetIndentation(3)}\"{Convert.ToBase64String(values)}\");\n\n";
    }

    private const string Header =
        """
        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.

        /// <summary>
        /// Everything the light engine needs about a block state, indexed by state id.
        /// <para>
        /// States are grouped into classes by the only things light cares about: the shape of each
        /// of their six faces, and how much of a light level crossing into them costs. A class id
        /// is a byte, which is what lets the engine keep one per block.
        /// </para>
        /// <para>
        /// Faces are ordered east, west, up, down, south, north, and the masks below use that as
        /// their bit order. <see cref="FaceOccludes"/> is vanilla's <c>Shapes.faceShapeOccludes</c>
        /// for every pair of faces: light crosses the boundary between two blocks unless the bit
        /// for (leaving face, entering face) is set, which is not the same as either face covering
        /// the square on its own.
        /// </para>
        /// </summary>
        public static class BlockLightTable {
            public const int StateCount = {stateCount};
            public const int ClassCount = {classCount};
            public const int FaceCount = {faceCount};

            /// <summary>
            /// The class an unloaded or unknown block takes. Nothing enters it and nothing leaves,
            /// which is how vanilla treats a section it holds no light for.
            /// </summary>
            public const byte VoidClass = {voidClass};

            /// <summary>Faces per class in <see cref="ClassFaceIds"/>, which is also its stride.</summary>
            public const int FacesPerClass = 6;

            /// <summary>What a level loses crossing into the block, ie. max(1, dampening).</summary>
            public const int AttenuationMask = 0xF;

            /// <summary>Bit of the face that has an occlusion shape at all, by face index.</summary>
            public const int FaceNotEmptyShift = 4;

            /// <summary>Bit of the face that covers its square on its own, by face index.</summary>
            public const int OccludesAloneShift = 10;

            /// <summary>The class of a state id, or <see cref="VoidClass"/> if it isn't one.</summary>
            public static byte ClassOf(uint stateId) {
                return stateId < StateCount ? StateClass[stateId] : VoidClass;
            }

            /// <summary>The light a state gives off, or zero if it isn't a state.</summary>
            public static byte EmissionOf(uint stateId) {
                return stateId < StateCount ? StateEmission[stateId] : (byte)0;
            }


        """;

    private const string Footer = "}\n";
}
