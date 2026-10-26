using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;

namespace GraphicalClient.Gui;

public enum ToastVisibility {
    Show,
    Hide
}

/// <summary>
/// A notification in the top right corner, slid in and out by <see cref="ToastManager"/>. It decides for itself
/// when it is done: once <see cref="WantedVisibility"/> turns to hide it slides out and is dropped.
/// </summary>
public abstract class Toast {
    public const int DefaultWidth = 160;
    public const int SlotHeight = 32;

    /// <summary>The token of a toast nothing looks up again.</summary>
    public static readonly object NoToken = new();

    public abstract ToastVisibility WantedVisibility { get; }

    /// <summary>Once a frame while on screen, with how long it has been fully slid in.</summary>
    public abstract void Update(ToastManager manager, long fullyVisibleForMs);

    /// <summary>Draws it with its top left corner at (<paramref name="x"/>, <paramref name="y"/>).</summary>
    public abstract void Render(GuiContext context, float x, float y, long fullyVisibleForMs);

    /// <summary>
    /// Lays out anything that depends on the font, before <see cref="Width"/> or <see cref="Height"/> is read and
    /// before every draw; the font changes when the packs reload.
    /// </summary>
    public virtual void Measure(TextRenderer text) {
    }

    /// <summary>Played as it comes on screen, once however many toasts with it arrive together.</summary>
    public virtual ISoundType? Sound => null;

    /// <summary>What <see cref="ToastManager.Get{T}"/> finds it by.</summary>
    public virtual object Token => NoToken;

    public virtual int Width => DefaultWidth;
    public virtual int Height => SlotHeight;

    /// <summary><c>xPos</c>: its left edge as it slides, in from the right edge of the screen.</summary>
    public virtual float XPos(int screenWidth, float visiblePortion) => screenWidth - Width * visiblePortion;

    /// <summary><c>yPos</c>: its top edge, at the first slot it holds.</summary>
    public virtual float YPos(int firstSlotIndex) => firstSlotIndex * (float)SlotHeight;

    public int OccupiedSlotCount => (Height + SlotHeight - 1) / SlotHeight;

    /// <summary>Once, when it has slid out for good.</summary>
    public virtual void OnFinishedRendering() {
    }
}

/// <summary>
/// <c>ToastManager</c>: five 32 pixel slots down the right edge. A toast waits in the queue until enough
/// slots in a row are free, slides in over 600 ms, and slides out the same way when it asks to hide. Add
/// one with <see cref="Add"/>; <see cref="Update"/> and <see cref="Render"/> run once a frame. The now
/// playing toast sits outside the slots in the top left corner, kept while the <c>musicToast</c> option
/// is not never.
/// </summary>
public sealed class ToastManager {
    private const int SlotCount = 5;
    private const long SlideAnimationDurationMs = 600;

    private readonly List<ToastInstance> _visible = [];
    private readonly bool[] _occupied = new bool[SlotCount];
    private readonly LinkedList<Toast> _queued = [];
    private readonly HashSet<ISoundType> _playedSounds = [];
    private ToastInstance? _nowPlaying;
    private MusicToastDisplayState? _musicToast;

    /// <summary>The <c>notificationDisplayTime</c> option, which every toast's own display time is multiplied by.</summary>
    public double NotificationDisplayTimeMultiplier { get; set; } = 1.0;

    /// <summary>The translation key of the song playing, null for none; <see cref="NowPlayingToast"/> names it.</summary>
    public Func<string?> CurrentMusic { get; set; } = () => null;

    public void Add(Toast toast) => _queued.AddLast(toast);

    /// <summary>
    /// Follows the <c>musicToast</c> option, once a frame: the first call is the constructor's
    /// <c>initializeMusicToast</c>, and a change after it is <c>setMusicToastDisplayState</c>, which shows the
    /// toast at once when switching to the toast and the music can be heard.
    /// </summary>
    public void FollowMusicToastOption(MusicToastDisplayState state, bool musicAudible) {
        if (_musicToast == state) {
            return;
        }
        bool initializing = _musicToast == null;
        _musicToast = state;
        _nowPlaying = state == MusicToastDisplayState.Never ? null : new ToastInstance(new NowPlayingToast(() => CurrentMusic()), 0, 0);
        if (!initializing && state == MusicToastDisplayState.PauseAndToast && musicAudible) {
            ((NowPlayingToast)_nowPlaying!.Toast).ShowToast(NotificationDisplayTimeMultiplier);
        }
    }

    public void ShowNowPlayingToast() {
        if (_nowPlaying != null) {
            _nowPlaying.Reset();
            ((NowPlayingToast)_nowPlaying.Toast).ShowToast(NotificationDisplayTimeMultiplier);
        }
    }

    public void HideNowPlayingToast() => (_nowPlaying?.Toast as NowPlayingToast)?.SetWantedVisibility(ToastVisibility.Hide);

    /// <summary><c>getToast</c>: one on screen or waiting with this token, to change rather than add another.</summary>
    public T? Get<T>(object token) where T : Toast {
        foreach (ToastInstance instance in _visible) {
            if (instance.Toast is T toast && toast.Token.Equals(token)) {
                return toast;
            }
        }
        foreach (Toast queued in _queued) {
            if (queued is T toast && toast.Token.Equals(token)) {
                return toast;
            }
        }
        return null;
    }

    public void Clear() {
        Array.Clear(_occupied);
        _visible.Clear();
        _queued.Clear();
    }

