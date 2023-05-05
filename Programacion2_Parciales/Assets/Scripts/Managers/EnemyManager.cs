using UnityEngine;
namespace Game.Managers
{
	public class EnemyManager : MonoBehaviour
	{
		public static EnemyManager instance;
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
	}
}
