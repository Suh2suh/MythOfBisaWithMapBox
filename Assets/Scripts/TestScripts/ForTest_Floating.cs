using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest_Floating : MonoBehaviour
{
    Vector3 UpPos;
    Vector3 DownPos;

    Vector3 MovingScale;
    private void Start()
    {
        MovingScale = new Vector3(0, 1f, 0);

        UpPos = transform.position + MovingScale;
        DownPos = transform.position - MovingScale;

        StartCoroutine(MovingUp());
    }

    private IEnumerator MovingUp()
    {
        while (transform.position.y < UpPos.y)
        {
            Vector3 moveToThis = gameObject.transform.position + new Vector3(0, 0.05f, 0);
            gameObject.transform.position = moveToThis;

            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(MovingDown());
    }

    private IEnumerator MovingDown()
    {
        while (transform.position.y > DownPos.y)
        {
            Vector3 moveToThis = gameObject.transform.position - new Vector3(0, 0.05f, 0);
            gameObject.transform.position = moveToThis;

            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(MovingUp());
    }
}
