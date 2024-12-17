using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
	public PlantObject plant;

	public Text nameTxt;
	public Text priceTxt;
	public Text upgradePriceTxt;
	public Text LevelTxt;
	public Image icon;

	FarmManager fm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		fm = FindFirstObjectByType<FarmManager>();
		initializationUI();
    }
	void initializationUI()
	{
		nameTxt.text = plant.plantName;
		priceTxt.text = "$" + (plant.buyprice * plant.level);
		upgradePriceTxt.text = "$" + (plant.upgradeprice * plant.level);
		LevelTxt.text = "" + plant.level;
		icon.sprite = plant.icon;
	}

	public void BuyPlant()
	{
		fm.SelectPlant(this);
	}

	public void UpgradePlant()
	{
		if(fm.money >= plant.upgradeprice && plant.level <= plant.maxLvl)
		{
			fm.Transaction(-plant.upgradeprice);
			plant.level += 1;
			plant.UpdatePlant();
			initializationUI();
		}
	}
}
