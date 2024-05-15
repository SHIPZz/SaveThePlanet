using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ClearDataEditor : UnityEditor.Editor
    {
        [MenuItem("Tools/Clear Data")]
        public static void ClearData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("DATA CLEARED SUCCESSFULLY");
        }

        [MenuItem("Tools/SetTutorialCompleted")]
        public static void SetTutorialCompleted()
        {
            EditorPrefs.SetBool("TUTORIAL", true);
        }
        
        [MenuItem("Tools/SetTutorialCompletedFalse")]
        public static void SetTutorialNotCompleted()
        {
            EditorPrefs.SetBool("TUTORIAL", false);
        }
    }
}