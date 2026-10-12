out vec4 vClip;
out vec3 vRelative;
flat out int vLayers;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vClip = gl_Position;
    vRelative = position;
    vLayers = vertexPortalLayers();
}
