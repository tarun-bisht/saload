using System.IO;
using UnityEditor;
using UnityEngine;
public class Menu : EditorWindow
{
    [MenuItem("Window/Saload/View Saved Parameters")]
    public static void ShowMenu()
    {
        GetWindow<Menu>("Saload Menu");
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        EditorGUILayout.HelpBox("Track All Saved Parameters in project", MessageType.None, true);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.EndHorizontal();
        string[] param = GetSavedParameters();
        if (param.Length < 1)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("No Data Saved Yet", MessageType.Info, true);
            GUILayout.EndHorizontal();
        }
        else
        {
            for (int i = 0; i < param.Length; i++)
            {
                string msg = "Key "+i.ToString()+" => "+Path.GetFileName(param[i]).Split('.')[0]+" | Path => "+Path.GetFullPath(param[i]);
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(msg);
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.BeginHorizontal();
        EditorGUILayout.HelpBox("If Creating a Custom File to Save Custom Object use Extension \".saload\" to be able to Track it.",MessageType.Warning,true);
        GUILayout.EndHorizontal();
    }
    private string[] GetSavedParameters()
    {
        string path = Application.persistentDataPath;
        return Directory.GetFiles(path);
    }
}
