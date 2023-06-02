
using UnityEngine;

namespace Game.Managers
{
	public class CombatManager : MonoBehaviour
	{
		public static CombatManager instance;
		[SerializeField] private KeyCode _attackButton;
		public bool canReceiveInput;
		public bool inputReceived;
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
		private void Update()
		{
			if (Input.GetKeyDown(_attackButton))
			{
				Attack();
			}
		}
		public void Attack()
		{

			inputReceived = true;
			canReceiveInput = false;

			if (Input.GetKeyUp(_attackButton))
			{

				canReceiveInput = true;
			}

		}

		public void InputManager()
		{
			if (!canReceiveInput)
			{
				canReceiveInput = true;
			}
			else
			{
				canReceiveInput = false;
			}
		}
	}
}
