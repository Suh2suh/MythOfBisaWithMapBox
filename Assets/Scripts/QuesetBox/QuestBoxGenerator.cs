using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoxGenerator : MonoBehaviour
{
    public GameObject QuestBox;

    public void OpenQuestBox()
    {
        QuestBox.SetActive(true);
    }
}
