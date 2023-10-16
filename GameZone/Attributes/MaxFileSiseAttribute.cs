namespace GameZone.Attributes
{
    public class MaxFileSiseAttribute : ValidationAttribute
    {
        private readonly int _maxFileSiza;

        public MaxFileSiseAttribute(int maxFileSize)
        {
            _maxFileSiza = maxFileSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                if (file.Length > _maxFileSiza)
                    return new ValidationResult($"Maximum allowed size is {_maxFileSiza} bytes!");
            }

            return ValidationResult.Success;
        }
    }
}
