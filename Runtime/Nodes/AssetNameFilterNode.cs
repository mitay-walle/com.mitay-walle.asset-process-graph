using System;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Filter/Assets Name Filter", typeof(AssetProcessGraph))]
    public class AssetNameFilterNode : ProcessAssetNode
    {
#if UNITY_EDITOR
        public override string name => "Assets Name Filter";
        [SerializeField] string assetName;

        protected override void Process()
        {
            outputAssets = assets.Where(asset => asset.name.Contains(assetName)).ToArray();
            
        }


#endif
        protected override void ProcessAsset(Object asset)
        {
        }
    }
}