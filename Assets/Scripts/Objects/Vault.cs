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
        Reset();
    }

    void Reset()
    {
        currentPassword = "";
        UpdateDisplay();
        AudioManager.instance.PlaySound("Vault_Wrong", transform.position);
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
