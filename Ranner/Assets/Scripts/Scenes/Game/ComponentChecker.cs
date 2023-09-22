using UnityEngine;

namespace Scenes.Game
{
    public static class ComponentChecker
    {
        public static bool IsHaveType<T>(this GameObject obj, out T t)
        {
            t = obj.GetComponent<T>();

            return t != null;
        }
    }
}