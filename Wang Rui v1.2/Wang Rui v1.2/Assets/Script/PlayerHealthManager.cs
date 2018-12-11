using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private bool damaged = false;

    
	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        damaged = false;
	}

    public void HurtPlayer(int damageToGive)
    {
        damaged = true;
        playerCurrentHealth -= damageToGive;
        healthSlider.value = playerCurrentHealth;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
