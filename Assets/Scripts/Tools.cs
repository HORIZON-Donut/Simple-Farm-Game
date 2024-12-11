using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
	public  EquipmentObject tool;

	public Image icon;
	public Text NameTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		initializationUI();
    }
	void initializationUI()
	{
		NameTxt.text = tool.toolsName;
		icon.sprite = tool.icon;
	}

	public void EquipTools()
	{
		Debug.Log("EquipTools"+tool.toolsName);
	}
}
