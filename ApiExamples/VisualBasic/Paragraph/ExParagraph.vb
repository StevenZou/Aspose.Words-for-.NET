Imports Microsoft.VisualBasic
Imports System
Imports Aspose.Words
Imports Aspose.Words.Fields
Imports NUnit.Framework


Namespace ApiExamples
	<TestFixture> _
	Friend Class ExParagraph
		Inherits ApiExampleBase
		<Test> _
		Public Sub InsertField()
			'ExStart
			'ExFor:Paragraph.InsertField
			'ExSummary:Shows how to insert field using several methods: "field code", "field code and field value", "field code and field value after a run of text"
			Dim doc As New Aspose.Words.Document()

			'Get the first paragraph of the document
			Dim para As Paragraph = doc.FirstSection.Body.FirstParagraph

			'Inseting field using field code
			'Note: All methods support inserting field after some node. Just set "true" in the "isAfter" parameter
			para.InsertField(" AUTHOR ", Nothing, False)

			'Using field type
			'Note:
			'1. For inserting field using field type, you can choose, update field before or after you open the document ("updateField" parameter)
			'2. For other methods it's works automatically
			para.InsertField(FieldType.FieldAuthor, False, Nothing, True)

			'Using field code and field value
			para.InsertField(" AUTHOR ", "Test Field Value", Nothing, False)

			'Add a run of text
			Dim run As New Run(doc) With {.Text = " Hello World!"}
			para.AppendChild(run)

			'Using field code and field value before a run of text
			'Note: For inserting field before/after a run of text you can use all methods above, just add ref on your text ("refNode" parameter)
			para.InsertField(" AUTHOR ", "Test Field Value", run, False)
			'ExEnd
		End Sub
	End Class
End Namespace
