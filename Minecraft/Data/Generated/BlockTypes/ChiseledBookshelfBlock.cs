using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ChiseledBookshelfBlock(Identifier Identifier, Direction Facing, bool Slot0Occupied, bool Slot1Occupied, bool Slot2Occupied, bool Slot3Occupied, bool Slot4Occupied, bool Slot5Occupied) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2143,
                                        false => 2144,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2145,
                                        false => 2146,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2147,
                                        false => 2148,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2149,
                                        false => 2150,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2151,
                                        false => 2152,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2153,
                                        false => 2154,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2155,
                                        false => 2156,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2157,
                                        false => 2158,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2159,
                                        false => 2160,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2161,
                                        false => 2162,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2163,
                                        false => 2164,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2165,
                                        false => 2166,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2167,
                                        false => 2168,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2169,
                                        false => 2170,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2171,
                                        false => 2172,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2173,
                                        false => 2174,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2175,
                                        false => 2176,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2177,
                                        false => 2178,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2179,
                                        false => 2180,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2181,
                                        false => 2182,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2183,
                                        false => 2184,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2185,
                                        false => 2186,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2187,
                                        false => 2188,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2189,
                                        false => 2190,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2191,
                                        false => 2192,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2193,
                                        false => 2194,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2195,
                                        false => 2196,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2197,
                                        false => 2198,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2199,
                                        false => 2200,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2201,
                                        false => 2202,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2203,
                                        false => 2204,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2205,
                                        false => 2206,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.South => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2207,
                                        false => 2208,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2209,
                                        false => 2210,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2211,
                                        false => 2212,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2213,
                                        false => 2214,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2215,
                                        false => 2216,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2217,
                                        false => 2218,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2219,
                                        false => 2220,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2221,
                                        false => 2222,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2223,
                                        false => 2224,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2225,
                                        false => 2226,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2227,
                                        false => 2228,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2229,
                                        false => 2230,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2231,
                                        false => 2232,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2233,
                                        false => 2234,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2235,
                                        false => 2236,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2237,
                                        false => 2238,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2239,
                                        false => 2240,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2241,
                                        false => 2242,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2243,
                                        false => 2244,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2245,
                                        false => 2246,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2247,
                                        false => 2248,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2249,
                                        false => 2250,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2251,
                                        false => 2252,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2253,
                                        false => 2254,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2255,
                                        false => 2256,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2257,
                                        false => 2258,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2259,
                                        false => 2260,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2261,
                                        false => 2262,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2263,
                                        false => 2264,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2265,
                                        false => 2266,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2267,
                                        false => 2268,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2269,
                                        false => 2270,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.West => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2271,
                                        false => 2272,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2273,
                                        false => 2274,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2275,
                                        false => 2276,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2277,
                                        false => 2278,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2279,
                                        false => 2280,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2281,
                                        false => 2282,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2283,
                                        false => 2284,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2285,
                                        false => 2286,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2287,
                                        false => 2288,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2289,
                                        false => 2290,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2291,
                                        false => 2292,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2293,
                                        false => 2294,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2295,
                                        false => 2296,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2297,
                                        false => 2298,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2299,
                                        false => 2300,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2301,
                                        false => 2302,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2303,
                                        false => 2304,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2305,
                                        false => 2306,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2307,
                                        false => 2308,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2309,
                                        false => 2310,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2311,
                                        false => 2312,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2313,
                                        false => 2314,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2315,
                                        false => 2316,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2317,
                                        false => 2318,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2319,
                                        false => 2320,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2321,
                                        false => 2322,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2323,
                                        false => 2324,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2325,
                                        false => 2326,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2327,
                                        false => 2328,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2329,
                                        false => 2330,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2331,
                                        false => 2332,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2333,
                                        false => 2334,
                                    },
                                },
                            },
                        },
                    },
                },
                Direction.East => Slot0Occupied switch {
                    true => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2335,
                                        false => 2336,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2337,
                                        false => 2338,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2339,
                                        false => 2340,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2341,
                                        false => 2342,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2343,
                                        false => 2344,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2345,
                                        false => 2346,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2347,
                                        false => 2348,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2349,
                                        false => 2350,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2351,
                                        false => 2352,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2353,
                                        false => 2354,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2355,
                                        false => 2356,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2357,
                                        false => 2358,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2359,
                                        false => 2360,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2361,
                                        false => 2362,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2363,
                                        false => 2364,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2365,
                                        false => 2366,
                                    },
                                },
                            },
                        },
                    },
                    false => Slot1Occupied switch {
                        true => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2367,
                                        false => 2368,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2369,
                                        false => 2370,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2371,
                                        false => 2372,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2373,
                                        false => 2374,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2375,
                                        false => 2376,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2377,
                                        false => 2378,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2379,
                                        false => 2380,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2381,
                                        false => 2382,
                                    },
                                },
                            },
                        },
                        false => Slot2Occupied switch {
                            true => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2383,
                                        false => 2384,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2385,
                                        false => 2386,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2387,
                                        false => 2388,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2389,
                                        false => 2390,
                                    },
                                },
                            },
                            false => Slot3Occupied switch {
                                true => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2391,
                                        false => 2392,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2393,
                                        false => 2394,
                                    },
                                },
                                false => Slot4Occupied switch {
                                    true => Slot5Occupied switch {
                                        true => 2395,
                                        false => 2396,
                                    },
                                    false => Slot5Occupied switch {
                                        true => 2397,
                                        false => 2398,
                                    },
                                },
                            },
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            2143 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, true),
            2144 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, true, false),
            2145 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, true),
            2146 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, true, false, false),
            2147 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, true),
            2148 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, true, false),
            2149 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, true),
            2150 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, true, false, false, false),
            2151 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, true),
            2152 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, true, false),
            2153 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, true),
            2154 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, true, false, false),
            2155 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, true),
            2156 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, true, false),
            2157 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, true),
            2158 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, true, false, false, false, false),
            2159 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, true),
            2160 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, true, false),
            2161 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, true),
            2162 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, true, false, false),
            2163 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, true),
            2164 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, true, false),
            2165 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, true),
            2166 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, true, false, false, false),
            2167 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, true),
            2168 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, true, false),
            2169 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, true),
            2170 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, true, false, false),
            2171 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, true),
            2172 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, true, false),
            2173 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, true),
            2174 => new ChiseledBookshelfBlock(Identifier, Direction.North, true, false, false, false, false, false),
            2175 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, true),
            2176 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, true, false),
            2177 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, true),
            2178 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, true, false, false),
            2179 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, true),
            2180 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, true, false),
            2181 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, true),
            2182 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, true, false, false, false),
            2183 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, true),
            2184 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, true, false),
            2185 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, true),
            2186 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, true, false, false),
            2187 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, true),
            2188 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, true, false),
            2189 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, true),
            2190 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, true, false, false, false, false),
            2191 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, true),
            2192 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, true, false),
            2193 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, true),
            2194 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, true, false, false),
            2195 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, true),
            2196 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, true, false),
            2197 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, true),
            2198 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, true, false, false, false),
            2199 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, true),
            2200 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, true, false),
            2201 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, true),
            2202 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, true, false, false),
            2203 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, true),
            2204 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, true, false),
            2205 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, true),
            2206 => new ChiseledBookshelfBlock(Identifier, Direction.North, false, false, false, false, false, false),
            2207 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, true),
            2208 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, true, false),
            2209 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, true),
            2210 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, true, false, false),
            2211 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, true),
            2212 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, true, false),
            2213 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, true),
            2214 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, true, false, false, false),
            2215 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, true),
            2216 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, true, false),
            2217 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, true),
            2218 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, true, false, false),
            2219 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, true),
            2220 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, true, false),
            2221 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, true),
            2222 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, true, false, false, false, false),
            2223 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, true),
            2224 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, true, false),
            2225 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, true),
            2226 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, true, false, false),
            2227 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, true),
            2228 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, true, false),
            2229 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, true),
            2230 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, true, false, false, false),
            2231 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, true),
            2232 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, true, false),
            2233 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, true),
            2234 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, true, false, false),
            2235 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, true),
            2236 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, true, false),
            2237 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, true),
            2238 => new ChiseledBookshelfBlock(Identifier, Direction.South, true, false, false, false, false, false),
            2239 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, true),
            2240 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, true, false),
            2241 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, true),
            2242 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, true, false, false),
            2243 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, true),
            2244 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, true, false),
            2245 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, true),
            2246 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, true, false, false, false),
            2247 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, true),
            2248 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, true, false),
            2249 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, true),
            2250 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, true, false, false),
            2251 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, true),
            2252 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, true, false),
            2253 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, true),
            2254 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, true, false, false, false, false),
            2255 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, true),
            2256 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, true, false),
            2257 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, true),
            2258 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, true, false, false),
            2259 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, true),
            2260 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, true, false),
            2261 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, true),
            2262 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, true, false, false, false),
            2263 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, true),
            2264 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, true, false),
            2265 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, true),
            2266 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, true, false, false),
            2267 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, true),
            2268 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, true, false),
            2269 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, true),
            2270 => new ChiseledBookshelfBlock(Identifier, Direction.South, false, false, false, false, false, false),
            2271 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, true),
            2272 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, true, false),
            2273 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, true),
            2274 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, true, false, false),
            2275 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, true),
            2276 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, true, false),
            2277 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, true),
            2278 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, true, false, false, false),
            2279 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, true),
            2280 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, true, false),
            2281 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, true),
            2282 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, true, false, false),
            2283 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, true),
            2284 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, true, false),
            2285 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, true),
            2286 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, true, false, false, false, false),
            2287 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, true),
            2288 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, true, false),
            2289 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, true),
            2290 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, true, false, false),
            2291 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, true),
            2292 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, true, false),
            2293 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, true),
            2294 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, true, false, false, false),
            2295 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, true),
            2296 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, true, false),
            2297 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, true),
            2298 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, true, false, false),
            2299 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, true),
            2300 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, true, false),
            2301 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, true),
            2302 => new ChiseledBookshelfBlock(Identifier, Direction.West, true, false, false, false, false, false),
            2303 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, true),
            2304 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, true, false),
            2305 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, true),
            2306 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, true, false, false),
            2307 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, true),
            2308 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, true, false),
            2309 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, true),
            2310 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, true, false, false, false),
            2311 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, true),
            2312 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, true, false),
            2313 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, true),
            2314 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, true, false, false),
            2315 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, true),
            2316 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, true, false),
            2317 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, true),
            2318 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, true, false, false, false, false),
            2319 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, true),
            2320 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, true, false),
            2321 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, true),
            2322 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, true, false, false),
            2323 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, true),
            2324 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, true, false),
            2325 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, true),
            2326 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, true, false, false, false),
            2327 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, true),
            2328 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, true, false),
            2329 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, true),
            2330 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, true, false, false),
            2331 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, true),
            2332 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, true, false),
            2333 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, true),
            2334 => new ChiseledBookshelfBlock(Identifier, Direction.West, false, false, false, false, false, false),
            2335 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, true),
            2336 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, true, false),
            2337 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, true),
            2338 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, true, false, false),
            2339 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, true),
            2340 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, true, false),
            2341 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, true),
            2342 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, true, false, false, false),
            2343 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, true),
            2344 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, true, false),
            2345 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, true),
            2346 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, true, false, false),
            2347 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, true),
            2348 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, true, false),
            2349 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, true),
            2350 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, true, false, false, false, false),
            2351 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, true),
            2352 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, true, false),
            2353 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, true),
            2354 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, true, false, false),
            2355 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, true),
            2356 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, true, false),
            2357 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, true),
            2358 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, true, false, false, false),
            2359 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, true),
            2360 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, true, false),
            2361 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, true),
            2362 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, true, false, false),
            2363 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, true),
            2364 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, true, false),
            2365 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, true),
            2366 => new ChiseledBookshelfBlock(Identifier, Direction.East, true, false, false, false, false, false),
            2367 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, true),
            2368 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, true, false),
            2369 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, true),
            2370 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, true, false, false),
            2371 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, true),
            2372 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, true, false),
            2373 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, true),
            2374 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, true, false, false, false),
            2375 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, true),
            2376 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, true, false),
            2377 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, true),
            2378 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, true, false, false),
            2379 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, true),
            2380 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, true, false),
            2381 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, true),
            2382 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, true, false, false, false, false),
            2383 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, true),
            2384 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, true, false),
            2385 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, true),
            2386 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, true, false, false),
            2387 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, true),
            2388 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, true, false),
            2389 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, true),
            2390 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, true, false, false, false),
            2391 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, true),
            2392 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, true, false),
            2393 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, true),
            2394 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, true, false, false),
            2395 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, true),
            2396 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, true, false),
            2397 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, true),
            2398 => new ChiseledBookshelfBlock(Identifier, Direction.East, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
