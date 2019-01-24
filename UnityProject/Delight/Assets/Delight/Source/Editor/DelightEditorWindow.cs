﻿#region Using Statements
using Delight.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Editor window displaying the control panel for the framework.
    /// </summary>
    public class DelightEditorWindow : UnityEditor.EditorWindow
    {
        #region Methods

        /// <summary>
        /// Displays the window.
        /// </summary>
        [MenuItem("Window/Delight")]
        public static void ShowWindow()
        {
            GetWindow(typeof(DelightEditorWindow), false, "Delight");
        }

        /// <summary>
        /// Called when GUI is to be rendered.
        /// </summary>
        public void OnGUI()
        {
            // parse all XUML
            GUIContent parseXumlContent = new GUIContent("Parse all XUML files", "Parses all XUML files and generates code.");
            if (GUILayout.Button(parseXumlContent))
            {
                // wait for any uncompiled scripts to be compiled first
                AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

                // parse all XUML assets
                XumlParser.ParseAllXumlFiles();

                // refresh generated scripts
                AssetDatabase.Refresh();
            }
        }

        #endregion
    }
}
