#include "common.glsl"

in vec4 vClip;
in vec3 vRelative;
flat in int vLayers;

layout(location = 0) out vec4 fragColour;

// Where layer n, counted from 1, samples the star texture for a point on screen (0 to 1 across it):
// turned and scaled about the screen's corner, then slid sideways by a constant and upward with the
// game time, which wraps every 24000 ticks.
vec2 layerUv(vec2 screenUv, float layer) {
    float angle = radians((layer * layer * 4321.0 + layer * 9.0) * 2.0);
    float scale = (4.5 - layer / 4.0) * 2.0;
    float gameTime = counters.w / 24000.0;
    vec2 turned = scale * vec2(screenUv.x * cos(angle) - screenUv.y * sin(angle), screenUv.x * sin(angle) + screenUv.y * cos(angle));
    vec2 slid = turned + vec2(17.0 / layer, (2.0 + layer / 1.5) * (gameTime * 1.5));
    return slid * 0.5 + 0.25;
}

// The inverse of the final pass's tonemap, so the colour vanilla puts on screen is the one that comes out.
vec3 untonemap(vec3 y) {
    y = min(y, vec3(0.999));
    vec3 a = 2.43 * y - 2.51;
    vec3 b = 0.59 * y - 0.03;
    vec3 c = 0.14 * y;
    return (-b - sqrt(b * b - 4.0 * a * c)) / (2.0 * a);
}

void main() {
    vec2 screenUv = vClip.xy / vClip.w * 0.5 + 0.5;
    vec3 colour = texture(endSky, screenUv).rgb * endPortalColours[0];
    for (int i = 0; i < vLayers; i++) {
        colour += texture(endPortal, layerUv(screenUv, float(i + 1))).rgb * endPortalColours[i];
    }
    fragColour = vec4(applyFog(untonemap(toLinear(colour)), vRelative), 1.0);
}
