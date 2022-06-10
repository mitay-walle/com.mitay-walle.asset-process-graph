using System;
using GraphProcessor;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;
using Object = UnityEngine.Object;
namespace mitaywalle.AssetProcessGraph.Nodes
{
	[Serializable, NodeMenuItem("Process/Apply Preset", typeof(AssetProcessGraph))]
	public class ProcessApplyPresetNode : ProcessImporterNode
	{
		public override string name => $"Apply Preset {Preset?.name}";
		[Input("Assets")] protected Object[] assets;
		[Output("Assets")] protected Object[] outputAssets;
		[SerializeField] Preset Preset;

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
			if (Preset.CanBeAppliedTo(asset))
			{
				Preset.ApplyTo(asset);
			}
		}

		protected override void ProcessImporter(AssetImporter importer)
		{
			if (Preset.CanBeAppliedTo(importer))
			{
				Preset.ApplyTo(importer);
			}
		}
	}
}