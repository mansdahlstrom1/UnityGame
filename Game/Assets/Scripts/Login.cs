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
        if (!createAccount.isCreateAccount)
        {

            if (Username != null && Password != null)
            {
                if (Username.Length > 0 && Password.Length > 0)
                {
                    DBController controller = new DBController();
                    controller.GetCompletePlayer(username);

                    if (Player.Username != null)
                    {
                        if (Player.checkPassword(Password))
                        {
                            Utils.ChangeScene("MainMenu");
                        }
                        else
                        {
                            ErrorMessage.text = "Invalid Password \n Please try again";
                        }


                    }
                    else
                    {
                        ErrorMessage.text = "Invalid Username \n Please try again";
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
                    ErrorMessage.text = "Passwords entered does not match.";
                    return;
                }
                DBController controller = new DBController();
                controller.CreateUser(Username, Password);
                if (Player.Username != null)
                {
                    ErrorMessage.text = "Account Was created!";
                    createAccount.createAccountClick();
                }
                else
                {
                    ErrorMessage.text = "Something Went Wrong";
                }


            }
            else
            {
                ErrorMessage.text = "Please enter all Fields";
            }
        }
    }
}
