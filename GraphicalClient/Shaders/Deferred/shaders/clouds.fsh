#include "common.glsl"

in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

// Vanilla's shade for each face: down, up, north, south, west, east. The flat layer is all top.
const float faceShades[6] = float[6](0.7, 1.0, 0.8, 0.8, 0.9, 0.9);

void main() {
    CloudHit hit;
    if (!cloudTrace(normalize(vRelative), hit)) {
        discard;
    }
    vec4 colour = cloudColour();
    float shade = cloudIsFlat() ? 1.0 : faceShades[hit.face];
    // A touch of the sun on the faces it reaches by day, and its warmth near the horizon.
    float sunlit = max(dot(hit.normal, sunDirection.xyz), 0.0) * clamp(sunDirection.y * 4.0, 0.0, 1.0) * (1.0 - weather.x);
    vec3 sunTint = mix(vec3(1.0, 0.75, 0.55), vec3(1.0), smoothstep(0.0, 0.3, sunDirection.y));
    vec3 linear = toLinear(colour.rgb * shade) * (1.0 + sunlit * 0.15 * sunTint);
    float fade = 1.0 - clamp(hit.distance / cloudFadeDistance(), 0.0, 1.0);
    vec4 clip = viewProjection * vec4(hit.position, 1.0);
    // Past the far plane the depth is held just short of the cleared depth, so the cloud still passes against the sky.
    gl_FragDepth = min(clip.z / clip.w * 0.5 + 0.5, 0.99999994);
    fragColour = vec4(linear, colour.a * fade);
}
