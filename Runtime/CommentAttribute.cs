using System;
using UnityEngine;

public class CommentAttribute : PropertyAttribute
{
    public string Message;
    private Guid _guid;

    public CommentAttribute(string message)
    {
        Message = message;
        _guid = Guid.NewGuid();
    }

    public override object TypeId => _guid;
}