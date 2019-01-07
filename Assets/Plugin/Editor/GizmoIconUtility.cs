using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.Callbacks;
using Variables;
public class GizmoIconUtility
{
   // [DidReloadScripts]
    static GizmoIconUtility()
    {
        EditorApplication.projectWindowItemOnGUI = ItemOnGUI;
    }

    static void ItemOnGUI(string guid, Rect rect)
    {
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);

        FloatVariable obj = AssetDatabase.LoadAssetAtPath(assetPath, typeof(FloatVariable)) as FloatVariable;
        
        if (obj != null)
        {
            //rect.width = rect.height;
            rect.height -= 10;
          
                GUI.DrawTexture(rect, (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/FloatVariable Icon.png", typeof(Texture2D)));
            
          
        }
    }
}