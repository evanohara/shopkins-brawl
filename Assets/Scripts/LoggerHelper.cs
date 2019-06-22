using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerHelper : MonoBehaviour
{
    public static void LogFromPlayer(Player player, string loggingClass, string message)
    {
        Debug.Log("Player logged: '" + message + "' : from the class - " + loggingClass);
    }
}
