namespace ClientLib;

/// <summary>
/// <c>StringSplitter</c>: measuring and line breaking against a font's advances. Text is drawn with its
/// section sign codes applied, so every measure here applies them too, except the <c>plain</c> ones,
/// which count a code's characters as glyphs as vanilla's do.
/// </summary>
/// <param name="widthProvider">A code point's advance in a style, the font's <c>getAdvance(bold)</c>.</param>
public sealed class StringSplitter(Func<int, RunStyle, float> widthProvider) {
    public static readonly RunStyle Empty = new(TextFlattener.DefaultRgb);

    private float Width(int codepoint, RunStyle style) => widthProvider(codepoint, style);

    public float StringWidth(string? str) {
        if (str == null) {
            return 0.0F;
        }
        float result = 0;
        StringDecomposer.IterateFormatted(str, 0, Empty, Empty, (_, style, codepoint) => {
            result += widthProvider(codepoint, style);
            return true;
        });
        return result;
    }

    public float StringWidth(IEnumerable<TextRun> text) {
        float result = 0;
        foreach (TextRun run in text) {
            RunStyle runStyle = run.Style;
            StringDecomposer.IterateFormatted(run.Text, 0, runStyle, runStyle, (_, style, codepoint) => {
                result += widthProvider(codepoint, style);
                return true;
            });
        }
        return result;
    }

    public int PlainIndexAtWidth(string str, int maxWidth, RunStyle style) {
        float remaining = maxWidth;
        int position = 0;
        StringDecomposer.Iterate(str, style, (pos, s, codepoint) => {
            remaining -= widthProvider(codepoint, s);
            if (remaining >= 0.0F) {
                position = pos + (codepoint > 0xFFFF ? 2 : 1);
                return true;
            }
            return false;
        });
        return position;
    }

    public string PlainHeadByWidth(string str, int maxWidth, RunStyle style) => str[..PlainIndexAtWidth(str, maxWidth, style)];

    public string PlainTailByWidth(string str, int maxWidth, RunStyle style) {
        float currentWidth = 0;
        int result = str.Length;
        StringDecomposer.IterateBackwards(str, style, (pos, s, codepoint) => {
            currentWidth += widthProvider(codepoint, s);
            if (currentWidth > maxWidth) {
                return false;
            }
            result = pos;
            return true;
        });
        return str[result..];
    }

    /// <summary>
    /// <c>splitLines(String, ...)</c>: each line as a range of the input and the style it starts in. A
    /// line broken at a space or newline ends before it, and takes it in only with <paramref name="includeAll"/>.
    /// </summary>
    public void SplitLines(string input, int maxWidth, RunStyle initialStyle, bool includeAll, Action<RunStyle, int, int> output) {
        int start = 0;
        int size = input.Length;
        RunStyle workStyle = initialStyle;
        while (start < size) {
            LineBreakFinder finder = new(this, maxWidth);
            bool endOfText = StringDecomposer.IterateFormatted(input, start, workStyle, initialStyle, finder.Accept);
            if (endOfText) {
                output(workStyle, start, size);
                break;
            }
            int lineBreak = finder.SplitPosition;
            char firstTailChar = input[lineBreak];
            int adjustedBreak = firstTailChar != '\n' && firstTailChar != ' ' ? lineBreak : lineBreak + 1;
            output(workStyle, start, includeAll ? adjustedBreak : lineBreak);
            start = adjustedBreak;
            workStyle = finder.SplitStyle;
        }
    }

    public List<List<TextRun>> SplitLines(IReadOnlyList<TextRun> input, int maxWidth) {
        List<List<TextRun>> result = [];
        SplitLines(input, maxWidth, (line, _) => result.Add(line));
        return result;
    }

