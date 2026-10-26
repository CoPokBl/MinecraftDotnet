#include "common.glsl"

in vec3 vUv;
in vec4 vColour;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 colour = (vUv.z < 0.0 ? texture(entityAtlas, vUv.xy) : texture(blockAtlas, vUv)) * vColour;
    if (colour.a < 0.1) {
        discard;
    }
    fragColour = applyFog(colour, vSpherical, vCylindrical);
}
