using Microsoft.AspNetCore.Mvc;

namespace OD_Stat.Helpings
{
    public static class ObjectResultExtentions
    {
        public static T Cast<T>(this ObjectResult objResult)
        {
            return (T) objResult.Value;
        }
    }
}