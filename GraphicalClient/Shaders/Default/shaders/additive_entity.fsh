#include "common.glsl"

in vec2 vUv;
in vec4 vColour;
in float vSpherical;
in float vCylindrical;
flat in uint vSwirl;

layout(location = 0) out vec4 fragColour;

// Drawn with ONE, ONE. The energy swirl is entity.fsh, emissive and unshaded, mixed toward the fog colour as any entity
// is and added whole; lightning and the dragon's rays are rendertype_lightning, faded by the fog in every channel and
// added by their alpha, which LIGHTNING blending takes from the faded colour as well.
void main() {
    vec4 texel = texture(entityAtlas, vUv);
    if (vSwirl != 0u) {
        if (texel.a < 0.1) {
            discard;
        }
        fragColour = vec4(applyFog(texel * vColour, vSpherical, vCylindrical).rgb, 0.0);
    }
    else {
        vec4 colour = texel * vColour * (1.0 - totalFogValue(vSpherical, vCylindrical));
        fragColour = vec4(colour.rgb * colour.a, 0.0);
    }
}
