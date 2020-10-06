using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vault : MonoBehaviour
{
    public string password;
    public float typeTimeout = 2;
    string currentPassword = "";
    public Text displayText;
    public Animator doorAnimator;
    public GameObject key;
    bool opened = false;

    public void typeNumber (int number)
    {
        Debug.Log("Typing vault number " + number);
        AudioManager.instance.SetPitch("Vault_Button", 0.7f + (float)number/10.0f);
        AudioManager.instance.PlaySound("Vault_Button", transform.position);
        if (opened) return;
        currentPassword += number;
        UpdateDisplay();
        if (currentPassword.Length >= password.Length)
        {
            if (currentPassword == password)
            {
                Open();
            }
            else
            {
                AudioManager.instance.PlaySound("Vault_Wrong", transform.position);
                Reset();
            }
            StopAllCoroutines();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(AutoReset());
        }
    }

    IEnumerator AutoReset()
    {
        yield return new WaitForSeconds(typeTimeout);
        if (!opened)
        {
            AudioManager.instance.PlaySound("Vault_Wrong", transform.position);
            Reset();
        }
    }

    void Reset()
    {
        currentPassword = "";
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayText.text = currentPassword;
    }

    void Open()
    {
        opened = true;
        doorAnimator.SetTrigger("Open");
        AudioManager.instance.PlaySound("Vault_Open", transform.position);
        key.SetActive(true);
    }
}
