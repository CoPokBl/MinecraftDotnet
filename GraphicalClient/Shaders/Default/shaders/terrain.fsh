#include "common.glsl"

in vec3 vUv;
in vec4 vColour;
// Vanilla interpolates the fog distances from the corners, over quads a block across. This mesh merges runs of
// faces into quads many blocks across, where an interpolated length overshoots the true one by blocks, so the
// distances are taken per fragment: the value vanilla's per block interpolation stays within a fraction of a block of.
in vec3 vRelative;
flat in uint vPlant;

layout(location = 0) out vec4 fragColour;

// texture_sampling.glsl's sampleNearest: the coordinate pulled toward the middle of its texel by as much as the texel
// is larger than a pixel, so the linear filter only blends across the last pixel of each texel's edge.
vec4 sampleNearest(vec3 uv) {
    vec2 pixelSize = 1.0 / vec2(textureSize(blockAtlas, 0).xy);
    vec2 du = dFdx(uv.xy);
    vec2 dv = dFdy(uv.xy);
    vec2 texelScreenSize = sqrt(du * du + dv * dv);
    vec2 uvTexelCoords = uv.xy / pixelSize;
    vec2 texelCenter = round(uvTexelCoords) - 0.5;
    vec2 texelOffset = uvTexelCoords - texelCenter;
    texelOffset = (texelOffset - 0.5) * pixelSize / texelScreenSize + 0.5;
    texelOffset = clamp(texelOffset, 0.0, 1.0);
    return textureGrad(blockAtlas, vec3((texelCenter + texelOffset) * pixelSize, uv.z), du, dv);
}

void main() {
    vec4 colour = sampleNearest(vUv) * vColour;
#ifdef CUTOUT
    // The pass draws both sides for a plant's one sided planes; anything else's back would fight its front.
    if (!gl_FrontFacing && vPlant == 0u) {
        discard;
    }
#endif
#ifdef ALPHA_CUTOUT
    if (colour.a < ALPHA_CUTOUT) {
        discard;
    }
#endif
    fragColour = applyFog(colour, fogSphericalDistance(vRelative), fogCylindricalDistance(vRelative));
}
