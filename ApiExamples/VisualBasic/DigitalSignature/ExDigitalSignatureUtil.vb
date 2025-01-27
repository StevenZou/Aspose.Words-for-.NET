' Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Words. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////


Imports Microsoft.VisualBasic
Imports System
Imports Aspose.Words
Imports NUnit.Framework


Namespace ApiExamples.DigitalSignature
	<TestFixture> _
	Public Class ExDigitalSignatureUtil
		Inherits ApiExampleBase
		<Test> _
		Public Sub RemoveAllSignaturesEx()
			'ExStart
			'ExFor:DigitalSignatureUtil.RemoveAllSignatures(Stream, Stream)
			'ExFor:DigitalSignatureUtil.RemoveAllSignatures(String, String)
			'ExSummary:Shows how to remove every signature from a document.
			'By stream:
			Dim docStreamIn As System.IO.Stream = New System.IO.FileStream(MyDir & "Document.Signed.doc", System.IO.FileMode.Open)
			Dim docStreamOut As System.IO.Stream = New System.IO.FileStream(MyDir & "Document.NoSignatures.FromStream.doc", System.IO.FileMode.Create)

			DigitalSignatureUtil.RemoveAllSignatures(docStreamIn, docStreamOut)

			docStreamIn.Close()
			docStreamOut.Close()

			'By string:
			Dim doc As New Aspose.Words.Document(MyDir & "Document.Signed.doc")
			Dim outFileName As String = MyDir & "Document.NoSignatures.FromString.doc"

			DigitalSignatureUtil.RemoveAllSignatures(doc.OriginalFileName, outFileName)
			'ExEnd
		End Sub

		<Test> _
		Public Sub LoadSignaturesEx()
			'ExStart
			'ExFor:DigitalSignatureUtil.LoadSignatures(Stream)
			'ExFor:DigitalSignatureUtil.LoadSignatures(String)
			'ExSummary:Shows how to load signatures from a document by stream and by string.
			Dim docStream As System.IO.Stream = New System.IO.FileStream(MyDir & "Document.Signed.doc", System.IO.FileMode.Open)

			' By stream:
			Dim digitalSignatures As DigitalSignatureCollection = DigitalSignatureUtil.LoadSignatures(docStream)
			docStream.Close()

			' By string:
			digitalSignatures = DigitalSignatureUtil.LoadSignatures(MyDir & "Document.Signed.doc")
			'ExEnd
		End Sub

		' We don't include a sample certificate with the examples
		' so this exception is expected instead since the file is not there.
		<Test, ExpectedException(GetType(System.IO.FileNotFoundException))> _
		Public Sub SignEx()
			'ExStart
			'ExFor:DigitalSignatureUtil.Sign(String, String, CertificateHolder, String, DateTime)
			'ExFor:DigitalSignatureUtil.Sign(Stream, Stream, CertificateHolder, String, DateTime)
			'ExSummary:Shows how to sign documents.
			Dim ch As CertificateHolder = CertificateHolder.Create(MyDir & "MyPkcs12.pfx", "My password")

			'By String
			Dim doc As New Aspose.Words.Document(MyDir & "Document.doc")
			Dim outputDocFileName As String = MyDir & "Document.Signed.doc"

			DigitalSignatureUtil.Sign(doc.OriginalFileName, outputDocFileName, ch, "My comment", DateTime.Now)

			'By Stream
			Dim docInStream As System.IO.Stream = New System.IO.FileStream(MyDir & "Document.doc", System.IO.FileMode.Open)
			Dim docOutStream As System.IO.Stream = New System.IO.FileStream(MyDir & "Document.Signed.doc", System.IO.FileMode.OpenOrCreate)

			DigitalSignatureUtil.Sign(docInStream, docOutStream, ch, "My comment", DateTime.Now)
			'ExEnd
		End Sub
	End Class
End Namespace