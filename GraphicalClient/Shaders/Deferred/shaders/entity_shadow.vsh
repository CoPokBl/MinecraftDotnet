flat out vec4 vCentreRadius;
flat out vec2 vPowerBottom;
flat out vec4 vShadowUv;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vCentreRadius = vec4(shadowCentre(), shadowRadius());
    vPowerBottom = vec2(shadowPower(), shadowBottom());
    vShadowUv = shadowUv();
}
