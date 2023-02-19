using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _ins;
        public static GameManager Ins
        {
            get
            {
                if (_ins == null)
                    _ins = FindObjectOfType<GameManager>();

                return _ins;
            }
        }

        public GameObject winPanel;
        public LevelManager levelManager;
        public DataManager dataManager;


        void Start()
        {
            dataManager = (DataManager)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/DataManager.asset", typeof(DataManager));
            levelManager = (LevelManager)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/LevelManager.asset", typeof(LevelManager));
        }
    }
}

