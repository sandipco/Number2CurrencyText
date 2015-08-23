using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConvertNumber.Models
{
    public class NumberToText
    {
        private string[] noInText = {" zero"," one"," two"," three"," four"," five"," six"," seven"," eight"," nine"," ten",
                             " eleven"," twelve"," thirteen"," fourteen"," fifteen"," sixteen"," seventeen"," eighteen"," nineteen"," twenty",
                             " twenty-one"," twenty-two"," twenty-three"," twenty-four"," twenty-five"," twenty-six"," twenty-seven",
                             " twenty-eight"," twenty-nine"," thirty"," thirty-one"," thirty-two"," thirty-three"," thirty-four",
                             " thirty-five"," thirty-six"," thirty-seven"," thirty-eight"," thirty-nine"," forty"," forty-one",
                             " forty-two"," forty-three"," forty-four"," forty-five"," forty-six"," forty-seven"," forty-eight",
                             " forty-nine"," fifty"," fifty-one"," fifty-two"," fifty-three"," fifty-four"," fifty-five"," fifty-six",
                             " fifty-seven"," fifty-eight"," fifty-nine"," sixty"," sixty-one"," sixty-two"," sixty-three"," sixty-four",
                             " sixty-five"," sixty-six"," sixty-seven"," sixty-eight"," sixty-nine"," seventy"," seventy-one"," seventy-two",
                             " seventy-three"," seventy-four"," seventy-five"," seventy-six"," seventy-seven"," seventy-eight"," seventy-nine",
                             " eighty"," eighty-one"," eighty-two"," eighty-three"," eighty-four"," eighty-five"," eighty-six"," eighty-seven",
                             " eighty-eight"," eighty-nine"," ninety"," ninety-one"," ninety-two"," ninety-three"," ninety-four"," ninety-five",
                             "ninety-six"," ninety-seven"," ninety-eight"," ninety-nine"
                            };
        public double noToConvert { get; set; }
        public string getConvertedValue()
        {
            string amount = noToConvert.ToString();
            string[] v=amount.Split('.');
            string cents="";
            string dollars = "";
            if(v.Length==2)
            {
                if (v[1].Length == 1)
                    v[1] = v[1] + "0";
                 cents = " AND " + noInText[Convert.ToInt32(v[1])] + " CENTS ";
            }
            if(v[0].CompareTo("0")!=0)
            { 
                dollars = convertToWords(v[0]) + " DOLLARS ";
            }
            
            string convertedVal = dollars + cents;
            return convertedVal.ToUpper();
        }
        private string convertToWords(string no)
        {
            char[] individualNo = no.ToCharArray();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int j = 0;
            j = Convert.ToInt32(no);
            if (j < 100)
                return noInText[j];
            j = individualNo.Length;
            for (int i = 0; i < individualNo.Length; i++)
            {
                int _no = Convert.ToInt32(individualNo[i].ToString());
                j = j - 1;
                switch (j)
                {
                    case 0:
                        dict.Add("UNIT", _no);
                        break;
                    case 1:
                        dict.Add("TEN", _no);
                        break;
                    case 2:
                        dict.Add("HUNDRED", _no);
                        break;
                    case 3:
                        dict.Add("THOUSAND", _no);
                        break;
                    case 4:
                        //dict.Add("TEN THOUSAND", _no);
                        dict.Add("THOUSAND TEN", _no * 10);
                        break;
                    case 5:
                        dict.Add("THOUSAND HUNDRED", _no * 100);
                        //dict.Add("HUNDRED THOUSAND", _no);
                        break;
                    case 6:
                        dict.Add("MILLION", _no);
                        break;
                    case 7:
                        dict.Add("MILLION TEN", _no * 10);
                        //dict.Add("TEN MILLION", _no);
                        break;
                    case 8:
                        dict.Add("MILLION HUNDRED", _no * 100);
                        //dict.Add("HUNDRED MILLION", _no );
                        break;


                }
            }
            string prevKey = "";
            string final = "";
            string curKey = "";
            int prevVal = 0, curVal = 0;
            Stack<string> stck = new Stack<string>();
            bool isNewValue = true;
            foreach (KeyValuePair<string, int> k in dict)
            {

                curKey = k.Key.ToString();
                string[] s = k.Key.Split(' ');
                string st = s[0];
                curVal = Convert.ToInt32(k.Value);
                if (curKey.Contains(prevKey) && prevKey.Length > 0)
                {
                    isNewValue = false;
                    curVal = prevVal + curVal;
                    prevVal = curVal;
                }
                else
                {
                    isNewValue = true;
                    prevVal = Convert.ToInt32(k.Value);
                }
                prevKey = st;
                if (isNewValue)
                    stck.Push(curVal.ToString() + " " + st);
                else
                {
                    if (stck.Count > 0)
                        stck.Pop();
                    stck.Push(curVal.ToString() + " " + st);
                }
                final = final + " " + curVal.ToString() + " " + st;


            }

            List<string> lst = stck.Reverse().ToList();
            final = "";
            int cnt = lst.Count;
            foreach (string ss in lst)
            {
                //Console.WriteLine(ss);
                string[] strNo = ss.Split(' ');
                string temp = strNo[0];
                cnt--;
                if (temp.CompareTo("0") != 0)
                {
                    if (prevVal != 0 && cnt == 0)
                    {
                        prevVal = prevVal + Convert.ToInt32(strNo[0]);
                        strNo[0] = prevVal.ToString();
                        prevVal = 0;
                    }
                    if (strNo[1].Contains("TEN") && cnt != 1)
                    {
                        j = Convert.ToInt32(strNo[0]) * 10;
                        final = final + translateDigits(j.ToString());
                        prevVal = 0;
                    }
                    else if (strNo[1].Contains("TEN"))
                        prevVal = Convert.ToInt32(strNo[0]) * 10;
                    else
                    {
                        final = final + translateDigits(strNo[0]) + strNo[1];
                        prevVal = 0;
                    }

                }
                else if (prevVal != 0)
                {
                    final = final + translateDigits(prevVal.ToString());
                    prevVal = 0;
                }



            }
            final = final.Replace("UNIT", "");
            return final;
        }

        private string translateDigits(string noToConvert)
        {
            string[] nos = noToConvert.Split(' ');
            char[] c = nos[0].ToCharArray();
            int j = c.Length - 1;
            string ret = "";
            string temp = "";
            int indx = 0;
            switch (c.Length)
            {
                case 1:
                    indx = Convert.ToInt32(c[0].ToString());
                    ret = noInText[indx];
                    break;
                case 2:
                    temp = c[0].ToString();
                    j = Convert.ToInt32(temp) * 10;
                    j = j + Convert.ToInt32(c[1].ToString());
                    ret = noInText[j];
                    break;
                case 3:
                    j = Convert.ToInt32(c[0].ToString());
                    ret = noInText[j] + " HUNDRED ";
                    j = Convert.ToInt32(c[1].ToString()) * 10 + Convert.ToInt32(c[2].ToString());
                    if (j != 0)
                        ret = ret + noInText[j];

                    break;

            }
            return ret.ToUpper() + " ";
        }
    }
}