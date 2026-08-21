namespace Minecraft.Schemas.Entities;

/// <summary>
/// A tropical fish's shape and markings. The value is vanilla's packed id, <c>base | index &lt;&lt; 8</c>,
/// where the base is the body shape and the index the pattern drawn on it, so the twelve are not
/// numbered zero to eleven.
/// </summary>
public enum TropicalFishPattern {
    Kob = 0,
    Sunstreak = 256,
    Snooper = 512,
    Dasher = 768,
    Brinely = 1024,
    Spotty = 1280,
    Flopper = 1,
    Stripey = 257,
    Glitter = 513,
    Blockfish = 769,
    Betty = 1025,
    Clayfish = 1281
}
