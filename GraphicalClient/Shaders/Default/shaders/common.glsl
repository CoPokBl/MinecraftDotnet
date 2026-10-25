vec3 toLinear(vec3 srgb) {
    return pow(srgb, vec3(2.2));
}

vec3 toSrgb(vec3 linear) {
    return pow(linear, vec3(1.0 / 2.2));
}

// What rain adds to the haze: vanilla's world fog, linear out to 1024 blocks, pulled in by 160 blocks at its
// start and 256 at its end, weighted by the rain, by how open to the sky the eye is and, at half, where the
// biome has no rain.
float rainFog(float distance) {
    float amount = weather.x * clamp((eyeLight.w * 15.0 - 8.0) / 7.0, 0.0, 1.0) * (biome.z > 0.5 ? 1.0 : 0.5);
    if (amount <= 0.0) {
        return 0.0;
    }
    float start = -160.0 * amount, end = 1024.0 - 256.0 * amount;
    return clamp((distance - start) / (end - start), 0.0, 1.0) - clamp(distance / 1024.0, 0.0, 1.0);
}

// Fog by cylindrical distance, so looking up does not clear it: a light haze that builds with
// distance, then the render distance edge fading out over its last stretch.
float fogAmount(vec3 relative) {
    float distance = max(length(relative.xz), abs(relative.y));
    float edge = clamp((distance - fogRange.x) / (fogRange.y - fogRange.x), 0.0, 1.0);
    float haze = 1.0 - exp(-distance / (fogRange.z * 3.0));
    return max(edge * edge, haze * 0.5 + rainFog(length(relative)));
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
