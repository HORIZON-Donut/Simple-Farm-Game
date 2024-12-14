using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
	public PlantItem selectPlant;
	public bool isPlanting = false;

	public int money = 100;
	public Text moneyTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyTxt.text = "$"+money;
    }

	public void SelectPlant(PlantItem newPlant)
	{
		if(selectPlant == newPlant)
		{
			selectPlant = null;
			isPlanting = false;
		}
		else
		{
			selectPlant = newPlant;
			isPlanting = true;
		}
	}

	public void Transaction(int amount)
	{
		money += amount;
		moneyTxt.text = "$"+money;
	}
}

