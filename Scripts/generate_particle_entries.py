#!/usr/bin/env/python3

import json
import os

# Converts keys like 'minecraft:angry_villager' to 'AngryVillager'
def pascal_case_name(key):
    # Remove namespace
    if ':' in key:
        key = key.split(':', 1)[1]
    # Split by _ and capitalize
    return ''.join(word.capitalize() for word in key.split('_'))

# JSON file path
json_path = os.path.abspath("../Minecraft/Schemas/Registry/registries.json")

# Read JSON
with open(json_path, "r") as file:
    data = json.load(file)

# Navigate to the node "minecraft:particle_type"/"entries"
particle_entries = data["minecraft:particle_type"]["entries"]

# Output in desired format
for key in particle_entries:
    pascal_name = pascal_case_name(key)
    print(f'public static SimpleParticle {pascal_name} => IParticle.DefaultOfType("{key}");')
