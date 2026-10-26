#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

// Vanilla's text.fsh: see through text is neither lit nor fogged.
void main() {
    vec4 colour = texture(entityAtlas, vUv) * vColour;
    if (colour.a < 0.1) {
        discard;
    }
#ifdef SEE_THROUGH
    fragColour = colour;
#else
    fragColour = applyFog(colour, vSpherical, vCylindrical);
#endif
}
