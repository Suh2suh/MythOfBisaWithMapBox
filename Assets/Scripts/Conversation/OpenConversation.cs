using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenConversation : MonoBehaviour
{
    public GameObject ConversationCanvas;
    public Camera ConversationCam;

    List<Dictionary<string, object>> kor_Dialog;

    private void Awake()
    {
        kor_Dialog = CSVReader.Read("Kor_Dialogue_MythOfBisa_CSV");
    }
    public void ActiveConversation()
    {
        if(kor_Dialog[GameData.CurrentPageNum+1]["EventNum"].ToString() != "End"){

            //Do not change order (canvas should use camera)
            ConversationCam.gameObject.SetActive(true);
            ConversationCanvas.SetActive(true);
        }
    }
}
