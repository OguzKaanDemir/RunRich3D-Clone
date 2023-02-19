using TMPro;
using Character;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UI
{
    public class ScoreBar : MonoBehaviour
    {
        private static ScoreBar _ins;
        public static ScoreBar Ins
        {
            get
            {
                if (_ins == null)
                    _ins = FindObjectOfType<ScoreBar>();

                return _ins;
            }
        }

        [SerializeField] private Image _inline;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private List<string> scoreBarTexts;
        [SerializeField] private List<Color> _inlineColors;
        private float _period;

        private void Start()
        {
            _period = 1f / scoreBarTexts.Count;
            print(_period);
            SetScoreBar();
        }

        public void SetScoreBar()
        {
            var amount = Player.Ins.Score() / 100f;
            _inline.fillAmount = amount;

            for (int i = 0; i < scoreBarTexts.Count; i++)
            {
                if (amount == 1)
                {
                    _text.text = scoreBarTexts[^1].ToUpper();
                    _inline.color = _inlineColors[^1];
                }
                else if (amount < (i + 1) * _period)
                {
                    _inline.color = _inlineColors[i];
                    _text.text = scoreBarTexts[i].ToUpper();
                    return;
                }
            }
        }
    }
}

