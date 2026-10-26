using ClientLib.Packs;

namespace ClientLib.Testing.Packs;

/// <summary>
/// <c>ServerPackManager</c>'s reports, in the order the vanilla source makes them: each is a
/// <c>ServerboundResourcePackPacket</c> once a connection is attached.
/// </summary>
public class ServerPackManagerTest {
    private sealed class Harness : IPackLoadFeedback {
        public readonly List<string> Reports = [];
        public readonly List<(Dictionary<Guid, PackDownloadRequest> Requests, Action<PackBatchResult> Output)> Downloads = [];
        public readonly List<IPackReloadCallbacks> Reloads = [];
        public readonly ServerPackManager Manager;
        private bool _updateRequested;

        public Harness(PackPromptStatus status) {
            Manager = new ServerPackManager((requests, output) => Downloads.Add((requests, output)), this, Reloads.Add, () => _updateRequested = true, status);
        }

        public void ReportUpdate(Guid id, PackUpdate update) => Reports.Add($"{Name(id)} {update}");

        public void ReportFinalResult(Guid id, PackFinalResult result) => Reports.Add($"{Name(id)} {result}");

        /// <summary>What the update scheduler's task does once the frame's tasks run.</summary>
        public void RunUpdates() {
            while (_updateRequested) {
                _updateRequested = false;
                Manager.Tick();
            }
        }

        public void FinishDownload(int batch, Guid[] downloaded, Guid[] failed) {
            PackBatchResult result = new();
            foreach (Guid id in downloaded) {
                result.Downloaded[id] = $"/cache/{id}";
            }
            foreach (Guid id in failed) {
                result.Failed.Add(id);
            }
            Downloads[batch].Output(result);
            RunUpdates();
        }
    }

    private static readonly Guid A = new("00000000-0000-0000-0000-00000000000a");
    private static readonly Guid B = new("00000000-0000-0000-0000-00000000000b");
    private static readonly Uri Url = new("http://localhost/pack.zip");

    private static string Name(Guid id) => id == A ? "A" : id == B ? "B" : id.ToString();

