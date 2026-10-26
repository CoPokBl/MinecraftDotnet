out vec2 vUv;
out vec4 vColour;
out vec2 vLight;
out vec3 vNormal;
out vec3 vRelative;
out vec2 vOverlay;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vColour = vertexColour();
    vLight = vertexLight() / 15.0;
    vNormal = vertexNormal();
    vRelative = position;
    vOverlay = vec2(vertexRedOverlay(), vertexWhiteOverlay());
}
