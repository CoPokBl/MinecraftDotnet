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
| `update` | For a pass on the `shadow` camera: `always` runs it every frame, while `shadowUpdate` keeps the pack's other shadow passes until something changes. The default pack draws `entities` into a map of their own this way, leaving the terrain's map cached. |

### Geometry

| Kind | What it is | Vertex helpers |
| --- | --- | --- |
| `terrain_solid` | Opaque blocks, and lava. | terrain |
| `terrain_cutout` | Blocks with see through texels: leaves, plants, glass panes. Discard on alpha yourself, and draw with `"cull": false`: a plant's planes are one sided and meant to be seen from both. | terrain |
| `terrain_translucent` | Water, stained glass, ice. Drawn back to front. | terrain |
| `entities` | Entity models and dropped items: textured from `entityAtlas`. Discard on alpha yourself; draw with `"cull": false`, as some model faces are one sided planes. | entity |
| `entities_translucent` | Entity parts vanilla draws blended: a slime's outer cube, a ghast's glow, a breeze's wind. Same inputs as `entities`; draw after the opaque world with `"blend": "alpha"`. Vanilla writes depth for these, so a model hides its own back. | entity |
| `entities_additive` | What vanilla adds to the picture behind it, unlit: the energy swirl round a charged creeper and a powered wither, lightning, the dying dragon's rays. Vanilla adds the texel times `vertexColour().rgb` times `vertexColour().a`, discarding where the texel's alpha is under 0.1: draw it with `"blend": "additive"`, `"cull": false` and the default depth write, as vanilla does. The light helpers say full light and mean nothing. Nothing is drawn when none is in view. | entity |
| `water_mask` | Vanilla's boat water patch: a slab filling the top of each boat's hull, level with its rim, left out for a boat under water. Draw it into the depth target with no `outputs`, so the water surface drawn after it fails the depth test inside the hull instead of showing through the floor. Vanilla draws it after `entities_translucent` and before `terrain_translucent`; a translucent part drawn after it is hidden inside a hull. Draw it after any pass that lights the opaque scene from depth, or the patch is lit as a surface. Only the position of the entity vertex helpers means anything. A pass that neither clears nor writes a history or mipmapped target is skipped when no boat is in view. | entity |
| `hand` | The first person arms and held items, in front of the camera. Same inputs as `entities`. Draw it with `"depthRange": [0, 0.05]` and `"depthClamp": true`, as vanilla clears depth before the hand; a depth read back from it is squeezed toward the camera accordingly. | entity |
| `crumbling` | The dig cracks: the dug block's faces again, textured with its destroy stage from `entityAtlas`. Vanilla blends them as twice the texel times what is there, which `multiply` and an output of twice the texel give. | entity |
| `glint` | The enchantment glint over `entities` and `entities_translucent`: every quad of a glinting item, a glinting special item model (shield) and worn glinting armour or elytra, again, at the same corners. Vanilla draws it with an equal depth test and no depth write, adding the glint texel times the strength, squared, to what is there: `"depthFunc": "equal"`, `"depthWrite": false` and `additive` blending with that as the output. Equal depth only holds if the position is worked out exactly as the pass that drew the item did, so declare `invariant gl_Position` in both. | glint |
| `hand_glint` | The same over `hand`. Draw it with the hand's `depthRange` and `depthClamp`. | glint |
| `entity_outline` | Glowing entities' silhouettes: everything `entities` and `entities_translucent` draw for an entity that appears glowing, held items and armour included, with `vertexColour()` its team colour, opaque, white without a coloured team. An invisible glowing entity gives its body alone. The parts vanilla keeps out of the outline are left out: eyes, emissive layers, paintings, experience orbs, fishing hooks, wind charges, lightning. Vanilla discards a texel only where the texture's alpha is 0 and writes the colour flat, into a target with a depth buffer of its own, so an outline shows through walls; it then finds the silhouette's edges, blurs them and blends them over the finished image, after the hand. The default pack's `entity_outline` programs transcribe that. Draw it with `"cull": false`, and give its passes `"when": "entity_outline"`. | entity |
| `lines` | Block outlines, fishing lines and other lines, each a quad of two triangles that the vertex stage widens on screen. | coloured |
| `particles` | The particles vanilla draws cut out: smoke, flames, crits, dust, block and item fragments and most others. One quad each, facing the camera or turned their own way. Discard where the alpha is under 0.1, as vanilla does. Draw with `"cull": false`: a quad turned its own way (a shriek, a vibration) is sent once and meant to be seen from both sides. Vanilla draws them after the opaque world, writing depth. | particle |
| `particles_translucent` | The particles vanilla blends: campfire smoke, spells, soul flames, end rod and firework sparks, and block fragments whose texture has partly clear texels. The same as `particles`, drawn with `"blend": "alpha"`. Vanilla does not sort them, and writes depth. | particle |
| `end_portal` | The faces of end portals and end gateways within vanilla's block entity view distance (64 blocks, 256 for a gateway): the portal's top and bottom at heights 0.75 and 0.375 of its block, each face of a gateway that its neighbour does not cover. Vanilla draws them opaque and unlit, layering `endSky` and `endPortal` in screen space; draw it after the opaque world with the default `cull`. Nothing is drawn when none is in view. | portal |
| `weather` | Rain and snow round the camera, as vanilla lays them out: every column within the weather radius (the `weatherRadius` option, 3 to 10 blocks) where it rains or snows at the camera's height, from the highest block that blocks motion, or the camera's height less the radius if that is higher, up to the radius above the camera. One quad each, turned square to the line from the camera's block, so the column the camera stands in has none. Rain is drawn first with `weatherTexture` the resource pack's `textures/environment/rain.png`, then snow with it `snow.png`, each the client's own art where no pack has one. Vanilla discards under an alpha of 0.1, blends, and does not write depth: `"blend": "alpha"`, `"depthWrite": false`, `"cull": false`, after the translucent world. Nothing is drawn when it is not raining. | weather |
| `text` | Text displays, the holograms and signs servers build from them, without the see through flag: each display's background, then each glyph's shadow, then the glyphs, underlines and strikethroughs, displays sorted back to front. Textured from `entityAtlas` (the background from its white texel); vanilla cuts at an alpha of 0.1, lights the text by the lightmap alone, fogs it and blends it: `"blend": "alpha"`, `"cull": false`. The layers of one display lie in one plane, so pull each over the one under it by `vertexTextLayer()` and draw with `"depthFunc": "lequal"`, as the default pack does; vanilla pulls its text toward the camera with `"polygonOffset": [-1, -10]`. Nothing is drawn when no text display is in view. | text |
| `text_see_through` | The text displays with the see through flag, the same way, which vanilla draws with no depth test or write, unlit and without fog: `"depthTest": false`, `"depthWrite": false`, after everything they should show through. | text |
| `entity_shadows` | The round shadows on the ground under entities (the `entityShadows` option, on by default). One box per entity, from below its feet (vanilla's reach down, at least the block under them) to a tenth of a block above, its radius each way, wound so culling keeps the far side: each pixel it covers is drawn once. The geometry carries no ground; read the opaque pass's depth to find it, as the default pack's `entity_shadow.fsh` does, and lay the shadow texture on what faces up there, darker the nearer it is to the feet and the brighter the ground is lit, as vanilla's `extractShadow` works out per block. Vanilla blends it with `"blend": "alpha"`. Leave the pass out for no round shadows. Nothing is drawn when no entity has one in view. | entity shadow |
| `clouds` | The cloud layer. Its geometry is only the box the layer fills out to where the clouds have faded, wound so that the walls on its far side are what culling keeps: each pixel the layer covers is drawn once, from outside the box or in it, and the fragment stage finds the cloud by tracing the pixel's ray through the cell map with `cloudTrace`. Draw it with `"depthClamp": true`, as the box reaches well past the far plane, writing `gl_FragDepth` from the hit so what is drawn later sorts against the clouds; vanilla blends them with `"blend": "alpha"` after the opaque world. Nothing is drawn with clouds off or in a dimension without them. | clouds |

A `copy` pass may name `"camera": "shadow"` to be skipped along with the shadow camera's passes.

From the `main` camera, terrain is culled to the frustum, to what the camera can see past cave walls,
and to the faces that can face the camera. From the `shadow` camera it is every solid and cutout
section inside the shadow camera's box, all faces, since back faces cast shadows too.
`entities` from the `shadow` camera is what the main camera's holds, with entities beside the view whose
shadow could fall into it, out to 64 blocks, and the player seen from its own eyes in first person, so a
pack can draw entities into a shadow map with nothing missing at the edges of the screen; it is empty with
the `entityShadows` option off. `terrain_translucent`, `entities_translucent`, `entities_additive`, `water_mask`, `crumbling`, `glint`, `hand_glint`, `entity_outline`, `lines`, `end_portal`, `particles`, `particles_translucent`, `weather`, `clouds`, `text`, `text_see_through` and `entity_shadows` are the same whichever camera a pass names.

## What every program gets

Each stage starts with `#version 450 core`, then these defines:

- `GEOMETRY_TERRAIN`, `GEOMETRY_ENTITY`, `GEOMETRY_COLOURED`, `GEOMETRY_PORTAL`, `GEOMETRY_PARTICLE`, `GEOMETRY_WEATHER`,
  `GEOMETRY_CLOUDS`, `GEOMETRY_TEXT`, `GEOMETRY_ENTITY_SHADOW` or `GEOMETRY_FULLSCREEN`, and
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
Units 30 and 31 hold `weatherTexture` and `cloudMap` for the passes that have them.

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

Textures vanilla repeats or scrolls, the energy swirls, the breeze's wind, a wind charge and every
beam, are drawn from copies of the texture tiled side by side in `entityAtlas`, cut into pieces where
a piece would run past the tiles, so `vertexUv()` always lands inside the tiled copy and needs no
wrapping. A scroll moves the coordinates, and any cuts, from frame to frame.

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
vec3  vertexPosition();      // camera relative: this end of the line
vec4  vertexColour();        // sRGB, unlit
vec2  vertexLight();         // sky and block light, 0 to 15
vec3  vertexLineDirection(); // a unit step along the line, either way, from this end
float vertexLineWidth();     // in pixels: the larger of 2.5 and 2.5 for each 1920 pixels of the window's width
float vertexLineSide();      // 1 or -1: which edge of the quad this vertex is
```

Each line comes as six vertices, both ends twice, which the vertex stage has to push apart or the
quad has no area. Vanilla projects the end and a step along the direction, takes the line's direction
on screen, and moves the vertex half the width across it, the offset turned to point right whichever
way the line runs, after pulling both a 256th of the way toward the camera. The default pack's
`lines.vsh` has the arithmetic.

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

### Particle vertex helpers

For `particles` and `particles_translucent`. Each particle is an instance of a four vertex strip, and the helpers
work out the corner the vertex is from the instance, so a vertex stage needs nothing else:

```glsl
vec3  vertexPosition();    // camera relative: the corner, at this frame's partial tick, sized and turned
vec3  vertexUv();          // xy in entityAtlas when z is negative, otherwise xy within blockAtlas layer z
vec4  vertexColour();      // tint and alpha, sRGB; multiply the texture by it
vec2  vertexLight();       // sky and block light, 0 to 15, with the glow some particles add as they age
bool  vertexIsEmissive();  // vanilla draws it at full brightness: use the colour as it is
vec3  vertexNormal();      // toward the camera, or the quad's own facing when it is turned its own way
float particleAge();       // 0 to 1 over its life, with the partial tick
float particleLifetime();  // its life in ticks
```

Particle sprites (a pack's `textures/particle`), block fragments and item fragments are drawn from the same
quads: a sprite or an item from `entityAtlas`, a block from its layer of `blockAtlas`.

### Weather vertex helpers

For `weather`. Each column is an instance of a four vertex strip, and the helpers work out the corner from the
instance. Both stages also get `uniform sampler2D weatherTexture`, the rain's or the snow's, repeating and nearest.

```glsl
vec3  vertexPosition(); // camera relative corner of the column's quad
vec2  vertexUv();       // in weatherTexture, scrolled for this frame: rain falls, snow falls slowly and drifts
vec4  vertexColour();   // white; the alpha fades from 1 (0.8 for snow) at the camera to 0.5 at the radius, times the rain level
vec2  vertexLight();    // sky and block light, 0 to 15, where the column meets the ground or the camera's height;
                        // snow's is raised a quarter of the way to full, as vanilla's is
vec3  vertexNormal();   // toward the camera's block
bool  vertexIsSnow();
```

The texture repeats every four blocks up the column, from the world's own heights, and once across it.

### Cloud helpers

For `clouds`, in both stages:

```glsl
uniform sampler2D cloudMap;    // textures/environment/clouds.png, or the client's own map: a cell is cloud where
                               // its alpha is 10 or more
vec4  cloudColour();           // sRGB and alpha: the dimension's visual/cloud_color, darkened through the night
                               // and greyed by rain and thunder, as vanilla's timeline and weather layers do
float cloudFadeDistance();     // where the clouds have faded out: the cloud range option, or nearer in fog
bool  cloudIsFlat();           // the Fast option: one flat layer rather than cells with sides

struct CloudHit {
    vec3  position;  // camera relative
    vec3  normal;    // the face's, toward the camera
    float distance;  // along the ray
    uint  face;      // 0 to 5: down, up, north, south, west, east
    bool  inside;    // the camera is inside this cloud and the face is its cell's wall, seen from within
    vec4  cell;      // the cell's texel in cloudMap
};
bool cloudTrace(vec3 direction, out CloudHit hit); // the first cloud face along a unit direction from the camera
```

and in the vertex stage `vec3 vertexPosition()`, a corner of the box. Cells are 12 blocks square and the layer 4
deep, its underside at the dimension's `visual/cloud_height`; the map drifts west 0.6 blocks a second. Vanilla
shades each face by a fixed amount, 0.7 below, 1 on top, 0.8 north and south, 0.9 east and west, the flat layer
all as a top, and fades the alpha out linearly to `cloudFadeDistance()`. The default pack's `clouds.fsh` does
that and writes the depth:

```glsl
vec4 clip = viewProjection * vec4(hit.position, 1.0);
gl_FragDepth = min(clip.z / clip.w * 0.5 + 0.5, 0.99999994);
```

The clamp keeps clouds past the far plane in front of the cleared depth.

### Text vertex helpers

For `text` and `text_see_through`. A display's mesh stays on the GPU in font pixels until its text changes,
and these place it with the display's pose for this frame:

```glsl
vec3  vertexPosition();     // camera relative
vec2  vertexUv();           // in entityAtlas: the glyph, or the white texel for a background or a line
vec4  vertexColour();       // sRGB: the run's colour at the display's text opacity, or the background's colour
vec2  vertexLight();        // sky and block light, 0 to 15, after the display's brightness override
vec3  vertexNormal();       // the way the text faces, camera relative
float vertexTextLayer();    // 0 for the background, 1 for the glyphs' shadows, 2 for the glyphs and their lines
bool  vertexIsBackground();
```

### Entity shadow vertex helpers

For `entity_shadows`, one instance per shadow:

```glsl
vec3  vertexPosition();  // camera relative: a corner of the box the shadow can fall in
vec3  shadowCentre();    // camera relative: the entity's feet
float shadowRadius();    // vanilla's per type radius, scaled with the entity: out to each side
float shadowPower();     // vanilla's pow: the type's strength, fading to 0 sixteen blocks from the camera
float shadowBottom();    // camera relative height of the lowest ground the shadow can lie on
vec4  shadowUv();        // the shadow texture's rectangle in entityAtlas: u0, v0, u1, v1
```

The texture is the pack's `textures/misc/shadow.png`, or a plain soft disc without one. Vanilla's alpha for
ground `d` blocks below the feet is `(shadowPower() - d * 0.5) * 0.5` times how bright the ground is, times the
texture's alpha at `-(ground.xz - centre.xz) / (2 * radius) + 0.5`.

### Entity shadows and the shadow map

The default pack keeps vanilla's look and lets the sun add to it. Every entity throws its round shadow on
the ground under it, and is also drawn every frame into `entityShadowMap` from the shadow camera (a pass
with `"update": "always"`, so the terrain's map stays cached), which the lighting reads beside the terrain's
map: in sunlight a mob has the dark patch at its feet and a sun shadow falling away from the light, and in
shade only the patch. A pack that wants only one of them leaves the other's pass out. The `entityShadows`
option (and `--no-entity-shadows`) turns both off by emptying `entity_shadows` and the shadow camera's
`entities`.

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
