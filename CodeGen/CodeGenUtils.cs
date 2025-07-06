using System.Reflection;
using System.Text;

namespace CodeGen;

public static class CodeGenUtils {
    private const string IdentSearch = "Identifier Identifier => \"";

    public static string NamespacedIdToPascalName(string namespacedId) {
        if (namespacedId.Contains(':')) {
            namespacedId = namespacedId.Split(':')[1];
        }

        return string.Join("", namespacedId.Split('_').Select(CapitaliseFirstLetter));
    }
    
    public static string CapitaliseFirstLetter(string input) {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input[1..];
    }

    public static string ReadEmbeddedFile(string fileName) {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream($"CodeGen.Data.{fileName}")!;
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
    
    public static string GetIndentation(int level) {
        return new string(' ', level * 4);
    }

    public static string? GetIdentifier(string fileContent) {
        int indexOfIdentifier = fileContent.IndexOf(IdentSearch, StringComparison.Ordinal);
        if (indexOfIdentifier == -1) {
            return null; // Identifier not found
        }
        StringBuilder identifierBuilder = new();

        int i = indexOfIdentifier + IdentSearch.Length;
        while (true) {
            if (fileContent[i] == '"') {
                break;
            }
            identifierBuilder.Append(fileContent[i]);
            i++;
        }
                
        return identifierBuilder.ToString();
    }
}
