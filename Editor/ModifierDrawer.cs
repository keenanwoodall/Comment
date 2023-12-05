using UnityEditor;
using UnityEngine.UIElements;

public abstract class ModifierDrawer : DecoratorDrawer
{
    protected VisualElement PropertyContainer { get; private set; }
    
    public bool TryGetLabel(out Label label)
    {
        label = PropertyContainer.Q<Label>(className: "unity-base-field__label");
        return label != null;
    }
    
    public override VisualElement CreatePropertyGUI()
    {
        var visualElement = new VisualElement();
        
        visualElement.RegisterCallback<AttachToPanelEvent>(evt =>
        {
            var decoratorContainer = visualElement.parent;
            PropertyContainer = decoratorContainer.parent;
            
            // We're just using the visual element to find the correct property visual element in the tree.
            // It can be safely removed now
            PropertyContainer.Remove(decoratorContainer);
            
            ModifyPropertyGUI(PropertyContainer);
        });
        
        // visualElement.RegisterCallback<DetachFromPanelEvent>(evt =>
        // {
        //     
        // });

        return visualElement;
    }

    public abstract void ModifyPropertyGUI(VisualElement propertyContainer);
}