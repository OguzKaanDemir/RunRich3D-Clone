using UI;
using Character;
using UnityEngine;
using Sirenix.OdinInspector;

namespace LevelDesign
{
    public class Collectable : MonoBehaviour
    {
        [OnValueChanged("SetCollectable")] public CollectableType myType;

        [SerializeField] private GameObject _money;
        [SerializeField] private GameObject _wineBottle;
        [SerializeField] private GameObject _friedPotatoes;
        [SerializeField] private BoxCollider _collider;

        public ActionType actionType => myType is CollectableType.Money ? ActionType.Positive : ActionType.Negative;
        [Range(0, 100)] public int actionValue;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                CollisionAction(actionType == ActionType.Negative ? -actionValue : actionValue);
        }

        public void CollisionAction(int val)
        {
            Player.Ins.SetScore(val);
            ScoreBar.Ins.SetScoreBar();
            Destroy(gameObject);
        }

        public void SetCollectable()
        {
            if (transform.childCount == 1)
                DestroyImmediate(transform.GetChild(0).gameObject);

            switch (myType)
            {
                case CollectableType.Money:
                    var money = Instantiate(_money, transform);
                    money.transform.localPosition = Vector3.zero;
                    break;
                case CollectableType.WineBottle:
                    var bottle = Instantiate(_wineBottle, transform);
                    bottle.transform.localPosition = Vector3.up / 2;
                    break;
                case CollectableType.FriedPotatoes:
                    var potatoes = Instantiate(_friedPotatoes, transform);
                    potatoes.transform.localPosition = Vector3.up / 2;
                    break;
            }
            SetCollider();
        }

        private void SetCollider()
        {
            switch (myType)
            {
                case CollectableType.Money:
                    _collider.center = new Vector3(0, .14f, 0);
                    _collider.size = new Vector3(.45f, .25f, 1);
                    break;
                case CollectableType.WineBottle:
                    _collider.center = new Vector3(0, .6f, 0);
                    _collider.size = new Vector3(.5f, 1f, .6f);
                    break;
                case CollectableType.FriedPotatoes:
                    _collider.center = new Vector3(0, .45f, 0);
                    _collider.size = new Vector3(.5f, .85f, .25f);
                    break;
            }
        }
    }
}

