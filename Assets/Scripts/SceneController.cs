using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject Marketplace;

	public void ActivateMarketPlace()
	{
		Marketplace.SetActive(true);
	}
	public void DeactivateMaeketPlace()
	{
		Marketplace.SetActive(false);
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
