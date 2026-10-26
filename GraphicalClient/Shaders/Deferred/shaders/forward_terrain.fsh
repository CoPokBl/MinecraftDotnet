#include "common.glsl"
#include "lighting.glsl"

in vec3 vUv;
in vec3 vTint;
in vec3 vNormal;
in vec3 vLight;
in vec3 vRelative;
flat in uint vFlags;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 texel = texture(blockAtlas, vUv);
    vec3 normal = vNormal;
    if ((vFlags & 2u) != 0u) {
        normal = normalize(cross(dFdx(vRelative), dFdy(vRelative)));
        if (dot(normal, vRelative) > 0.0) {
            normal = -normal;
        }
    }
    vec3 albedo = toLinear(texel.rgb * vTint);
    vec3 colour = albedo * incomingLight(vRelative, normal, vLight.x, vLight.y, vLight.z, false);
    // A little sky reflected off water at grazing angles, so its surface reads from afar.
    if ((vFlags & 2u) != 0u) {
        float fresnel = pow(1.0 - max(dot(normal, normalize(-vRelative)), 0.0), 4.0);
        colour = mix(colour, skyLinear() * (sunDirection.w * 0.9 + 0.1), fresnel * 0.6);
    }
    fragColour = vec4(applyFog(colour, vRelative), texel.a);
}
