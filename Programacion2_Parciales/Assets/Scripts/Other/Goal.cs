using UnityEngine;
using UnityEngine.UI;
public class Goal : MonoBehaviour
{
	[SerializeField] private Canvas _goalScreen;
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerMovement>() != null)
		{
			_goalScreen.enabled = true;
			Time.timeScale = 0;
			
		}
	}
}
