using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
	float moveSpd = 5.0f;
	float startSpd = 15.0f;
	float rotateSpd = 8.0f;
	float xRotate = 0f;
	float yRotate = 0f;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
			gameObject.transform.Translate(Vector3.forward * moveSpd * Time.deltaTime);
		if (Input.GetKey(KeyCode.S))
			gameObject.transform.Translate(Vector3.back * moveSpd * Time.deltaTime);
		if (Input.GetKey(KeyCode.A))
			gameObject.transform.Translate(Vector3.left * moveSpd * Time.deltaTime);
		if (Input.GetKey(KeyCode.D))
			gameObject.transform.Translate(Vector3.right * moveSpd * Time.deltaTime);


		if (Input.GetMouseButton(0))
		{
			float yRotateSize = Input.GetAxis("Mouse X") * rotateSpd;
			yRotate = transform.eulerAngles.y + yRotateSize;
		}


		if (Input.GetMouseButton(1))
		{
			float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpd;
			xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);     //상하 회전각을 -45~80까지 제한
		}

		transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
	}
}