    [Test]
    public void TestAllowedPackIsAcceptedDownloadedThenApplied() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted" }), "accepted in the push handler itself");
        h.RunUpdates();
        Assert.That(h.Downloads, Has.Count.EqualTo(1));
        Assert.That(h.Reloads, Is.Empty, "no reload while a download is pending");
        h.FinishDownload(0, [A], []);
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted", "A Downloaded" }));
        Assert.That(h.Reloads, Has.Count.EqualTo(1));
        Assert.That(h.Reloads[0].PacksToLoad(), Is.EqualTo(new[] { (A, $"/cache/{A}") }));
        h.Reloads[0].OnSuccess();
        h.RunUpdates();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted", "A Downloaded", "A Applied" }));
    }

    [Test]
    public void TestDeclinedStatusDeclinesAtOnce() {
        Harness h = new(PackPromptStatus.Declined);
        h.Manager.PushPack(A, Url, null);
        h.RunUpdates();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Declined" }));
        Assert.That(h.Downloads, Is.Empty);
    }

    [Test]
    public void TestPendingPackWaitsForTheAnswer() {
        Harness h = new(PackPromptStatus.Pending);
        h.Manager.PushPack(A, Url, null);
        h.RunUpdates();
        Assert.That(h.Reports, Is.Empty);
        Assert.That(h.Downloads, Is.Empty);
        h.Manager.AllowServerPacks();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted" }));
        h.RunUpdates();
        Assert.That(h.Downloads, Has.Count.EqualTo(1));
    }

    [Test]
    public void TestRejectingDeclinesWhatWasNotAccepted() {
        Harness h = new(PackPromptStatus.Pending);
        h.Manager.PushPack(A, Url, null);
        h.Manager.RejectServerPacks();
        Assert.That(h.Reports, Is.Empty, "the decline is reported when the removed pack is cleaned up");
        h.RunUpdates();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Declined" }));
    }

    [Test]
    public void TestOneFailureInABatchDiscardsTheRest() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        h.Manager.PushPack(B, Url, null);
        h.RunUpdates();
        Assert.That(h.Downloads, Has.Count.EqualTo(1), "both go in one batch");
        h.FinishDownload(0, [B], [A]);
        // onDownload marks every inactive pack removed before reporting downloads, so B is never reported downloaded.
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted", "B Accepted", "A DownloadFailed", "B Discarded" }));
        Assert.That(h.Reloads, Is.Empty);
    }

    [Test]
    public void TestPoppingAnActivePackReloadsWithoutAReport() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        h.RunUpdates();
        h.FinishDownload(0, [A], []);
        h.Reloads[0].OnSuccess();
        h.RunUpdates();
        h.Reports.Clear();

        h.Manager.PopPack(A);
        h.RunUpdates();
        Assert.That(h.Reloads, Has.Count.EqualTo(2));
        Assert.That(h.Reloads[1].PacksToLoad(), Is.Empty);
        h.Reloads[1].OnSuccess();
        h.RunUpdates();
        Assert.That(h.Reports, Is.Empty);
    }

    [Test]
    public void TestPushingTheSameIdReplacesSilently() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        h.Manager.PushPack(A, new Uri("http://localhost/other.zip"), null);
        h.RunUpdates();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted", "A Accepted" }));
        Assert.That(h.Downloads[0].Requests[A].Url.AbsolutePath, Is.EqualTo("/other.zip"));
    }

    [Test]
    public void TestFailedReloadReportsTheNewPacks() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        h.RunUpdates();
        h.FinishDownload(0, [A], []);
        h.Reloads[0].OnFailure(false);
        Assert.That(h.Reloads[0].PacksToLoad(), Is.Empty, "the recovery set keeps only packs that were active");
        h.RunUpdates();
        Assert.That(h.Reports, Is.EqualTo(new[] { "A Accepted", "A Downloaded", "A ActivationFailed" }));
    }

    [Test]
    public void TestPacksStackInPushOrder() {
        Harness h = new(PackPromptStatus.Allowed);
        h.Manager.PushPack(A, Url, null);
        h.Manager.PushPack(B, Url, null);
        h.RunUpdates();
        h.FinishDownload(0, [A, B], []);
        Assert.That(h.Reloads[0].PacksToLoad().Select(p => p.Id), Is.EqualTo(new[] { A, B }));
    }

    [Test]
    public void TestResponsesMatchTheWireValues() {
        Assert.That((int)DownloadedPackSource.Response(PackFinalResult.Applied), Is.EqualTo(0));
        Assert.That((int)DownloadedPackSource.Response(PackFinalResult.Declined), Is.EqualTo(1));
        Assert.That((int)DownloadedPackSource.Response(PackFinalResult.DownloadFailed), Is.EqualTo(2));
        Assert.That((int)DownloadedPackSource.Response(PackUpdate.Accepted), Is.EqualTo(3));
        Assert.That((int)DownloadedPackSource.Response(PackUpdate.Downloaded), Is.EqualTo(4));
        Assert.That((int)DownloadedPackSource.Response(PackFinalResult.ActivationFailed), Is.EqualTo(6));
        Assert.That((int)DownloadedPackSource.Response(PackFinalResult.Discarded), Is.EqualTo(7));
    }

    [Test]
    public void TestOnlyHttpUrlsParse() {
        Assert.That(MinecraftClient.ParseResourcePackUrl("https://example.com/a.zip"), Is.Not.Null);
        Assert.That(MinecraftClient.ParseResourcePackUrl("HTTP://example.com/a.zip"), Is.Not.Null);
        Assert.That(MinecraftClient.ParseResourcePackUrl("ftp://example.com/a.zip"), Is.Null);
        Assert.That(MinecraftClient.ParseResourcePackUrl("file:///tmp/a.zip"), Is.Null);
        Assert.That(MinecraftClient.ParseResourcePackUrl("not a url"), Is.Null);
    }
}
