using UnityEngine;

namespace RedPanda
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        [SerializeField] private SpawnSoldierArea[] _spawnSoldierArea = new SpawnSoldierArea[2];
        [SerializeField] private bool _isWin = false;

        public static GameManager Instance { get => instance; private set => instance = value; }
        public bool IsWin { get => _isWin; private set => _isWin = value; }

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
        public void CheckWinCondition()
        {
            int count = 0;

            for (int i = 0; i < _spawnSoldierArea.Length; i++)
            {
                if (_spawnSoldierArea[i].SoldierCount >= 3)
                {
                    count++;
                }
            }

            if (count >= _spawnSoldierArea.Length)
            {
                IsWin = true;
                UiManager.Instance.ActivateWinScene();
            }
        }
    }
}