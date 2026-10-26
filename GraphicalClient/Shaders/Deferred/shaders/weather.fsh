#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in vec3 vLight;
in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 texel = texture(weatherTexture, vUv) * vColour;
    // The cut of vanilla's particle shader, which its weather is drawn with.
    if (texel.a < 0.1) {
        discard;
    }
    fragColour = vec4(applyFog(toLinear(texel.rgb) * vLight, vRelative), texel.a);
}
