using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net;
using DBConnector;
using System.Collections.Generic;

public class Login : MonoBehaviour
{

    private string username;
    private string password;
    private string confirmPassword;
    public Text ErrorMessage;
    public CreateAccount createAccount;

    public string Username { set { username = value; } get { return username; } }
    public string Password { set { password = value; } get { return password; } }
    public string ConfirmPassword { set { confirmPassword = value; } get { return confirmPassword; } }

    EventSystem system;

    void Start()
    {
        system = EventSystem.current;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (system.currentSelectedGameObject.GetComponent<InputField>() != null)
            {
                Selectable next = system.currentSelectedGameObject.GetComponent<InputField>().FindSelectableOnDown();


                if (next != null)
                {

                    InputField inputfield = next.GetComponent<InputField>();
                    if (inputfield != null)
                        inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                    system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
                }
            }
            else
            {
                system.SetSelectedGameObject(system.firstSelectedGameObject);
            }

        }
    }



    public void SubmitForm()
    {
        Debug.Log("test1");
        Debug.Log(createAccount.isCreateAccount + "hejhej");
        if (!createAccount.isCreateAccount)
        {

            if (Username != null && Password != null)
            {
                if (Username.Length > 0 && Password.Length > 0)
                {
                    DBController controller = new DBController();
                    Player p = controller.GetCompletePlayer(username);

                    Debug.Log(p.Username.Length);
                    if (p == null || p.Username.Length == 0)
                    {
                        ErrorMessage.text = "Invalid Username \n Please try again";
                    }
                    else
                    {
                        Utils.ChangeScene("MainMenu");
                    }

                }
                else
                {
                    ErrorMessage.text = "Please enter both Username and Password";
                }
            }
            else
            {
                ErrorMessage.text = "Please enter both Username and Password";
            }

        }
        else
        {
            // Create Account Logic
            if (Username != null && Password != null && ConfirmPassword != null)
            {
                if (Password != ConfirmPassword)
                {
                    ErrorMessage.text = "Please enter all Fields";
                    return;
                }

                System.Console.WriteLine("hey u made it! JK!");
            }
            else
            {
                ErrorMessage.text = "Please enter all Fields";
            }
        }
    }
}
