using System;
using GraphProcessor;
using UnityEditor;
using Object = UnityEngine.Object;
namespace mitaywalle.AssetProcessGraph.Nodes
{
	[Serializable, NodeMenuItem("Process/Save Assets", typeof(AssetProcessGraph))]
	public class SaveAndRefreshNode : ProcessNode
	{
		public override string name => "Save and Refresh";

		protected override void Process()
		{
			base.Process();
			#if UNITY_EDITOR
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
  #endif


		}
		protected override void ProcessAsset(Object asset) { }
	}
}