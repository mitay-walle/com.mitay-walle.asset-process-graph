using GraphProcessor;
using mitaywalle.AssetProcessGraph.Nodes;
using UnityEngine.UIElements;

namespace mitaywalle.AssetProcessGraph.Editor
{
    [NodeCustomEditor(typeof(ProcessAssetNode))]
    public class ProcessAssetNodeView : BaseNodeView
    {
        ProcessAssetNode node;
        Label debugLabel;

        public override void Enable()
        {
            node = nodeTarget as ProcessAssetNode;
            base.Enable();
            debugLabel = new Label(node.ToString());
            debugContainer.Add(debugLabel);
        }
    }
    
}