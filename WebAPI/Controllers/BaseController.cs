using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BaseController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi =true)]
    public IActionResult HandleDataResult<T>(IDataResult<T> dataResult)
    {
        return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
    }




    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleResult(Core.Utilities.Results.IResult result)
    {
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
