in vec3 vUv;

void main() {
#ifdef ALPHA_TEST
    if (texture(blockAtlas, vUv).a < 0.5) {
        discard;
    }
#endif
}
