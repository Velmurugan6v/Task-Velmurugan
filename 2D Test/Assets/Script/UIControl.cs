using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VelmuruganRV
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField] Text gameResoult;
        public GameObject[] directionArrow;

        public static UIControl instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            gameResoult.gameObject.SetActive(false);
        }

        public void Won()
        {
            gameResoult.gameObject.SetActive(true);
            gameResoult.text = "Won";
        }

        public void Lose()
        {
            gameResoult.gameObject.SetActive(true);
            gameResoult.text = "Lose";
        }

        public void DisableAllDirArow()
        {
            foreach (GameObject arrow in directionArrow)
            {
                arrow.SetActive(false);
            }
        }

        public void ActivadeAllArrow()
        {
            foreach (GameObject arrow in directionArrow)
            {
                arrow.SetActive(true);
            }
        }
    }
}
