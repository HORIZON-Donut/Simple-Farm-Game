using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
	public PlantObject plant;

	public Text nameTxt;
	public Text priceTxt;
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
		priceTxt.text = "$" + (plant.buyprice);
		icon.sprite = plant.icon;
	}

	public void BuyPlant()
	{
		fm.SelectPlant(this);
	}
}
