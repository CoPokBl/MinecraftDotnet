// Vanilla's fog.glsl, light.glsl and sample_lightmap.glsl, read from the Frame block. Colours are multiplied as
// they are, in sRGB, with no conversion anywhere: that is what vanilla does.

float linearFogValue(float vertexDistance, float fogStart, float fogEnd) {
    if (vertexDistance <= fogStart) {
        return 0.0;
    }
    else if (vertexDistance >= fogEnd) {
        return 1.0;
    }
    return (vertexDistance - fogStart) / (fogEnd - fogStart);
}

float fogSphericalDistance(vec3 position) {
    return length(position);
}

float fogCylindricalDistance(vec3 position) {
    return max(length(position.xz), abs(position.y));
}

// total_fog_value: the environmental fog by spherical distance, the render distance edge by cylindrical.
float totalFogValue(float spherical, float cylindrical) {
    return max(linearFogValue(spherical, fogDistances.x, fogDistances.y), linearFogValue(cylindrical, fogDistances.z, fogDistances.w));
}

// apply_fog: toward the fog colour by the fog value times the fog colour's alpha, leaving the alpha alone.
vec4 applyFog(vec4 colour, float spherical, float cylindrical) {
    return vec4(mix(colour.rgb, fogColour.rgb, totalFogValue(spherical, cylindrical) * fogColour.a), colour.a);
}

// sample_lightmap for a vertexLight() of sky and block levels 0 to 15: vanilla's UV2 is the level times 16, and the
// texture's x is block light, y sky light.
vec4 sampleLightmap(vec2 skyBlock) {
    return texture(lightmap, clamp(skyBlock.yx / 16.0 + 0.5 / 16.0, vec2(0.5 / 16.0), vec2(15.5 / 16.0)));
}

// minecraft_mix_light_separate: the two directional lights of Lighting.Entry.LEVEL, at 0.6 each over an ambient 0.4.
vec4 mixLightSeparate(vec2 light, vec4 colour) {
    vec2 lightValue = max(vec2(0.0), light);
    float lightAccum = min(1.0, (lightValue.x + lightValue.y) * 0.6 + 0.4);
    return vec4(colour.rgb * lightAccum, colour.a);
}

vec2 computeLight(vec3 normal) {
    return vec2(dot(diffuseLight0.xyz, normal), dot(diffuseLight1.xyz, normal));
}

// OverlayTexture's texel: rows under 8 are red at alpha 0xB3, the rest white at an alpha falling with u, where u is
// (int)(progress * 15) and v is 3 while hurt, 10 otherwise.
vec4 overlayColour(float red, float white) {
    if (red > 0.5) {
        return vec4(1.0, 0.0, 0.0, 179.0 / 255.0);
    }
    float u = floor(white * 15.0 + 0.5);
    return vec4(1.0, 1.0, 1.0, floor((1.0 - u / 15.0 * 0.75) * 255.0) / 255.0);
}
