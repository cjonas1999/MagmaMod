using UnityEngine;
using DebugMod.Hitbox;
using System;
using UnityEngine.Analytics;

namespace MagmaMod
{
    public class Circle : MonoBehaviour
    {
        private float LineWidth => Math.Max(0.7f, Screen.width / 960f * GameCameras.instance.tk2dCam.ZoomFactor);
        GameObject centerObject;

        public void Awake()
        {
            GameObject dog_bug = UnityEngine.GameObject.Find("Crystallised Lazer Bug (5)");
            if (dog_bug != null)
            {
                float X = dog_bug.transform.GetPositionX();
                float Y = dog_bug.transform.GetPositionY();

                Modding.Logger.Log($"Initial buggy X:{X} Y:{Y}");

                centerObject = dog_bug;
            }
        }

        public void OnGUI()
        {
            Camera camera = Camera.main;
            GUI.depth = 1;
            int radius = 28;

            Vector2 obj_center = centerObject.transform.position;
            Vector2 screen_point = camera.WorldToScreenPoint(obj_center);
            Vector2 center_point = new Vector2((int)Math.Round(screen_point.x), (int)Math.Round(Screen.height - screen_point.y));


            Vector2 right_screen_point = camera.WorldToScreenPoint(obj_center + new Vector2(radius, 0));
            Vector2 right_point = new Vector2((int)Math.Round(right_screen_point.x), (int)Math.Round(Screen.height - right_screen_point.y));

            int radius_screen = (int)Math.Round(Vector2.Distance(center_point, right_point));
           /*
            Modding.Logger.Log($"buggy X:{obj_center.x} Y:{obj_center.y}");
            Modding.Logger.Log($"end center X:{center_point.x} Y:{center_point.y}");
            Modding.Logger.Log($"end radius {radius_screen}");
           */

            Drawing.DrawCircle(center_point, radius_screen, Color.cyan, LineWidth, true, 32);
        }

    }
}
