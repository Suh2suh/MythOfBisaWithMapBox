using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEventController : MonoBehaviour
{
    public GameObject ConversationController;

    public GameObject SelectingBtn1;
    public GameObject SelectingBtn2;

    int Btn1PageNum;
    int Btn2PageNum;

    List<Dictionary<string, object>> kor_SelectEvent;

    void Awake()
    {
        kor_SelectEvent = CSVReader.Read("Kor_SelectEvent_MythOfBisa_CSV");
    }

    void OnEnable()
    {
        //버튼 텍스트 변경
        ChangeTextOfButtons();

        //버튼 중 둘 중 하나 클릭할 시 conversationBoxController의 ClickingConversationBox() 실행
        //(해당 패널 활성화 시 conversationBox 레이캐스트 클릭 못 하게 할 것)
    }

    void ChangeTextOfButtons()
    {
        //선택지가 두 개일 때에만 적용됨

        Text BtnText1 = SelectingBtn1.GetComponent<Text>();
        Text BtnText2 = SelectingBtn2.GetComponent<Text>();

        Btn1PageNum = GameData.CurrentSelectEventNum * 2;
        Btn2PageNum = Btn1PageNum + 1;

        Debug.Log(BtnText1.text);
        Debug.Log(BtnText2.text);


        BtnText1.text = kor_SelectEvent[Btn1PageNum]["SelectText"].ToString();
        BtnText2.text = kor_SelectEvent[Btn2PageNum]["SelectText"].ToString();
    }

    public void ClickingButton1()
    {
        if (kor_SelectEvent[Btn1PageNum]["BackToDialogue"].ToString() != "")
        {
            GameData.CurrentPageNum = int.Parse(kor_SelectEvent[Btn1PageNum]["BackToDialogue"].ToString());
            Debug.Log(GameData.CurrentPageNum);
        }
        CloseSelectEventPanel();
    }

    public void ClickingButton2()
    {
        if (kor_SelectEvent[Btn2PageNum]["BackToDialogue"].ToString() != "")
        {
            GameData.CurrentPageNum = int.Parse(kor_SelectEvent[Btn2PageNum]["BackToDialogue"].ToString());
            Debug.Log(GameData.CurrentPageNum);
        }
        CloseSelectEventPanel();
    }

    public void CloseSelectEventPanel()
    {
        ConversationController.GetComponent<ConversationBoxController>().ClickingConversationBox();
        //TODO: 대화창 컨트롤러의 changeText 함수에 접근하는 더 좋은 방법을 찾아볼 것 (체크용 bool을 써도 좋을 듯)
        GameData.CurrentSelectEventNum++;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
