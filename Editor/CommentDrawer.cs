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
                MonoScript script = null;
                Object target = SerializedObject.targetObject;

                if (target is MonoBehaviour mb)
                    script = MonoScript.FromMonoBehaviour(mb);
                else if (target is ScriptableObject so)
                    script = MonoScript.FromScriptableObject(so);

                var hoverRect = label.worldBound;
                
                if (SerializedProperty.TryGetNicifiedComment(script, out var comment))
                {
                    CommentTooltipPopup.ShowFor(hoverRect, new GUIContent(comment));
                }
                else
                {
                    CommentTooltipPopup.ShowFor(hoverRect, new GUIContent("Tooltip Missing: No comment found above this field"));
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