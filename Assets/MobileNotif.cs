using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    private const string ChannelId = "game_notifications";

    private void Start()
    {
        CreateNotificationChannel();
    }

    // Creates the notification channel (required for Android 8.0 and above)
    private void CreateNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Name = "Game Notifications",
            Importance = Importance.High,
            Description = "Reminder Notification",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Schedules a notification with a specified message and delay
    public void ScheduleNotification(string title, string message, int delaySeconds)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = message,
            SmallIcon = "PetPal_Logo", // Default icon
            LargeIcon = "PetPal_Logo", // Custom large icon if needed
            FireTime = System.DateTime.Now.AddSeconds(delaySeconds)
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }

    
}
