#include "common.glsl"

out vec2 vUv;
out float vSpherical;
out float vCylindrical;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
}
