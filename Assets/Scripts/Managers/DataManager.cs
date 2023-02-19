using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "New Data Manager", menuName = "Data Manager")]
    public class DataManager : ScriptableObject
    {
        private const string LevelKey = "pLevel";
        public int Level
        {
            get
            {
                if (!PlayerPrefs.HasKey(LevelKey))
                    PlayerPrefs.SetInt(LevelKey, 0);

                return PlayerPrefs.GetInt(LevelKey);
            }
            set => PlayerPrefs.SetInt(LevelKey, value);
        }
    }
}

