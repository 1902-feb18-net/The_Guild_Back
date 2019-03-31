﻿using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace The_Guild_Back.BLL
{
    public class Users
    {
        private string _firstName, _lastName, _userName;
        private int? _strength, _dex, _intelligence, _wisdom, _charisma, _constitution;
        private decimal? _salary;

        public int Id { get; set; }
        public int? RankId { get; set; }

        public string UserName
        {
            get => _userName;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _userName = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                Guard.Against.NullOrWhiteSpace(value, nameof(value));
                _lastName = value;
            }
        }

        public int? Strength
        {
            get => _strength;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _strength = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int? Dex
        {
            get => _dex;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _dex = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int? Intelligence
        {
            get => _intelligence;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _intelligence = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int? Wisdom
        {
            get => _wisdom;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _wisdom = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int? Charisma
        {
            get => _charisma;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _charisma = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int? Constitution
        {
            get => _constitution;
            set
            {
                if (CheckConstraints.NonNegativeInt(value)) //allows setting null, 0, or positive
                { _constitution = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public decimal? Salary
        {
            get => _salary;
            set
            {
                if (CheckConstraints.NonNegativeDecimal(value)) //allows setting null, 0, or positive
                { _salary = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
}
        }
    }
}
