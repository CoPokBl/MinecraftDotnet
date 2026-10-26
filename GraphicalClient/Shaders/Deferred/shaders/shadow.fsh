in vec3 vUv;

void main() {
#ifdef GEOMETRY_ENTITY
    // The cut the entity passes make, so a texel that is not drawn throws no shadow.
    if (texture(entityAtlas, vUv.xy).a < 0.1) {
        discard;
    }
#elif defined(ALPHA_TEST)
    if (texture(blockAtlas, vUv).a < 0.5) {
        discard;
    }
#endif
}
