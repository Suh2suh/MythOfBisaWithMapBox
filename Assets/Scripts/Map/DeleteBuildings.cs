using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBuildings : MonoBehaviour
{
    bool isOnce = false;

    bool isBuildingExist = false;

    bool isDeletingDone = false;

    List<string> UnNeedTiles;
    List<string> UnNeedBuildingsParent;
    List<string> NeedBuildings;

    void Start()
    {
        UnNeedTiles = new List<string>() { "17/112352/51534", "17/112352/51535", "17/112352/51536" };
        UnNeedBuildingsParent = new List<string>() { "17/112351/51536", "17/112351/51534", "17/112351/51535" };
        NeedBuildings = new List<string>() { "Untitled - 761858107", "Untitled - 504635748", "Untitled - 761858106" };

        StartCoroutine("checkBuildingAndDelete");
    }

    IEnumerator checkBuildingAndDelete()
    {
        while (!isOnce)
        {
            checkIfBuildingExist();

            if (isBuildingExist)
            {
                deleteUnNeedBuildings();
            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void checkIfBuildingExist()
    {
        if (GameObject.Find(UnNeedTiles[0]))
        {
            isBuildingExist = true;
        }
    }

    void deleteUnNeedBuildings()
    {
        int forTile = 0;
        int forParent = 0;

        while (!isDeletingDone)
        {
            if (forTile <= 2)
            {
                GameObject.Find(UnNeedTiles[forTile]).SetActive(false);

                forTile++;
            }
            if (forParent <= 2)
            {
                Transform[] childList = GameObject.Find(UnNeedBuildingsParent[forParent]).GetComponentsInChildren<Transform>();

                if(childList != null)
				{
                    int endPos;

                    if (forParent == 2)
					{
                        endPos = childList.Length - 3;
                    }
                    else
					{
                        endPos = childList.Length;
					}

                    for(int i = 1; i < endPos; i++)
					{
                        if (childList[i] != transform)
                            childList[i].gameObject.SetActive(false);
					}
                }

                forParent++;
            }

            if (forParent > 2 && forTile > 2)
                isDeletingDone = true;

        }

        isOnce = true;
    }
}
