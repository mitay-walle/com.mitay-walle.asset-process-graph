using System;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Process/Model Importer/Set Material Mode", typeof(AssetProcessGraph))]
    public class ProcessImporterSetImportMaterialNode : ProcessImporterNode
    {
        public override string name => "Set Material Mode";
        [SerializeField] private ModelImporterMaterialImportMode Mode;
		
        protected override void ProcessImporter(AssetImporter importer)
        {
            if (importer is ModelImporter modelImporter)
            {
                modelImporter.materialImportMode = Mode;
            }
        }
    }
}