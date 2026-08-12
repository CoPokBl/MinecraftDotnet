namespace Minecraft.Data.Dialogs;

/// <summary>What happens to the dialog once the player presses one of its buttons.</summary>
public enum DialogAfterAction {
    /// <summary>Shut the dialog.</summary>
    Close,

    /// <summary>Leave it open.</summary>
    None,

    /// <summary>Leave it open but stop taking input until the server says otherwise.</summary>
    WaitForResponse
}

public static class DialogAfterActionExtensions {
    public static string ToProtocolString(this DialogAfterAction action) => action switch {
        DialogAfterAction.Close => "close",
        DialogAfterAction.None => "none",
        DialogAfterAction.WaitForResponse => "wait_for_response",
        _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
    };

    public static DialogAfterAction ParseDialogAfterAction(string value) => value switch {
        "close" => DialogAfterAction.Close,
        "none" => DialogAfterAction.None,
        "wait_for_response" => DialogAfterAction.WaitForResponse,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown dialog after action")
    };
}
