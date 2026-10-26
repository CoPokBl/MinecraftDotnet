using System.Text;

namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>CommandDispatcher</c> without <c>execute</c>: the server runs every command.</summary>
public sealed class CommandDispatcher<TSource> {
    public const string ArgumentSeparator = " ";
    public const char ArgumentSeparatorChar = ' ';
    private const string UsageOptionalOpen = "[";
    private const string UsageOptionalClose = "]";
    private const string UsageRequiredOpen = "(";
    private const string UsageRequiredClose = ")";
    private const string UsageOr = "|";

    public CommandDispatcher(RootCommandNode<TSource> root) {
        Root = root;
    }

    public CommandDispatcher() : this(new RootCommandNode<TSource>()) {
    }

    public RootCommandNode<TSource> Root { get; }

    public ParseResults<TSource> Parse(string command, TSource source) => Parse(new StringReader(command), source);

    public ParseResults<TSource> Parse(StringReader command, TSource source) {
        CommandContextBuilder<TSource> context = new(this, source, Root, command.Cursor);
        return ParseNodes(Root, command, context);
    }

    private ParseResults<TSource> ParseNodes(CommandNode<TSource> node, StringReader originalReader, CommandContextBuilder<TSource> contextSoFar) {
        TSource source = contextSoFar.Source;
        OrderedDictionary<CommandNode<TSource>, CommandSyntaxException>? errors = null;
        List<ParseResults<TSource>>? potentials = null;
        int cursor = originalReader.Cursor;

        foreach (CommandNode<TSource> child in node.GetRelevantNodes(originalReader)) {
            if (!child.CanUse(source)) {
                continue;
            }
            CommandContextBuilder<TSource> context = contextSoFar.Copy();
            StringReader reader = new(originalReader);
            try {
                try {
                    child.Parse(reader, context);
                }
                catch (CommandSyntaxException) {
                    throw;
                }
                catch (Exception e) {
                    throw CommandSyntaxException.BuiltInExceptions.DispatcherParseException.CreateWithContext(reader, e.Message);
                }
                if (reader.CanRead() && reader.Peek() != ArgumentSeparatorChar) {
                    throw CommandSyntaxException.BuiltInExceptions.DispatcherExpectedArgumentSeparator.CreateWithContext(reader);
                }
            }
            catch (CommandSyntaxException ex) {
                errors ??= new OrderedDictionary<CommandNode<TSource>, CommandSyntaxException>();
                errors[child] = ex;
                reader.Cursor = cursor;
                continue;
            }

            context.WithCommand(child.Command);
            if (reader.CanRead(child.Redirect == null ? 2 : 1)) {
                reader.Skip();
                if (child.Redirect != null) {
                    CommandContextBuilder<TSource> childContext = new(this, source, child.Redirect, reader.Cursor);
                    ParseResults<TSource> redirected = ParseNodes(child.Redirect, reader, childContext);
                    context.WithChild(redirected.Context);
                    return new ParseResults<TSource>(context, redirected.Reader, redirected.Exceptions);
                }
                ParseResults<TSource> parse = ParseNodes(child, reader, context);
                potentials ??= new List<ParseResults<TSource>>(1);
                potentials.Add(parse);
            }
            else {
                potentials ??= new List<ParseResults<TSource>>(1);
                potentials.Add(new ParseResults<TSource>(context, reader, new OrderedDictionary<CommandNode<TSource>, CommandSyntaxException>()));
            }
        }

        if (potentials != null) {
            if (potentials.Count > 1) {
                // List.Sort is not stable and Java's is; the first of equal potentials has to win.
                potentials = potentials.OrderBy(p => p, Comparer<ParseResults<TSource>>.Create(ComparePotentials)).ToList();
            }
            return potentials[0];
        }
        return new ParseResults<TSource>(contextSoFar, originalReader,
            errors ?? new OrderedDictionary<CommandNode<TSource>, CommandSyntaxException>());
    }

    private static int ComparePotentials(ParseResults<TSource> a, ParseResults<TSource> b) {
        if (!a.Reader.CanRead() && b.Reader.CanRead()) {
            return -1;
        }
        if (a.Reader.CanRead() && !b.Reader.CanRead()) {
            return 1;
        }
        if (a.Exceptions.Count == 0 && b.Exceptions.Count > 0) {
            return -1;
        }
        return a.Exceptions.Count > 0 && b.Exceptions.Count == 0 ? 1 : 0;
    }

