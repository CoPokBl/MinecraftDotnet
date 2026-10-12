in vec3 vUv;
in vec3 vTint;
in vec3 vNormal;
in vec3 vLight;
in vec3 vRelative;
flat in uint vFlags;

layout(location = 0) out vec4 outAlbedo;
layout(location = 1) out vec4 outNormal;
layout(location = 2) out vec4 outLight;

void main() {
    vec4 texel = texture(blockAtlas, vUv);
#ifdef ALPHA_TEST
    if (texel.a < 0.5) {
        discard;
    }
#endif
    vec3 normal = vNormal;
    if ((vFlags & 2u) != 0u) {
        normal = normalize(cross(dFdx(vRelative), dFdy(vRelative)));
    }
    // Plants are lit as if facing up, so a crossed pair of planes does not light unevenly.
    float plant = (vFlags & 1u) != 0u ? 1.0 : 0.0;
    if (plant > 0.5) {
        normal = vec3(0.0, 1.0, 0.0);
    }
    outAlbedo = vec4(texel.rgb * vTint, 1.0);
    outNormal = vec4(normal, vLight.z);
    outLight = vec4(vLight.x, vLight.y, plant, 1.0);
}
