using UnityEngine;

public class FarmManager : MonoBehaviour
{
	public PlantItem selectPlant;
	public bool isPlanting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
