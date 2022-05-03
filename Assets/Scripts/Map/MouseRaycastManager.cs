using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRaycastManager: MonoBehaviour
{
	public Camera camera;
	private RaycastHit hitObject;

	public GameObject ConversationOpener;

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//마우스가 UI 말고 게임오브젝트를 클릭했을 시에만 Ray 체크
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				MouseRayCheck();
			}
		}
	}

	void MouseRayCheck()
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hitObject))
		{
			if (hitObject.collider)
			{
				OpenConversationIfNPC();
			}
		}
	}

	//마우스가 NPC를 가리켰을 경우, 대화창 열기
	void OpenConversationIfNPC()
	{
		if (hitObject.collider.gameObject.tag == "NPC")
		{
			ConversationOpener.GetComponent<OpenConversationBox>().ActiveConversationBox();
		}
	}

}
