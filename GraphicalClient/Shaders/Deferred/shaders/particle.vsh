#include "common.glsl"
#include "lighting.glsl"

out vec3 vUv;
out vec4 vColour;
out vec3 vLight;
out vec3 vRelative;

// Lit once per corner rather than per pixel: a particle is small, and vanilla lights each one as a whole.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vColour = vertexColour();
    vRelative = position;
    vec2 light = vertexLight() / 15.0;
    vLight = vertexIsEmissive() ? vec3(1.0) : incomingLight(position, vertexNormal(), light.x, light.y, 1.0, true);
}
