using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name"); //Criando uma instância de Category com parâmetros válidos
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
            //não será lançada nenhuma exceção de validação de domínio
    }

    [Fact(DisplayName = "Create Category With Invalid State")]
    public void CreateCategory_NegativeIdValue_ResultException()
    {
        Action action = () => new Category(-1, "f43f534v435v"); //Criando uma instância de Category com parâmetros inválidos
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Id inválido. Id deve ser maior que zero.");
    }
}

//O Desenvolvedor deverá aplicar o máximo de testes possíveis para garantir a integridade do domínio
//e a validação das regras de negócio implementadas nas entidades do domínio.
