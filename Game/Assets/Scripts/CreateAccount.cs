using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CreateAccount : MonoBehaviour {

    // State 0 = Login
    // State 1 = Create Account
    private bool isCreateAccount = false;
    public GameObject LoginButton;
    public GameObject CreateAccountText;
    public EventSystem eventSystem;
    public Text LoginButtonText;


    public void createAccountClick()
    {
        Button btn = LoginButton.GetComponent<Button>();
        Text text = CreateAccountText.GetComponent<Text>();
        if (!isCreateAccount)
        {   
            moveDown(btn);
            moveDown(text);
            LoginButtonText.text = "Create Account";
        } else
        {
            moveUp(btn);
            moveUp(text);
            LoginButtonText.text = "Login";
            
        }

        isCreateAccount = !isCreateAccount;
    }

    public void moveUp(Component go)
    {
        Vector3 newPosition = new Vector3(go.transform.position.x, go.transform.position.y + 40, go.transform.position.z);
        go.transform.position = newPosition;
    }

    public void moveDown(Component go)
    {
        Vector3 newPosition = new Vector3(go.transform.position.x, go.transform.position.y - 40, go.transform.position.z);
        go.transform.position = newPosition;
    }
}
