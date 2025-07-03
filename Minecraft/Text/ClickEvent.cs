using NBT;
using NBT.Tags;

namespace Minecraft.Text;

public record ClickEvent(string Action, params INbtTag?[] Fields) {
    
    public static ClickEvent OpenUrl(string url) {
        return new ClickEvent("open_url", new StringTag("url", url));
    }
    
    public static ClickEvent OpenFile(string file) {
        return new ClickEvent("open_file", new StringTag("path", file));
    }
    
    public static ClickEvent RunCommand(string cmd) {
        return new ClickEvent("run_command", new StringTag("command", cmd));
    }
    
    public static ClickEvent SuggestCommand(string cmd) {
        return new ClickEvent("suggest_command", new StringTag("command", cmd));
    }
    
    /// <summary>
    /// Click event that changes the current page in the open book to the value.
    /// <p/>
    /// This only works for text in books.
    /// </summary>
    /// <param name="page">The page to change to.</param>
    /// <returns></returns>
    public static ClickEvent ChangePage(int page) {
        return new ClickEvent("change_page", new IntegerTag("page", page));
    }
    
    public static ClickEvent CopyToClipboard(string msg) {
        return new ClickEvent("copy_to_clipboard", new StringTag("value", msg));
    }
    
    // TODO: add show dialog and custom types
}
