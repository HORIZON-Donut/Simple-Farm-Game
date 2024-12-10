using UnityEngine;

public class PlotManager : MonoBehaviour
{
	bool isPlanted = false;
	bool isCoin = false;

    public SpriteRenderer myplant;
	public SpriteRenderer coin;

    int plantStage = 0;
    float timer;

	ScoreController _scorePoint;
	PlantObject selectedPlant;
	FarmManager fm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_scorePoint = FindObjectOfType<ScoreController>();
		fm = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isPlanted)
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
        else if(fm.isPlanting && fm.selectPlant.plant.buyprice <= _scorePoint.money)
		{
            Plant(fm.selectPlant.plant);
        }
	
}
	void UpdatePlant() {
       myplant.sprite = selectedPlant.plantStages[plantStage];
    }
	void Coin()
	{
		isCoin = false;
		coin.gameObject.SetActive(false);
		_scorePoint.AddScore(selectedPlant.sellprice);	
	}
    void Ground() {
        isPlanted = false;
		isCoin = true;
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
		_scorePoint.AddScore(-selectedPlant.buyprice);
	}
}
