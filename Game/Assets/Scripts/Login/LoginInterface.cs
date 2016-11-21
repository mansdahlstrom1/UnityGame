using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LoginInterface : MonoBehaviour
{

    // State 0 = Login
    // State 1 = Create Account
    public bool isCreateAccount = false;
    public GameObject LoginButton;
    public GameObject CreateAccountText;
    public EventSystem eventSystem;
    public Text LoginButtonText;

    public void createAccountClick()
    {
        Button btn = LoginButton.GetComponent<Button>();
        Text cat = CreateAccountText.GetComponent<Text>();
        if (!isCreateAccount)
        {
            moveDown(btn);
            moveDown(cat);
            LoginButtonText.text = "Create Account";
            cat.text = "Go back to login";
        }
        else
        {
            moveUp(btn);
            moveUp(cat);
            LoginButtonText.text = "Login";
            cat.text = "Don't have and account?";
        }

        isCreateAccount = !isCreateAccount;
    }

    public void moveUp(Component go)
    {
        Vector3 newPosition = new Vector3(go.transform.position.x, go.transform.position.y + 80, go.transform.position.z);
        go.transform.position = newPosition;
    }

    public void moveDown(Component go)
    {
        Vector3 newPosition = new Vector3(go.transform.position.x, go.transform.position.y - 80, go.transform.position.z);
        go.transform.position = newPosition;
    }
}
