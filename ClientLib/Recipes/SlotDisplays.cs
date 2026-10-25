using ClientLib.World.BlockEntities;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Text;

namespace ClientLib.Recipes;

/// <summary>
/// <c>SlotDisplayContext.fromLevel</c>: the registries, the server's item tags and the fuels a slot display
/// resolves against.
/// </summary>
public sealed class SlotDisplayContext(MinecraftRegistry registry, Func<Identifier, int[]?> itemTag, Func<IReadOnlyList<IItem>> fuelItems) {
    public MinecraftRegistry Registry { get; } = registry;
    public int[]? ItemTag(Identifier tag) => itemTag(tag);
    public IReadOnlyList<IItem> FuelItems => fuelItems();
}

/// <summary><c>SlotDisplay.resolveForStacks</c> and <c>resolveForFirstStack</c>.</summary>
public static class SlotDisplays {
    private const int DemoLimit = 16;

    public static List<ItemStack> ResolveForStacks(this SlotDisplay display, SlotDisplayContext context) {
        List<ItemStack> result = [];
        Resolve(display, context, result);
        return result;
    }

    public static ItemStack ResolveForFirstStack(this SlotDisplay display, SlotDisplayContext context) =>
        display.ResolveForStacks(context) is { Count: > 0 } stacks ? stacks[0] : ItemStack.Air;

    private static void Resolve(SlotDisplay display, SlotDisplayContext context, List<ItemStack> into) {
        switch (display) {
            case SlotDisplay.AnyFuel:
                into.AddRange(context.FuelItems.Select(item => new ItemStack(item)));
                break;
            case SlotDisplay.Item item:
                into.Add(new ItemStack(item.Value));
                break;
            case SlotDisplay.Stack stack:
                into.Add(stack.Value);
                break;
            case SlotDisplay.Tag tag:
                if (context.ItemTag(tag.TagName) is { } ids) {
                    into.AddRange(ids.Select(id => new ItemStack(context.Registry.Items[id])));
                }
                break;
            case SlotDisplay.Composite composite:
                foreach (SlotDisplay part in composite.Contents) {
                    Resolve(part, context, into);
                }
                break;
            case SlotDisplay.WithRemainder remainder:
                Resolve(remainder.Input, context, into);
                break;
            case SlotDisplay.OnlyWithComponent only:
                into.AddRange(only.Source.ResolveForStacks(context).Where(stack => HasComponent(stack, only.Component)));
                break;
            case SlotDisplay.WithAnyPotion withPotion: {
                List<ItemStack> items = withPotion.Display.ResolveForStacks(context);
                for (int id = 0; id < context.Registry.Potions.Count; id++) {
                    PotionContentsComponent.Data contents = new(context.Registry.Potions[id]);
                    into.AddRange(items.Select(item => item.With(DataComponent.PotionContents, contents)));
                }
                break;
            }
            case SlotDisplay.Dyed dyed:
                // applyDemoTransformation's cycle: every target with every dye, target fastest. One dye on an undyed
                // item comes out as that dye's own colour, which is all a demo ever applies.
                Demo(dyed.Target.ResolveForStacks(context), dyed.Dye.ResolveForStacks(context), (target, dye) => {
                    DyeColor colour = dye.Has(DataComponent.Dye) ? dye.Get(DataComponent.Dye) : DyeColor.White;
                    return target.With(DataComponent.DyedColor, TextColor.FromDecimal((int)(BeaconBlockEntity.TextureDiffuseColor(colour) & 0xFFFFFF)));
                }, into);
                break;
            case SlotDisplay.SmithingTrim trim:
                // Vanilla draws a random base and material per entry; only the smithing table shows these, and it
                // has no recipe book, so the bases stand in.
                Resolve(trim.Base, context, into);
                break;
        }
    }

    private static void Demo(List<ItemStack> first, List<ItemStack> second, Func<ItemStack, ItemStack, ItemStack> operation, List<ItemStack> into) {
        if (first.Count == 0 || second.Count == 0) {
            return;
        }
        int added = 0;
        for (int index = 0; index < first.Count * second.Count && added < DemoLimit; index++) {
            ItemStack made = operation(first[index % first.Count], second[index / first.Count]);
            if (!made.IsAir()) {
                into.Add(made);
                added++;
            }
        }
    }

    private static bool HasComponent(ItemStack stack, IDataComponent component) =>
        stack.Components.ContainsKey(component)
        || (!stack.RemoveComponents.Contains(component) && stack.Type.DefaultComponents.ContainsKey(component));
}
