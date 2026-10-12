# Shader packs

Everything the client draws in the world goes through a shader pack. The built in look is itself a
pack, `Default/` next to this file, so anything it does a pack of your own can do differently.

```bash
dotnet run -c Release --project GraphicalClient -- --server localhost --shaders path/to/MyPack
```

F7 reloads the pack from disk. A pack that fails to load or compile leaves the built in one running
and prints why, so you can fix the file and press F7 again. `--verbose` prints the GPU time of every
pass once a second.

## Layout

```
MyPack/
  pack.json
  shaders/
    something.vsh
    something.fsh
    shared.glsl
```

`pack.json` declares the render targets and the passes that fill them, in order. Programs are found
by name in `shaders/`: a pass with `"program": "gbuffer"` uses `gbuffer.vsh` and `gbuffer.fsh`.
`#include "file.glsl"` pastes in another file from `shaders/`, and includes may nest.

## pack.json

```json
{
  "name": "MyPack",
  "shadowDistance": 112,
  "sunPathRotation": 0,
  "targets": [
    { "name": "colour", "format": "rgba16f" },
    { "name": "depth", "format": "depth32f", "filter": "nearest" },
    { "name": "shadowMap", "format": "depth32f", "size": [2048, 2048], "compare": true }
  ],
  "passes": [
    { "name": "shadow", "geometry": "terrain_solid", "camera": "shadow", "program": "shadow", "depth": "shadowMap", "clearDepth": true, "cull": false },
    { "name": "terrain", "geometry": "terrain_solid", "program": "terrain", "inputs": ["shadowMap"], "outputs": ["colour"], "depth": "depth", "clear": [0, 0, 0, 1], "clearDepth": true },
    { "name": "final", "type": "fullscreen", "program": "final", "inputs": ["colour"], "outputs": ["screen"] }
  ]
}
```

### Targets

| Field | Meaning |
| --- | --- |
| `name` | How passes refer to it, and the sampler's name when it is an input. `screen` is reserved. |
| `format` | `r8`, `rg8`, `rgba8`, `rgb10a2`, `rgba16`, `r16f`, `rg16f`, `rgba16f`, `r32f`, `rgba32f`, `r11g11b10f`, `depth24` or `depth32f`. |
| `scale` | Size as a fraction of the window. Default 1. |
| `size` | A fixed `[width, height]` in pixels instead, for a shadow map say. |
| `filter` | `linear` (default) or `nearest`. |
| `compare` | For a depth target read as a `sampler2DShadow`: sample with hardware comparison. |
| `of` | Makes this entry another name for the target it names, read with this entry's `filter` and `compare` instead of that target's. It has no texture or size of its own and can only be an input: a shadow map read both as a `sampler2DShadow` and, under a second name, as raw depth. |
| `history` | Keep the target from frame to frame. It is two textures that swap: each pass that writes it writes the other one, and a read gets whichever was written last, so until a pass writes it this frame a read sees what the last frame left. A pass can read and write it at once, which is how a temporal filter blends with its own last result. |
| `mipmaps` | Give it a mip chain, rebuilt after every pass or copy that writes it, for `textureLod` reads and wide blurs. |

Targets are recreated when the window changes size, unless they have a fixed `size`.

### Textures

Textures are filled once when the pack loads and read like targets, by naming them in a pass's `inputs`.

```json
"textures": [
  { "name": "noise", "type": "noise", "size": 256 }
]
```

| Field | Meaning |
| --- | --- |
| `name` | The sampler's name when it is an input. |
| `type` | `noise`: an `rgba8` texture of independent random bytes in every channel, the same each time the pack loads. |
| `size` | Width and height in texels. Default 256. |
| `filter` | `linear` (default) or `nearest`. Reads wrap at the edges. |

### Passes

