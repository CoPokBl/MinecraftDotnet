#include "common.glsl"

out vec4 vClip;
out float vSpherical;
out float vCylindrical;
flat out int vLayers;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vClip = gl_Position;
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vLayers = vertexPortalLayers();
}
