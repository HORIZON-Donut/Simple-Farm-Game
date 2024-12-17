using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void OnPlayButton()
	{
		SceneManager.LoadScene(1);
	}
	public void OnQuitButton()
	{
		Application.Quit();
	}
	public void SwitchToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
