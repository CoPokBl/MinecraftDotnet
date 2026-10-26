#include "common.glsl"

out vec3 vUv;
out vec4 vColour;
out vec3 vRelative;
flat out uint vPlant;

// Vanilla's terrain.vsh: the vertex colour is the tint, darkened by the corner's occlusion and the face's shade, times
// the lightmap, sampled here per vertex and interpolated, as vanilla does.
void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vRelative = position;
    vColour = vec4(vertexTint() * vertexOcclusion() * vertexFaceShade(), 1.0) * sampleLightmap(vertexLight());
    vUv = vertexUv();
    vPlant = vertexIsPlant() ? 1u : 0u;
}
