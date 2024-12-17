using UnityEngine;

public class PlotManager : MonoBehaviour
{
	bool isPlanted = false;
	bool isCoin = false;
	bool isDry = true;
	public bool isAvailable = true;

    SpriteRenderer myplant;
	SpriteRenderer coin;

	SpriteRenderer plot;

	public Sprite dryPlot;
	public Sprite normalPlot;
	public Sprite unavailablePlot;

    int plantStage = 0;
    float timer;
	float speed = 1;
	float cdTimer = 300;

	PlantObject selectedPlant;
	FarmManager fm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		myplant = transform.GetChild(0).GetComponent<SpriteRenderer>();
		coin = transform.GetChild(1).GetComponent<SpriteRenderer>();
		fm = FindFirstObjectByType<FarmManager>();
		plot = GetComponent<SpriteRenderer>();
		if(!isAvailable)
		{
			plot.sprite = unavailablePlot;
		}
		else
		{
			plot.sprite = dryPlot;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (isPlanted && !isDry)
        {
            timer -= speed*Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
		else if(isDry && !isPlanted)
		{
			cdTimer -= 1*Time.deltaTime;
			if (cdTimer <= 0)
			{
				DisablePlot();
				cdTimer = 300;
			}
		}
    }

    private void OnMouseDown()
    {
		if(fm.isSelectingTool)
		{
			switch(fm.toolSelected)
			{
				case 1:	//hoe
					if (isPlanted)
       				{
						if(plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
						{
            				Ground();
						}
        			}
					break;

				case 2:	//ferterilizer
					if(isAvailable && fm.money >= 20){if(speed < 2) speed += 0.1f;fm.Transaction(-20);}
					break;

				case 3:	//water
				if(isAvailable){
					isDry = false;
					plot.sprite = normalPlot;
					if(isPlanted) UpdatePlant();
				}
					break;

				case 4:	//shovel
					if(!isAvailable && fm.money >= 50)
					{
						EnablePlot();
						fm.Transaction(-50);
					}
					break;

				case 5:	//axe
					CutOff();
					break;

				default:
					break;
			}
		}
		else if(isCoin)
		{
			Coin();
		}
        else if(fm.isPlanting && fm.selectPlant.plant.buyprice <= fm.money && isAvailable)
		{
            Plant(fm.selectPlant.plant);
        }

	
}
	void UpdatePlant() {
		if(isDry)
		{
			myplant.sprite = selectedPlant.dryPlant;
		}
		else
		{
       		myplant.sprite = selectedPlant.plantStages[plantStage];
		}
    }
	void Coin()
	{
		isCoin = false;
		coin.gameObject.SetActive(false);
		fm.Transaction(selectedPlant.sellprice);	
	}
    void Ground() {
		isCoin = true;
		plot.sprite = dryPlot;
        myplant.gameObject.SetActive(false);
		coin.gameObject.SetActive(true);
		speed = 1f;
		EnablePlot();
	 }
    void CutOff() 
	{
		plot.sprite = dryPlot;
        myplant.gameObject.SetActive(false);
		speed = 1f;
		DisablePlot();
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

	void DisablePlot()
	{
		isPlanted = false;
		isDry = true;
		isAvailable = false;
		plot.sprite = unavailablePlot;
	}

	void EnablePlot()
	{
		isPlanted = false;
		isDry = true;
		isAvailable = true;
		plot.sprite = dryPlot;
		cdTimer = 300;
	}
}
