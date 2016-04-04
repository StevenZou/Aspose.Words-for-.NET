// For complete examples and data files, please go to https://github.com/asposewords/Aspose_Words_NET
Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

Table table = builder.StartTable();
builder.InsertCell();

// Set the row formatting
RowFormat rowFormat = builder.RowFormat;
rowFormat.Height = 100;
rowFormat.HeightRule = HeightRule.Exactly;
// These formatting properties are set on the table and are applied to all rows in the table.
table.LeftPadding = 30;
table.RightPadding = 30;
table.TopPadding = 30;
table.BottomPadding = 30;

builder.Writeln("I'm a wonderful formatted row.");

builder.EndRow();
builder.EndTable();

dataDir = dataDir + "Table.ApplyRowFormatting_out_.doc";

// Save the document to disk.
doc.Save(dataDir);