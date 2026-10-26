in vec2 vUv;
in vec4 vColour;
in vec2 vLight;
in vec3 vNormal;
in vec2 vOverlay;

layout(location = 0) out vec4 outAlbedo;
layout(location = 1) out vec4 outNormal;
layout(location = 2) out vec4 outLight;

void main() {
    vec4 colour = texture(entityAtlas, vUv) * vColour;
    if (colour.a < 0.1) {
        discard;
    }
    // Vanilla's overlay texture: a hurt entity is 30% red, a creeper about to blow flashes white.
    colour.rgb = mix(colour.rgb, vec3(1.0, 0.0, 0.0), vOverlay.x * 0.3);
    colour.rgb = mix(colour.rgb, vec3(1.0), vOverlay.y);
    vec3 normal = normalize(vNormal);
    // A plane seen from behind faces away; light it as its front.
    if (!gl_FrontFacing) {
        normal = -normal;
    }
    outAlbedo = vec4(colour.rgb, 1.0);
    outNormal = vec4(normal, 1.0);
    outLight = vec4(vLight, 0.0, 0.5);
}
