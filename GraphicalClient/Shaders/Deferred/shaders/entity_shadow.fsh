#include "common.glsl"

flat in vec4 vCentreRadius;
flat in vec2 vPowerBottom;
flat in vec4 vShadowUv;

uniform sampler2D sceneDepth;
uniform sampler2D gNormal;
uniform sampler2D gLight;

layout(location = 0) out vec4 fragColour;

// Vanilla's round shadow, laid on whatever ground the opaque pass left inside the box under the entity:
// the shadow texture spread over twice the radius, as dark as the entity's power less half a level for each
// block the ground lies below its feet, times how bright that ground is.
void main() {
    vec2 uv = gl_FragCoord.xy * screen.zw;
    float depth = texture(sceneDepth, uv).r;
    if (depth >= 1.0) {
        discard;
    }
    vec4 world = inverseViewProjection * vec4(uv * 2.0 - 1.0, depth * 2.0 - 1.0, 1.0);
    vec3 relative = world.xyz / world.w;
    vec3 local = relative - vCentreRadius.xyz;
    float radius = vCentreRadius.w;
    if (abs(local.x) > radius || abs(local.z) > radius || local.y > 0.02 || relative.y < vPowerBottom.y) {
        discard;
    }
    vec4 light = texture(gLight, uv);
    // Entities write an alpha of a half: a shadow falls on the ground, never on a mob.
    if (light.a < 0.75) {
        discard;
    }
    float facing = smoothstep(0.5, 0.9, normalize(texture(gNormal, uv).xyz).y);
    // getMaxLocalRawBrightness, with the day's darkening, and nothing at all at 3 or under.
    float level = max(light.r * sunDirection.w, light.g) * 15.0;
    if (level <= 3.0 || facing <= 0.0) {
        discard;
    }
    // Lightmap.getBrightness: the dimension's curve, lifted by its ambient light.
    float f = level / 15.0;
    float brightness = mix(f / (4.0 - 3.0 * f), 1.0, weather.w);
    float power = vPowerBottom.x - (-local.y) * 0.5;
    vec2 st = -local.xz / (2.0 * radius) + 0.5;
    vec4 texel = texture(entityAtlas, mix(vShadowUv.xy, vShadowUv.zw, st));
    float alpha = clamp(power * 0.5 * brightness, 0.0, 1.0) * texel.a * facing * (1.0 - fogAmount(relative));
    // Vanilla blends in sRGB; this darkens the linear colour by as much as that darkens what is shown.
    alpha = 1.0 - pow(1.0 - alpha, 2.2);
    fragColour = vec4(toLinear(texel.rgb), alpha);
}
