' For complete examples and data files, please go to https://github.com/asposewords/Aspose_Words_NET
Dim doc As New Document()
Dim builder As New DocumentBuilder(doc)

' Insert a table row made up of three cells which have different preferred widths.
Dim table As Table = builder.StartTable()

' Insert an absolute sized cell.
builder.InsertCell()
builder.CellFormat.PreferredWidth = PreferredWidth.FromPoints(40)
builder.CellFormat.Shading.BackgroundPatternColor = Color.LightYellow
builder.Writeln("Cell at 40 points width")

' Insert a relative (percent) sized cell.
builder.InsertCell()
builder.CellFormat.PreferredWidth = PreferredWidth.FromPercent(20)
builder.CellFormat.Shading.BackgroundPatternColor = Color.LightBlue
builder.Writeln("Cell at 20% width")

' Insert a auto sized cell.
builder.InsertCell()
builder.CellFormat.PreferredWidth = PreferredWidth.Auto
builder.CellFormat.Shading.BackgroundPatternColor = Color.LightGreen
builder.Writeln("Cell automatically sized. The size of this cell is calculated from the table preferred width.")
builder.Writeln("In this case the cell will fill up the rest of the available space.")

dataDir = dataDir & Convert.ToString("Table.CellPreferredWidths_out_.doc")
' Save the document to disk.
doc.Save(dataDir)