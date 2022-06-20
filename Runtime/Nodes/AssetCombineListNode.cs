using System;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Utils/Assets Combine List", typeof(AssetProcessGraph))]
    public class AssetCombineListNode : ProcessAssetNode
    {
#if UNITY_EDITOR
        public override string name => "Assets Combine List";
        [SerializeField, Input("Assets")] protected Object[] assets1;

        protected override void Process()
        {
            outputAssets = assets.Concat(assets1).ToArray();
        }


#endif
        protected override void ProcessAsset(Object asset)
        {
        }
    }
}