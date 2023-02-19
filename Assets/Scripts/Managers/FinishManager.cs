using UI;
using Character;
using UnityEngine;

namespace Managers
{
    public class FinishManager : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Player.Ins.movement.StopMovement();
                GameManager.Ins.winPanel.SetActive(true);
                ScoreBar.Ins.gameObject.SetActive(false);
            }
        }
    }
}

