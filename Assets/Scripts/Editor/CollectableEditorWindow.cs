using LevelDesign;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class CollectableEditorWindow : EditorWindow
{
    private List<Collectable> _collectables;
    private CollectableType _type;
    private int _value;
    private bool _changeType;
    private bool _changeValue;

    [MenuItem("Editor/Collectable Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CollectableEditorWindow));
    }

    private void OnGUI()
    {
        _collectables = new List<Collectable>();

        foreach (GameObject go in Selection.gameObjects)
        {
            Collectable collectable = go.GetComponent<Collectable>();
            if (collectable != null)
                _collectables.Add(collectable);
        }

        if (_collectables.Count > 0)
        {
            GUILayout.Label("Selected Collectables:");

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            foreach (var collectable in _collectables)
                GUILayout.Label("- " + collectable.name);

            EditorGUILayout.EndVertical();

            _changeType = EditorGUILayout.Toggle("Change Type", _changeType);
            _changeValue = EditorGUILayout.Toggle("Change Value", _changeValue);

            if (_changeType)
                _type = (CollectableType)EditorGUILayout.EnumPopup("Select Type", _type);

            if (_changeValue)
                _value = EditorGUILayout.IntSlider("Action Value", _value, 0, 100);

            if (GUILayout.Button("Set Collectables"))
            {
                foreach (var collectable in _collectables)
                {
                    if (_changeValue)
                        collectable.actionValue = _value;

                    if (_changeType)
                        collectable.myType = _type;

                    collectable.SetCollectable();
                }
            }
        }
        else
            GUILayout.Label("No Collectables selected.");
    }
}


