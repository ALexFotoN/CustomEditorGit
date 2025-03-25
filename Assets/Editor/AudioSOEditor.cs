using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(AudioSo))]
    public class AudioSoEditor : UnityEditor.Editor
    {
        private bool _showList = false;
        private bool _showText = false;

        public override void OnInspectorGUI()
        {
            var audioSo = (AudioSo)target;

            // Строка с уникальным ID
            EditorGUILayout.LabelField("Unique ID", audioSo.uniqueID);

            // Поле для выбора типа аудиоконтента
            audioSo.audioContentType = (AudioContentType)EditorGUILayout.EnumPopup("Audio Content Type", audioSo.audioContentType);

            // Кнопки для управления отображением
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Show List"))
            {
                _showList = true;
                _showText = false;
            }
            if (GUILayout.Button("Show Text"))
            {
                _showList = false;
                _showText = true;
            }
            if (GUILayout.Button("Hide All"))
            {
                _showList = false;
                _showText = false;
            }
            EditorGUILayout.EndHorizontal();

            // Отображение соответствующего листа
            if (_showList)
            {
                var list = audioSo.audioContentType switch
                {
                    AudioContentType.Dangerous => serializedObject.FindProperty("dangerousAudioList"),
                    AudioContentType.Friendly => serializedObject.FindProperty("friendlyAudioList"),
                    AudioContentType.Neutral => serializedObject.FindProperty("neutralAudioList"),
                    _ => null
                };
                if (list != null)
                {
                    EditorGUILayout.PropertyField(list, true);
                }
            }

            // Отображение текста
            if (_showText)
            {
                var text = serializedObject.FindProperty("panelText");
                EditorGUILayout.PropertyField(text, true);
            }

            serializedObject.ApplyModifiedProperties();
        }

    }
}