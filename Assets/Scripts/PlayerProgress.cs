using UnityEngine;

public static class PlayerProgress
{
    private const string PetNameKey = "NameEntered"; // This key tracks if a name was entered
    private const string SelectedEggKey = "SelectedEgg"; // This key tracks the selected egg
    private const string PlayerNameKey = "PlayerName"; // Key for saving the player's name

    public static bool HasName()
    {
        return PlayerPrefs.GetInt(PetNameKey, 0) == 1; // Check if the name has been entered
    }

    public static void SaveNameEntered(bool hasEnteredName)
    {
        PlayerPrefs.SetInt(PetNameKey, hasEnteredName ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static string GetSelectedEgg()
    {
        return PlayerPrefs.GetString(SelectedEggKey, ""); // Retrieve the selected egg
    }

    public static void SaveSelectedEgg(string eggType)
    {
        PlayerPrefs.SetString(SelectedEggKey, eggType); // Save the selected egg type
        PlayerPrefs.Save();
    }

    public static string GetPlayerName() // Method to get the player's name
    {
        return PlayerPrefs.GetString(PlayerNameKey, ""); // Retrieve the player's name, default to an empty string
    }
}
