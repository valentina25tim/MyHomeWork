using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace MyHomeWork2._0.ReadFromFile._2
{
    public class ReadAllFromFile : ReadFromFile
    {
#region peremen

        public Dictionary<string, int> _wordDictionary = new Dictionary<string, int>();
        public Dictionary<string, int> _collocation2Dictionary = new Dictionary<string, int>();


        private string _fullTextFromFile;
        private string[] _allWordsArray;
        private int[] _countEachWord;
        private string[] _allCollocations2;
        private string _collocation2;
#endregion peremen
        public ReadAllFromFile(string LinkToFile = null) : base(LinkToFile)
        {
            _fullTextFromFile = ReadText;
        }

        public void DoAction(string LinkToFile)
        {
            FindWords();
            FindCollocations();
            AddToDictionaryWordAndCollocation(LinkToFile);
        }
        private void AddToDictionaryWordAndCollocation(string LinkToFile)
        {
            File.AppendAllText(@LinkToFile, "\t WORDS(uniq) \n", Encoding.UTF8);

            foreach (KeyValuePair<string, int> kv in _wordDictionary)
            {
                string addText = ($"{kv.Key}  -  {kv.Value}") + Environment.NewLine;

                File.AppendAllText(@LinkToFile, addText, Encoding.UTF8);
            }

            File.AppendAllText(@LinkToFile, "\t COLLOCATION(str + str) \n", Encoding.UTF8);

            foreach (KeyValuePair<string, int> kv in _collocation2Dictionary)
            {
                if (kv.Value > 1)
                {
                    string addText = ($"{kv.Key}  -  {kv.Value}") + Environment.NewLine;

                    File.AppendAllText(@LinkToFile, addText, Encoding.UTF8);
                }
            }
        }
        private void FindWords()
        {
            _fullTextFromFile = ReadText.ToLower();

            _allWordsArray = _fullTextFromFile.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?', '/', '\n', '\t', '"', '\r' },
                 StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in _allWordsArray)
            {
                if (_wordDictionary.TryGetValue(i, out int value))
                    _wordDictionary[i] += 1;

                else
                    _wordDictionary.Add(i, 1);
            }
        }
        private void FindCollocations()
        {
            // заполнение массива с колличеством эл-тов = всем словам в тексте и присваивание
            // каждому эл-ту количество повторов (с дикшинари)

            _countEachWord = new int[_allWordsArray.Length];

            for (var i = 0; i < _allWordsArray.Length; i++)
                for (var j = 0; j < _wordDictionary.Count; j++)
                {
                    var key = _wordDictionary.ElementAt(j).Key;
                    var value = _wordDictionary.ElementAt(j).Value;

                    if (_allWordsArray[i] == key)
                        _countEachWord[i] = value;
                }

            //заполнение массива всеми словосочетаниями без вычистки повторов &
            //& заполнение дикшинари уник фразами  (string1 + string2 = count) 

            _allCollocations2 = new string[_countEachWord.Length];

            for (var j = 0; j < _countEachWord.Length - 1; j++)
            {
                if (_countEachWord[j] > 1 && _countEachWord[j + 1] > 1)
                {
                    _collocation2 = $"{_allWordsArray[j]}  {_allWordsArray[j + 1]}";
                    _allCollocations2[j] = _collocation2;
                }
                string i = _allCollocations2[j];
                if (i != null)
                {
                    if (_collocation2Dictionary.TryGetValue(i, out int value))
                        _collocation2Dictionary[i] += 1;
                    else
                        _collocation2Dictionary.Add(i, 1);
                }
            }






            #region  Waiting
            //for (var j = 0; j < countWord.Length - 1; j++)
            //{
            //    if (countWord[j] > 1)
            //    {
            //        for (var y = j; y < countWord.Length; y++)
            //        {
            //            allCollocations[y] = j == y ? null : $" {allWordsArray[j..y]}";
            //        }

            //    }
            //    //string i = allCollocations[j];
            //    //if (i != null)
            //    //{
            //    //    if (_collocationDictionary.TryGetValue(i, out int value))
            //    //        _collocationDictionary[i] += 1;
            //    //    else
            //    //        _collocationDictionary.Add(i, 1);
            //    //}
            //}
            //for (var i = 0; i < allCollocations.Length; i++) Console.WriteLine(allCollocations[i]);
            #endregion  Waiting#region  Waiting

        }
    }
}


