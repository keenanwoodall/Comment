using System.Runtime.CompilerServices;
using UnityEngine;

public class CommentAttribute : PropertyAttribute
{
    public readonly string SourceFilePath;
    
    public CommentAttribute([CallerFilePath] string callerFilePath = null)
    {
        SourceFilePath = callerFilePath;
    }
}