using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VelmuruganRV
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public List<Obstacle> obsList;
        [SerializeField] bool gameWon;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            obsList.AddRange(GameObject.FindObjectsOfType<Obstacle>());
        }

        private void Update()
        {
            if (obsList.Count == 0 && !gameWon)
            {
                print("You won");
                gameWon = true;
                UIControl.instance.Won();
                Time.timeScale = 0f;
            }
        }

        public void RestartGame()
        {
            UIControl.instance.Lose();
            Time.timeScale = 0f;
        }

    }
}
