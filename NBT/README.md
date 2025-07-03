# NBT
An NBT (Named Binary Tag) parser and writer for C#. Completely compatible with Minecraft's NBT format.

## Example Usage

#### Serialising
```csharp
CompoundTag someTag = new(null, 
    new StringTag("name", "Test"), 
    new IntegerTag("age", 30), 
    new ListTag<IntegerTag>("SomeList", [new IntegerTag(null, 1), new IntegerTag(null, 2)]
    ),
    new ArrayTag<sbyte>("AnArrayOfBytes", 0, 1, 2)
);
byte[] serialised = someTag.Serialise();
```

#### Deserialising
```csharp
byte[] data = ...; // Some NBT data
INbtTag deserialised = NbtReader.ReadNbt(data);

// You can cast to the specific type you expect
```
