out vec2 vUv;
out float vStrength;
out float vArmor;
out vec3 vRelative;

// The equal depth test only holds if this lands exactly where gbuffer_entity put the same corner.
invariant gl_Position;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    vUv = vertexUv();
    vStrength = vertexColour().r;
    vArmor = vertexIsArmorGlint() ? 1.0 : 0.0;
    vRelative = position;
}