    /// <returns>Insertion ordered, one entry per usable child.</returns>
    public OrderedDictionary<CommandNode<TSource>, string> GetSmartUsage(CommandNode<TSource> node, TSource source) {
        OrderedDictionary<CommandNode<TSource>, string> result = new();
        bool optional = node.Command != null;
        foreach (CommandNode<TSource> child in node.Children) {
            string? usage = GetSmartUsage(child, source, optional, false);
            if (usage != null) {
                result[child] = usage;
            }
        }
        return result;
    }

    private string? GetSmartUsage(CommandNode<TSource> node, TSource source, bool optional, bool deep) {
        if (!node.CanUse(source)) {
            return null;
        }
        string self = optional ? UsageOptionalOpen + node.UsageText + UsageOptionalClose : node.UsageText;
        bool childOptional = node.Command != null;
        string open = childOptional ? UsageOptionalOpen : UsageRequiredOpen;
        string close = childOptional ? UsageOptionalClose : UsageRequiredClose;
        if (deep) {
            return self;
        }
        if (node.Redirect != null) {
            string redirect = node.Redirect == Root ? "..." : "-> " + node.Redirect.UsageText;
            return self + ArgumentSeparator + redirect;
        }

        List<CommandNode<TSource>> children = node.Children.Where(c => c.CanUse(source)).ToList();
        if (children.Count == 1) {
            string? usage = GetSmartUsage(children[0], source, childOptional, childOptional);
            if (usage != null) {
                return self + ArgumentSeparator + usage;
            }
        }
        else if (children.Count > 1) {
            // A LinkedHashSet: the first occurrence keeps its place.
            List<string> childUsage = [];
            foreach (CommandNode<TSource> child in children) {
                string? usage = GetSmartUsage(child, source, childOptional, true);
                if (usage != null && !childUsage.Contains(usage)) {
                    childUsage.Add(usage);
                }
            }
            if (childUsage.Count == 1) {
                string usage = childUsage[0];
                return self + ArgumentSeparator + (childOptional ? UsageOptionalOpen + usage + UsageOptionalClose : usage);
            }
            if (childUsage.Count > 1) {
                StringBuilder builder = new(open);
                int count = 0;
                foreach (CommandNode<TSource> child in children) {
                    if (count > 0) {
                        builder.Append(UsageOr);
                    }
                    builder.Append(child.UsageText);
                    count++;
                }
                if (count > 0) {
                    builder.Append(close);
                    return self + ArgumentSeparator + builder;
                }
            }
        }
        return self;
    }

    public Task<Suggestions> GetCompletionSuggestions(ParseResults<TSource> parse) => GetCompletionSuggestions(parse, parse.Reader.TotalLength);

    /// <summary>As in brigadier, one cancelled node future (a newer server request cancels an older one) leaves the merged one pending for ever.</summary>
    public Task<Suggestions> GetCompletionSuggestions(ParseResults<TSource> parse, int cursor) {
        CommandContextBuilder<TSource> context = parse.Context;
        SuggestionContext<TSource> nodeBeforeCursor = context.FindSuggestionContext(cursor);
        CommandNode<TSource> parent = nodeBeforeCursor.Parent;
        int start = Math.Min(nodeBeforeCursor.StartPos, cursor);
        string fullInput = parse.Reader.String;
        string truncatedInput = fullInput[..cursor];
        string truncatedInputLowerCase = JavaText.ToLowerRoot(truncatedInput);
        Task<Suggestions>[] futures = new Task<Suggestions>[parent.Children.Count];
        int i = 0;
        foreach (CommandNode<TSource> node in parent.Children) {
            Task<Suggestions> future = Suggestions.Empty();
            try {
                future = node.ListSuggestions(context.Build(truncatedInput), new SuggestionsBuilder(truncatedInput, truncatedInputLowerCase, start));
            }
            catch (CommandSyntaxException) {
            }
            futures[i++] = future;
        }

        TaskCompletionSource<Suggestions> result = new();
        Task.WhenAll(futures).ContinueWith(_ => {
            List<Suggestions> suggestions = [];
            foreach (Task<Suggestions> future in futures) {
                suggestions.Add(future.Result);
            }
            result.SetResult(Suggestions.Merge(fullInput, suggestions));
        }, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
        return result.Task;
    }
}
