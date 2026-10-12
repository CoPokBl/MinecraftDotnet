namespace GraphicalClient.Audio;

/// <summary>
/// The built in art for sounds: every sound event synthesised from its name, so the game is heard
/// without anyone's recordings. The event's path says what kind of noise it is (a block's material and
/// what happened to it, a mob and what it did, the weather, the menus, music), and a hash of the whole
/// name varies the pitch and timbre so that two mobs or two materials never sound alike. Deterministic:
/// an event always makes the same sound.
/// </summary>
public static class DevSounds {
    public const int SampleRate = 22050;

    private enum Material {
        Hard,
        Wood,
        Plant,
        Grainy,
        Glass,
        Soft,
        Liquid,
        Metal
    }

    /// <param name="path">The event's namespace and path, <c>minecraft/block.stone.step</c>.</param>
    public static AudioData Synthesize(string path) {
        string name = path.Contains('/') ? path[(path.IndexOf('/') + 1)..] : path;
        uint seed = Hash(path);
        Synth synth = new(seed);
        string[] parts = name.Split('.');
        string category = parts[0];
        string action = parts[^1];
        string subject = parts.Length > 2 ? parts[1] : "";

        float[] samples = category switch {
            "block" => BlockSound(synth, action, name),
            "entity" => EntitySound(synth, subject, action, name, seed),
            "item" => ItemSound(synth, name),
            "ui" => synth.Click(0.04F, 2400 + seed % 800),
            "music" or "music_disc" => synth.Music(seed, category == "music_disc" ? 40.0F : 30.0F),
            "ambient" => AmbientSound(synth, name),
            "weather" => name.Contains("thunder") ? synth.Boom(2.5F, 40) : synth.Rain(1.5F),
            "event" or "particle" => synth.Click(0.06F, 900 + seed % 600),
            _ => synth.Voice(0.25F, 300 + seed % 400, 1)
        };
        short[] pcm = new short[samples.Length];
        for (int i = 0; i < samples.Length; i++) {
            pcm[i] = (short)Math.Clamp((int)(samples[i] * 26000.0F), short.MinValue, short.MaxValue);
        }
        return new AudioData(pcm, 1, SampleRate);
    }

    private static uint Hash(string text) {
        uint hash = 2166136261;
        foreach (char c in text) {
            hash = (hash ^ c) * 16777619;
        }
        return hash;
    }

    private static readonly (Material Material, string[] Words)[] Materials = [
        (Material.Glass, ["glass", "amethyst", "ice", "chime", "bell"]),
        (Material.Metal, ["metal", "iron", "copper", "anvil", "chain", "lantern", "netherite", "gold", "heavy_core", "trial_spawner", "vault"]),
        (Material.Wood, ["wood", "plank", "log", "bamboo", "barrel", "chest", "ladder", "scaffold", "fence", "door", "sign", "shelf"]),
        (Material.Plant, ["grass", "leaves", "plant", "crop", "vine", "moss", "azalea", "berry", "flower", "root", "lily", "fungus", "nylium", "wart", "hay", "kelp",
            "cave_vines", "sapling"]),
        (Material.Grainy, ["sand", "gravel", "snow", "soul", "mud", "powder", "dirt", "rooted", "suspicious", "packed", "clay"]),
        (Material.Soft, ["wool", "carpet", "honey", "slime", "sponge", "frogspawn", "candle", "bed"]),
        (Material.Liquid, ["water", "lava", "bubble", "fluid"])
    ];

    private static Material MaterialOf(string name) {
        foreach ((Material material, string[] words) in Materials) {
            if (Has(name, words)) {
                return material;
            }
        }
        return Material.Hard;
    }

    private static bool Has(string text, params string[] words) => words.Any(text.Contains);

