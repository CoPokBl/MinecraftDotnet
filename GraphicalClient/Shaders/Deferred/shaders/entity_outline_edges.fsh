// Vanilla's entity_sobel: alpha is how much the silhouette changes against the four neighbours, colour
// the mean of the five texels' colours, each weighted by its alpha.
in vec2 texCoord;

uniform sampler2D outline;

layout(location = 0) out vec4 fragColour;

void main() {
    vec2 oneTexel = 1.0 / vec2(textureSize(outline, 0));
    vec4 centre = texture(outline, texCoord);
    vec4 left = texture(outline, texCoord - vec2(oneTexel.x, 0.0));
    vec4 right = texture(outline, texCoord + vec2(oneTexel.x, 0.0));
    vec4 up = texture(outline, texCoord - vec2(0.0, oneTexel.y));
    vec4 down = texture(outline, texCoord + vec2(0.0, oneTexel.y));
    float total = clamp(abs(centre.a - left.a) + abs(centre.a - right.a) + abs(centre.a - up.a) + abs(centre.a - down.a), 0.0, 1.0);
    vec3 colour = centre.rgb * centre.a + left.rgb * left.a + right.rgb * right.a + up.rgb * up.a + down.rgb * down.a;
    fragColour = vec4(colour * 0.2, total);
}
