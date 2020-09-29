using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Core.Words
{
    public class WordLoader : MonoBehaviour
    {
        [SerializeField] public List<TextAsset> Assets;

        public List<Dictionary<string, List<string>>> Dictionaries;
        private void Awake()
        {
            
            Dictionaries = new List<Dictionary<string, List<string>>>();
            for (int i = 0; i < Assets.Count; i++)
            {
                Dictionaries.Add(GenerateDictionaryFromAsset(Assets[i]));
            }

            var dict = Dictionaries[0];

            

            

        }
        private Dictionary<string, List<string>> GenerateDictionaryFromAsset(TextAsset csv)
        {
            Dictionary<string,List<string>> dictionary = new Dictionary<string, List<string>>();
            
            var splitByLine = csv.text.Split('\n');
            var categories = splitByLine[0].Split(',');
            
            // first line is the categories
            for (int i = 0; i < categories.Length; i++)
            {
               dictionary[categories[i]] = new List<string>(); 
            }

            for (int i = 1; i < splitByLine.Length; i++)
            {
                var line = splitByLine[i].Split(',');
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x].Length > 1)
                    {
                       dictionary[categories[x]].Add(line[x]);
                    } 
                }
            }

            return dictionary;
        }
    }
    
    
}
