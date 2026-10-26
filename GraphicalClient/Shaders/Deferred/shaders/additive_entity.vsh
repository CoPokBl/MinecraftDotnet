out vec2 vUv;
out vec4 vColour;
out vec3 vRelative;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vColour = vertexColour();
    vRelative = position;
}
