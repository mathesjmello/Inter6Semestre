using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
	public GameObject MainMenuScreen;
	public GameObject OptionScreen;

	public void Opções()
	{
		MainMenuScreen.SetActive(!MainMenuScreen.activeSelf);
		OptionScreen.SetActive(true);


	}

	public void VoltaOpções()
	{
		OptionScreen.SetActive(false);
		MainMenuScreen.SetActive(true);

	}
}
