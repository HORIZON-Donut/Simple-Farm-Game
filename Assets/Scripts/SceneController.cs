using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject Marketplace;

	public void ActivatePanel()
	{
		Marketplace.SetActive(true);
	}
	public void DeactivatePanel()
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