    private static float[] BlockSound(Synth synth, string action, string name) {
        Material material = MaterialOf(name);
        float length = action switch {
            "break" => 0.28F,
            "place" => 0.14F,
            "hit" => 0.06F,
            "fall" => 0.18F,
            "step" => 0.09F,
            _ => 0.3F
        };
        if (Has(name, "door", "trapdoor", "gate") && Has(action, "open", "close")) return synth.Knock(0.12F, action == "open" ? 260 : 200);
        if (Has(name, "button", "lever", "pressure_plate", "tripwire")) return synth.Click(0.05F, action.Contains("on") ? 1800 : 1400);
        if (Has(name, "fire", "furnace", "campfire", "smoker")) return synth.Crackle(0.8F);
        if (Has(name, "portal")) return synth.Drone(2.0F, 90, 0.4F);
        if (Has(name, "piston")) return synth.Knock(0.18F, 120);
        if (Has(name, "note_block")) return synth.Pluck(0.6F, 220 * MathF.Pow(2, (synth.Seed % 24) / 12.0F));
        return material switch {
            Material.Hard => synth.Crunch(length, 2200, 0.55F),
            Material.Wood => synth.Knock(length, 180 + synth.Seed % 90),
            Material.Plant => synth.Rustle(length * 1.3F),
            Material.Grainy => synth.Crunch(length * 1.2F, 900, 0.85F),
            Material.Glass => action == "break" ? synth.Shatter(0.45F) : synth.Pluck(length + 0.1F, 1800 + synth.Seed % 900),
            Material.Soft => synth.Thud(length, 160),
            Material.Liquid => synth.Splash(length + 0.2F),
            _ => synth.Clank(length + 0.08F, 600 + synth.Seed % 500)
        };
    }

    private static float[] EntitySound(Synth synth, string subject, string action, string name, uint seed) {
        // Each kind of mob gets its own register: a pitch from its name, lower for the big ones.
        float basePitch = 140 + Hash(subject) % 420;
        if (Has(subject, "ghast", "warden", "ravager", "iron_golem", "ender_dragon", "wither", "hoglin", "zoglin", "polar_bear", "sniffer", "camel")) {
            basePitch *= 0.45F;
        }
        if (Has(subject, "bat", "parrot", "chicken", "bee", "silverfish", "endermite", "allay", "vex", "tadpole", "fox")) {
            basePitch *= 2.1F;
        }
        if (Has(name, "generic.explode", "explode", "explosion")) return synth.Boom(1.6F, 55);
        if (Has(name, "splash", "swim")) return synth.Splash(0.4F);
        if (Has(name, "item.pickup", "experience_orb.pickup")) return synth.Pluck(0.12F, name.Contains("experience") ? 1400 + seed % 600 : 1100);
        if (Has(action, "step", "land")) return synth.Thud(0.08F, 120 + Hash(subject) % 80);
        if (Has(name, "attack.sweep", "attack.strong", "attack.weak", "attack.knockback", "attack.crit", "attack.nodamage")) return synth.Whoosh(0.18F, name.Contains("crit") ? 2.0F : 1.0F);
        if (Has(action, "shoot", "throw", "flap", "whoosh")) return synth.Whoosh(0.2F, 1.0F);
        if (Has(action, "eat", "chew", "burp")) return synth.Crunch(0.35F, 700, 0.9F);
        if (Has(action, "drink", "slurp")) return synth.Gulp(0.4F);
        if (Has(name, "fuse", "primed", "sizzle", "extinguish")) return synth.Hiss(0.9F);
        if (Has(action, "hurt")) return synth.Glide(0.22F, basePitch * 1.4F, basePitch * 0.8F, 0.35F);
        if (Has(action, "death")) return synth.Glide(0.7F, basePitch * 1.2F, basePitch * 0.45F, 0.25F);
        if (Has(action, "ambient", "idle", "growl", "say", "yes", "no", "trade", "purr", "bark", "howl", "hiss", "angry")) {
            return synth.Voice(0.35F + seed % 3 * 0.12F, basePitch, 1 + (int)(seed % 3));
        }
        return synth.Voice(0.25F, basePitch, 1);
    }

