using System;
using UnityEngine;

namespace Microsoft.Toolkit.ThreeD.Editor
{
    /// <summary>
    /// Build task that copies the <see cref="WebRTCServer"/> config files to the output directory if they exist
    /// </summary>
    public class LibraryCopyBuildTask : MonoBehaviour
    {
        /// <summary>
        /// Unity editor post build hook
        /// </summary>
        [UnityEditor.Callbacks.PostProcessBuild]
        static void OnPostprocessBuild(
            UnityEditor.BuildTarget target,
            string pathToBuiltProject)
        {
            string sourcePath = "/fewrf";// Application.dataPath + "/UnityPackages/3DToolkit/";
            string destPath = pathToBuiltProject.Substring(
                0, pathToBuiltProject.LastIndexOf("/") + 1);

            try
            {
                UnityEditor.FileUtil.CopyFileOrDirectory(
                    sourcePath + "nvpipe.dll",
                    destPath + "nvpipe.dll");

                UnityEditor.FileUtil.CopyFileOrDirectory(
                    sourcePath + "cudart64_91.dll",
                    destPath + "cudart64_91.dll");

                UnityEditor.FileUtil.CopyFileOrDirectory(
                    sourcePath + "nvToolsExt64_1.dll",
                    destPath + "nvToolsExt64_1.dll");
            }
            catch (Exception ex)
            {
                // Note to developers: If you don't want this behavior for your project, simply delete this script
                Debug.LogWarning("[BuildTask] Unable to copy 3DToolkit files: " + ex.Message);
            }
        }
    }
}