using System;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Load/Assets From Folders", typeof(AssetProcessGraph))]
    public class LoadNode : AssetProcessGraphNode
    {
#if UNITY_EDITOR
        public override string name => "Assets From Folders";
        [SerializeField] DefaultAsset[] Folders;
        [Output("Assets")] Object[] assets;

        public override bool canProcess => Folders != null && Folders.Length > 0;

        protected override void Process()
        {
            assets = AssetDatabase.FindAssets("", Folders.Select(AssetDatabase.GetAssetPath).ToArray())
                .Select(AssetDatabase.GUIDToAssetPath).Select(AssetDatabase.LoadAssetAtPath<Object>).ToArray();

            if (assets == null)
            {
                Debug.LogError("No assets found!");
            }
        }
#endif
    }
}