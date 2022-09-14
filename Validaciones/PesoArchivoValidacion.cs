using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Validaciones
{
    //validacion por atributo para poderla repetir en otros Ifromfile
    public class PesoArchivoValidacion:ValidationAttribute
    {
        private readonly int pesoMaximoEnMegabytes;

        public PesoArchivoValidacion(int pesoMaximoEnMegabytes)
        {
            this.pesoMaximoEnMegabytes = pesoMaximoEnMegabytes;
        }
        // sobreescribimos el metodo Isvalid
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formFile = value as IFormFile;

            if(formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length > pesoMaximoEnMegabytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor de {pesoMaximoEnMegabytes}mb");
            }
            return ValidationResult.Success;
        }

    }
}
