using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlantItem : MonoBehaviour
{
	public PlantObject plant;

	public GameObject Locked;
	public GameObject Unlocked;

	public Text nameTxt;
	public Text priceTxt;
	public Text unlockTxt;
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
		priceTxt.text = "$" + plant.buyprice;
		unlockTxt.text = "$" + plant.unlockPrice;
		icon.sprite = plant.icon;
	}

	void unlockPlant()
	{
		Locked.gameObject.SetActive(false);
		Unlocked.gameObject.SetActive(true);
	}

	public void BuyPlant()
	{
		fm.SelectPlant(this);
	}

	public void UnlockPlant()
	{
		if(fm.money >= plant.unlockPrice)
		{
			unlockPlant();
			fm.Transaction(-plant.unlockPrice);
		}
	}
}

