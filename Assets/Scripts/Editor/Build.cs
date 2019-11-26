using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Build
{
    [MenuItem("MyMenu/Do Something")]
    private static void PerformBuild()
    {
        //a comment
        string[] scenes = { "Assets/Scenes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes, "Build/app.exe", BuildTarget.StandaloneWindows64, BuildOptions.Development);
    }
}