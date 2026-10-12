in vec4 vColour;

layout(location = 0) out vec4 fragColour;

void main() {
    fragColour = vec4(pow(vColour.rgb, vec3(2.2)), vColour.a);
}
