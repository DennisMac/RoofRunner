using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public Transform cameraTarget;
	public float cameraSpeed = 2.5f;
	public float minX;
	public float minY;
	public float maxX;
	public float maxY;

    GameObject[] backgroundElements;
    GameObject[] backgroundElements2;
    private Vector3 previousPosition;

    public float parallax = 10f;

    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        backgroundElements = GameObject.FindGameObjectsWithTag("background");
        backgroundElements2 = GameObject.FindGameObjectsWithTag("background2");
        previousPosition = transform.position;
    }

	void FixedUpdate(){
		if (cameraTarget != null) {
            var newPos = Vector2.Lerp(transform.position, cameraTarget.position, Time.deltaTime * cameraSpeed);
			var vect3 = new Vector3 (newPos.x, newPos.y, -10f);
			var clampX = Mathf.Clamp (vect3.x, minX, maxX);
			var clampY = Mathf.Clamp (vect3.y, minY, maxY);
			transform.position = new Vector3(clampX, clampY, -10f);


            // parallax 
            Vector3 movement = (transform.position - previousPosition) * 0.75f;
           
            for (int i = 0; i < backgroundElements.Length; i++)
            {
                backgroundElements[i].transform.position += movement;    
            }

            movement = (transform.position - previousPosition)*.5f;
            for (int i = 0; i < backgroundElements2.Length; i++)
            {
                backgroundElements2[i].transform.position += movement;
            }

            previousPosition = transform.position;
        }
	}
}
