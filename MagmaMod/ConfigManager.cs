using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System;
using UnityEngine.Analytics;
using HutongGames.PlayMaker.Actions;
using Modding;
using UnityEngine;
using System;
using System.IO;

namespace MagmaMod {
    public class ConfigManager: MonoBehaviour {

        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/KeyCode.html
        public KeyCode toggle_key = KeyCode.None;
        public bool is_enabled = false;

        public static string config_path;

        public ConfigManager() {
            config_path = Application.persistentDataPath + "/MagmaMod/";
            Directory.CreateDirectory(config_path);

            string config_file = config_path + "/config.txt";
            
            if (File.Exists(config_file)) {
                using (TextReader reader = File.OpenText(config_file)) {
                    toggle_key = (KeyCode)Enum.Parse(typeof(KeyCode), reader.ReadLine());
                }
            }
            else {
                toggle_key = KeyCode.F9;
                File.WriteAllText(config_file, toggle_key.ToString());
            }

            Modding.Logger.Log($"MagmaMod toggle key set to : {toggle_key}");
        }

        public void Update() {
            if (Input.GetKeyDown(toggle_key)) {
                is_enabled = !is_enabled;
                Modding.Logger.Log($"MagmaMod toggled: {is_enabled}");
            }
        }
    }
}
