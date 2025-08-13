using Minecraft.Data.ArgumentParsers;

namespace ManagedServer.Commands.Arguments;

public class Argument<T>(string name, IArgumentParser<T> parser) : IArgument {
    public string Name { get; } = name;
    public IArgumentParser Parser { get; } = parser;
    
    public IArgumentParser<T> TypedParser => (IArgumentParser<T>)Parser;
}

public interface IArgument {
    public string Name { get; }
    public IArgumentParser Parser { get; }
}
