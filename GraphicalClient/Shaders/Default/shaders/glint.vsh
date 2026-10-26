#include "common.glsl"

out vec2 vUv;
out float vStrength;
flat out uint vArmor;
out float vSpherical;
out float vCylindrical;

// The equal depth test only holds if this lands exactly where entity.vsh put the same corner.
invariant gl_Position;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
    vStrength = vertexColour().r;
    vArmor = vertexIsArmorGlint() ? 1u : 0u;
}
