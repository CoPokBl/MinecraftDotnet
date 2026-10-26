#include "common.glsl"

in vec2 vUv;
in vec4 vColourFront;
in vec4 vColourBack;
in vec4 vLightmap;
in vec4 vOverlay;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

// Vanilla's entity.fsh and item.fsh: the cut is on the texel's own alpha, before the tint, at 0.1 as every cut out,
// translucent and item pipeline has it. ENTITY_SOLID has no cut, which only differs where its texture has clear texels.
void main() {
    vec4 colour = texture(entityAtlas, vUv);
    if (colour.a < 0.1) {
        discard;
    }
    colour *= gl_FrontFacing ? vColourFront : vColourBack;
    colour.rgb = mix(vOverlay.rgb, colour.rgb, vOverlay.a);
    colour *= vLightmap;
    fragColour = applyFog(colour, vSpherical, vCylindrical);
}
