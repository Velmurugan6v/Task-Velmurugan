using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelmuruganRV
{
    public class Select : MonoBehaviour
    {
        [SerializeField] GameObject ball;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (ball != null)
            {
                Vector2 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float roundX = Mathf.RoundToInt(cameraPos.x);
                float roundY = Mathf.RoundToInt(cameraPos.y);
                ball.transform.position = new Vector3(roundX, roundY, ball.transform.position.z);
            }

            RaycastHit2D? hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit != null && Input.GetMouseButtonDown(0))
            {
                ball = null;
                FindObjectOfType<BallMovement>()._point = null;
                UIControl.instance.ActivadeAllArrow();
            }
        }
    }
}
