using System.Collections;
using System.Collections.Generic;
using TankGame.Localization;
using UnityEngine;
using UnityEngine.UI;
using l10n = TankGame.Localization.Localization;

namespace TankGame
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private int _score = 100;

        private const string ScoreKey = "score";

        public void OnEnable()
        {
            _scoreText = GetComponentInChildren<Text>();
            SetScore(_score);
            l10n.LanguageLoaded += OnLanguageLoaded;
        }

        private void OnLanguageLoaded(LangCode currentLang)
        {
            SetScore(_score);
        }

        public void SetScore(int score)
        {
            string translation = l10n.CurrentLanguage.GetTranslation(ScoreKey);
            _scoreText.text = string.Format(translation, score);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player") )
            {
                GameManager.Instance.ScorePoints(_score);
                gameObject.SetActive(false);
            }
        }

        protected void OnDestroy()
        {
            l10n.LanguageLoaded -= OnLanguageLoaded;
        }
    }
}
