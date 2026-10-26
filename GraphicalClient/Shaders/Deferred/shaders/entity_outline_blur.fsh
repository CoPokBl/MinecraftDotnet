// Vanilla's entity_outline_box_blur along BLUR_DIR, reading BLUR_INPUT through a linear filter: two taps
// between texels and half of one at the radius. The alpha is summed rather than averaged, so the edge
// thickens; an 8 bit target clamps it at 1, as vanilla's does.
in vec2 texCoord;

uniform sampler2D BLUR_INPUT;

layout(location = 0) out vec4 fragColour;

void main() {
    vec2 sampleStep = BLUR_DIR / vec2(textureSize(BLUR_INPUT, 0));
    vec4 blurred = texture(BLUR_INPUT, texCoord - sampleStep * 1.5)
        + texture(BLUR_INPUT, texCoord + sampleStep * 0.5)
        + texture(BLUR_INPUT, texCoord + sampleStep * 2.0) * 0.5;
    fragColour = vec4(blurred.rgb / 2.5, blurred.a);
}
