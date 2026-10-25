#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in vec3 vLight;
in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 colour = texture(entityAtlas, vUv) * vColour;
    // Vanilla's text and text background shaders cut at a tenth.
    if (colour.a < 0.1) {
        discard;
    }
    vec3 linear = toLinear(colour.rgb * vLight);
#ifdef SEE_THROUGH
    fragColour = vec4(linear, colour.a);
#else
    fragColour = vec4(applyFog(linear, vRelative), colour.a);
#endif
}
