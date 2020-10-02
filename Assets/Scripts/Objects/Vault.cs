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
    bool opened = false;

    public void typeNumber (int number)
    {
        if (opened) return;
        currentPassword += number;
        if (currentPassword.Length > 4)
        {
            if (currentPassword == password)
            {
                Open();
            }
            else
            {
                Reset();
            }
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
        AudioManager.instance.PlaySound("Vault_Wrong", transform.position);
        Reset();
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
    }
}
