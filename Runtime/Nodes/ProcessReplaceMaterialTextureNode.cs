using System;
using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable]
    public class TextureReplaceData
    {
        public Texture From;
        public Texture To;
    }

    [Serializable, NodeMenuItem("Process/Replace Texture", typeof(AssetProcessGraph))]
    public class ProcessReplaceMaterialTextureNode : ProcessAssetNode
    {
        public override string name => "Replace Texture";

        [SerializeField] protected List<TextureReplaceData> replaceData;

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
                var count = material.shader.GetPropertyCount();
                for (int i = 0; i < count; i++)
                {
                    var index = material.shader.GetPropertyNameId(i);
                    
                    if (material.shader.GetPropertyType(i) == ShaderPropertyType.Texture)
                    {
                        var texture = material.GetTexture(index);
                        if (texture)
                        {
                            var data = replaceData.Find(data => data.From == texture);
                            if (data != null)
                            {
                                material.SetTexture(index, data.To);
#if UNITY_EDITOR
                      					Debug.Log($"replace texture at '{AssetDatabase.GetAssetPath(asset)}' | material '{material.name}'");
#endif
                            }
                        }
                    }
                }
            }
        }
    }
}