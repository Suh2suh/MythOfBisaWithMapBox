using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBtnGenerator : MonoBehaviour
{
	public GameObject QuestBtn;
	public void ActiveQuestBtn()
	{
		if(QuestBtn.activeSelf == false)
		{
			QuestBtn.SetActive(true);
		}
	}

	public void UnactiveQuestBtn()
	{
		if (QuestBtn.activeSelf == true)
		{
			QuestBtn.SetActive(false);
		}
	}
}