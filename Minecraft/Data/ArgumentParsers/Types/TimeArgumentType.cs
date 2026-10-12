using System.Globalization;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

/// <summary>A duration in ticks, written with an optional <c>d</c>, <c>s</c> or <c>t</c> unit, as <c>TimeArgument</c> reads it.</summary>
public record TimeArgumentType(int Min = 0) : ArgumentParser<int>() {
    public override Identifier Identifier => "minecraft:time";

    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteInteger(Min);
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with { Min = reader.ReadInteger() };
    }

    public override int Parse(ref string str, MinecraftRegistry reg) {
        int space = str.IndexOf(' ');
        string token = space == -1 ? str : str[..space];
        str = space == -1 ? string.Empty : str[(space + 1)..];

        int multiplier = 1;
        if (token.EndsWith('d')) {
            multiplier = 24000;
            token = token[..^1];
        }
        else if (token.EndsWith('s')) {
            multiplier = 20;
            token = token[..^1];
        }
        else if (token.EndsWith('t')) {
            token = token[..^1];
        }

        int ticks = (int)Math.Round(float.Parse(token, CultureInfo.InvariantCulture) * multiplier);
        if (ticks < Min) {
            throw new ArgumentException($"Tick count must not be less than {Min}, found {ticks}");
        }
        return ticks;
    }

    public override string Format(int value) => $"{value}t";
}
