// System.IO is an implicit using, and its StringReader would otherwise make every parser's ambiguous.
global using StringReader = ClientLib.Brigadier.StringReader;
