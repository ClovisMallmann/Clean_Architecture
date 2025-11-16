using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
{
    
}

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity //Com Sealed, a classe não pode ser herdada
    {


    //Construtores
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido. Id deve ser maior que zero.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

      
       //Definindo a relação de 1 para muitos entre Category e Product
       public ICollection<Product> Products { get; private set; }

       //Método de validação

        private void ValidateDomain(string name) //Duas regras de validação para o nome da categoria
        {   
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido, muito curto, mínimo 3 caracteres");

            //Caso passe nas validações, atribui o valor ao Name
            Name = name;
        }

    }
}