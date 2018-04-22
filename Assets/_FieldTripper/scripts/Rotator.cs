using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class Rotator : MonoBehaviour
    {
        private float angle = 0;
        private float velocity = 40.0f;

        // Use this for initialization
        void Start()
        {
            Debug.Log("Hey there. I have been updated yet again!");
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == UnityEngine.TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) == true)
                    {
                        velocity *= -1;
                    }
                }
            }

            transform.localEulerAngles = new Vector3(angle / 2.0f, angle, 0);
            angle += velocity * Time.deltaTime;
        }
    }
}