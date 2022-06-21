using System;
using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace mitaywalle.AssetProcessGraph.Nodes
{
    [Serializable, NodeMenuItem("Filter/Assets Dependency Filter", typeof(AssetProcessGraph))]
    public class AssetDependencyFilterNode : ProcessAssetNode
    {
        public override string name => "Assets Dependency Filter";
        [SerializeField] private bool _recursive = true;
        [SerializeField] private Object objectFilter;
        [SerializeField] private List<Object> filteredObjects;


        protected override void Process()
        {
            filteredObjects = new List<Object>();
            base.Process();

            outputAssets = filteredObjects.ToArray();
        }


        protected override void ProcessAsset(Object asset)
        {
#if UNITY_EDITOR
            var _dependencies = AssetDatabase.GetDependencies(AssetDatabase.GetAssetPath(asset), _recursive)
                .Select(AssetDatabase.LoadAssetAtPath<Object>).ToList();

            for (int i = 0; i < _dependencies.Count; i++)
            {
                if (_dependencies[i] == objectFilter)
                {
                    filteredObjects.Add(asset);
                    break;
                }
            }
#endif
        }
    }
}