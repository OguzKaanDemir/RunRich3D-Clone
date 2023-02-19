using UI;
using TMPro;
using Character;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace LevelDesign
{
    public class Gate : MonoBehaviour
    {
        [OnValueChanged("SetGate")] public ActionType actionType;

        [OnValueChanged("SetGate")] public bool isSolo;
        [HideIf("isSolo")] public Gate nextDoor;

        [Space] [OnValueChanged("SetGate")] [Range(0, 100)] public int actionValue;
        [OnValueChanged("SetGate")] public string gateText;
        [OnValueChanged("SetGate")] public Sprite gateImage;
        [OnValueChanged("SetGate")] [Range(0, 1)] public float opacity;

        public bool canCollide = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!isSolo) nextDoor.canCollide = false;
                CollisionAction(actionType == ActionType.Negative ? -actionValue : actionValue);
            }
        }

        public void CollisionAction(int val)
        {
            if (!isSolo && !nextDoor.canCollide && canCollide || isSolo && canCollide)
            {
                canCollide = false;
                Player.Ins.SetScore(val);
                ScoreBar.Ins.SetScoreBar();
            }
        }

        public void SetGate()
        {
            SetGateColor();
            SetGateText();
            SetGateImage();
        }

        private void SetGateColor()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.color = GetColor();
        }

        private void SetGateText()
        {
            var text = GetComponentInChildren<TMP_Text>();
            text.text = gateText.ToUpper();
        }

        private void SetGateImage()
        {
            var renderer = GetComponentsInChildren<SpriteRenderer>().Where(x => x.transform.childCount == 0).ToList();
            renderer[0].sprite = gateImage;
        }

        private Color GetColor()
        {
            var color = actionType == ActionType.Negative ? Color.red : Color.green;
            color.a = opacity;

            return color;
        }

    }
}

