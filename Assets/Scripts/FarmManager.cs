using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
	public PlantItem selectPlant;
	public bool isPlanting = false;

	public int money = 100;
	Text moneyTxt;

	public bool isSelectingTool = false;
	public int toolSelected = 0;
	//1 - hoe 2 - ferterilizer 3 - water 4 - axe 5 - shovel

	public Image[] buttonImg;
	public Sprite normalButton;
	public Sprite selectedButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		moneyTxt = transform.GetChild(0).GetComponent<Text>();
        moneyTxt.text = "$"+money;
    }

	public void SelectPlant(PlantItem newPlant)
	{
		if(selectPlant == newPlant)
		{
			Deselection();
		}
		else
		{
			Deselection();
			selectPlant = newPlant;
			isPlanting = true;
		}
	}

	public void SelectTool(int toolsNumber)
	{
		if(toolSelected == toolsNumber)
		{
			Deselection();
		}
		else
		{
			Deselection();
			isSelectingTool = true;
			toolSelected = toolsNumber;
			buttonImg[toolsNumber - 1].sprite = selectedButton;
		}
	}

	void Deselection()
	{
		if(isPlanting)
		{
			isPlanting = false;
			selectPlant = null;
		}

		if(isSelectingTool)
		{
			if(toolSelected>0)
			{
				buttonImg[toolSelected - 1].sprite = normalButton;
			}
			isSelectingTool = false;
			toolSelected = 0;
		}
	}

	public void Transaction(int amount)
	{
		money += amount;
		moneyTxt.text = "$"+money;
	}
}

