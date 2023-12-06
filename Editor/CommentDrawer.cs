using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

namespace Comments.Editor
{
    [CustomPropertyDrawer(typeof(CommentAttribute))]
    public class CommentDrawer : ModifierDrawer
    {
        public override void ModifyPropertyGUI(VisualElement propertyContainer)
        {
            if (!TryGetLabel(out var label))
            {
                Debug.LogError("Comment attribute drawer could not find label");
                return;
            }
            
            label.RegisterCallback<PointerEnterEvent>(enterEvt =>
            {
                Object target = SerializedObject.targetObject;

                var commentAttribute = (CommentAttribute)attribute;
                var source = File.ReadAllText(commentAttribute.SourceFilePath);

                var hoverRect = label.worldBound;
                
                if (SerializedProperty.TryGetNicifiedComment(source, out var comment))
                {
                    CommentTooltipPopup.ShowFor(hoverRect, new GUIContent(comment));
                }
                else
                {
                    CommentTooltipPopup.ShowFor(hoverRect, new GUIContent($"Tooltip Missing: No comment found for this field in {target.GetType().FullName}"));
                }
            });

            label.RegisterCallback<PointerLeaveEvent>(leaveEvt =>
            {
                CommentTooltipPopup.Hide();
            });
            
            label.RegisterCallback<PointerDownEvent>(leaveEvt =>
            {
                CommentTooltipPopup.Hide();
            });
        }
    }
}