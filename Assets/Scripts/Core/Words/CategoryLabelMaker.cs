using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Words;
using Lean.Gui;
using TMPro;
using UnityEngine;

namespace Core.Words
{
    public class CategoryLabelMaker : MonoBehaviour
    {
        [SerializeField] public GameObject LabelPrefab;
        [SerializeField] public WordLoader Words;

        private int _dictionaryIndex = 0;

        private string[] _keys;

        private string _myKey;
        void Start()
        {
            _keys = Words.Dictionaries[_dictionaryIndex].Keys.ToArray();
            for (int i = 0; i < _keys.Length; i++)
            {
                var newLabel = Instantiate(LabelPrefab, transform);
                var text = newLabel.GetComponentInChildren<TextMeshProUGUI>();
                text.text = _keys[i];
                var btn = newLabel.GetComponent<LeanButton>();
                btn.OnClick.AddListener(() => OnClick(text));
            }
        }
        
        

        private void OnClick(TextMeshProUGUI text)
        {
            var randomWord = Words.Dictionaries[_dictionaryIndex][text.text][Random.Range(0, Words.Dictionaries[_dictionaryIndex][text.text].Count)];
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}