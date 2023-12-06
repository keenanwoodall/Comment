using System;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using UnityEditor;
using UnityEngine;

namespace Comments.Editor
{
    public static class SerializedPropertyx
    {
        public static bool HasComment(this SerializedProperty property, MonoScript script, out string comment)
        {
            comment = null;
            
            var inputStream = new AntlrInputStream(script.text);
            var lexer = new CSharpLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new CSharpParser(tokenStream);
            var tree = parser.compilation_unit();
            var commentFinder = new FieldCommentFinder(property.name, tokenStream);
            ParseTreeWalker.Default.Walk(commentFinder, tree);

            if (commentFinder.CommentFound)
            {
                if (!string.IsNullOrEmpty(commentFinder.PlainComment))
                {
                    comment = commentFinder.PlainComment;
                }
                else
                {
                    var nicifiedComment = "";

                    foreach (XmlNode node in commentFinder.XmlComment.DocumentElement.ChildNodes)
                    {
                        Traverse(node, (currentNode, depth) =>
                        {
                            var indent = "  ";
                            var indentLevel = string.Concat(Enumerable.Repeat(indent, depth));
                            if (currentNode.HasChildNodes)
                            {
                                var nicifiedName = ObjectNames.NicifyVariableName(currentNode.Name);
                                var indentedName = $"{indentLevel}<b>{nicifiedName.Replace("\n", $"\n{indentLevel}{indent}")}</b>\n";
                                nicifiedComment += indentedName;
                            }
                            else
                            {
                                nicifiedComment +=
                                    $"{indentLevel}{indent}{currentNode.InnerText.Trim().Replace("\n", $"\n{indentLevel}{indent}")}\n";
                            }
                        });   
                    }
                    
                    comment = nicifiedComment.Trim();
                }
            }
            
            return commentFinder.CommentFound;
        }

        private static void Traverse(XmlNode node, Action<XmlNode, int> visit, int depth = 0)
        {
            visit(node, depth);
            foreach (XmlNode childNode in node.ChildNodes)
            {
                Traverse(childNode, visit, depth + 1);
            }
        }
    }
}