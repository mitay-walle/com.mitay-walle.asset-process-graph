using GraphProcessor;
using UnityEditor;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    //[Serializable, NodeMenuItem("Process/NodeName", typeof(AssetProcessGraph))]
    public abstract class ProcessImporterNode : AssetProcessGraphNode
    {
#if UNITY_EDITOR
        [Input("Importers")] protected AssetImporter[] importers;
        [Output("Importers")] protected AssetImporter[] outputImporters;
        protected override void Process()
        {
            foreach (var asset in importers)
            {
                ProcessImporter(asset);
            }

            outputImporters = importers;
        }

        protected abstract void ProcessImporter(AssetImporter importer);
#endif
    }
}