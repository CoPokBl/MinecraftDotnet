out vec2 vUv;
out vec4 vColour;
out vec2 vLight;
out vec3 vNormal;
out vec2 vOverlay;

// The glint passes test for equal depth against what this writes.
invariant gl_Position;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vUv = vertexUv();
    vColour = vertexColour();
    vLight = vertexLight() / 15.0;
    vNormal = vertexNormal();
    vOverlay = vec2(vertexRedOverlay(), vertexWhiteOverlay());
}
