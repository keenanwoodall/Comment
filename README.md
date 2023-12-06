# Comment
Add comments to the inspector via a Comment component, and a Comment tooltip attribute.

### Component
Add the Comment component to write comments in the inspector.

![image](https://github.com/keenanwoodall/Comment/assets/9631530/20e3af5c-22b0-49cb-b3f4-865597218b12)

### Attribute
Instead of using `[Tooltip]` on a field, you can use `[Comment]` to automatically display the comment above a field as its tooltip

![Unity_4khkk3yXne](https://github.com/keenanwoodall/Comment/assets/9631530/5103e898-3043-493f-a1aa-e885507b2ab2)

```cs
public class SimpleExampleScript : MonoBehaviour
{
    // This is a tooltip for a single line comment
    [Comment] public float fieldWithComment;
    
    /// <summary>
    /// This is a summary description of the field.
    /// </summary>
    /// <remarks>
    /// It is used to demonstrate how the [Comment] attribute handles documentation comments.
    /// </remarks>
    [Comment] public float fieldWithXMLComment;
}
```

### Attribute Limitations
- Comment discovery is greedy(?) The `[Comment]` attribute will always display the first comment block above the field in question, even if there's other fields in between.

```cs
// This is a comment
[Comment] public float field1;
[Comment] public float field2;

// ^ both fields will have the same tooltip
```
