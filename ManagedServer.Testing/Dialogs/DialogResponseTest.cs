using ManagedServer.Dialogs;
using NBT;
using NBT.Tags;

namespace ManagedServer.Testing.Dialogs;

/// <summary>
/// The client sends every input as a string, whatever control collected it, so all of these go
/// through parsing rather than reading a typed tag.
/// </summary>
public class DialogResponseTest {

    [Test]
    public void ReadsTheValuesBack() {
        DialogResponse response = Response(("name", "bob"), ("age", "37.0"), ("ratio", "0.5"));

        Assert.That(response.GetString("name"), Is.EqualTo("bob"));
        Assert.That(response["name"], Is.EqualTo("bob"));
        Assert.That(response.GetInt("age"), Is.EqualTo(37));
        Assert.That(response.GetFloat("ratio"), Is.EqualTo(0.5f));
        Assert.That(response.Contains("name"), Is.True);
    }

    [Test]
    public void MissingValuesFallBack() {
        DialogResponse response = Response(("name", "bob"));

        Assert.That(response.GetString("nope"), Is.Null);
        Assert.That(response.GetString("nope", "default"), Is.EqualTo("default"));
        Assert.That(response.GetInt("nope", 5), Is.EqualTo(5));
        Assert.That(response.GetFloat("nope", 1.5f), Is.EqualTo(1.5f));
        Assert.That(response.GetBool("nope", true), Is.True);
        Assert.That(response.Contains("nope"), Is.False);
    }

    [Test]
    public void NumberRangesRoundToInts() {
        DialogResponse response = Response(("age", "36.6"));
        Assert.That(response.GetInt("age"), Is.EqualTo(37));
    }

    [Test]
    public void BooleansUseTheStringsTheyWereGiven() {
        ManagedDialog dialog = new DialogBuilder("Title")
            .BooleanInput("plain", "Plain")
            .BooleanInput("custom", "Custom", onTrue: "YES", onFalse: "no")
            .Button("Send", _ => { })
            .Build();

        DialogResponse ticked = Response(dialog, ("plain", "true"), ("custom", "YES"));
        Assert.That(ticked.GetBool("plain"), Is.True);
        Assert.That(ticked.GetBool("custom"), Is.True);

        DialogResponse unticked = Response(dialog, ("plain", "false"), ("custom", "no"));
        Assert.That(unticked.GetBool("plain"), Is.False);
        Assert.That(unticked.GetBool("custom"), Is.False);
    }

    [Test]
    public void NoPayloadReadsAsEmpty() {
        DialogResponse response = new() {
            Player = null!,
            ActionId = "managedserver:dialog/test/0"
        };

        Assert.That(response.Contains("name"), Is.False);
        Assert.That(response.GetString("name"), Is.Null);
    }

    private static DialogResponse Response(params (string Key, string Value)[] values) {
        return Response(null, values);
    }

    private static DialogResponse Response(ManagedDialog? dialog, params (string Key, string Value)[] values) {
        return new DialogResponse {
            Player = null!,
            ActionId = "managedserver:dialog/test/0",
            Dialog = dialog,
            Payload = new CompoundTag(values
                .Select(v => (v.Key, (INbtTag)new StringTag(v.Value)))
                .ToArray())
        };
    }
}
