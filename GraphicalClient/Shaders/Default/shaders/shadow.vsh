out vec3 vUv;

void main() {
    gl_Position = shadowProjection * shadowView * vec4(vertexPosition(), 1.0);
    vUv = vertexUv();
}
