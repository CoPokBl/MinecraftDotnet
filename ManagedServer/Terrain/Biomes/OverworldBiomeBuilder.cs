using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// <c>OverworldBiomeBuilder</c>: which biome each region of climate space is, for the overworld.
/// </summary>
/// <remarks>
/// <b>This is not in the datapack.</b> <c>multi_noise_biome_source_parameter_list/overworld.json</c>
/// is one field naming a preset, and the preset is this class compiled into the jar. So where every
/// other piece of worldgen data is read from a <c>IDatapackSource</c>, this one is transcribed, on the
/// rule that content which is code upstream gets ported like any other vanilla method.
/// <p/>
/// It produces 7599 regions. <c>OverworldBiomeBuilderTest</c> compares every one of them against the
/// table dumped out of the jar, in order, so a mistranscribed range is a failure rather than a
/// continent in the wrong place.
/// <p/>
/// The instance fields of the vanilla class are static here because none of them are ever written; it
/// is a builder in name only.
/// </remarks>
public static class OverworldBiomeBuilder {
    private static readonly ClimateParameter FullRange = ClimateParameter.Span(-1.0f, 1.0f);

    private static readonly ClimateParameter[] Temperatures = [
        ClimateParameter.Span(-1.0f, -0.45f),
        ClimateParameter.Span(-0.45f, -0.15f),
        ClimateParameter.Span(-0.15f, 0.2f),
        ClimateParameter.Span(0.2f, 0.55f),
        ClimateParameter.Span(0.55f, 1.0f)
    ];

    private static readonly ClimateParameter[] Humidities = [
        ClimateParameter.Span(-1.0f, -0.35f),
        ClimateParameter.Span(-0.35f, -0.1f),
        ClimateParameter.Span(-0.1f, 0.1f),
        ClimateParameter.Span(0.1f, 0.3f),
        ClimateParameter.Span(0.3f, 1.0f)
    ];

    private static readonly ClimateParameter[] Erosions = [
        ClimateParameter.Span(-1.0f, -0.78f),
        ClimateParameter.Span(-0.78f, -0.375f),
        ClimateParameter.Span(-0.375f, -0.2225f),
        ClimateParameter.Span(-0.2225f, 0.05f),
        ClimateParameter.Span(0.05f, 0.45f),
        ClimateParameter.Span(0.45f, 0.55f),
        ClimateParameter.Span(0.55f, 1.0f)
    ];

    private static readonly ClimateParameter FrozenRange = Temperatures[0];
    private static readonly ClimateParameter UnfrozenRange = Between(Temperatures[1], Temperatures[4]);

    private static readonly ClimateParameter MushroomFieldsContinentalness =
        ClimateParameter.Span(-1.2f, -1.05f);

    private static readonly ClimateParameter DeepOceanContinentalness =
        ClimateParameter.Span(-1.05f, -0.455f);

    private static readonly ClimateParameter OceanContinentalness =
        ClimateParameter.Span(-0.455f, -0.19f);

    private static readonly ClimateParameter CoastContinentalness =
        ClimateParameter.Span(-0.19f, -0.11f);

    private static readonly ClimateParameter InlandContinentalness =
        ClimateParameter.Span(-0.11f, 0.55f);

    private static readonly ClimateParameter NearInlandContinentalness =
        ClimateParameter.Span(-0.11f, 0.03f);

    private static readonly ClimateParameter MidInlandContinentalness =
        ClimateParameter.Span(0.03f, 0.3f);

    private static readonly ClimateParameter FarInlandContinentalness =
        ClimateParameter.Span(0.3f, 1.0f);

    // Indexed [temperature][humidity] throughout, which is the order the two loops run in.
    private static readonly Identifier[][] Oceans = [
        [Id(Biome.DeepFrozenOcean), Id(Biome.DeepColdOcean), Id(Biome.DeepOcean), Id(Biome.DeepLukewarmOcean), Id(Biome.WarmOcean)],
        [Id(Biome.FrozenOcean), Id(Biome.ColdOcean), Id(Biome.Ocean), Id(Biome.LukewarmOcean), Id(Biome.WarmOcean)]
    ];

