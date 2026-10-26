#include "common.glsl"

in vec3 vRelative;

layout(location = 0) out vec4 fragColour;

// Vanilla's clouds.vsh face colours: down, up, north, south, west, east. The flat layer is all top.
const float faceShades[6] = float[6](0.7, 1.0, 0.8, 0.8, 0.9, 0.9);

// Vanilla's clouds.fsh: the face's shade times the cloud colour, unfogged, its alpha fading out linearly to the cloud
// fog end. Vanilla interpolates the distance between a face's corners; here it is the hit's own, which differs by
// under a block across the far faces.
void main() {
    CloudHit hit;
    if (!cloudTrace(normalize(vRelative), hit)) {
        discard;
    }
    float shade = cloudIsFlat() ? 1.0 : faceShades[hit.face];
    vec4 colour = vec4(vec3(shade), 1.0) * cloudColour();
    colour.a *= 1.0 - linearFogValue(hit.distance, 0.0, fogSkyClouds.y);
    vec4 clip = viewProjection * vec4(hit.position, 1.0);
    // Past the far plane the depth is held just short of the cleared depth, so the cloud still passes against the sky.
    gl_FragDepth = min(clip.z / clip.w * 0.5 + 0.5, 0.99999994);
    fragColour = colour;
}
