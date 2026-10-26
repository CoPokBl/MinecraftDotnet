flat out vec4 vCentreRadius;
flat out vec3 vPowerBottomBrightness;
flat out vec4 vShadowUv;

void main() {
    gl_Position = viewProjection * vec4(vertexPosition(), 1.0);
    vCentreRadius = vec4(shadowCentre(), shadowRadius());
    vPowerBottomBrightness = vec3(shadowPower(), shadowBottom(), shadowBrightness());
    vShadowUv = shadowUv();
}
