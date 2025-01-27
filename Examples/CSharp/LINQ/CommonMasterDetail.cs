﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Words;
using Aspose.Words.Reporting;

namespace CSharp.LINQ
{
    class CommonMasterDetail
    {
        public static void Run()
        {
            //ExStart:CommonMasterDetail
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LINQ(); 
            string fileName = "CommonMasterDetail.doc";
            // Load the template document.
            Document doc = new Document(dataDir + fileName);
                        
            // Create a Reporting Engine.
            ReportingEngine engine = new ReportingEngine();
            
            // Execute the build report.
            engine.BuildReport(doc, Common.GetManagers(), "managers");

            dataDir = dataDir + RunExamples.GetOutputFilePath(fileName);

            // Save the finished document to disk.
            doc.Save(dataDir);
            //ExEnd:CommonMasterDetail
            Console.WriteLine("\nCommon master detail template document is populated with the data about managers and it's contracts.\nFile saved at " + dataDir);

        }
    }
}
