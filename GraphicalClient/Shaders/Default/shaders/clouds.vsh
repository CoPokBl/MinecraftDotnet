out vec3 vRelative;

void main() {
    vec3 position = vertexPosition();
    vRelative = position;
    gl_Position = viewProjection * vec4(position, 1.0);
}
