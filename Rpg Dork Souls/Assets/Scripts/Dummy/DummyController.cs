using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyController : MonoBehaviour, IDamageable
{
    int max_life = 200;
    int life;

    [SerializeField] Image healthHolder;
    [SerializeField] Image health;


    #region Damageable
    public void TakeDamage(int damage)
    {
        Damage(damage);
    }

    private void Damage(int damage)
    {
        Debug.Log("Damage: "+damage);
        life -= damage;
        Debug.Log("life:" + life);
        float pct = Mathf.InverseLerp(0,max_life,life);
        
        health.rectTransform.localScale = new Vector2(pct, health.rectTransform.localScale.y);

    }
    #endregion
    void OnEnable()
    {
        life = max_life;
        health.rectTransform.localScale = new Vector2(1, health.rectTransform.localScale.y);
    }
    
}
