﻿namespace SmartHint.Lib.Utils.CustomExceptions
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException(string message, Exception ex = null) : base(message, ex) { }
    }
}
