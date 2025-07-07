namespace Minecraft.Schemas.Shapes;

public interface ICollisionBox {

    // looks like: [AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0]]
    public static ICollisionBox ParseAabbArrayString(string str) {
        // get rid of the brackets
        str = str.Trim();
        if (!str.StartsWith("[") || !str.EndsWith("]")) {
            throw new FormatException($"Invalid AABB array format: {str}");
        }
        str = str[1..^1]; // Remove "[" from start and "]" from end
        // split by comma, but not inside AABB[]
        string[] parts = str.Split(new[] { "], " }, StringSplitOptions.RemoveEmptyEntries);
        // parse each part with Aabb.FromString
        ICollisionBox[] boxes = new ICollisionBox[parts.Length];
        
        for (int i = 0; i < parts.Length; i++) {
            boxes[i] = Aabb.FromString($"{parts[i]}]".Trim());
        }
        if (boxes.Length == 1) {
            return boxes[0]; // If there's only one box, return it directly
        }
        return new CompositeBox(boxes); // If there are multiple boxes, return a CompositeBox
    }
}