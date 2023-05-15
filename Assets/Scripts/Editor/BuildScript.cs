using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    [MenuItem("Build/Build Server (Linux)")]
    static void BuildLinuxServer()
    {
        BuildTargetGroup targetGroup = BuildTargetGroup.Standalone;
        BuildTarget target = BuildTarget.StandaloneLinux64;

        // Switch the active build target
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/StarterAssets/ThirdPersonController/Scenes/Playground.unity" };
        buildPlayerOptions.locationPathName = "build/StandaloneLinux64/Server/Server.x86_64";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.subtarget = (int)StandaloneBuildSubtarget.Server;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;
        

        // Set Linux-specific build options based on editor settings
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
        PlayerSettings.SetArchitecture(BuildTargetGroup.Standalone, 0);
        PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64, true);

        // Add more Linux-specific settings as needed...

        Debug.Log("Building Server (Linux)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Debug.Log("Built Server (Linux).");
    }

    [MenuItem("Build/Build Client (WebGL)")]
    static void BuildWebGlClient()
    {
        BuildTargetGroup targetGroup = BuildTargetGroup.WebGL;
        BuildTarget target = BuildTarget.WebGL;

        // Switch the active build target
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/WebGL";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        // Set WebGL-specific build options based on editor settings
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
        PlayerSettings.WebGL.dataCaching = true;
        PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
        PlayerSettings.WebGL.memorySize = 16;

        // Add more WebGL-specific settings as needed...

        Debug.Log("Building Client (WebGL)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Debug.Log("Built Client (WebGL).");
    }

    [MenuItem("Build/Build Server and Client (Linux and WebGL)")]
    static void BuildLinuxAndWebGl() {
        BuildLinuxServer();
        BuildWebGlClient();
    }
}