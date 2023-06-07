using UnityEngine;
using EasyUI.Dialogs;

public class Demo : MonoBehaviour
{
    void Start()
    {

        DialogUI.Instance
            .SetTitle("GAME OVER")
            .SetMessage("You Win ***")
            .Show();

    }
} 
 