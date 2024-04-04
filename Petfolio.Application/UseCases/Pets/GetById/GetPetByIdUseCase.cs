using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = 1,
            Name = "Alice",
            Type = Communication.Enum.PetType.Dog,
            Birthday  = new DateTime(year:2023, month:01, day:29)
        };

    }
}
