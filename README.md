# Unity3d Asset Process Graph
![](https://github.com/mitay-walle/Unity3d-AssetProcessGraph/blob/main/Documentation/graph_preview.jpg)
Designer-oriented replacement for Unity3d-official Asset Graph (abondoned at 2020), help batch process assets. UPM package, Easy extendable

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
## Process
- Save and Refresh
- Apply Preset ( You can choose to only apply some properties from a Preset and exclude others. Right-click a property and choose Exclude Property. The window displays a red horizontal line next to excluded properties )
- Replace Shaders
