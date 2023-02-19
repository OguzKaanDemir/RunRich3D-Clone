using TMPro;
using Managers;
using Character;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinPanel : MonoBehaviour
    {
        private static WinPanel _ins;
        public static WinPanel Ins
        {
            get
            {
                if (_ins == null)
                    _ins = FindObjectOfType<WinPanel>();

                return _ins;
            }
        }

        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private TMP_Text _scoreText;

        private void Start()
        {
            _scoreText.text = $"SCORE: {Player.Ins.Score()}";
            _nextLevelButton.onClick.AddListener(NextLevel);
        }

        private void NextLevel()
        {
            GameManager.Ins.dataManager.Level += 1;
            GameManager.Ins.levelManager.OpenLevel(GameManager.Ins.dataManager.Level);
        }
    }
}
