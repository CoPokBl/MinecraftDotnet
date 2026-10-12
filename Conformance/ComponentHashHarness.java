import com.google.common.hash.HashCode;
import net.minecraft.SharedConstants;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.component.DataComponentType;
import net.minecraft.core.component.DataComponents;
import net.minecraft.core.registries.Registries;
import net.minecraft.data.registries.VanillaRegistries;
import net.minecraft.network.chat.Component;
import net.minecraft.network.chat.Style;
import net.minecraft.ChatFormatting;
import net.minecraft.resources.RegistryOps;
import net.minecraft.server.Bootstrap;
import net.minecraft.util.HashOps;
import net.minecraft.util.Unit;
import net.minecraft.world.item.component.DyedItemColor;
import net.minecraft.world.item.enchantment.Enchantments;
import net.minecraft.world.item.enchantment.ItemEnchantments;

/**
 * Prints the hash vanilla's client puts in a container click for a handful of component values, for
 * ComponentHasherTest in ClientLib.Testing. The client hashes every component a stack patches with
 * HashOps over the component's persistent codec, and a wrong hash only shows up as the server quietly
 * correcting the slot, so the numbers have to come from the jar.
 *
 * Run it with Conformance/componenthash.sh and paste the lines it prints into the test.
 */
public class ComponentHashHarness {
    public static void main(String[] args) {
        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        HolderLookup.Provider registries = VanillaRegistries.createLookup();
        RegistryOps<HashCode> ops = registries.createSerializationContext(HashOps.CRC32C_INSTANCE);

        print(ops, "damage 5", DataComponents.DAMAGE, 5);
        print(ops, "damage 0", DataComponents.DAMAGE, 0);
        print(ops, "max_stack_size 16", DataComponents.MAX_STACK_SIZE, 16);
        print(ops, "repair_cost 3", DataComponents.REPAIR_COST, 3);
        print(ops, "custom_name Bob", DataComponents.CUSTOM_NAME, Component.literal("Bob"));
        print(ops, "custom_name red bold Bob", DataComponents.CUSTOM_NAME,
            Component.literal("Bob").withStyle(Style.EMPTY.withColor(ChatFormatting.RED).withBold(true)));
        print(ops, "unbreakable", DataComponents.UNBREAKABLE, Unit.INSTANCE);
        print(ops, "dyed_color 0x123456", DataComponents.DYED_COLOR, new DyedItemColor(0x123456));
        print(ops, "enchantment_glint_override true", DataComponents.ENCHANTMENT_GLINT_OVERRIDE, true);

        ItemEnchantments.Mutable enchantments = new ItemEnchantments.Mutable(ItemEnchantments.EMPTY);
        enchantments.set(registries.lookupOrThrow(Registries.ENCHANTMENT).getOrThrow(Enchantments.SHARPNESS), 3);
        enchantments.set(registries.lookupOrThrow(Registries.ENCHANTMENT).getOrThrow(Enchantments.UNBREAKING), 2);
        print(ops, "enchantments sharpness 3 unbreaking 2", DataComponents.ENCHANTMENTS, enchantments.toImmutable());
    }

    static <T> void print(RegistryOps<HashCode> ops, String label, DataComponentType<T> type, T value) {
        int hash = type.codecOrThrow().encodeStart(ops, value).getOrThrow().asInt();
        System.out.println(label + " = " + hash);
    }
}
