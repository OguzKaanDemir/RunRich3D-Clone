using LevelDesign;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GateEditorWindow : EditorWindow
    {
        private Gate[] _gates;
        private Vector2 _scrollPos;

        [MenuItem("Editor/Gate Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GateEditorWindow));
        }

        private void OnEnable()
        {
            _gates = FindObjectsOfType<Gate>();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Gates", EditorStyles.boldLabel);

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            foreach (var gate in _gates)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.LabelField(gate.name, EditorStyles.boldLabel);
                EditorGUI.indentLevel++;

                var transform = EditorGUILayout.ObjectField("Gate Transform", gate.transform, typeof(Transform), true);
                gate.actionType = (ActionType)EditorGUILayout.EnumPopup("Action Type", gate.actionType);
                gate.isSolo = EditorGUILayout.Toggle("Is Solo", gate.isSolo);
                if (!gate.isSolo)
                    gate.nextDoor = (Gate)EditorGUILayout.ObjectField("Next Door", gate.nextDoor, typeof(Gate), true);
                gate.actionValue = EditorGUILayout.IntSlider("Action Value", gate.actionValue, 0, 100);
                gate.gateText = EditorGUILayout.TextField("Gate Text", gate.gateText);
                gate.gateImage = (Sprite)EditorGUILayout.ObjectField("Gate Image", gate.gateImage, typeof(Sprite), true);
                gate.opacity = EditorGUILayout.Slider("Opacity", gate.opacity, 0, 1);

                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();

                if (GUI.changed)
                    gate.SetGate();
            }

            EditorGUILayout.EndScrollView();
        }
    }
}

