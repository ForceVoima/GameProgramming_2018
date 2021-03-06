using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.UI
{
	public class UI : MonoBehaviour
	{
		public static UI Current { get; private set; }

		public HealthUI HealthUI { get; private set; }
        public ScoreUI ScoreUI { get; private set; }
        public DeathsUI DeathsUI { get; private set; }

        public void Init()
		{
			Current = this;
			HealthUI = GetComponentInChildren< HealthUI >();
			HealthUI.Init();

            ScoreUI = GetComponentInChildren<ScoreUI>();
            ScoreUI.Init();

            DeathsUI = GetComponentInChildren<DeathsUI>();
            DeathsUI.Init();
        }
	}
}
