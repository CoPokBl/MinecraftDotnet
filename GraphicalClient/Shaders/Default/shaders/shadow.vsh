out vec3 vUv;

void main() {
    gl_Position = shadowProjection * shadowView * vec4(vertexPosition(), 1.0);
#ifdef GEOMETRY_ENTITY
    vUv = vec3(vertexUv(), 0.0);
#else
    vUv = vertexUv();
#endif
}
