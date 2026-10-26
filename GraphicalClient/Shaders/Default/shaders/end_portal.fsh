#include "common.glsl"

in vec4 vClip;
in float vSpherical;
in float vCylindrical;
flat in int vLayers;

layout(location = 0) out vec4 fragColour;

// Where layer n, counted from 1, samples the star texture for a point on screen (0 to 1 across it): turned and scaled
// about the screen's corner, then slid sideways by a constant and upward with the game time, which wraps every 24000
// ticks.
vec2 layerUv(vec2 screenUv, float layer) {
    float angle = radians((layer * layer * 4321.0 + layer * 9.0) * 2.0);
    float scale = (4.5 - layer / 4.0) * 2.0;
    float gameTime = counters.w / 24000.0;
    vec2 turned = scale * vec2(screenUv.x * cos(angle) - screenUv.y * sin(angle), screenUv.x * sin(angle) + screenUv.y * cos(angle));
    vec2 slid = turned + vec2(17.0 / layer, (2.0 + layer / 1.5) * (gameTime * 1.5));
    return slid * 0.5 + 0.25;
}

// rendertype_end_portal.fsh: unlit, and fogged as anything else is.
void main() {
    vec2 screenUv = vClip.xy / vClip.w * 0.5 + 0.5;
    vec3 colour = texture(endSky, screenUv).rgb * endPortalColours[0];
    for (int i = 0; i < vLayers; i++) {
        colour += texture(endPortal, layerUv(screenUv, float(i + 1))).rgb * endPortalColours[i];
    }
    fragColour = applyFog(vec4(colour, 1.0), vSpherical, vCylindrical);
}
