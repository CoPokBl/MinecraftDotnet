float hash(vec3 p) {
    p = fract(p * 0.3183099 + 0.1);
    p *= 17.0;
    return fract(p.x * p.y * p.z * (p.x + p.y + p.z));
}

// The sky in a direction, linear and unexposed.
vec3 skyRadiance(vec3 direction) {
    float up = clamp(direction.y, 0.0, 1.0);
    vec3 colour = mix(fogLinear(), skyLinear(), pow(up, 0.6));
    if (direction.y < 0.0) {
        colour = mix(fogLinear(), fogLinear() * 0.5, clamp(-direction.y * 3.0, 0.0, 1.0));
    }
    if (fogRange.w > 0.5) {
        float sun = dot(direction, sunDirection.xyz);
        colour += vec3(3.0, 2.6, 1.9) * smoothstep(0.9983, 0.9990, sun) * (1.0 - weather.x);
        colour += vec3(1.0, 0.8, 0.5) * pow(max(sun, 0.0), 32.0) * 0.35 * (1.0 - weather.x);
        colour += vec3(0.6, 0.65, 0.8) * smoothstep(0.9990, 0.9994, -sun);
        float stars = clamp(1.0 - (sunDirection.y * 2.0 + 0.25), 0.0, 1.0) * 0.5 * (1.0 - weather.x);
        if (stars > 0.0 && direction.y > 0.0 && hash(floor(direction * 180.0)) > 0.997) {
            colour += vec3(stars);
        }
    }
    return colour;
}
