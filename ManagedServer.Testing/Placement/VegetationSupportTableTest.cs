using ManagedServer.Placement.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// The two hand written tables, against the blocks they are supposed to cover.
/// <p/>
/// Both exist because the value they hold is a <b>constructor argument</b> in vanilla's
/// <c>Blocks.java</c> rather than anything on the block state or on
/// <c>BlockBehaviour.Properties</c>, so the dumper cannot see it and the generator cannot write it.
/// That makes them the one place in the placement rules where a name is matched by hand rather than
/// generated, so they need a backstop: a block added to one of these classes upstream fails a test
/// instead of quietly becoming a plant that can never be placed or a vine that never converts between
/// its head and its body.
/// <p/>
/// If one of these fails after a version bump, read the new block's registration in
/// <c>Blocks.java</c> and add the row it names.
/// </summary>
[TestFixture]
public class VegetationSupportTableTest {
    private static readonly ManagedMinecraftServer Server = ManagedMinecraftServer.New();

    [Test]
    public void EveryStemAndFungusHasItsSupportTag() {
        Assert.That(BlocksOf(GrownFromTagPlacementRule.Classes),
            Is.EquivalentTo(GrownFromTagPlacementRule.Tags.Keys));
    }

    [Test]
    public void EveryGrowingPlantHalfHasItsFamily() {
        Assert.That(BlocksOf(GrowingPlantPlacementRule.Classes),
            Is.EquivalentTo(GrowingPlantPlacementRule.Families.Keys));
    }

    /// <summary>
    /// The stem and fruit an attached stem reverts to, which are the same kind of constructor
    /// argument. A missing row here is an attached stem that stays attached to nothing after its
    /// pumpkin is broken.
    /// </summary>
    [Test]
    public void EveryAttachedStemNamesWhatItRevertsTo() {
        Assert.That(BlocksOf([BlockClass.AttachedStemBlock]),
            Is.EquivalentTo(AttachedStemPlacementRule.Grown.Keys));
    }

    /// <summary>Both halves of each row name blocks that exist.</summary>
    [Test]
    public void EveryAttachedStemsStemAndFruitExist() {
        Assert.Multiple(() => {
            foreach (AttachedStemPlacementRule.Attachment attachment
                     in AttachedStemPlacementRule.Grown.Values) {
                Assert.That(Server.Registry.Blocks.Contains(attachment.Stem), Is.True,
                    $"{attachment.Stem} is not a block");
                Assert.That(Server.Registry.Blocks.Contains(attachment.Fruit), Is.True,
                    $"{attachment.Fruit} is not a block");
            }
        });
    }

    /// <summary>
    /// A family names both of its halves, and each half agrees which family it is in, so a typo in
    /// one of the two identifiers cannot pass by matching the other row.
    /// </summary>
    [Test]
    public void EveryGrowingPlantFamilyNamesBothItsHalves() {
        Assert.Multiple(() => {
            foreach ((Identifier block, GrowingPlantPlacementRule.Family family)
                     in GrowingPlantPlacementRule.Families) {
                Assert.That(block, Is.EqualTo(family.Head).Or.EqualTo(family.Body));
                Assert.That(GrowingPlantPlacementRule.Families[family.Head], Is.EqualTo(family));
                Assert.That(GrowingPlantPlacementRule.Families[family.Body], Is.EqualTo(family));
            }
        });
    }

    private static HashSet<Identifier> BlocksOf(BlockClass[] classes) {
        HashSet<Identifier> found = [];
        foreach (IBlock block in Server.Registry.Blocks.StatesByStateId.Values) {
            foreach (BlockClass className in classes) {
                if (BlockClasses.Is(block.Identifier, className)) {
                    found.Add(block.Identifier);
                }
            }
        }

        return found;
    }
}
