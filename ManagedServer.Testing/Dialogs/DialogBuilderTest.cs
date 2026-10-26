using ManagedServer.Dialogs;
using Minecraft.Data.Dialogs;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Testing.Dialogs;

public class DialogBuilderTest {

    [Test]
    public void OneButtonMakesANotice() {
        ManagedDialog dialog = new DialogBuilder("Title").Button("OK", _ => { }).Build();
        Assert.That(dialog.Dialog, Is.TypeOf<NoticeDialog>());
    }

    [Test]
    public void SeveralButtonsMakeAGrid() {
        ManagedDialog dialog = new DialogBuilder("Title")
            .Button("One", _ => { })
            .Button("Two", _ => { })
            .Build();

        Assert.That(dialog.Dialog, Is.TypeOf<MultiActionDialog>());
        Assert.That(((MultiActionDialog)dialog.Dialog).Actions, Has.Length.EqualTo(2));
    }

    [Test]
    public void ButtonsCarryTheirOwnActionId() {
        ManagedDialog dialog = new DialogBuilder("Title")
            .Button("One", _ => { })
            .Button("Two", _ => { })
            .ExitButton("Back", _ => { })
            .Build();

        MultiActionDialog built = (MultiActionDialog)dialog.Dialog;
        Identifier[] ids = [
            ActionId(built.Actions[0]),
            ActionId(built.Actions[1]),
            ActionId(built.ExitAction!)
        ];

        Assert.That(ids, Is.Unique);
        Assert.That(dialog.ButtonIndexFor(ids[0]), Is.EqualTo(0));
        Assert.That(dialog.ButtonIndexFor(ids[1]), Is.EqualTo(1));
        Assert.That(dialog.ButtonIndexFor(ids[2]), Is.EqualTo(2));
    }

    [Test]
    public void ButtonsFromOtherDialogsArentOurs() {
        ManagedDialog dialog = new DialogBuilder("Title").Button("One", _ => { }).Build();
        ManagedDialog other = new DialogBuilder("Title").Button("One", _ => { }).Build();

        Identifier otherId = ActionId(((NoticeDialog)other.Dialog).Action);
        Assert.That(dialog.ButtonIndexFor(otherId), Is.EqualTo(-1));
        Assert.That(dialog.ButtonIndexFor("minecraft:something_else"), Is.EqualTo(-1));
        // A button index that isn't there mustn't run one that is
        Assert.That(dialog.ButtonIndexFor("managedserver:dialog/nope/0"), Is.EqualTo(-1));
    }

    [Test]
    public void ButtonWithoutACallbackHasNoAction() {
        ManagedDialog dialog = new DialogBuilder("Title").Button("Close", null).Build();
        Assert.That(((NoticeDialog)dialog.Dialog).Action.Action, Is.Null);
    }

    [Test]
    public void InputsKeepTheirKeysAndTypes() {
        ManagedDialog dialog = new DialogBuilder("Title")
            .TextInput("name", "Name", maxLength: 16)
            .NumberInput("age", "Age", 0, 100, step: 1)
            .BooleanInput("loud", "Loud")
            .OptionInput("colour", "Colour", new SingleOptionEntry("red"))
            .Button("Send", _ => { })
            .Build();

        Assert.That(dialog.Inputs.Select(i => i.Key), Is.EqualTo(new[] { "name", "age", "loud", "colour" }));

        ListTag inputs = (ListTag)dialog.Dialog.ToNbt().GetCompound()["inputs"]!;
        Assert.That(inputs.Tags.ToArray().Select(t => t.GetCompound()["type"].GetString()), Is.EqualTo(new[] {
            "minecraft:text", "minecraft:number_range", "minecraft:boolean", "minecraft:single_option"
        }));
    }

    [Test]
    public void BadInputKeysAreRejected() {
        // The client refuses the whole dialog over one of these
        Assert.Throws<ArgumentException>(() => new DialogBuilder("Title").TextInput("no spaces", "Label"));
        Assert.Throws<ArgumentException>(() => new DialogBuilder("Title").TextInput("", "Label"));
        Assert.Throws<ArgumentException>(() => new DialogBuilder("Title")
            .TextInput("name", "Label")
            .TextInput("name", "Again"));
    }

    [Test]
    public void StayingOpenTurnsPausingOff() {
        // The client refuses to decode a dialog that pauses the game and never unpauses it, and
        // drops the connection rather than complaining
        ManagedDialog dialog = new DialogBuilder("Title")
            .AfterAction(DialogAfterAction.None)
            .Button("One", _ => { })
            .Build();

        Assert.That(dialog.Dialog.Common.Pause, Is.False);
    }

    [Test]
    public void PausingWhileStayingOpenIsRejected() {
        DialogBuilder builder = new DialogBuilder("Title")
            .AfterAction(DialogAfterAction.None)
            .Pause()
            .Button("One", _ => { });

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Test]
    public void WaitingForAResponseStillPauses() {
        // This one does unpause when the server answers, so vanilla allows it
        ManagedDialog dialog = new DialogBuilder("Title")
            .AfterAction(DialogAfterAction.WaitForResponse)
            .Button("One", _ => { })
            .Build();

        Assert.That(dialog.Dialog.Common.Pause, Is.True);
    }

    [Test]
    public void ConfirmationHasBothButtons() {
        ManagedDialog dialog = ManagedDialog.Confirmation("Sure?", "Really?", _ => { }, _ => { });
        ConfirmationDialog built = (ConfirmationDialog)dialog.Dialog;

        Assert.That(dialog.ButtonIndexFor(ActionId(built.Yes)), Is.EqualTo(0));
        Assert.That(dialog.ButtonIndexFor(ActionId(built.No)), Is.EqualTo(1));
    }

    private static Identifier ActionId(DialogActionButton button) {
        return ((DialogAction.Custom)button.Action!).Id;
    }
}
