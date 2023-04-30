using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.SO;
namespace Game.Managers
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager instance;

		[SerializeField] private FloatSO _SfxVolume;
		[SerializeField] private FloatSO _mouseSensibility;

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
