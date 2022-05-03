using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenConversationBox : MonoBehaviour
{
    public GameObject ConversationBox;
    List<Dictionary<string, object>> kor_Dialog;

    private void Awake()
    {
        kor_Dialog = CSVReader.Read("Kor_Dialogue_MythOfBisa_CSV");
    }
    public void ActiveConversationBox()
    {
        if(kor_Dialog[GameData.CurrentPageNum+1]["EventNum"].ToString() != "End"){
            ConversationBox.SetActive(true);
        }
    }
}
