﻿namespace FootballMatchCrudApi.System.Exceptions
{
    public class ItemDoesNotExist : Exception
    {
        public ItemDoesNotExist(string? message) : base(message)
        {

        }
    }
}
