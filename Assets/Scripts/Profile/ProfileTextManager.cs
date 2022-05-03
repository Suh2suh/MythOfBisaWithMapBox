using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ProfileTextManager : MonoBehaviour
{
	public Text nameText;
	public Text studentCodeText;

	public Text userCodeText; // ������ ���� ������

	private void Awake()
	{
		nameText.text = GameData.PlayerName.ToString();
		studentCodeText.text = GameData.StudentCode.ToString();
	}
}