    private static readonly Identifier[][] MiddleBiomes = [
        [Id(Biome.SnowyPlains), Id(Biome.SnowyPlains), Id(Biome.SnowyPlains), Id(Biome.SnowyTaiga), Id(Biome.Taiga)],
        [Id(Biome.Plains), Id(Biome.Plains), Id(Biome.Forest), Id(Biome.Taiga), Id(Biome.OldGrowthSpruceTaiga)],
        [Id(Biome.FlowerForest), Id(Biome.Plains), Id(Biome.Forest), Id(Biome.BirchForest), Id(Biome.DarkForest)],
        [Id(Biome.Savanna), Id(Biome.Savanna), Id(Biome.Forest), Id(Biome.Jungle), Id(Biome.Jungle)],
        [Id(Biome.Desert), Id(Biome.Desert), Id(Biome.Desert), Id(Biome.Desert), Id(Biome.Desert)]
    ];

    private static readonly Identifier?[][] MiddleBiomesVariant = [
        [Id(Biome.IceSpikes), null, Id(Biome.SnowyTaiga), null, null],
        [null, null, null, null, Id(Biome.OldGrowthPineTaiga)],
        [Id(Biome.SunflowerPlains), null, null, Id(Biome.OldGrowthBirchForest), null],
        [null, null, Id(Biome.Plains), Id(Biome.SparseJungle), Id(Biome.BambooJungle)],
        [null, null, null, null, null]
    ];

    private static readonly Identifier[][] PlateauBiomes = [
        [Id(Biome.SnowyPlains), Id(Biome.SnowyPlains), Id(Biome.SnowyPlains), Id(Biome.SnowyTaiga), Id(Biome.SnowyTaiga)],
        [Id(Biome.Meadow), Id(Biome.Meadow), Id(Biome.Forest), Id(Biome.Taiga), Id(Biome.OldGrowthSpruceTaiga)],
        [Id(Biome.Meadow), Id(Biome.Meadow), Id(Biome.Meadow), Id(Biome.Meadow), Id(Biome.PaleGarden)],
        [Id(Biome.SavannaPlateau), Id(Biome.SavannaPlateau), Id(Biome.Forest), Id(Biome.Forest), Id(Biome.Jungle)],
        [Id(Biome.Badlands), Id(Biome.Badlands), Id(Biome.Badlands), Id(Biome.WoodedBadlands), Id(Biome.WoodedBadlands)]
    ];

    private static readonly Identifier?[][] PlateauBiomesVariant = [
        [Id(Biome.IceSpikes), null, null, null, null],
        [Id(Biome.CherryGrove), null, Id(Biome.Meadow), Id(Biome.Meadow), Id(Biome.OldGrowthPineTaiga)],
        [Id(Biome.CherryGrove), Id(Biome.CherryGrove), Id(Biome.Forest), Id(Biome.BirchForest), null],
        [null, null, null, null, null],
        [Id(Biome.ErodedBadlands), Id(Biome.ErodedBadlands), null, null, null]
    ];

    private static readonly Identifier?[][] ShatteredBiomes = [
        [Id(Biome.WindsweptGravellyHills), Id(Biome.WindsweptGravellyHills), Id(Biome.WindsweptHills), Id(Biome.WindsweptForest), Id(Biome.WindsweptForest)],
        [Id(Biome.WindsweptGravellyHills), Id(Biome.WindsweptGravellyHills), Id(Biome.WindsweptHills), Id(Biome.WindsweptForest), Id(Biome.WindsweptForest)],
        [Id(Biome.WindsweptHills), Id(Biome.WindsweptHills), Id(Biome.WindsweptHills), Id(Biome.WindsweptForest), Id(Biome.WindsweptForest)],
        [null, null, null, null, null],
        [null, null, null, null, null]
    ];

