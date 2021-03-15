using System;

namespace Common.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(int id, string message = "")
            : base($"{typeof(T).Name} with Id={id} was not found. {message}")
        {
        }

        public EntityNotFoundException(string id, string message = "")
            : base($"{typeof(T).Name} with Id={id} was not found. {message}")
        {
        }
    }
}