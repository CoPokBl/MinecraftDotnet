#include "common.glsl"

out vec2 vUv;
out vec4 vColour;
out float vSpherical;
out float vCylindrical;
flat out uint vSwirl;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
    vColour = vertexColour();
    vSwirl = vertexIsEmissive() ? 1u : 0u;
}
