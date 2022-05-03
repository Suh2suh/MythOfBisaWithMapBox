using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBoxController : MonoBehaviour
{
    public GameObject BGMOnCheck;
    public GameObject BGMOffCheck;

    public GameObject SFXOnCheck;
    public GameObject SFXOffCheck;

    public GameObject KoreanOnCheck;
    public GameObject EnglishOnCheck;
    public GameObject ChineseOnCheck;

    public GameObject OptionBox;

    private void Awake()
    {
        InitSetting();   
    }

    void InitSetting()
    {
        InitBGMSetting();
        InitSFXSetting();
        InitLanguageSetting();
    }

    void InitBGMSetting()
    {
        if (GameData.BGMState)
        {
            BGMOn();
        }
        else
        {
            BGMOff();
        }
    }
    void InitSFXSetting()
    {
        if (GameData.SFXState)
        {
            SFXOn();
        }
        else
        {
            SFXOff();
        }
    }
    void InitLanguageSetting()
    {
        if (GameData.Language == "Korean")
        {
            KoreanOn();
        }
        else if (GameData.Language == "English")
        {
            EnglishOn();
        }
        else if (GameData.Language == "Chinese")
        {
            ChineseOn();
        }
        else
        {
            Debug.Log("Read Error in GameData.Language");
        }
    }

    public void BGMOn()
    {
        BGMOnCheck.SetActive(true);
        BGMOffCheck.SetActive(false);

        GameData.BGMState = true;
    }
    public void BGMOff()
    {
        BGMOffCheck.SetActive(true);
        BGMOnCheck.SetActive(false);

        GameData.BGMState = false;
    }

    public void SFXOn()
    {
        SFXOnCheck.SetActive(true);
        SFXOffCheck.SetActive(false);

        GameData.SFXState = true;
    }
    public void SFXOff()
    {
        SFXOffCheck.SetActive(true);
        SFXOnCheck.SetActive(false);

        GameData.SFXState = false;
    }

    public void KoreanOn()
    {
        KoreanOnCheck.SetActive(true);
        EnglishOnCheck.SetActive(false);
        ChineseOnCheck.SetActive(false);

        GameData.Language = "Korean";
    }
    public void EnglishOn()
    {
        EnglishOnCheck.SetActive(true);
        KoreanOnCheck.SetActive(false);
        ChineseOnCheck.SetActive(false);

        GameData.Language = "English";
    }
    public void ChineseOn()
    {
        ChineseOnCheck.SetActive(true);
        KoreanOnCheck.SetActive(false);
        EnglishOnCheck.SetActive(false);

        GameData.Language = "Chinese";
    }

    public void XButton()
	{
        OptionBox.SetActive(false);
	}
}
