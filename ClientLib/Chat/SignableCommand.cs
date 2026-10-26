using ClientLib.Brigadier;

namespace ClientLib.Chat;

/// <summary><c>SignedArgument</c>: an argument type whose text a player signs as a chat message.</summary>
public interface ISignedArgument;

/// <summary><c>SignableCommand</c>: a parse's signed arguments, each with the text it was parsed from.</summary>
public sealed record SignableCommand<TSource>(IReadOnlyList<(string Name, string Value)> Arguments) {
    public static bool HasSignableArguments(ParseResults<TSource> command) => Of(command).Arguments.Count > 0;

    public static SignableCommand<TSource> Of(ParseResults<TSource> command) {
        string commandString = command.Reader.String;
        List<(string, string)> arguments = [];
        VisitArguments(command, (argument, value) => {
            if (value != null && argument.Type is ISignedArgument) {
                arguments.Add((argument.Name, commandString[value.Range.Start..value.Range.End]));
            }
        });
        return new SignableCommand<TSource>(arguments);
    }

    /// <summary><c>ArgumentVisitor.visitArguments</c> with <c>rejectRootRedirects</c>, as <c>of</c> calls it.</summary>
    private static void VisitArguments(ParseResults<TSource> command, Action<ArgumentCommandNode<TSource>, ParsedArgument<TSource>?> output) {
        CommandContextBuilder<TSource> rootContext = command.Context;
        CommandContextBuilder<TSource> context = rootContext;
        VisitNodeArguments(rootContext, output);
        while (context.Child is { } child && child.RootNode != rootContext.RootNode) {
            VisitNodeArguments(child, output);
            context = child;
        }
    }

    private static void VisitNodeArguments(CommandContextBuilder<TSource> context, Action<ArgumentCommandNode<TSource>, ParsedArgument<TSource>?> output) {
        foreach (ParsedCommandNode<TSource> node in context.Nodes) {
            if (node.Node is ArgumentCommandNode<TSource> argument) {
                output(argument, context.Arguments.GetValueOrDefault(argument.Name));
            }
        }
    }
}

/// <summary><c>ArgumentSignatures.signCommand</c>: an argument the signer gives no signature for is left out.</summary>
public static class ArgumentSignatures {
    public static (string Name, MessageSignature Signature)[] SignCommand<TSource>(SignableCommand<TSource> command, Func<string, MessageSignature?> signer) =>
        command.Arguments.Select(argument => (argument.Name, Signature: signer(argument.Value)))
            .Where(entry => entry.Signature != null).Select(entry => (entry.Name, entry.Signature!)).ToArray();
}
