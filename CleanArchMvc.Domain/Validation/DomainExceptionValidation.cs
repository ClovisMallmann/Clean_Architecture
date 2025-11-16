namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation: Exception //classe de exceção personalizada
    {
        public DomainExceptionValidation(string error): base(error)
        { }

        public static void When(bool hasError, string error) //método estático para validar condições de domínio
        {
            if (hasError) //Se houver um erro, lança uma exceção de validação de domínio
            {
                throw new DomainExceptionValidation(error);
            }
        }

    }
} 