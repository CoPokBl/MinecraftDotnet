#include "common.glsl"

in vec2 vUv;
in float vStrength;
in float vArmor;
in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 colour = vArmor > 0.5 ? texture(glintArmor, vUv) : texture(glintItem, vUv);
    if (colour.a < 0.1) {
        discard;
    }
    // Vanilla's glint.fsh fades by the fog and the strength, and its blend adds the result times itself
    // to the display space scene. The scene here is linear, where a display space step is about the same
    // size around mid grey, so the sum is added as it is: brighter than vanilla's over dark surfaces,
    // fainter over bright ones.
    vec3 glint = colour.rgb * vStrength * (1.0 - fogAmount(vRelative));
    fragColour = vec4(glint * glint, 0.0);
}
