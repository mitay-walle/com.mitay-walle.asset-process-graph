using System;
using GraphProcessor;
using UnityEditor;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    
    [Serializable, NodeMenuItem("Process/Save Assets", typeof(AssetProcessGraph))]
    public class SaveAndRefreshNode : ProcessImporterNode
    {
#if UNITY_EDITOR
        public override string name => "Save and Refresh";
        [Input("Assets")] protected Object[] assets;
        [Output("Assets")] protected Object[] outputAssets;
        
        protected override void ProcessImporter(AssetImporter importer) => importer.SaveAndReimport();
        protected override void Process()
        {
            base.Process();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            outputAssets = assets;
        }
#endif
    }
}