using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda
{
    public class UiManager : MonoBehaviour
    {
        private static UiManager instance;
        public static UiManager Instance { get => instance; private set => instance = value; }
        public GameObject Panel { get => _panel; private set => _panel = value; }

        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _panelWin;
        [SerializeField] private Text _textWood;
        [SerializeField] private Text _textGold;
        [SerializeField] private Text _textStone;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            SetTexts(ResourceType.Wood, 0.ToString());
            SetTexts(ResourceType.Gold, 0.ToString());
            SetTexts(ResourceType.Stone, 0.ToString());
        }
        public void SetTexts(ResourceType type, string text)
        {
            switch (type)
            {
                case ResourceType.Wood:
                    _textWood.text = "Wood: " + text;
                    break;
                case ResourceType.Gold:
                    _textGold.text = "Gold: " + text;
                    break;
                case ResourceType.Stone:
                    _textStone.text = "Stone: " + text;
                    break;
            }
        }
        public void ActivateWinScene()
        {
            if (_panel.activeSelf)
            {
                _panel.SetActive(false);
            }

            _panelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}