using System.Globalization;

namespace Petfolio.Communication.Responses;

public class ResponseErrorsJson
{
    public List<StringInfo> Errors { get; set; } = [];
}
