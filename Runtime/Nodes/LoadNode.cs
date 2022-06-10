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
		public override string name=>"Assets From Folders";
		[SerializeField] DefaultAsset[] Folders;
		[Input("Asset Type"), SerializeField] string assetType;
		[Output("Assets")] Object[] assets;

		public override bool canProcess => Folders != null && Folders.Length > 0 && !string.IsNullOrEmpty(assetType);

		protected override void Process()
		{
			#if UNITY_EDITOR
			assets = AssetDatabase.FindAssets($"t:{assetType}", Folders.Select(AssetDatabase.GetAssetPath).ToArray())
				.Select(AssetDatabase.GUIDToAssetPath).Select(AssetDatabase.LoadAssetAtPath<Object>).ToArray(); 
  #endif
  
    
		}
	}
}