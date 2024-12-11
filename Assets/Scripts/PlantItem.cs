using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
	public PlantObject plant;

	public Text nameTxt;
	public Text priceTxt;
	public Text upgradePriceTxt;
	public Image icon;

	FarmManager fm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		fm = FindObjectOfType<FarmManager>();
		initializationUI();
    }
	void initializationUI()
	{
		nameTxt.text = plant.plantName;
		priceTxt.text = "$" + (plant.buyprice * plant.level);
		upgradePriceTxt.text = "$" + (plant.upgradeprice * plant.level);
		icon.sprite = plant.icon;
	}

	public void BuyPlant()
	{
		Debug.Log("Buy"+plant.plantName);
		fm.SelectPlant(this);
	}
}
