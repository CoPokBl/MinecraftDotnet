namespace GraphicalClient.Rendering;

/// <summary>The client's own GUI shaders; everything in the world is drawn by the shader pack.</summary>
public static class Shaders {
    /// <summary>Screen space quads for the HUD, in pixels, optionally textured from a font or icon atlas.</summary>
    public const string GuiVertex = """
        #version 450 core
        layout(location = 0) in vec2 aPos;
        layout(location = 1) in vec2 aUv;
        layout(location = 2) in vec4 aColour;

        uniform vec2 uScreen;

        out vec2 vUv;
        out vec4 vColour;

        void main() {
            vec2 ndc = vec2(aPos.x / uScreen.x * 2.0 - 1.0, 1.0 - aPos.y / uScreen.y * 2.0);
            gl_Position = vec4(ndc, 0.0, 1.0);
            vUv = aUv;
            vColour = aColour;
        }
        """;

    public const string GuiFragment = """
        #version 450 core
        in vec2 vUv;
        in vec4 vColour;

        uniform sampler2D uTexture;

        out vec4 fragColour;

        void main() {
            fragColour = texture(uTexture, vUv) * vColour;
            if (fragColour.a <= 0.0) {
                discard;
            }
        }
        """;

    /// <summary>The GUI's glint: positions as <see cref="GuiVertex"/>, with the icon's texture coordinates and the glint's.</summary>
    public const string GuiGlintVertex = """
        #version 450 core
        layout(location = 0) in vec2 aPos;
        layout(location = 1) in vec2 aUv;
        layout(location = 2) in vec2 aGlintUv;

        uniform vec2 uScreen;

        out vec2 vUv;
        out vec2 vGlintUv;

        void main() {
            vec2 ndc = vec2(aPos.x / uScreen.x * 2.0 - 1.0, 1.0 - aPos.y / uScreen.y * 2.0);
            gl_Position = vec4(ndc, 0.0, 1.0);
            vUv = aUv;
            vGlintUv = aGlintUv;
        }
        """;

    /// <summary>
    /// Vanilla's <c>glint.fsh</c> without fog, kept to where the icon has texels, as vanilla's equal depth
    /// test keeps it to where the item drew. Blended as source colour plus what is there.
    /// </summary>
    public const string GuiGlintFragment = """
        #version 450 core
        in vec2 vUv;
        in vec2 vGlintUv;

        uniform sampler2D uMask;
        uniform sampler2D uGlint;
        uniform float uStrength;

        out vec4 fragColour;

        void main() {
            vec4 colour = texture(uGlint, vGlintUv);
            if (colour.a < 0.1 || texture(uMask, vUv).a < 0.5) {
                discard;
            }
            fragColour = vec4(colour.rgb * uStrength, colour.a);
        }
        """;

    /// <summary>
    /// Vanilla's <c>entity.vsh</c> as a picture in picture draws it: positions in the picture's pixels,
    /// y down and z towards the viewer, lit by the two <c>ENTITY_IN_UI</c> lights. Every draw is lit
    /// per face, as vanilla's no cull entity pipelines are, since the batch does not say which draws cull.
    /// </summary>
    public const string EntityInUiVertex = """
        #version 450 core
        layout(location = 0) in vec3 aPosition;
        layout(location = 1) in vec2 aUv;
        layout(location = 2) in vec4 aColour;
        layout(location = 4) in vec3 aNormal;
        layout(location = 5) in vec2 aOverlay;

        uniform vec2 uSize;
        uniform vec3 uLight0;
        uniform vec3 uLight1;

        out vec2 vUv;
        out vec4 vColourFront;
        out vec4 vColourBack;
        out vec4 vOverlay;

        // light.glsl's minecraft_mix_light_separate.
        vec4 mixLight(vec2 light, vec4 colour) {
            vec2 lightValue = max(vec2(0.0), light);
            float lightAccum = min(1.0, (lightValue.x + lightValue.y) * 0.6 + 0.4);
            return vec4(colour.rgb * lightAccum, colour.a);
        }

        void main() {
            gl_Position = vec4(aPosition.x / uSize.x * 2.0 - 1.0, 1.0 - aPosition.y / uSize.y * 2.0, -aPosition.z / 1000.0, 1.0);
            vec2 light = vec2(dot(uLight0, aNormal), dot(uLight1, aNormal));
            vColourFront = mixLight(light, aColour);
            vColourBack = mixLight(-light, aColour);
            // OverlayTexture's texel: the hurt row is red at alpha 178, the others white fading by
            // u = (int)(progress * 15). The batch keeps the progress as a byte, which can land a hair
            // under a whole step.
            if (aOverlay.x > 0.5) {
                vOverlay = vec4(1.0, 0.0, 0.0, 178.0 / 255.0);
            }
            else {
                float u = floor(aOverlay.y * 15.0 + 0.001);
                vOverlay = vec4(1.0, 1.0, 1.0, floor((1.0 - u / 15.0 * 0.75) * 255.0) / 255.0);
            }
            vUv = aUv;
        }
        """;

    /// <summary>
    /// Vanilla's <c>entity.fsh</c> with the 0.1 alpha cutout, lit from the lightmap at full sky and block
    /// light as <c>GuiGraphicsExtractor.entity</c> sets <c>lightCoords</c>, without fog.
    /// </summary>
    public const string EntityInUiFragment = """
        #version 450 core
        in vec2 vUv;
        in vec4 vColourFront;
        in vec4 vColourBack;
        in vec4 vOverlay;

        uniform sampler2D uAtlas;
        uniform sampler2D uLightmap;

        out vec4 fragColour;

        void main() {
            vec4 colour = texture(uAtlas, vUv);
            if (colour.a < 0.1) {
                discard;
            }
            colour *= gl_FrontFacing ? vColourFront : vColourBack;
            colour.rgb = mix(vOverlay.rgb, colour.rgb, vOverlay.a);
            colour *= texelFetch(uLightmap, ivec2(15, 15), 0);
            fragColour = colour;
        }
        """;
}