| Field | Meaning |
| --- | --- |
| `name` | Shows up in errors and timings, and as the define `PASS_<NAME>`. |
| `type` | `geometry` (default) draws something the client has; `fullscreen` runs the program over every pixel of its outputs; `copy` copies one target into another. |
| `from`, `to` | For a `copy` pass: the targets copied from and into, which must have the same format and size. A copy of the depth target before translucent geometry is drawn into it lets later passes see both. |
| `geometry` | What a geometry pass draws, see below. |
| `camera` | `main` (default) or `shadow`. Decides which sections are drawn; the matrices you transform by are your choice. |
| `program` | Base name of the `.vsh`/`.fsh` pair. A fullscreen pass may leave out the `.vsh`. |
| `defines` | `{ "NAME": "value" }`, added before your source, so one program can serve several passes. |
| `inputs` | Targets and textures bound as samplers, each under its own name. |
| `outputs` | Colour targets written, in `layout(location = n)` order. `screen` is the window. |
| `depth` | The depth target, if any. |
| `clear` | RGBA every output is cleared to first. |
| `clearDepth` | Clear the depth target to 1 first. |
| `blend` | `none` (default), `alpha`, `additive`, `premultiplied`, or `multiply`, which multiplies what is there by the output's colour. |
| `depthRange` | `[near, far]` for `glDepthRange`: `[0, 0.05]` puts everything the pass draws in front of the world while it still sorts against itself. |
| `depthClamp` | Clamp depth instead of clipping at the near plane, for geometry closer than it. |
| `polygonOffset` | `[factor, units]` for `glPolygonOffset`, so a decal drawn on a surface wins its depth test. |
| `depthFunc` | `less` (default), `lequal` or `equal`: what the depth test passes. |
| `depthTest`, `depthWrite`, `cull` | Default true. Fullscreen passes never test, write depth or cull. |
| `when` | A geometry kind: the pass, of any type, is skipped on frames when that geometry has nothing to draw. Passes that only exist for one geometry, such as an outline's blur and composite, then cost nothing without it. |

### Geometry

| Kind | What it is | Vertex helpers |
| --- | --- | --- |
| `terrain_solid` | Opaque blocks, and lava. | terrain |
| `terrain_cutout` | Blocks with see through texels: leaves, plants, glass panes. Discard on alpha yourself, and draw with `"cull": false`: a plant's planes are one sided and meant to be seen from both. | terrain |
| `terrain_translucent` | Water, stained glass, ice. Drawn back to front. | terrain |
| `entities` | Entity models and dropped items: textured from `entityAtlas`. Discard on alpha yourself; draw with `"cull": false`, as some model faces are one sided planes. | entity |
| `entities_translucent` | Entity parts vanilla draws blended: a slime's outer cube, a ghast's glow. Same inputs as `entities`; draw after the opaque world with `"blend": "alpha"`. Vanilla writes depth for these, so a model hides its own back. | entity |
| `water_mask` | Vanilla's boat water patch: a slab filling the top of each boat's hull, level with its rim, left out for a boat under water. Draw it into the depth target with no `outputs`, so the water surface drawn after it fails the depth test inside the hull instead of showing through the floor. Vanilla draws it after `entities_translucent` and before `terrain_translucent`; a translucent part drawn after it is hidden inside a hull. Draw it after any pass that lights the opaque scene from depth, or the patch is lit as a surface. Only the position of the entity vertex helpers means anything. A pass that neither clears nor writes a history or mipmapped target is skipped when no boat is in view. | entity |
| `hand` | The first person arms and held items, in front of the camera. Same inputs as `entities`. Draw it with `"depthRange": [0, 0.05]` and `"depthClamp": true`, as vanilla clears depth before the hand; a depth read back from it is squeezed toward the camera accordingly. | entity |
| `crumbling` | The dig cracks: the dug block's faces again, textured with its destroy stage from `entityAtlas`. Vanilla blends them as twice the texel times what is there, which `multiply` and an output of twice the texel give. | entity |
| `glint` | The enchantment glint over `entities` and `entities_translucent`: every quad of a glinting item, a glinting special item model (shield) and worn glinting armour or elytra, again, at the same corners. Vanilla draws it with an equal depth test and no depth write, adding the glint texel times the strength, squared, to what is there: `"depthFunc": "equal"`, `"depthWrite": false` and `additive` blending with that as the output. Equal depth only holds if the position is worked out exactly as the pass that drew the item did, so declare `invariant gl_Position` in both. | glint |
| `hand_glint` | The same over `hand`. Draw it with the hand's `depthRange` and `depthClamp`. | glint |
| `entity_outline` | Glowing entities' silhouettes: everything `entities` and `entities_translucent` draw for an entity that appears glowing, held items and armour included, with `vertexColour()` its team colour, opaque, white without a coloured team. An invisible glowing entity gives its body alone. The parts vanilla keeps out of the outline are left out: eyes, emissive layers, paintings, experience orbs, fishing hooks, wind charges, lightning. Vanilla discards a texel only where the texture's alpha is 0 and writes the colour flat, into a target with a depth buffer of its own, so an outline shows through walls; it then finds the silhouette's edges, blurs them and blends them over the finished image, after the hand. The default pack's `entity_outline` programs transcribe that. Draw it with `"cull": false`, and give its passes `"when": "entity_outline"`. | entity |
| `lines` | Block outlines and other lines. | coloured |
| `end_portal` | The faces of end portals and end gateways within vanilla's block entity view distance (64 blocks, 256 for a gateway): the portal's top and bottom at heights 0.75 and 0.375 of its block, each face of a gateway that its neighbour does not cover. Vanilla draws them opaque and unlit, layering `endSky` and `endPortal` in screen space; draw it after the opaque world with the default `cull`. Nothing is drawn when none is in view. | portal |

