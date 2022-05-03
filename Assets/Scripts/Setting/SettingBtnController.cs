using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtnController : MonoBehaviour
{
    public GameObject myCanvas;

    public void EnableOptionBox()
    {
        GameObject OptionBox = myCanvas.transform.Find("OptionBoxParent").gameObject;

        if (OptionBox)
        {
            if(OptionBox.activeInHierarchy == false)
            {
                OptionBox.SetActive(true);
            }
            else
            {
                OptionBox.SetActive(false);
            }
        }

    }

}
