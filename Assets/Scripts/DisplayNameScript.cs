using UnityEngine;
using TMPro;

public class DisplayNameScript : MonoBehaviour
{
    public TextMeshProUGUI display_pet_name;  

    private const string PetNameKey = "PetName";  

    void Start()
    {
        string petName = PlayerPrefs.GetString(PetNameKey, "No Name");
        display_pet_name.text = petName;
    }
}
