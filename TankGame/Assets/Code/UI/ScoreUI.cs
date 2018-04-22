using UnityEngine;
using UnityEngine.UI;
using l10n = TankGame.Localization.Localization;
using TankGame.Localization;

namespace TankGame.UI
{
    public class ScoreUI : MonoBehaviour
    {
        private Text _text;
        private int _currentScore;

        private const string ScoreKey = "score";
        private const string WinKey = "youwin";

        private bool _resolved = false;

        public void Init()
        {
            _text = GetComponentInChildren<Text>();
            SetScore(0);
            l10n.LanguageLoaded += OnLanguageLoaded;
        }

        private void OnLanguageLoaded(LangCode currentLang)
        {
            if (!_resolved)
                SetScore(_currentScore);
            else
                YouWin();
        }

        public void SetScore(int score)
        {
            _currentScore = score;
            string translation = l10n.CurrentLanguage.GetTranslation(ScoreKey);
            _text.text = string.Format(translation, score);
        }

        public void YouWin()
        {
            _resolved = true;
            string translation = l10n.CurrentLanguage.GetTranslation(WinKey);
            _text.text = translation;
        }

        protected void OnDestroy()
        {
            l10n.LanguageLoaded -= OnLanguageLoaded;
        }
    }
}
