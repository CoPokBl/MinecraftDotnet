vec3 toLinear(vec3 srgb) {
    return pow(srgb, vec3(2.2));
}

vec3 toSrgb(vec3 linear) {
    return pow(linear, vec3(1.0 / 2.2));
}

// Fog by cylindrical distance, so looking up does not clear it: a light haze that builds with
// distance, then the render distance edge fading out over its last stretch.
float fogAmount(vec3 relative) {
    float distance = max(length(relative.xz), abs(relative.y));
    float edge = clamp((distance - fogRange.x) / (fogRange.y - fogRange.x), 0.0, 1.0);
    float haze = 1.0 - exp(-distance / (fogRange.z * 3.0));
    return max(edge * edge, haze * 0.5);
}

// Toward the sun by day and the moon by night, kept above the horizon as the shadow camera is.
vec3 lightDirection() {
    vec3 light = sunDirection.y >= 0.0 ? sunDirection.xyz : -sunDirection.xyz;
    if (light.y < 0.15) {
        light = normalize(vec3(light.x, 0.15, light.z));
    }
    return light;
}

vec3 skyLinear() { return toLinear(skyColour.rgb); }
vec3 fogLinear() { return toLinear(fogColour.rgb); }

vec3 applyFog(vec3 colour, vec3 relative) {
    if (cameraPosition.w > 0.5) {
        float underwater = clamp(length(relative) / 48.0, 0.0, 1.0);
        return mix(colour, fogLinear(), underwater);
    }
    return mix(colour, fogLinear(), fogAmount(relative));
}
