using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Comments.Editor
{
    [CustomPropertyDrawer(typeof(CommentAttribute))]
    public class CommentTooltipDrawer : ModifierDrawer
    {
        private CommentAttribute CommentAttribute => attribute as CommentAttribute;
        private Guid CommentGuid => (Guid)CommentAttribute.TypeId;

        public override void ModifyPropertyGUI(VisualElement propertyContainer)
        {
            if (!TryGetLabel(out var label))
            {
                Debug.LogWarning("Comment drawer did not find a label inside property GUI.");
                return;
            }

            label.RegisterCallback<PointerEnterEvent>(enterEvt =>
            {
                var hoverRect = label.worldBound;
                CommentTooltipPopup.ShowFor(hoverRect, new GUIContent(CommentAttribute.Message));
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