using CleanArchMvc.Domain.Validation;



namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity //Com Sealed, a classe não pode ser herdada
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set;} = string.Empty;

        public int CategoryId { get;  set; }  //Chave estrangeira para Category
  
        public Category Category { get;  set; } //Propriedade de navegação para Category


        //Construtores Sem e Com Id.
        public Product(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image); //Valida os dados do produto
            CategoryId = categoryId;
        }   

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido. Id deve ser maior que zero.");
            Id = id;
            ValidateDomain(name, description, price, stock, image); //Valida os dados do produto
            CategoryId = categoryId;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }


        public void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {   
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido, muito curto, mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida. Descrição é obrigatória");

            DomainExceptionValidation.When(description.Length < 5,
                "Descrição inválida, muito curta, mínimo 5 caracteres");

            DomainExceptionValidation.When(price < 0,
                "Preço inválido. Preço não pode ser negativo");

            DomainExceptionValidation.When(stock < 0,
                "Estoque inválido. Estoque não pode ser negativo");

            DomainExceptionValidation.When(image?.Length > 250,
                "Nome da imagem inválido. Nome da imagem muito longo, máximo 250 caracteres");

            //Caso passe nas validações, atribui os valores às propriedades
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }



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

