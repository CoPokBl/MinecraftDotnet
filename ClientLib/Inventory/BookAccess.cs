using ClientLib.Interaction;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib.Inventory;

/// <summary>A book's pages, as <c>BookViewScreen.BookAccess</c> and the edit screen read them. Text filtering is off, so pages are raw.</summary>
public static class BookAccess {
    /// <summary><c>BookAccess.fromItem</c>: a written book's pages, else a writable book's as literals, else null.</summary>
    public static List<TextComponent>? FromItem(ItemStack stack) {
        if (ItemComponents.Get(stack, DataComponent.WrittenBookContent) is { } written) {
            return written.Pages.Select(page => page.Raw).ToList();
        }
        return WritableContent(stack) is { } writable ? writable.Contents.Select(page => TextComponent.Text(page.Raw)).ToList() : null;
    }

    /// <summary>
    /// The stack's <c>writable_book_content</c>. The generated item table leaves the writable book's default
    /// of no pages off, so a book carrying that default arrives without the component and is given it here.
    /// </summary>
    public static WritableBookContentComponent.Data? WritableContent(ItemStack stack) {
        if (ItemComponents.Get(stack, DataComponent.WritableBookContent) is { } content) {
            return content;
        }
        bool removed = stack.RemoveComponents.Contains(DataComponent.WritableBookContent);
        return stack.Type.Identifier == Item.WritableBook.Identifier && !removed ? new WritableBookContentComponent.Data([]) : null;
    }
}
