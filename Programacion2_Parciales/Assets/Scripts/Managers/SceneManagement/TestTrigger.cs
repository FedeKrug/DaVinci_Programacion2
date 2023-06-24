using UnityEngine;

public class TestTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Test Trigger in {gameObject.name}");
	}
}