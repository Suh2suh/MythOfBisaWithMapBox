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
        //��ư �ؽ�Ʈ ����
        ChangeTextOfButtons();

        //��ư �� �� �� �ϳ� Ŭ���� �� conversationBoxController�� ClickingConversationBox() ����
        //(�ش� �г� Ȱ��ȭ �� conversationBox ����ĳ��Ʈ Ŭ�� �� �ϰ� �� ��)
    }

    void ChangeTextOfButtons()
    {
        //�������� �� ���� ������ �����

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
        //TODO: ��ȭâ ��Ʈ�ѷ��� changeText �Լ��� �����ϴ� �� ���� ����� ã�ƺ� �� (üũ�� bool�� �ᵵ ���� ��)
        GameData.CurrentSelectEventNum++;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
