using GraphProcessor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace mitaywalle.AssetProcessGraph.Editor
{
	public class AssetProcessGraphWindowGraphView : BaseGraphView
	{
		public AssetProcessGraphWindowGraphView(EditorWindow window) : base(window) { }

		public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
		{
			evt.menu.AppendSeparator();

			// Add the "Hello World" menu item which print Hello World in the console
			evt.menu.AppendAction("Hello World",
			                      (e) => Debug.Log("Hello World"), DropdownMenuAction.AlwaysEnabled
				);

			base.BuildContextualMenu(evt);
		}
	}
}