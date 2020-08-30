using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.ViewModel
{
    public class SignUpViewModel : IValidatableObject
    {
      
        [Required(ErrorMessage ="username is required")]
        [StringLength(200,MinimumLength =6,ErrorMessage ="username out of allow length")]

        public string UserName { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(200,MinimumLength =6,ErrorMessage ="password out of allow length")]
        public string Passward { get; set; }

        [Required(ErrorMessage = "please confirm password")]
        public string ConfirmPassword { get; set; }

        public bool IsConfirmPassword => Passward?.Equals(ConfirmPassword??string.Empty)??false;

        public string ErrorMessage => Validate(new ValidationContext(this)).Select(e => e.ErrorMessage).ToLineString(Environment.NewLine);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(UserName))
            {
                yield return new ValidationResult(
                    $"{nameof(UserName)} is required.",
                    new[] { nameof(UserName) });
            }
            else 
            if( UserName.Length<6 || UserName.Length>200 )
            {
                yield return new ValidationResult(
                    $"{nameof(UserName)} out of allow length.",
                    new[] { nameof(UserName) });
            } else
            if (String.IsNullOrEmpty(Passward) || Passward.Length < 6 || Passward.Length > 200)
            {
                yield return new ValidationResult(
                    $"{nameof(Passward)} out of allow length.",
                    new[] { nameof(Passward) });
            } else
            if (String.IsNullOrEmpty(ConfirmPassword))
            {
                yield return new ValidationResult(
                    $"please confirm password.",
                    new[] { nameof(ConfirmPassword) });
            } else
            if (!IsConfirmPassword)
            {
                yield return new ValidationResult(
                    $"please enter confirm password curectly.",
                    new[] { nameof(ConfirmPassword) });
            }
        }
    }
}
