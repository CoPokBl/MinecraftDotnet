out vec3 vUv;
out vec3 vTint;
out vec3 vNormal;
out vec3 vLight;
out vec3 vRelative;
flat out uint vFlags;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vTint = vertexTint();
    vNormal = vertexNormal();
    vLight = vec3(vertexLight() / 15.0, vertexOcclusion());
    vRelative = position;
    vFlags = (vertexIsPlant() ? 1u : 0u) | (vertexIsFluidSurface() ? 2u : 0u);
}
