using UnityEngine;
using Game.Managers;

public class PauseScreen : MonoBehaviour
{
	public static PauseScreen instance;
	[SerializeField] private GameObject _pauseScreen;

	#region Singleton
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	public bool paused;

	private void Update()
	{
		if (Input.GetButtonDown("Pause"))
		{
			PauseGame();
		}
	}
	private void PauseGame()
	{
		paused = !paused;
		if (paused)
		{
			CombatManager.instance.inputReceived = false;
			Time.timeScale = 0;
			_pauseScreen.SetActive(true);
			GameManager.instance.FreeCursor();
			GameManager.instance.ShowCursor();
		}
		else
		{
			ResumeGame();
		}

	}
	public void ResumeGame()
	{
		CombatManager.instance.inputReceived = false;
		Time.timeScale = 1;
		_pauseScreen.SetActive(false);
		GameManager.instance.BlockCursor();
		GameManager.instance.HideCursor();
	}
}