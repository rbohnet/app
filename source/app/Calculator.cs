﻿using System;
using System.Data;
using System.Linq;

namespace app
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);

            connection.Open();
            connection.CreateCommand().ExecuteNonQuery();

            return first + second;
        }

        void ensure_all_are_positive(params int[] numbers)
        {
            if (numbers.All(x => x > 0)) return;
            throw new ArgumentException("Can't deal with negatives");
        }
    }
}