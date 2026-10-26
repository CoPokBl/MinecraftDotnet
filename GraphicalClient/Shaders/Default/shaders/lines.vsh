#include "common.glsl"

out vec4 vColour;
out float vSpherical;
out float vCylindrical;

// Vanilla's rendertype_lines: each end pulled a 256th of the way toward the camera, so a line on a surface wins
// against it, then pushed sideways on screen by half the width either way.
const float VIEW_SHRINK = 1.0 - (1.0 / 256.0);

void main() {
    vec3 position = vertexPosition();
    vec4 start = viewProjection * vec4(position * VIEW_SHRINK, 1.0);
    vec4 end = viewProjection * vec4((position + vertexLineDirection()) * VIEW_SHRINK, 1.0);
    vec3 ndcStart = start.xyz / start.w;
    vec3 ndcEnd = end.xyz / end.w;
    vec2 direction = normalize((ndcEnd.xy - ndcStart.xy) * screen.xy);
    vec2 offset = vec2(-direction.y, direction.x) * vertexLineWidth() / screen.xy;
    if (offset.x < 0.0) {
        offset = -offset;
    }
    gl_Position = vec4((ndcStart + vec3(offset * vertexLineSide(), 0.0)) * start.w, start.w);
    vSpherical = fogSphericalDistance(position);
    vCylindrical = fogCylindricalDistance(position);
    vColour = vertexColour();
}
