//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CSharpPreprocessorParser.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CSharpPreprocessorParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ICSharpPreprocessorParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorDeclaration</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorDeclaration([NotNull] CSharpPreprocessorParser.PreprocessorDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorDeclaration</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorDeclaration([NotNull] CSharpPreprocessorParser.PreprocessorDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorConditional</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorConditional([NotNull] CSharpPreprocessorParser.PreprocessorConditionalContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorConditional</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorConditional([NotNull] CSharpPreprocessorParser.PreprocessorConditionalContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorLine</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorLine([NotNull] CSharpPreprocessorParser.PreprocessorLineContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorLine</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorLine([NotNull] CSharpPreprocessorParser.PreprocessorLineContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorDiagnostic</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorDiagnostic([NotNull] CSharpPreprocessorParser.PreprocessorDiagnosticContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorDiagnostic</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorDiagnostic([NotNull] CSharpPreprocessorParser.PreprocessorDiagnosticContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorRegion</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorRegion([NotNull] CSharpPreprocessorParser.PreprocessorRegionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorRegion</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorRegion([NotNull] CSharpPreprocessorParser.PreprocessorRegionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorPragma</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorPragma([NotNull] CSharpPreprocessorParser.PreprocessorPragmaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorPragma</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorPragma([NotNull] CSharpPreprocessorParser.PreprocessorPragmaContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>preprocessorNullable</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessorNullable([NotNull] CSharpPreprocessorParser.PreprocessorNullableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>preprocessorNullable</c>
	/// labeled alternative in <see cref="CSharpPreprocessorParser.preprocessor_directive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessorNullable([NotNull] CSharpPreprocessorParser.PreprocessorNullableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CSharpPreprocessorParser.directive_new_line_or_sharp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirective_new_line_or_sharp([NotNull] CSharpPreprocessorParser.Directive_new_line_or_sharpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CSharpPreprocessorParser.directive_new_line_or_sharp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirective_new_line_or_sharp([NotNull] CSharpPreprocessorParser.Directive_new_line_or_sharpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CSharpPreprocessorParser.preprocessor_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreprocessor_expression([NotNull] CSharpPreprocessorParser.Preprocessor_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CSharpPreprocessorParser.preprocessor_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreprocessor_expression([NotNull] CSharpPreprocessorParser.Preprocessor_expressionContext context);
}
