#include "common.glsl"

out vec2 vUv;
out vec4 vColour;
out float vSpherical;
out float vCylindrical;

// WeatherEffectRenderer draws with the particle shader: the colour times the lightmap at the column's light.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vUv = vertexUv();
    vColour = vertexColour() * sampleLightmap(vertexLight());
}
