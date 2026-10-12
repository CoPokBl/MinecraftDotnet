#include "common.glsl"
#include "sky.glsl"
#include "lighting.glsl"

in vec2 texCoord;

uniform sampler2D gAlbedo;
uniform sampler2D gNormal;
uniform sampler2D gLight;
uniform sampler2D sceneDepth;

layout(location = 0) out vec4 fragColour;

void main() {
    float depth = texture(sceneDepth, texCoord).r;
    vec4 world = inverseViewProjection * vec4(texCoord * 2.0 - 1.0, depth * 2.0 - 1.0, 1.0);
    vec3 relative = world.xyz / world.w;
    if (depth >= 1.0) {
        fragColour = vec4(skyRadiance(normalize(relative)), 1.0);
        return;
    }

    vec3 albedo = toLinear(texture(gAlbedo, texCoord).rgb);
    vec4 normalOcclusion = texture(gNormal, texCoord);
    vec4 light = texture(gLight, texCoord);
    vec3 normal = normalize(normalOcclusion.xyz);
    vec3 colour = albedo * incomingLight(relative, normal, light.r, light.g, normalOcclusion.w, light.b > 0.5);
    fragColour = vec4(applyFog(colour, relative), 1.0);
}
