using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameScript : MonoBehaviour
{
    public TextMeshProUGUI display_pet_name;

    public void Awake ()
    {
        display_pet_name.text = PawScript.scene1.pet_name;
    }
}
