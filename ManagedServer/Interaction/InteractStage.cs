namespace ManagedServer.Interaction;

/// <summary>
/// Which of <c>BlockBehaviour</c>'s two interaction methods a <c>PlayerBlockInteractEvent</c> is.
/// Named after the vanilla methods so a reader can find them in the jar.
/// <p/>
/// The split is not cosmetic. Vanilla runs <see cref="UseItemOn"/> first and only runs
/// <see cref="UseWithoutItem"/> when the first asked for it by returning
/// <c>TRY_WITH_EMPTY_HAND</c>, and then only for the main hand. Which of the two a block overrides
/// therefore decides when it is reached: a chest, a door, a trapdoor, a fence gate, a button and a
/// lever are all <see cref="UseWithoutItem"/>, so all of them are only reached through that retry.
/// </summary>
public enum InteractStage {
    /// <summary><c>BlockState.useItemOn</c>: the block deciding what the held item does to it.</summary>
    UseItemOn,

    /// <summary><c>BlockState.useWithoutItem</c>: the retry, as though the hand were empty.</summary>
    UseWithoutItem
}
