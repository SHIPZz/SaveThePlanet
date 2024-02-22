using CodeBase.UI.ButtonOpeners;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(ButtonOpenerBase), true)]
    public class ButtonOpenerBaseInspector : UnityEditor.UI.ButtonEditor
    {
        private SerializedProperty _windowServiceProperty;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }
    }
}