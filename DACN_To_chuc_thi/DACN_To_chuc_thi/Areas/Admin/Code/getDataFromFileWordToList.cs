
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  

namespace DACN_To_chuc_thi.Areas.Admin.Code
{
    public class getDataFromFileWordToList
    {
        public static List<string> ReadFileWord(string p)
        {
            List<string> list = new List<string>();
            Application word = new Application();
            object miss = System.Reflection.Missing.Value;
            object path = p;
            //object readOnly = true;
            object missing = System.Type.Missing;
            Document doc = word.Documents.Open(ref path,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss);
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                String str = "";
                str += str + doc.Paragraphs[i + 1].Range.Text.ToString();
                list.Add(str);
            }

            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
            ((_Document)doc).Close(ref saveChanges, ref miss, ref miss);
            doc = null;
            ((_Application)word).Quit();
            word = null;
            return list;
        }
    }
}