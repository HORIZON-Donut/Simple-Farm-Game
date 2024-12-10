using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject Marketplace;
	public int mode;

	public void ActivatePanel()
	{
		Marketplace.SetActive(true);
		mode = 1;
	}
	public void DeactivatePanel()
	{
		Marketplace.SetActive(false);
		mode = 0;
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
