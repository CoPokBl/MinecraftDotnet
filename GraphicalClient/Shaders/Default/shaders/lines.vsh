out vec4 vColour;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vColour = vertexColour();
}
