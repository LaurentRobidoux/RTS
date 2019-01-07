using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Variables;
using UnityEditor.AnimatedValues;
namespace RTS.Units
{
    [CustomEditor(typeof(UnitModel))]
    public class UnitModelEditor : Editor
    {
        public const string VARIABLE_FOLDER_NAME = "Variables";
       public void OnEnable()
        {
            myAnimBool = new AnimBool(showSettings);

            UnitModel model = target as UnitModel;
           
                string path = AssetDatabase.GetAssetPath(model);
                path = path.Replace(model.name + ".asset", "");
                path = path.Replace("Assets/Resources/", "");
                var list = Resources.LoadAll(path + VARIABLE_FOLDER_NAME, typeof(RtsVariable));
                Debug.Log(path + VARIABLE_FOLDER_NAME + "/");
                Debug.Log(list.Count());
                foreach (var item in list)
                {
                    model.Variables.Add(item as RtsVariable);
                }
                //     Resources.Load(path+)

            
        }
        bool showSettings;
        AnimBool myAnimBool;
        private bool showPosition=true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UnitModel model = target as UnitModel;

         
            showPosition = EditorGUILayout.Foldout(showPosition, "Technologies");
            if (showPosition)
            {
                foreach (int key in model.TechDicto.Dicto.Keys)
                {

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(key.ToString(), GUILayout.Width(100));
                    EditorGUILayout.BeginVertical();
                    foreach (var item in model.TechDicto.Dicto[key])
                    {
                        EditorGUILayout.LabelField(item.name);
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndFadeGroup();
            }
         
        }
        public void OnInspectorUpdate()
        {
            this.Repaint();
        }
    }
}
