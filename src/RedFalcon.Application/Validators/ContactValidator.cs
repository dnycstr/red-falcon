﻿using RedFalcon.Application.Interfaces.Validator;
using RedFalcon.Domain.Entities;

namespace RedFalcon.Application.Validators
{
    public class ContactValidator : IContactValidator
    {
        public async Task<bool> ValidateData(Contact value)
        {
            if (value == null)
                return false;





            return true;
        }
    }
}
