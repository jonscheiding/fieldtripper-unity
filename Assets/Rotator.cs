using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    private float angle = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("Hey there.");
	}
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(0, angle, 0);
        angle += 10 * Time.deltaTime;
	}
}
