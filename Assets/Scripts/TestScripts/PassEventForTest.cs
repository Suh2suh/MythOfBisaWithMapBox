using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassEventForTest : MonoBehaviour
{
    public void PassToEvent1()
    {

    }
    public void PassToEvent2()
    {
        GameData.CurrentPageNum = 27;
        GameData.CurrentEventNum = 2;
    }
    public void PassToEvent3()
    {
        GameData.CurrentPageNum = 41;
        GameData.CurrentEventNum = 3;
    }
    public void PassToEvent4()
    {
        GameData.CurrentPageNum = 67;
        GameData.CurrentEventNum = 4;
    }
    public void PassToEvent5()
    {
        GameData.CurrentPageNum = 89;
        GameData.CurrentEventNum = 5;
    }
    public void PassToEvent6()
    {
        GameData.CurrentPageNum = 114;
        GameData.CurrentEventNum = 6;
    }
    public void PassToEvent7()
    {
        GameData.CurrentPageNum = 141;
        GameData.CurrentEventNum = 7;
    }
    public void PassToEvent8()
    {
        GameData.CurrentPageNum = 157;
        GameData.CurrentEventNum = 8;
    }
    public void PassToEvent9()
    {
        GameData.CurrentPageNum = 182;
        GameData.CurrentEventNum = 9;
    }
}
