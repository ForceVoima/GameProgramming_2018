using UnityEngine;
using UnityEngine.UI;
using l10n = TankGame.Localization.Localization;
using TankGame.Localization;

namespace TankGame.UI
{
    public class DeathsUI : MonoBehaviour
    {
        private Text _text;
        private int _currentDeaths;

        private const string ScoreKey = "death";
        private const string LoseKey = "youlose";

        private bool _resolved = false;

        public void Init()
        {
            _text = GetComponentInChildren<Text>();
            SetDeaths(0);
            l10n.LanguageLoaded += OnLanguageLoaded;
        }

        private void OnLanguageLoaded(LangCode currentLang)
        {
            if (!_resolved)
                SetDeaths(_currentDeaths);
            else
                YouLose();
        }

        public void SetDeaths(int Deaths)
        {
            _currentDeaths = Deaths;
            string translation = l10n.CurrentLanguage.GetTranslation(ScoreKey);
            _text.text = string.Format(translation, Deaths);
        }

        public void YouLose()
        {
            _resolved = true;
            string translation = l10n.CurrentLanguage.GetTranslation(LoseKey);
            _text.text = translation;
        }

        protected void OnDestroy()
        {
            l10n.LanguageLoaded -= OnLanguageLoaded;
        }
    }
}
