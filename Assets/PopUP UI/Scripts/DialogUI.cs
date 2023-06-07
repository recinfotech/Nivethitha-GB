using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs
{
    public class Dialog
    {
        public string Title = "Title";
        public string Message = "Message";  
    }

public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
        [SerializeField] Button quitUIButton;

        Dialog dialog = new Dialog();

        public static DialogUI Instance;

        private void Awake()
        {
            Instance = this;
            //Add close event listener
            quitUIButton.onClick.RemoveAllListeners();
            quitUIButton.onClick.AddListener(Hide);
        }
        //set dialogue Title
        public DialogUI SetTitle(string title)
        {
            dialog.Title = title;
            return Instance;
        }
        //Set dialogue message
        public DialogUI SetMessage(string message) 
        { 
            dialog.Message = message;   
            return Instance;    
        }

        //Show dialogue
        public void Show()

            
        {
            titleUIText.text = dialog.Title;
            messageUIText.text = dialog.Message;

            
            canvas.SetActive(true);
        }

        //Hide dialogue

        public void Hide() 
        {
            canvas.SetActive(false);
            //Reset dialogue

            dialog = new Dialog();
            
        }
    }
}