    private static float[] ItemSound(Synth synth, string name) {
        if (Has(name, "armor.equip")) return synth.Clank(0.2F, 700);
        if (Has(name, "bucket")) return synth.Splash(0.4F);
        if (Has(name, "break")) return synth.Shatter(0.35F);
        if (Has(name, "flintandsteel", "firecharge")) return synth.Crackle(0.3F);
        if (Has(name, "shield.block")) return synth.Knock(0.15F, 160);
        if (Has(name, "totem")) return synth.Music(synth.Seed, 2.0F);
        if (Has(name, "book", "page")) return synth.Rustle(0.2F);
        return synth.Click(0.08F, 1000 + synth.Seed % 1000);
    }

    private static float[] AmbientSound(Synth synth, string name) {
        if (Has(name, "underwater", "basalt", "crimson", "warped", "soul_sand_valley", "nether_wastes")) {
            return name.Contains("loop") ? synth.Drone(4.0F, 60 + synth.Seed % 40, 0.6F) : synth.Drone(2.0F, 80 + synth.Seed % 60, 0.35F);
        }
        if (name.Contains("cave")) return synth.Glide(2.5F, 90 + synth.Seed % 80, 50, 0.25F);
        return synth.Drone(2.0F, 100 + synth.Seed % 100, 0.3F);
    }

    /// <summary>The handful of noises everything above is built from.</summary>
    private sealed class Synth(uint seed) {
        private uint _state = seed | 1;

        public uint Seed { get; } = seed;

        private float Noise() {
            _state ^= _state << 13;
            _state ^= _state >> 17;
            _state ^= _state << 5;
            return _state / (float)uint.MaxValue * 2.0F - 1.0F;
        }

        private static int Length(float seconds) => Math.Max(1, (int)(seconds * SampleRate));

        private static float Decay(int i, int length, float sharpness) => MathF.Exp(-sharpness * i / (float)length);

        private static float Attack(int i, float seconds) => Math.Min(1.0F, i / (seconds * SampleRate));

        private static float Time(int i) => i / (float)SampleRate;

        /// <summary>A sound <paramref name="seconds"/> long, each sample asked for in order from the first.</summary>
        private static float[] Fill(float seconds, Func<int, int, float> sample) {
            int n = Length(seconds);
            float[] s = new float[n];
            for (int i = 0; i < n; i++) {
                s[i] = sample(i, n);
            }
            return s;
        }

        /// <summary>Filtered noise in a fast decaying burst: stone underfoot, gravel, crumbling.</summary>
        public float[] Crunch(float seconds, float cutoff, float grain) {
            float low = 0, a = MathF.Min(1, cutoff / SampleRate * 6.28F);
            return Fill(seconds, (i, n) => {
                float noise = Noise() * (Noise() > grain - 1 ? 1 : 0.2F);
                low += (noise - low) * a;
                return (noise - low * 0.6F) * Decay(i, n, 6) * 0.8F;
            });
        }

        /// <summary>A short resonant tone over a thump: wood.</summary>
        public float[] Knock(float seconds, float frequency) => Fill(seconds, (i, n) => {
            float t = Time(i);
            float tone = MathF.Sin(t * frequency * MathF.Tau) + 0.5F * MathF.Sin(t * frequency * 2.7F * MathF.Tau);
            return (tone * 0.7F + Noise() * 0.3F) * Decay(i, n, 9);
        });

        /// <summary>High passed crackly noise: grass and leaves.</summary>
        public float[] Rustle(float seconds) {
            float previous = 0;
            return Fill(seconds, (i, n) => {
                float noise = Noise();
                float high = noise - previous;
                previous = noise;
                float flutter = 0.6F + 0.4F * MathF.Sin(Time(i) * 40 * MathF.Tau);
                return high * flutter * Decay(i, n, 4) * Attack(i, 0.01F) * 0.6F;
            });
        }

        /// <summary>Low passed noise, quick and dull: wool, slime, a soft landing.</summary>
        public float[] Thud(float seconds, float frequency) {
            float low = 0;
            return Fill(seconds, (i, n) => {
                low += (Noise() - low) * 0.08F;
                return (low * 2.5F + 0.6F * MathF.Sin(Time(i) * frequency * MathF.Tau)) * Decay(i, n, 7);
            });
        }

