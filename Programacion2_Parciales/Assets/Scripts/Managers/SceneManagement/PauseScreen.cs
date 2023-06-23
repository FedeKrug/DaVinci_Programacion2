using UnityEngine;
using Game.Managers;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
	public static PauseScreen instance;
	[SerializeField] private Canvas _pauseScreen;

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
		if (Input.GetButtonDown("Pause")/* && _pauseScreen != null*/)
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
			_pauseScreen.enabled = true;
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
		_pauseScreen.enabled = false;
		GameManager.instance.BlockCursor();
		GameManager.instance.HideCursor();
	}
}