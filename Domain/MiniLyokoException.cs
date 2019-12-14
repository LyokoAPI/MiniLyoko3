using System;

namespace Domain
{
    public abstract class MiniLyokoException : Exception
    {
        public abstract void Resolve(string parameter = "");
    }
}