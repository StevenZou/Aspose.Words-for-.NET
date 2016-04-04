// For complete examples and data files, please go to https://github.com/asposewords/Aspose_Words_NET
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_WorkingWithTables();
Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

// Insert the table from HTML. Note that AutoFitSettings does not apply to tables
// inserted from HTML.
builder.InsertHtml("<table>" +
                   "<tr>" +
                   "<td>Row 1, Cell 1</td>" +
                   "<td>Row 1, Cell 2</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td>Row 2, Cell 2</td>" +
                   "<td>Row 2, Cell 2</td>" +
                   "</tr>" +
                   "</table>");

dataDir = dataDir + "DocumentBuilder.InsertTableFromHtml_out_.doc";
// Save the document to disk.
doc.Save(dataDir);