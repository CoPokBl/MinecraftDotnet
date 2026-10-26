#include "common.glsl"
#include "lighting.glsl"

out vec2 vUv;
out vec4 vColour;
out vec3 vLight;
out vec3 vRelative;

// Lit per corner, as a particle is: a column is lit by the light where it meets the ground or the camera's height.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vColour = vertexColour();
    vRelative = position;
    vec2 light = vertexLight() / 15.0;
    vLight = incomingLight(position, vec3(0.0, 1.0, 0.0), light.x, light.y, 1.0, true);
}
