using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwStages;
    public int buyprice;
    public int sellprice;
	public int upgradeprice;
    public Sprite icon;
	public Sprite dryPlant;
	public int level = 1;

	public void UpdatePlant()
	{
		timeBtwStages *= level;
		buyprice *= level;
		sellprice *= level;
		upgradeprice *= level;
	}
}
