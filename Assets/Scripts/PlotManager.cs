using UnityEngine;

public class PlotManager : MonoBehaviour
{
	bool isPlanted = false;
	bool isCoin = false;
	bool isDry = true;

    SpriteRenderer myplant;
	SpriteRenderer coin;

	SpriteRenderer plot;

	public Sprite dryPlot;
	public Sprite normalPlot;

    int plantStage = 0;
    float timer;

	PlantObject selectedPlant;
	FarmManager fm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		myplant = transform.GetChild(0).GetComponent<SpriteRenderer>();
		coin = transform.GetChild(1).GetComponent<SpriteRenderer>();
		fm = FindObjectOfType<FarmManager>();
		plot = GetComponent<SpriteRenderer>();
		plot.sprite = dryPlot;
    }

    // Update is called once per frame
    void Update()
    {
		if (isPlanted && isDry)
        {
            //https://medium.com/star-gazers/understanding-time-deltatime-6528a8c2b5c8

            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
			if(plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
			{
            	Ground();
			}
        }
		else if(isCoin)
		{
			Coin();
		}
        else if(fm.isPlanting && fm.selectPlant.plant.buyprice <= fm.money)
		{
            Plant(fm.selectPlant.plant);
        }

		if(fm.isSelectingTool)
		{
			switch(fm.toolSelected)
			{
				case 1:	//hoe
					break;
				case 2:	//ferterilizer
					break;
				case 3:	//water
					isDry = false;
					plot.sprite = normalPlot;
					break;
				case 4:	//axe
					break;
				case 5:	//shovel
					break;
			}
		}
	
}
	void UpdatePlant() {
       myplant.sprite = selectedPlant.plantStages[plantStage];
    }
	void Coin()
	{
		isCoin = false;
		coin.gameObject.SetActive(false);
		fm.Transaction(selectedPlant.sellprice);	
	}
    void Ground() {
        isPlanted = false;
		isCoin = true;
		//isDry = true;
		//plot.sprite = dryPlot;
        myplant.gameObject.SetActive(false);
		coin.gameObject.SetActive(true);
	 }
    void Plant(PlantObject newPlant) {
		selectedPlant = newPlant;
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        myplant.gameObject.SetActive(true);
		fm.Transaction(-selectedPlant.buyprice);
	}
}
