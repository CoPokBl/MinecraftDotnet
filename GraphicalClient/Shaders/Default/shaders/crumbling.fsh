in vec2 vUv;

layout(location = 0) out vec4 fragColour;

void main() {
    vec4 colour = texture(entityAtlas, vUv);
    if (colour.a < 0.1) {
        discard;
    }
    // Vanilla blends twice the texel times the scene in display space. The scene here is linear, so
    // the factor is taken to linear too, which keeps a mid grey texel leaving the scene unchanged.
    fragColour = vec4(pow(2.0 * colour.rgb, vec3(2.2)), 1.0);
}
