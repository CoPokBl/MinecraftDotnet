#include "common.glsl"
#include "lighting.glsl"

in vec2 vUv;
in vec4 vColour;
in vec2 vLight;
in vec3 vNormal;
in vec3 vRelative;
in vec2 vOverlay;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 texel = texture(entityAtlas, vUv) * vColour;
    if (texel.a < 0.004) {
        discard;
    }
    texel.rgb = mix(texel.rgb, vec3(1.0, 0.0, 0.0), vOverlay.x * 0.3);
    texel.rgb = mix(texel.rgb, vec3(1.0), vOverlay.y);
    vec3 normal = normalize(vNormal);
    if (!gl_FrontFacing) {
        normal = -normal;
    }
    vec3 colour = toLinear(texel.rgb) * incomingLight(vRelative, normal, vLight.x, vLight.y, 1.0, false);
    fragColour = vec4(applyFog(colour, vRelative), texel.a);
}
