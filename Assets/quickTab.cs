using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quickTab : MonoBehaviour
{
    [Header("Registration")]
    public InputField[] registration = new InputField[4];
    public Button regBtn;
    [Header("Login")]
    public InputField[] login = new InputField[2];
    public Button logBtn;

    private bool delay = true;

    private IEnumerator setDelay()
    {
        yield return new WaitForSeconds(0.1f);
        delay = true;
    }

    IEnumerator selectButton(Button btn)
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(btn.gameObject);
        yield return new WaitForSeconds(0.6f);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && delay)
        {
            delay = false;
            for (int i = 0; i < registration.Length; i++)
            {
                if (registration[i].isFocused)
                {
                    if (i == registration.Length - 1)
                    {
                        StartCoroutine(selectButton(regBtn));
                        StartCoroutine(setDelay());
                    }
                    else
                    {
                        registration[i + 1].Select();
                        //registration[i + 1].ActivateInputField();
                        StartCoroutine(setDelay());
                    }
                }
            }

            for (int i = 0; i < login.Length; i++)
            {
                if (login[i].isFocused)
                {
                    if (i == login.Length - 1)
                    {
                        StartCoroutine(selectButton(logBtn));
                        StartCoroutine(setDelay());
                    }
                    else
                    {
                        login[i + 1].Select();
                        //login[i + 1].ActivateInputField();
                        StartCoroutine(setDelay());
                    }
                }
            }

        }
    }

}
