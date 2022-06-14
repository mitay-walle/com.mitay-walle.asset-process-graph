using System;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor.Presets;
#endif

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Process/Apply Preset", typeof(AssetProcessGraph))]
    public class ProcessApplyPresetNode : ProcessImporterNode
    {
        [Input("Assets")] protected Object[] assets;
        [Output("Assets")] protected Object[] outputAssets;
#if UNITY_EDITOR
        [SerializeField] Preset Preset;
        public override string name => $"Apply Preset {Preset?.name}";
#endif
        protected override void Process()
        {
            base.Process();
            if (assets != null)
            {
                foreach (Object asset in assets)
                {
                    ProcessAsset(asset);
                }
            }

            outputAssets = assets;
        }

        protected void ProcessAsset(Object asset)
        {
#if UNITY_EDITOR
            if (Preset.CanBeAppliedTo(asset))
            {
                Preset.ApplyTo(asset);
            }
#endif
        }

#if UNITY_EDITOR
        protected override void ProcessImporter(AssetImporter importer)
        {
            if (Preset.CanBeAppliedTo(importer))
            {
                Preset.ApplyTo(importer);
            }
        }
#endif
    }
}