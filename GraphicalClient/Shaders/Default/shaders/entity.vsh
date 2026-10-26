#include "common.glsl"

out vec2 vUv;
out vec4 vColourFront;
out vec4 vColourBack;
out vec4 vLightmap;
out vec4 vOverlay;
out float vSpherical;
out float vCylindrical;

// The glint passes test for equal depth against what this writes.
invariant gl_Position;

// Vanilla's entity.vsh with PER_FACE_LIGHTING: a face seen from behind is shaded as if it faced the other way. The
// pipelines without it cull, so their back faces are never seen and the two agree. EMISSIVE leaves out the lightmap
// and NO_CARDINAL_LIGHTING the two lights.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vec4 colour = vertexColour();
    if (vertexIsUnshaded()) {
        vColourFront = colour;
        vColourBack = colour;
    }
    else {
        vec2 light = computeLight(vertexNormal());
        vColourFront = mixLightSeparate(light, colour);
        vColourBack = mixLightSeparate(-light, colour);
    }
    vLightmap = vertexIsEmissive() ? vec4(1.0) : sampleLightmap(vertexLight());
    vOverlay = overlayColour(vertexRedOverlay(), vertexWhiteOverlay());
    vUv = vertexUv();
}
