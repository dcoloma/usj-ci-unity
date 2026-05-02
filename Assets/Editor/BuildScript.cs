using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildScript
{
    public static void Build()
    {
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;

        string[] scenes = FindScenesInAssets();

        if (scenes.Length == 0)
            throw new System.Exception("No .unity scene files found under Assets/");

        Debug.Log($"Building scenes: {string.Join(", ", scenes)}");

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes           = scenes,
            locationPathName = "build/WebGL/WebGL",
            target           = BuildTarget.WebGL,
            options          = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);

        if (report.summary.result == BuildResult.Succeeded)
            Debug.Log($"Build succeeded: {report.summary.totalSize / 1024 / 1024} MB");
        else
            throw new System.Exception($"Build failed: {report.summary.result}");
    }

    private static string[] FindScenesInAssets()
    {
        string[] guids = AssetDatabase.FindAssets("t:Scene", new[] { "Assets" });
        string[] paths = new string[guids.Length];
        for (int i = 0; i < guids.Length; i++)
            paths[i] = AssetDatabase.GUIDToAssetPath(guids[i]);
        return paths;
    }
}