A `copy` pass may name `"camera": "shadow"` to be skipped along with the shadow camera's passes.

From the `main` camera, terrain is culled to the frustum, to what the camera can see past cave walls,
and to the faces that can face the camera. From the `shadow` camera it is every solid and cutout
section inside the shadow camera's box, all faces, since back faces cast shadows too.
`terrain_translucent`, `entities`, `entities_translucent`, `water_mask`, `crumbling`, `glint`, `hand_glint`, `entity_outline`, `lines` and `end_portal` are the same whichever camera a pass names.

## What every program gets

Each stage starts with `#version 450 core`, then these defines:

- `GEOMETRY_TERRAIN`, `GEOMETRY_ENTITY`, `GEOMETRY_COLOURED`, `GEOMETRY_PORTAL` or `GEOMETRY_FULLSCREEN`, and
  `GEOMETRY_GLINT` besides `GEOMETRY_ENTITY` for the glint geometries
- `PASS_<NAME>`, the pass's name upper cased with anything else turned to `_`
- `SHADOW_PASS` when the pass uses the shadow camera
- whatever the pass's `defines` say

then the frame's uniforms and the samplers every program can read:

```glsl
layout(std140, binding = 0) uniform Frame {
    mat4 view;
    mat4 projection;
    mat4 viewProjection;
    mat4 inverseView;
    mat4 inverseProjection;
    mat4 inverseViewProjection;
    mat4 shadowView;
    mat4 shadowProjection;
    vec4 cameraPosition;  // world position; w is 1 under water
    vec4 sunDirection;    // unit vector toward the sun; w is daylight, 0 to 1
    vec4 skyColour;       // sRGB
    vec4 fogColour;       // sRGB
    vec4 fogRange;        // fog start, fog end, render distance in blocks, 1 if the dimension has a sky
    vec4 time;            // time of day 0 to 1, game seconds, real seconds, partial tick
    vec4 screen;          // width, height, 1 / width, 1 / height
    vec4 weather;         // rain, thunder, sky darkening, the dimension's ambient light
    mat4 previousViewProjection; // last frame's viewProjection
    vec4 cameraMotion;    // camera position minus last frame's; w is the seconds between them
    vec4 counters;        // frame number wrapping at 65536, ticks into the day 0 to 24000, moon phase 0 to 7,
                          // ticks of game time 0 to 24000 with the partial tick (vanilla's GameTime times 24000)
    vec4 eyeLight;        // block and sky light at the eye 0 to 1, then both eased, halving the gap each second
    vec4 heldLight;       // light the main hand's and the off hand's items give off, 0 to 15
    vec4 biome;           // the camera's biome: temperature, downfall, 1 if it rains or snows there
    vec4 clipPlanes;      // the near and far planes of projection
};

uniform sampler2DArray blockAtlas;  // every block texture, one layer each
uniform sampler2D lightmap;         // 16 by 16: x is block light, y is sky light
uniform sampler2D entityAtlas;      // every entity texture, packed; no mipmaps, sample it nearest
uniform sampler2D endSky;           // textures/environment/end_sky.png, repeating, nearest
uniform sampler2D endPortal;        // textures/entity/end_portal/end_portal.png, repeating, nearest
uniform vec3 endPortalColours[16];  // the end portal's layer tints: the first for endSky, the nth for the nth star layer
uniform sampler2D glintItem;        // textures/misc/enchanted_glint_item.png, repeating, linear
uniform sampler2D glintArmor;       // textures/misc/enchanted_glint_armor.png, repeating, linear
```

