out vec2 vUv;
out vec4 vColour;
out vec3 vLight;
out vec3 vRelative;

void main() {
    vec3 position = vertexPosition();
    gl_Position = viewProjection * vec4(position, 1.0);
    // A display's background, shadows and glyphs lie in one plane; each layer is pulled a few depth steps over
    // the one under it, which with lequal and the order they are drawn in keeps them from fighting.
    gl_Position.z -= vertexTextLayer() * 1.5e-6 * gl_Position.w;
    vUv = vertexUv();
    vColour = vertexColour();
    vRelative = position;
#ifdef SEE_THROUGH
    // Vanilla draws see through text unlit.
    vLight = vec3(1.0);
#else
    // Lit as vanilla's text is, by the lightmap alone: a sign or a hologram does not shade by its facing.
    vec2 light = vertexLight();
    vLight = texture(lightmap, (vec2(light.y, light.x) + 0.5) / 16.0).rgb;
#endif
}
