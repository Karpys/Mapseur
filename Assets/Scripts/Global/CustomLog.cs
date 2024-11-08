namespace Mapseur
{
    using System.Collections.Generic;
    using UnityEngine;

    public static class CustomLog
    {
        public static void Log(this object target, string log)
        {
            Debug.Log(log +" : " +target);
        }
            
        public static void LogError(this object target, string log)
        {
            Debug.LogError(log +" : " +target);
        }
            
        public static void LogList<T>(this T[] log,string startMessage = "Start",string endMessage = "End")
        {
            Debug.Log(startMessage);
            foreach (T obj in log)
            {
                Debug.Log(obj);
            }
            Debug.Log(endMessage);
        }
            
        public static void LogList<T>(this List<T> log,string startMessage = "Start",string endMessage = "End")
        {
            Debug.Log(startMessage);
            foreach (T obj in log)
            {
                Debug.Log(obj);
            }
            Debug.Log(endMessage);
        }
    }
}
