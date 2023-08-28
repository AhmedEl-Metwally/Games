namespace Games.Attributes
{
    public class AllowedExtentsionsAttributes :ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtentsionsAttributes(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file is not null)
            {
                var extention = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtensions.Split(',') .Contains(extention , StringComparer.OrdinalIgnoreCase);

                if(!isAllowed) 
                {
                    return new ValidationResult($"Only {_allowedExtensions} are allowed");
                }
            }

            return ValidationResult.Success;    
        }
    }
}
