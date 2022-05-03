using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseParentClickingOutside : MonoBehaviour
{
    bool isMouseOn;

    private void Update()
    {
        CloseBoxIfClickOutSide();
    }

    void CloseBoxIfClickOutSide()
    {
        if (Input.GetMouseButton(0) && !isMouseOn)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void TurnIsMouseOnT()
    {
        isMouseOn = true;
    }
    public void TurnIsMouseOnF()
    {
        isMouseOn = false;
    }
}
