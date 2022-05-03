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
			//���콺�� UI ���� ���ӿ�����Ʈ�� Ŭ������ �ÿ��� Ray üũ
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

	//���콺�� NPC�� �������� ���, ��ȭâ ����
	void OpenConversationIfNPC()
	{
		if (hitObject.collider.gameObject.tag == "NPC")
		{
			ConversationOpener.GetComponent<OpenConversationBox>().ActiveConversationBox();
		}
	}

}
