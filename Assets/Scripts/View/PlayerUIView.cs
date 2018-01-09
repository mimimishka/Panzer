using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;

namespace Panzer
{
    public class PlayerUIView : View
    {
        [SerializeField]
        Text damageText;
        [SerializeField]
        RectTransform healthBar;
        [SerializeField]
        Text protectionText;
        [SerializeField]
        Text scoreText;

        internal void UpdateDamage(float damage)
        {
            damageText.text = string.Format("{0:0.##}", damage);
        }
        internal void UpdateHealth(float percent)
        {
            percent = Mathf.Clamp(percent, 0f, 100f);
            Vector3 newScale = healthBar.localScale;
            newScale.x = percent;
            healthBar.localScale = newScale;
        }
        internal void UpdateProtection(float prot)
        {
            protectionText.text = prot.ToString();
        }
        internal void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}