    /// <summary>
    /// <c>splitLines(FormattedText, ...)</c>, telling the output whether each line follows a wrap rather
    /// than a newline. Text with nothing in it gives no lines.
    /// </summary>
    public void SplitLines(IReadOnlyList<TextRun> input, int maxWidth, Action<List<TextRun>, bool> output) {
        FlatComponents parts = new(input.Where(run => run.Text.Length > 0).ToList());
        bool shouldRestart = true;
        bool forceNewLine = false;
        bool isWrapped = false;
        while (shouldRestart) {
            shouldRestart = false;
            LineBreakFinder finder = new(this, maxWidth);
            foreach (TextRun part in parts.Parts) {
                RunStyle partStyle = part.Style;
                bool endOfText = StringDecomposer.IterateFormatted(part.Text, 0, partStyle, Empty, finder.Accept);
                if (!endOfText) {
                    int lineBreak = finder.SplitPosition;
                    RunStyle lineBreakStyle = finder.SplitStyle;
                    char firstTailChar = parts.CharAt(lineBreak);
                    bool isNewLine = firstTailChar == '\n';
                    bool skipNextChar = isNewLine || firstTailChar == ' ';
                    forceNewLine = isNewLine;
                    List<TextRun> result = parts.SplitAt(lineBreak, skipNextChar ? 1 : 0, lineBreakStyle);
                    output(result, isWrapped);
                    isWrapped = !isNewLine;
                    shouldRestart = true;
                    break;
                }
                finder.AddToOffset(part.Text.Length);
            }
        }
        List<TextRun>? lastLine = parts.GetRemainder();
        if (lastLine != null) {
            output(lastLine, isWrapped);
        }
        else if (forceNewLine) {
            output([], false);
        }
    }

    private sealed class FlatComponents(List<TextRun> parts) {
        public List<TextRun> Parts { get; } = parts;
        private string _flatParts = string.Concat(parts.Select(p => p.Text));

        public char CharAt(int position) => _flatParts[position];

        public List<TextRun> SplitAt(int skipPosition, int skipSize, RunStyle splitStyle) {
            List<TextRun> result = [];
            int position = skipPosition;
            bool inSkip = false;
            for (int i = 0; i < Parts.Count;) {
                TextRun element = Parts[i];
                string contents = element.Text;
                int contentsSize = contents.Length;
                if (!inSkip) {
                    if (position > contentsSize) {
                        result.Add(element);
                        Parts.RemoveAt(i);
                        position -= contentsSize;
                        continue;
                    }
                    string beforeSplit = contents[..position];
                    if (beforeSplit.Length > 0) {
                        result.Add(element with { Text = beforeSplit });
                    }
                    position += skipSize;
                    inSkip = true;
                }
                if (position <= contentsSize) {
                    string afterSplit = contents[position..];
                    if (afterSplit.Length == 0) {
                        Parts.RemoveAt(i);
                    }
                    else {
                        Parts[i] = TextRun.Of(afterSplit, splitStyle);
                    }
                    break;
                }
                Parts.RemoveAt(i);
                position -= contentsSize;
            }
            _flatParts = _flatParts[(skipPosition + skipSize)..];
            return result;
        }

        public List<TextRun>? GetRemainder() {
            if (Parts.Count == 0) {
                return null;
            }
            List<TextRun> result = [..Parts];
            Parts.Clear();
            return result;
        }
    }

    private sealed class LineBreakFinder(StringSplitter splitter, float maxWidth) {
        private readonly float _maxWidth = Math.Max(maxWidth, 1.0F);
        private int _lineBreak = -1;
        private RunStyle _lineBreakStyle = Empty;
        private bool _hadNonZeroWidthChar;
        private float _width;
        private int _lastSpace = -1;
        private RunStyle _lastSpaceStyle = Empty;
        private int _nextChar;
        private int _offset;

        public bool Accept(int position, RunStyle style, int codepoint) {
            int adjustedPosition = position + _offset;
            switch (codepoint) {
                case '\n':
                    return FinishIteration(adjustedPosition, style);
                case ' ':
                    _lastSpace = adjustedPosition;
                    _lastSpaceStyle = style;
                    break;
            }
            float charWidth = splitter.Width(codepoint, style);
            _width += charWidth;
            if (!_hadNonZeroWidthChar || !(_width > _maxWidth)) {
                _hadNonZeroWidthChar |= charWidth != 0.0F;
                _nextChar = adjustedPosition + (codepoint > 0xFFFF ? 2 : 1);
                return true;
            }
            return _lastSpace != -1 ? FinishIteration(_lastSpace, _lastSpaceStyle) : FinishIteration(adjustedPosition, style);
        }

        private bool FinishIteration(int lineBreak, RunStyle style) {
            _lineBreak = lineBreak;
            _lineBreakStyle = style;
            return false;
        }

        public int SplitPosition => _lineBreak != -1 ? _lineBreak : _nextChar;

        public RunStyle SplitStyle => _lineBreakStyle;

        public void AddToOffset(int delta) => _offset += delta;
    }
}
