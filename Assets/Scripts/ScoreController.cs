using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public int money = 100;
	public Text MyScore_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		MyScore_text.text = "$"+money;
	}
	 // Update is called once per frame
    public void AddScore(int amount)
    {
        money+=amount;
		MyScore_text.text = "$"+money;
    }
}
