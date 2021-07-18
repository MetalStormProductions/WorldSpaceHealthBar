using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaWheel;

    private float maxHealth = 250f;
    private float currentHealth;

    private float maxMana = 100f;
    private float currentMana;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        UpdateHealthBar();
        UpdateManaWheel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 15f;
            UpdateHealthBar();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            currentMana -= 5f;
            UpdateManaWheel();
        }

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        canvasTransform.LookAt(transform.position + Camera.main.transform.forward);
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void UpdateManaWheel()
    {
        manaWheel.fillAmount = currentMana / maxMana;
    }
}