    /// <summary>
    /// Moves every toast on, then fills free slots from the queue in its order, skipping one that does not fit.
    /// Of all the toasts that change direction this frame only the first plays its slide sound.
    /// </summary>
    public void Update(GuiContext context) {
        long now = Environment.TickCount64;
        bool visibilitySoundPlayed = false;
        for (int i = 0; i < _visible.Count; i++) {
            ToastInstance toast = _visible[i];
            ToastVisibility previous = toast.Visibility;
            toast.Update(this, now);
            if (toast.Visibility != previous && !visibilitySoundPlayed) {
                visibilitySoundPlayed = true;
                context.Sounds?.PlayUi(toast.Visibility == ToastVisibility.Show ? SoundType.ToastIn : SoundType.ToastOut, 1.0F, 1.0F);
            }
            if (toast.HasFinishedRendering) {
                Array.Fill(_occupied, false, toast.FirstSlotIndex, toast.OccupiedSlotCount);
                _visible.RemoveAt(i--);
            }
        }
        if (_queued.Count > 0 && FreeSlotCount() > 0) {
            for (LinkedListNode<Toast>? node = _queued.First; node != null;) {
                LinkedListNode<Toast>? next = node.Next;
                Toast toast = node.Value;
                toast.Measure(context.Text);
                int slots = toast.OccupiedSlotCount;
                int first = FindFreeSlotsIndex(slots);
                if (first != -1) {
                    _visible.Add(new ToastInstance(toast, first, slots));
                    Array.Fill(_occupied, true, first, slots);
                    if (toast.Sound is { } sound && _playedSounds.Add(sound)) {
                        context.Sounds?.PlayUi(sound, 1.0F, 1.0F);
                    }
                    _queued.Remove(node);
                }
                node = next;
            }
        }
        _playedSounds.Clear();
        _nowPlaying?.Update(this, now);
    }

    /// <summary>
    /// The toasts on screen; the caller leaves this out while the HUD is hidden. The now playing toast is
    /// left out under the pause screen, which draws its own.
    /// </summary>
    public void Render(GuiContext context) {
        foreach (ToastInstance toast in _visible) {
            toast.Render(context);
        }
        if (_musicToast?.RenderToast() == true && _nowPlaying != null && context.CurrentScreen() is not PauseScreen) {
            _nowPlaying.Render(context);
        }
    }

    private int FindFreeSlotsIndex(int required) {
        if (FreeSlotCount() >= required) {
            int consecutive = 0;
            for (int i = 0; i < SlotCount; i++) {
                if (_occupied[i]) {
                    consecutive = 0;
                }
                else if (++consecutive == required) {
                    return i + 1 - consecutive;
                }
            }
        }
        return -1;
    }

    private int FreeSlotCount() => _occupied.Count(occupied => !occupied);

    /// <summary><c>ToastManager.ToastInstance</c>: where a toast is in its slide, and for how long it has been fully in.</summary>
    private sealed class ToastInstance(Toast toast, int firstSlotIndex, int occupiedSlotCount) {
        private long _animationStartTime = -1;
        private long _becameFullyVisibleAt = -1;

        /// <summary><c>resetToast</c>: back to before its first slide in.</summary>
        public void Reset() {
            _animationStartTime = -1;
            _becameFullyVisibleAt = -1;
            Visibility = ToastVisibility.Hide;
            FullyVisibleFor = 0;
            VisiblePortion = 0;
            HasFinishedRendering = false;
        }

        public void Render(GuiContext context) {
            if (!HasFinishedRendering) {
                Toast.Measure(context.Text);
                Toast.Render(context, Toast.XPos(context.Width, VisiblePortion), Toast.YPos(FirstSlotIndex), FullyVisibleFor);
            }
        }

        public Toast Toast { get; } = toast;
        public int FirstSlotIndex { get; } = firstSlotIndex;
        public int OccupiedSlotCount { get; } = occupiedSlotCount;
        public ToastVisibility Visibility { get; private set; } = ToastVisibility.Hide;
        public long FullyVisibleFor { get; private set; }
        public float VisiblePortion { get; private set; }
        public bool HasFinishedRendering { get; private set; }

        private void CalculateVisiblePortion(long now) {
            float progress = Math.Clamp((now - _animationStartTime) / (float)SlideAnimationDurationMs, 0.0F, 1.0F);
            progress *= progress;
            VisiblePortion = Visibility == ToastVisibility.Hide ? 1.0F - progress : progress;
        }

        public void Update(ToastManager manager, long now) {
            if (_animationStartTime == -1) {
                _animationStartTime = now;
                Visibility = ToastVisibility.Show;
            }
            if (Visibility == ToastVisibility.Show && now - _animationStartTime <= SlideAnimationDurationMs) {
                _becameFullyVisibleAt = now;
            }
            FullyVisibleFor = now - _becameFullyVisibleAt;
            CalculateVisiblePortion(now);
            Toast.Update(manager, FullyVisibleFor);
            ToastVisibility wanted = Toast.WantedVisibility;
            if (wanted != Visibility) {
                // Turning round mid slide starts from where it is rather than from the far end.
                _animationStartTime = now - (int)((1.0F - VisiblePortion) * SlideAnimationDurationMs);
                Visibility = wanted;
            }
            bool wasFinished = HasFinishedRendering;
            HasFinishedRendering = Visibility == ToastVisibility.Hide && now - _animationStartTime > SlideAnimationDurationMs;
            if (HasFinishedRendering && !wasFinished) {
                Toast.OnFinishedRendering();
            }
        }
    }
}
