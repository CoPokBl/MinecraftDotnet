#include "common.glsl"

in vec2 texCoord;

uniform sampler2D sceneColour;

layout(location = 0) out vec4 fragColour;

// Narkowicz's fit of the ACES filmic curve: highlights roll off instead of clipping.
vec3 tonemap(vec3 x) {
    return clamp((x * (2.51 * x + 0.03)) / (x * (2.43 * x + 0.59) + 0.14), 0.0, 1.0);
}

void main() {
    vec3 hdr = texture(sceneColour, texCoord).rgb;
    fragColour = vec4(toSrgb(tonemap(hdr)), 1.0);
}
