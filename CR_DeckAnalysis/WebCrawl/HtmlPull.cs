using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebCrawl
{

    public static class HtmlPull
    {
        public static List<string> htmlTest()
        {
            List<string> retList = new List<string>();
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("http://clashroyale.wikia.com/wiki/Spear_Goblins");
            }


            string summaryString = getStringBetweenKeys("Summary</span></h2>", ">History</span></h2>", ref htmlCode);

            string statsString = getStringBetweenKeys("Statistics</span></h2>", "unit-statistics-table", ref htmlCode);
            string fullstatsString = getStringBetweenKeys("<td>1</td><td>", "<td>13</td><td>", ref htmlCode, -19, 50);

            retList.Add(summaryString);
            retList.Add(statsString);
            retList.Add(fullstatsString);

            var xy = getStatisticsFromString(ref fullstatsString);
            var yz = extractFunFacts(summaryString);

            return retList;


        }

        #region FunFacts

        public static List<string> extractFunFacts(string source)
        {
            string St = source;
            var retList = new List<string>();

            string keyA = "<li>";
            string keyB = "</li>";

            int pFrom = St.IndexOf(keyA) + keyA.Length;
            int pTo = St.IndexOf(keyB);

            string levelString;
            int initLevelStringLength;

            levelString = St.Substring(pFrom, pTo - pFrom);
            initLevelStringLength = levelString.Length ;

            while (pFrom > -1 && pTo > -1)
            {
                string xyz = RemoveAllBetweenChars(levelString);
                retList.Add(xyz);

                if (St.Length > initLevelStringLength)
                {
                    St = St.Substring(initLevelStringLength);

                    pFrom = St.IndexOf(keyA) + keyA.Length;
                    pTo = St.IndexOf(keyB);

                    if(pTo < pFrom) //error prevent
                    {
                        int tmpFrom = pFrom - keyA.Length;
                        St = St.Substring(tmpFrom, St.Length - pFrom);
                        pFrom = St.IndexOf(keyA) + keyA.Length;
                        pTo = St.IndexOf(keyB);
                    }
                    if (pTo > -1 && pFrom > -1) {
                        levelString = St.Substring(pFrom, pTo - pFrom);
                        initLevelStringLength = levelString.Length;
                    }
                }
                else
                {
                    pTo = -4;
                }
            }

            return retList;
        }

        private static string RemoveAllBetweenChars(string source)
        {
            string s = source;

            //string input = "Give [Me Some] Purple (And More) Elephants";
        //    string regex = "(\\<.*\\>)|(\".*\")|('.*')|(\\(.*\\))";
          /*  string regex = "(\\<.*\\>)";
            string output = Regex.Replace(s, regex, "");
            */
        
            s = RemoveBetween(s, '<', '>');

            return s;
        }


        private static string RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty);
        }

  

        /*  public static string removeBetweenTwoChars(char a, char b, string source)
          {
              string s = source;
              int indexA = findFirstLocationOfCharInString('<', source);
              int indexB = findFirstLocationOfCharInString('>', source, indexA + 1);

              while(indexA > -1 && indexB > -1)
              {


                  indexA = findFirstLocationOfCharInString('<', source);
                 indexB = findFirstLocationOfCharInString('>', source, indexA + 1);
              }

          } */

        public static int findFirstLocationOfCharInString(char find, string source, int startIndex = 0)
        {
            int retInt = -1;
            for (int i = startIndex; i < source.Length; i++)
            {
                if (source[i] == find)
                {
                    retInt = i;
                    break;
                }
            }
            return retInt;
        }
        #endregion




        #region Stats Table
        //level, hitpoints, damage, dps
        public static List<Tuple<int, int, int, int>> getStatisticsFromString(ref string StR)
        {
            string St = StR;

            var retList = new List<Tuple<int, int, int, int>>();
            for (int levelInc = 0; levelInc < 13; levelInc++)
            {
                int level = levelInc + 1;
                int hp = -1;
                int damage = -1;
                int dps = -1;

                string keyA = "<tr>";
                string keyB = "</tr>";

                int pFrom = St.IndexOf(keyA) + keyA.Length;
                int pTo = St.IndexOf(keyB);

                string levelString; int initLevelStringLength;
                if (levelInc < 12)
                {
                    levelString = St.Substring(pFrom, pTo - pFrom);
                    initLevelStringLength = levelString.Length;
                }
                else
                {
                    levelString = St;
                    initLevelStringLength = levelString.Length;
                }

                //now find the stats
                keyA = "<td>";
                keyB = "</td>";

                pFrom = levelString.IndexOf(keyA) + keyA.Length;
                pTo = levelString.IndexOf(keyB);

                levelString = levelString.Substring(pTo + keyB.Length); //we already know the level, so back out

                for (int i = 0; i < 3; i++)
                {
                    pFrom = levelString.IndexOf(keyA) + keyA.Length;
                    pTo = levelString.IndexOf(keyB);

                    string targetString = levelString.Substring(pFrom, pTo - pFrom);

                    targetString.Replace("<td>", "");
                    targetString.Replace("</td>", "");

                    if (i == 0)
                        hp = Int32.Parse(targetString);
                    else if (i == 1)
                        damage = Int32.Parse(targetString);
                    else
                        dps = Int32.Parse(targetString);

                    levelString = levelString.Substring(pTo + keyB.Length);

                }


                //cut the string
                if (levelInc < 12)
                {
                    St = St.Substring(initLevelStringLength + 10);
                }

                var newTup = new Tuple<int, int, int, int>(level, hp, damage, dps);
                retList.Add(newTup);
            }
            return retList;
        }

        public static string getStringBetweenKeys(string keyA, string keyB, ref string St, int offsetA = 0, int offsetB = 0)
        {

            int pFrom = St.IndexOf(keyA) + keyA.Length + offsetA;
            int pTo = St.LastIndexOf(keyB) + offsetB;

            return St.Substring(pFrom, pTo - pFrom);
        }

        public static string getLastStringBetweenKeys(string keyA, string keyB, ref string St)
        {

            int pFrom = St.LastIndexOf(keyA) + keyA.Length;
            int pTo = St.LastIndexOf(keyB);

            return St.Substring(pFrom, pTo - pFrom);
        }
        #endregion


    }
}
