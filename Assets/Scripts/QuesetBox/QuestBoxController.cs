using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoxController : MonoBehaviour
{
    List<Dictionary<string, object>> QuestDialogue;

    public GameObject QuestBox;
    public Text QuestTitleText;
    public Text QuestContentText;

    public GameObject MapSection;
    public Sprite[] QuestMaps;

    int lastQuestNum = 0;

    private void Awake()
    {
        QuestDialogue = CSVReader.Read("kor_QuestDialogue_MythOfBisa_CSV");
    }

    private void OnEnable()
    {
        if (IsRightQuestNumber())
        {
            if (IsQuestChanged())
            {
                ChangeQuestText();
                ChangeQuestMapGraphic();
            }
        }
    }

    bool IsQuestChanged()
    {
        return (lastQuestNum == 0 || lastQuestNum != GameData.CurrentQuestNum);
    }

    bool IsRightQuestNumber()
    {
        if(GameData.CurrentQuestNum >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ChangeQuestText()
    {
        //�ҷ��� ����Ʈ ������ QuestNum üũ
        //����Ʈ �ѹ��� ���� ����Ʈ Ÿ��Ʋ, ����Ʈ ���� ����

        ApplyQuestTitle();
        ApplyQuestContentWithLineBreak();
    }

    void ApplyQuestTitle()
    {
        Debug.Log(GameData.CurrentQuestNum);
        QuestTitleText.text = QuestDialogue[GameData.CurrentQuestNum-1]["QuestTitle"].ToString();
    }

    void ApplyQuestContentWithLineBreak()
    {
        string TextBeforeLineBreak = QuestDialogue[GameData.CurrentQuestNum - 1]["QuestContent"].ToString(); ;

        if (TextBeforeLineBreak.Contains("ENTER"))
        {
            string TextAfterLineBreak = TextBeforeLineBreak.Replace("ENTER", "\n");
            QuestContentText.text = TextAfterLineBreak;
        }
        else
        {
            QuestContentText.text = TextBeforeLineBreak;
        }
    }

    void ChangeQuestMapGraphic() 
    {
        MapSection.GetComponent<Image>().sprite = QuestMaps[GameData.CurrentQuestNum-1];
    }

    public void CloseQuestBox()
    {
        QuestBox.SetActive(false);
    }
}
