#include "common.glsl"

in vec3 vUv;
in vec4 vColour;
in vec3 vLight;
in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 texel = (vUv.z < 0.0 ? texture(entityAtlas, vUv.xy) : texture(blockAtlas, vUv)) * vColour;
    // The 0.1 cut vanilla's particle shader makes, for both groups.
    if (texel.a < 0.1) {
        discard;
    }
    vec3 colour = toLinear(texel.rgb) * vLight;
#ifdef TRANSLUCENT
    fragColour = vec4(applyFog(colour, vRelative), texel.a);
#else
    fragColour = vec4(applyFog(colour, vRelative), 1.0);
#endif
}
