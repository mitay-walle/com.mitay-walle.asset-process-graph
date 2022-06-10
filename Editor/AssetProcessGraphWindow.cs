using GraphProcessor;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace mitaywalle.AssetProcessGraph.Editor
{
	public class AssetProcessGraphWindow : BaseGraphWindow
	{
		AssetProcessGraph _graph;

		[OnOpenAsset]
		//Handles opening the editor window when double-clicking project files
		public static bool OnOpenAsset(int instanceID, int line)
		{
			AssetProcessGraph graph = EditorUtility.InstanceIDToObject(instanceID) as AssetProcessGraph;
			if (graph == null) return false;
			
			BaseGraphWindow window = Open();
			window.InitializeGraph(graph);
			return true;
		}


		[MenuItem("Window/Asset Management/Asset Process Graph")]
		public static BaseGraphWindow Open()
		{
			AssetProcessGraphWindow graphWindow = GetWindow<AssetProcessGraphWindow>();

			graphWindow.Show();
			// Set the window title
			graphWindow.titleContent = new GUIContent("Asset Process Graph");

			return graphWindow;
		}

		protected override void InitializeWindow(BaseGraph graph)
		{
			_graph = graph as AssetProcessGraph;
			// Here you can use the default BaseGraphView or a custom one (see section below)
			var graphView = new AssetProcessGraphWindowGraphView(this);
			var toolbarView = new ToolbarView(graphView);
			graphView.Add(toolbarView);
			rootView.Add(graphView);
		}
	}
}