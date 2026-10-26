#include "common.glsl"

in vec2 vUv;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

// rendertype_crumbling.fsh, under the doubleMultiply blend vanilla's DST_COLOR, SRC_COLOR comes to. The fog mixes the
// texel toward the fog colour, so far off cracks tint what is under them rather than vanishing.
void main() {
    vec4 colour = texture(entityAtlas, vUv);
    if (colour.a < 0.1) {
        discard;
    }
    fragColour = applyFog(colour, vSpherical, vCylindrical);
}
