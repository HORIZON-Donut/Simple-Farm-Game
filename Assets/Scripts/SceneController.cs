using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject Marketplace;
	public GameObject Inventory;

	public void SwitchToMarketplace()
	{
		Marketplace.SetActive(true);
		Inventory.SetActive(false);
	}
	public void SwitchToInventory()
	{
		Marketplace.SetActive(false);
		Inventory.SetActive(true);
	}
	//public void OnPlayButton()
	//{
	//	SceneManager.LoadScene(1);
	//}
	//public void OnQuitButton()
	//{
	//	Application.Quit();
	//}
}
