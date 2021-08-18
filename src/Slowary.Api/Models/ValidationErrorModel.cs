using System.Collections.Generic;

namespace Slowary.Api.Models
{
    public class ValidationErrorModel
    {
        public string FieldName { get; }
        public IList<string> Messages { get; }

        public ValidationErrorModel(string fieldName, IList<string> messages)
        {
            FieldName = fieldName;
            Messages = messages;
        }
    }

    public class ValidationErrorModelCollection
    {
        public int ErrorCount => Errors.Count;
        public IList<ValidationErrorModel> Errors { get; }

        public ValidationErrorModelCollection(IList<ValidationErrorModel> errors)
        {
            Errors = errors;
        }
    }
}