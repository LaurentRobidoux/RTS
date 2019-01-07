using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace RTS.Tech
{
    [CustomEditor(typeof(Technology),true)]
    public class TechEditor : Editor
    {
        int playerIndex;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            playerIndex = EditorGUILayout.IntField("Player Index :",playerIndex);
            if ( GUILayout.Button("Do Tech"))
            {
                Technology tech = target as Technology;
                tech.ApplyTech(playerIndex);
            }
        }
    }
}
