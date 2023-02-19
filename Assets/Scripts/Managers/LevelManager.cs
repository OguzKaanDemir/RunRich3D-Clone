using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Managers
{
    [CreateAssetMenu(fileName ="New Level Data", menuName = "Level Data")]
    public class LevelManager : ScriptableObject
    {
        public List<SceneAsset> levels = new List<SceneAsset>();
        public void OpenLevel(int level)
        {
            var count = levels.Count;
            var t = level % count;
            SceneManager.LoadScene(levels[t].name);
        }
    }
}

