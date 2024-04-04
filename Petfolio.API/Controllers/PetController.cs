using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]//Caso de erro
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var usecase = new RegisterPetUseCase();
        var response = usecase.Execute(request);
        return Created(string.Empty, response);

    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]//Caso de erro
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
    {
        var usecase = new UpdatePetUseCase();
        usecase.Execute(id, request);
        return NoContent();
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetsJson), StatusCodes.Status200OK)]//ResponseAllPetsJson nada mais é do que uma list de ResponseShortPetJSon apenas por ser mais aceito, poderia ser simplemnte a lista noa tributo desta parte
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var usecase = new GetAllPetsUseCase();
        var response = usecase.Execute();
        if (response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]//ResponseAllPetsJson nada mais é do que uma list de ResponseShortPetJSon apenas por ser mais aceito, poderia ser simplemnte a lista noa tributo desta parte
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetId(int id)
    {
        var useCase = new GetPetByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status204NoContent)]//ResponseAllPetsJson nada mais é do que uma list de ResponseShortPetJSon apenas por ser mais aceito, poderia ser simplemnte a lista noa tributo desta parte
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeletePetByIdUseCase();
        useCase.Execute(id);
        return NoContent();
    }
}
