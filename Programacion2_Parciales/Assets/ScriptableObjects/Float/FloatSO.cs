using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.SO
{
	[CreateAssetMenu(fileName = "New Float", menuName = "ScriptableObject/Float")]
	public class FloatSO : ScriptableObject
	{
		public float value;
	}

}
