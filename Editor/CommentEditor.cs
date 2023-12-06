using UnityEditor;
using UnityEngine;

namespace Comments.Editor
{
	[CustomEditor(typeof(Comment))]
	public class CommentEditor : UnityEditor.Editor
	{
		private const int FontSize = 14;
		private const FontStyle Style = FontStyle.Italic;
		private static readonly Color MessageColor = new Color(87 / (float)255, 166 / (float)255, 74 / (float)255, 1f);
		private static GUIStyle EditableMessageStyle;

		private SerializedProperty messageProperty;

		protected void OnEnable()
		{
			messageProperty = serializedObject.FindProperty("message");
			EditableMessageStyle = null;
		}

		public override void OnInspectorGUI()
		{
			if (EditableMessageStyle == null)
			{
				EditableMessageStyle = new GUIStyle(EditorStyles.textArea);
				EditableMessageStyle.padding = new RectOffset(10, 10, 10, 10);
				EditableMessageStyle.fontSize = FontSize;
				EditableMessageStyle.fontStyle = Style;

				EditableMessageStyle.normal.textColor		= 
				EditableMessageStyle.hover.textColor		= 
				EditableMessageStyle.active.textColor		= 
				EditableMessageStyle.focused.textColor		= MessageColor;
			}

			serializedObject.UpdateIfRequiredOrScript();
			messageProperty.stringValue = EditorGUILayout.TextArea
			(
				messageProperty.stringValue,
				EditableMessageStyle
			);
			serializedObject.ApplyModifiedProperties();
		}
	}
}