using Game.Cameras;
using Game.Enemies;

using UnityEngine;
using UnityEngine.Events;
namespace Game.Managers
{
	[DefaultExecutionOrder(-10)]
	public class EventManager : MonoBehaviour
	{
		public static EventManager instance;
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
		public IncreaseHealthEvent playerHealthIncreased = new IncreaseHealthEvent();
		public TakeDamageEvent playerDamaged = new TakeDamageEvent();

		public CameraChangeEvent cameraChangeEvent = new CameraChangeEvent();

		public UpdateHealthUIEvent updateHealthUIEvent = new UpdateHealthUIEvent();

		public MakeDamageToEnemyEvent makeDamageToEnemyEvent = new MakeDamageToEnemyEvent();
	}

	public class IncreaseHealthEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc) -> aplicado a la curacion
	public class TakeDamageEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc) -> aplicado al daño

	public class CameraChangeEvent : UnityEvent <TypesOfCamera>{} //primer TypesOfCamera: tipo de camara deseado

	public class UpdateHealthUIEvent : UnityEvent<float, float> { } //vida max -> vida actual

	public class MakeDamageToEnemyEvent : UnityEvent<float, float, Enemy> { } //damage made to enemy and enemyHealth amount

}
