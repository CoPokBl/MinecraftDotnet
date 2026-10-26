// LevelRenderer's clear pass: the fog colour, with an alpha of 0, before anything else is drawn.
layout(location = 0) out vec4 fragColour;

void main() {
    fragColour = vec4(fogColour.rgb, 0.0);
}
