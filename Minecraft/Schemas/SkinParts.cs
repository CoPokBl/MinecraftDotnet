namespace Minecraft.Schemas;

[Flags]
public enum SkinParts : sbyte {  // sbyte because PlayerMeta stores it as a byte
    CapeEnabled = 0x01,
    JacketEnabled = 0x02,
    LeftSleeveEnabled = 0x04,
    RightSleeveEnabled = 0x08,
    LeftPantsEnabled = 0x10,
    RightPantsEnabled = 0x20,
    HatEnabled = 0x40,
    
    All = CapeEnabled | JacketEnabled | LeftSleeveEnabled | RightSleeveEnabled | LeftPantsEnabled | RightPantsEnabled | HatEnabled
}
