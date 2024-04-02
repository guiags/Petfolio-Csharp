using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetsJson Execute()
    {
        return new ResponseAllPetsJson
        {
            Pets = new List<ResponseShortPetJson> {

                new ResponseShortPetJson{
                    Id = 1,
                    Name = "Alice",
                    Type = Communication.Enum.PetType.Dog
                },
                new ResponseShortPetJson{
                    Id = 2,
                    Name = "Lorde",
                    Type = Communication.Enum.PetType.Dog
                }
            }
        };


    }
}
