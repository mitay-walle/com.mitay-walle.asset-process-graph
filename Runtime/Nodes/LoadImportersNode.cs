using System;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Load/Importers From Folders", typeof(AssetProcessGraph))]
    public class LoadImportersNode : AssetProcessGraphNode
    {
        public override string name => "Importers From Folders";
#if UNITY_EDITOR
        [SerializeField] DefaultAsset[] Folders;
        [Input("Asset Type"), SerializeField] string assetType;
        [Output("Importers")] AssetImporter[] importers;
        public override bool canProcess => Folders != null && Folders.Length > 0 && !string.IsNullOrEmpty(assetType);

        protected override void Process()
        {
            importers = AssetDatabase.FindAssets($"t:{assetType}", Folders.Select(AssetDatabase.GetAssetPath).ToArray())
                .Select(AssetDatabase.GUIDToAssetPath).Select(AssetImporter.GetAtPath).ToArray();
        }
#endif
    }
}