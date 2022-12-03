using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes
{
    public class ValidateImageFileAttribute : RequiredAttribute
    {
        private const int MaxFileLengthInBytes = 1048576; // = 1 MB

        public override bool IsValid(object value)
        {
            // The File sent from the HTTPRequest
            IFormFile file = value as IFormFile;

            if (file == null)
            {
                return false;
            }

            if (file.Length > MaxFileLengthInBytes)
            {
                return false;
            }

            // Mime Types Validating
            if (file.ContentType.ToLower() != "image/jpg"
                && file.ContentType.ToLower() != "image/jpeg"
                && file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            return true;
        }
    }
}
