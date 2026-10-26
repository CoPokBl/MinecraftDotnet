#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 texel = texture(entityAtlas, vUv);
    if (texel.a < 0.1) {
        discard;
    }
    // Unlit, and faded with the fog rather than mixed toward it, which an added colour cannot be.
    vec3 colour = toLinear(texel.rgb * vColour.rgb) * vColour.a;
    fragColour = vec4(colour * (1.0 - fogAmount(vRelative)), 0.0);
}
