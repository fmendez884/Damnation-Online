using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

public class LogBuildSettings : MonoBehaviour
{
    [MenuItem("Build/Log Build Settings")]
    public static void LogSettings()
    {
        string logFilePath = "Builds/LogSettings.log";
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath);
        }

        Logger.OpenLog(logFilePath);

        LogSettingsForPlatform(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        LogSettingsForPlatform(BuildTargetGroup.Standalone, BuildTarget.StandaloneLinux64);

        Logger.CloseLog();
    }

    private static void LogSettingsForPlatform(BuildTargetGroup targetGroup, BuildTarget target)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);

        Logger.Log("Build target: " + EditorUserBuildSettings.activeBuildTarget);
        Logger.Log("Build target group: " + targetGroup.ToString());
        Logger.Log("Scenes: " + string.Join(", ", EditorBuildSettings.scenes.Select(s => s.path).ToArray()));
        Logger.Log("Build output path: " + EditorUserBuildSettings.GetBuildLocation(target));

        if (target == BuildTarget.WebGL)
        {
            // WebGL-specific settings
            Logger.Log("WebGL compression format: " + PlayerSettings.WebGL.compressionFormat.ToString());
            Logger.Log("WebGL data caching: " + PlayerSettings.WebGL.dataCaching.ToString());
            Logger.Log("WebGL linker target: " + PlayerSettings.WebGL.linkerTarget.ToString());
            Logger.Log("WebGL memory size: " + PlayerSettings.WebGL.memorySize.ToString());
            // Add more WebGL-specific settings as needed...
        }
        else if (target == BuildTarget.StandaloneLinux64)
        {
            // Linux-specific settings
            Logger.Log("Linux build type: " + PlayerSettings.GetScriptingBackend(targetGroup).ToString());
            Logger.Log("Linux build architecture: " + PlayerSettings.GetArchitecture(targetGroup).ToString());
            Logger.Log("Linux build target: " + targetGroup.ToString());
            Logger.Log("Linux enable headless mode: " + PlayerSettings.GetUseDefaultGraphicsAPIs(target).ToString());
            // Add more Linux-specific settings as needed...
        }

        Logger.Log("");  // Empty line to separate settings for different platforms
    }
}
