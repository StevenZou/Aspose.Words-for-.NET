' Copyright (c) 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Words. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////


Imports Microsoft.VisualBasic
Imports System
Imports Aspose.Words
Imports NUnit.Framework


Namespace ApiExamples.Bookmark
	<TestFixture> _
	Public Class ExBookmarks
		Inherits ApiExampleBase
		<Test> _
		Public Sub BookmarkNameAndText()
			'ExStart
			'ExFor:Bookmark
			'ExFor:Bookmark.Name
			'ExFor:Bookmark.Text
			'ExFor:Range.Bookmarks
			'ExId:BookmarksGetNameSetText
			'ExSummary:Shows how to get or set bookmark name and text.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmark.doc")

			' Use the indexer of the Bookmarks collection to obtain the desired bookmark.
			Dim bookmark As Aspose.Words.Bookmark = doc.Range.Bookmarks("MyBookmark")

			' Get the name and text of the bookmark.
			Dim name As String = bookmark.Name
			Dim text As String = bookmark.Text

			' Set the name and text of the bookmark.
			bookmark.Name = "RenamedBookmark"
			bookmark.Text = "This is a new bookmarked text."
			'ExEnd

			Assert.AreEqual("MyBookmark", name)
			Assert.AreEqual("This is a bookmarked text.", text)
		End Sub

		<Test> _
		Public Sub BookmarkRemove()
			'ExStart
			'ExFor:Bookmark.Remove
			'ExSummary:Shows how to remove a particular bookmark from a document.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmark.doc")

			' Use the indexer of the Bookmarks collection to obtain the desired bookmark.
			Dim bookmark As Aspose.Words.Bookmark = doc.Range.Bookmarks("MyBookmark")

			' Remove the bookmark. The bookmarked text is not deleted.
			bookmark.Remove()
			'ExEnd

			' Verify that the bookmarks were removed from the document.
			Assert.AreEqual(0, doc.Range.Bookmarks.Count)
		End Sub

		<Test> _
		Public Sub ClearBookmarks()
			'ExStart
			'ExFor:BookmarkCollection.Clear
			'ExSummary:Shows how to remove all bookmarks from a document.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmark.doc")
			doc.Range.Bookmarks.Clear()
			'ExEnd

			' Verify that the bookmarks were removed
			Assert.AreEqual(0, doc.Range.Bookmarks.Count)
		End Sub

		<Test> _
		Public Sub AccessBookmarks()
			'ExStart
			'ExFor:BookmarkCollection
			'ExFor:BookmarkCollection.Item(Int32)
			'ExFor:BookmarkCollection.Item(String)
			'ExId:BookmarksAccess
			'ExSummary:Shows how to obtain bookmarks from a bookmark collection.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmarks.doc")

			' By index.
			Dim bookmark1 As Aspose.Words.Bookmark = doc.Range.Bookmarks(0)

			' By name.
			Dim bookmark2 As Aspose.Words.Bookmark = doc.Range.Bookmarks("Bookmark2")
			'ExEnd
		End Sub

		<Test> _
		Public Sub BookmarkCollectionRemove()
			'ExStart
			'ExFor:BookmarkCollection.Remove(Bookmark)
			'ExFor:BookmarkCollection.Remove(String)
			'ExFor:BookmarkCollection.RemoveAt
			'ExSummary:Demonstrates different methods of removing bookmarks from a document.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmarks.doc")
			' Remove a particular bookmark from the document.
			Dim bookmark As Aspose.Words.Bookmark = doc.Range.Bookmarks(0)
			doc.Range.Bookmarks.Remove(bookmark)

			' Remove a bookmark by specified name.
			doc.Range.Bookmarks.Remove("Bookmark2")

			' Remove a bookmark at the specified index.
			doc.Range.Bookmarks.RemoveAt(0)
			'ExEnd

			Assert.AreEqual(0, doc.Range.Bookmarks.Count)
		End Sub

		<Test> _
		Public Sub BookmarksInsertBookmarkWithDocumentBuilder()
			'ExStart
			'ExId:BookmarksInsertBookmark
			'ExSummary:Shows how to create a new bookmark.
			Dim doc As New Aspose.Words.Document()
			Dim builder As New DocumentBuilder(doc)

			builder.StartBookmark("MyBookmark")
			builder.Writeln("Text inside a bookmark.")
			builder.EndBookmark("MyBookmark")
			'ExEnd
		End Sub

		<Test> _
		Public Sub GetBookmarkCount()
			'ExStart
			'ExFor:BookmarkCollection.Count
			'ExSummary:Shows how to count the number of bookmarks in a document.
			Dim doc As New Aspose.Words.Document(MyDir & "Bookmark.doc")

			Dim count As Integer = doc.Range.Bookmarks.Count
			'ExEnd

			Assert.AreEqual(1, count)
		End Sub

		<Test> _
		Public Sub CreateBookmarkWithNodes()
			'ExStart
			'ExFor:BookmarkStart
			'ExFor:BookmarkStart.#ctor
			'ExFor:BookmarkEnd
			'ExFor:BookmarkEnd.#ctor
			'ExSummary:Shows how to create a bookmark by inserting bookmark start and end nodes.
			Dim doc As New Aspose.Words.Document()

			' An empty document has just one empty paragraph by default.
			Dim p As Paragraph = doc.FirstSection.Body.FirstParagraph

			p.AppendChild(New Run(doc, "Text before bookmark. "))

			p.AppendChild(New BookmarkStart(doc, "My bookmark"))
			p.AppendChild(New Run(doc, "Text inside bookmark. "))
			p.AppendChild(New BookmarkEnd(doc, "My bookmark"))

			p.AppendChild(New Run(doc, "Text after bookmark."))

			doc.Save(MyDir & "Bookmarks.CreateBookmarkWithNodes.doc")

			Assert.AreEqual(doc.Range.Bookmarks("My bookmark").Text, "Text inside bookmark. ")
			'ExEnd
		End Sub
	End Class
End Namespace
