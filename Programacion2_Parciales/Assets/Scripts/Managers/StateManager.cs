using UnityEngine;

public class StateManager : MonoBehaviour
{
	//#region Singleton
	//public static StateManager instance;
	//private void Awake()
	//{
	//	if (instance == null)
	//	{
	//		instance = this;
	//	}
	//	else
	//	{
	//		Destroy(gameObject);
	//	}
	//}
	//#endregion

	[SerializeField] private State currentState;

	private void Update()
	{
		RunStateMachine();
	}

	private void RunStateMachine()
	{
		State nextState = currentState?.RunCurrentState();

		if (nextState != null)
		{
			SwitchToTheNextState(nextState);
		}

	}
	private void SwitchToTheNextState(State nextState)
	{
		currentState = nextState;
	}
}