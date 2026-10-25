using Minecraft.Text;

namespace ClientLib.Advancements;

/// <summary>
/// <c>AdvancementProgress</c> as the client holds it: when each criterion was obtained, null while it is not,
/// judged against the requirements of the advancement it belongs to.
/// </summary>
public sealed class AdvancementProgress {
    private readonly Dictionary<string, DateTimeOffset?> _criteria;
    private string[][] _requirements = [];

    public AdvancementProgress(Dictionary<string, DateTimeOffset?> criteria) {
        _criteria = criteria;
    }

    public IReadOnlyDictionary<string, DateTimeOffset?> Criteria => _criteria;

    /// <summary><c>update</c>: criteria the requirements do not name are dropped, and those they name but the server left out start not done.</summary>
    public void Update(string[][] requirements) {
        HashSet<string> names = requirements.SelectMany(group => group).ToHashSet();
        foreach (string name in _criteria.Keys.Where(name => !names.Contains(name)).ToList()) {
            _criteria.Remove(name);
        }
        foreach (string name in names) {
            _criteria.TryAdd(name, null);
        }
        _requirements = requirements;
    }

    /// <summary><c>AdvancementRequirements.test</c>: every group has a done criterion, and an advancement with no groups is never done.</summary>
    public bool IsDone => _requirements.Length != 0 && _requirements.All(group => group.Any(IsCriterionDone));

    public bool HasProgress => _criteria.Values.Any(obtained => obtained != null);

    public float Percent => _criteria.Count == 0 ? 0.0F : (float)CountCompletedRequirements() / _requirements.Length;

    /// <summary><c>getProgressText</c>: "done/total" groups, only for an advancement with more than one group.</summary>
    public TextComponent? ProgressText {
        get {
            if (_criteria.Count == 0 || _requirements.Length <= 1) {
                return null;
            }
            return TextComponent.Translatable("advancements.progress",
                with: [TextComponent.Text(CountCompletedRequirements().ToString()), TextComponent.Text(_requirements.Length.ToString())]);
        }
    }

    public DateTimeOffset? FirstProgressDate => _criteria.Values.Where(obtained => obtained != null).Min();

    public bool IsCriterionDone(string criterion) => _criteria.TryGetValue(criterion, out DateTimeOffset? obtained) && obtained != null;

    private int CountCompletedRequirements() => _requirements.Count(group => group.Any(IsCriterionDone));
}
