using System.Collections.Generic;
using UnityEngine;

public class StoreManagement : MonoBehaviour
{
	public GameObject plantItem;
	List<PlantObject> plantObjects = new List<PlantObject>();

	private void Awake()
	{
		var loadPlant = Resources.LoadAll("Plants", typeof(PlantObject));

		foreach(var plant in loadPlant)
		{
			plantObjects.Add((PlantObject)plant);
		}
		plantObjects.Sort(SortByPrice);

		foreach(var plant in loadPlant)
		{
			PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
			newPlant.plant = (PlantObject)plant;
		}

	}

	int SortByPrice(PlantObject plantObject1, PlantObject plantObject2)
	{
		return plantObject1.buyprice.CompareTo(plantObject2.buyprice);
	}

}
