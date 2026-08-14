namespace ManagedServer.Interaction;

/// <summary>
/// Which of vanilla's six <c>InteractionResult</c> constants this is.
/// </summary>
public enum InteractionResultKind {
    /// <summary>Handled. The only kind <c>consumesAction</c> is true for.</summary>
    Success,

    /// <summary>Handled by refusing. Stops the client's own sequence, unlike <see cref="Pass"/>.</summary>
    Fail,

    /// <summary>Nothing happened here, carry on.</summary>
    Pass,

    /// <summary>
    /// <c>TRY_WITH_EMPTY_HAND</c>: nothing happened <em>with this item</em>, ask the block again as
    /// though the hand were empty. This is the kind that lets a chest open while you hold a block.
    /// </summary>
    TryEmptyHand
}

/// <summary><c>InteractionResult.SwingSource</c>: who plays the swing animation, if anyone.</summary>
public enum SwingSource {
    None,

    /// <summary>The client swings on its own; the server sends nothing.</summary>
    Client,

    /// <summary>The server has to send the animation.</summary>
    Server
}

/// <summary>
/// A port of <c>net.minecraft.world.InteractionResult</c>, the answer every step of
/// <see cref="BlockInteraction.UseItemOn"/> gives.
/// <p/>
/// A bool is not enough. The sequence has three distinct non consuming outcomes and the difference
/// between two of them is load bearing: <see cref="TryWithEmptyHand"/> means "ask the block again
/// without the item", which is the only way <c>ChestBlock.useWithoutItem</c> is ever reached, while
/// <see cref="Pass"/> means "fall through to the item". Collapsing them stops a chest opening while
/// the player holds a block, which is the whole reason this type exists.
/// <p/>
/// Upstream this is a sealed interface with six singletons rather than an enum, so it is a record
/// struct here: vanilla's <c>ItemContext</c> (<c>wasItemInteraction</c> and
/// <c>heldItemTransformedTo</c>) is a second component of <c>Success</c> and can be added as a third
/// field without touching a call site. It is <b>deliberately omitted</b> for now, because the only
/// things that read it are item durability and advancement triggers, neither of which is ported.
/// </summary>
public readonly record struct InteractionResult(InteractionResultKind Kind, SwingSource Swing) {
    /// <summary><c>InteractionResult.SUCCESS</c>: handled, and the client swings by itself.</summary>
    public static readonly InteractionResult Success = new(InteractionResultKind.Success, SwingSource.Client);

    /// <summary><c>InteractionResult.SUCCESS_SERVER</c>: handled, and the server sends the swing.</summary>
    public static readonly InteractionResult SuccessServer = new(InteractionResultKind.Success, SwingSource.Server);

    /// <summary><c>InteractionResult.CONSUME</c>: handled, with no animation at all.</summary>
    public static readonly InteractionResult Consume = new(InteractionResultKind.Success, SwingSource.None);

    /// <summary><c>InteractionResult.FAIL</c>: refused, and the sequence stops.</summary>
    public static readonly InteractionResult Fail = new(InteractionResultKind.Fail, SwingSource.None);

    /// <summary><c>InteractionResult.PASS</c>: nothing happened, carry on to the next step.</summary>
    public static readonly InteractionResult Pass = new(InteractionResultKind.Pass, SwingSource.None);

    /// <summary>
    /// <c>InteractionResult.TRY_WITH_EMPTY_HAND</c>: the default body of
    /// <c>BlockBehaviour.useItemOn</c>, asking for the <c>useWithoutItem</c> retry.
    /// </summary>
    public static readonly InteractionResult TryWithEmptyHand = new(InteractionResultKind.TryEmptyHand, SwingSource.None);

    /// <summary>
    /// <c>InteractionResult.consumesAction()</c>: true for the three <c>Success</c> constants and
    /// nothing else. <see cref="Fail"/> stops the sequence without consuming it, which is why this
    /// is not "anything but Pass".
    /// </summary>
    public bool ConsumesAction => Kind == InteractionResultKind.Success;
}
