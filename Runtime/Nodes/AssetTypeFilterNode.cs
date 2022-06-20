using System;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Filter/Assets Type Filter", typeof(AssetProcessGraph))]
    public class AssetTypeFilterNode : ProcessAssetNode
    {
#if UNITY_EDITOR
        public override string name => "Assets Type Filter";
        [SerializeField] string assetType;

        protected override void Process()
        {
            outputAssets = assets.Where(asset => asset.GetType().Name == assetType).ToArray();
        }


#endif
        protected override void ProcessAsset(Object asset)
        {
        }
    }
}