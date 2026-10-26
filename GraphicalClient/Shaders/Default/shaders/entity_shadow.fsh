#include "common.glsl"

flat in vec4 vCentreRadius;
flat in vec3 vPowerBottomBrightness;
flat in vec4 vShadowUv;

uniform sampler2D depth;

layout(location = 0) out vec4 fragColour;

vec3 relativeAt(ivec2 pixel) {
    float d = texelFetch(depth, pixel, 0).r;
    vec4 world = inverseViewProjection * vec4((vec2(pixel) + 0.5) * screen.zw * 2.0 - 1.0, d * 2.0 - 1.0, 1.0);
    return world.xyz / world.w;
}

// The step to a neighbouring pixel on the same surface: whichever side is nearer in depth, so an edge does not bend
// the normal of the face it bounds.
vec3 alongSurface(ivec2 pixel, ivec2 step, vec3 centre) {
    vec3 forward = relativeAt(pixel + step) - centre;
    vec3 backward = centre - relativeAt(pixel - step);
    return dot(forward, forward) < dot(backward, backward) ? forward : backward;
}

// Vanilla's round shadow: extractShadow lays a quad on the top of each full block under the entity, the shadow texture
// spread over twice the radius, as dark as the entity's power less half a level for each block the top lies below its
// feet, times the brightness above it, and rendertype_entity_shadow draws it fogged. Here the tops are found in the
// depth already drawn: a surface facing up at a whole block's height.
void main() {
    ivec2 pixel = ivec2(gl_FragCoord.xy);
    if (texelFetch(depth, pixel, 0).r >= 1.0) {
        discard;
    }
    vec3 relative = relativeAt(pixel);
    vec3 local = relative - vCentreRadius.xyz;
    float radius = vCentreRadius.w;
    if (abs(local.x) > radius || abs(local.z) > radius || local.y > 0.02 || relative.y < vPowerBottomBrightness.y) {
        discard;
    }
    float worldY = relative.y + cameraPosition.y;
    if (abs(worldY - round(worldY)) > 0.01) {
        discard;
    }
    vec3 normal = normalize(cross(alongSurface(pixel, ivec2(1, 0), relative), alongSurface(pixel, ivec2(0, 1), relative)));
    if (abs(normal.y) < 0.9) {
        discard;
    }
    float powerAtDepth = vPowerBottomBrightness.x - (-local.y) * 0.5;
    float alpha = clamp(powerAtDepth * 0.5 * vPowerBottomBrightness.z, 0.0, 1.0);
    vec2 st = clamp(-local.xz / (2.0 * radius) + 0.5, 0.0, 1.0);
    vec4 colour = texture(entityAtlas, mix(vShadowUv.xy, vShadowUv.zw, st)) * vec4(1.0, 1.0, 1.0, alpha);
    fragColour = applyFog(colour, fogSphericalDistance(relative), fogCylindricalDistance(relative));
}
