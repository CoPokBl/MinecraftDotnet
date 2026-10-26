// The fragment stages of vanilla's sky pipelines, each part's blend written premultiplied for the pass's
// "premultiplied" blend: none for the discs, TRANSLUCENT for the sunrise and the end sky, and OVERLAY, which adds
// the colour by its alpha and leaves the target's alpha alone, for the sun, the moon, the stars and the end flash.
layout(location = 0) in float sphericalVertexDistance;
layout(location = 1) in float cylindricalVertexDistance;
layout(location = 2) in vec2 texCoord0;
layout(location = 3) in vec4 vertexColor;
layout(location = 4) flat in uint part;

layout(location = 0) out vec4 fragColor;

float linearFogValue(float vertexDistance, float fogStart, float fogEnd) {
    if (vertexDistance <= fogStart) {
        return 0.0;
    }
    else if (vertexDistance >= fogEnd) {
        return 1.0;
    }
    return (vertexDistance - fogStart) / (fogEnd - fogStart);
}

void main() {
    if (part == SKY_DISC || part == SKY_DARK_DISC) {
        // sky.fsh: apply_fog with the sky's end as every distance, environmental from 0 and render distance from
        // the end itself, so past it the cylinder distance is all fog.
        float skyEnd = fogSkyClouds.x;
        float fogValue = max(linearFogValue(sphericalVertexDistance, 0.0, skyEnd), linearFogValue(cylindricalVertexDistance, skyEnd, skyEnd));
        fragColor = vec4(mix(vertexColor.rgb, fogColour.rgb, fogValue * fogColour.a), 1.0);
        return;
    }
    vec4 color;
    if (part == SKY_SUNRISE) {
        if (vertexColor.a == 0.0) {
            discard;
        }
        color = vertexColor;
    }
    else if (part == SKY_STARS) {
        color = vertexColor;
    }
    else if (part == SKY_END) {
        color = texture(endSky, texCoord0) * vertexColor;
        if (color.a == 0.0) {
            discard;
        }
    }
    else {
        vec4 texel = texture(celestialAtlas, texCoord0);
        if (texel.a == 0.0) {
            discard;
        }
        color = texel * vertexColor;
    }
    bool translucent = part == SKY_SUNRISE || part == SKY_END;
    fragColor = vec4(color.rgb * color.a, translucent ? color.a : 0.0);
}
