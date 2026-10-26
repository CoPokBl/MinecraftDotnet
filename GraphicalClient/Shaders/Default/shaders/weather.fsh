#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 colour = texture(weatherTexture, vUv) * vColour;
    if (colour.a < 0.1) {
        discard;
    }
    fragColour = applyFog(colour, vSpherical, vCylindrical);
}
