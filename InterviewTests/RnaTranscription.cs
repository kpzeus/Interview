using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTests
{
    internal class RnaTranscription
    {
        internal static string ToRna(string v)
        {
            if (v == null || v.Length == 0)
                return v;

            StringBuilder sb = new StringBuilder();

            foreach (var item in v)
            {
                switch (item)
                {
                    case 'G':
                        sb.Append('C');
                        break;

                    case 'C':
                        sb.Append('G');
                        break;

                    case 'T':
                        sb.Append('A');
                        break;

                    case 'A':
                        sb.Append('U');
                        break;
                }
            }

            return sb.ToString();
        }
    }
}