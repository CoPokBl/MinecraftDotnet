import java.io.DataOutputStream;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;
import java.nio.ByteBuffer;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.function.Supplier;
import java.util.zip.GZIPOutputStream;

import com.mojang.blaze3d.systems.RenderSystem;
import com.mojang.blaze3d.vertex.BufferBuilder;
import com.mojang.blaze3d.vertex.ByteBufferBuilder;
import com.mojang.blaze3d.vertex.DefaultVertexFormat;
import com.mojang.blaze3d.vertex.MeshData;
import com.mojang.blaze3d.vertex.VertexConsumer;
import com.mojang.renderpearl.api.buffers.GpuBuffer;
import com.mojang.renderpearl.api.device.GpuDevice;
import com.mojang.renderpearl.api.pipeline.PrimitiveTopology;
import net.minecraft.client.renderer.EndFlashState;
import net.minecraft.client.renderer.SkyRenderer;

/**
 * Runs the client's own SkyRenderer.buildStars, buildSunriseFan, buildEndSky and buildSkyDisc and writes the vertex
 * bytes each hands the GPU, for SkyMeshConformanceTest. No GPU is opened: RenderSystem's device is a proxy that keeps
 * whatever createBuffer is given, and the SkyRenderer is allocated without its constructor, which wants an atlas.
 *
 * It also ticks an EndFlashState through two stretches of clock time and keeps its intensity and angles after each
 * tick, as three little endian floats, under "End flash".
 *
 * The fixture is a gzip of entries, each a UTF name, a big endian int length and that many bytes in the vertex
 * format's own little endian layout, ending with "starIndexCount" and its int.
 */
public final class SkyMeshHarness {
    private static final Map<String, byte[]> BUFFERS = new LinkedHashMap<>();

    /** The clock times the flash is ticked at: the first 3000 ticks, then 3000 more from far into the game. */
    private static final long[] END_FLASH_TICKS = java.util.stream.LongStream.concat(
        java.util.stream.LongStream.range(0, 3000), java.util.stream.LongStream.range(123_456_000L, 123_459_000L)).toArray();

    public static void main(String[] args) throws Throwable {
        ClassLoader loader = SkyMeshHarness.class.getClassLoader();
        GpuDevice device = (GpuDevice) Proxy.newProxyInstance(loader, new Class<?>[] { GpuDevice.class }, (proxy, method, arguments) -> {
            if (method.getName().equals("createBuffer") && arguments.length == 3 && arguments[2] instanceof ByteBuffer data) {
                @SuppressWarnings("unchecked")
                String label = ((Supplier<String>) arguments[0]).get();
                BUFFERS.put(label, copy(data));
                long size = data.remaining();
                return Proxy.newProxyInstance(loader, new Class<?>[] { GpuBuffer.class }, (buffer, m, a) -> switch (m.getName()) {
                    case "size" -> size;
                    case "usage" -> 0;
                    case "isClosed" -> false;
                    default -> null;
                });
            }
            throw new UnsupportedOperationException(method.getName());
        });
        Field deviceField = RenderSystem.class.getDeclaredField("DEVICE");
        deviceField.setAccessible(true);
        deviceField.set(null, device);

        Field unsafeField = Class.forName("sun.misc.Unsafe").getDeclaredField("theUnsafe");
        unsafeField.setAccessible(true);
        Object unsafe = unsafeField.get(null);
        SkyRenderer sky = (SkyRenderer) unsafe.getClass().getMethod("allocateInstance", Class.class).invoke(unsafe, SkyRenderer.class);

        invoke(sky, "buildStars");
        invoke(sky, "buildSunriseFan");
        invoke(null, "buildEndSky");
        // The constructor's two discs, built the way it builds them.
        Method buildSkyDisc = SkyRenderer.class.getDeclaredMethod("buildSkyDisc", VertexConsumer.class, float.class);
        buildSkyDisc.setAccessible(true);
        for (float yy : new float[] { 16.0F, -16.0F }) {
            try (ByteBufferBuilder builder = ByteBufferBuilder.exactlySized(10 * DefaultVertexFormat.POSITION.getVertexSize())) {
                BufferBuilder bufferBuilder = new BufferBuilder(builder, PrimitiveTopology.TRIANGLE_FAN, DefaultVertexFormat.POSITION);
                buildSkyDisc.invoke(sky, bufferBuilder, yy);
                try (MeshData mesh = bufferBuilder.buildOrThrow()) {
                    BUFFERS.put(yy > 0 ? "Top sky vertex buffer" : "Bottom sky vertex buffer", copy(mesh.vertexBuffer()));
                }
            }
        }
        ByteBuffer flashes = ByteBuffer.allocate(END_FLASH_TICKS.length * 12).order(java.nio.ByteOrder.LITTLE_ENDIAN);
        EndFlashState flash = new EndFlashState();
        for (long clockTime : END_FLASH_TICKS) {
            flash.tick(clockTime);
            flashes.putFloat(flash.getIntensity(1.0F)).putFloat(flash.getXAngle()).putFloat(flash.getYAngle());
        }
        BUFFERS.put("End flash", flashes.array());
        Field starIndexCount = SkyRenderer.class.getDeclaredField("starIndexCount");
        starIndexCount.setAccessible(true);

        Path out = Path.of(args[0]);
        try (DataOutputStream stream = new DataOutputStream(new GZIPOutputStream(Files.newOutputStream(out)))) {
            for (Map.Entry<String, byte[]> entry : BUFFERS.entrySet()) {
                stream.writeUTF(entry.getKey());
                stream.writeInt(entry.getValue().length);
                stream.write(entry.getValue());
                System.out.println(entry.getKey() + ": " + entry.getValue().length + " bytes");
            }
            stream.writeUTF("starIndexCount");
            stream.writeInt(starIndexCount.getInt(sky));
        }
        System.out.println("starIndexCount: " + starIndexCount.getInt(sky));
        System.out.println("Wrote " + out);
    }

    private static void invoke(Object target, String name) throws Exception {
        Method method = SkyRenderer.class.getDeclaredMethod(name);
        method.setAccessible(true);
        method.invoke(target);
    }

    private static byte[] copy(ByteBuffer data) {
        byte[] bytes = new byte[data.remaining()];
        data.duplicate().get(bytes);
        return bytes;
    }
}
