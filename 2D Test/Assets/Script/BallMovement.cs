using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VelmuruganRV
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float moveSpeed;
        public Transform _point;


        private void Awake()
        {
            _point.parent = null;
        }
        void Start()
        {
            //MoveRD();
        }

        
        void Update()
        {
            
        }

        private void FixedUpdate()
        {
            if (_point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _point.position, 20 * Time.deltaTime);

                if (Vector3.Distance(transform.position, _point.position) <= 0.10f)
                {
                    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                    {
                        _point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    }
                    if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                    {
                        _point.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    }
                }
            }
        }

        public void GritMove(Vector2 direction)
        {
            int rounX = Mathf.RoundToInt(direction.x);
            int rounY = Mathf.RoundToInt(direction.y);
            //return new Vector2(rounX, rounY);

        }

        public void Move(Vector2 direction)
        {
            //direction = direction.normalized;
            float roundX = Mathf.Floor(direction.x);
            float roundY = Mathf.Floor(direction.y);
            rb.velocity = new Vector2(roundX, roundY) * moveSpeed;
        }

        public void MoveRU()
        {
            Move(new Vector2(1,1));
            UIControl.instance.DisableAllDirArow();
        }

        public void MoveRD()
        {
            Move(new Vector2(1, -1));
            UIControl.instance.DisableAllDirArow();
        }

        public void MoveLU()
        {
            Move(new Vector2(-1, 1));
            UIControl.instance.DisableAllDirArow();
        }

        public void MoveLD()
        {
            Move(new Vector2(-1, -1));
            UIControl.instance.DisableAllDirArow();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Obstacle")
            {
                var _obstacle = collision.transform.GetComponent<Obstacle>();
                _obstacle.Hitcount++;
                _obstacle.hitCount.text = "" + _obstacle.Hitcount;

                if (!_obstacle.Removed)
                {
                    GameManager.instance.obsList.Remove(_obstacle);
                    _obstacle.Removed = true;
                }
            }
        }
    }
}
