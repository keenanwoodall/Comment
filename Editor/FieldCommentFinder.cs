using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Antlr4.Runtime;

namespace Comments.Editor
{
    public class FieldCommentFinder : CSharpParserBaseListener
    {
        private readonly string _fieldName;
        private readonly BufferedTokenStream _tokenStream;

        private bool _foundLastCommentToken;
        public bool CommentFound { get; private set; }
        public string PlainComment { get; private set; }
        public XmlDocument XmlComment { get; private set; }

        public FieldCommentFinder(string fieldName, BufferedTokenStream tokenStream)
        {
            _fieldName = fieldName;
            _tokenStream = tokenStream;
            PlainComment = "";
            XmlComment = new XmlDocument();
        }

        private string CleanComment(string comment)
        {
            string[] lines = comment.Split(new[] { '\n', '\r' }, System.StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i]; ;
                line = line.TrimStart('\n', '\r', ' ', '*', '/');
                lines[i] = line;
            }
            
            return string.Join(System.Environment.NewLine, lines).Trim();
        }
        
        public override void ExitCompilation_unit(CSharpParser.Compilation_unitContext context)
        {
            PlainComment = CleanComment(PlainComment);

            if (PlainComment.StartsWith('<') && PlainComment.EndsWith('>'))
            {
                try
                {
                    XmlComment.LoadXml("<root>" + PlainComment + "</root>");
                }
                catch (XmlException)
                {
                }
                
                if (XmlComment.HasChildNodes)
                    PlainComment = null;
            }
        }

        public override void EnterField_declaration(CSharpParser.Field_declarationContext context)
        {
            if (_foundLastCommentToken)
                return;
            
            var text = context.GetText().TrimEnd(';');
            if (text.Contains(_fieldName))
            {
                // Assuming that the field declaration context's start token is the start of the field
                var fieldStartToken = context.Start;

                // Get tokens preceding the start of the field
                var precedingTokens = _tokenStream.GetTokens(0, fieldStartToken.TokenIndex);
                if (precedingTokens == null) 
                    return;
                
                foreach (var token in precedingTokens.Reverse())
                {
                    // Check if token is a comment
                    if (token.Type is 
                        CSharpLexer.SINGLE_LINE_COMMENT or
                        CSharpLexer.DELIMITED_DOC_COMMENT or 
                        CSharpLexer.DELIMITED_COMMENT or 
                        CSharpLexer.SINGLE_LINE_DOC_COMMENT or 
                        CSharpLexer.EMPTY_DELIMITED_DOC_COMMENT
                       )
                    {
                        PlainComment = PlainComment.Insert(0, token.Text + "\n");
                        CommentFound = true;
                    }
                    else if (token.Type is not CSharpLexer.WHITESPACES && CommentFound)
                    {
                        _foundLastCommentToken = true;
                        break;
                    }
                }
            }
        }
    }
}