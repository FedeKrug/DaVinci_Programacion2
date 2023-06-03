using UnityEngine;
using Game.Managers;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen instance;


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
            Time.timeScale = 0;
			GameManager.instance.FreeCursor();
			GameManager.instance.ShowCursor();

		}
        else
		{
            Time.timeScale = 1;
			GameManager.instance.BlockCursor();
			GameManager.instance.HideCursor();
		}

	}
}