        /// <summary>A bright decaying partial: glass touched, a pickup, a note.</summary>
        public float[] Pluck(float seconds, float frequency) => Fill(seconds, (i, n) => {
            float t = Time(i);
            return (MathF.Sin(t * frequency * MathF.Tau) + 0.3F * MathF.Sin(t * frequency * 2 * MathF.Tau)) * Decay(i, n, 5) * 0.6F;
        });

        /// <summary>Several bright partials with noise: breaking glass.</summary>
        public float[] Shatter(float seconds) {
            float[] partials = [2100 + Seed % 500, 3300 + Seed % 700, 4700 + Seed % 900];
            return Fill(seconds, (i, n) => {
                float t = Time(i);
                float tone = partials.Sum(f => MathF.Sin(t * f * MathF.Tau)) / partials.Length;
                return (tone * 0.6F + Noise() * 0.4F * Decay(i, n, 20)) * Decay(i, n, 5);
            });
        }

        /// <summary>Inharmonic ringing: metal.</summary>
        public float[] Clank(float seconds, float frequency) => Fill(seconds, (i, n) => {
            float t = Time(i);
            float tone = MathF.Sin(t * frequency * MathF.Tau) + 0.6F * MathF.Sin(t * frequency * 2.76F * MathF.Tau) + 0.3F * MathF.Sin(t * frequency * 5.4F * MathF.Tau);
            return (tone * 0.45F + Noise() * 0.2F * Decay(i, n, 30)) * Decay(i, n, 6);
        });

        /// <summary>A tick: buttons and menus.</summary>
        public float[] Click(float seconds, float frequency) => Fill(seconds, (i, n) => MathF.Sin(Time(i) * frequency * MathF.Tau) * Decay(i, n, 12) * 0.7F);

        /// <summary>Noise swelling and falling away: water.</summary>
        public float[] Splash(float seconds) {
            float low = 0;
            return Fill(seconds, (i, n) => {
                low += (Noise() - low) * 0.25F;
                float bubble = MathF.Sin(Time(i) * (300 + 600 * Decay(i, n, 3)) * MathF.Tau) * 0.25F;
                return (low * 1.2F + bubble) * Attack(i, 0.03F) * Decay(i, n, 4);
            });
        }

        /// <summary>Random pops: fire.</summary>
        public float[] Crackle(float seconds) {
            float pop = 0;
            return Fill(seconds, (_, _) => {
                if (Noise() > 0.995F) {
                    pop = 1;
                }
                pop *= 0.92F;
                return (Noise() * pop + Noise() * 0.05F) * 0.7F;
            });
        }

        /// <summary>Steady noise: a fuse, a fire going out.</summary>
        public float[] Hiss(float seconds) {
            float previous = 0;
            return Fill(seconds, (i, n) => {
                float noise = Noise();
                float sample = (noise - previous) * 0.35F * Attack(i, 0.05F) * Decay(i, n, 2);
                previous = noise;
                return sample;
            });
        }

        /// <summary>Deep noise with a long tail: explosions and thunder.</summary>
        public float[] Boom(float seconds, float frequency) {
            float low = 0;
            return Fill(seconds, (i, n) => {
                low += (Noise() - low) * 0.03F;
                return (low * 4 + MathF.Sin(Time(i) * frequency * MathF.Tau) * 0.4F) * Attack(i, 0.005F) * Decay(i, n, 5);
            });
        }

        /// <summary>Band passed noise rising and falling: a swing, a throw, wings.</summary>
        public float[] Whoosh(float seconds, float brightness) {
            float low = 0, band = 0;
            return Fill(seconds, (i, n) => {
                float noise = Noise();
                low += (noise - low) * 0.3F * brightness;
                band += (low - band) * 0.15F;
                float shape = MathF.Sin(MathF.PI * i / n);
                return (low - band) * shape * 1.6F;
            });
        }

        /// <summary>Low pulses: drinking.</summary>
        public float[] Gulp(float seconds) => Fill(seconds, (i, _) => {
            float t = Time(i);
            float pulse = MathF.Max(0, MathF.Sin(t * 7 * MathF.Tau));
            return MathF.Sin(t * (180 + 80 * pulse) * MathF.Tau) * pulse * 0.6F;
        });