Where a point was on screen last frame, for reprojection: `previousViewProjection * vec4(relative + cameraMotion.xyz, 1.0)`.
The camera's motion is worked out in double precision, which taking the difference of two
`cameraPosition`s far from the origin would not be.

**Positions are relative to the camera.** The camera sits at the origin of every position a shader
sees, and `view` only rotates. Add `cameraPosition.xyz` for a world position. This keeps precision
far from the world origin; do the same in anything you compute.

The shadow matrices look along `sunDirection` by day and against it by night, with the light held
at least a little above the horizon. They cover `shadowDistance` blocks either side of a centre that
follows the camera a section at a time, and are snapped to the shadow map's texels, so shadows do not
shimmer as the camera moves. That centre can be most of a section from the camera, which a pack that
gathers resolution toward the middle of the map should allow for. Depth runs over four times
`shadowDistance`, the light standing twice that from the centre.

`"sunPathRotation"` at the top of `pack.json` tilts the sun's path that many degrees about the east
west axis, as OptiFine's option of that name does, so the sun is not overhead at noon; `sunDirection`
and the shadow camera both follow it.

Passes on the shadow camera only run when something they depend on has changed: the light (once a
game tick), the centre, or terrain within reach. Otherwise their targets keep what was drawn last
time, which the matrices still line up with. A pack that draws moving things into them sets
`"shadowUpdate": "always"` at the top of `pack.json` to run them every frame.

Inputs are bound from texture unit 7 up, in the order the pass lists them; units 0 to 6 are the
block atlas, the lightmap, the entity atlas, `endSky`, `endPortal`, `glintItem` and `glintArmor`.

### Terrain vertex helpers

```glsl
vec3  vertexPosition();       // camera relative
vec3  vertexUv();             // xy within the texture (past 1 where merged faces repeat it), z the layer in blockAtlas
vec2  vertexLight();          // sky and block light, 0 to 15, smoothed between blocks
vec3  vertexTint();           // biome or block colour, 1 for untinted faces
float vertexOcclusion();      // ambient occlusion, 1 for open, darker into corners
uint  vertexFace();           // 0 to 5: down, up, north, south, west, east
vec3  vertexNormal();         // the face's normal
float vertexFaceShade();      // the classic per face darkening, if you want the flat look
bool  vertexIsPlant();        // crossed planes: lit as if facing up looks best
bool  vertexIsFluidSurface(); // a fluid's top, whose corners need not be level
uint  vertexMaterial();       // the pack's material number for the block, 0 if it names none
```

