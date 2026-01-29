using HutongGames.PlayMaker.Actions;
using Modding;
using UnityEngine;
using System;
using System.IO;

namespace MagmaMod {
    public class MagmaMod : Mod {
        public GameObject gameObject { get; private set; }
        public Circle c { get; private set; }
        public ConfigManager manager { get; set; }


        public override void Initialize() {
            gameObject = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);

            manager = gameObject.AddComponent<ConfigManager>();

            ModHooks.Instance.SceneChanged += CreateCircle;
        }


        private void CreateCircle(string scene_name) {
            if (this.manager.is_enabled && scene_name == "Mines_05") {
                c = gameObject.AddComponent<Circle>();
            }
            else {
                UnityEngine.Object.Destroy(c);
            }
        }

        public override string GetVersion() => "1.1";
    }
}