    /// <summary>
    /// Every climate region of the overworld and the biome in it, in vanilla's own order.
    /// </summary>
    /// <remarks>
    /// The order is part of the answer: <c>ParameterList</c>'s search breaks a tie on the first region
    /// it found with that fitness, so two regions of equal distance resolve to whichever was added
    /// first.
    /// </remarks>
    public static List<(ClimateParameterPoint Point, Identifier Biome)> Build() {
        List<(ClimateParameterPoint, Identifier)> biomes = [];

        AddOffCoastBiomes(biomes);
        AddInlandBiomes(biomes);
        AddUndergroundBiomes(biomes);

        return biomes;
    }

    private static void AddOffCoastBiomes(List<(ClimateParameterPoint, Identifier)> biomes) {
        AddSurfaceBiome(biomes, FullRange, FullRange, MushroomFieldsContinentalness, FullRange,
            FullRange, 0.0f, Id(Biome.MushroomFields));

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            AddSurfaceBiome(biomes, temperature, FullRange, DeepOceanContinentalness, FullRange,
                FullRange, 0.0f, Oceans[0][temperatureIndex]);

            AddSurfaceBiome(biomes, temperature, FullRange, OceanContinentalness, FullRange,
                FullRange, 0.0f, Oceans[1][temperatureIndex]);
        }
    }

    /// <summary>
    /// The thirteen weirdness slices, which is what makes the same climate a peak in one band and a
    /// valley in the next.
    /// </summary>
    private static void AddInlandBiomes(List<(ClimateParameterPoint, Identifier)> biomes) {
        AddMidSlice(biomes, ClimateParameter.Span(-1.0f, -0.93333334f));
        AddHighSlice(biomes, ClimateParameter.Span(-0.93333334f, -0.7666667f));
        AddPeaks(biomes, ClimateParameter.Span(-0.7666667f, -0.56666666f));
        AddHighSlice(biomes, ClimateParameter.Span(-0.56666666f, -0.4f));
        AddMidSlice(biomes, ClimateParameter.Span(-0.4f, -0.26666668f));
        AddLowSlice(biomes, ClimateParameter.Span(-0.26666668f, -0.05f));
        AddValleys(biomes, ClimateParameter.Span(-0.05f, 0.05f));
        AddLowSlice(biomes, ClimateParameter.Span(0.05f, 0.26666668f));
        AddMidSlice(biomes, ClimateParameter.Span(0.26666668f, 0.4f));
        AddHighSlice(biomes, ClimateParameter.Span(0.4f, 0.56666666f));
        AddPeaks(biomes, ClimateParameter.Span(0.56666666f, 0.7666667f));
        AddHighSlice(biomes, ClimateParameter.Span(0.7666667f, 0.93333334f));
        AddMidSlice(biomes, ClimateParameter.Span(0.93333334f, 1.0f));
    }

    private static void AddPeaks(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter weirdness) {

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            for (int humidityIndex = 0; humidityIndex < Humidities.Length; humidityIndex++) {
                ClimateParameter humidity = Humidities[humidityIndex];

                Identifier middleBiome = PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHot =
                    PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHotOrSlopeIfCold =
                    PickMiddleBiomeOrBadlandsIfHotOrSlopeIfCold(temperatureIndex, humidityIndex, weirdness);
                Identifier plateauBiome = PickPlateauBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier shatteredBiome = PickShatteredBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier shatteredBiomeOrWindsweptSavanna =
                    MaybePickWindsweptSavannaBiome(temperatureIndex, humidityIndex, weirdness, shatteredBiome);
                Identifier peakBiome = PickPeakBiome(temperatureIndex, humidityIndex, weirdness);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, FarInlandContinentalness), Erosions[0], weirdness,
                    0.0f, peakBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness), Erosions[1], weirdness,
                    0.0f, middleBiomeOrBadlandsIfHotOrSlopeIfCold);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[1], weirdness,
                    0.0f, peakBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness),
                    Between(Erosions[2], Erosions[3]), weirdness, 0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[2], weirdness,
                    0.0f, plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity, MidInlandContinentalness, Erosions[3],
                    weirdness, 0.0f, middleBiomeOrBadlandsIfHot);

                AddSurfaceBiome(biomes, temperature, humidity, FarInlandContinentalness, Erosions[3],
                    weirdness, 0.0f, plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, FarInlandContinentalness), Erosions[4], weirdness,
                    0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness), Erosions[5], weirdness,
                    0.0f, shatteredBiomeOrWindsweptSavanna);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[5], weirdness,
                    0.0f, shatteredBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
                    0.0f, middleBiome);
            }
        }
    }

    private static void AddHighSlice(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter weirdness) {

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            for (int humidityIndex = 0; humidityIndex < Humidities.Length; humidityIndex++) {
                ClimateParameter humidity = Humidities[humidityIndex];

                Identifier middleBiome = PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHot =
                    PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHotOrSlopeIfCold =
                    PickMiddleBiomeOrBadlandsIfHotOrSlopeIfCold(temperatureIndex, humidityIndex, weirdness);
                Identifier plateauBiome = PickPlateauBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier shatteredBiome = PickShatteredBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrWindsweptSavanna =
                    MaybePickWindsweptSavannaBiome(temperatureIndex, humidityIndex, weirdness, middleBiome);
                Identifier slopeBiome = PickSlopeBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier peakBiome = PickPeakBiome(temperatureIndex, humidityIndex, weirdness);

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness,
                    Between(Erosions[0], Erosions[1]), weirdness, 0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness, Erosions[0],
                    weirdness, 0.0f, slopeBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[0], weirdness,
                    0.0f, peakBiome);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness, Erosions[1],
                    weirdness, 0.0f, middleBiomeOrBadlandsIfHotOrSlopeIfCold);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[1], weirdness,
                    0.0f, slopeBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness),
                    Between(Erosions[2], Erosions[3]), weirdness, 0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[2], weirdness,
                    0.0f, plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity, MidInlandContinentalness, Erosions[3],
                    weirdness, 0.0f, middleBiomeOrBadlandsIfHot);

                AddSurfaceBiome(biomes, temperature, humidity, FarInlandContinentalness, Erosions[3],
                    weirdness, 0.0f, plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, FarInlandContinentalness), Erosions[4], weirdness,
                    0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness), Erosions[5], weirdness,
                    0.0f, middleBiomeOrWindsweptSavanna);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[5], weirdness,
                    0.0f, shatteredBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
                    0.0f, middleBiome);
            }
        }
    }

    private static void AddMidSlice(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter weirdness) {

        AddSurfaceBiome(biomes, FullRange, FullRange, CoastContinentalness,
            Between(Erosions[0], Erosions[2]), weirdness, 0.0f, Id(Biome.StonyShore));

        AddSurfaceBiome(biomes, Between(Temperatures[1], Temperatures[2]), FullRange,
            Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
            0.0f, Id(Biome.Swamp));

        AddSurfaceBiome(biomes, Between(Temperatures[3], Temperatures[4]), FullRange,
            Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
            0.0f, Id(Biome.MangroveSwamp));

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            for (int humidityIndex = 0; humidityIndex < Humidities.Length; humidityIndex++) {
                ClimateParameter humidity = Humidities[humidityIndex];

                Identifier middleBiome = PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHot =
                    PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHotOrSlopeIfCold =
                    PickMiddleBiomeOrBadlandsIfHotOrSlopeIfCold(temperatureIndex, humidityIndex, weirdness);
                Identifier shatteredBiome = PickShatteredBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier plateauBiome = PickPlateauBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier beachBiome = PickBeachBiome(temperatureIndex);
                Identifier middleBiomeOrWindsweptSavanna =
                    MaybePickWindsweptSavannaBiome(temperatureIndex, humidityIndex, weirdness, middleBiome);
                Identifier shatteredCoastBiome =
                    PickShatteredCoastBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier slopeBiome = PickSlopeBiome(temperatureIndex, humidityIndex, weirdness);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[0], weirdness,
                    0.0f, slopeBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(NearInlandContinentalness, MidInlandContinentalness), Erosions[1], weirdness,
                    0.0f, middleBiomeOrBadlandsIfHotOrSlopeIfCold);

                AddSurfaceBiome(biomes, temperature, humidity, FarInlandContinentalness, Erosions[1],
                    weirdness, 0.0f, temperatureIndex == 0 ? slopeBiome : plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness, Erosions[2],
                    weirdness, 0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity, MidInlandContinentalness, Erosions[2],
                    weirdness, 0.0f, middleBiomeOrBadlandsIfHot);

                AddSurfaceBiome(biomes, temperature, humidity, FarInlandContinentalness, Erosions[2],
                    weirdness, 0.0f, plateauBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(CoastContinentalness, NearInlandContinentalness), Erosions[3], weirdness,
                    0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[3], weirdness,
                    0.0f, middleBiomeOrBadlandsIfHot);

                // A negative weirdness slice is the "not shattered" side, and it is what puts a beach
                // on a coast rather than running the middle biome down to the water.
                if (weirdness.Max < 0L) {
                    AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness, Erosions[4],
                        weirdness, 0.0f, beachBiome);

                    AddSurfaceBiome(biomes, temperature, humidity,
                        Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[4],
                        weirdness, 0.0f, middleBiome);
                } else {
                    AddSurfaceBiome(biomes, temperature, humidity,
                        Between(CoastContinentalness, FarInlandContinentalness), Erosions[4], weirdness,
                        0.0f, middleBiome);
                }

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness, Erosions[5],
                    weirdness, 0.0f, shatteredCoastBiome);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness, Erosions[5],
                    weirdness, 0.0f, middleBiomeOrWindsweptSavanna);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[5], weirdness,
                    0.0f, shatteredBiome);

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness, Erosions[6],
                    weirdness, 0.0f, weirdness.Max < 0L ? beachBiome : middleBiome);

                if (temperatureIndex == 0) {
                    AddSurfaceBiome(biomes, temperature, humidity,
                        Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6],
                        weirdness, 0.0f, middleBiome);
                }
            }
        }
    }

    private static void AddLowSlice(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter weirdness) {

        AddSurfaceBiome(biomes, FullRange, FullRange, CoastContinentalness,
            Between(Erosions[0], Erosions[2]), weirdness, 0.0f, Id(Biome.StonyShore));

        AddSurfaceBiome(biomes, Between(Temperatures[1], Temperatures[2]), FullRange,
            Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
            0.0f, Id(Biome.Swamp));

        AddSurfaceBiome(biomes, Between(Temperatures[3], Temperatures[4]), FullRange,
            Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness,
            0.0f, Id(Biome.MangroveSwamp));

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            for (int humidityIndex = 0; humidityIndex < Humidities.Length; humidityIndex++) {
                ClimateParameter humidity = Humidities[humidityIndex];

                Identifier middleBiome = PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHot =
                    PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);
                Identifier middleBiomeOrBadlandsIfHotOrSlopeIfCold =
                    PickMiddleBiomeOrBadlandsIfHotOrSlopeIfCold(temperatureIndex, humidityIndex, weirdness);
                Identifier beachBiome = PickBeachBiome(temperatureIndex);
                Identifier middleBiomeOrWindsweptSavanna =
                    MaybePickWindsweptSavannaBiome(temperatureIndex, humidityIndex, weirdness, middleBiome);
                Identifier shatteredCoastBiome =
                    PickShatteredCoastBiome(temperatureIndex, humidityIndex, weirdness);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness,
                    Between(Erosions[0], Erosions[1]), weirdness, 0.0f, middleBiomeOrBadlandsIfHot);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness),
                    Between(Erosions[0], Erosions[1]), weirdness, 0.0f,
                    middleBiomeOrBadlandsIfHotOrSlopeIfCold);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness,
                    Between(Erosions[2], Erosions[3]), weirdness, 0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness),
                    Between(Erosions[2], Erosions[3]), weirdness, 0.0f, middleBiomeOrBadlandsIfHot);

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness,
                    Between(Erosions[3], Erosions[4]), weirdness, 0.0f, beachBiome);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[4], weirdness,
                    0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness, Erosions[5],
                    weirdness, 0.0f, shatteredCoastBiome);

                AddSurfaceBiome(biomes, temperature, humidity, NearInlandContinentalness, Erosions[5],
                    weirdness, 0.0f, middleBiomeOrWindsweptSavanna);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness), Erosions[5], weirdness,
                    0.0f, middleBiome);

                AddSurfaceBiome(biomes, temperature, humidity, CoastContinentalness, Erosions[6],
                    weirdness, 0.0f, beachBiome);

                if (temperatureIndex == 0) {
                    AddSurfaceBiome(biomes, temperature, humidity,
                        Between(NearInlandContinentalness, FarInlandContinentalness), Erosions[6],
                        weirdness, 0.0f, middleBiome);
                }
            }
        }
    }

    /// <summary>
    /// The band around zero weirdness, which is where rivers are.
    /// </summary>
    /// <remarks>
    /// Frozen and unfrozen are split at every step rather than picked from a table, because a river is
    /// a river or a frozen river on temperature alone and nothing else about the climate matters.
    /// </remarks>
    private static void AddValleys(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter weirdness) {

        AddSurfaceBiome(biomes, FrozenRange, FullRange, CoastContinentalness,
            Between(Erosions[0], Erosions[1]), weirdness, 0.0f,
            weirdness.Max < 0L ? Id(Biome.StonyShore) : Id(Biome.FrozenRiver));

        AddSurfaceBiome(biomes, UnfrozenRange, FullRange, CoastContinentalness,
            Between(Erosions[0], Erosions[1]), weirdness, 0.0f,
            weirdness.Max < 0L ? Id(Biome.StonyShore) : Id(Biome.River));

        AddSurfaceBiome(biomes, FrozenRange, FullRange, NearInlandContinentalness,
            Between(Erosions[0], Erosions[1]), weirdness, 0.0f, Id(Biome.FrozenRiver));

        AddSurfaceBiome(biomes, UnfrozenRange, FullRange, NearInlandContinentalness,
            Between(Erosions[0], Erosions[1]), weirdness, 0.0f, Id(Biome.River));

        AddSurfaceBiome(biomes, FrozenRange, FullRange,
            Between(CoastContinentalness, FarInlandContinentalness),
            Between(Erosions[2], Erosions[5]), weirdness, 0.0f, Id(Biome.FrozenRiver));

        AddSurfaceBiome(biomes, UnfrozenRange, FullRange,
            Between(CoastContinentalness, FarInlandContinentalness),
            Between(Erosions[2], Erosions[5]), weirdness, 0.0f, Id(Biome.River));

        AddSurfaceBiome(biomes, FrozenRange, FullRange, CoastContinentalness, Erosions[6], weirdness,
            0.0f, Id(Biome.FrozenRiver));

        AddSurfaceBiome(biomes, UnfrozenRange, FullRange, CoastContinentalness, Erosions[6], weirdness,
            0.0f, Id(Biome.River));

        AddSurfaceBiome(biomes, Between(Temperatures[1], Temperatures[2]), FullRange,
            Between(InlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness, 0.0f,
            Id(Biome.Swamp));

        AddSurfaceBiome(biomes, Between(Temperatures[3], Temperatures[4]), FullRange,
            Between(InlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness, 0.0f,
            Id(Biome.MangroveSwamp));

        AddSurfaceBiome(biomes, FrozenRange, FullRange,
            Between(InlandContinentalness, FarInlandContinentalness), Erosions[6], weirdness, 0.0f,
            Id(Biome.FrozenRiver));

        for (int temperatureIndex = 0; temperatureIndex < Temperatures.Length; temperatureIndex++) {
            ClimateParameter temperature = Temperatures[temperatureIndex];

            for (int humidityIndex = 0; humidityIndex < Humidities.Length; humidityIndex++) {
                ClimateParameter humidity = Humidities[humidityIndex];

                Identifier middleBiomeOrBadlandsIfHot =
                    PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);

                AddSurfaceBiome(biomes, temperature, humidity,
                    Between(MidInlandContinentalness, FarInlandContinentalness),
                    Between(Erosions[0], Erosions[1]), weirdness, 0.0f, middleBiomeOrBadlandsIfHot);
            }
        }
    }

    /// <summary>
    /// The four cave biomes, which are the only regions with a depth other than the surface's.
    /// </summary>
    private static void AddUndergroundBiomes(List<(ClimateParameterPoint, Identifier)> biomes) {
        AddUndergroundBiome(biomes, FullRange, FullRange, ClimateParameter.Span(0.8f, 1.0f), FullRange,
            FullRange, 0.0f, Id(Biome.DripstoneCaves));

        AddUndergroundBiome(biomes, FullRange, ClimateParameter.Span(0.7f, 1.0f), FullRange, FullRange,
            FullRange, 0.0f, Id(Biome.LushCaves));

        AddUndergroundBiome(biomes, FullRange, FullRange,
            Between(CoastContinentalness, InlandContinentalness), Between(Erosions[5], Erosions[6]),
            ClimateParameter.Span(-1.1f, -0.85f), 0.0f, Id(Biome.SulfurCaves));

        AddBottomBiome(biomes, FullRange, FullRange, FullRange, Between(Erosions[0], Erosions[1]),
            FullRange, 0.0f, Id(Biome.DeepDark));
    }

    // ------------------------------------------------------------------ the picks

    private static Identifier PickMiddleBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        if (weirdness.Max < 0L) {
            return MiddleBiomes[temperatureIndex][humidityIndex];
        }

        return MiddleBiomesVariant[temperatureIndex][humidityIndex]
            ?? MiddleBiomes[temperatureIndex][humidityIndex];
    }

    private static Identifier PickMiddleBiomeOrBadlandsIfHot(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        return temperatureIndex == 4
            ? PickBadlandsBiome(humidityIndex, weirdness)
            : PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
    }

    private static Identifier PickMiddleBiomeOrBadlandsIfHotOrSlopeIfCold(int temperatureIndex,
        int humidityIndex, ClimateParameter weirdness) {

        return temperatureIndex == 0
            ? PickSlopeBiome(temperatureIndex, humidityIndex, weirdness)
            : PickMiddleBiomeOrBadlandsIfHot(temperatureIndex, humidityIndex, weirdness);
    }

    private static Identifier MaybePickWindsweptSavannaBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness, Identifier underlyingBiome) {

        return temperatureIndex > 1 && humidityIndex < 4 && weirdness.Max >= 0L
            ? Id(Biome.WindsweptSavanna)
            : underlyingBiome;
    }

    private static Identifier PickShatteredCoastBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        Identifier beachOrMiddleBiome = weirdness.Max >= 0L
            ? PickMiddleBiome(temperatureIndex, humidityIndex, weirdness)
            : PickBeachBiome(temperatureIndex);

        return MaybePickWindsweptSavannaBiome(temperatureIndex, humidityIndex, weirdness,
            beachOrMiddleBiome);
    }

    /// <summary>
    /// The beach a temperature gets. The hottest is desert rather than beach, which is why a hot coast
    /// runs sand straight into the water with no beach biome between.
    /// </summary>
    /// <remarks>
    /// Vanilla takes a humidity index too and ignores it.
    /// </remarks>
    private static Identifier PickBeachBiome(int temperatureIndex) {
        if (temperatureIndex == 0) {
            return Id(Biome.SnowyBeach);
        }

        return temperatureIndex == 4 ? Id(Biome.Desert) : Id(Biome.Beach);
    }

    private static Identifier PickBadlandsBiome(int humidityIndex, ClimateParameter weirdness) {
        if (humidityIndex < 2) {
            return weirdness.Max < 0L ? Id(Biome.Badlands) : Id(Biome.ErodedBadlands);
        }

        return humidityIndex < 3 ? Id(Biome.Badlands) : Id(Biome.WoodedBadlands);
    }

    private static Identifier PickPlateauBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        if (weirdness.Max >= 0L) {
            Identifier? variant = PlateauBiomesVariant[temperatureIndex][humidityIndex];

            if (variant is not null) {
                return variant.Value;
            }
        }

        return PlateauBiomes[temperatureIndex][humidityIndex];
    }

    private static Identifier PickPeakBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        if (temperatureIndex <= 2) {
            return weirdness.Max < 0L ? Id(Biome.JaggedPeaks) : Id(Biome.FrozenPeaks);
        }

        return temperatureIndex == 3
            ? Id(Biome.StonyPeaks)
            : PickBadlandsBiome(humidityIndex, weirdness);
    }

    private static Identifier PickSlopeBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        if (temperatureIndex >= 3) {
            return PickPlateauBiome(temperatureIndex, humidityIndex, weirdness);
        }

        return humidityIndex <= 1 ? Id(Biome.SnowySlopes) : Id(Biome.Grove);
    }

    private static Identifier PickShatteredBiome(int temperatureIndex, int humidityIndex,
        ClimateParameter weirdness) {

        return ShatteredBiomes[temperatureIndex][humidityIndex]
            ?? PickMiddleBiome(temperatureIndex, humidityIndex, weirdness);
    }

    // ------------------------------------------------------------------ the adds

    /// <summary>
    /// A surface region, which is <b>two</b> entries: one at depth zero and one at depth one.
    /// </summary>
    /// <remarks>
    /// Depth is how far under the surface a position is, so zero is the ground and one is a little way
    /// into it. Adding both is what stops the region losing to a cave biome the moment a position is
    /// slightly below the surface.
    /// </remarks>
    private static void AddSurfaceBiome(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter temperature, ClimateParameter humidity, ClimateParameter continentalness,
        ClimateParameter erosion, ClimateParameter weirdness, float offset, Identifier biome) {

        biomes.Add((Parameters(temperature, humidity, continentalness, erosion,
            ClimateParameter.Point(0.0f), weirdness, offset), biome));

        biomes.Add((Parameters(temperature, humidity, continentalness, erosion,
            ClimateParameter.Point(1.0f), weirdness, offset), biome));
    }

    private static void AddUndergroundBiome(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter temperature, ClimateParameter humidity, ClimateParameter continentalness,
        ClimateParameter erosion, ClimateParameter weirdness, float offset, Identifier biome) {

        biomes.Add((Parameters(temperature, humidity, continentalness, erosion,
            ClimateParameter.Span(0.2f, 0.9f), weirdness, offset), biome));
    }

    /// <summary>The deep dark's band, below everything the underground regions reach.</summary>
    private static void AddBottomBiome(List<(ClimateParameterPoint, Identifier)> biomes,
        ClimateParameter temperature, ClimateParameter humidity, ClimateParameter continentalness,
        ClimateParameter erosion, ClimateParameter weirdness, float offset, Identifier biome) {

        biomes.Add((Parameters(temperature, humidity, continentalness, erosion,
            ClimateParameter.Point(1.1f), weirdness, offset), biome));
    }

    /// <summary><c>Climate.parameters</c>, whose offset is quantised like every other coordinate.</summary>
    private static ClimateParameterPoint Parameters(ClimateParameter temperature,
        ClimateParameter humidity, ClimateParameter continentalness, ClimateParameter erosion,
        ClimateParameter depth, ClimateParameter weirdness, float offset) {

        return new ClimateParameterPoint(temperature, humidity, continentalness, erosion, depth,
            weirdness, ClimateParameter.Quantize(offset));
    }

    /// <summary>
    /// <c>Parameter.span(Parameter, Parameter)</c>: the first's minimum to the second's maximum.
    /// </summary>
    /// <remarks>
    /// Not the union of the two. Every caller passes them in order so the two agree, but transcribing
    /// it as a union would be a different method that happens to have the same answers here.
    /// </remarks>
    private static ClimateParameter Between(ClimateParameter from, ClimateParameter to) {
        return new ClimateParameter(from.Min, to.Max);
    }

    private static Identifier Id(IBiome biome) => biome.Identifier;
}
