using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnactiver : MonoBehaviour
{
	public GameObject Buttons;

	private void OnEnable()
	{
		if(Buttons.activeSelf == true)
			Buttons.SetActive(false);
	}
	private void OnDisable()
	{
		if(Buttons.activeSelf == false)
			Buttons.SetActive(true);
	}
}
