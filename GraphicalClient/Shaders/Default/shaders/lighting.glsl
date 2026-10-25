// Shared by the deferred pass and the forward translucent pass, so water and land agree.

uniform sampler2DShadow shadowMap;

#ifdef ENTITY_SHADOWS
uniform sampler2DShadow entityShadowMap;

// Entities, drawn into a map of their own every frame with the same matrices. Four gathers take the 4x4
// texels the 3x3 filter below can reach; most pixels have no entity shadow near and stop there.
float entityShadow(vec3 coords) {
    vec2 texel = 1.0 / vec2(textureSize(entityShadowMap, 0));
    float depth = coords.z - 0.0004;
    vec4 near = textureGather(entityShadowMap, coords.xy + vec2(-1.0, -1.0) * texel, depth)
        + textureGather(entityShadowMap, coords.xy + vec2(1.0, -1.0) * texel, depth)
        + textureGather(entityShadowMap, coords.xy + vec2(-1.0, 1.0) * texel, depth)
        + textureGather(entityShadowMap, coords.xy + vec2(1.0, 1.0) * texel, depth);
    if (dot(near, vec4(1.0)) > 15.99) {
        return 1.0;
    }
    float lit = 0.0;
    for (int x = -1; x <= 1; x++) {
        for (int y = -1; y <= 1; y++) {
            lit += texture(entityShadowMap, vec3(coords.xy + vec2(x, y) * texel, depth));
        }
    }
    return lit / 9.0;
}
#endif

// Percentage closer filtering over a 5x5 grid of comparisons, with the hardware's bilinear
// comparison inside each, which hides the texel edges of the map.
float shadowFactor(vec3 relative, vec3 normal) {
    vec3 light = lightDirection();
    float slope = 1.0 - max(dot(normal, light), 0.0);
    vec3 offsetPosition = relative + normal * (0.04 + 0.08 * slope);
    vec4 clip = shadowProjection * shadowView * vec4(offsetPosition, 1.0);
    vec3 coords = clip.xyz / clip.w * 0.5 + 0.5;
    if (any(lessThan(coords, vec3(0.0))) || any(greaterThan(coords, vec3(1.0)))) {
        return 1.0;
    }
    vec2 texel = 1.0 / vec2(textureSize(shadowMap, 0));
    float lit = 0.0;
    for (int x = -2; x <= 2; x++) {
        for (int y = -2; y <= 2; y++) {
            lit += texture(shadowMap, vec3(coords.xy + vec2(x, y) * texel, coords.z - 0.0004));
        }
    }
    lit /= 25.0;
#ifdef ENTITY_SHADOWS
    lit = min(lit, entityShadow(coords));
#endif
    // Fade out toward the edge of the shadowed area instead of stopping at a line.
    float edge = max(abs(coords.x - 0.5), abs(coords.y - 0.5)) * 2.0;
    return mix(lit, 1.0, smoothstep(0.85, 1.0, edge));
}

// What light falls on a surface. Sky and block levels are 0 to 1, from the server's light engine;
// the sun's contribution needs a view of the sky, which the sky level says.
vec3 incomingLight(vec3 relative, vec3 normal, float skyLevel, float blockLevel, float occlusion, bool plant) {
    float day = clamp((sunDirection.w - 0.2) / 0.8, 0.0, 1.0);
    vec3 light = lightDirection();
    bool hasSky = fogRange.w > 0.5;

    float elevation = sunDirection.y;
    vec3 sunColour = mix(vec3(1.0, 0.5, 0.3), vec3(1.4, 1.32, 1.2), smoothstep(0.0, 0.35, elevation));
    vec3 moonColour = vec3(0.10, 0.13, 0.22);
    vec3 direct = elevation >= 0.0 ? sunColour * (1.0 - weather.x * 0.75) : moonColour;

    float facing = plant ? 0.6 : max(dot(normal, light), 0.0);
    // The shadow map does not hold water, and a cave's mouth leaks past its texels; a low sky level
    // says the sun is not reaching here either way.
    float openness = smoothstep(0.5, 1.0, skyLevel);
    float shadow = hasSky && openness > 0.0 && facing > 0.0 ? shadowFactor(relative, normal) : 0.0;
    vec3 sun = hasSky ? direct * facing * shadow * openness : vec3(0.0);

    // The sky's colour, mostly desaturated: a fully blue fill reads as tinted rather than shaded.
    vec3 sky = skyLinear();
    vec3 skyFill = mix(vec3(dot(sky, vec3(0.2126, 0.7152, 0.0722))), sky, 0.35) * 0.75 + vec3(0.08);
    vec3 skyAmbient = mix(vec3(0.02, 0.025, 0.05), skyFill, day);
    // Without a sky the dimension's ambient level is all there is, so it is given more weight.
    vec3 ambient = hasSky ? skyAmbient * skyLevel * skyLevel + vec3(weather.w + 0.012) : vec3(weather.w * 1.5 + 0.12);
    float up = normal.y * 0.5 + 0.5;
    ambient *= mix(0.6, 1.0, up);

    // Block light, warm, falling off faster than the level so a torch reads as a pool of light.
    vec3 block = vec3(1.0, 0.68, 0.38) * pow(blockLevel, 2.6) * 2.4;

    return sun + (ambient + block) * occlusion;
}
