#include "common.glsl"

out vec3 vUv;
out vec4 vColour;
out float vSpherical;
out float vCylindrical;

// Vanilla's particle.vsh: the colour times the lightmap at the particle's light, a full bright one included.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
    vColour = vertexColour() * sampleLightmap(vertexLight());
}
