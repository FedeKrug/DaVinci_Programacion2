using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

public class Goal : MonoBehaviour
{
	[SerializeField] private Canvas _goalScreen;
	[SerializeField] private CanvasManager _canvasManagerRef;
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerMovement>() != null)
		{
			GoalScreen();

		}
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.M))
		{
			GoalScreen();
		}
	}
	private void GoalScreen()
	{
		_canvasManagerRef.GoalScreen();
	}
}
