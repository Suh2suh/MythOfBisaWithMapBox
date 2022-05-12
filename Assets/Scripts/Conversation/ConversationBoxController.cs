using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationBoxController : MonoBehaviour
{
    public GameObject ConversationCanvas;
    public GameObject ConversationCam;

    public GameObject NameOfConversationBox;

    public GameObject NameTextOfConversationBox;
    public GameObject MainTextOfConversationBox;

    public GameObject QuestGenerator;

    bool IsDoubleClicked = false;
    bool IsCurrentPageEnd = false;

    bool IsNameBoxNeeded = true;
    bool IsSelectEventNeeded = false;

    bool IsNewQuest = false;


    Text NameText;
    Text MainText;

    List<Dictionary<string, object>> kor_Dialog;

    [SerializeField]
    float TalkingSpeed = 0.02f;



    public GameObject SelectEventPanel;


    private void Awake()
    {
        kor_Dialog = CSVReader.Read("Kor_Dialogue_MythOfBisa_CSV");

        NameText = NameTextOfConversationBox.GetComponent<Text>();
        MainText = MainTextOfConversationBox.GetComponent<Text>();
    }

    private void OnEnable()
    {
        InitPage();
        //ĳ������ ȥ�㸻 ���� ��, ���� �̺�Ʈ�� Ŭ����ƴ��� Ȯ���ϰ� �˸��� ��ȭâ ����� ��
    }
    
    private void InitPage()
    {
        GameData.CurrentPageNum++;
        ChangeTextApplyingPlayerName();
        IsNewQuest = false;
    }


    public void ClickingConversationBox()
    {
        if (IsSelectEventNeeded)
        {
            DoSelectEvent();
            IsSelectEventNeeded = false;
        }
        else
        {
            if (IsCurrentPageEnd)
            {
                PassToNextText();
            }
            else
            {
                IsDoubleClicked = true;
            }
        }
    }

    void PassToNextText()
    {
        IsCurrentPageEnd = false;

        if (IsRightEventForNow())
        {
            ChangeTextUnlessFinalPage();
        }
    }

    bool IsRightEventForNow()
    {
        return kor_Dialog[GameData.CurrentPageNum]["EventNum"].ToString() == GameData.CurrentEventNum.ToString();
    }

    void ChangeTextUnlessFinalPage()
    {
        if (IsNotFinalPage())
        {
            ChangeTextApplyingPlayerName();
        }
        else
        {
            GameData.CurrentEventNum++; //���� �÷��̾ �̺�Ʈ�� Ŭ���� �ߴٸ�, ���Ŀ� �� �ڵ带 ������ �� (����� �̺�Ʈ�� �����Ƿ� �׽�Ʈ��)
            CloseConversationBox();
        }
    }

    bool IsNotFinalPage()
    {
        return (kor_Dialog[GameData.CurrentPageNum]["PageNum"].ToString() != "" && kor_Dialog[GameData.CurrentPageNum]["PageNum"].ToString() != null);
    }

    void ChangeTextApplyingPlayerName()
    {
        if (IsAnnounceText())
        {
            Debug.Log("�ȳ��ؽ�Ʈ��");
            DisableNameBox();
            ChangeMainTextApplyingPlayerName();
        }
        else
        {
            ReAbleNameBoxIfNeeded();

            ChangeNameTextApplyingPlayerName();
            ChangeMainTextApplyingPlayerName();
        }
    }

    bool IsAnnounceText()
    {
        if(kor_Dialog[GameData.CurrentPageNum]["Name"].ToString() == "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DisableNameBox()
    {
        NameOfConversationBox.SetActive(false);

        IsNameBoxNeeded = true;
    }

    void ReAbleNameBoxIfNeeded()
    {
        if (IsNameBoxNeeded)
        {
            NameOfConversationBox.SetActive(true);
            IsNameBoxNeeded = false;
        }
    }

    void ChangeNameTextApplyingPlayerName()
    {
        if (kor_Dialog[GameData.CurrentPageNum]["Name"].ToString().Contains("player")){
            string PlayerTextInName = kor_Dialog[GameData.CurrentPageNum]["Name"].ToString().Replace("player", GameData.PlayerName);
            NameText.text = PlayerTextInName;
        }
        else
        {
            NameText.text = kor_Dialog[GameData.CurrentPageNum]["Name"].ToString();
        }
    }

    void ChangeMainTextApplyingPlayerName()
    {
        if (kor_Dialog[GameData.CurrentPageNum]["Dialogue"].ToString().Contains("player"))
        {
            string PlayerTextInMain = kor_Dialog[GameData.CurrentPageNum]["Dialogue"].ToString().Replace("player", GameData.PlayerName);
            StartCoroutine(AnimateMainText(PlayerTextInMain));
        }
        else
        {
            StartCoroutine(AnimateMainText(kor_Dialog[GameData.CurrentPageNum]["Dialogue"].ToString()));
        }
    }


    IEnumerator AnimateMainText(string originalText)
    {
        Debug.Log("�ִϸ��̼� ����");

        string newText = "";
        int TailChar = 1;

        while(TailChar <= originalText.Length && !IsCurrentPageEnd)
        {
            newText = originalText.Substring(0, TailChar);
            TailChar++;

            MainText.text = newText;

            if (!IsDoubleClicked)
            {
                yield return new WaitForSeconds(TalkingSpeed);
            }
            else
            {
                break;
            }
        }

        MainText.text = originalText;

        EndCurrentPage();

        yield return null;
    }


    void EndCurrentPage()
    {
        CheckAndApplyQuest();
        GoToNextPageUnlessEvents();

        IsCurrentPageEnd = true;
        IsDoubleClicked = false;
    }

    void CheckAndApplyQuest()
    {
        if (kor_Dialog[GameData.CurrentPageNum]["Quest"].ToString() != "")
        {
            GameData.CurrentQuestNum = int.Parse(kor_Dialog[GameData.CurrentPageNum]["Quest"].ToString());
            IsNewQuest = true;
            Debug.Log("����Ʈ ����: " + GameData.CurrentQuestNum);
        }
    }

    void GoToNextPageUnlessEvents()
    {
        if (kor_Dialog[GameData.CurrentPageNum]["PassToPage"].ToString() != "")
            DoDialoguePass();
        else if (kor_Dialog[GameData.CurrentPageNum]["SelectEvent"].ToString() != "")
            IsSelectEventNeeded = true;
        else
            GameData.CurrentPageNum++;
    }

    void DoDialoguePass()
    {
        GameData.CurrentPageNum = int.Parse(kor_Dialog[GameData.CurrentPageNum]["PassToPage"].ToString());
    }

    void DoSelectEvent()
    {
        GameData.CurrentSelectEventNum = int.Parse(kor_Dialog[GameData.CurrentPageNum]["SelectEvent"].ToString());
        OpenSelectEventPanel();

        Debug.Log("�̺�Ʈ ����: " + kor_Dialog[GameData.CurrentPageNum]["SelectEvent"].ToString());
        Debug.Log("���� �̺�Ʈ ��ȣ: " + GameData.CurrentSelectEventNum);
    }

    void OpenSelectEventPanel()
    {
        SelectEventPanel.SetActive(true);
    }



    //Skip and Close
    void CloseConversationBox()
    {
        ConversationCanvas.SetActive(false);
        ConversationCam.SetActive(false);
    }

    private void OnDisable()
    {
        CheckQuestAndOpen();
    }

    void CheckQuestAndOpen()
	{
        if (IsNewQuest)
        {
            //�Ʒ� �� �ڵ��� ������ �ٲ� �ȵ� (��ư Ȱ��ȭ -> ����Ʈ�ڽ� Ȱ��ȭ)
            QuestGenerator.GetComponent<QuestBtnGenerator>().ActiveQuestBtn();
            QuestGenerator.GetComponent<QuestBoxGenerator>().OpenQuestBox();
        }
        else
        {
            QuestGenerator.GetComponent<QuestBtnGenerator>().UnactiveQuestBtn();
        }
    }

    public void skipDialogue()
	{
        IsNewQuest = true;

        switch (GameData.CurrentEventNum)
		{
            case 1:
                ConversationDataChange(2, 27, 1);
                break;
            case 2:
                ConversationDataChange(3, 41, 2);
                break;
            case 3:
                ConversationDataChange(4, 67, 3);
                break;
            case 4:
                ConversationDataChange(5, 89, 4);
                break;
            case 5:
                ConversationDataChange(6, 114, 5);
                break;
            case 6:
                ConversationDataChange(7, 141, 6);
                break;
            case 7:
                ConversationDataChange(8, 157, 7);
                break;
            case 8:
                ConversationDataChange(9, 182, 8);
                break;
            case 9:
                ConversationDataChange(10, 199, 9);
                break;
        }

        CloseConversationBox();
    }

    void ConversationDataChange(int eventNum, int pageNum, int questNum)
	{
        GameData.CurrentQuestNum = questNum;
        GameData.CurrentEventNum = eventNum;
        GameData.CurrentPageNum = pageNum;
    }
}
