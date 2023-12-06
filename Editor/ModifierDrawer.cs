using Comments.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// An un-quarantined decorator drawer. Provides access to the relevant SerializedObject/Property, and the entire visual tree for modification 
/// </summary>
public abstract class ModifierDrawer : DecoratorDrawer
{
    protected PropertyField PropertyField { get; private set; }
    protected VisualElement InspectorElement { get; private set; }
    protected SerializedObject SerializedObject { get; private set; }
    protected SerializedProperty SerializedProperty { get; private set; }
    
    public bool TryGetLabel(out Label label)
    {
        label = PropertyField.Q<Label>(className: "unity-label");
        return label != null;
    }
    
    public override VisualElement CreatePropertyGUI()
    {
        var visualElement = new VisualElement();
        visualElement.RegisterCallback<AttachToPanelEvent>(evt =>
        {
            EditorApplication.delayCall += () =>
            {
                var decoratorContainer = visualElement.parent;
                PropertyField = decoratorContainer.GetFirstAncestorOfType<PropertyField>();
                InspectorElement = decoratorContainer.GetFirstAncestorWithClass("unity-inspector-element");//PropertyField.parent.parent;

                var soFieldInfo = Reflectionx.Field(InspectorElement.GetType(), "m_BoundObject");
                if (soFieldInfo != null)
                {
                    SerializedObject = (SerializedObject)soFieldInfo.GetValue(InspectorElement);
                    SerializedProperty = SerializedObject.FindProperty(PropertyField.bindingPath);
                }

                // We're just using the visual element to find the correct property visual element in the tree.
                // It can be safely removed now
                PropertyField.Remove(decoratorContainer);

                ModifyPropertyGUI(PropertyField);
            };
        });

        return visualElement;
    }

    public abstract void ModifyPropertyGUI(VisualElement propertyContainer);
}