using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VelmuruganRV
{
    public class Obstacle : MonoBehaviour
    {
        public int Hitcount { get; set; }
        public bool Removed { get; set; }
        public Text hitCount;

        private void Update()
        {
            if (Hitcount >= 3)
            {
                GameManager.instance.RestartGame();
            }
        }
    }
}
