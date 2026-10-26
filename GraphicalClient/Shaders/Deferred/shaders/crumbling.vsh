out vec2 vUv;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vUv = vertexUv();
}
