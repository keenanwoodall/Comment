using UnityEngine.UIElements;

public static class VisualElementx
{
    public static VisualElement GetFirstAncestorWithClass(this VisualElement element, string className)
    {
        if (element == null)
            return null;
 
        if (element.ClassListContains(className))
            return element;
 
        return element.parent.GetFirstAncestorWithClass(className);
    }
}