        /// <summary>A tone sliding between two pitches with a little grit: hurt, death, a cave's moan.</summary>
        public float[] Glide(float seconds, float from, float to, float grit) {
            float phase = 0;
            return Fill(seconds, (i, n) => {
                float progress = i / (float)n;
                phase += (from + (to - from) * progress) / SampleRate;
                float tone = MathF.Sin(phase * MathF.Tau) + 0.4F * MathF.Sin(phase * 2 * MathF.Tau);
                return (tone * (1 - grit) + Noise() * grit) * Attack(i, 0.01F) * Decay(i, n, 2.5F) * 0.6F;
            });
        }

        /// <summary>Syllables of a voiced tone with a moving formant: a mob going about its business.</summary>
        public float[] Voice(float seconds, float pitch, int syllables) {
            float phase = 0;
            return Fill(seconds, (i, n) => {
                float progress = i / (float)n;
                float syllable = progress * syllables % 1.0F;
                float envelope = MathF.Sin(MathF.PI * syllable);
                float wobble = 1 + 0.12F * MathF.Sin(progress * syllables * MathF.Tau + Seed % 7);
                phase += pitch * wobble / SampleRate;
                float buzz = (phase % 1.0F) * 2 - 1;
                float formant = MathF.Sin(phase * (2.5F + 1.5F * syllable) * MathF.Tau);
                return (buzz * 0.3F + formant * 0.5F) * envelope * 0.55F;
            });
        }

        /// <summary>A slow beating chord: nether air, the underwater loop.</summary>
        public float[] Drone(float seconds, float frequency, float level) => Fill(seconds, (i, _) => {
            float t = Time(i);
            float tone = MathF.Sin(t * frequency * MathF.Tau) + MathF.Sin(t * frequency * 1.007F * MathF.Tau) + 0.5F * MathF.Sin(t * frequency * 1.5F * MathF.Tau);
            float fade = MathF.Min(1, MathF.Min(t / 0.3F, (seconds - t) / 0.3F));
            return tone * 0.25F * level * fade;
        });

        /// <summary>Pink-ish noise with drops in it: rain.</summary>
        public float[] Rain(float seconds) {
            float low = 0;
            return Fill(seconds, (_, _) => {
                float noise = Noise();
                low += (noise - low) * 0.12F;
                float drop = Noise() > 0.998F ? Noise() : 0;
                return (low * 0.6F + drop * 0.5F) * 0.5F;
            });
        }

        /// <summary>
        /// A slow walk through a pentatonic scale over a held root, soft and quiet, for the music events.
        /// Long enough that the music manager's gaps between tracks do the rest.
        /// </summary>
        public float[] Music(uint seed, float seconds) {
            int n = Length(seconds);
            float[] s = new float[n];
            int[] scale = [0, 2, 4, 7, 9, 12, 14, 16];
            float root = 196 * MathF.Pow(2, seed % 7 / 12.0F);
            float noteLength = 0.6F + seed % 4 * 0.15F;
            int notes = (int)(seconds / noteLength);
            int degree = 3;
            for (int note = 0; note < notes; note++) {
                degree = Math.Clamp(degree + (int)(Noise() * 2.99F), 0, scale.Length - 1);
                if (Noise() > 0.7F) {
                    continue;
                }
                float frequency = root * MathF.Pow(2, scale[degree] / 12.0F);
                int start = (int)(note * noteLength * SampleRate);
                int length = Math.Min(n - start, (int)(noteLength * 2.2F * SampleRate));
                for (int i = 0; i < length; i++) {
                    float t = Time(i);
                    float tone = MathF.Sin(t * frequency * MathF.Tau) + 0.2F * MathF.Sin(t * frequency * 2 * MathF.Tau);
                    s[start + i] += tone * Attack(i, 0.04F) * Decay(i, length, 3) * 0.22F;
                }
            }
            for (int i = 0; i < n; i++) {
                float t = Time(i);
                float fade = MathF.Min(1, MathF.Min(t / 2, (seconds - t) / 3));
                s[i] = (s[i] + MathF.Sin(t * root / 2 * MathF.Tau) * 0.06F) * fade;
            }
            return s;
        }
    }
}
