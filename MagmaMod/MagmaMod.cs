using HutongGames.PlayMaker.Actions;
using Modding;
using UnityEngine;

namespace MagmaMod
{
    public class MagmaMod : Mod
    {
        public GameObject gameObject { get; private set; }
        public Circle c { get; private set; }

        public override void Initialize()
        {
            ModHooks.Instance.SceneChanged += CreateCircle;
        }

        private void CreateCircle(string scene_name)
        {

            if (scene_name == "Mines_05")
            {
                Modding.Logger.Log("In the mines");

                gameObject = new GameObject();
                c = gameObject.AddComponent<Circle>();
            }
            else
            {
                Object.Destroy(c);
                Object.Destroy(gameObject);
            }

        }

        public override string GetVersion() => "1.0";
    }
}
