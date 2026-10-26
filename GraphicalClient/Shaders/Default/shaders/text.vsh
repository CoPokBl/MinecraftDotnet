#include "common.glsl"

out vec2 vUv;
out vec4 vColour;
out float vSpherical;
out float vCylindrical;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    // A display's background, shadows and glyphs lie in one plane; each layer is pulled a few depth steps over the one
    // under it, which with lequal and the order they are drawn in keeps them from fighting.
    gl_Position.z -= vertexTextLayer() * 1.5e-6 * gl_Position.w;
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
#ifdef SEE_THROUGH
    vColour = vertexColour();
#else
    vColour = vertexColour() * sampleLightmap(vertexLight());
#endif
}
