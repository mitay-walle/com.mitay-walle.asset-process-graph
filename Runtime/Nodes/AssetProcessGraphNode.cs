using System;
using GraphProcessor;
namespace mitaywalle.AssetProcessGraph.Nodes
{
	[Serializable]
	public abstract class AssetProcessGraphNode : BaseNode
	{
		public override bool isRenamable => true;
	}
}