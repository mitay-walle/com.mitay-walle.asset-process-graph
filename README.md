# Unity3d Asset Process Graph
Designer-oriented replacement for Unity3d-official Asset Graph (abondoned at 2020), help batch process assets. UPM package, Easy extendable
![](https://github.com/mitay-walle/Unity3d-AssetProcessGraph/blob/main/Documentation/graph_preview.jpg)

# Install
 as dependency you need install NodeGraphProcessor as UPM:
 1. PackageManager -> Add package from Git URL
 
 "com.alelievr.node-graph-processor": "https://github.com/alelievr/NodeGraphProcessor.git#upm"
 
 2. PackageManager -> Add package from Git URL
 
 https://github.com/mitay-walle/Unity3d-AssetProcessGraph.git

# Nodes
## Load
- Load Assets From Folders
- Load Importers From Folders
## Filter
- filter by Name
- filter by Asset type
- filter by Dependency-asset
## Process
- Save and Refresh
- Combine asset lists
- Apply Preset ( You can choose to only apply some properties from a Preset and exclude others. Right-click a property and choose Exclude Property. The window displays a red horizontal line next to excluded properties )
- Replace Shaders (In prefabs or Materials)
- Replace Textures (In prefabs or Materials)
- Set Model Material Mode
