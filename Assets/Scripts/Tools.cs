using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
	public  EquipmentObject tool;

	public Text nameTxt;
	public Image icon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		initializationUI();
    }
	void initializationUI()
	{
		nameTxt.text = tool.toolsName;
		icon.sprite = tool.icon;
	}

	public void BuyPlant()
	{
		Debug.Log("Buy"+tool.toolsName);
	}
}