Faces that are not axis aligned carry a nominal face for the classic shading: plants say north and a
fluid's top says up, even where it slopes. Tell them apart by their flags, and derive a true normal
in the fragment stage from `cross(dFdx(position), dFdy(position))` where you need one.

### Materials

A pack can number blocks for its shaders to treat differently, the way OptiFine's `block.properties`
does: leaves to sway, water to ripple, metal to reflect.

```json
"materials": [
  { "id": 1, "blocks": ["oak_leaves", "birch_leaves"], "merge": false },
  { "id": 2, "blocks": ["water"] },
  { "id": 3, "blocks": ["lantern:hanging=true", "minecraft:soul_lantern:hanging=true"] }
]
```

Ids run from 1 to 63. A block is named with or without its namespace, and `:property=value` pairs
after it pick out the states that have them; the first entry that matches a state wins. Names that
are not blocks are printed when the pack loads. A waterlogged block's water takes water's material.

The number is written into the terrain vertices, so changing the materials remeshes every section,
and a pack without materials costs nothing. Alike neighbouring faces are normally merged into one
quad; `"merge": false` keeps a material's faces one per block, which a pack that moves vertices per
block needs so merged faces do not stretch and open cracks. Distant terrain drawn at a lower level of
detail always merges, and keeps the material of the block it was drawn as.

### Entity vertex helpers

```glsl
vec3  vertexPosition();     // camera relative
vec2  vertexUv();           // in entityAtlas
vec4  vertexColour();       // tint, sRGB; multiply the texture by it
vec2  vertexLight();        // sky and block light, 0 to 15
vec3  vertexNormal();       // the face's normal, camera relative
float vertexRedOverlay();   // 0 to 1: how far to tint red, for an entity hurt or dying
float vertexWhiteOverlay(); // 0 to 1: how far to flash white, for a creeper about to blow
```

### Glint vertex helpers

The glint geometries have the entity helpers, read differently, and one more:

```glsl
vec2 vertexUv();            // in the glint texture, already scrolled and turned for this frame
vec4 vertexColour();        // the glint strength option in every channel
bool vertexIsArmorGlint();  // sample glintArmor rather than glintItem
```

Vanilla fades the glint with the fog as well.

### Coloured vertex helpers

For `lines`:

```glsl
vec3 vertexPosition(); // camera relative
vec4 vertexColour();   // sRGB, unlit
vec2 vertexLight();    // sky and block light, 0 to 15
```

### Portal vertex helpers

For `end_portal`:

```glsl
vec3 vertexPosition();    // camera relative
int  vertexPortalLayers(); // 15 for an end portal, 16 for an end gateway: how many star layers vanilla draws
```

Vanilla's effect works in screen space: the sky texture at the fragment's place on the screen, 0 to 1
across it, tinted by the first of sixteen colours, plus layer n (from 1) of the star texture tinted by
the nth colour, each layer turned, scaled, slid and scrolled with `counters.w`. The default pack's
`end_portal.fsh` has the colours and the arithmetic.

### Fullscreen passes

Without a `.vsh` a fullscreen pass gets a single triangle covering the screen and `in vec2 texCoord`
from 0 to 1. Reconstruct a position from a depth target with:

```glsl
vec4 p = inverseViewProjection * vec4(texCoord * 2.0 - 1.0, depth * 2.0 - 1.0, 1.0);
vec3 relative = p.xyz / p.w;
```

## Things to know

- Colours from textures, tints and `vertexColour()` are sRGB. Convert before lighting in linear.
- Nothing is drawn to the window until a pass outputs `screen`. The HUD is drawn after the last pass.
- The sky is not geometry. Draw it where depth is still 1, as the default pack's lighting pass does.
- A cutout pass that does not discard draws the transparent texels as solid.
