# Code Generator
This directory contains the code generation project for the Minecraft library. 
It generates C# code from the Minecraft protocol specifications.

To use simply run the project, it will automatically generate the code and place it in the `Data/Generated` directory.


The data that is project uses is obtained in two different ways:

## 1. From the builtin Minecraft server jar
Download the official server jar and run the following command:

```bash
java -DbundlerMainClass="net.minecraft.data.Main" -jar THESERVERJAR.jar --all --output OUTPUTFOLDER --all
```

This will give you a 'reports' folder in the OUTPUTFOLDER, which contains most of the files.


## 2. From Minestom's data generator

You can get the project from [its GitHub](https://github.com/Minestom/MinestomDataGenerator).

One you have it run the project, it will output a bunch of files to `MinestomData`. There you can find the
things that are needed for this project.
