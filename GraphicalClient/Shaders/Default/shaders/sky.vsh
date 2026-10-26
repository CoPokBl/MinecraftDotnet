// Vanilla's sky.vsh, position_color.vsh, position_tex.vsh, position_tex_color.vsh and stars.vsh in one: the sky
// disc's fog distances are measured from the mesh's own position, before its draw's transform.
layout(location = 0) out float sphericalVertexDistance;
layout(location = 1) out float cylindricalVertexDistance;
layout(location = 2) out vec2 texCoord0;
layout(location = 3) out vec4 vertexColor;
layout(location = 4) flat out uint part;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vec3 fogPosition = vertexFogPosition();
    sphericalVertexDistance = length(fogPosition);
    cylindricalVertexDistance = max(length(fogPosition.xz), abs(fogPosition.y));
    texCoord0 = vertexUv();
    vertexColor = vertexColour();
    part = vertexSkyPart();
}
