using System;
using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
namespace mitaywalle.AssetProcessGraph.Nodes
{
	[Serializable]
	public class ShaderReplaceData
	{
		public Shader From;
		public Shader To;
	}

	[Serializable, NodeMenuItem("Process/Replace Shader", typeof(AssetProcessGraph))]
	public class ProcessReplaceShaderNode : ProcessNode
	{
		public override string name => "Replace Shader";

		[SerializeField] protected List<ShaderReplaceData> replaceData;

		List<Material> _tempMaterials = new List<Material>();
		List<Renderer> _tempRenderers = new List<Renderer>();

		protected override void ProcessAsset(Object asset)
		{
			_tempMaterials.Clear();
			switch (asset)
			{
				case Material foundMaterial:
					_tempMaterials.Add(foundMaterial);
					break;
				case GameObject gameObject:
					gameObject.GetComponentsInChildren(true, _tempRenderers);
					_tempMaterials.AddRange(_tempRenderers.SelectMany(r => r.sharedMaterials));
					break;
			}

			foreach (Material material in _tempMaterials)
			{
				var data = replaceData.Find(data => data.From == material.shader);
				if (data != null)
				{
					material.shader = data.To;
					Debug.Log($"replace shader at '{AssetDatabase.GetAssetPath(asset)}' | material '{material.name}'");
				}
			}
		}
	}
}