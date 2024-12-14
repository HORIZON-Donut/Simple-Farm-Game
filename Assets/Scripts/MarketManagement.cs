using UnityEngine;

public class StoreManagement : MonoBehaviour
{
	public GameObject plantItem;

	private void Awake()
	{
		var loadPlant = Resources.LoadAll("Plants", typeof(PlantObject));

		foreach(var plant in loadPlant)
		{
			PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
			newPlant.plant = (PlantObject)plant;
		}
	}
}
