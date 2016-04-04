' For complete examples and data files, please go to https://github.com/asposewords/Aspose_Words_NET
' The path to the documents directory.
Dim dataDir As String = RunExamples.GetDataDir_WorkingWithFields()
Dim fileName As String = "TestFile.doc"
Dim doc As New Document(dataDir & fileName)

' Pass the appropriate parameters to convert all IF fields encountered in the document (including headers and footers) to static text.
FieldsHelper.ConvertFieldsToStaticText(doc, FieldType.FieldIf)

dataDir = dataDir & RunExamples.GetOutputFilePath(fileName)
' Save the document with fields transformed to disk.
doc.Save(dataDir)