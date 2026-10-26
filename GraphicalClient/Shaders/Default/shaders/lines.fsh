#include "common.glsl"

in vec4 vColour;
in float vSpherical;
in float vCylindrical;

layout(location = 0) out vec4 fragColour;

void main() {
    fragColour = applyFog(vColour, vSpherical, vCylindrical);
}
