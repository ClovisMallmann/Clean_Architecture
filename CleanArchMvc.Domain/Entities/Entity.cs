namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity     //Classe base abstrata para entidades do domínio
    {
        public int Id { get; protected set; } 
        public string Name { get; protected set; } = string.Empty;
    }

    //A classe Entity serve como base para outras entidades, fornecendo propriedades comuns como Id e Name.
    //Isto é uma boa prática DDD (Domain-Driven Design) para garantir consistência e reutilização de código nas 
    // entidades do domínio.
}