// Blended over the finished image as vanilla blends its outline target over the main one, by the alpha.
in vec2 texCoord;

uniform sampler2D outlineSwap;

layout(location = 0) out vec4 fragColour;

void main() {
    fragColour = texture(outlineSwap, texCoord);
}
