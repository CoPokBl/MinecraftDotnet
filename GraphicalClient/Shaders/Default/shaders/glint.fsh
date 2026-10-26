#include "common.glsl"

in vec2 vUv;
in float vStrength;
flat in uint vArmor;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

// Vanilla's glint.fsh under GLINT blending, which adds the source colour times itself: the texel faded by the fog and
// the strength, then squared. Items and armour draw their glint inside item.fsh and entity.fsh instead, adding the
// square before the fog, which comes to the same wherever the fog is clear.
void main() {
    vec4 colour = vArmor != 0u ? texture(glintArmor, vUv) : texture(glintItem, vUv);
    if (colour.a < 0.1) {
        discard;
    }
    vec3 glint = colour.rgb * (1.0 - totalFogValue(vSpherical, vCylindrical)) * vStrength;
    fragColour = vec4(glint * glint, 0.0);
}
