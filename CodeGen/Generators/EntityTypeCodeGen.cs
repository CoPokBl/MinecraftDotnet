using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class EntityTypeCodeGen {
    /// <summary>
    /// The two classes whose gravity or air drag isn't a plain constant, and what a per type value
    /// works out to for them. A class that isn't listed here throws instead of being guessed at, so
    /// one turning into a computed value upstream can't quietly become a wrong number.
    /// </summary>
    private static readonly Dictionary<(string Class, string Method), double> Computed = new() {
        // Reads the minecraft:gravity attribute, whose base value is this for every living entity.
        { ("net.minecraft.world.entity.LivingEntity", "getDefaultGravity"), 0.08 },
        // Picks 0.91 or 0.98 on omnidirectionalAirMover(), which is per entity rather than per type.
        { ("net.minecraft.world.entity.LivingEntity", "getAirDrag"), 0.98 },
        // 0.005 while the minecart is in water, and this otherwise.
        { ("net.minecraft.world.entity.vehicle.minecart.AbstractMinecart", "getDefaultGravity"), 0.04 }
    };

    public static string CreateEntityTypeEntries(JObject registriesJson) {
        JObject entityDataJson = JObject.Parse(CodeGenUtils.ReadDumpFile("entity_type.json"));
        JObject attributeDataJson = JObject.Parse(CodeGenUtils.ReadDumpFile("attribute.json"));
        using JavaClassConstants classes = new(CodeGenUtils.ServerJarPath);

        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:entity_type",
            "SimpleEntityType",
            "EntityType",
            "EntityTypes",
            "Entities;\nusing Minecraft.Data.Attributes",
            extraSimpleParams: key => {
                JObject entry = entityDataJson[key]!.ToObject<JObject>()!;
                bool fireImmune = entry["fireImmune"]!.ToObject<bool>();
                double width = entry["width"]!.ToObject<double>();
                double height = entry["height"]!.ToObject<double>();
                double eyeHeight = entry["eyeHeight"]!.ToObject<double>();
                int clientTrackingRange = entry["clientTrackingRange"]!.ToObject<int>();

                string entityClass = entry["entityClass"]!.ToObject<string>()!;
                double acceleration = Read(classes, key, entityClass, "getDefaultGravity", "()D");
                double airDrag = Read(classes, key, entityClass, "getAirDrag", "()F");

                // Air drag is a float in vanilla and gets multiplied as one, so it is written back
                // as the float it came from rather than as the widened double.
                return $"{fireImmune.ToString().ToLower()}, {width}, {height}, {eyeHeight}, " +
                       $"{acceleration}, {(float)airDrag:R}f, {clientTrackingRange}, " +
                       $"{Attachments(entry["attachments"]!.ToObject<JObject>()!)}, " +
                       $"{DefaultAttributes(entry["attributes"], attributeDataJson)}";
            });
    }

    private static string Attachments(JObject attachments) {
        // The four are always present, and their order is the record's.
        string[] points = ["passenger", "vehicle", "name_tag", "warden_chest"];
        return "new(" + string.Join(", ", points.Select(name => {
            JArray attached = attachments[name]!.ToObject<JArray>()!;
            return "[" + string.Join(", ", attached.Select(point => {
                double[] xyz = point.ToObject<double[]>()!;
                return $"new({xyz[0]}, {xyz[1]}, {xyz[2]})";
            })) + "]";
        })) + ")";
    }

    /// <summary>
    /// The attribute base values an entity starts on. Only the ones it disagrees with the attribute's
    /// own default about are written out: the rest resolve to the same number either way, and every
    /// living entity carries all 26 of them.
    /// </summary>
    private static string DefaultAttributes(JToken? attributes, JObject attributeData) {
        if (attributes is null) {
            return "SimpleEntityType.NoAttributes";
        }

        List<string> entries = [];
        foreach ((string key, JToken? value) in attributes.ToObject<JObject>()!) {
            double baseValue = value!.ToObject<double>();
            if (baseValue == attributeData[key]!["defaultValue"]!.ToObject<double>()) {
                continue;
            }

            entries.Add($"{{ Attribute.{CodeGenUtils.NamespacedIdToPascalName(key)}, {baseValue} }}");
        }

        return entries.Count == 0
            ? "SimpleEntityType.NoAttributes"
            : "new Dictionary<IAttribute, double> { " + string.Join(", ", entries) + " }";
    }

    /// <summary>
    /// Gravity and air drag are constants returned by <c>Entity.getDefaultGravity()</c> and
    /// <c>Entity.getAirDrag()</c> overrides on the entity class, so they get read out of the class
    /// file rather than off anything <c>EntityType</c> exposes. <see cref="Computed"/> covers the
    /// two that aren't constants.
    /// </summary>
    private static double Read(JavaClassConstants classes, string key, string entityClass,
        string method, string descriptor) {
        JavaClassConstants.Result result = classes.FindConstant(entityClass, method, descriptor);
        switch (result.Kind) {
            case JavaClassConstants.Lookup.Constant:
                return result.Value;

            case JavaClassConstants.Lookup.NotConstant
                when Computed.TryGetValue((result.DeclaringClass!, method), out double computed):
                return computed;

            case JavaClassConstants.Lookup.NotConstant:
                throw new InvalidOperationException(
                    $"{key}: {result.DeclaringClass}.{method} is no longer a constant, so its value " +
                    $"has to be worked out by hand and added to {nameof(Computed)}");

            default:
                throw new InvalidOperationException($"{key}: nothing above {entityClass} declares {method}");
        }
    }
}
