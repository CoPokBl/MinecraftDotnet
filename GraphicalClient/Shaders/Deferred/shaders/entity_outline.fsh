// Vanilla's outline render type: the silhouette wherever the texel is not wholly transparent, flat in
// the outline colour, ignoring the tint's alpha.
in vec2 vUv;
in vec4 vColour;

layout(location = 0) out vec4 outColour;

void main() {
    if (texture(entityAtlas, vUv).a == 0.0) {
        discard;
    }
    outColour = vec4(vColour.rgb, 1.0);
}
