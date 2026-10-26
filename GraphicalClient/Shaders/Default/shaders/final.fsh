in vec2 texCoord;

uniform sampler2D colour;

layout(location = 0) out vec4 fragColour;

void main() {
    fragColour = vec4(texelFetch(colour, ivec2(gl_FragCoord.xy), 0).rgb, 1.0);
}
